namespace Prepod
{
    partial class GeneratorTwo
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
            this.gBNew = new System.Windows.Forms.GroupBox();
            this.lstMetod = new System.Windows.Forms.ListView();
            this.gBParameters = new System.Windows.Forms.GroupBox();
            this.dGVParameters = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.назадToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.методыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.впередToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gBNew.SuspendLayout();
            this.gBParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVParameters)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gBNew);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gBParameters);
            this.splitContainer1.Size = new System.Drawing.Size(844, 423);
            this.splitContainer1.SplitterDistance = 301;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // gBNew
            // 
            this.gBNew.Controls.Add(this.lstMetod);
            this.gBNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBNew.Location = new System.Drawing.Point(0, 0);
            this.gBNew.Margin = new System.Windows.Forms.Padding(4);
            this.gBNew.Name = "gBNew";
            this.gBNew.Padding = new System.Windows.Forms.Padding(4);
            this.gBNew.Size = new System.Drawing.Size(301, 423);
            this.gBNew.TabIndex = 0;
            this.gBNew.TabStop = false;
            this.gBNew.Text = "Методы:";
            // 
            // lstMetod
            // 
            this.lstMetod.CheckBoxes = true;
            this.lstMetod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMetod.Location = new System.Drawing.Point(4, 20);
            this.lstMetod.Margin = new System.Windows.Forms.Padding(4);
            this.lstMetod.Name = "lstMetod";
            this.lstMetod.Size = new System.Drawing.Size(293, 399);
            this.lstMetod.TabIndex = 0;
            this.lstMetod.UseCompatibleStateImageBehavior = false;
            this.lstMetod.View = System.Windows.Forms.View.List;
            this.lstMetod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstMetod_KeyDown);
            this.lstMetod.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstMetod_MouseDoubleClick);
            // 
            // gBParameters
            // 
            this.gBParameters.Controls.Add(this.dGVParameters);
            this.gBParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBParameters.Location = new System.Drawing.Point(0, 0);
            this.gBParameters.Margin = new System.Windows.Forms.Padding(4);
            this.gBParameters.Name = "gBParameters";
            this.gBParameters.Padding = new System.Windows.Forms.Padding(4);
            this.gBParameters.Size = new System.Drawing.Size(538, 423);
            this.gBParameters.TabIndex = 0;
            this.gBParameters.TabStop = false;
            this.gBParameters.Text = "Параметры:";
            // 
            // dGVParameters
            // 
            this.dGVParameters.AllowUserToAddRows = false;
            this.dGVParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dGVParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVParameters.Location = new System.Drawing.Point(4, 20);
            this.dGVParameters.Margin = new System.Windows.Forms.Padding(4);
            this.dGVParameters.Name = "dGVParameters";
            this.dGVParameters.Size = new System.Drawing.Size(530, 399);
            this.dGVParameters.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Входные";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Выходные";
            this.Column2.Name = "Column2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.назадToolStripMenuItem,
            this.редактированиеToolStripMenuItem,
            this.впередToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(844, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // назадToolStripMenuItem
            // 
            this.назадToolStripMenuItem.Name = "назадToolStripMenuItem";
            this.назадToolStripMenuItem.Size = new System.Drawing.Size(73, 23);
            this.назадToolStripMenuItem.Text = "| Назад |";
            this.назадToolStripMenuItem.Click += new System.EventHandler(this.назадToolStripMenuItem_Click);
            // 
            // редактированиеToolStripMenuItem
            // 
            this.редактированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.методыToolStripMenuItem});
            this.редактированиеToolStripMenuItem.Name = "редактированиеToolStripMenuItem";
            this.редактированиеToolStripMenuItem.Size = new System.Drawing.Size(139, 23);
            this.редактированиеToolStripMenuItem.Text = "| Редактирование |";
            // 
            // методыToolStripMenuItem
            // 
            this.методыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.методыToolStripMenuItem.Name = "методыToolStripMenuItem";
            this.методыToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
            this.методыToolStripMenuItem.Text = "Методы";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // впередToolStripMenuItem
            // 
            this.впередToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.впередToolStripMenuItem.Name = "впередToolStripMenuItem";
            this.впередToolStripMenuItem.Size = new System.Drawing.Size(81, 23);
            this.впередToolStripMenuItem.Text = "| Вперед |";
            this.впередToolStripMenuItem.Click += new System.EventHandler(this.впередToolStripMenuItem_Click);
            // 
            // GeneratorTwo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GeneratorTwo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Генератор. Шаг второй. Методы и параметры";
            this.Load += new System.EventHandler(this.GeneratorTwo_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gBNew.ResumeLayout(false);
            this.gBParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVParameters)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gBParameters;
        private System.Windows.Forms.DataGridView dGVParameters;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox gBNew;
        private System.Windows.Forms.ListView lstMetod;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem редактированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem методыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem назадToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem впередToolStripMenuItem;
    }
}