namespace Prepod
{
    partial class ChangePass
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
            this.gBGeneral = new System.Windows.Forms.GroupBox();
            this.lblTek = new System.Windows.Forms.Label();
            this.TekRtB = new System.Windows.Forms.TextBox();
            this.lblNew = new System.Windows.Forms.Label();
            this.NewRtB = new System.Windows.Forms.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.gBGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBGeneral
            // 
            this.gBGeneral.Controls.Add(this.lblError);
            this.gBGeneral.Controls.Add(this.btnChange);
            this.gBGeneral.Controls.Add(this.NewRtB);
            this.gBGeneral.Controls.Add(this.lblNew);
            this.gBGeneral.Controls.Add(this.TekRtB);
            this.gBGeneral.Controls.Add(this.lblTek);
            this.gBGeneral.Location = new System.Drawing.Point(12, 12);
            this.gBGeneral.Name = "gBGeneral";
            this.gBGeneral.Size = new System.Drawing.Size(359, 195);
            this.gBGeneral.TabIndex = 0;
            this.gBGeneral.TabStop = false;
            this.gBGeneral.Text = "Смена пароля:";
            // 
            // lblTek
            // 
            this.lblTek.AutoSize = true;
            this.lblTek.Location = new System.Drawing.Point(18, 36);
            this.lblTek.Name = "lblTek";
            this.lblTek.Size = new System.Drawing.Size(94, 13);
            this.lblTek.TabIndex = 0;
            this.lblTek.Text = "Текущий пароль:";
            // 
            // TekRtB
            // 
            this.TekRtB.Location = new System.Drawing.Point(134, 33);
            this.TekRtB.Name = "TekRtB";
            this.TekRtB.PasswordChar = '*';
            this.TekRtB.Size = new System.Drawing.Size(168, 20);
            this.TekRtB.TabIndex = 1;
            this.TekRtB.TextChanged += new System.EventHandler(this.TekRtB_TextChanged);
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.Location = new System.Drawing.Point(29, 93);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(83, 13);
            this.lblNew.TabIndex = 2;
            this.lblNew.Text = "Новый пароль:";
            // 
            // NewRtB
            // 
            this.NewRtB.Location = new System.Drawing.Point(134, 90);
            this.NewRtB.Name = "NewRtB";
            this.NewRtB.PasswordChar = '*';
            this.NewRtB.Size = new System.Drawing.Size(168, 20);
            this.NewRtB.TabIndex = 3;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(119, 156);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(106, 23);
            this.btnChange.TabIndex = 4;
            this.btnChange.Text = "Сменить пароль";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(57, 127);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(242, 13);
            this.lblError.TabIndex = 5;
            this.lblError.Text = "Ошибка! Вы ввели неверный текущий пароль!";
            this.lblError.Visible = false;
            // 
            // ChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 222);
            this.Controls.Add(this.gBGeneral);
            this.Name = "ChangePass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменить пароль";
            this.gBGeneral.ResumeLayout(false);
            this.gBGeneral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBGeneral;
        private System.Windows.Forms.TextBox TekRtB;
        private System.Windows.Forms.Label lblTek;
        private System.Windows.Forms.TextBox NewRtB;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Label lblError;
    }
}