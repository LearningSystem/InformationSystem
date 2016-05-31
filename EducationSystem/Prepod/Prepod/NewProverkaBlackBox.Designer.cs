namespace Prepod
{
    partial class NewProverkaBlackBox
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
            this.gB = new System.Windows.Forms.GroupBox();
            this.dgvGeneral = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneral)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gB
            // 
            this.gB.Controls.Add(this.dgvGeneral);
            this.gB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gB.Location = new System.Drawing.Point(0, 27);
            this.gB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gB.Name = "gB";
            this.gB.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gB.Size = new System.Drawing.Size(531, 417);
            this.gB.TabIndex = 0;
            this.gB.TabStop = false;
            this.gB.Text = "Ввод данных:";
            // 
            // dgvGeneral
            // 
            this.dgvGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGeneral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGeneral.Location = new System.Drawing.Point(4, 20);
            this.dgvGeneral.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvGeneral.Name = "dgvGeneral";
            this.dgvGeneral.Size = new System.Drawing.Size(523, 393);
            this.dgvGeneral.TabIndex = 0;
            this.dgvGeneral.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGeneral_CellContentClick);
            this.dgvGeneral.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvGeneral_RowsAdded);
            this.dgvGeneral.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvGeneral_RowsRemoved);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Входные данные";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Выходные данные";
            this.Column2.Name = "Column2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(531, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem1,
            this.очиститьToolStripMenuItem});
            this.сохранитьToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(60, 23);
            this.сохранитьToolStripMenuItem.Text = "Меню";
            // 
            // сохранитьToolStripMenuItem1
            // 
            this.сохранитьToolStripMenuItem1.Name = "сохранитьToolStripMenuItem1";
            this.сохранитьToolStripMenuItem1.Size = new System.Drawing.Size(152, 24);
            this.сохранитьToolStripMenuItem1.Text = "Сохранить";
            this.сохранитьToolStripMenuItem1.Click += new System.EventHandler(this.сохранитьToolStripMenuItem1_Click);
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.очиститьToolStripMenuItem.Text = "Очистить";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // NewProverkaBlackBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 444);
            this.Controls.Add(this.gB);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "NewProverkaBlackBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание новой проверки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewProverkaBlackBox_FormClosing);
            this.Load += new System.EventHandler(this.NewProverkaBlackBox_Load);
            this.gB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneral)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gB;
        private System.Windows.Forms.DataGridView dgvGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
    }
}