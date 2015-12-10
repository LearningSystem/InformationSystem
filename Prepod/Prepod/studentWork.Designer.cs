namespace Prepod
{
    partial class studentWork
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(studentWork));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьКурсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView2 = new System.Windows.Forms.ListView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.name = new System.Windows.Forms.ToolStripLabel();
            this.loadTask = new System.Windows.Forms.ToolStripButton();
            this.pg = new System.Windows.Forms.ToolStripProgressBar();
            this.nazad = new System.Windows.Forms.ToolStripButton();
            this.startTest = new System.Windows.Forms.ToolStripButton();
            this.bwStream = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.выйтиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(729, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьКурсToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // выбратьКурсToolStripMenuItem
            // 
            this.выбратьКурсToolStripMenuItem.Name = "выбратьКурсToolStripMenuItem";
            this.выбратьКурсToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.выбратьКурсToolStripMenuItem.Text = "Выбрать курс";
            this.выбратьКурсToolStripMenuItem.Click += new System.EventHandler(this.выбратьКурсToolStripMenuItem_Click);
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.выйтиToolStripMenuItem.Text = "Выйти";
            this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 351);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(729, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView2);
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(729, 327);
            this.splitContainer1.SplitterDistance = 198;
            this.splitContainer1.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(198, 327);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "directory_mini.bmp");
            this.imageList1.Images.SetKeyName(1, "Documents_mini.png");
            // 
            // listView2
            // 
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.LargeImageList = this.imageList2;
            this.listView2.Location = new System.Drawing.Point(0, 25);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(527, 302);
            this.listView2.SmallImageList = this.imageList1;
            this.listView2.TabIndex = 3;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            this.listView2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseDoubleClick);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "directory.bmp");
            this.imageList2.Images.SetKeyName(1, "Documents.png");
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.LargeImageList = this.imageList2;
            this.listView1.Location = new System.Drawing.Point(0, 25);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(527, 302);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick_1);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 25);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(527, 302);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.name,
            this.loadTask,
            this.pg,
            this.nazad,
            this.startTest});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(527, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // name
            // 
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(86, 22);
            this.name.Text = "toolStripLabel1";
            // 
            // loadTask
            // 
            this.loadTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loadTask.Image = ((System.Drawing.Image)(resources.GetObject("loadTask.Image")));
            this.loadTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadTask.Name = "loadTask";
            this.loadTask.Size = new System.Drawing.Size(81, 22);
            this.loadTask.Text = "Сдать задачу";
            this.loadTask.Click += new System.EventHandler(this.loadTask_Click);
            // 
            // pg
            // 
            this.pg.Name = "pg";
            this.pg.Size = new System.Drawing.Size(100, 22);
            // 
            // nazad
            // 
            this.nazad.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.nazad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.nazad.Image = ((System.Drawing.Image)(resources.GetObject("nazad.Image")));
            this.nazad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nazad.Name = "nazad";
            this.nazad.Size = new System.Drawing.Size(43, 22);
            this.nazad.Text = "Назад";
            this.nazad.Click += new System.EventHandler(this.nazad_Click);
            // 
            // startTest
            // 
            this.startTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.startTest.Image = ((System.Drawing.Image)(resources.GetObject("startTest.Image")));
            this.startTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startTest.Name = "startTest";
            this.startTest.Size = new System.Drawing.Size(122, 22);
            this.startTest.Text = "Начать выполнение";
            this.startTest.Click += new System.EventHandler(this.startTest_Click);
            // 
            // bwStream
            // 
            this.bwStream.WorkerReportsProgress = true;
            this.bwStream.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwStream_DoWork);
            this.bwStream.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwStream_ProgressChanged);
            // 
            // studentWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 373);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "studentWork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "studentWork";
            this.Load += new System.EventHandler(this.studentWork_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выбратьКурсToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel name;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ToolStripButton nazad;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton loadTask;
        private System.ComponentModel.BackgroundWorker bwStream;
        private System.Windows.Forms.ToolStripProgressBar pg;
        private System.Windows.Forms.ToolStripButton startTest;
    }
}