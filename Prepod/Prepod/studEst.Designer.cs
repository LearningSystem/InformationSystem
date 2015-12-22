namespace Prepod
{
    partial class studEst
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
            this.tasks = new System.Windows.Forms.DataGridView();
            this.tableName = new System.Windows.Forms.ToolStripComboBox();
            this.tests = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.моиОценкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.tasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tasks
            // 
            this.tasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tasks.Location = new System.Drawing.Point(0, 27);
            this.tasks.Name = "tasks";
            this.tasks.Size = new System.Drawing.Size(680, 243);
            this.tasks.TabIndex = 0;
            // 
            // tableName
            // 
            this.tableName.Items.AddRange(new object[] {
            "Задачи",
            "Тесты"});
            this.tableName.Name = "tableName";
            this.tableName.Size = new System.Drawing.Size(121, 23);
            this.tableName.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // tests
            // 
            this.tests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tests.Location = new System.Drawing.Point(0, 27);
            this.tests.Name = "tests";
            this.tests.Size = new System.Drawing.Size(680, 243);
            this.tests.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(680, 246);
            this.dataGridView1.TabIndex = 0;
            // 
            // моиОценкиToolStripMenuItem
            // 
            this.моиОценкиToolStripMenuItem.Name = "моиОценкиToolStripMenuItem";
            this.моиОценкиToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.моиОценкиToolStripMenuItem.Text = "Мои оценки";
            this.моиОценкиToolStripMenuItem.Click += new System.EventHandler(this.моиОценкиToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(322, 7);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(111, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // studEst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 382);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tests);
            this.Controls.Add(this.tasks);
            this.Name = "studEst";
            this.Text = "studEst";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.studEst_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tasks;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem рейтингToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox tableName;
        private System.Windows.Forms.DataGridView tests;
        private System.Windows.Forms.DataGridView dataGridView1;
        
        private System.Windows.Forms.ToolStripMenuItem моиОценкиToolStripMenuItem;
        
    }
}