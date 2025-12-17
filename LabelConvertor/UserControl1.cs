using LabelConvertor.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelConvertor
{
	public partial class UserControl1 : UserControl
	{
		public UserControl1 ()
		{
			InitializeComponent ();
		}

		private void button4_Click (object sender, EventArgs e)
		{
			textBox1.Text = FileDialogService.SelectFolder () ?? textBox1.Text;
		}
	}
}
