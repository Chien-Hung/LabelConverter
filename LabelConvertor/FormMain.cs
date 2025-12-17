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


// 可以參考 https://zhuanlan.zhihu.com/p/461488682
// https://github.com/yukkyo/voc2coco



namespace LabelConvertor
{
	public partial class FormMain : Form
	{	
		public string ImagePath => txtImage.Text;
		public string VocPath => txtVoc.Text;
		public string YoloPath => txtYoloLabel.Text;
		public string CocoPath => txtCoCo.Text;

		// 常見影像副檔名
		string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".bmp" };

		public FormMain ()
		{
			InitializeComponent ();

			cmbMode.SelectedIndex = 0;
			txtVoc.Text = "example\\Voc";

			txtImage.Text = "example\\images";
			txtYoloLabel.Text = "example\\Yolo";
			
			txtCoCo.Text = "example\\Coco\\annotations.json";
			AddImagesToListBox (ImagePath);
		}

		private void btnConvert_Click (object sender, EventArgs e)
		{
			ConvertService.Execute(cmbMode.Text, this);
		}
		
		private void btnImage_Click (object sender, EventArgs e)
		{
			var path = FileDialogService.SelectFolder();
			if (path == null) return;

			txtImage.Text = path;
			AddImagesToListBox(path);
		}

		private void AddImagesToListBox(string imageDir)
		{
			var imageFiles = Directory
				.EnumerateFiles(imageDir, "*.*", SearchOption.TopDirectoryOnly)
				.Where(f => imageExtensions.Contains(Path.GetExtension(f).ToLower()))
				.Select(Path.GetFileName)
				.OrderBy(f => f)
				.ToArray();

			listBox1.BeginUpdate();
			listBox1.Items.Clear();

			foreach (var file in imageFiles)
			{
				listBox1.Items.Add(file);
			}

			listBox1.EndUpdate();
		}

		private void btnYoloLabel_Click (object sender, EventArgs e)
		{
			 txtYoloLabel.Text = FileDialogService.SelectFolder() ?? txtYoloLabel.Text;
		}

		private void cmbMode_SelectedIndexChanged (object sender, EventArgs e)
		{
			flowLayoutPanel1.Controls.Clear ();
			string[] strings = cmbMode.Text.Split('2');

			for (int i = 0; i < strings.Length; i++)
			{
				if (strings [i] == "VOC")
				{
					flowLayoutPanel1.Controls.Add (pnlVoc);
				}
				else if (strings [i] == "YOLO")
				{
					flowLayoutPanel1.Controls.Add (pnlYolo);
				}
				else if (strings [i] == "COCO")
				{
					flowLayoutPanel1.Controls.Add (pnlCoco);
				}
			}
		}

		private void btnCocoFile_Click (object sender, EventArgs e)
		{
			txtCoCo.Text = IsCocoInputMode()
				? FileDialogService.OpenJsonFile() ?? txtCoCo.Text
				: FileDialogService.SaveJsonFile() ?? txtCoCo.Text;
		}

		private bool IsCocoInputMode()
		{
			return flowLayoutPanel1.Controls.IndexOf(pnlCoco) == 0;
		}

		private void listBox1_SelectedIndexChanged (object sender, EventArgs e)
		{
			string file = listBox1.Text;
			var bmp = new Bitmap(Path.Combine(txtImage.Text, file));
			bmp.SetResolution (75, 75);

			ILabelDrawer drawer = null;
			switch (cmbLabelFormat.Text)
			{
				case "VOC":
					drawer = new VocDrawer(txtVoc.Text);
					break;
				case "YOLO":
					drawer = new YoloDrawer(txtYoloLabel.Text);
					break;
				case "COCO":
					drawer = new CocoDrawer(txtCoCo.Text);
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

		private void cmbLabelFormat_SelectedIndexChanged (object sender, EventArgs e)
		{
			tssLabel1.Text = (listBox1.SelectedIndex + 1) + " / " + listBox1.Items.Count.ToString ();
		}

		private void btnVocFolder_Click (object sender, EventArgs e)
		{
			txtVoc.Text = FileDialogService.SelectFolder () ?? txtVoc.Text;
		}

		private void pictureBox1_DoubleClick (object sender, EventArgs e)
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
	}
}
