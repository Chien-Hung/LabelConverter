using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using Newtonsoft.Json;

namespace LabelConvertor
{
	public class VocToCocoConverter2
	{
		public VocToCocoConverter2 ()
		{
			// Example usage
			string dataDir = @"path_to_data";  // Replace with your data directory
			string jsonSavePath = @"path_to_save\annotations.json";  // Replace with your output JSON path
			ParseXmlFiles(dataDir, jsonSavePath);
		}

		// Initialize COCO structure
		static Dictionary<string, object> coco = new Dictionary<string, object>
		{
			{ "images", new List<Dictionary<string, object>>() },
			{ "type", "instances" },
			{ "annotations", new List<Dictionary<string, object>>() },
			{ "categories", new List<Dictionary<string, object>>() }
		};

		static Dictionary<string, int> categorySet = new Dictionary<string, int>();
		static HashSet<string> imageSet = new HashSet<string>();

		static int categoryItemId = -1;
		static int imageId = 0;
		static int annotationId = 0;

		// Add category to COCO
		static int AddCatItem(string name)
		{
			categoryItemId++;
			var categoryItem = new Dictionary<string, object>
			{
				{ "supercategory", "none" },
				{ "id", categoryItemId },
				{ "name", name }
			};
			((List<Dictionary<string, object>>)coco["categories"]).Add(categoryItem);
			categorySet[name] = categoryItemId;
			return categoryItemId;
		}

		// Add image to COCO
		static int AddImgItem(string fileName, Dictionary<string, int> size)
		{
			if (fileName == null) throw new Exception("Could not find filename tag in xml file.");
			if (size["width"] == null) throw new Exception("Could not find width tag in xml file.");
			if (size["height"] == null) throw new Exception("Could not find height tag in xml file.");
			imageId++;
			var imageItem = new Dictionary<string, object>
			{
				{ "id", imageId },
				{ "file_name", fileName },
				{ "width", size["width"] },
				{ "height", size["height"] },
				{ "license", null },
				{ "flickr_url", null },
				{ "coco_url", null },
				{ "date_captured", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") }
			};
			((List<Dictionary<string, object>>)coco["images"]).Add(imageItem);
			imageSet.Add(fileName);
			return imageId;
		}

		// Add annotation to COCO
		static void AddAnnoItem(string objectName, int imageId, int categoryId, int[] bbox)
		{
			annotationId++;
			var annotationItem = new Dictionary<string, object>
			{
				{ "segmentation", new List<List<int>>() },
				{ "area", bbox[2] * bbox[3] },
				{ "iscrowd", 0 },
				{ "ignore", 0 },
				{ "image_id", imageId },
				{ "bbox", bbox },
				{ "category_id", categoryId },
				{ "id", annotationId }
			};

			var seg = new List<int>
			{
				bbox[0], bbox[1],  // left_top
				bbox[0], bbox[1] + bbox[3],  // left_bottom
				bbox[0] + bbox[2], bbox[1] + bbox[3],  // right_bottom
				bbox[0] + bbox[2], bbox[1]  // right_top
			};

			((List<List<int>>)annotationItem["segmentation"]).Add(seg);
			((List<Dictionary<string, object>>)coco["annotations"]).Add(annotationItem);
		}

		// Read image ids from file
		static List<string> ReadImageIds(string imageSetsFile)
		{
			return File.ReadLines(imageSetsFile).Select(line => line.Trim()).ToList();
		}

		// Parse XML files and generate COCO format
		public static void ParseXmlFiles(string dataDir, string jsonSavePath, string split = "train")
		{
			if (!Directory.Exists(dataDir)) throw new Exception($"Data path: {dataDir} does not exist");
			string labelFile = $"{split}.txt";
			string imageSetsFile = Path.Combine(dataDir, "ImageSets", "Main", labelFile);

			List<string> xmlFilesList = new List<string>();
			if (File.Exists(imageSetsFile))
			{
				var ids = ReadImageIds(imageSetsFile);
				xmlFilesList = ids.Select(id => Path.Combine(dataDir, "Annotations", $"{id}.xml")).ToList();
			}
			else if (Directory.Exists(dataDir))
			{
				string xmlDir = dataDir;
				var xmlList = Directory.GetFiles(xmlDir, "*.xml");
				xmlFilesList.AddRange(xmlList);
			}

			foreach (var xmlFile in xmlFilesList)
			{
				var doc = XDocument.Load(xmlFile);
				var root = doc.Root;
				
				if (root.Name != "annotation") throw new Exception($"Pascal VOC XML root element should be 'annotation', rather than {root.Name}");

				// Extract image filename
				string fileName = root.Element("filename")?.Value;
				if (fileName == null) throw new Exception("Filename is not in the file");

				// Extract image size
				var sizeElement = root.Element("size");
				if (sizeElement == null) throw new Exception("Size is not in the file");

				var size = new Dictionary<string, int>
				{
					{ "width", int.Parse(sizeElement.Element("width")?.Value ?? "0") },
					{ "height", int.Parse(sizeElement.Element("height")?.Value ?? "0") }
				};

				if (!imageSet.Contains(fileName))
				{
					int currentImageId = AddImgItem(fileName, size);
					Console.WriteLine($"Add image with name: {fileName}\tand\tsize: {size}");
				}
				else
				{
					throw new Exception($"File name {fileName} is duplicated");
				}

				// Process each object in the image
				var objectInfo = root.Elements("object").ToList();
				if (objectInfo.Count == 0) continue;

				foreach (var obj in objectInfo)
				{
					string objectName = obj.Element("name")?.Value;
					if (objectName == null) throw new Exception("Object name is missing");

					int currentCategoryId;
					if (!categorySet.ContainsKey(objectName))
					{
						currentCategoryId = AddCatItem(objectName);
					}
					else
					{
						currentCategoryId = categorySet[objectName];
					}

					var bndboxElement = obj.Element("bndbox");
					if (bndboxElement == null) throw new Exception("Bounding box is missing");

					var bbox = new int[4]
					{
						int.Parse(bndboxElement.Element("xmin")?.Value ?? "0"),
						int.Parse(bndboxElement.Element("ymin")?.Value ?? "0"),
						int.Parse(bndboxElement.Element("xmax")?.Value ?? "0") - int.Parse(bndboxElement.Element("xmin")?.Value ?? "0"),
						int.Parse(bndboxElement.Element("ymax")?.Value ?? "0") - int.Parse(bndboxElement.Element("ymin")?.Value ?? "0")
					};

					Console.WriteLine($"Add annotation with object_name: {objectName}\timage_id: {imageId}\tcat_id: {currentCategoryId}\tbbox: {bbox}");
					AddAnnoItem(objectName, imageId, currentCategoryId, bbox);
				}
			}

			// Save COCO JSON file
			string jsonParentDir = Path.GetDirectoryName(jsonSavePath);
			if (!Directory.Exists(jsonParentDir)) Directory.CreateDirectory(jsonParentDir);
			File.WriteAllText(jsonSavePath, JsonConvert.SerializeObject(coco, Newtonsoft.Json.Formatting.Indented));
			Console.WriteLine($"Class nums: {((List<Dictionary<string, object>>)coco["categories"]).Count}");
			Console.WriteLine($"Image nums: {((List<Dictionary<string, object>>)coco["images"]).Count}");
			Console.WriteLine($"Bbox nums: {((List<Dictionary<string, object>>)coco["annotations"]).Count}");
		}
	}
}
