using LabelConvertor.Draw;
using LabelConvertor.Services;
using Newtonsoft.Json;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static LabelConvertor.CocoToVoc;
using LabelConvertor.UI;
using System.Xml.Serialization;


namespace LabelConvertor
{
	public partial class FormMain : Form
	{	
		private LabelConverterControl labelConverterControl;
		private ImageBoxControl imageBoxControl;

		public FormMain ()
		{
			InitializeComponent ();
			
			labelConverterControl = new LabelConverterControl ();
			labelConverterControl.Dock = DockStyle.Fill;
			
			imageBoxControl = new ImageBoxControl (labelConverterControl);
			imageBoxControl.Dock = DockStyle.Fill;

			tabSetting.Controls.Add (labelConverterControl);
			tabVisualization.Controls.Add (imageBoxControl);
		}
	}
}
