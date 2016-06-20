namespace Prepod
{
    partial class GeneratorOne
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
            this.gBCreate = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.txtBoxPon = new System.Windows.Forms.TextBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.cmBSchablon = new System.Windows.Forms.ComboBox();
            this.tabContr = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rTBText = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lstPon = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.работаСДаннымиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gBCreate.SuspendLayout();
            this.tabContr.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.gBCreate);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabContr);
            this.splitContainer1.Size = new System.Drawing.Size(851, 467);
            this.splitContainer1.SplitterDistance = 310;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // gBCreate
            // 
            this.gBCreate.Controls.Add(this.label1);
            this.gBCreate.Controls.Add(this.btnNext);
            this.gBCreate.Controls.Add(this.lbl2);
            this.gBCreate.Controls.Add(this.lbl1);
            this.gBCreate.Controls.Add(this.txtBoxPon);
            this.gBCreate.Controls.Add(this.btnPrev);
            this.gBCreate.Controls.Add(this.cmBSchablon);
            this.gBCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBCreate.Location = new System.Drawing.Point(0, 0);
            this.gBCreate.Margin = new System.Windows.Forms.Padding(4);
            this.gBCreate.Name = "gBCreate";
            this.gBCreate.Padding = new System.Windows.Forms.Padding(4);
            this.gBCreate.Size = new System.Drawing.Size(310, 467);
            this.gBCreate.TabIndex = 0;
            this.gBCreate.TabStop = false;
            this.gBCreate.Text = "Старт";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(75, 230);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 75);
            this.label1.TabIndex = 6;
            this.label1.Text = "Есть ли сходные понятия? Если да, то выделите их в списке созданных понятий.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(93, 390);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 28);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Далее";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(57, 149);
            this.lbl2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(69, 17);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "Понятие:";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(57, 68);
            this.lbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(118, 17);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Выбор шаблона:";
            // 
            // txtBoxPon
            // 
            this.txtBoxPon.Location = new System.Drawing.Point(61, 181);
            this.txtBoxPon.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxPon.Name = "txtBoxPon";
            this.txtBoxPon.Size = new System.Drawing.Size(184, 23);
            this.txtBoxPon.TabIndex = 3;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(93, 338);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(100, 28);
            this.btnPrev.TabIndex = 4;
            this.btnPrev.Text = "Назад";
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // cmBSchablon
            // 
            this.cmBSchablon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBSchablon.FormattingEnabled = true;
            this.cmBSchablon.Location = new System.Drawing.Point(61, 101);
            this.cmBSchablon.Margin = new System.Windows.Forms.Padding(4);
            this.cmBSchablon.Name = "cmBSchablon";
            this.cmBSchablon.Size = new System.Drawing.Size(184, 24);
            this.cmBSchablon.TabIndex = 1;
            this.cmBSchablon.SelectedIndexChanged += new System.EventHandler(this.cmBSchablon_SelectedIndexChanged);
            // 
            // tabContr
            // 
            this.tabContr.Controls.Add(this.tabPage1);
            this.tabContr.Controls.Add(this.tabPage3);
            this.tabContr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContr.Location = new System.Drawing.Point(0, 0);
            this.tabContr.Margin = new System.Windows.Forms.Padding(4);
            this.tabContr.Name = "tabContr";
            this.tabContr.SelectedIndex = 0;
            this.tabContr.Size = new System.Drawing.Size(536, 467);
            this.tabContr.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rTBText);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(528, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Текст шаблона";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rTBText
            // 
            this.rTBText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTBText.Location = new System.Drawing.Point(4, 4);
            this.rTBText.Margin = new System.Windows.Forms.Padding(4);
            this.rTBText.Name = "rTBText";
            this.rTBText.Size = new System.Drawing.Size(520, 430);
            this.rTBText.TabIndex = 0;
            this.rTBText.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lstPon);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(528, 438);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Список созданных понятий";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lstPon
            // 
            this.lstPon.CheckBoxes = true;
            this.lstPon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPon.Location = new System.Drawing.Point(0, 0);
            this.lstPon.Margin = new System.Windows.Forms.Padding(4);
            this.lstPon.Name = "lstPon";
            this.lstPon.Size = new System.Drawing.Size(528, 438);
            this.lstPon.TabIndex = 0;
            this.lstPon.UseCompatibleStateImageBehavior = false;
            this.lstPon.View = System.Windows.Forms.View.List;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.работаСДаннымиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(851, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // работаСДаннымиToolStripMenuItem
            // 
            this.работаСДаннымиToolStripMenuItem.Name = "работаСДаннымиToolStripMenuItem";
            this.работаСДаннымиToolStripMenuItem.Size = new System.Drawing.Size(227, 23);
            this.работаСДаннымиToolStripMenuItem.Text = "| Работа с данными генератора |";
            this.работаСДаннымиToolStripMenuItem.Click += new System.EventHandler(this.работаСДаннымиToolStripMenuItem_Click);
            // 
            // GeneratorOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 494);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GeneratorOne";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Генератор. Шаг первый. Старт";
            this.Load += new System.EventHandler(this.GeneratorOne_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gBCreate.ResumeLayout(false);
            this.gBCreate.PerformLayout();
            this.tabContr.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gBCreate;
        private System.Windows.Forms.TextBox txtBoxPon;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.ComboBox cmBSchablon;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TabControl tabContr;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.RichTextBox rTBText;
        private System.Windows.Forms.ListView lstPon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem работаСДаннымиToolStripMenuItem;

    }
}