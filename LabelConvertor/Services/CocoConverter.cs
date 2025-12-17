using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LabelConvertor.CocoToVoc;
using System.Xml.Linq;

namespace LabelConvertor
{
	public class CocoDataset
	{
		public List<Category> categories { get; set; } = new List<Category> ();
		public List<ImageInfo> images { get; set; } = new List<ImageInfo> ();
		public List<Annotation> annotations { get; set; } = new List<Annotation> ();
	}

	public class Category
	{
		public int id { get; set; }          // ⚠ 從 1 開始
		public string name { get; set; }
		public string supercategory  { get; set; } = "none";
	}

	public class ImageInfo
	{
		public long id { get; set; }
		public string file_name { get; set; }
		public int width { get; set; }
		public int height { get; set; }

		// COCO official fields
		public int? license { get; set; } = null;
		public string coco_url { get; set; } = null;
		public string flickr_url { get; set; } = null;
		public string date_captured { get; set; }
	}

	public class Annotation
	{
		public long id { get; set; }
		public long image_id { get; set; }
		public int category_id { get; set; }	// ⚠ 對應從 1 開始的 category id
		public List<float> bbox { get; set; }   // COCO: [x, y, w, h]

		public float area { get; set; }
		public int iscrowd { get; set; } = 0;

		[JsonIgnore]
		public object segmentation { get; set; }
	}

	public static class CocoUtils
	{
		public static CocoDataset Load(string jsonPath)
		{
			if (!File.Exists(jsonPath))
				throw new FileNotFoundException(jsonPath);

			return JsonConvert.DeserializeObject<CocoDataset>(
				File.ReadAllText(jsonPath)
			);
		}

		public static Dictionary<int, string> BuildCategoryMap(CocoDataset coco)
		{
			return coco.categories.ToDictionary(c => c.id, c => c.name);
		}

		public static Dictionary<long, List<Annotation>> GroupByImage(CocoDataset coco)
		{
			return coco.annotations
					   .GroupBy(a => a.image_id)
					   .ToDictionary(g => g.Key, g => g.ToList());
		}
	}

	public static class CocoToVocConverter
	{
		public static void Convert(string jsonPath, string xmlSavePath)
		{
			var coco = CocoUtils.Load(jsonPath);
			var classMap = CocoUtils.BuildCategoryMap(coco);
			var annByImage = CocoUtils.GroupByImage(coco);

			if (!Directory.Exists(xmlSavePath))
				Directory.CreateDirectory(xmlSavePath);

			foreach (var img in coco.images)
			{
				XElement annotation =
					new XElement("annotation",
						new XElement("filename", img.file_name),
						new XElement("size",
							new XElement("width", img.width),
							new XElement("height", img.height),
							new XElement("depth", 3)
						),
						new XElement("segmented", 0)
					);

				if (annByImage.ContainsKey(img.id))
				{
					foreach (var ann in annByImage[img.id])
					{
						int xmin = (int)ann.bbox[0];
						int ymin = (int)ann.bbox[1];
						int xmax = xmin + (int)ann.bbox[2];
						int ymax = ymin + (int)ann.bbox[3];

						annotation.Add(
							new XElement("object",
								new XElement("name", classMap[ann.category_id]),
								new XElement("bndbox",
									new XElement("xmin", xmin),
									new XElement("ymin", ymin),
									new XElement("xmax", xmax),
									new XElement("ymax", ymax)
								)
							)
						);
					}
				}

				string xmlPath = Path.Combine(
					xmlSavePath,
					Path.GetFileNameWithoutExtension(img.file_name) + ".xml"
				);

				new XDocument(annotation).Save(xmlPath);
			}
		}
	}

	public static class CocoToYoloConverter
	{
		public static void Convert(string jsonPath, string txtSavePath)
		{
			var coco = CocoUtils.Load(jsonPath);
			var annByImage = CocoUtils.GroupByImage(coco);

			if (!Directory.Exists(txtSavePath))
				Directory.CreateDirectory(txtSavePath);

			// classes.txt（依照 category id 排序）
			var categories = coco.categories.OrderBy(c => c.id).ToList();
			File.WriteAllLines(
				Path.Combine(txtSavePath, "classes.txt"),
				categories.Select(c => c.name)
			);

			var catIdToIndex = categories
				.Select((c, i) => new { c.id, index = i })
				.ToDictionary(x => x.id, x => x.index);

			foreach (var img in coco.images)
			{
				string txtPath = Path.Combine(
					txtSavePath,
					Path.ChangeExtension(img.file_name, ".txt")
				);

				using (StreamWriter sw = new StreamWriter (txtPath))
				{
					if (!annByImage.ContainsKey (img.id))
						continue;

					foreach (var ann in annByImage [img.id])
					{
						float x = ann.bbox[0];
						float y = ann.bbox[1];
						float w = ann.bbox[2];
						float h = ann.bbox[3];

						float xc = (x + w / 2f) / img.width;
						float yc = (y + h / 2f) / img.height;
						float wn = w / img.width;
						float hn = h / img.height;

						int classIndex = catIdToIndex[ann.category_id];

						sw.WriteLine (
							$"{classIndex} {xc:F6} {yc:F6} {wn:F6} {hn:F6}"
						);
					}
				}
			}
		}
	}

}
