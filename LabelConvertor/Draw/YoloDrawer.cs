using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LabelConvertor.Draw
{
	public class YoloDrawer : ILabelDrawer
	{
		private readonly string _yoloDir;

		public YoloDrawer(string yoloDir)
		{
			_yoloDir = yoloDir;
		}

		public void Draw(Bitmap bmp, string imageFile)
		{
			string yoloFilePath = Path.Combine(_yoloDir, Path.ChangeExtension(imageFile, ".txt"));
			string yoloClassPath = Path.Combine(_yoloDir, "classes.txt");

			if (!File.Exists (yoloFilePath) || !File.Exists (yoloClassPath)) return;

			Dictionary<int, string> classDict = YoloToVOC.ReadYoLoClass (yoloClassPath);

			// 讀取YOLO標註檔案
			var yoloLines = File.ReadAllLines(yoloFilePath);
			int imageWidth = bmp.Width;
			int imageHeight = bmp.Height;
				
			var g = Graphics.FromImage(bmp);
			var pen = new Pen(Color.Red, 3);
			var brush = new SolidBrush(Color.Cyan);
			var font = new Font("Arial", 20);				

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

				// 繪製邊界框
				g.DrawRectangle (pen, xmin, ymin, xmax - xmin, ymax - ymin);
				// 繪製類別標籤
				int offset = (ymin > 30) ? 20 : 0;
				g.DrawString (className, font, brush, new PointF (xmin, ymin - offset));
			}
			
			g.Dispose ();
			pen.Dispose ();
			brush.Dispose ();
			font.Dispose ();
		}
	}
}
