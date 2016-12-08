namespace NewBlackBox
{
    partial class AddExercise
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddTest = new System.Windows.Forms.Button();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.Output = new System.Windows.Forms.Label();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.Input = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox1.Location = new System.Drawing.Point(0, 66);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(525, 399);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "Шаблон задачи:\n\n\n<Текст задачи>\n\n\n\n\n\n\n\nMax score: <Кол-во баллов>";
            this.richTextBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 465);
            this.panel1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSave.Location = new System.Drawing.Point(351, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(143, 30);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Сохранить задачу";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите текст задачи:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblName.Location = new System.Drawing.Point(9, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(163, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Введите номер задачи:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnAddTest);
            this.panel2.Controls.Add(this.richTextBox4);
            this.panel2.Controls.Add(this.Output);
            this.panel2.Controls.Add(this.richTextBox3);
            this.panel2.Controls.Add(this.Input);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(528, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 465);
            this.panel2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button1.Location = new System.Drawing.Point(212, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(13, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // btnAddTest
            // 
            this.btnAddTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAddTest.Location = new System.Drawing.Point(42, 419);
            this.btnAddTest.Name = "btnAddTest";
            this.btnAddTest.Size = new System.Drawing.Size(118, 34);
            this.btnAddTest.TabIndex = 5;
            this.btnAddTest.Text = "Добавить тест";
            this.btnAddTest.UseVisualStyleBackColor = true;
            this.btnAddTest.Click += new System.EventHandler(this.btnAddTest_Click);
            // 
            // richTextBox4
            // 
            this.richTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.richTextBox4.Location = new System.Drawing.Point(3, 252);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(379, 161);
            this.richTextBox4.TabIndex = 4;
            this.richTextBox4.Text = "";
            // 
            // Output
            // 
            this.Output.AutoSize = true;
            this.Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Output.Location = new System.Drawing.Point(6, 229);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(155, 17);
            this.Output.TabIndex = 3;
            this.Output.Text = "Исходные параметры:";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.richTextBox3.Location = new System.Drawing.Point(3, 66);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(370, 157);
            this.richTextBox3.TabIndex = 2;
            this.richTextBox3.Text = "";
            // 
            // Input
            // 
            this.Input.AutoSize = true;
            this.Input.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Input.Location = new System.Drawing.Point(13, 39);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(147, 17);
            this.Input.TabIndex = 1;
            this.Input.Text = "Входные параметры:";
            // 
            // AddExercise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 465);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddExercise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить задачу";
            this.Load += new System.EventHandler(this.AddExercise_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddTest;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.Label Output;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Label Input;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;

    }
}