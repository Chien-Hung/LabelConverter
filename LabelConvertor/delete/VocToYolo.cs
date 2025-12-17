using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LabelConvertor
{
	public class VocToYoloConverter2
	{
		private string m_fullDirPath;
		private string m_outputPath;
		private List<string> m_GeneratedFiles;

		public VocToYoloConverter2(string fullDirPath, string outputPath) 
		{
			m_fullDirPath = fullDirPath;
			m_outputPath = outputPath;
			m_GeneratedFiles = new List<string>();
		}

		public void StartConvertion ()
		{
			if (!Directory.Exists(m_outputPath))
			{
				Directory.CreateDirectory(m_outputPath);
			}

			var imagePaths = GetImagesInDir(m_fullDirPath);

			foreach (var imagePath in imagePaths)
			{
				Console.WriteLine(imagePath);
				ConvertAnnotation(m_fullDirPath, m_outputPath, imagePath);
			}

			// Write classes to classes.txt
			string classesFilePath = Path.Combine(m_outputPath, "classes.txt");
			File.WriteAllLines(classesFilePath, classes);
			m_GeneratedFiles.Add(classesFilePath);
		}

		static List<string> classes = new List<string>();

		static List<string> GetImagesInDir(string dirPath)
		{
			var imageList = new List<string>();
			imageList.AddRange(Directory.GetFiles(dirPath, "*.xml"));
			return imageList;
		}

		static (double x, double y, double w, double h) Convert((int width, int height) size, (float xmin, float xmax, float ymin, float ymax) box)
		{
			double dw = 1.0 / size.width;
			double dh = 1.0 / size.height;
			double x = (box.xmin + box.xmax) / 2.0 - 1;
			double y = (box.ymin + box.ymax) / 2.0 - 1;
			double w = box.xmax - box.xmin;
			double h = box.ymax - box.ymin;
			x = Math.Round(x * dw, 6);
			w = Math.Round(w * dw, 6);
			y = Math.Round(y * dh, 6);
			h = Math.Round(h * dh, 6);
			return (x, y, w, h);
		}

		private void ConvertAnnotation(string dirPath, string outputPath, string imagePath)
		{
			string baseName = Path.GetFileName(imagePath);
			string baseNameNoExt = Path.GetFileNameWithoutExtension(baseName);
			
			string xmlFilePath = Path.Combine(dirPath, baseNameNoExt + ".xml");

			if (!File.Exists (xmlFilePath))
			{
				return;
			}

			var outFilePath = Path.Combine(outputPath, baseNameNoExt + ".txt");
			m_GeneratedFiles.Add(outFilePath);
			using (var outFile = new StreamWriter(outFilePath))
			{
				XDocument doc = XDocument.Load(xmlFilePath);
				var sizeElement = doc.Descendants("size").FirstOrDefault();
				int width = int.Parse(sizeElement.Element("width").Value);
				int height = int.Parse(sizeElement.Element("height").Value);

				var objects = doc.Descendants("object");
				foreach (var obj in objects)
				{
					string cls = obj.Element("name").Value;
					if (!classes.Contains(cls))
					{
						classes.Add(cls);
						Console.WriteLine("new class : " + cls);
					}

					int clsId = classes.IndexOf(cls);
					var bndBox = obj.Element("bndbox");
					var xmin = float.Parse(bndBox.Element("xmin").Value);
					var xmax = float.Parse(bndBox.Element("xmax").Value);
					var ymin = float.Parse(bndBox.Element("ymin").Value);
					var ymax = float.Parse(bndBox.Element("ymax").Value);

					var box = Convert((width, height), (xmin, xmax, ymin, ymax));
					outFile.WriteLine($"{clsId} {box.x} {box.y} {box.w} {box.h}");
				}
			}
		}
	}
}
