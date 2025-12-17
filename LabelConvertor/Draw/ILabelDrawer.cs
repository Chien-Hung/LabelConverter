using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelConvertor.Draw
{
	public interface ILabelDrawer
	{
		void Draw(Bitmap bmp, string imageFileName);
	}
}
