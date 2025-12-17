using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelConvertor
{
	public class CocoToYolo
	{
		static int images_nums = 0;
		static int category_nums = 0;
		static int bbox_nums = 0;

		// 将类别名字和id建立索引
		static Dictionary<int, string> CatId2Name(JObject coco)
		{
			var categories = coco["categories"].ToObject<List<JObject>>();
			Dictionary<int, string> classes = new Dictionary<int, string>();

			foreach (var cat in categories)
			{
				classes[cat["id"].Value<int>()] = cat["name"].Value<string>();
			}

			return classes;
		}

		// convert [xmin, ymin, xmax, ymax] to [x_center, y_center, w, h] with normalization
		static string Xyxy2Xywhn(List<float> bbox, int width, int height)
		{
			float xn = bbox[0] / width;
			float yn = bbox[1] / height;
			float wn = bbox[2] / width;
			float hn = bbox[3] / height;
			return $"{xn:F5} {yn:F5} {wn:F5} {hn:F5}";
		}

		// 保存数据到txt文件
		static void SaveAnnoToTxt(JObject imageInfo, string savePath)
		{
			string filename = imageInfo["filename"].Value<string>();
			string txtName = Path.ChangeExtension(filename, "txt");

			string filePath = Path.Combine(savePath, txtName);

			using (StreamWriter writer = new StreamWriter(filePath))
			{
				var objects = imageInfo["objects"].ToObject<List<JObject>>();
				foreach (var obj in objects)
				{
					List<float> bbox = obj["bbox"].ToObject<List<float>>();
					int cat_id = obj ["category_id"].ToObject<int>();	
					writer.WriteLine($"{cat_id} {Xyxy2Xywhn(bbox, imageInfo["width"].Value<int>(), imageInfo["height"].Value<int>())}");
				}
			}
		}

		// 读取COCO格式的JSON文件并处理
		static void LoadCoco(string annoFile, string xmlSavePath)
		{
			if (Directory.Exists(xmlSavePath))
			{
				Directory.Delete(xmlSavePath, true);
			}
			Directory.CreateDirectory(xmlSavePath);

			JObject coco = JObject.Parse(File.ReadAllText(annoFile));
			var classes = CatId2Name(coco);
			var imgIds = coco["images"].ToObject<List<JObject>>().Select(x => x["id"].Value<int>()).ToList();

			// 保存classes.txt
			string classesFile = Path.Combine(xmlSavePath, "classes.txt");
			using (StreamWriter writer = new StreamWriter(classesFile))
			{
				foreach (var categoryId in classes.Keys)
				{
					writer.WriteLine(classes[categoryId]);
				}
			}

			// 遍历每一张图片
			foreach (var imgId in imgIds)
			{
				var img = coco["images"].FirstOrDefault(i => i["id"].Value<int>() == imgId);
				string filename = img["file_name"].Value<string>();
				int width = img["width"].Value<int>();
				int height = img["height"].Value<int>();

				var anns = coco["annotations"].Where(a => a["image_id"].Value<int>() == imgId).ToList();
				List<JObject> objects = new List<JObject>();

				foreach (var ann in anns)
				{
					int categoryId = ann["category_id"].Value<int>();
					List<float> bbox = ann["bbox"].ToObject<List<float>>();
					float xc = bbox[0] + bbox[2] / 2.0f;
					float yc = bbox[1] + bbox[3] / 2.0f;
					float w = bbox[2];
					float h = bbox[3];

					objects.Add(new JObject
					{
						{ "category_id", categoryId },
						{ "bbox", new JArray(xc, yc, w, h) }
					});
				}

				JObject imageInfo = new JObject
				{
					{ "filename", filename },
					{ "width", width },
					{ "height", height },
					{ "objects", JArray.FromObject(objects) }
				};

				SaveAnnoToTxt(imageInfo, xmlSavePath);
			}
		}

		public static void ParseJsonFile(string jsonPath, string txtSavePath)
		{
			if (!File.Exists(jsonPath))
			{
				throw new ArgumentException($"JSON path:{jsonPath} does not exist");
			}

			if (Directory.Exists(txtSavePath))
			{
				Directory.Delete(txtSavePath, true);
			}
			Directory.CreateDirectory(txtSavePath);

			if (!jsonPath.EndsWith(".json"))
			{
				throw new ArgumentException($"The file {jsonPath} is not a JSON file!");
			}

			LoadCoco(jsonPath, txtSavePath);

			//// 输出一些统计信息
			//Console.WriteLine($"Images numbers: {images_nums}");
			//Console.WriteLine($"Category numbers: {category_nums}");
			//Console.WriteLine($"Bounding box numbers: {bbox_nums}");
		}
	}
}
