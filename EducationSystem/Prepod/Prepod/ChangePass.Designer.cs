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
            this.lblError = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.NewRtB = new System.Windows.Forms.TextBox();
            this.lblNew = new System.Windows.Forms.Label();
            this.TekRtB = new System.Windows.Forms.TextBox();
            this.lblTek = new System.Windows.Forms.Label();
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
            this.gBGeneral.Location = new System.Drawing.Point(16, 15);
            this.gBGeneral.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBGeneral.Name = "gBGeneral";
            this.gBGeneral.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBGeneral.Size = new System.Drawing.Size(479, 240);
            this.gBGeneral.TabIndex = 0;
            this.gBGeneral.TabStop = false;
            this.gBGeneral.Text = "Смена пароля:";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(76, 156);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(312, 17);
            this.lblError.TabIndex = 5;
            this.lblError.Text = "Ошибка! Вы ввели неверный текущий пароль!";
            this.lblError.Visible = false;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(159, 192);
            this.btnChange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(141, 28);
            this.btnChange.TabIndex = 4;
            this.btnChange.Text = "Сменить пароль";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // NewRtB
            // 
            this.NewRtB.Location = new System.Drawing.Point(179, 111);
            this.NewRtB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NewRtB.Name = "NewRtB";
            this.NewRtB.PasswordChar = '*';
            this.NewRtB.Size = new System.Drawing.Size(223, 23);
            this.NewRtB.TabIndex = 3;
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.Location = new System.Drawing.Point(39, 114);
            this.lblNew.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(106, 17);
            this.lblNew.TabIndex = 2;
            this.lblNew.Text = "Новый пароль:";
            // 
            // TekRtB
            // 
            this.TekRtB.Location = new System.Drawing.Point(179, 41);
            this.TekRtB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TekRtB.Name = "TekRtB";
            this.TekRtB.PasswordChar = '*';
            this.TekRtB.Size = new System.Drawing.Size(223, 23);
            this.TekRtB.TabIndex = 1;
            this.TekRtB.TextChanged += new System.EventHandler(this.TekRtB_TextChanged);
            // 
            // lblTek
            // 
            this.lblTek.AutoSize = true;
            this.lblTek.Location = new System.Drawing.Point(24, 44);
            this.lblTek.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTek.Name = "lblTek";
            this.lblTek.Size = new System.Drawing.Size(121, 17);
            this.lblTek.TabIndex = 0;
            this.lblTek.Text = "Текущий пароль:";
            // 
            // ChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 273);
            this.Controls.Add(this.gBGeneral);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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