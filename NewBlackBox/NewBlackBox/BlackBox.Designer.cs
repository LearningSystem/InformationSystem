namespace NewBlackBox
{
    partial class BlackBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstBox = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gBTask = new System.Windows.Forms.GroupBox();
            this.rtbTask = new System.Windows.Forms.RichTextBox();
            this.gBInfo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.lblFio = new System.Windows.Forms.Label();
            this.gBXodProv = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стартToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gBTask.SuspendLayout();
            this.gBInfo.SuspendLayout();
            this.gBXodProv.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstBox
            // 
            this.lstBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBox.FormattingEnabled = true;
            this.lstBox.ItemHeight = 16;
            this.lstBox.Location = new System.Drawing.Point(3, 19);
            this.lstBox.Margin = new System.Windows.Forms.Padding(4);
            this.lstBox.Name = "lstBox";
            this.lstBox.Size = new System.Drawing.Size(368, 374);
            this.lstBox.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gBTask);
            this.splitContainer1.Panel1.Controls.Add(this.gBInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gBXodProv);
            this.splitContainer1.Size = new System.Drawing.Size(805, 396);
            this.splitContainer1.SplitterDistance = 426;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 3;
            // 
            // gBTask
            // 
            this.gBTask.Controls.Add(this.rtbTask);
            this.gBTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBTask.Location = new System.Drawing.Point(0, 128);
            this.gBTask.Name = "gBTask";
            this.gBTask.Size = new System.Drawing.Size(426, 268);
            this.gBTask.TabIndex = 1;
            this.gBTask.TabStop = false;
            this.gBTask.Text = "Текст задачи:";
            // 
            // rtbTask
            // 
            this.rtbTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbTask.Location = new System.Drawing.Point(3, 19);
            this.rtbTask.Name = "rtbTask";
            this.rtbTask.ReadOnly = true;
            this.rtbTask.Size = new System.Drawing.Size(420, 246);
            this.rtbTask.TabIndex = 0;
            this.rtbTask.Text = "";
            // 
            // gBInfo
            // 
            this.gBInfo.Controls.Add(this.label1);
            this.gBInfo.Controls.Add(this.comboBox1);
            this.gBInfo.Controls.Add(this.lbl3);
            this.gBInfo.Controls.Add(this.lbl2);
            this.gBInfo.Controls.Add(this.lbl1);
            this.gBInfo.Controls.Add(this.lblData);
            this.gBInfo.Controls.Add(this.lblFio);
            this.gBInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBInfo.Location = new System.Drawing.Point(0, 0);
            this.gBInfo.Name = "gBInfo";
            this.gBInfo.Size = new System.Drawing.Size(426, 128);
            this.gBInfo.TabIndex = 0;
            this.gBInfo.TabStop = false;
            this.gBInfo.Text = "Информация:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Задача:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(142, 101);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(227, 24);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(149, 66);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(0, 17);
            this.lbl3.TabIndex = 5;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(140, 66);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(0, 17);
            this.lbl2.TabIndex = 4;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(140, 31);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(0, 17);
            this.lbl1.TabIndex = 3;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(90, 66);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(46, 17);
            this.lblData.TabIndex = 2;
            this.lblData.Text = "Дата:";
            // 
            // lblFio
            // 
            this.lblFio.AutoSize = true;
            this.lblFio.Location = new System.Drawing.Point(14, 31);
            this.lblFio.Name = "lblFio";
            this.lblFio.Size = new System.Drawing.Size(122, 17);
            this.lblFio.TabIndex = 0;
            this.lblFio.Text = "Кто тестируется:";
            // 
            // gBXodProv
            // 
            this.gBXodProv.Controls.Add(this.lstBox);
            this.gBXodProv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBXodProv.Location = new System.Drawing.Point(0, 0);
            this.gBXodProv.Name = "gBXodProv";
            this.gBXodProv.Size = new System.Drawing.Size(374, 396);
            this.gBXodProv.TabIndex = 3;
            this.gBXodProv.TabStop = false;
            this.gBXodProv.Text = "Ход проверки:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SkyBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem,
            this.стартToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(805, 27);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.выходToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(75, 23);
            this.выходToolStripMenuItem.Text = "| Выход |";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // стартToolStripMenuItem
            // 
            this.стартToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.стартToolStripMenuItem.Name = "стартToolStripMenuItem";
            this.стартToolStripMenuItem.Size = new System.Drawing.Size(71, 23);
            this.стартToolStripMenuItem.Text = "| Старт |";
            this.стартToolStripMenuItem.Click += new System.EventHandler(this.стартToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(88, 23);
            this.помощьToolStripMenuItem.Text = "| Справка |";
            this.помощьToolStripMenuItem.Click += new System.EventHandler(this.помощьToolStripMenuItem_Click);
            // 
            // BlackBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 423);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BlackBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Черный ящик";
            this.Load += new System.EventHandler(this.BlackBox_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gBTask.ResumeLayout(false);
            this.gBInfo.ResumeLayout(false);
            this.gBInfo.PerformLayout();
            this.gBXodProv.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.GroupBox gBInfo;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblFio;
        private System.Windows.Forms.GroupBox gBTask;
        private System.Windows.Forms.RichTextBox rtbTask;
        private System.Windows.Forms.ToolStripMenuItem стартToolStripMenuItem;
        private System.Windows.Forms.GroupBox gBXodProv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
    }
}

