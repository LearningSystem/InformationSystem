namespace Prepod
{
    partial class InfoTest
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
            this.lblNameTest = new System.Windows.Forms.Label();
            this.tBNameTest = new System.Windows.Forms.TextBox();
            this.lblDescTest = new System.Windows.Forms.Label();
            this.rtBDescTest = new System.Windows.Forms.RichTextBox();
            this.lblThemeTest = new System.Windows.Forms.Label();
            this.tBThemeTest = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.gB = new System.Windows.Forms.GroupBox();
            this.gB.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNameTest
            // 
            this.lblNameTest.AutoSize = true;
            this.lblNameTest.Location = new System.Drawing.Point(15, 28);
            this.lblNameTest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNameTest.Name = "lblNameTest";
            this.lblNameTest.Size = new System.Drawing.Size(117, 17);
            this.lblNameTest.TabIndex = 0;
            this.lblNameTest.Text = "Название теста:";
            // 
            // tBNameTest
            // 
            this.tBNameTest.Location = new System.Drawing.Point(155, 27);
            this.tBNameTest.Margin = new System.Windows.Forms.Padding(4);
            this.tBNameTest.MaxLength = 10;
            this.tBNameTest.Name = "tBNameTest";
            this.tBNameTest.Size = new System.Drawing.Size(311, 23);
            this.tBNameTest.TabIndex = 1;
            // 
            // lblDescTest
            // 
            this.lblDescTest.AutoSize = true;
            this.lblDescTest.Location = new System.Drawing.Point(15, 195);
            this.lblDescTest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescTest.Name = "lblDescTest";
            this.lblDescTest.Size = new System.Drawing.Size(119, 17);
            this.lblDescTest.TabIndex = 2;
            this.lblDescTest.Text = "Описание теста:";
            // 
            // rtBDescTest
            // 
            this.rtBDescTest.Location = new System.Drawing.Point(155, 165);
            this.rtBDescTest.Margin = new System.Windows.Forms.Padding(4);
            this.rtBDescTest.Name = "rtBDescTest";
            this.rtBDescTest.Size = new System.Drawing.Size(309, 80);
            this.rtBDescTest.TabIndex = 3;
            this.rtBDescTest.Text = "";
            // 
            // lblThemeTest
            // 
            this.lblThemeTest.AutoSize = true;
            this.lblThemeTest.Location = new System.Drawing.Point(45, 97);
            this.lblThemeTest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThemeTest.Name = "lblThemeTest";
            this.lblThemeTest.Size = new System.Drawing.Size(87, 17);
            this.lblThemeTest.TabIndex = 6;
            this.lblThemeTest.Text = "Тема теста:";
            // 
            // tBThemeTest
            // 
            this.tBThemeTest.Location = new System.Drawing.Point(155, 95);
            this.tBThemeTest.Margin = new System.Windows.Forms.Padding(4);
            this.tBThemeTest.MaxLength = 10;
            this.tBThemeTest.Name = "tBThemeTest";
            this.tBThemeTest.Size = new System.Drawing.Size(311, 23);
            this.tBThemeTest.TabIndex = 7;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(367, 282);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 28);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Далее";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(18, 282);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 28);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gB
            // 
            this.gB.Controls.Add(this.tBNameTest);
            this.gB.Controls.Add(this.btnNext);
            this.gB.Controls.Add(this.btnExit);
            this.gB.Controls.Add(this.lblNameTest);
            this.gB.Controls.Add(this.rtBDescTest);
            this.gB.Controls.Add(this.tBThemeTest);
            this.gB.Controls.Add(this.lblThemeTest);
            this.gB.Controls.Add(this.lblDescTest);
            this.gB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gB.Location = new System.Drawing.Point(0, 0);
            this.gB.Margin = new System.Windows.Forms.Padding(4);
            this.gB.Name = "gB";
            this.gB.Padding = new System.Windows.Forms.Padding(4);
            this.gB.Size = new System.Drawing.Size(481, 323);
            this.gB.TabIndex = 14;
            this.gB.TabStop = false;
            this.gB.Text = "Тест:";
            // 
            // InfoTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 323);
            this.Controls.Add(this.gB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InfoTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация о тесте";
            this.Load += new System.EventHandler(this.InfoTest_Load);
            this.gB.ResumeLayout(false);
            this.gB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNameTest;
        private System.Windows.Forms.TextBox tBNameTest;
        private System.Windows.Forms.Label lblDescTest;
        private System.Windows.Forms.RichTextBox rtBDescTest;
        private System.Windows.Forms.Label lblThemeTest;
        private System.Windows.Forms.TextBox tBThemeTest;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox gB;
    }
}