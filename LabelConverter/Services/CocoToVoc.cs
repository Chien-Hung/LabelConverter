using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LabelConverter
{
	public class CocoToVoc
	{
		public static string [] ExtractClasses (string jsonFile)
		{
			if (!File.Exists(jsonFile))
			{
				throw new FileNotFoundException($"JSON file not found: {jsonFile}");
			}

			string jsonContent = File.ReadAllText(jsonFile);
			CocoAnnotation coco = JsonConvert.DeserializeObject<CocoAnnotation>(jsonContent);
			var classes = coco.categories.ToDictionary(c => c.id, c => c.name);
			var classNames = classes.Values.ToArray();

			return classNames;
		}

		public class CocoAnnotation
		{
			public List<Category> categories { get; set; }
			public List<ImageInfo> images { get; set; }
			public List<Annotation> annotations { get; set; }
		}

		public class Category
		{
			public int id { get; set; }
			public string name { get; set; }
		}

		public class ImageInfo
		{
			public long id { get; set; }
			public string file_name { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class Annotation
		{
			public long id { get; set; }
			public long image_id { get; set; }
			public int category_id { get; set; }
			public List<float> bbox { get; set; }   // x,y,w,h
		}


		public class CocoToVocConverter
		{
			// 建立 category id -> name 對應
			private static Dictionary<int, string> CatId2Name(CocoAnnotation coco)
			{
				return coco.categories.ToDictionary(c => c.id, c => c.name);
			}

			// 將 annotation 存成 XML
			private static void SaveXml(string filename, ImageInfo img, List<Tuple<string, int, int, int, int>> objs, string savePath)
			{
				XElement annotation =
					new XElement("annotation",
						new XElement("folder", "DATA"),
						new XElement("filename", filename),
						new XElement("source",
							new XElement("database", "The VOC Database"),
							new XElement("annotation", "PASCAL VOC"),
							new XElement("image", "flickr")
						),
						new XElement("size",
							new XElement("width", img.width),
							new XElement("height", img.height),
							new XElement("depth", 3)
						),
						new XElement("segmented", 0)
					);

				foreach (var obj in objs)
				{
					annotation.Add(
						new XElement("object",
							new XElement("name", obj.Item1),
							new XElement("pose", "Unspecified"),
							new XElement("truncated", 0),
							new XElement("difficult", 0),
							new XElement("bndbox",
								new XElement("xmin", obj.Item2),
								new XElement("ymin", obj.Item3),
								new XElement("xmax", obj.Item4),
								new XElement("ymax", obj.Item5)
							)
						)
					);
				}

				Directory.CreateDirectory(savePath);
				string xmlPath = Path.Combine(savePath, Path.GetFileNameWithoutExtension(filename) + ".xml");

				XDocument doc = new XDocument(annotation);
				doc.Save(xmlPath);
			}

			// 載入 COCO JSON 並轉換
			public static void ConvertCocoToVoc (string jsonPath, string xmlSavePath)
			{
				if (!File.Exists(jsonPath))
				{
					throw new FileNotFoundException($"JSON file not found: {jsonPath}");
				}

				if (Directory.Exists(xmlSavePath))
					Directory.Delete(xmlSavePath, true);
				Directory.CreateDirectory(xmlSavePath);

				string jsonContent = File.ReadAllText(jsonPath);
				CocoAnnotation coco = JsonConvert.DeserializeObject<CocoAnnotation>(jsonContent);

				var classes = CatId2Name(coco);

				// 依照 image 分組 annotation
				var annByImage = coco.annotations.GroupBy(a => a.image_id)
												 .ToDictionary(g => g.Key, g => g.ToList());

				foreach (var img in coco.images)
				{
					List<Tuple<string, int, int, int, int>> objs = new List<Tuple<string, int, int, int, int>>();

					if (annByImage.ContainsKey(img.id))
					{
						foreach (var ann in annByImage[img.id])
						{
							string name = classes[ann.category_id];
							var bbox = ann.bbox.Select(v => (int)v).ToList();

							int xmin = bbox[0];
							int ymin = bbox[1];
							int xmax = bbox[0] + bbox[2];
							int ymax = bbox[1] + bbox[3];

							objs.Add(Tuple.Create(name, xmin, ymin, xmax, ymax));
						}
					}

					SaveXml(img.file_name, img, objs, xmlSavePath);
				}

				Console.WriteLine("Convert completed. XML saved to: " + xmlSavePath);
			}
		}
	}
}
