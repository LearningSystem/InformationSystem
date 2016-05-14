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
            this.gBSettings = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSaveOne = new System.Windows.Forms.Button();
            this.dgvGeneral = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gB.SuspendLayout();
            this.gBSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // gB
            // 
            this.gB.Controls.Add(this.gBSettings);
            this.gB.Controls.Add(this.dgvGeneral);
            this.gB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gB.Location = new System.Drawing.Point(0, 0);
            this.gB.Name = "gB";
            this.gB.Size = new System.Drawing.Size(587, 361);
            this.gB.TabIndex = 0;
            this.gB.TabStop = false;
            this.gB.Text = "Ввод данных:";
            // 
            // gBSettings
            // 
            this.gBSettings.Controls.Add(this.btnClear);
            this.gBSettings.Controls.Add(this.btnSaveOne);
            this.gBSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.gBSettings.Location = new System.Drawing.Point(384, 16);
            this.gBSettings.Name = "gBSettings";
            this.gBSettings.Size = new System.Drawing.Size(200, 342);
            this.gBSettings.TabIndex = 1;
            this.gBSettings.TabStop = false;
            this.gBSettings.Text = "Действия:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(24, 176);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(153, 36);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSaveOne
            // 
            this.btnSaveOne.Location = new System.Drawing.Point(24, 125);
            this.btnSaveOne.Name = "btnSaveOne";
            this.btnSaveOne.Size = new System.Drawing.Size(153, 36);
            this.btnSaveOne.TabIndex = 0;
            this.btnSaveOne.Text = "Сохранить";
            this.btnSaveOne.UseVisualStyleBackColor = true;
            this.btnSaveOne.Click += new System.EventHandler(this.btnSaveOne_Click);
            // 
            // dgvGeneral
            // 
            this.dgvGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGeneral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvGeneral.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvGeneral.Location = new System.Drawing.Point(3, 16);
            this.dgvGeneral.Name = "dgvGeneral";
            this.dgvGeneral.Size = new System.Drawing.Size(373, 342);
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
            // NewProverkaBlackBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 361);
            this.Controls.Add(this.gB);
            this.Name = "NewProverkaBlackBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание новой проверки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewProverkaBlackBox_FormClosing);
            this.Load += new System.EventHandler(this.NewProverkaBlackBox_Load);
            this.gB.ResumeLayout(false);
            this.gBSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneral)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gB;
        private System.Windows.Forms.DataGridView dgvGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox gBSettings;
        private System.Windows.Forms.Button btnSaveOne;
        private System.Windows.Forms.Button btnClear;
    }
}