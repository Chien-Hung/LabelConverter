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
	public class VocDrawer : ILabelDrawer
	{
		private readonly string _vocDir;

		public VocDrawer(string vocDir)
		{
			_vocDir = vocDir;
		}

		public void Draw(Bitmap bmp, string imageFile)
		{
			string xml = Path.Combine(_vocDir, Path.ChangeExtension(imageFile, ".xml"));
			if (!File.Exists(xml)) return;

			var doc = XDocument.Load(xml);
			var g = Graphics.FromImage(bmp);
			var pen = new Pen(Color.Red, 3);
			var brush = new SolidBrush(Color.LightGreen);
			var font = new Font("Arial", 20);

			foreach (var obj in doc.Descendants("object"))
			{
				var box = obj.Element("bndbox");
				int xmin = int.Parse(box.Element("xmin").Value);
				int ymin = int.Parse(box.Element("ymin").Value);
				int xmax = int.Parse(box.Element("xmax").Value);
				int ymax = int.Parse(box.Element("ymax").Value);

				g.DrawRectangle(pen, xmin, ymin, xmax - xmin, ymax - ymin);
				int offset = (ymin > 30) ? 20 : 0;
				g.DrawString(obj.Element("name").Value.ToString(), font, brush, xmin, ymin - offset);
			}

			g.Dispose ();
			pen.Dispose ();
			brush.Dispose ();
			font.Dispose ();
		}
	}
}
