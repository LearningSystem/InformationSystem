namespace Prepod
{
    partial class DataBlackBox
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Dgvchgvvod = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.viewEnterData = new Prepod.ViewEnterData();
            this.viewEnterDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.viewEnterDataTableAdapter = new Prepod.ViewEnterDataTableAdapters.ViewEnterDataTableAdapter();
            this.задачиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.проверкиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.значениеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.параметраDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewExitData = new Prepod.ViewExitData();
            this.viewExitDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.viewExitDataTableAdapter = new Prepod.ViewExitDataTableAdapters.ViewExitDataTableAdapter();
            this.задачиDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.проверкиDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.значениеDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.параметраDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgvchgvvod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewEnterData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewEnterDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewExitData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewExitDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(733, 395);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(725, 293);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ввод данных";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.Dgvchgvvod);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(725, 369);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Изменение";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(725, 293);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Удаление";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Dgvchgvvod
            // 
            this.Dgvchgvvod.AutoGenerateColumns = false;
            this.Dgvchgvvod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgvchgvvod.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.задачиDataGridViewTextBoxColumn,
            this.проверкиDataGridViewTextBoxColumn,
            this.значениеDataGridViewTextBoxColumn,
            this.параметраDataGridViewTextBoxColumn});
            this.Dgvchgvvod.DataSource = this.viewEnterDataBindingSource;
            this.Dgvchgvvod.Location = new System.Drawing.Point(6, 28);
            this.Dgvchgvvod.Name = "Dgvchgvvod";
            this.Dgvchgvvod.Size = new System.Drawing.Size(713, 147);
            this.Dgvchgvvod.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Входные данные:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.задачиDataGridViewTextBoxColumn1,
            this.проверкиDataGridViewTextBoxColumn1,
            this.значениеDataGridViewTextBoxColumn1,
            this.параметраDataGridViewTextBoxColumn1});
            this.dataGridView1.DataSource = this.viewExitDataBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(9, 217);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(710, 146);
            this.dataGridView1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выходные данные:";
            // 
            // viewEnterData
            // 
            this.viewEnterData.DataSetName = "ViewEnterData";
            this.viewEnterData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewEnterDataBindingSource
            // 
            this.viewEnterDataBindingSource.DataMember = "ViewEnterData";
            this.viewEnterDataBindingSource.DataSource = this.viewEnterData;
            // 
            // viewEnterDataTableAdapter
            // 
            this.viewEnterDataTableAdapter.ClearBeforeFill = true;
            // 
            // задачиDataGridViewTextBoxColumn
            // 
            this.задачиDataGridViewTextBoxColumn.DataPropertyName = "№ задачи";
            this.задачиDataGridViewTextBoxColumn.HeaderText = "№ задачи";
            this.задачиDataGridViewTextBoxColumn.Name = "задачиDataGridViewTextBoxColumn";
            // 
            // проверкиDataGridViewTextBoxColumn
            // 
            this.проверкиDataGridViewTextBoxColumn.DataPropertyName = "№ проверки";
            this.проверкиDataGridViewTextBoxColumn.HeaderText = "№ проверки";
            this.проверкиDataGridViewTextBoxColumn.Name = "проверкиDataGridViewTextBoxColumn";
            // 
            // значениеDataGridViewTextBoxColumn
            // 
            this.значениеDataGridViewTextBoxColumn.DataPropertyName = "Значение";
            this.значениеDataGridViewTextBoxColumn.HeaderText = "Значение";
            this.значениеDataGridViewTextBoxColumn.Name = "значениеDataGridViewTextBoxColumn";
            // 
            // параметраDataGridViewTextBoxColumn
            // 
            this.параметраDataGridViewTextBoxColumn.DataPropertyName = "№ параметра";
            this.параметраDataGridViewTextBoxColumn.HeaderText = "№ параметра";
            this.параметраDataGridViewTextBoxColumn.Name = "параметраDataGridViewTextBoxColumn";
            // 
            // viewExitData
            // 
            this.viewExitData.DataSetName = "ViewExitData";
            this.viewExitData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewExitDataBindingSource
            // 
            this.viewExitDataBindingSource.DataMember = "ViewExitData";
            this.viewExitDataBindingSource.DataSource = this.viewExitData;
            // 
            // viewExitDataTableAdapter
            // 
            this.viewExitDataTableAdapter.ClearBeforeFill = true;
            // 
            // задачиDataGridViewTextBoxColumn1
            // 
            this.задачиDataGridViewTextBoxColumn1.DataPropertyName = "№ задачи";
            this.задачиDataGridViewTextBoxColumn1.HeaderText = "№ задачи";
            this.задачиDataGridViewTextBoxColumn1.Name = "задачиDataGridViewTextBoxColumn1";
            // 
            // проверкиDataGridViewTextBoxColumn1
            // 
            this.проверкиDataGridViewTextBoxColumn1.DataPropertyName = "№ проверки";
            this.проверкиDataGridViewTextBoxColumn1.HeaderText = "№ проверки";
            this.проверкиDataGridViewTextBoxColumn1.Name = "проверкиDataGridViewTextBoxColumn1";
            // 
            // значениеDataGridViewTextBoxColumn1
            // 
            this.значениеDataGridViewTextBoxColumn1.DataPropertyName = "Значение";
            this.значениеDataGridViewTextBoxColumn1.HeaderText = "Значение";
            this.значениеDataGridViewTextBoxColumn1.Name = "значениеDataGridViewTextBoxColumn1";
            // 
            // параметраDataGridViewTextBoxColumn1
            // 
            this.параметраDataGridViewTextBoxColumn1.DataPropertyName = "№ параметра";
            this.параметраDataGridViewTextBoxColumn1.HeaderText = "№ параметра";
            this.параметраDataGridViewTextBoxColumn1.Name = "параметраDataGridViewTextBoxColumn1";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(570, 430);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(661, 430);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // DataBlackBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 455);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.Name = "DataBlackBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Данные для проверки";
            this.Load += new System.EventHandler(this.DataBlackBox_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgvchgvvod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewEnterData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewEnterDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewExitData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewExitDataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView Dgvchgvvod;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ViewEnterData viewEnterData;
        private System.Windows.Forms.BindingSource viewEnterDataBindingSource;
        private ViewEnterDataTableAdapters.ViewEnterDataTableAdapter viewEnterDataTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn задачиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn проверкиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn значениеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn параметраDataGridViewTextBoxColumn;
        private ViewExitData viewExitData;
        private System.Windows.Forms.BindingSource viewExitDataBindingSource;
        private ViewExitDataTableAdapters.ViewExitDataTableAdapter viewExitDataTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn задачиDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn проверкиDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn значениеDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn параметраDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
    }
}