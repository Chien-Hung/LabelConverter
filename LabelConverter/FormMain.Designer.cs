namespace LabelConverter
{
	partial class FormMain
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

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent ()
		{
			this.miniToolStrip = new System.Windows.Forms.StatusStrip();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabVisualization = new System.Windows.Forms.TabPage();
			this.tabSetting = new System.Windows.Forms.TabPage();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// miniToolStrip
			// 
			this.miniToolStrip.AccessibleName = "新增項目選取範圍";
			this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
			this.miniToolStrip.AutoSize = false;
			this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.miniToolStrip.Location = new System.Drawing.Point(42, 3);
			this.miniToolStrip.Name = "miniToolStrip";
			this.miniToolStrip.Size = new System.Drawing.Size(227, 25);
			this.miniToolStrip.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 6);
			this.label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 20);
			this.label2.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 5);
			this.label3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(95, 20);
			this.label3.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 9);
			this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 20);
			this.label1.TabIndex = 2;
			// 
			// tabVisualization
			// 
			this.tabVisualization.Location = new System.Drawing.Point(4, 29);
			this.tabVisualization.Name = "tabVisualization";
			this.tabVisualization.Padding = new System.Windows.Forms.Padding(3);
			this.tabVisualization.Size = new System.Drawing.Size(1358, 688);
			this.tabVisualization.TabIndex = 4;
			this.tabVisualization.Text = "Visualization";
			this.tabVisualization.UseVisualStyleBackColor = true;
			// 
			// tabSetting
			// 
			this.tabSetting.Font = new System.Drawing.Font("新細明體", 9F);
			this.tabSetting.Location = new System.Drawing.Point(4, 29);
			this.tabSetting.Name = "tabSetting";
			this.tabSetting.Padding = new System.Windows.Forms.Padding(3);
			this.tabSetting.Size = new System.Drawing.Size(1358, 688);
			this.tabSetting.TabIndex = 3;
			this.tabSetting.Text = "Setting";
			this.tabSetting.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabSetting);
			this.tabControl1.Controls.Add(this.tabVisualization);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1366, 721);
			this.tabControl1.TabIndex = 10;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1366, 721);
			this.Controls.Add(this.tabControl1);
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Voc / Yolo / Coco Label Converter <Object Detection>";
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.StatusStrip miniToolStrip;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabVisualization;
		private System.Windows.Forms.TabPage tabSetting;
		private System.Windows.Forms.TabControl tabControl1;
	}
}

