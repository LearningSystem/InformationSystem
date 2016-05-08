namespace Prepod
{
    partial class TestWorkStart
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
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.radBut3 = new System.Windows.Forms.RadioButton();
            this.btnPath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.radBut2 = new System.Windows.Forms.RadioButton();
            this.radBut1 = new System.Windows.Forms.RadioButton();
            this.openPath = new System.Windows.Forms.OpenFileDialog();
            this.gBChanged = new System.Windows.Forms.GroupBox();
            this.chBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.gb1.SuspendLayout();
            this.gBChanged.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(283, 234);
            this.splitContainer1.SplitterDistance = 94;
            this.splitContainer1.TabIndex = 0;
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.gBChanged);
            this.gb1.Controls.Add(this.btnPrev);
            this.gb1.Controls.Add(this.btnNext);
            this.gb1.Controls.Add(this.radBut3);
            this.gb1.Controls.Add(this.btnPath);
            this.gb1.Controls.Add(this.txtPath);
            this.gb1.Controls.Add(this.radBut2);
            this.gb1.Controls.Add(this.radBut1);
            this.gb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb1.Location = new System.Drawing.Point(0, 0);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(283, 234);
            this.gb1.TabIndex = 1;
            this.gb1.TabStop = false;
            this.gb1.Text = "Режим работы:";
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(6, 203);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 6;
            this.btnPrev.Text = "Назад";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(196, 203);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Далее";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // radBut3
            // 
            this.radBut3.AutoSize = true;
            this.radBut3.Location = new System.Drawing.Point(12, 175);
            this.radBut3.Name = "radBut3";
            this.radBut3.Size = new System.Drawing.Size(106, 17);
            this.radBut3.TabIndex = 4;
            this.radBut3.TabStop = true;
            this.radBut3.Text = "Удаление теста";
            this.radBut3.UseVisualStyleBackColor = true;
            this.radBut3.Click += new System.EventHandler(this.radBut1_Click);
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(196, 76);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(75, 23);
            this.btnPath.TabIndex = 3;
            this.btnPath.Text = "Выбрать";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 79);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(155, 20);
            this.txtPath.TabIndex = 2;
            // 
            // radBut2
            // 
            this.radBut2.AutoSize = true;
            this.radBut2.Location = new System.Drawing.Point(12, 53);
            this.radBut2.Name = "radBut2";
            this.radBut2.Size = new System.Drawing.Size(140, 17);
            this.radBut2.TabIndex = 1;
            this.radBut2.TabStop = true;
            this.radBut2.Text = "Редактирование теста";
            this.radBut2.UseVisualStyleBackColor = true;
            this.radBut2.Click += new System.EventHandler(this.radBut1_Click);
            // 
            // radBut1
            // 
            this.radBut1.AutoSize = true;
            this.radBut1.Location = new System.Drawing.Point(12, 25);
            this.radBut1.Name = "radBut1";
            this.radBut1.Size = new System.Drawing.Size(127, 17);
            this.radBut1.TabIndex = 0;
            this.radBut1.TabStop = true;
            this.radBut1.Text = "Создать новый тест";
            this.radBut1.UseVisualStyleBackColor = true;
            this.radBut1.Click += new System.EventHandler(this.radBut1_Click);
            // 
            // openPath
            // 
            this.openPath.Filter = "XML-файл (*.xml)|*.xml";
            // 
            // gBChanged
            // 
            this.gBChanged.Controls.Add(this.chBox1);
            this.gBChanged.Location = new System.Drawing.Point(12, 105);
            this.gBChanged.Name = "gBChanged";
            this.gBChanged.Size = new System.Drawing.Size(259, 64);
            this.gBChanged.TabIndex = 7;
            this.gBChanged.TabStop = false;
            this.gBChanged.Text = "Режим редактирования";
            // 
            // chBox1
            // 
            this.chBox1.AutoSize = true;
            this.chBox1.Location = new System.Drawing.Point(6, 29);
            this.chBox1.Name = "chBox1";
            this.chBox1.Size = new System.Drawing.Size(77, 17);
            this.chBox1.TabIndex = 0;
            this.chBox1.Text = "XML-файл";
            this.chBox1.UseVisualStyleBackColor = true;
            // 
            // TestWorkStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 234);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TestWorkStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор тестов";
            this.Load += new System.EventHandler(this.TestWorkStart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.gBChanged.ResumeLayout(false);
            this.gBChanged.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.RadioButton radBut1;
        private System.Windows.Forms.RadioButton radBut3;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.RadioButton radBut2;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.OpenFileDialog openPath;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.GroupBox gBChanged;
        private System.Windows.Forms.CheckBox chBox1;
    }
}