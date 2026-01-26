using LabelConverter.Draw;
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

namespace LabelConverter.UI
{
	public partial class ImageBoxControl : UserControl
	{
		private LabelConverterControl m_UserControl1;
		private string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".bmp" };

		public ImageBoxControl (LabelConverterControl userControl1)
		{
			InitializeComponent ();

			m_UserControl1 = userControl1;
		}

		private void cmbLabelFormat_SelectedIndexChanged (object sender, EventArgs e)
		{
			tssLabel1.Text = (listBox1.SelectedIndex + 1) + " / " + listBox1.Items.Count.ToString ();
		}

		private void cmbData_SelectedIndexChanged (object sender, EventArgs e)
		{
			switch (cmbData.Text)
			{
				case "Train":
					AddImagesToListBox (m_UserControl1.ImageTrain);
					break;
				case "Val":
					AddImagesToListBox (m_UserControl1.ImageVal);
					break;
				case "Test":
					AddImagesToListBox (m_UserControl1.ImageTest);
					break;
				default:
					break;
			}
		}

		private void listBox1_SelectedIndexChanged (object sender, EventArgs e)
		{
			string file = listBox1.Text;
			string filePath = Path.Combine(listBox1.Tag.ToString(), file);
			if (!File.Exists (filePath)) return;
			
			var bmp = new Bitmap(filePath);
			bmp.SetResolution (75, 75);

			ILabelDrawer drawer = null;
			switch (cmbLabelFormat.Text)
			{
				case "VOC":
					if (cmbData.Text == "Train")
						drawer = new VocDrawer (m_UserControl1.LabelVocTrain);
					else if (cmbData.Text == "Val")
						drawer = new VocDrawer (m_UserControl1.LabelVocVal);
					else if (cmbData.Text == "Test")
							drawer = new VocDrawer(m_UserControl1.LabelVocTest);
					break;
				case "YOLO":
					if (cmbData.Text == "Train")
						drawer = new YoloDrawer (m_UserControl1.LabelYoloTrain);
					else if (cmbData.Text == "Val")
						drawer = new YoloDrawer (m_UserControl1.LabelYoloVal);
					else if (cmbData.Text == "Test")
						drawer = new YoloDrawer(m_UserControl1.LabelYoloTest);
					break;
				case "COCO":
					if (cmbData.Text == "Train")
						drawer = new CocoDrawer (m_UserControl1.JsonFileTrain);
					else if (cmbData.Text == "Val")
						drawer = new CocoDrawer (m_UserControl1.JsonFileVal);
					else if (cmbData.Text == "Test")
						drawer = new CocoDrawer(m_UserControl1.JsonFileTest);
					break;
				default:
					break;
			}

			drawer?.Draw(bmp, file);

			pictureBox1.Image?.Dispose();
			pictureBox1.Image = bmp;
			tssLabel1.Text = (listBox1.SelectedIndex + 1) + " / " + listBox1.Items.Count.ToString () + 
				$"   [ {bmp.Width} x {bmp.Height} ]";
		}

		private void pictureBox1_MouseDoubleClick (object sender, MouseEventArgs e)
		{
			if (pictureBox1.SizeMode == PictureBoxSizeMode.Zoom)
			{
				panel2.AutoScroll = true;	
				pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
				pictureBox1.Dock = DockStyle.None;
			}
			else
			{
				panel2.AutoScroll = false;	
				pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
				pictureBox1.Dock = DockStyle.Fill;
			}
		}

		private void AddImagesToListBox(string imageDir)
		{
			if (!Directory.Exists (imageDir)) return;

			listBox1.Tag = imageDir;

			var imageFiles = Directory
			.EnumerateFiles(imageDir, "*.*", SearchOption.TopDirectoryOnly)
			.Where(f => imageExtensions.Contains(Path.GetExtension(f).ToLower()))
			.Select(Path.GetFileName)
			.OrderBy(f => f)
			.ToArray();

			listBox1.BeginUpdate ();
			listBox1.Items.Clear ();

			foreach (var file in imageFiles)
			{
				listBox1.Items.Add (file);
			}

			listBox1.EndUpdate ();
		}
	}
}
