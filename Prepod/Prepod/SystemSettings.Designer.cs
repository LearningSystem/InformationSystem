namespace Prepod
{
    partial class SystemSettings
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
            this.gBpath = new System.Windows.Forms.GroupBox();
            this.gBCompiler = new System.Windows.Forms.GroupBox();
            this.lblCompilePath = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.lblTempFile = new System.Windows.Forms.Label();
            this.txtBoxTemp = new System.Windows.Forms.TextBox();
            this.btnTemp = new System.Windows.Forms.Button();
            this.lblNumberCore = new System.Windows.Forms.Label();
            this.NumCore = new System.Windows.Forms.NumericUpDown();
            this.lblSaveTest = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnTests = new System.Windows.Forms.Button();
            this.lblStudentsTasks = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnStudentsTasks = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPrim = new System.Windows.Forms.Button();
            this.gBpath.SuspendLayout();
            this.gBCompiler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumCore)).BeginInit();
            this.SuspendLayout();
            // 
            // gBpath
            // 
            this.gBpath.Controls.Add(this.btnStudentsTasks);
            this.gBpath.Controls.Add(this.textBox3);
            this.gBpath.Controls.Add(this.lblStudentsTasks);
            this.gBpath.Controls.Add(this.btnTests);
            this.gBpath.Controls.Add(this.textBox2);
            this.gBpath.Controls.Add(this.lblSaveTest);
            this.gBpath.Location = new System.Drawing.Point(12, 12);
            this.gBpath.Name = "gBpath";
            this.gBpath.Size = new System.Drawing.Size(322, 215);
            this.gBpath.TabIndex = 0;
            this.gBpath.TabStop = false;
            this.gBpath.Text = "Директории:";
            // 
            // gBCompiler
            // 
            this.gBCompiler.Controls.Add(this.NumCore);
            this.gBCompiler.Controls.Add(this.lblNumberCore);
            this.gBCompiler.Controls.Add(this.btnTemp);
            this.gBCompiler.Controls.Add(this.txtBoxTemp);
            this.gBCompiler.Controls.Add(this.lblTempFile);
            this.gBCompiler.Controls.Add(this.btnSelect);
            this.gBCompiler.Controls.Add(this.textBox1);
            this.gBCompiler.Controls.Add(this.lblCompilePath);
            this.gBCompiler.Location = new System.Drawing.Point(340, 12);
            this.gBCompiler.Name = "gBCompiler";
            this.gBCompiler.Size = new System.Drawing.Size(322, 215);
            this.gBCompiler.TabIndex = 0;
            this.gBCompiler.TabStop = false;
            this.gBCompiler.Text = "Настройки черного ящика:";
            // 
            // lblCompilePath
            // 
            this.lblCompilePath.AutoSize = true;
            this.lblCompilePath.Location = new System.Drawing.Point(6, 25);
            this.lblCompilePath.Name = "lblCompilePath";
            this.lblCompilePath.Size = new System.Drawing.Size(178, 13);
            this.lblCompilePath.TabIndex = 0;
            this.lblCompilePath.Text = "Путь к exe - файлу (компилятору):";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 20);
            this.textBox1.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(241, 48);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Выбрать:";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // lblTempFile
            // 
            this.lblTempFile.AutoSize = true;
            this.lblTempFile.Location = new System.Drawing.Point(6, 86);
            this.lblTempFile.Name = "lblTempFile";
            this.lblTempFile.Size = new System.Drawing.Size(223, 13);
            this.lblTempFile.TabIndex = 3;
            this.lblTempFile.Text = "Директория хранения временных файлов:";
            // 
            // txtBoxTemp
            // 
            this.txtBoxTemp.Location = new System.Drawing.Point(6, 112);
            this.txtBoxTemp.Name = "txtBoxTemp";
            this.txtBoxTemp.Size = new System.Drawing.Size(229, 20);
            this.txtBoxTemp.TabIndex = 4;
            // 
            // btnTemp
            // 
            this.btnTemp.Location = new System.Drawing.Point(241, 112);
            this.btnTemp.Name = "btnTemp";
            this.btnTemp.Size = new System.Drawing.Size(75, 23);
            this.btnTemp.TabIndex = 5;
            this.btnTemp.Text = "Выбрать:";
            this.btnTemp.UseVisualStyleBackColor = true;
            // 
            // lblNumberCore
            // 
            this.lblNumberCore.AutoSize = true;
            this.lblNumberCore.Location = new System.Drawing.Point(6, 151);
            this.lblNumberCore.Name = "lblNumberCore";
            this.lblNumberCore.Size = new System.Drawing.Size(134, 13);
            this.lblNumberCore.TabIndex = 6;
            this.lblNumberCore.Text = "Кол-во ядер процессора:";
            // 
            // NumCore
            // 
            this.NumCore.Location = new System.Drawing.Point(6, 178);
            this.NumCore.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumCore.Name = "NumCore";
            this.NumCore.Size = new System.Drawing.Size(229, 20);
            this.NumCore.TabIndex = 7;
            this.NumCore.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSaveTest
            // 
            this.lblSaveTest.AutoSize = true;
            this.lblSaveTest.Location = new System.Drawing.Point(6, 25);
            this.lblSaveTest.Name = "lblSaveTest";
            this.lblSaveTest.Size = new System.Drawing.Size(150, 13);
            this.lblSaveTest.TabIndex = 0;
            this.lblSaveTest.Text = "Папка для хранения тестов:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 51);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(229, 20);
            this.textBox2.TabIndex = 1;
            // 
            // btnTests
            // 
            this.btnTests.Location = new System.Drawing.Point(244, 49);
            this.btnTests.Name = "btnTests";
            this.btnTests.Size = new System.Drawing.Size(75, 23);
            this.btnTests.TabIndex = 2;
            this.btnTests.Text = "Выбрать:";
            this.btnTests.UseVisualStyleBackColor = true;
            // 
            // lblStudentsTasks
            // 
            this.lblStudentsTasks.AutoSize = true;
            this.lblStudentsTasks.Location = new System.Drawing.Point(6, 86);
            this.lblStudentsTasks.Name = "lblStudentsTasks";
            this.lblStudentsTasks.Size = new System.Drawing.Size(199, 13);
            this.lblStudentsTasks.TabIndex = 3;
            this.lblStudentsTasks.Text = "Папка для хранения задач студентов:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(9, 112);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(229, 20);
            this.textBox3.TabIndex = 4;
            // 
            // btnStudentsTasks
            // 
            this.btnStudentsTasks.Location = new System.Drawing.Point(244, 110);
            this.btnStudentsTasks.Name = "btnStudentsTasks";
            this.btnStudentsTasks.Size = new System.Drawing.Size(75, 23);
            this.btnStudentsTasks.TabIndex = 5;
            this.btnStudentsTasks.Text = "Выбрать:";
            this.btnStudentsTasks.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(587, 233);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Назад";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPrim
            // 
            this.btnPrim.Location = new System.Drawing.Point(506, 233);
            this.btnPrim.Name = "btnPrim";
            this.btnPrim.Size = new System.Drawing.Size(75, 23);
            this.btnPrim.TabIndex = 2;
            this.btnPrim.Text = "Применить";
            this.btnPrim.UseVisualStyleBackColor = true;
            // 
            // SystemSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 263);
            this.Controls.Add(this.btnPrim);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.gBCompiler);
            this.Controls.Add(this.gBpath);
            this.Name = "SystemSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.gBpath.ResumeLayout(false);
            this.gBpath.PerformLayout();
            this.gBCompiler.ResumeLayout(false);
            this.gBCompiler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumCore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBpath;
        private System.Windows.Forms.GroupBox gBCompiler;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblCompilePath;
        private System.Windows.Forms.Button btnTemp;
        private System.Windows.Forms.TextBox txtBoxTemp;
        private System.Windows.Forms.Label lblTempFile;
        private System.Windows.Forms.Label lblNumberCore;
        private System.Windows.Forms.NumericUpDown NumCore;
        private System.Windows.Forms.Button btnTests;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblSaveTest;
        private System.Windows.Forms.Label lblStudentsTasks;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnStudentsTasks;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrim;
    }
}