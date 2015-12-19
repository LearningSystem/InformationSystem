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
<<<<<<< HEAD
            this.tasks = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.рейтингToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableName = new System.Windows.Forms.ToolStripComboBox();
            this.tests = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tasks)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tests)).BeginInit();
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
=======
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.моиОценкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рейтингToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(680, 246);
            this.dataGridView1.TabIndex = 0;
>>>>>>> d5f74ac7cb74f2aa2d0a722db7b10ad320858850
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
<<<<<<< HEAD
            this.tableName,
            this.рейтингToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(680, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // рейтингToolStripMenuItem
            // 
            this.рейтингToolStripMenuItem.Name = "рейтингToolStripMenuItem";
            this.рейтингToolStripMenuItem.Size = new System.Drawing.Size(63, 23);
            this.рейтингToolStripMenuItem.Text = "Рейтинг";
            this.рейтингToolStripMenuItem.Click += new System.EventHandler(this.рейтингToolStripMenuItem_Click);
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
=======
            this.моиОценкиToolStripMenuItem,
            this.рейтингToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(680, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // моиОценкиToolStripMenuItem
            // 
            this.моиОценкиToolStripMenuItem.Name = "моиОценкиToolStripMenuItem";
            this.моиОценкиToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.моиОценкиToolStripMenuItem.Text = "Мои оценки";
            this.моиОценкиToolStripMenuItem.Click += new System.EventHandler(this.моиОценкиToolStripMenuItem_Click);
            // 
            // рейтингToolStripMenuItem
            // 
            this.рейтингToolStripMenuItem.Name = "рейтингToolStripMenuItem";
            this.рейтингToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.рейтингToolStripMenuItem.Text = "Рейтинг";
            this.рейтингToolStripMenuItem.Click += new System.EventHandler(this.рейтингToolStripMenuItem_Click);
            // 
>>>>>>> d5f74ac7cb74f2aa2d0a722db7b10ad320858850
            // studEst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 270);
<<<<<<< HEAD
            this.Controls.Add(this.tests);
            this.Controls.Add(this.tasks);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "studEst";
            this.Text = "Успеваемость";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.studEst_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tasks)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tests)).EndInit();
=======
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "studEst";
            this.Text = "studEst";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.studEst_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
>>>>>>> d5f74ac7cb74f2aa2d0a722db7b10ad320858850
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

<<<<<<< HEAD
        private System.Windows.Forms.DataGridView tasks;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem рейтингToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox tableName;
        private System.Windows.Forms.DataGridView tests;
=======
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem моиОценкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рейтингToolStripMenuItem;
>>>>>>> d5f74ac7cb74f2aa2d0a722db7b10ad320858850
    }
}