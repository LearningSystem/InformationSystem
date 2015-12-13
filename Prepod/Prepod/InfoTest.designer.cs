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
            this.lblAuthorTest = new System.Windows.Forms.Label();
            this.tBAuthorTest = new System.Windows.Forms.TextBox();
            this.lblThemeTest = new System.Windows.Forms.Label();
            this.tBThemeTest = new System.Windows.Forms.TextBox();
            this.lblDiscipTest = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cBDiscip = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblNameTest
            // 
            this.lblNameTest.AutoSize = true;
            this.lblNameTest.Location = new System.Drawing.Point(28, 41);
            this.lblNameTest.Name = "lblNameTest";
            this.lblNameTest.Size = new System.Drawing.Size(91, 13);
            this.lblNameTest.TabIndex = 0;
            this.lblNameTest.Text = "Название теста:";
            // 
            // tBNameTest
            // 
            this.tBNameTest.Location = new System.Drawing.Point(144, 38);
            this.tBNameTest.Name = "tBNameTest";
            this.tBNameTest.Size = new System.Drawing.Size(100, 20);
            this.tBNameTest.TabIndex = 1;
            // 
            // lblDescTest
            // 
            this.lblDescTest.AutoSize = true;
            this.lblDescTest.Location = new System.Drawing.Point(28, 121);
            this.lblDescTest.Name = "lblDescTest";
            this.lblDescTest.Size = new System.Drawing.Size(91, 13);
            this.lblDescTest.TabIndex = 2;
            this.lblDescTest.Text = "Описание теста:";
            // 
            // rtBDescTest
            // 
            this.rtBDescTest.Location = new System.Drawing.Point(144, 118);
            this.rtBDescTest.Name = "rtBDescTest";
            this.rtBDescTest.Size = new System.Drawing.Size(308, 187);
            this.rtBDescTest.TabIndex = 3;
            this.rtBDescTest.Text = "";
            // 
            // lblAuthorTest
            // 
            this.lblAuthorTest.AutoSize = true;
            this.lblAuthorTest.Location = new System.Drawing.Point(499, 41);
            this.lblAuthorTest.Name = "lblAuthorTest";
            this.lblAuthorTest.Size = new System.Drawing.Size(71, 13);
            this.lblAuthorTest.TabIndex = 4;
            this.lblAuthorTest.Text = "Автор теста:";
            // 
            // tBAuthorTest
            // 
            this.tBAuthorTest.Location = new System.Drawing.Point(599, 38);
            this.tBAuthorTest.Name = "tBAuthorTest";
            this.tBAuthorTest.Size = new System.Drawing.Size(121, 20);
            this.tBAuthorTest.TabIndex = 5;
            // 
            // lblThemeTest
            // 
            this.lblThemeTest.AutoSize = true;
            this.lblThemeTest.Location = new System.Drawing.Point(502, 111);
            this.lblThemeTest.Name = "lblThemeTest";
            this.lblThemeTest.Size = new System.Drawing.Size(68, 13);
            this.lblThemeTest.TabIndex = 6;
            this.lblThemeTest.Text = "Тема теста:";
            // 
            // tBThemeTest
            // 
            this.tBThemeTest.Location = new System.Drawing.Point(599, 108);
            this.tBThemeTest.Name = "tBThemeTest";
            this.tBThemeTest.Size = new System.Drawing.Size(121, 20);
            this.tBThemeTest.TabIndex = 7;
            // 
            // lblDiscipTest
            // 
            this.lblDiscipTest.AutoSize = true;
            this.lblDiscipTest.Location = new System.Drawing.Point(497, 190);
            this.lblDiscipTest.Name = "lblDiscipTest";
            this.lblDiscipTest.Size = new System.Drawing.Size(73, 13);
            this.lblDiscipTest.TabIndex = 8;
            this.lblDiscipTest.Text = "Дисциплина:";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(668, 312);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Далее";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 312);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cBDiscip
            // 
            this.cBDiscip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBDiscip.FormattingEnabled = true;
            this.cBDiscip.Location = new System.Drawing.Point(599, 182);
            this.cBDiscip.Name = "cBDiscip";
            this.cBDiscip.Size = new System.Drawing.Size(121, 21);
            this.cBDiscip.TabIndex = 14;
            // 
            // InfoTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 347);
            this.Controls.Add(this.cBDiscip);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblDiscipTest);
            this.Controls.Add(this.tBThemeTest);
            this.Controls.Add(this.lblThemeTest);
            this.Controls.Add(this.tBAuthorTest);
            this.Controls.Add(this.lblAuthorTest);
            this.Controls.Add(this.rtBDescTest);
            this.Controls.Add(this.lblDescTest);
            this.Controls.Add(this.tBNameTest);
            this.Controls.Add(this.lblNameTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InfoTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация о тесте";
            this.Load += new System.EventHandler(this.InfoTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNameTest;
        private System.Windows.Forms.TextBox tBNameTest;
        private System.Windows.Forms.Label lblDescTest;
        private System.Windows.Forms.RichTextBox rtBDescTest;
        private System.Windows.Forms.Label lblAuthorTest;
        private System.Windows.Forms.TextBox tBAuthorTest;
        private System.Windows.Forms.Label lblThemeTest;
        private System.Windows.Forms.TextBox tBThemeTest;
        private System.Windows.Forms.Label lblDiscipTest;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cBDiscip;
    }
}