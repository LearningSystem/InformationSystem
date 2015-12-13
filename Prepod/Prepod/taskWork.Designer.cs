namespace Prepod
{
    partial class taskWork
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(taskWork));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.group = new System.Windows.Forms.ToolStripComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.check = new System.Windows.Forms.ToolStripDropDownButton();
            this.checkOneTask = new System.Windows.Forms.ToolStripMenuItem();
            this.checkNewTask = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.show = new System.Windows.Forms.ToolStripDropDownButton();
            this.showNew = new System.Windows.Forms.ToolStripMenuItem();
            this.showAll = new System.Windows.Forms.ToolStripMenuItem();
            this.showTask = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.watch = new System.Windows.Forms.ToolStripDropDownButton();
            this.watchTask = new System.Windows.Forms.ToolStripMenuItem();
            this.watchCode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cancel = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(961, 341);
            this.splitContainer1.SplitterDistance = 319;
            this.splitContainer1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 25);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(319, 316);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.group});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(319, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel1.Text = "Группа";
            // 
            // group
            // 
            this.group.Name = "group";
            this.group.Size = new System.Drawing.Size(121, 25);
            this.group.SelectedIndexChanged += new System.EventHandler(this.group_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(638, 316);
            this.dataGridView1.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 25);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(638, 316);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.check,
            this.toolStripSeparator1,
            this.show,
            this.toolStripSeparator2,
            this.watch,
            this.toolStripSeparator3,
            this.cancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(638, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // check
            // 
            this.check.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.check.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkOneTask,
            this.checkNewTask});
            this.check.Image = ((System.Drawing.Image)(resources.GetObject("check.Image")));
            this.check.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(74, 22);
            this.check.Text = "Проверка";
            // 
            // checkOneTask
            // 
            this.checkOneTask.Name = "checkOneTask";
            this.checkOneTask.Size = new System.Drawing.Size(193, 22);
            this.checkOneTask.Text = "Проверить задачу";
            this.checkOneTask.Click += new System.EventHandler(this.проверитьЗадачуToolStripMenuItem_Click);
            // 
            // checkNewTask
            // 
            this.checkNewTask.Name = "checkNewTask";
            this.checkNewTask.Size = new System.Drawing.Size(193, 22);
            this.checkNewTask.Text = "Проверить все новые";
            this.checkNewTask.Click += new System.EventHandler(this.проверитьВсеНовыеToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // show
            // 
            this.show.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.show.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showNew,
            this.showAll,
            this.showTask});
            this.show.Image = ((System.Drawing.Image)(resources.GetObject("show.Image")));
            this.show.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(70, 22);
            this.show.Text = "Показать";
            // 
            // showNew
            // 
            this.showNew.Name = "showNew";
            this.showNew.Size = new System.Drawing.Size(152, 22);
            this.showNew.Text = "Новые";
            this.showNew.Click += new System.EventHandler(this.showNew_Click);
            // 
            // showAll
            // 
            this.showAll.Name = "showAll";
            this.showAll.Size = new System.Drawing.Size(152, 22);
            this.showAll.Text = "Все задачи";
            this.showAll.Click += new System.EventHandler(this.showAll_Click);
            // 
            // showTask
            // 
            this.showTask.Name = "showTask";
            this.showTask.Size = new System.Drawing.Size(152, 22);
            this.showTask.Text = "Проверенные";
            this.showTask.Click += new System.EventHandler(this.showTask_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // watch
            // 
            this.watch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.watch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.watchTask,
            this.watchCode});
            this.watch.Image = ((System.Drawing.Image)(resources.GetObject("watch.Image")));
            this.watch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.watch.Name = "watch";
            this.watch.Size = new System.Drawing.Size(87, 22);
            this.watch.Text = "Посмотреть";
            // 
            // watchTask
            // 
            this.watchTask.Name = "watchTask";
            this.watchTask.Size = new System.Drawing.Size(160, 22);
            this.watchTask.Text = "Условие задачи";
            this.watchTask.Click += new System.EventHandler(this.watchTask_Click);
            // 
            // watchCode
            // 
            this.watchCode.Name = "watchCode";
            this.watchCode.Size = new System.Drawing.Size(160, 22);
            this.watchCode.Text = "Код работы";
            this.watchCode.Click += new System.EventHandler(this.watchCode_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // cancel
            // 
            this.cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cancel.Image = ((System.Drawing.Image)(resources.GetObject("cancel.Image")));
            this.cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(43, 22);
            this.cancel.Text = "Назад";
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // taskWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 341);
            this.Controls.Add(this.splitContainer1);
            this.Name = "taskWork";
            this.Text = "Проверка задач";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripComboBox group;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripDropDownButton check;
        private System.Windows.Forms.ToolStripMenuItem checkOneTask;
        private System.Windows.Forms.ToolStripMenuItem checkNewTask;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripButton cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton show;
        private System.Windows.Forms.ToolStripMenuItem showNew;
        private System.Windows.Forms.ToolStripMenuItem showAll;
        private System.Windows.Forms.ToolStripMenuItem showTask;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton watch;
        private System.Windows.Forms.ToolStripMenuItem watchTask;
        private System.Windows.Forms.ToolStripMenuItem watchCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}