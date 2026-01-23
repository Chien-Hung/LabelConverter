using LabelConvertor.Draw;
using LabelConvertor.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelConvertor
{
	public enum ConvertMode
	{
		VocToCoco,
		YoloToCoco,
		VocToYolo,
		CocoToYolo,
		YoloToVoc,
		CocoToVoc
	}

	public partial class LabelConverterControl : UserControl
	{
		public string ImageTrain => txtImageTrain.Text;
		public string ImageVal => txtImageVal.Text;
		public string ImageTest => txtImageTest.Text;
		
		public string LabelVocTrain => txtVocLabelTrain.Text;
		public string LabelVocVal => txtVocLabelVal.Text;
		public string LabelVocTest => txtVocLabelTest.Text;

		public string LabelYoloTrain => txtYoloLabelTrain.Text;
		public string LabelYoloVal => txtYoloLabelVal.Text;
		public string LabelYoloTest => txtYoloLabelTest.Text;

		public string JsonFileTrain => txtJsonFileTrain.Text;
		public string JsonFileVal => txtJsonFileVal.Text;
		public string JsonFileTest => txtJsonFileTest.Text;
		
		public string[] Classes => GetUnionClasses ();

		public bool useTest => chkTest.Checked;
		public bool useVal => chkVal.Checked;

		public LabelConverterControl ()
		{
			InitializeComponent ();

			cmbMode.SelectedIndex = 0;
			cmbMode_SelectedIndexChanged (null, null);

			txtVocLabelTrain.Text = "example\\Voc\\Train";
			txtVocLabelVal.Text = "example\\Voc\\Val";
			txtVocLabelTest.Text = "example\\Voc\\Test";

			txtImageTrain.Text = "example\\images\\Train";
			txtImageVal.Text = "example\\images\\Val";
			txtImageTest.Text = "example\\images\\Test";

			txtYoloLabelTrain.Text = "example\\Yolo\\Train";
			txtYoloLabelVal.Text = "example\\Yolo\\Val";
			txtYoloLabelTest.Text = "example\\Yolo\\Test";
			
			txtJsonFileTrain.Text = "example\\Coco\\instances_train2017.json";
			txtJsonFileVal.Text = "example\\Coco\\instances_val2017.json";
			txtJsonFileTest.Text = "example\\Coco\\test.json";
		}

		private void cmbMode_SelectedIndexChanged (object sender, EventArgs e)
		{
			flowLayoutPanel1.Controls.Clear ();
			string[] strings = cmbMode.Text.Split(' ');

			for (int i = 0; i < strings.Length; i++)
			{
				if (strings [i] == "to")
				{
					continue;
				}
				else if (strings [i] == "VOC")
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

		private void btnConvert_Click (object sender, EventArgs e)
		{
			// CheckDstData ();
			try
			{
				ConvertService.Execute (cmbMode.Text, this);
				MessageBox.Show ($"Finish Conversion!");
			}
			catch (Exception ex)
			{
				MessageBox.Show ($"Convert error!\n{ex.ToString ()}");
			}
		}
		
		private ConvertMode GetSelectedMode()
		{
			switch (cmbMode.Text)
			{
				case "VOC to COCO": return ConvertMode.VocToCoco;
				case "YOLO to COCO": return ConvertMode.YoloToCoco;
				case "VOC to YOLO": return ConvertMode.VocToYolo;
				case "COCO to YOLO": return ConvertMode.CocoToYolo;
				case "YOLO to VOC": return ConvertMode.YoloToVoc;
				case "COCO to VOC": return ConvertMode.CocoToVoc;
				default:	
					throw new InvalidOperationException("Unknown mode");
			}
		}

		private void CheckDstData ()
		{
			switch (cmbMode.Text)
			{
				case "VOC to COCO":
				case "YOLO to COCO":
					DeleteFiles(
						JsonFileTrain,
						useVal ? JsonFileVal: null,
						useTest ? JsonFileTest : null
					);
					break;

				case "VOC to YOLO":
				case "COCO to YOLO":
					 DeleteDirectories(
						LabelYoloTrain,
						useVal ? LabelYoloVal : null,
						useTest ? LabelYoloTest : null
					);
					break;

				case "YOLO to VOC":
				case "COCO to VOC":
					DeleteDirectories(
						LabelVocTrain,
						useVal ? LabelVocVal : null,
						useTest ? LabelVocTest : null
					);
					break;
				default:
					break;
			}
		}

		private void DeleteFiles(params string[] files)
		{
			foreach (var file in files)
			{
				if (!string.IsNullOrEmpty(file))
				{
					ConfirmAndDeleteFile(file);
				}
			}
		}

		private void DeleteDirectories(params string[] directories)
		{
			foreach (var dir in directories)
			{
				if (!string.IsNullOrEmpty(dir))
				{
					ConfirmAndDeleteDirectory(dir);
				}
			}
		}

		private void ConfirmAndDeleteFile(string filePath)
		{
			if (!File.Exists(filePath))
				return;

			if (MessageBox.Show(
					$"{filePath} is existed! Do you want to delete this file?",
					"",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Information) == DialogResult.Yes)
			{
				File.Delete(filePath);
			}
		}

		private void ConfirmAndDeleteDirectory(string directoryPath)
		{
			if (!Directory.Exists(directoryPath))
				return;

			if (MessageBox.Show(
					$"{directoryPath} is existed! Do you want to delete this directory?",
					"",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Information) == DialogResult.Yes)
			{
				Directory.Delete(directoryPath, true); // true = recursive
			}
		}

		private void btnImageTrain_Click (object sender, EventArgs e)
		{
			txtImageTrain.Text = FileDialogService.SelectFolder () ?? txtImageTrain.Text;
		}

		private bool IsCocoInputMode()
		{
			return flowLayoutPanel1.Controls.IndexOf(pnlCoco) == 0;
		}

		private void btnImageVal_Click (object sender, EventArgs e)
		{
			txtImageVal.Text = FileDialogService.SelectFolder () ?? txtImageVal.Text;
		}

		private void btnImageTest_Click (object sender, EventArgs e)
		{
			txtImageTest.Text = FileDialogService.SelectFolder () ?? txtImageTest.Text;
		}

		private void btnJsonFileTrain_Click (object sender, EventArgs e)
		{
			txtJsonFileTrain.Text = IsCocoInputMode()
				? FileDialogService.OpenJsonFile() ?? txtJsonFileTrain.Text
				: FileDialogService.SaveJsonFile() ?? txtJsonFileTrain.Text;
		}

		private void btnJsonFileVal_Click (object sender, EventArgs e)
		{
			txtJsonFileVal.Text = IsCocoInputMode ()
				? FileDialogService.OpenJsonFile () ?? txtJsonFileVal.Text
				: FileDialogService.SaveJsonFile () ?? txtJsonFileVal.Text;
		}

		private void btnJsonFileTest_Click (object sender, EventArgs e)
		{
			txtJsonFileTest.Text = IsCocoInputMode ()
				? FileDialogService.OpenJsonFile () ?? txtJsonFileTest.Text
				: FileDialogService.SaveJsonFile () ?? txtJsonFileTest.Text;
		}

		private void btnVocLabelTrain_Click (object sender, EventArgs e)
		{
			txtVocLabelTrain.Text = FileDialogService.SelectFolder () ?? txtVocLabelTrain.Text;
		}

		private void btnVocLabelVal_Click (object sender, EventArgs e)
		{
			txtVocLabelVal.Text = FileDialogService.SelectFolder () ?? txtVocLabelVal.Text;
		}

		private void btnVocLabelTest_Click (object sender, EventArgs e)
		{
			txtVocLabelTest.Text = FileDialogService.SelectFolder () ?? txtVocLabelTest.Text;
		}

		private void btnYoloLabelTrain_Click (object sender, EventArgs e)
		{
			txtYoloLabelTrain.Text = FileDialogService.SelectFolder () ?? txtYoloLabelTrain.Text;
		}

		private void btnYoloLabelVal_Click (object sender, EventArgs e)
		{
			txtYoloLabelVal.Text = FileDialogService.SelectFolder () ?? txtYoloLabelVal.Text;
		}

		private void btnYoloLabelTest_Click (object sender, EventArgs e)
		{
			txtYoloLabelTest.Text = FileDialogService.SelectFolder () ?? txtYoloLabelTest.Text;
		}

		private void btnCheckClasses_Click (object sender, EventArgs e)
		{
			if (cmbMode.Text.StartsWith ("VOC"))
			{
				var vocDirTrain = txtVocLabelTrain.Text;
				var classesTrain = VocToYoloConverter.ExtractClasses (vocDirTrain);

				var vocDirVal = txtVocLabelVal.Text;
				var classesVal = VocToYoloConverter.ExtractClasses (vocDirVal);

				string[] classesTest = null;
				if (chkTest.Checked)
				{
					var vocDirTest = txtVocLabelTest.Text;
					classesTest = VocToYoloConverter.ExtractClasses (vocDirTest);
				}

				showClassesForm (classesTrain, classesVal, classesTest);
			}
			else if (cmbMode.Text.StartsWith ("YOLO"))
			{
				var yoloDirTrain = txtYoloLabelTrain.Text;
				var classesTrain = YoloToVOC.ExtractClasses (yoloDirTrain);

				var yoloDirVal = txtYoloLabelVal.Text;
				var classesVal = YoloToVOC.ExtractClasses (yoloDirVal);

				string[] classesTest = null;
				if (chkTest.Checked)
				{
					var yoloDirTest = txtYoloLabelTest.Text;
					classesTest = YoloToVOC.ExtractClasses (yoloDirTest);
				}

				showClassesForm (classesTrain, classesVal, classesTest);
			}
			else if (cmbMode.Text.StartsWith ("COCO"))
			{
				var jsonFileTrain = txtJsonFileTrain.Text;
				var classesTrain = CocoToVoc.ExtractClasses (jsonFileTrain);
				
				var jsonFileVal = txtJsonFileVal.Text;
				var classesVal = CocoToVoc.ExtractClasses (jsonFileVal);

				string[] classesTest = null;
				if (chkTest.Checked)
				{
					var jsonFileTest = txtJsonFileTest.Text;
					classesTest = CocoToVoc.ExtractClasses (jsonFileTest);
				}

				showClassesForm (classesTrain, classesVal, classesTest);
			}
		}

		private void showClassesForm0 (string[] classesTrain, string[] classesVal)
		{
			// MessageBox.Show ($"COCO標註檔案 '{jsonFile}' 中的類別有:\n{string.Join ("\n", classesVal)}");

			// add classesTrain to datagridview in column Train and classesVal to column Val
			var allClasses = classesTrain.Union (classesVal).Distinct().OrderBy(c => c).ToList();
			var form = new Form ();
			var dgv = new DataGridView
			{
				Dock = DockStyle.Fill,
				AllowUserToAddRows = false,
				RowHeadersVisible = false,
				DataSource = allClasses.Select((c, index) => new
				{
					ID = index + 1, // 編號列，從 1 開始
					ClassName = c,
					Train = classesTrain.Contains(c) ? "Yes" : "No",
					Val = classesVal.Contains(c) ? "Yes" : "No"
				}).ToList()
			};

			// 註冊 DataBindingComplete 事件
			dgv.DataBindingComplete += (sender, e) =>
			{
				// 設置編號列的標題
				dgv.Columns[0].HeaderText = "No.";
				dgv.Columns [0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; // 自動調整寬度
			};

			form.Controls.Add (dgv);
			form.StartPosition = FormStartPosition.CenterParent;
			form.Size = new Size (380, 600);
			form.Text = "標註檔案中的類別";
			form.ShowDialog ();

			//var form = new Form();
			//var dgv = new DataGridView
			//{
			//	Dock = DockStyle.Fill,
			//	ColumnCount = 4,
			//	RowHeadersVisible = false,
			//	AllowUserToAddRows = false,
			//	Columns = 
			//	{
			//		[0] = { Name ="ClassId", HeaderText = "", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
			//		[1] = { Name = "Train", HeaderText = "Train", Width = 100 },
			//		[2] = { Name = "Val", HeaderText = "Val", Width = 100 },
			//		[3] = { Name = "Test", HeaderText = "Test", Width = 100 }
			//	}
			//};

			//// 計算最大行數
			//int n = Math.Max(classesTrain.Length, classesVal.Length);
			//dgv.Rows.Clear();
			//dgv.Rows.Add(n);

			//// 填充數據
			//for (int i = 0; i < n; i++)
			//{
			//	dgv.Rows[i].Cells[0].Value = i + 1; // 設置 ClassId
			//	if (i < classesTrain.Length)
			//		dgv.Rows[i].Cells[1].Value = classesTrain[i]; // 設置 Train
			//	if (i < classesVal.Length)
			//		dgv.Rows[i].Cells[2].Value = classesVal[i]; // 設置 Val
			//}

			//form.Controls.Add(dgv);
			//form.StartPosition = FormStartPosition.CenterParent;
			//form.Size = new Size(380, 800);
			//form.Text = "標註檔案中的類別";
			//form.ShowDialog();


			//var allClasses = new HashSet<string>(classesTrain);

			//var form = new Form ();
			//var dgv = new DataGridView
			//{
			//	Dock = DockStyle.Fill,
			//	DataSource = classesTrain.Select(c => new { ClassName = c }).ToList()
			//};
		}

		private void showClassesForm (string[] classesTrain, string[] classesVal, string[] classesTest)
		{
			var allClasses = classesTrain.Union (classesVal).Distinct().ToList();
			if (classesTest != null)
			{
				allClasses = allClasses.Union (classesTest).Distinct ().ToList ();
			}

			var form = new Form ();
			form.Font = new Font ("微軟正黑體", 10);
			FlowLayoutPanel layoutPanel = new FlowLayoutPanel();
			layoutPanel.Dock = DockStyle.Fill;

			var dgv = new DataGridView
			{
				//Dock = DockStyle.Fill,
				Size = new Size (380, 850),
				AllowUserToAddRows = false,
				RowHeadersVisible = false,
				DataSource = allClasses.Select((c, index) => new
				{
					ID = index + 1, // 編號列，從 1 開始
					Name = c,
					Train = classesTrain.Contains(c) ? "" : "X",
					Val = classesVal.Contains(c) ? "" : "X",
					Test = classesTest != null
						? (classesTest.Contains(c) ? "" : "X")
						: ""
				}).ToList()
			};

			// 註冊 DataBindingComplete 事件
			dgv.DataBindingComplete += (sender, e) =>
			{
				// 設置編號列的標題
				dgv.Columns [0].HeaderText = "No.";
				dgv.Columns [0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; // 自動調整寬度
				dgv.Columns [1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				dgv.Columns [2].Width = 65;
				dgv.Columns [2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dgv.Columns [3].Width = 65;
				dgv.Columns [3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dgv.Columns [4].Width = 65;
				dgv.Columns [4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			};


			var dgv2 = new DataGridView
			{
				//Dock = DockStyle.Fill,
				Size = new Size (380, 850),
				ColumnCount = 4,
				RowHeadersVisible = false,
				AllowUserToAddRows = false,
				Columns =
				{
					[0] = { Name ="ClassId", HeaderText = "", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
					[1] = { Name = "Train", HeaderText = "Train", Width = 100 },
					[2] = { Name = "Val", HeaderText = "Val", Width = 100 },
					[3] = { Name = "Test", HeaderText = "Test", Width = 100 }
				}
			};

			// 計算最大行數
			int n = classesTest == null 
				? Math.Max(classesTrain.Length, classesVal.Length)
				: Math.Max(Math.Max(classesTrain.Length, classesVal.Length), classesTest.Length);
			dgv2.Rows.Clear ();
			dgv2.Rows.Add (n);

			// 填充數據
			for (int i = 0; i < n; i++)
			{
				dgv2.Rows [i].Cells [0].Value = i + 1; // 設置 ClassId
				if (i < classesTrain.Length)
					dgv2.Rows [i].Cells [1].Value = classesTrain [i]; // 設置 Train
				if (i < classesVal.Length)
					dgv2.Rows [i].Cells [2].Value = classesVal [i]; // 設置 Val
				if (classesTest != null && i < classesTest.Length)
					dgv2.Rows [i].Cells [3].Value = classesTest [i]; // 設置 Val
			}

			form.Controls.Add (layoutPanel);
			layoutPanel.Controls.Add (dgv2);
			layoutPanel.Controls.Add (dgv);
			form.StartPosition = FormStartPosition.CenterParent;
			form.Size = new Size (800, 900);
			form.Text = "annotation classes";
			form.ShowDialog ();
		}

		public string[] GetUnionClasses ()
		{
			string[] classesAll = null;

			if (cmbMode.Text.StartsWith ("VOC"))
			{
				var vocDirTrain = txtVocLabelTrain.Text;
				var classesTrain = VocToYoloConverter.ExtractClasses (vocDirTrain);

				var vocDirVal = txtVocLabelVal.Text;
				var classesVal = VocToYoloConverter.ExtractClasses (vocDirVal);
				
				classesAll = classesTrain.Union (classesVal).Distinct ().ToArray ();

				if (chkTest.Checked)
				{
					var vocDirTest = txtVocLabelTest.Text;
					string[] classesTest = VocToYoloConverter.ExtractClasses (vocDirTest);
					classesAll = classesAll.Union (classesTest).Distinct ().ToArray ();
				}
			}
			else if (cmbMode.Text.StartsWith ("YOLO"))
			{
				var yoloDirTrain = txtYoloLabelTrain.Text;
				var classesTrain = YoloToVOC.ExtractClasses (yoloDirTrain);

				var yoloDirVal = txtYoloLabelVal.Text;
				var classesVal = YoloToVOC.ExtractClasses (yoloDirVal);

				classesAll = classesTrain.Union (classesVal).Distinct ().ToArray ();

				if (chkTest.Checked)
				{
					var yoloDirTest = txtYoloLabelTest.Text;
					string[] classesTest = YoloToVOC.ExtractClasses (yoloDirTest);
					classesAll = classesAll.Union (classesTest).Distinct ().ToArray ();
				}
			}
			else if (cmbMode.Text.StartsWith ("COCO"))
			{
				var jsonFileTrain = txtJsonFileTrain.Text;
				var classesTrain = CocoToVoc.ExtractClasses (jsonFileTrain);
				
				var jsonFileVal = txtJsonFileVal.Text;
				var classesVal = CocoToVoc.ExtractClasses (jsonFileVal);

				classesAll = classesTrain.Union (classesVal).Distinct ().ToArray ();

				if (chkTest.Checked)
				{
					var jsonFileTest = txtJsonFileTest.Text;
					string[] classesTest = CocoToVoc.ExtractClasses (jsonFileTest);
					classesAll = classesAll.Union (classesTest).Distinct ().ToArray ();
				}
			}

			return classesAll; 
		}
	}
}
