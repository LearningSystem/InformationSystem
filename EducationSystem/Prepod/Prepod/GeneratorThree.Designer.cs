namespace Prepod
{
    partial class GeneratorThree
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gBGeneral = new System.Windows.Forms.GroupBox();
            this.lblProc = new System.Windows.Forms.Label();
            this.pgBar = new System.Windows.Forms.ProgressBar();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.KolNum = new System.Windows.Forms.NumericUpDown();
            this.lblKol = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.назадToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.впередToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gBGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KolNum)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.gBGeneral);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(549, 198);
            this.splitContainer1.SplitterDistance = 114;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // gBGeneral
            // 
            this.gBGeneral.Controls.Add(this.lblProc);
            this.gBGeneral.Controls.Add(this.pgBar);
            this.gBGeneral.Controls.Add(this.btnSelect);
            this.gBGeneral.Controls.Add(this.txtPath);
            this.gBGeneral.Controls.Add(this.lblPath);
            this.gBGeneral.Controls.Add(this.KolNum);
            this.gBGeneral.Controls.Add(this.lblKol);
            this.gBGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBGeneral.Location = new System.Drawing.Point(0, 0);
            this.gBGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.gBGeneral.Name = "gBGeneral";
            this.gBGeneral.Padding = new System.Windows.Forms.Padding(4);
            this.gBGeneral.Size = new System.Drawing.Size(549, 198);
            this.gBGeneral.TabIndex = 0;
            this.gBGeneral.TabStop = false;
            this.gBGeneral.Text = "Настройки:";
            // 
            // lblProc
            // 
            this.lblProc.AutoSize = true;
            this.lblProc.Location = new System.Drawing.Point(16, 159);
            this.lblProc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProc.Name = "lblProc";
            this.lblProc.Size = new System.Drawing.Size(103, 17);
            this.lblProc.TabIndex = 6;
            this.lblProc.Text = "Ход создания:";
            // 
            // pgBar
            // 
            this.pgBar.Location = new System.Drawing.Point(136, 153);
            this.pgBar.Margin = new System.Windows.Forms.Padding(4);
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(283, 28);
            this.pgBar.TabIndex = 5;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(440, 102);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 28);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "Выбрать";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(135, 106);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(281, 23);
            this.txtPath.TabIndex = 3;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(13, 107);
            this.lblPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(109, 17);
            this.lblPath.TabIndex = 2;
            this.lblPath.Text = "Путь хранения:";
            // 
            // KolNum
            // 
            this.KolNum.Location = new System.Drawing.Point(136, 47);
            this.KolNum.Margin = new System.Windows.Forms.Padding(4);
            this.KolNum.Name = "KolNum";
            this.KolNum.Size = new System.Drawing.Size(283, 23);
            this.KolNum.TabIndex = 1;
            // 
            // lblKol
            // 
            this.lblKol.AutoSize = true;
            this.lblKol.Location = new System.Drawing.Point(16, 49);
            this.lblKol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKol.Name = "lblKol";
            this.lblKol.Size = new System.Drawing.Size(100, 17);
            this.lblKol.TabIndex = 0;
            this.lblKol.Text = "Кол-во задач:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.назадToolStripMenuItem,
            this.впередToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(549, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // назадToolStripMenuItem
            // 
            this.назадToolStripMenuItem.Name = "назадToolStripMenuItem";
            this.назадToolStripMenuItem.Size = new System.Drawing.Size(73, 23);
            this.назадToolStripMenuItem.Text = "| Назад |";
            this.назадToolStripMenuItem.Click += new System.EventHandler(this.назадToolStripMenuItem_Click);
            // 
            // впередToolStripMenuItem
            // 
            this.впередToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.впередToolStripMenuItem.Name = "впередToolStripMenuItem";
            this.впередToolStripMenuItem.Size = new System.Drawing.Size(71, 23);
            this.впередToolStripMenuItem.Text = "| Старт |";
            this.впередToolStripMenuItem.Click += new System.EventHandler(this.впередToolStripMenuItem_Click);
            // 
            // GeneratorThree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 225);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GeneratorThree";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Генератор. Шаг третий.";
            this.Load += new System.EventHandler(this.GeneratorThree_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gBGeneral.ResumeLayout(false);
            this.gBGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KolNum)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem назадToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem впередToolStripMenuItem;
        private System.Windows.Forms.GroupBox gBGeneral;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.NumericUpDown KolNum;
        private System.Windows.Forms.Label lblKol;
        private System.Windows.Forms.Label lblProc;
        private System.Windows.Forms.ProgressBar pgBar;
    }
}