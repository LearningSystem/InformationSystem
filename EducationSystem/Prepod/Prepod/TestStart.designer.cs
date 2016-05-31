namespace Prepod
{
    partial class TestStart
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
            this.lstQuestion = new System.Windows.Forms.ListView();
            this.rTB = new System.Windows.Forms.RichTextBox();
            this.pBTime = new System.Windows.Forms.ProgressBar();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gB3 = new System.Windows.Forms.GroupBox();
            this.txtB4 = new System.Windows.Forms.RichTextBox();
            this.txtB2 = new System.Windows.Forms.RichTextBox();
            this.txtB3 = new System.Windows.Forms.RichTextBox();
            this.txtB1 = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.MyTimer = new System.Windows.Forms.Timer(this.components);
            this.lblNumberQuest = new System.Windows.Forms.Label();
            this.btnPrevQuestion = new System.Windows.Forms.Button();
            this.btnNextQuestion = new System.Windows.Forms.Button();
            this.lbllistQ = new System.Windows.Forms.Label();
            this.lbltextQ = new System.Windows.Forms.Label();
            this.gB3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstQuestion
            // 
            this.lstQuestion.Location = new System.Drawing.Point(14, 38);
            this.lstQuestion.Name = "lstQuestion";
            this.lstQuestion.Size = new System.Drawing.Size(224, 454);
            this.lstQuestion.TabIndex = 0;
            this.lstQuestion.UseCompatibleStateImageBehavior = false;
            this.lstQuestion.View = System.Windows.Forms.View.List;
            this.lstQuestion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstQuestion_MouseDoubleClick);
            // 
            // rTB
            // 
            this.rTB.Location = new System.Drawing.Point(258, 37);
            this.rTB.Name = "rTB";
            this.rTB.ReadOnly = true;
            this.rTB.Size = new System.Drawing.Size(742, 167);
            this.rTB.TabIndex = 1;
            this.rTB.Text = "";
            // 
            // pBTime
            // 
            this.pBTime.Location = new System.Drawing.Point(346, 466);
            this.pBTime.Name = "pBTime";
            this.pBTime.Size = new System.Drawing.Size(535, 27);
            this.pBTime.TabIndex = 3;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(255, 472);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(48, 15);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "Время:";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(885, 466);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(115, 27);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Сдать тест";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ответ 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ответ 2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ответ 3:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(384, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ответ 4:";
            // 
            // gB3
            // 
            this.gB3.Controls.Add(this.txtB4);
            this.gB3.Controls.Add(this.txtB2);
            this.gB3.Controls.Add(this.txtB3);
            this.gB3.Controls.Add(this.txtB1);
            this.gB3.Controls.Add(this.label6);
            this.gB3.Controls.Add(this.label7);
            this.gB3.Controls.Add(this.label5);
            this.gB3.Controls.Add(this.label4);
            this.gB3.Controls.Add(this.label3);
            this.gB3.Controls.Add(this.label2);
            this.gB3.Location = new System.Drawing.Point(258, 205);
            this.gB3.Name = "gB3";
            this.gB3.Size = new System.Drawing.Size(742, 211);
            this.gB3.TabIndex = 2;
            this.gB3.TabStop = false;
            this.gB3.Text = "Блок ответов:";
            // 
            // txtB4
            // 
            this.txtB4.Location = new System.Drawing.Point(405, 152);
            this.txtB4.Name = "txtB4";
            this.txtB4.Size = new System.Drawing.Size(322, 40);
            this.txtB4.TabIndex = 21;
            this.txtB4.Text = "";
            // 
            // txtB2
            // 
            this.txtB2.Location = new System.Drawing.Point(402, 61);
            this.txtB2.Name = "txtB2";
            this.txtB2.Size = new System.Drawing.Size(322, 40);
            this.txtB2.TabIndex = 20;
            this.txtB2.Text = "";
            // 
            // txtB3
            // 
            this.txtB3.Location = new System.Drawing.Point(38, 152);
            this.txtB3.Name = "txtB3";
            this.txtB3.Size = new System.Drawing.Size(322, 40);
            this.txtB3.TabIndex = 19;
            this.txtB3.Text = "";
            // 
            // txtB1
            // 
            this.txtB1.Location = new System.Drawing.Point(38, 61);
            this.txtB1.Name = "txtB1";
            this.txtB1.Size = new System.Drawing.Size(322, 40);
            this.txtB1.TabIndex = 18;
            this.txtB1.Text = "";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(363, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 3);
            this.label6.TabIndex = 17;
            this.label6.Text = "     ";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(363, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 3);
            this.label7.TabIndex = 16;
            this.label7.Text = "     ";
            this.label7.Visible = false;
            // 
            // MyTimer
            // 
            this.MyTimer.Interval = 60000;
            this.MyTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblNumberQuest
            // 
            this.lblNumberQuest.AutoSize = true;
            this.lblNumberQuest.Location = new System.Drawing.Point(255, 487);
            this.lblNumberQuest.Name = "lblNumberQuest";
            this.lblNumberQuest.Size = new System.Drawing.Size(0, 15);
            this.lblNumberQuest.TabIndex = 6;
            this.lblNumberQuest.Visible = false;
            // 
            // btnPrevQuestion
            // 
            this.btnPrevQuestion.Location = new System.Drawing.Point(258, 430);
            this.btnPrevQuestion.Name = "btnPrevQuestion";
            this.btnPrevQuestion.Size = new System.Drawing.Size(87, 27);
            this.btnPrevQuestion.TabIndex = 7;
            this.btnPrevQuestion.Text = "Назад";
            this.btnPrevQuestion.UseVisualStyleBackColor = true;
            this.btnPrevQuestion.Click += new System.EventHandler(this.btnPrevQuestion_Click);
            // 
            // btnNextQuestion
            // 
            this.btnNextQuestion.Location = new System.Drawing.Point(912, 430);
            this.btnNextQuestion.Name = "btnNextQuestion";
            this.btnNextQuestion.Size = new System.Drawing.Size(87, 27);
            this.btnNextQuestion.TabIndex = 8;
            this.btnNextQuestion.Text = "Вперед";
            this.btnNextQuestion.UseVisualStyleBackColor = true;
            this.btnNextQuestion.Click += new System.EventHandler(this.btnNextQuestion_Click);
            // 
            // lbllistQ
            // 
            this.lbllistQ.AutoSize = true;
            this.lbllistQ.Location = new System.Drawing.Point(10, 10);
            this.lbllistQ.Name = "lbllistQ";
            this.lbllistQ.Size = new System.Drawing.Size(109, 15);
            this.lbllistQ.TabIndex = 9;
            this.lbllistQ.Text = "Список вопросов:";
            // 
            // lbltextQ
            // 
            this.lbltextQ.AutoSize = true;
            this.lbltextQ.Location = new System.Drawing.Point(255, 10);
            this.lbltextQ.Name = "lbltextQ";
            this.lbltextQ.Size = new System.Drawing.Size(94, 15);
            this.lbltextQ.TabIndex = 10;
            this.lbltextQ.Text = "Текст вопроса:";
            // 
            // TestStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1008, 507);
            this.Controls.Add(this.lbltextQ);
            this.Controls.Add(this.lbllistQ);
            this.Controls.Add(this.btnNextQuestion);
            this.Controls.Add(this.btnPrevQuestion);
            this.Controls.Add(this.lblNumberQuest);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.pBTime);
            this.Controls.Add(this.gB3);
            this.Controls.Add(this.rTB);
            this.Controls.Add(this.lstQuestion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TestStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тестирование";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestStart_FormClosing);
            this.Load += new System.EventHandler(this.TestStart_Load);
            this.gB3.ResumeLayout(false);
            this.gB3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstQuestion;
        private System.Windows.Forms.RichTextBox rTB;
        private System.Windows.Forms.ProgressBar pBTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gB3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer MyTimer;
        private System.Windows.Forms.Label lblNumberQuest;
        private System.Windows.Forms.Button btnPrevQuestion;
        private System.Windows.Forms.Button btnNextQuestion;
        private System.Windows.Forms.Label lbllistQ;
        private System.Windows.Forms.Label lbltextQ;
        private System.Windows.Forms.RichTextBox txtB3;
        private System.Windows.Forms.RichTextBox txtB1;
        private System.Windows.Forms.RichTextBox txtB4;
        private System.Windows.Forms.RichTextBox txtB2;
    }
}

