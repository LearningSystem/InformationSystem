namespace Prepod
{
    partial class helpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(helpForm));
            this.rb = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.findBtn = new System.Windows.Forms.ToolStripButton();
            this.section = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rb
            // 
            this.rb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rb.Location = new System.Drawing.Point(0, 25);
            this.rb.Name = "rb";
            this.rb.Size = new System.Drawing.Size(497, 305);
            this.rb.TabIndex = 0;
            this.rb.Text = "";
            this.rb.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rb_LinkClicked);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.section,
            this.findBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(497, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // findBtn
            // 
            this.findBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            //this.findBtn.Image = ((System.Drawing.Image)(resources.GetObject("findBtn.Image")));
            this.findBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(58, 22);
            this.findBtn.Text = "Перейти";
            this.findBtn.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // section
            // 
            this.section.Name = "section";
            this.section.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(135, 22);
            this.toolStripLabel1.Text = "Введите номер раздела";
            // 
            // helpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 330);
            this.Controls.Add(this.rb);
            this.Controls.Add(this.toolStrip1);
            this.Name = "helpForm";
            this.Text = "Справка";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rb;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton findBtn;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox section;
    }
}