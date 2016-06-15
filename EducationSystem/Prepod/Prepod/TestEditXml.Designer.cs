namespace Prepod
{
    partial class TestEditXml
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
            this.rTB = new System.Windows.Forms.RichTextBox();
            this.gBText = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.легендаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gBLegend = new System.Windows.Forms.GroupBox();
            this.rTBLegend = new System.Windows.Forms.RichTextBox();
            this.lblLegend = new System.Windows.Forms.Label();
            this.gBText.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gBLegend.SuspendLayout();
            this.SuspendLayout();
            // 
            // rTB
            // 
            this.rTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTB.Location = new System.Drawing.Point(4, 20);
            this.rTB.Margin = new System.Windows.Forms.Padding(4);
            this.rTB.Name = "rTB";
            this.rTB.Size = new System.Drawing.Size(510, 423);
            this.rTB.TabIndex = 0;
            this.rTB.Text = "";
            this.rTB.TextChanged += new System.EventHandler(this.rTB_TextChanged);
            // 
            // gBText
            // 
            this.gBText.Controls.Add(this.rTB);
            this.gBText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBText.Location = new System.Drawing.Point(0, 0);
            this.gBText.Margin = new System.Windows.Forms.Padding(4);
            this.gBText.Name = "gBText";
            this.gBText.Padding = new System.Windows.Forms.Padding(4);
            this.gBText.Size = new System.Drawing.Size(518, 447);
            this.gBText.TabIndex = 1;
            this.gBText.TabStop = false;
            this.gBText.Text = "Текст XML-файла:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.выходToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(983, 27);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem1,
            this.сохранитьToolStripMenuItem1});
            this.сохранитьToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this.сохранитьToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem1
            // 
            this.открытьToolStripMenuItem1.Name = "открытьToolStripMenuItem1";
            this.открытьToolStripMenuItem1.Size = new System.Drawing.Size(145, 24);
            this.открытьToolStripMenuItem1.Text = "Открыть";
            this.открытьToolStripMenuItem1.Click += new System.EventHandler(this.открытьToolStripMenuItem1_Click);
            // 
            // сохранитьToolStripMenuItem1
            // 
            this.сохранитьToolStripMenuItem1.Name = "сохранитьToolStripMenuItem1";
            this.сохранитьToolStripMenuItem1.Size = new System.Drawing.Size(145, 24);
            this.сохранитьToolStripMenuItem1.Text = "Сохранить";
            this.сохранитьToolStripMenuItem1.Click += new System.EventHandler(this.сохранитьToolStripMenuItem1_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(61, 23);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.легендаToolStripMenuItem});
            this.помощьToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(76, 23);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // легендаToolStripMenuItem
            // 
            this.легендаToolStripMenuItem.Name = "легендаToolStripMenuItem";
            this.легендаToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.легендаToolStripMenuItem.Text = "Легенда";
            this.легендаToolStripMenuItem.Click += new System.EventHandler(this.легендаToolStripMenuItem_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
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
            this.splitContainer1.Panel1.Controls.Add(this.gBText);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gBLegend);
            this.splitContainer1.Size = new System.Drawing.Size(983, 447);
            this.splitContainer1.SplitterDistance = 518;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // gBLegend
            // 
            this.gBLegend.Controls.Add(this.rTBLegend);
            this.gBLegend.Controls.Add(this.lblLegend);
            this.gBLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBLegend.Location = new System.Drawing.Point(0, 0);
            this.gBLegend.Margin = new System.Windows.Forms.Padding(4);
            this.gBLegend.Name = "gBLegend";
            this.gBLegend.Padding = new System.Windows.Forms.Padding(4);
            this.gBLegend.Size = new System.Drawing.Size(460, 447);
            this.gBLegend.TabIndex = 0;
            this.gBLegend.TabStop = false;
            this.gBLegend.Text = "Легенда:";
            // 
            // rTBLegend
            // 
            this.rTBLegend.BackColor = System.Drawing.Color.LightBlue;
            this.rTBLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTBLegend.Location = new System.Drawing.Point(4, 20);
            this.rTBLegend.Name = "rTBLegend";
            this.rTBLegend.Size = new System.Drawing.Size(452, 423);
            this.rTBLegend.TabIndex = 1;
            this.rTBLegend.Text = "";
            // 
            // lblLegend
            // 
            this.lblLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLegend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLegend.Location = new System.Drawing.Point(4, 20);
            this.lblLegend.Name = "lblLegend";
            this.lblLegend.Size = new System.Drawing.Size(452, 423);
            this.lblLegend.TabIndex = 0;
            // 
            // TestEditXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 474);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TestEditXml";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование теста";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TestEditXml_Load);
            this.gBText.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gBLegend.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rTB;
        private System.Windows.Forms.GroupBox gBText;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem легендаToolStripMenuItem;
        private System.Windows.Forms.GroupBox gBLegend;
        private System.Windows.Forms.Label lblLegend;
        private System.Windows.Forms.RichTextBox rTBLegend;
    }
}