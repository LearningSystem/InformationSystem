namespace Prepod
{
    partial class WarningPass
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
            this.lblPresent = new System.Windows.Forms.Label();
            this.lblWarn = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.GeneralTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblPresent
            // 
            this.lblPresent.AutoSize = true;
            this.lblPresent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPresent.Location = new System.Drawing.Point(101, 25);
            this.lblPresent.Name = "lblPresent";
            this.lblPresent.Size = new System.Drawing.Size(169, 15);
            this.lblPresent.TabIndex = 0;
            this.lblPresent.Text = "Уважаемый пользователь! ";
            // 
            // lblWarn
            // 
            this.lblWarn.AutoSize = true;
            this.lblWarn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWarn.Location = new System.Drawing.Point(12, 58);
            this.lblWarn.Name = "lblWarn";
            this.lblWarn.Size = new System.Drawing.Size(367, 15);
            this.lblWarn.TabIndex = 1;
            this.lblWarn.Text = "У вас стоит стандартный пароль. Для безопасности смените";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl2.Location = new System.Drawing.Point(12, 89);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(343, 15);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "его на другой. Это можно сделать в разделе \"Настройки\".";
            // 
            // GeneralTimer
            // 
            this.GeneralTimer.Interval = 10;
            this.GeneralTimer.Tick += new System.EventHandler(this.GeneralTimer_Tick);
            // 
            // WarningPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(390, 151);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lblWarn);
            this.Controls.Add(this.lblPresent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WarningPass";
            this.Opacity = 0D;
            this.Text = "ChangePassword";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChangePassword_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPresent;
        private System.Windows.Forms.Label lblWarn;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Timer GeneralTimer;
    }
}