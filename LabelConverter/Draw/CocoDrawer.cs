using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static LabelConverter.CocoToVoc;

namespace LabelConverter.Draw
{
	public class CocoDrawer : ILabelDrawer
	{
		private readonly string _jsonPath;

		public CocoDrawer(string jsonPath)
		{
			_jsonPath = jsonPath;
		}

		public void Draw(Bitmap bmp, string imageFile)
		{
			if (_jsonPath == "") return;

			string jsonContent = File.ReadAllText(_jsonPath);
			CocoAnnotation coco = JsonConvert.DeserializeObject<CocoAnnotation>(jsonContent);

			var classes = coco.categories.ToDictionary(c => c.id, c => c.name);

			// 依照 image 分組 annotation
			var annByImage = coco.annotations.GroupBy(a => a.image_id)
												.ToDictionary(group => group.Key, group => group.ToList());

			foreach (var img in coco.images)
			{
				if (Path.GetFileNameWithoutExtension(img.file_name) != Path.GetFileNameWithoutExtension(imageFile)) continue;

				if (annByImage.ContainsKey (img.id))
				{
					var g = Graphics.FromImage(bmp);
					var pen = new Pen(Color.Red, 3);
					var brush = new SolidBrush(Color.Yellow);
					var font = new Font("Arial", 20);
							
					foreach (var ann in annByImage [img.id])
					{
						string className = classes[ann.category_id];
						var bbox = ann.bbox.Select(v => (int)v).ToList();

						int xmin = bbox[0];
						int ymin = bbox[1];
						int xmax = bbox[0] + bbox[2];
						int ymax = bbox[1] + bbox[3];

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
	}
}
