using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelConvertor
{
	internal class YoloToCoco
	{
		private CocoRoot coco;
		private int imageId = 0;
		private int annotationId = 0;

		public YoloToCoco()
		{
			coco = new CocoRoot
			{
				images = new List<CocoImage>(),
				annotations = new List<CocoAnnotation>(),
				categories = new List<CocoCategory>(),
				type = "instances"
			};
		}

		// ---------------------------
		//  Coco structures
		// ---------------------------
		public class CocoRoot
		{
			public string type { get; set; }
			public List<CocoImage> images { get; set; }
			public List<CocoAnnotation> annotations { get; set; }
			public List<CocoCategory> categories { get; set; }
		}

		public class CocoImage
		{
			public int id { get; set; }
			public string file_name { get; set; }
			public int width { get; set; }
			public int height { get; set; }
			public object license { get; set; }
			public object flickr_url { get; set; }
			public object coco_url { get; set; }
			public string date_captured { get; set; }
		}

		public class CocoAnnotation
		{
			public int id { get; set; }
			public int image_id { get; set; }
			public int category_id { get; set; }
			public List<List<int>> segmentation { get; set; }
			public List<int> bbox { get; set; }
			public float area { get; set; }
			public int iscrowd { get; set; }
			public int ignore { get; set; }
		}

		public class CocoCategory
		{
			public int id { get; set; }
			public string name { get; set; }
			public string supercategory { get; set; }
		}

		// ---------------------------
		// Add Category
		// ---------------------------
		private void AddCategoryItems(Dictionary<int, string> dict)
		{
			foreach (var kv in dict)
			{
				coco.categories.Add(new CocoCategory
				{
					id = kv.Key,
					name = kv.Value,
					supercategory = "none"
				});
			}
		}

		// ---------------------------
		// Add Image
		// ---------------------------
		private int AddImage(string fileName, int height, int width)
		{
			imageId++;

			coco.images.Add(new CocoImage
			{
				id = imageId,
				file_name = fileName,
				width = width,
				height = height,
				license = null,
				flickr_url = null,
				coco_url = null,
				date_captured = DateTime.Now.ToString()
			});

			return imageId;
		}

		// ---------------------------
		// Add Annotation
		// ---------------------------
		private void AddAnnotation(string name, int imageId, int categoryId, List<int> bbox)
		{
			annotationId++;

			var x = bbox[0];
			var y = bbox[1];
			var w = bbox[2];
			var h = bbox[3];

			var seg = new List<int>
			{
				x, y,
				x, y + h,
				x + w, y + h,
				x + w, y
			};

			coco.annotations.Add(new CocoAnnotation
			{
				id = annotationId,
				image_id = imageId,
				category_id = categoryId,
				bbox = bbox,
				area = w * h,
				iscrowd = 0,
				ignore = 0,
				segmentation = new List<List<int>> { seg }
			});
		}

		// ---------------------------
		// YOLO xywhn → COCO xywh
		// ---------------------------
		private List<int> YoloToCoco2(string[] bboxStr, int imgH, int imgW)
		{
			double xc = double.Parse(bboxStr[0]);
			double yc = double.Parse(bboxStr[1]);
			double w = double.Parse(bboxStr[2]);
			double h = double.Parse(bboxStr[3]);

			double xmin = (xc - w / 2) * imgW;
			double ymin = (yc - h / 2) * imgH;

			return new List<int>
			{
				(int)xmin,
				(int)ymin,
				(int)(w * imgW),
				(int)(h * imgH)
			};
		}

		// ----------------------------------------------------
		// Main Function = parseXmlFiles()
		// ----------------------------------------------------
		public void Convert(string imagePath, string annoPath, string jsonOutput, string[] preDefinedClasses = null)
		{
			if (!Directory.Exists(imagePath))
				throw new Exception($"ERROR {imagePath} does not exist");

			if (!Directory.Exists(annoPath))
				throw new Exception($"ERROR {annoPath} does not exist");

			// Load class list
			string classFile = Path.Combine(annoPath, "classes.txt");
			var categories = File.ReadAllLines(classFile).Select(x => x.Trim()).ToList();
			
			var categoryDict = preDefinedClasses != null
				? preDefinedClasses.Select((v, i) => new { v, i }).ToDictionary(x => x.i, x => x.v)
				: categories.Select((v, i) => new { v, i }).ToDictionary(x => x.i, x => x.v);

			AddCategoryItems (categoryDict);
			
			var imageFiles = Directory.GetFiles(imagePath);
			var annoFiles = Directory.GetFiles(annoPath);

			var imageIndex = imageFiles.ToDictionary(
				f => Path.GetFileNameWithoutExtension(f),
				f => f);

			foreach (var txtFile in annoFiles)
			{
				if (Path.GetExtension(txtFile) != ".txt" || Path.GetFileName(txtFile).Contains("classes"))
					continue;

				string key = Path.GetFileNameWithoutExtension(txtFile);
				if (!imageIndex.ContainsKey(key))
					continue;

				string imgFile = imageIndex[key];
				Bitmap bmp = new Bitmap(imgFile);
				int h = bmp.Height;
				int w = bmp.Width;

				int currImgId = AddImage(Path.GetFileName(imgFile), h, w);

				// Read annotation
				foreach (var line in File.ReadAllLines(txtFile))
				{
					var parts = line.Trim().Split(' ');
					int cat = int.Parse(parts[0]);
					string name = categoryDict[cat];

					var bbox = YoloToCoco2(parts.Skip(1).ToArray(), h, w);

					AddAnnotation(name, currImgId, cat, bbox);
				}
			}

			// Output JSON
			var json = JsonConvert.SerializeObject(
				coco,
				Formatting.Indented      // 等同 WriteIndented = true
			);
			File.WriteAllText(jsonOutput, json);

			Console.WriteLine($"class nums: {coco.categories.Count}");
			Console.WriteLine($"image nums: {coco.images.Count}");
			Console.WriteLine($"bbox nums: {coco.annotations.Count}");
		}
	}
}
