using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LabelConvertor
{
	public class YoloToVOC
	{
		string m_imageFolderPath = "path/to/image.jpg";   // 圖片的路徑
		string m_yoloFolderPath = "path/to/yolo.txt";    // YOLO標註檔案
		string m_classFilePath = "path/to/yolo.txt";    // YOLO標註檔案
		string m_outputFolderPath = "path/to/output.xml"; // 輸出的XML檔案

		public YoloToVOC (string imageFolderPath, string yoloFolderPath, string outputFolderPath)
		{
			m_imageFolderPath = imageFolderPath;
			m_yoloFolderPath = yoloFolderPath;
			m_outputFolderPath = outputFolderPath;
			m_classFilePath = Path.Combine(m_yoloFolderPath, "classes.txt");
		}

		public static Dictionary<int, string> ReadYoLoClass (string classFilePath)
		{
			Dictionary<int, string> classDict = new Dictionary<int, string>();

			using (StreamReader sr = new StreamReader (classFilePath))
			{
				while (!sr.EndOfStream)
				{
					string line = sr.ReadLine ();
					int classId = classDict.Count;
					classDict.Add (classId, line);
				}
			}

			return classDict;
		}

		public void StartConvertion ()
		{
			Dictionary<int, string> classDict = ReadYoLoClass (m_classFilePath);
			List<string> imageFilePaths = GetImages ();

			foreach (string imageFilePath in imageFilePaths)
			{
				string yoloName = Path.GetFileNameWithoutExtension (imageFilePath) + ".txt";
				string yoloFilePath = Path.Combine (m_yoloFolderPath, yoloName);
				string outputXmlPath = Path.Combine (m_outputFolderPath, Path.GetFileNameWithoutExtension (imageFilePath) + ".xml");
				if (!File.Exists (yoloFilePath))
					continue;
				
				ConvertYoloToVOC (imageFilePath, yoloFilePath, outputXmlPath, classDict);
				Console.WriteLine (yoloFilePath);
			}
		}

		private List<string> GetImages()
		{
			List<string> images = new List<string>();
			string[] imageFiles = Directory.GetFiles(m_imageFolderPath, "*.*")
				.Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
							   file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
							   file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
							   file.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
				.ToArray();
			images.AddRange (imageFiles);
			return images;
		}

		// 將YOLO格式轉換為VOC XML格式
		public static void ConvertYoloToVOC(string imageFilePath, string yoloFilePath, string outputXmlPath, Dictionary<int, string> classDict)
		{
			// 讀取YOLO標註檔案
			var yoloLines = File.ReadAllLines(yoloFilePath);
			
			Bitmap image = new Bitmap(imageFilePath);
			int imageWidth = image.Width;
			int imageHeight = image.Height;
			int depth = Image.GetPixelFormatSize(image.PixelFormat) / 8;
			image.Dispose ();

			// 建立VOC XML根元素
			var xml = new XElement("annotation",
				new XElement("folder", Path.GetDirectoryName(imageFilePath)),
				new XElement("filename", Path.GetFileName(imageFilePath)),
				new XElement("path", imageFilePath),
				new XElement("source",
					new XElement("database", "Unknown")),
				new XElement("size",
					new XElement("width", imageWidth),
					new XElement("height", imageHeight),
					new XElement("depth", depth)),
				new XElement("segmented", "0")
			);

			// 解析每一行YOLO標註
			foreach (var line in yoloLines)
			{
				var parts = line.Split(' ');
				int classId = int.Parse(parts[0]);
				double xCenter = double.Parse(parts[1]);
				double yCenter = double.Parse(parts[2]);
				double width = double.Parse(parts[3]);
				double height = double.Parse(parts[4]);

				// 計算邊界框的實際座標 (像素)
				int xmin = (int)((xCenter - width / 2) * imageWidth);
				int ymin = (int)((yCenter - height / 2) * imageHeight);
				int xmax = (int)((xCenter + width / 2) * imageWidth);
				int ymax = (int)((yCenter + height / 2) * imageHeight);

				string className = classDict[classId];

				// 創建物件標註
				var objectElement = new XElement("object",
					new XElement("name", className),
					new XElement("pose", "Unspecified"),
					new XElement("truncated", "0"),
					new XElement("difficult", "0"),
					new XElement("bndbox",
						new XElement("xmin", xmin),
						new XElement("ymin", ymin),
						new XElement("xmax", xmax),
						new XElement("ymax", ymax)
					)
				);

				// 將物件標註添加到XML中
				xml.Add(objectElement);
			}

			// 儲存轉換後的XML檔案，並設置縮排為Tab
			var settings = new XmlWriterSettings
			{
				Indent = true,            // 啟用縮排
				IndentChars = "\t",       // 使用 Tab 字符作為縮排
				NewLineOnAttributes = true
			};

			//// 儲存轉換後的XML檔案
			using (XmlWriter writer = XmlWriter.Create(outputXmlPath, settings))
			{
				xml.Save(writer);
			}

			//var doc = new XDocument(xml);
			//doc.Save(outputXmlPath);

			Console.WriteLine("YOLO轉換為VOC XML完成!");
		}

		public static string[] ExtractClasses (string yoloDir)
		{
			var classesFile = Path.Combine(yoloDir, "classes.txt");
			Dictionary<int, string> classDict = ReadYoLoClass (classesFile);
			return classDict.Values.ToArray ();
		}
	}
}
