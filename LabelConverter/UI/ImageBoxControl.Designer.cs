namespace LabelConverter.UI
{
	partial class ImageBoxControl
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbData = new System.Windows.Forms.ComboBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tssLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbLabelFormat = new System.Windows.Forms.ComboBox();
			this.panel2.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel3.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1220, 585);
			this.panel2.TabIndex = 12;
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel4.AutoScroll = true;
			this.panel4.Controls.Add(this.pictureBox1);
			this.panel4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.panel4.Location = new System.Drawing.Point(246, 5);
			this.panel4.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(969, 575);
			this.panel4.TabIndex = 19;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(969, 575);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.panel3.Controls.Add(this.label1);
			this.panel3.Controls.Add(this.cmbData);
			this.panel3.Controls.Add(this.statusStrip1);
			this.panel3.Controls.Add(this.listBox1);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Controls.Add(this.cmbLabelFormat);
			this.panel3.Location = new System.Drawing.Point(5, 5);
			this.panel3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(236, 575);
			this.panel3.TabIndex = 18;
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Location = new System.Drawing.Point(5, 43);
			this.label1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 28);
			this.label1.TabIndex = 12;
			this.label1.Text = "Data";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cmbData
			// 
			this.cmbData.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.cmbData.FormattingEnabled = true;
			this.cmbData.Items.AddRange(new object[] {
            "Train",
            "Val",
            "Test"});
			this.cmbData.Location = new System.Drawing.Point(125, 43);
			this.cmbData.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.cmbData.Name = "cmbData";
			this.cmbData.Size = new System.Drawing.Size(105, 28);
			this.cmbData.TabIndex = 11;
			this.cmbData.SelectedIndexChanged += new System.EventHandler(this.cmbData_SelectedIndexChanged);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 550);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 23, 0);
			this.statusStrip1.Size = new System.Drawing.Size(236, 25);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tssLabel1
			// 
			this.tssLabel1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.tssLabel1.Name = "tssLabel1";
			this.tssLabel1.Size = new System.Drawing.Size(41, 20);
			this.tssLabel1.Text = "        ";
			// 
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 20;
			this.listBox1.Location = new System.Drawing.Point(5, 81);
			this.listBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(225, 464);
			this.listBox1.TabIndex = 7;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label2.Location = new System.Drawing.Point(5, 5);
			this.label2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 28);
			this.label2.TabIndex = 10;
			this.label2.Text = "Format";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cmbLabelFormat
			// 
			this.cmbLabelFormat.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.cmbLabelFormat.FormattingEnabled = true;
			this.cmbLabelFormat.Items.AddRange(new object[] {
            "VOC",
            "YOLO",
            "COCO"});
			this.cmbLabelFormat.Location = new System.Drawing.Point(125, 5);
			this.cmbLabelFormat.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.cmbLabelFormat.Name = "cmbLabelFormat";
			this.cmbLabelFormat.Size = new System.Drawing.Size(105, 28);
			this.cmbLabelFormat.TabIndex = 9;
			this.cmbLabelFormat.SelectedIndexChanged += new System.EventHandler(this.cmbLabelFormat_SelectedIndexChanged);
			// 
			// UserControl3
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel2);
			this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.Name = "UserControl3";
			this.Size = new System.Drawing.Size(1220, 585);
			this.panel2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbData;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tssLabel1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbLabelFormat;
	}
}
