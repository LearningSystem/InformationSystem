namespace Prepod
{
    partial class GeneratorWorkData
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radBtn1 = new System.Windows.Forms.RadioButton();
            this.radBtn2 = new System.Windows.Forms.RadioButton();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.radBtn3 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(288, 239);
            this.splitContainer1.SplitterDistance = 108;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radBtn3);
            this.groupBox1.Controls.Add(this.btnPrev);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.radBtn2);
            this.groupBox1.Controls.Add(this.radBtn1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(288, 239);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Хочу настроить:";
            // 
            // radBtn1
            // 
            this.radBtn1.AutoSize = true;
            this.radBtn1.Location = new System.Drawing.Point(12, 37);
            this.radBtn1.Name = "radBtn1";
            this.radBtn1.Size = new System.Drawing.Size(83, 21);
            this.radBtn1.TabIndex = 0;
            this.radBtn1.TabStop = true;
            this.radBtn1.Text = "Понятия";
            this.radBtn1.UseVisualStyleBackColor = true;
            // 
            // radBtn2
            // 
            this.radBtn2.AutoSize = true;
            this.radBtn2.Location = new System.Drawing.Point(12, 94);
            this.radBtn2.Name = "radBtn2";
            this.radBtn2.Size = new System.Drawing.Size(78, 21);
            this.radBtn2.TabIndex = 1;
            this.radBtn2.TabStop = true;
            this.radBtn2.Text = "Методы";
            this.radBtn2.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(201, 201);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 26);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Далее";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(7, 201);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 26);
            this.btnPrev.TabIndex = 4;
            this.btnPrev.Text = "Назад";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // radBtn3
            // 
            this.radBtn3.AutoSize = true;
            this.radBtn3.Location = new System.Drawing.Point(12, 150);
            this.radBtn3.Name = "radBtn3";
            this.radBtn3.Size = new System.Drawing.Size(87, 21);
            this.radBtn3.TabIndex = 5;
            this.radBtn3.TabStop = true;
            this.radBtn3.Text = "Шаблоны";
            this.radBtn3.UseVisualStyleBackColor = true;
            // 
            // GeneratorWorkData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 239);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GeneratorWorkData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Работа с данными";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.RadioButton radBtn2;
        private System.Windows.Forms.RadioButton radBtn1;
        private System.Windows.Forms.RadioButton radBtn3;
    }
}