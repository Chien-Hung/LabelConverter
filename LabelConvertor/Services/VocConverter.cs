using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LabelConvertor
{
	public class VocAnnotation
	{
		public string Filename { get; set; }
		public VocSize Size { get; set; }
		public List<VocObject> Objects { get; set; } = new List<VocObject> ();
	}

	public class VocSize
	{
		public int Width { get; set; }
		public int Height { get; set; }
	}

	public class VocObject
	{
		public string Name { get; set; }
		public VocBndBox BndBox { get; set; }
	}

	public class VocBndBox
	{
		public int Xmin { get; set; }
		public int Ymin { get; set; }
		public int Xmax { get; set; }
		public int Ymax { get; set; }
	}

	public static class VocParser
	{
		public static VocAnnotation Parse(string xmlPath)
		{
			XDocument doc = XDocument.Load(xmlPath);
			XElement root = doc.Root;

			var sizeElem = root.Element("size");

			var anno = new VocAnnotation
			{
				Filename = root.Element("filename")?.Value,
				Size = new VocSize
				{
					Width = int.Parse(sizeElem.Element("width").Value),
					Height = int.Parse(sizeElem.Element("height").Value)
				}
			};

			foreach (var obj in root.Elements("object"))
			{
				var box = obj.Element("bndbox");
				anno.Objects.Add(new VocObject
				{
					Name = obj.Element("name").Value,
					BndBox = new VocBndBox
					{
						Xmin = int.Parse(box.Element("xmin").Value),
						Ymin = int.Parse(box.Element("ymin").Value),
						Xmax = int.Parse(box.Element("xmax").Value),
						Ymax = int.Parse(box.Element("ymax").Value)
					}
				});
			}

			return anno;
		}
	}

	public static class VocToYoloConverter
	{
		public static void Convert(string vocDir, string outputDir, string[] preDefinedClasses = null)
		{
			if (!Directory.Exists(outputDir))
				Directory.CreateDirectory(outputDir);

			List<string> classes = new List<string>();

			if (preDefinedClasses != null)
			{
				classes.AddRange (preDefinedClasses);
			}

			foreach (var xmlFile in Directory.GetFiles (vocDir, "*.xml"))
			{
				var anno = VocParser.Parse(xmlFile);
				string txtPath = Path.Combine(
					outputDir,
					Path.ChangeExtension(anno.Filename, ".txt")
				);

				using (StreamWriter sw = new StreamWriter (txtPath))
				{
					foreach (var obj in anno.Objects)
					{
						if (!classes.Contains (obj.Name))
							classes.Add (obj.Name);

						int clsId = classes.IndexOf(obj.Name);

						var box = ConvertToYolo(
							anno.Size,
							obj.BndBox
						);

						sw.WriteLine ($"{clsId} {box.x:F6} {box.y:F6} {box.w:F6} {box.h:F6}");
					}
				}
			}

			File.WriteAllLines(
				Path.Combine(outputDir, "classes.txt"),
				classes
			);
		}

		private static (double x, double y, double w, double h)
			ConvertToYolo(VocSize size, VocBndBox box)
		{
			double dw = 1.0 / size.Width;
			double dh = 1.0 / size.Height;

			double xc = (box.Xmin + box.Xmax) / 2.0;
			double yc = (box.Ymin + box.Ymax) / 2.0;

			double w = box.Xmax - box.Xmin;
			double h = box.Ymax - box.Ymin;

			return (
				xc * dw,
				yc * dh,
				w * dw,
				h * dh
			);
		}

		public static string [] ExtractClasses (string vocDir)
		{
			if (!Directory.Exists(vocDir))
				throw new DirectoryNotFoundException(vocDir);

			List<string> classes = new List<string>();

			foreach (var xmlFile in Directory.GetFiles (vocDir, "*.xml"))
			{
				var anno = VocParser.Parse(xmlFile);
				foreach (var obj in anno.Objects)
				{
					if (!classes.Contains (obj.Name))
						classes.Add (obj.Name);
				}
			}
			return classes.ToArray ();
		}
	}

	public static class VocToCocoConverter
	{
		public static void Convert(string vocDir, string jsonSavePath, string[] preDefinedClasses = null)
		{
			if (!Directory.Exists(vocDir))
				throw new DirectoryNotFoundException(vocDir);

			CocoDataset coco = new CocoDataset();

			Dictionary<string, int> categoryMap = new Dictionary<string, int>(); // name → id (from 1)

			if (preDefinedClasses != null)
			{
				foreach (var category in preDefinedClasses)
				{
					int catId = categoryMap.Count + 1;
					categoryMap [category] = catId;
					coco.categories.Add (new Category
					{
						id = catId,
						name = category,
						supercategory = "none"
					});
				}
			}

			int imageId = 0;
			int annotationId = 0;
			int categoryIdCounter = 1;

			foreach (var xmlFile in Directory.GetFiles(vocDir, "*.xml"))
			{
				var voc = VocParser.Parse(xmlFile);
				imageId++;

				// ---------- Image ----------
				coco.images.Add(new ImageInfo
				{
					id = imageId,
					file_name = voc.Filename,
					width = voc.Size.Width,
					height = voc.Size.Height,
					license = null,
					coco_url = null,
					flickr_url = null,
					date_captured = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")
				});

				// ---------- Objects ----------
				foreach (var obj in voc.Objects)
				{
					// Category (id from 1)
					if (!categoryMap.ContainsKey(obj.Name))
					{
						int catId = categoryIdCounter++;
						categoryMap[obj.Name] = catId;

						coco.categories.Add(new Category
						{
							id = catId,
							name = obj.Name,
							supercategory = "none"
						});
					}

					int categoryId = categoryMap[obj.Name];

					var b = obj.BndBox;
					int w = b.Xmax - b.Xmin;
					int h = b.Ymax - b.Ymin;

					coco.annotations.Add(new Annotation
					{
						id = ++annotationId,
						image_id = imageId,
						category_id = categoryId,
						bbox = new List<float>
						{
							b.Xmin,
							b.Ymin,
							w,
							h
						},
						area = w * h,
						iscrowd = 0,
						segmentation = new List<List<float>>
						{
							new List<float>
							{
								b.Xmin, b.Ymin,
								b.Xmin, b.Ymin + h,
								b.Xmin + w, b.Ymin + h,
								b.Xmin + w, b.Ymin
							}
						}
					});
				}
			}

			Directory.CreateDirectory(Path.GetDirectoryName(jsonSavePath));
			File.WriteAllText(
				jsonSavePath,
				JsonConvert.SerializeObject(coco, Formatting.Indented)
			);

			Console.WriteLine("VOC → COCO conversion completed");
			Console.WriteLine($"Images      : {coco.images.Count}");
			Console.WriteLine($"Categories  : {coco.categories.Count}");
			Console.WriteLine($"Annotations : {coco.annotations.Count}");
		}
	}
}
