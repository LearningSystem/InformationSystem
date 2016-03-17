namespace Prepod
{
    partial class ReportForm
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
            this.lblStudName = new System.Windows.Forms.Label();
            this.lblStudGroup = new System.Windows.Forms.Label();
            this.lblNameTest = new System.Windows.Forms.Label();
            this.lblStudBall = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblTheme = new System.Windows.Forms.Label();
            this.lblBall = new System.Windows.Forms.Label();
            this.treeViewTest = new System.Windows.Forms.TreeView();
            this.lblTest = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStudName
            // 
            this.lblStudName.AutoSize = true;
            this.lblStudName.Location = new System.Drawing.Point(64, 63);
            this.lblStudName.Name = "lblStudName";
            this.lblStudName.Size = new System.Drawing.Size(37, 13);
            this.lblStudName.TabIndex = 0;
            this.lblStudName.Text = "ФИО:";
            // 
            // lblStudGroup
            // 
            this.lblStudGroup.AutoSize = true;
            this.lblStudGroup.Location = new System.Drawing.Point(56, 133);
            this.lblStudGroup.Name = "lblStudGroup";
            this.lblStudGroup.Size = new System.Drawing.Size(45, 13);
            this.lblStudGroup.TabIndex = 1;
            this.lblStudGroup.Text = "Группа:";
            // 
            // lblNameTest
            // 
            this.lblNameTest.AutoSize = true;
            this.lblNameTest.Location = new System.Drawing.Point(10, 215);
            this.lblNameTest.Name = "lblNameTest";
            this.lblNameTest.Size = new System.Drawing.Size(91, 13);
            this.lblNameTest.TabIndex = 2;
            this.lblNameTest.Text = "Название теста:";
            // 
            // lblStudBall
            // 
            this.lblStudBall.AutoSize = true;
            this.lblStudBall.Location = new System.Drawing.Point(58, 271);
            this.lblStudBall.Name = "lblStudBall";
            this.lblStudBall.Size = new System.Drawing.Size(43, 13);
            this.lblStudBall.TabIndex = 3;
            this.lblStudBall.Text = "Баллы:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(560, 330);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(136, 63);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 13);
            this.lblName.TabIndex = 6;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(136, 133);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(0, 13);
            this.lblGroup.TabIndex = 7;
            // 
            // lblTheme
            // 
            this.lblTheme.AutoSize = true;
            this.lblTheme.Location = new System.Drawing.Point(136, 215);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(0, 13);
            this.lblTheme.TabIndex = 8;
            // 
            // lblBall
            // 
            this.lblBall.AutoSize = true;
            this.lblBall.Location = new System.Drawing.Point(136, 271);
            this.lblBall.Name = "lblBall";
            this.lblBall.Size = new System.Drawing.Size(0, 13);
            this.lblBall.TabIndex = 9;
            // 
            // treeViewTest
            // 
            this.treeViewTest.BackColor = System.Drawing.SystemColors.Control;
            this.treeViewTest.Location = new System.Drawing.Point(278, 43);
            this.treeViewTest.Name = "treeViewTest";
            this.treeViewTest.Size = new System.Drawing.Size(357, 271);
            this.treeViewTest.TabIndex = 10;
            this.treeViewTest.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewTest_NodeMouseDoubleClick);
            this.treeViewTest.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeViewTest_MouseDoubleClick);
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(300, 16);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(77, 13);
            this.lblTest.TabIndex = 11;
            this.lblTest.Text = "Дерево теста";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 365);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.treeViewTest);
            this.Controls.Add(this.lblBall);
            this.Controls.Add(this.lblTheme);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblStudBall);
            this.Controls.Add(this.lblNameTest);
            this.Controls.Add(this.lblStudGroup);
            this.Controls.Add(this.lblStudName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчет";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportForm_FormClosing);
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStudName;
        private System.Windows.Forms.Label lblStudGroup;
        private System.Windows.Forms.Label lblNameTest;
        private System.Windows.Forms.Label lblStudBall;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.Label lblBall;
        private System.Windows.Forms.TreeView treeViewTest;
        private System.Windows.Forms.Label lblTest;
    }
}