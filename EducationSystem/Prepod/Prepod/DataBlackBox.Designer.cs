﻿namespace Prepod
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gBText = new System.Windows.Forms.GroupBox();
            this.rTBText1 = new System.Windows.Forms.RichTextBox();
            this.gBSelect = new System.Windows.Forms.GroupBox();
            this.cmBTest = new System.Windows.Forms.ComboBox();
            this.lblnumTest = new System.Windows.Forms.Label();
            this.cmBExer = new System.Windows.Forms.ComboBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.gBData = new System.Windows.Forms.GroupBox();
            this.dGVData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenMenu = new System.Windows.Forms.MenuStrip();
            this.oToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видИзмененияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вводДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменениеДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалениеДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gBText.SuspendLayout();
            this.gBSelect.SuspendLayout();
            this.gBData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVData)).BeginInit();
            this.GenMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1028, 533);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gBText);
            this.tabPage1.Controls.Add(this.gBSelect);
            this.tabPage1.Controls.Add(this.gBData);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1020, 504);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Основная вкладка";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gBText
            // 
            this.gBText.Controls.Add(this.rTBText1);
            this.gBText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBText.Location = new System.Drawing.Point(4, 99);
            this.gBText.Margin = new System.Windows.Forms.Padding(4);
            this.gBText.Name = "gBText";
            this.gBText.Padding = new System.Windows.Forms.Padding(4);
            this.gBText.Size = new System.Drawing.Size(453, 401);
            this.gBText.TabIndex = 8;
            this.gBText.TabStop = false;
            this.gBText.Text = "Текст задачи:";
            // 
            // rTBText1
            // 
            this.rTBText1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTBText1.Location = new System.Drawing.Point(4, 20);
            this.rTBText1.Margin = new System.Windows.Forms.Padding(4);
            this.rTBText1.Name = "rTBText1";
            this.rTBText1.ReadOnly = true;
            this.rTBText1.Size = new System.Drawing.Size(445, 377);
            this.rTBText1.TabIndex = 3;
            this.rTBText1.Text = "";
            // 
            // gBSelect
            // 
            this.gBSelect.Controls.Add(this.cmBTest);
            this.gBSelect.Controls.Add(this.lblnumTest);
            this.gBSelect.Controls.Add(this.cmBExer);
            this.gBSelect.Controls.Add(this.lbl1);
            this.gBSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBSelect.Location = new System.Drawing.Point(4, 4);
            this.gBSelect.Margin = new System.Windows.Forms.Padding(4);
            this.gBSelect.Name = "gBSelect";
            this.gBSelect.Padding = new System.Windows.Forms.Padding(4);
            this.gBSelect.Size = new System.Drawing.Size(453, 95);
            this.gBSelect.TabIndex = 7;
            this.gBSelect.TabStop = false;
            this.gBSelect.Text = "Выбор";
            // 
            // cmBTest
            // 
            this.cmBTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBTest.FormattingEnabled = true;
            this.cmBTest.Location = new System.Drawing.Point(264, 53);
            this.cmBTest.Margin = new System.Windows.Forms.Padding(4);
            this.cmBTest.Name = "cmBTest";
            this.cmBTest.Size = new System.Drawing.Size(160, 24);
            this.cmBTest.TabIndex = 6;
            this.cmBTest.SelectedIndexChanged += new System.EventHandler(this.cmBTest_SelectedIndexChanged);
            // 
            // lblnumTest
            // 
            this.lblnumTest.AutoSize = true;
            this.lblnumTest.Location = new System.Drawing.Point(260, 24);
            this.lblnumTest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnumTest.Name = "lblnumTest";
            this.lblnumTest.Size = new System.Drawing.Size(137, 17);
            this.lblnumTest.TabIndex = 5;
            this.lblnumTest.Text = "Выберите № теста:";
            // 
            // cmBExer
            // 
            this.cmBExer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBExer.FormattingEnabled = true;
            this.cmBExer.Location = new System.Drawing.Point(16, 53);
            this.cmBExer.Margin = new System.Windows.Forms.Padding(4);
            this.cmBExer.Name = "cmBExer";
            this.cmBExer.Size = new System.Drawing.Size(160, 24);
            this.cmBExer.TabIndex = 0;
            this.cmBExer.SelectedIndexChanged += new System.EventHandler(this.cmBExer_SelectedIndexChanged);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(13, 24);
            this.lbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(127, 17);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "Название задачи:";
            // 
            // gBData
            // 
            this.gBData.Controls.Add(this.dGVData);
            this.gBData.Dock = System.Windows.Forms.DockStyle.Right;
            this.gBData.Location = new System.Drawing.Point(457, 4);
            this.gBData.Margin = new System.Windows.Forms.Padding(4);
            this.gBData.Name = "gBData";
            this.gBData.Padding = new System.Windows.Forms.Padding(4);
            this.gBData.Size = new System.Drawing.Size(559, 496);
            this.gBData.TabIndex = 4;
            this.gBData.TabStop = false;
            this.gBData.Text = "Данные:";
            // 
            // dGVData
            // 
            this.dGVData.AllowUserToAddRows = false;
            this.dGVData.AllowUserToDeleteRows = false;
            this.dGVData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dGVData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVData.Location = new System.Drawing.Point(4, 20);
            this.dGVData.Margin = new System.Windows.Forms.Padding(4);
            this.dGVData.Name = "dGVData";
            this.dGVData.ReadOnly = true;
            this.dGVData.Size = new System.Drawing.Size(551, 472);
            this.dGVData.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Входные данные";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Выходные данные";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // GenMenu
            // 
            this.GenMenu.BackColor = System.Drawing.Color.LightBlue;
            this.GenMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oToolStripMenuItem,
            this.выходToolStripMenuItem,
            this.видИзмененияToolStripMenuItem});
            this.GenMenu.Location = new System.Drawing.Point(0, 0);
            this.GenMenu.Name = "GenMenu";
            this.GenMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.GenMenu.Size = new System.Drawing.Size(1028, 27);
            this.GenMenu.TabIndex = 4;
            this.GenMenu.Text = "menuStrip2";
            // 
            // oToolStripMenuItem
            // 
            this.oToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.oToolStripMenuItem.Name = "oToolStripMenuItem";
            this.oToolStripMenuItem.Size = new System.Drawing.Size(197, 23);
            this.oToolStripMenuItem.Text = "| Загрузить тесты из файла |";
            this.oToolStripMenuItem.Click += new System.EventHandler(this.oToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // видИзмененияToolStripMenuItem
            // 
            this.видИзмененияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вводДанныхToolStripMenuItem,
            this.изменениеДанныхToolStripMenuItem,
            this.удалениеДанныхToolStripMenuItem});
            this.видИзмененияToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.видИзмененияToolStripMenuItem.Name = "видИзмененияToolStripMenuItem";
            this.видИзмененияToolStripMenuItem.Size = new System.Drawing.Size(167, 23);
            this.видИзмененияToolStripMenuItem.Text = "| Действие с данными |";
            // 
            // вводДанныхToolStripMenuItem
            // 
            this.вводДанныхToolStripMenuItem.Name = "вводДанныхToolStripMenuItem";
            this.вводДанныхToolStripMenuItem.Size = new System.Drawing.Size(266, 24);
            this.вводДанныхToolStripMenuItem.Text = "Ввод нового теста";
            this.вводДанныхToolStripMenuItem.Click += new System.EventHandler(this.вводДанныхToolStripMenuItem_Click);
            // 
            // изменениеДанныхToolStripMenuItem
            // 
            this.изменениеДанныхToolStripMenuItem.Name = "изменениеДанныхToolStripMenuItem";
            this.изменениеДанныхToolStripMenuItem.Size = new System.Drawing.Size(266, 24);
            this.изменениеДанныхToolStripMenuItem.Text = "Изменение выбранного теста";
            this.изменениеДанныхToolStripMenuItem.Click += new System.EventHandler(this.изменениеДанныхToolStripMenuItem_Click);
            // 
            // удалениеДанныхToolStripMenuItem
            // 
            this.удалениеДанныхToolStripMenuItem.Name = "удалениеДанныхToolStripMenuItem";
            this.удалениеДанныхToolStripMenuItem.Size = new System.Drawing.Size(266, 24);
            this.удалениеДанныхToolStripMenuItem.Text = "Удаление выбранного теста";
            this.удалениеДанныхToolStripMenuItem.Click += new System.EventHandler(this.удалениеДанныхToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1Collapsed = true;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1028, 533);
            this.splitContainer1.SplitterDistance = 288;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 5;
            // 
            // DataBlackBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 560);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.GenMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DataBlackBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Данные для проверки";
            this.Load += new System.EventHandler(this.DataBlackBox_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gBText.ResumeLayout(false);
            this.gBSelect.ResumeLayout(false);
            this.gBSelect.PerformLayout();
            this.gBData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVData)).EndInit();
            this.GenMenu.ResumeLayout(false);
            this.GenMenu.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.MenuStrip GenMenu;
        private System.Windows.Forms.ToolStripMenuItem oToolStripMenuItem;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ComboBox cmBExer;
        private System.Windows.Forms.RichTextBox rTBText1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cmBTest;
        private System.Windows.Forms.Label lblnumTest;
        private System.Windows.Forms.GroupBox gBData;
        private System.Windows.Forms.DataGridView dGVData;
        private System.Windows.Forms.ToolStripMenuItem видИзмененияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вводДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменениеДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалениеДанныхToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gBSelect;
        private System.Windows.Forms.GroupBox gBText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}