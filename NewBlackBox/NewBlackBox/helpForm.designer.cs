namespace NewBlackBox
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
            this.rb = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rb
            // 
            this.rb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rb.Location = new System.Drawing.Point(0, 0);
            this.rb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rb.Name = "rb";
            this.rb.ReadOnly = true;
            this.rb.Size = new System.Drawing.Size(663, 406);
            this.rb.TabIndex = 0;
            this.rb.Text = "";
            this.rb.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rb_LinkClicked);
            // 
            // helpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 406);
            this.Controls.Add(this.rb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "helpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справка";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rb;
    }
}