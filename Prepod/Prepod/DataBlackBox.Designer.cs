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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmBTest = new System.Windows.Forms.ComboBox();
            this.lblnumTest = new System.Windows.Forms.Label();
            this.gBData = new System.Windows.Forms.GroupBox();
            this.dGVData = new System.Windows.Forms.DataGridView();
            this.rTBText1 = new System.Windows.Forms.RichTextBox();
            this.lblExerText = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.cmBExer = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.GenMenu = new System.Windows.Forms.MenuStrip();
            this.oToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видИзмененияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вводДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменениеДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалениеДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gBData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVData)).BeginInit();
            this.GenMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(850, 395);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmBTest);
            this.tabPage1.Controls.Add(this.lblnumTest);
            this.tabPage1.Controls.Add(this.gBData);
            this.tabPage1.Controls.Add(this.rTBText1);
            this.tabPage1.Controls.Add(this.lblExerText);
            this.tabPage1.Controls.Add(this.lbl1);
            this.tabPage1.Controls.Add(this.cmBExer);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(842, 369);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Основная вкладка";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmBTest
            // 
            this.cmBTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBTest.FormattingEnabled = true;
            this.cmBTest.Location = new System.Drawing.Point(192, 40);
            this.cmBTest.Name = "cmBTest";
            this.cmBTest.Size = new System.Drawing.Size(121, 21);
            this.cmBTest.TabIndex = 6;
            this.cmBTest.SelectedIndexChanged += new System.EventHandler(this.cmBTest_SelectedIndexChanged);
            // 
            // lblnumTest
            // 
            this.lblnumTest.AutoSize = true;
            this.lblnumTest.Location = new System.Drawing.Point(189, 14);
            this.lblnumTest.Name = "lblnumTest";
            this.lblnumTest.Size = new System.Drawing.Size(105, 13);
            this.lblnumTest.TabIndex = 5;
            this.lblnumTest.Text = "Выберите № теста:";
            // 
            // gBData
            // 
            this.gBData.Controls.Add(this.dGVData);
            this.gBData.Location = new System.Drawing.Point(330, 14);
            this.gBData.Name = "gBData";
            this.gBData.Size = new System.Drawing.Size(512, 349);
            this.gBData.TabIndex = 4;
            this.gBData.TabStop = false;
            this.gBData.Text = "Данные:";
            // 
            // dGVData
            // 
            this.dGVData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVData.Location = new System.Drawing.Point(3, 16);
            this.dGVData.Name = "dGVData";
            this.dGVData.Size = new System.Drawing.Size(506, 327);
            this.dGVData.TabIndex = 0;
            // 
            // rTBText1
            // 
            this.rTBText1.Location = new System.Drawing.Point(3, 112);
            this.rTBText1.Name = "rTBText1";
            this.rTBText1.Size = new System.Drawing.Size(321, 251);
            this.rTBText1.TabIndex = 3;
            this.rTBText1.Text = "";
            // 
            // lblExerText
            // 
            this.lblExerText.AutoSize = true;
            this.lblExerText.Location = new System.Drawing.Point(6, 86);
            this.lblExerText.Name = "lblExerText";
            this.lblExerText.Size = new System.Drawing.Size(78, 13);
            this.lblExerText.TabIndex = 2;
            this.lblExerText.Text = "Текст задачи:";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(6, 14);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(59, 13);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "№ задачи:";
            // 
            // cmBExer
            // 
            this.cmBExer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBExer.FormattingEnabled = true;
            this.cmBExer.Location = new System.Drawing.Point(6, 40);
            this.cmBExer.Name = "cmBExer";
            this.cmBExer.Size = new System.Drawing.Size(121, 21);
            this.cmBExer.TabIndex = 0;
            this.cmBExer.SelectedIndexChanged += new System.EventHandler(this.cmBExer_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(683, 430);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(774, 430);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Назад";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // GenMenu
            // 
            this.GenMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oToolStripMenuItem,
            this.выходToolStripMenuItem,
            this.видИзмененияToolStripMenuItem});
            this.GenMenu.Location = new System.Drawing.Point(0, 0);
            this.GenMenu.Name = "GenMenu";
            this.GenMenu.Size = new System.Drawing.Size(865, 24);
            this.GenMenu.TabIndex = 4;
            this.GenMenu.Text = "menuStrip2";
            // 
            // oToolStripMenuItem
            // 
            this.oToolStripMenuItem.Name = "oToolStripMenuItem";
            this.oToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.oToolStripMenuItem.Text = "Загрузить из файла";
            this.oToolStripMenuItem.Click += new System.EventHandler(this.oToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // видИзмененияToolStripMenuItem
            // 
            this.видИзмененияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вводДанныхToolStripMenuItem,
            this.изменениеДанныхToolStripMenuItem,
            this.удалениеДанныхToolStripMenuItem});
            this.видИзмененияToolStripMenuItem.Name = "видИзмененияToolStripMenuItem";
            this.видИзмененияToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.видИзмененияToolStripMenuItem.Text = "Действие с данными";
            // 
            // вводДанныхToolStripMenuItem
            // 
            this.вводДанныхToolStripMenuItem.Name = "вводДанныхToolStripMenuItem";
            this.вводДанныхToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.вводДанныхToolStripMenuItem.Text = "Ввод нового теста";
            // 
            // изменениеДанныхToolStripMenuItem
            // 
            this.изменениеДанныхToolStripMenuItem.Name = "изменениеДанныхToolStripMenuItem";
            this.изменениеДанныхToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.изменениеДанныхToolStripMenuItem.Text = "Изменение";
            this.изменениеДанныхToolStripMenuItem.Click += new System.EventHandler(this.изменениеДанныхToolStripMenuItem_Click);
            // 
            // удалениеДанныхToolStripMenuItem
            // 
            this.удалениеДанныхToolStripMenuItem.Name = "удалениеДанныхToolStripMenuItem";
            this.удалениеДанныхToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.удалениеДанныхToolStripMenuItem.Text = "Удаление";
            this.удалениеДанныхToolStripMenuItem.Click += new System.EventHandler(this.удалениеДанныхToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // DataBlackBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 455);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.GenMenu);
            this.Name = "DataBlackBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Данные для проверки";
            this.Load += new System.EventHandler(this.DataBlackBox_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gBData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVData)).EndInit();
            this.GenMenu.ResumeLayout(false);
            this.GenMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.MenuStrip GenMenu;
        private System.Windows.Forms.ToolStripMenuItem oToolStripMenuItem;
        private System.Windows.Forms.Label lblExerText;
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
    }
}