namespace LabelConverter
{
	partial class LabelConverterControl
	{
		/// <summary> 
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region 元件設計工具產生的程式碼

		/// <summary> 
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent ()
		{
			this.cmbMode = new System.Windows.Forms.ComboBox();
			this.btnConvert = new System.Windows.Forms.Button();
			this.chkTest = new System.Windows.Forms.CheckBox();
			this.btnImageTest = new System.Windows.Forms.Button();
			this.txtImageTest = new System.Windows.Forms.TextBox();
			this.chkVal = new System.Windows.Forms.CheckBox();
			this.btnImageVal = new System.Windows.Forms.Button();
			this.txtImageVal = new System.Windows.Forms.TextBox();
			this.chkTrain = new System.Windows.Forms.CheckBox();
			this.btnImageTrain = new System.Windows.Forms.Button();
			this.txtImageTrain = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.pnlCoco = new System.Windows.Forms.Panel();
			this.lblCocoTest = new System.Windows.Forms.Label();
			this.btnJsonFileTest = new System.Windows.Forms.Button();
			this.txtJsonFileTest = new System.Windows.Forms.TextBox();
			this.lblCocoVal = new System.Windows.Forms.Label();
			this.btnJsonFileVal = new System.Windows.Forms.Button();
			this.txtJsonFileVal = new System.Windows.Forms.TextBox();
			this.lblCocoTrain = new System.Windows.Forms.Label();
			this.btnJsonFileTrain = new System.Windows.Forms.Button();
			this.txtJsonFileTrain = new System.Windows.Forms.TextBox();
			this.lblCoco = new System.Windows.Forms.Label();
			this.pnlVoc = new System.Windows.Forms.Panel();
			this.btnVocLabelTest = new System.Windows.Forms.Button();
			this.txtVocLabelTest = new System.Windows.Forms.TextBox();
			this.btnVocLabelVal = new System.Windows.Forms.Button();
			this.txtVocLabelVal = new System.Windows.Forms.TextBox();
			this.lblVocTest = new System.Windows.Forms.Label();
			this.lblVocVal = new System.Windows.Forms.Label();
			this.lblVocTrain = new System.Windows.Forms.Label();
			this.btnVocLabelTrain = new System.Windows.Forms.Button();
			this.txtVocLabelTrain = new System.Windows.Forms.TextBox();
			this.lblVoc = new System.Windows.Forms.Label();
			this.pnlYolo = new System.Windows.Forms.Panel();
			this.btnYoloLabelTest = new System.Windows.Forms.Button();
			this.txtYoloLabelTest = new System.Windows.Forms.TextBox();
			this.btnYoloLabelVal = new System.Windows.Forms.Button();
			this.txtYoloLabelVal = new System.Windows.Forms.TextBox();
			this.lblYoloTest = new System.Windows.Forms.Label();
			this.btnYoloLabelTrain = new System.Windows.Forms.Button();
			this.lblYoloVal = new System.Windows.Forms.Label();
			this.txtYoloLabelTrain = new System.Windows.Forms.TextBox();
			this.lblYoloTrain = new System.Windows.Forms.Label();
			this.lblYolo = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pnlImage = new System.Windows.Forms.Panel();
			this.btnCheckClasses = new System.Windows.Forms.Button();
			this.flowLayoutPanel1.SuspendLayout();
			this.pnlCoco.SuspendLayout();
			this.pnlVoc.SuspendLayout();
			this.pnlYolo.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnlImage.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbMode
			// 
			this.cmbMode.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.cmbMode.FormattingEnabled = true;
			this.cmbMode.Items.AddRange(new object[] {
            "VOC to COCO",
            "VOC to YOLO",
            "YOLO to VOC",
            "YOLO to COCO",
            "COCO to VOC",
            "COCO to YOLO"});
			this.cmbMode.Location = new System.Drawing.Point(9, 12);
			this.cmbMode.Name = "cmbMode";
			this.cmbMode.Size = new System.Drawing.Size(156, 28);
			this.cmbMode.TabIndex = 5;
			this.cmbMode.SelectedIndexChanged += new System.EventHandler(this.cmbMode_SelectedIndexChanged);
			// 
			// btnConvert
			// 
			this.btnConvert.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnConvert.Location = new System.Drawing.Point(171, 10);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(100, 32);
			this.btnConvert.TabIndex = 6;
			this.btnConvert.Text = "Convert";
			this.btnConvert.UseVisualStyleBackColor = true;
			this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
			// 
			// chkTest
			// 
			this.chkTest.AutoSize = true;
			this.chkTest.Location = new System.Drawing.Point(9, 134);
			this.chkTest.Name = "chkTest";
			this.chkTest.Size = new System.Drawing.Size(59, 24);
			this.chkTest.TabIndex = 26;
			this.chkTest.Text = "Test";
			this.chkTest.UseVisualStyleBackColor = true;
			// 
			// btnImageTest
			// 
			this.btnImageTest.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnImageTest.Location = new System.Drawing.Point(75, 129);
			this.btnImageTest.Name = "btnImageTest";
			this.btnImageTest.Size = new System.Drawing.Size(133, 32);
			this.btnImageTest.TabIndex = 24;
			this.btnImageTest.Text = "Image Folder";
			this.btnImageTest.UseVisualStyleBackColor = true;
			this.btnImageTest.Click += new System.EventHandler(this.btnImageTest_Click);
			// 
			// txtImageTest
			// 
			this.txtImageTest.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.txtImageTest.Location = new System.Drawing.Point(220, 131);
			this.txtImageTest.Name = "txtImageTest";
			this.txtImageTest.Size = new System.Drawing.Size(1079, 29);
			this.txtImageTest.TabIndex = 25;
			// 
			// chkVal
			// 
			this.chkVal.AutoSize = true;
			this.chkVal.Checked = true;
			this.chkVal.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkVal.Location = new System.Drawing.Point(9, 96);
			this.chkVal.Name = "chkVal";
			this.chkVal.Size = new System.Drawing.Size(52, 24);
			this.chkVal.TabIndex = 23;
			this.chkVal.Text = "Val";
			this.chkVal.UseVisualStyleBackColor = true;
			// 
			// btnImageVal
			// 
			this.btnImageVal.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnImageVal.Location = new System.Drawing.Point(75, 91);
			this.btnImageVal.Name = "btnImageVal";
			this.btnImageVal.Size = new System.Drawing.Size(133, 32);
			this.btnImageVal.TabIndex = 21;
			this.btnImageVal.Text = "Image Folder";
			this.btnImageVal.UseVisualStyleBackColor = true;
			this.btnImageVal.Click += new System.EventHandler(this.btnImageVal_Click);
			// 
			// txtImageVal
			// 
			this.txtImageVal.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.txtImageVal.Location = new System.Drawing.Point(220, 93);
			this.txtImageVal.Name = "txtImageVal";
			this.txtImageVal.Size = new System.Drawing.Size(1079, 29);
			this.txtImageVal.TabIndex = 22;
			// 
			// chkTrain
			// 
			this.chkTrain.AutoSize = true;
			this.chkTrain.Checked = true;
			this.chkTrain.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkTrain.Enabled = false;
			this.chkTrain.Location = new System.Drawing.Point(9, 58);
			this.chkTrain.Name = "chkTrain";
			this.chkTrain.Size = new System.Drawing.Size(66, 24);
			this.chkTrain.TabIndex = 20;
			this.chkTrain.Text = "Train";
			this.chkTrain.UseVisualStyleBackColor = true;
			// 
			// btnImageTrain
			// 
			this.btnImageTrain.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnImageTrain.Location = new System.Drawing.Point(75, 53);
			this.btnImageTrain.Name = "btnImageTrain";
			this.btnImageTrain.Size = new System.Drawing.Size(133, 32);
			this.btnImageTrain.TabIndex = 18;
			this.btnImageTrain.Text = "Image Folder";
			this.btnImageTrain.UseVisualStyleBackColor = true;
			this.btnImageTrain.Click += new System.EventHandler(this.btnImageTrain_Click);
			// 
			// txtImageTrain
			// 
			this.txtImageTrain.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.txtImageTrain.Location = new System.Drawing.Point(220, 55);
			this.txtImageTrain.Name = "txtImageTrain";
			this.txtImageTrain.Size = new System.Drawing.Size(1079, 29);
			this.txtImageTrain.TabIndex = 19;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.pnlCoco);
			this.flowLayoutPanel1.Controls.Add(this.pnlVoc);
			this.flowLayoutPanel1.Controls.Add(this.pnlYolo);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 183);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(1312, 559);
			this.flowLayoutPanel1.TabIndex = 17;
			// 
			// pnlCoco
			// 
			this.pnlCoco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlCoco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlCoco.Controls.Add(this.lblCocoTest);
			this.pnlCoco.Controls.Add(this.btnJsonFileTest);
			this.pnlCoco.Controls.Add(this.txtJsonFileTest);
			this.pnlCoco.Controls.Add(this.lblCocoVal);
			this.pnlCoco.Controls.Add(this.btnJsonFileVal);
			this.pnlCoco.Controls.Add(this.txtJsonFileVal);
			this.pnlCoco.Controls.Add(this.lblCocoTrain);
			this.pnlCoco.Controls.Add(this.btnJsonFileTrain);
			this.pnlCoco.Controls.Add(this.txtJsonFileTrain);
			this.pnlCoco.Controls.Add(this.lblCoco);
			this.pnlCoco.Location = new System.Drawing.Point(3, 3);
			this.pnlCoco.Name = "pnlCoco";
			this.pnlCoco.Size = new System.Drawing.Size(1306, 160);
			this.pnlCoco.TabIndex = 4;
			// 
			// lblCocoTest
			// 
			this.lblCocoTest.AutoSize = true;
			this.lblCocoTest.Location = new System.Drawing.Point(11, 119);
			this.lblCocoTest.Name = "lblCocoTest";
			this.lblCocoTest.Size = new System.Drawing.Size(40, 20);
			this.lblCocoTest.TabIndex = 10;
			this.lblCocoTest.Text = "Test";
			// 
			// btnJsonFileTest
			// 
			this.btnJsonFileTest.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnJsonFileTest.Location = new System.Drawing.Point(71, 113);
			this.btnJsonFileTest.Name = "btnJsonFileTest";
			this.btnJsonFileTest.Size = new System.Drawing.Size(133, 32);
			this.btnJsonFileTest.TabIndex = 8;
			this.btnJsonFileTest.Text = "Json File";
			this.btnJsonFileTest.UseVisualStyleBackColor = true;
			this.btnJsonFileTest.Click += new System.EventHandler(this.btnJsonFileTest_Click);
			// 
			// txtJsonFileTest
			// 
			this.txtJsonFileTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtJsonFileTest.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.txtJsonFileTest.Location = new System.Drawing.Point(210, 115);
			this.txtJsonFileTest.Name = "txtJsonFileTest";
			this.txtJsonFileTest.Size = new System.Drawing.Size(1085, 29);
			this.txtJsonFileTest.TabIndex = 9;
			// 
			// lblCocoVal
			// 
			this.lblCocoVal.AutoSize = true;
			this.lblCocoVal.Location = new System.Drawing.Point(11, 81);
			this.lblCocoVal.Name = "lblCocoVal";
			this.lblCocoVal.Size = new System.Drawing.Size(33, 20);
			this.lblCocoVal.TabIndex = 7;
			this.lblCocoVal.Text = "Val";
			// 
			// btnJsonFileVal
			// 
			this.btnJsonFileVal.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnJsonFileVal.Location = new System.Drawing.Point(71, 75);
			this.btnJsonFileVal.Name = "btnJsonFileVal";
			this.btnJsonFileVal.Size = new System.Drawing.Size(133, 32);
			this.btnJsonFileVal.TabIndex = 5;
			this.btnJsonFileVal.Text = "Json File";
			this.btnJsonFileVal.UseVisualStyleBackColor = true;
			this.btnJsonFileVal.Click += new System.EventHandler(this.btnJsonFileVal_Click);
			// 
			// txtJsonFileVal
			// 
			this.txtJsonFileVal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtJsonFileVal.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.txtJsonFileVal.Location = new System.Drawing.Point(210, 77);
			this.txtJsonFileVal.Name = "txtJsonFileVal";
			this.txtJsonFileVal.Size = new System.Drawing.Size(1085, 29);
			this.txtJsonFileVal.TabIndex = 6;
			// 
			// lblCocoTrain
			// 
			this.lblCocoTrain.AutoSize = true;
			this.lblCocoTrain.Location = new System.Drawing.Point(11, 42);
			this.lblCocoTrain.Name = "lblCocoTrain";
			this.lblCocoTrain.Size = new System.Drawing.Size(47, 20);
			this.lblCocoTrain.TabIndex = 4;
			this.lblCocoTrain.Text = "Train";
			// 
			// btnJsonFileTrain
			// 
			this.btnJsonFileTrain.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnJsonFileTrain.Location = new System.Drawing.Point(71, 37);
			this.btnJsonFileTrain.Name = "btnJsonFileTrain";
			this.btnJsonFileTrain.Size = new System.Drawing.Size(133, 32);
			this.btnJsonFileTrain.TabIndex = 1;
			this.btnJsonFileTrain.Text = "Json File";
			this.btnJsonFileTrain.UseVisualStyleBackColor = true;
			this.btnJsonFileTrain.Click += new System.EventHandler(this.btnJsonFileTrain_Click);
			// 
			// txtJsonFileTrain
			// 
			this.txtJsonFileTrain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtJsonFileTrain.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.txtJsonFileTrain.Location = new System.Drawing.Point(210, 39);
			this.txtJsonFileTrain.Name = "txtJsonFileTrain";
			this.txtJsonFileTrain.Size = new System.Drawing.Size(1085, 29);
			this.txtJsonFileTrain.TabIndex = 3;
			// 
			// lblCoco
			// 
			this.lblCoco.AutoSize = true;
			this.lblCoco.Location = new System.Drawing.Point(7, 9);
			this.lblCoco.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
			this.lblCoco.Name = "lblCoco";
			this.lblCoco.Size = new System.Drawing.Size(110, 20);
			this.lblCoco.TabIndex = 2;
			this.lblCoco.Text = "COCO [ json ]";
			// 
			// pnlVoc
			// 
			this.pnlVoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlVoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlVoc.Controls.Add(this.btnVocLabelTest);
			this.pnlVoc.Controls.Add(this.txtVocLabelTest);
			this.pnlVoc.Controls.Add(this.btnVocLabelVal);
			this.pnlVoc.Controls.Add(this.txtVocLabelVal);
			this.pnlVoc.Controls.Add(this.lblVocTest);
			this.pnlVoc.Controls.Add(this.lblVocVal);
			this.pnlVoc.Controls.Add(this.lblVocTrain);
			this.pnlVoc.Controls.Add(this.btnVocLabelTrain);
			this.pnlVoc.Controls.Add(this.txtVocLabelTrain);
			this.pnlVoc.Controls.Add(this.lblVoc);
			this.pnlVoc.Location = new System.Drawing.Point(3, 169);
			this.pnlVoc.Name = "pnlVoc";
			this.pnlVoc.Size = new System.Drawing.Size(1306, 160);
			this.pnlVoc.TabIndex = 3;
			// 
			// btnVocLabelTest
			// 
			this.btnVocLabelTest.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnVocLabelTest.Location = new System.Drawing.Point(71, 113);
			this.btnVocLabelTest.Name = "btnVocLabelTest";
			this.btnVocLabelTest.Size = new System.Drawing.Size(133, 32);
			this.btnVocLabelTest.TabIndex = 17;
			this.btnVocLabelTest.Text = "Label Folder";
			this.btnVocLabelTest.UseVisualStyleBackColor = true;
			this.btnVocLabelTest.Click += new System.EventHandler(this.btnVocLabelTest_Click);
			// 
			// txtVocLabelTest
			// 
			this.txtVocLabelTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtVocLabelTest.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.txtVocLabelTest.Location = new System.Drawing.Point(210, 115);
			this.txtVocLabelTest.Name = "txtVocLabelTest";
			this.txtVocLabelTest.Size = new System.Drawing.Size(1085, 29);
			this.txtVocLabelTest.TabIndex = 18;
			// 
			// btnVocLabelVal
			// 
			this.btnVocLabelVal.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnVocLabelVal.Location = new System.Drawing.Point(71, 75);
			this.btnVocLabelVal.Name = "btnVocLabelVal";
			this.btnVocLabelVal.Size = new System.Drawing.Size(133, 32);
			this.btnVocLabelVal.TabIndex = 15;
			this.btnVocLabelVal.Text = "Label Folder";
			this.btnVocLabelVal.UseVisualStyleBackColor = true;
			this.btnVocLabelVal.Click += new System.EventHandler(this.btnVocLabelVal_Click);
			// 
			// txtVocLabelVal
			// 
			this.txtVocLabelVal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtVocLabelVal.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.txtVocLabelVal.Location = new System.Drawing.Point(210, 77);
			this.txtVocLabelVal.Name = "txtVocLabelVal";
			this.txtVocLabelVal.Size = new System.Drawing.Size(1085, 29);
			this.txtVocLabelVal.TabIndex = 16;
			// 
			// lblVocTest
			// 
			this.lblVocTest.AutoSize = true;
			this.lblVocTest.Location = new System.Drawing.Point(11, 119);
			this.lblVocTest.Name = "lblVocTest";
			this.lblVocTest.Size = new System.Drawing.Size(40, 20);
			this.lblVocTest.TabIndex = 14;
			this.lblVocTest.Text = "Test";
			// 
			// lblVocVal
			// 
			this.lblVocVal.AutoSize = true;
			this.lblVocVal.Location = new System.Drawing.Point(11, 81);
			this.lblVocVal.Name = "lblVocVal";
			this.lblVocVal.Size = new System.Drawing.Size(33, 20);
			this.lblVocVal.TabIndex = 13;
			this.lblVocVal.Text = "Val";
			// 
			// lblVocTrain
			// 
			this.lblVocTrain.AutoSize = true;
			this.lblVocTrain.Location = new System.Drawing.Point(11, 42);
			this.lblVocTrain.Name = "lblVocTrain";
			this.lblVocTrain.Size = new System.Drawing.Size(47, 20);
			this.lblVocTrain.TabIndex = 12;
			this.lblVocTrain.Text = "Train";
			// 
			// btnVocLabelTrain
			// 
			this.btnVocLabelTrain.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnVocLabelTrain.Location = new System.Drawing.Point(71, 37);
			this.btnVocLabelTrain.Name = "btnVocLabelTrain";
			this.btnVocLabelTrain.Size = new System.Drawing.Size(133, 32);
			this.btnVocLabelTrain.TabIndex = 1;
			this.btnVocLabelTrain.Text = "Label Folder";
			this.btnVocLabelTrain.UseVisualStyleBackColor = true;
			this.btnVocLabelTrain.Click += new System.EventHandler(this.btnVocLabelTrain_Click);
			// 
			// txtVocLabelTrain
			// 
			this.txtVocLabelTrain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtVocLabelTrain.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.txtVocLabelTrain.Location = new System.Drawing.Point(210, 39);
			this.txtVocLabelTrain.Name = "txtVocLabelTrain";
			this.txtVocLabelTrain.Size = new System.Drawing.Size(1085, 29);
			this.txtVocLabelTrain.TabIndex = 3;
			// 
			// lblVoc
			// 
			this.lblVoc.AutoSize = true;
			this.lblVoc.Location = new System.Drawing.Point(7, 9);
			this.lblVoc.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
			this.lblVoc.Name = "lblVoc";
			this.lblVoc.Size = new System.Drawing.Size(93, 20);
			this.lblVoc.TabIndex = 2;
			this.lblVoc.Text = "VOC [ xml ]";
			// 
			// pnlYolo
			// 
			this.pnlYolo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlYolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlYolo.Controls.Add(this.btnYoloLabelTest);
			this.pnlYolo.Controls.Add(this.txtYoloLabelTest);
			this.pnlYolo.Controls.Add(this.btnYoloLabelVal);
			this.pnlYolo.Controls.Add(this.txtYoloLabelVal);
			this.pnlYolo.Controls.Add(this.lblYoloTest);
			this.pnlYolo.Controls.Add(this.btnYoloLabelTrain);
			this.pnlYolo.Controls.Add(this.lblYoloVal);
			this.pnlYolo.Controls.Add(this.txtYoloLabelTrain);
			this.pnlYolo.Controls.Add(this.lblYoloTrain);
			this.pnlYolo.Controls.Add(this.lblYolo);
			this.pnlYolo.Location = new System.Drawing.Point(3, 335);
			this.pnlYolo.Name = "pnlYolo";
			this.pnlYolo.Size = new System.Drawing.Size(1306, 160);
			this.pnlYolo.TabIndex = 5;
			// 
			// btnYoloLabelTest
			// 
			this.btnYoloLabelTest.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnYoloLabelTest.Location = new System.Drawing.Point(71, 113);
			this.btnYoloLabelTest.Name = "btnYoloLabelTest";
			this.btnYoloLabelTest.Size = new System.Drawing.Size(133, 32);
			this.btnYoloLabelTest.TabIndex = 24;
			this.btnYoloLabelTest.Text = "Label Folder";
			this.btnYoloLabelTest.UseVisualStyleBackColor = true;
			this.btnYoloLabelTest.Click += new System.EventHandler(this.btnYoloLabelTest_Click);
			// 
			// txtYoloLabelTest
			// 
			this.txtYoloLabelTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtYoloLabelTest.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.txtYoloLabelTest.Location = new System.Drawing.Point(210, 115);
			this.txtYoloLabelTest.Name = "txtYoloLabelTest";
			this.txtYoloLabelTest.Size = new System.Drawing.Size(1085, 29);
			this.txtYoloLabelTest.TabIndex = 25;
			// 
			// btnYoloLabelVal
			// 
			this.btnYoloLabelVal.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnYoloLabelVal.Location = new System.Drawing.Point(71, 75);
			this.btnYoloLabelVal.Name = "btnYoloLabelVal";
			this.btnYoloLabelVal.Size = new System.Drawing.Size(133, 32);
			this.btnYoloLabelVal.TabIndex = 22;
			this.btnYoloLabelVal.Text = "Label Folder";
			this.btnYoloLabelVal.UseVisualStyleBackColor = true;
			this.btnYoloLabelVal.Click += new System.EventHandler(this.btnYoloLabelVal_Click);
			// 
			// txtYoloLabelVal
			// 
			this.txtYoloLabelVal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtYoloLabelVal.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.txtYoloLabelVal.Location = new System.Drawing.Point(210, 77);
			this.txtYoloLabelVal.Name = "txtYoloLabelVal";
			this.txtYoloLabelVal.Size = new System.Drawing.Size(1085, 29);
			this.txtYoloLabelVal.TabIndex = 23;
			// 
			// lblYoloTest
			// 
			this.lblYoloTest.AutoSize = true;
			this.lblYoloTest.Location = new System.Drawing.Point(11, 119);
			this.lblYoloTest.Name = "lblYoloTest";
			this.lblYoloTest.Size = new System.Drawing.Size(40, 20);
			this.lblYoloTest.TabIndex = 21;
			this.lblYoloTest.Text = "Test";
			// 
			// btnYoloLabelTrain
			// 
			this.btnYoloLabelTrain.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnYoloLabelTrain.Location = new System.Drawing.Point(71, 37);
			this.btnYoloLabelTrain.Name = "btnYoloLabelTrain";
			this.btnYoloLabelTrain.Size = new System.Drawing.Size(133, 32);
			this.btnYoloLabelTrain.TabIndex = 4;
			this.btnYoloLabelTrain.Text = "Label Folder";
			this.btnYoloLabelTrain.UseVisualStyleBackColor = true;
			this.btnYoloLabelTrain.Click += new System.EventHandler(this.btnYoloLabelTrain_Click);
			// 
			// lblYoloVal
			// 
			this.lblYoloVal.AutoSize = true;
			this.lblYoloVal.Location = new System.Drawing.Point(11, 81);
			this.lblYoloVal.Name = "lblYoloVal";
			this.lblYoloVal.Size = new System.Drawing.Size(33, 20);
			this.lblYoloVal.TabIndex = 20;
			this.lblYoloVal.Text = "Val";
			// 
			// txtYoloLabelTrain
			// 
			this.txtYoloLabelTrain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtYoloLabelTrain.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.txtYoloLabelTrain.Location = new System.Drawing.Point(210, 39);
			this.txtYoloLabelTrain.Name = "txtYoloLabelTrain";
			this.txtYoloLabelTrain.Size = new System.Drawing.Size(1085, 29);
			this.txtYoloLabelTrain.TabIndex = 5;
			// 
			// lblYoloTrain
			// 
			this.lblYoloTrain.AutoSize = true;
			this.lblYoloTrain.Location = new System.Drawing.Point(11, 42);
			this.lblYoloTrain.Name = "lblYoloTrain";
			this.lblYoloTrain.Size = new System.Drawing.Size(47, 20);
			this.lblYoloTrain.TabIndex = 19;
			this.lblYoloTrain.Text = "Train";
			// 
			// lblYolo
			// 
			this.lblYolo.AutoSize = true;
			this.lblYolo.Location = new System.Drawing.Point(7, 9);
			this.lblYolo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
			this.lblYolo.Name = "lblYolo";
			this.lblYolo.Size = new System.Drawing.Size(95, 20);
			this.lblYolo.TabIndex = 2;
			this.lblYolo.Text = "YOLO [ txt ]";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.pnlImage);
			this.panel1.Controls.Add(this.flowLayoutPanel1);
			this.panel1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1322, 747);
			this.panel1.TabIndex = 27;
			// 
			// pnlImage
			// 
			this.pnlImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlImage.Controls.Add(this.btnCheckClasses);
			this.pnlImage.Controls.Add(this.chkTest);
			this.pnlImage.Controls.Add(this.cmbMode);
			this.pnlImage.Controls.Add(this.btnImageTest);
			this.pnlImage.Controls.Add(this.btnConvert);
			this.pnlImage.Controls.Add(this.txtImageTest);
			this.pnlImage.Controls.Add(this.chkVal);
			this.pnlImage.Controls.Add(this.txtImageTrain);
			this.pnlImage.Controls.Add(this.btnImageVal);
			this.pnlImage.Controls.Add(this.btnImageTrain);
			this.pnlImage.Controls.Add(this.txtImageVal);
			this.pnlImage.Controls.Add(this.chkTrain);
			this.pnlImage.Location = new System.Drawing.Point(5, 5);
			this.pnlImage.Margin = new System.Windows.Forms.Padding(5);
			this.pnlImage.Name = "pnlImage";
			this.pnlImage.Size = new System.Drawing.Size(1312, 168);
			this.pnlImage.TabIndex = 28;
			// 
			// btnCheckClasses
			// 
			this.btnCheckClasses.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnCheckClasses.Location = new System.Drawing.Point(277, 10);
			this.btnCheckClasses.Name = "btnCheckClasses";
			this.btnCheckClasses.Size = new System.Drawing.Size(169, 32);
			this.btnCheckClasses.TabIndex = 27;
			this.btnCheckClasses.Text = "Check Label Classes";
			this.btnCheckClasses.UseVisualStyleBackColor = true;
			this.btnCheckClasses.Click += new System.EventHandler(this.btnCheckClasses_Click);
			// 
			// LabelConverterControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Name = "LabelConverterControl";
			this.Size = new System.Drawing.Size(1322, 747);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.pnlCoco.ResumeLayout(false);
			this.pnlCoco.PerformLayout();
			this.pnlVoc.ResumeLayout(false);
			this.pnlVoc.PerformLayout();
			this.pnlYolo.ResumeLayout(false);
			this.pnlYolo.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.pnlImage.ResumeLayout(false);
			this.pnlImage.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbMode;
		private System.Windows.Forms.Button btnConvert;
		private System.Windows.Forms.CheckBox chkTest;
		private System.Windows.Forms.Button btnImageTest;
		private System.Windows.Forms.TextBox txtImageTest;
		private System.Windows.Forms.CheckBox chkVal;
		private System.Windows.Forms.Button btnImageVal;
		private System.Windows.Forms.TextBox txtImageVal;
		private System.Windows.Forms.CheckBox chkTrain;
		private System.Windows.Forms.Button btnImageTrain;
		private System.Windows.Forms.TextBox txtImageTrain;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Panel pnlCoco;
		private System.Windows.Forms.Label lblCocoTest;
		private System.Windows.Forms.Button btnJsonFileTest;
		private System.Windows.Forms.TextBox txtJsonFileTest;
		private System.Windows.Forms.Label lblCocoVal;
		private System.Windows.Forms.Button btnJsonFileVal;
		private System.Windows.Forms.TextBox txtJsonFileVal;
		private System.Windows.Forms.Label lblCocoTrain;
		private System.Windows.Forms.Button btnJsonFileTrain;
		private System.Windows.Forms.TextBox txtJsonFileTrain;
		private System.Windows.Forms.Label lblCoco;
		private System.Windows.Forms.Panel pnlVoc;
		private System.Windows.Forms.Button btnVocLabelTest;
		private System.Windows.Forms.TextBox txtVocLabelTest;
		private System.Windows.Forms.Button btnVocLabelVal;
		private System.Windows.Forms.TextBox txtVocLabelVal;
		private System.Windows.Forms.Label lblVocTest;
		private System.Windows.Forms.Label lblVocVal;
		private System.Windows.Forms.Label lblVocTrain;
		private System.Windows.Forms.Button btnVocLabelTrain;
		private System.Windows.Forms.TextBox txtVocLabelTrain;
		private System.Windows.Forms.Label lblVoc;
		private System.Windows.Forms.Panel pnlYolo;
		private System.Windows.Forms.Button btnYoloLabelTest;
		private System.Windows.Forms.TextBox txtYoloLabelTest;
		private System.Windows.Forms.Button btnYoloLabelVal;
		private System.Windows.Forms.TextBox txtYoloLabelVal;
		private System.Windows.Forms.Label lblYoloTest;
		private System.Windows.Forms.Button btnYoloLabelTrain;
		private System.Windows.Forms.Label lblYoloVal;
		private System.Windows.Forms.TextBox txtYoloLabelTrain;
		private System.Windows.Forms.Label lblYoloTrain;
		private System.Windows.Forms.Label lblYolo;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCheckClasses;
		private System.Windows.Forms.Panel pnlImage;
	}
}
