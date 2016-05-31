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
            this.lblName = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblTheme = new System.Windows.Forms.Label();
            this.lblBall = new System.Windows.Forms.Label();
            this.treeViewTest = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gBInfo = new System.Windows.Forms.GroupBox();
            this.gBTree = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gBInfo.SuspendLayout();
            this.gBTree.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStudName
            // 
            this.lblStudName.AutoSize = true;
            this.lblStudName.Location = new System.Drawing.Point(64, 47);
            this.lblStudName.Name = "lblStudName";
            this.lblStudName.Size = new System.Drawing.Size(37, 13);
            this.lblStudName.TabIndex = 0;
            this.lblStudName.Text = "ФИО:";
            // 
            // lblStudGroup
            // 
            this.lblStudGroup.AutoSize = true;
            this.lblStudGroup.Location = new System.Drawing.Point(56, 117);
            this.lblStudGroup.Name = "lblStudGroup";
            this.lblStudGroup.Size = new System.Drawing.Size(45, 13);
            this.lblStudGroup.TabIndex = 1;
            this.lblStudGroup.Text = "Группа:";
            // 
            // lblNameTest
            // 
            this.lblNameTest.AutoSize = true;
            this.lblNameTest.Location = new System.Drawing.Point(10, 199);
            this.lblNameTest.Name = "lblNameTest";
            this.lblNameTest.Size = new System.Drawing.Size(91, 13);
            this.lblNameTest.TabIndex = 2;
            this.lblNameTest.Text = "Название теста:";
            // 
            // lblStudBall
            // 
            this.lblStudBall.AutoSize = true;
            this.lblStudBall.Location = new System.Drawing.Point(58, 255);
            this.lblStudBall.Name = "lblStudBall";
            this.lblStudBall.Size = new System.Drawing.Size(43, 13);
            this.lblStudBall.TabIndex = 3;
            this.lblStudBall.Text = "Баллы:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(109, 47);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 13);
            this.lblName.TabIndex = 6;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(109, 117);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(0, 13);
            this.lblGroup.TabIndex = 7;
            // 
            // lblTheme
            // 
            this.lblTheme.AutoSize = true;
            this.lblTheme.Location = new System.Drawing.Point(109, 199);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(0, 13);
            this.lblTheme.TabIndex = 8;
            // 
            // lblBall
            // 
            this.lblBall.AutoSize = true;
            this.lblBall.Location = new System.Drawing.Point(109, 255);
            this.lblBall.Name = "lblBall";
            this.lblBall.Size = new System.Drawing.Size(0, 13);
            this.lblBall.TabIndex = 9;
            // 
            // treeViewTest
            // 
            this.treeViewTest.BackColor = System.Drawing.SystemColors.Control;
            this.treeViewTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewTest.Location = new System.Drawing.Point(3, 16);
            this.treeViewTest.Name = "treeViewTest";
            this.treeViewTest.Size = new System.Drawing.Size(340, 322);
            this.treeViewTest.TabIndex = 10;
            this.treeViewTest.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewTest_NodeMouseDoubleClick);
            this.treeViewTest.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeViewTest_MouseDoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gBInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gBTree);
            this.splitContainer1.Size = new System.Drawing.Size(647, 341);
            this.splitContainer1.SplitterDistance = 297;
            this.splitContainer1.TabIndex = 12;
            // 
            // gBInfo
            // 
            this.gBInfo.Controls.Add(this.lblStudBall);
            this.gBInfo.Controls.Add(this.lblBall);
            this.gBInfo.Controls.Add(this.lblTheme);
            this.gBInfo.Controls.Add(this.lblStudName);
            this.gBInfo.Controls.Add(this.lblStudGroup);
            this.gBInfo.Controls.Add(this.lblGroup);
            this.gBInfo.Controls.Add(this.lblNameTest);
            this.gBInfo.Controls.Add(this.lblName);
            this.gBInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBInfo.Location = new System.Drawing.Point(0, 0);
            this.gBInfo.Name = "gBInfo";
            this.gBInfo.Size = new System.Drawing.Size(297, 341);
            this.gBInfo.TabIndex = 0;
            this.gBInfo.TabStop = false;
            this.gBInfo.Text = "Информация:";
            // 
            // gBTree
            // 
            this.gBTree.Controls.Add(this.treeViewTest);
            this.gBTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBTree.Location = new System.Drawing.Point(0, 0);
            this.gBTree.Name = "gBTree";
            this.gBTree.Size = new System.Drawing.Size(346, 341);
            this.gBTree.TabIndex = 0;
            this.gBTree.TabStop = false;
            this.gBTree.Text = "Дерево теста:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(647, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 365);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчет";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportForm_FormClosing);
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gBInfo.ResumeLayout(false);
            this.gBInfo.PerformLayout();
            this.gBTree.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStudName;
        private System.Windows.Forms.Label lblStudGroup;
        private System.Windows.Forms.Label lblNameTest;
        private System.Windows.Forms.Label lblStudBall;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.Label lblBall;
        private System.Windows.Forms.TreeView treeViewTest;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gBInfo;
        private System.Windows.Forms.GroupBox gBTree;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
    }
}