namespace Prepod
{
    partial class studEstimates
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
            this.myEst = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tableName = new System.Windows.Forms.ToolStripComboBox();
            this.tasks = new System.Windows.Forms.DataGridView();
            this.myEst.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tasks)).BeginInit();
            this.SuspendLayout();
            // 
            // myEst
            // 
            this.myEst.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.myEst.Controls.Add(this.tabPage1);
            this.myEst.Controls.Add(this.tabPage2);
            this.myEst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myEst.Location = new System.Drawing.Point(0, 0);
            this.myEst.Multiline = true;
            this.myEst.Name = "myEst";
            this.myEst.SelectedIndex = 0;
            this.myEst.Size = new System.Drawing.Size(678, 311);
            this.myEst.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tasks);
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(670, 285);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Мои оценки";
            this.tabPage1.ToolTipText = "Мои оценки";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(670, 285);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Рейтинг";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tableName});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(664, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tableName
            // 
            this.tableName.Items.AddRange(new object[] {
            "Задачи",
            "Тесты"});
            this.tableName.Name = "tableName";
            this.tableName.Size = new System.Drawing.Size(121, 25);
            this.tableName.SelectedIndexChanged += new System.EventHandler(this.tableName_SelectedIndexChanged_1);
            // 
            // tasks
            // 
            this.tasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tasks.Location = new System.Drawing.Point(3, 28);
            this.tasks.Name = "tasks";
            this.tasks.Size = new System.Drawing.Size(664, 254);
            this.tasks.TabIndex = 2;
            // 
            // studEstimates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 311);
            this.Controls.Add(this.myEst);
            this.Name = "studEstimates";
            this.Text = "studEstimates";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.studEstimates_FormClosing);
            this.myEst.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tasks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl myEst;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView tasks;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox tableName;
        private System.Windows.Forms.TabPage tabPage2;

    }
}