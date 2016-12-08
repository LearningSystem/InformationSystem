namespace NewBlackBox
{
    partial class MainPrepod
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddTests = new System.Windows.Forms.Button();
            this.btnAddExercise = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.группировкаРезультатовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заСегодняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnAddTests);
            this.panel1.Controls.Add(this.btnAddExercise);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 242);
            this.panel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 122);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(354, 48);
            this.button3.TabIndex = 3;
            this.button3.Text = "Редактирование задач и тестов";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 203);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "Настройки";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 203);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddTests
            // 
            this.btnAddTests.Location = new System.Drawing.Point(213, 36);
            this.btnAddTests.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTests.Name = "btnAddTests";
            this.btnAddTests.Size = new System.Drawing.Size(157, 48);
            this.btnAddTests.TabIndex = 1;
            this.btnAddTests.Text = "Добавить тесты";
            this.btnAddTests.UseVisualStyleBackColor = true;
            this.btnAddTests.Click += new System.EventHandler(this.btnAddTests_Click);
            // 
            // btnAddExercise
            // 
            this.btnAddExercise.Location = new System.Drawing.Point(16, 36);
            this.btnAddExercise.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddExercise.Name = "btnAddExercise";
            this.btnAddExercise.Size = new System.Drawing.Size(157, 48);
            this.btnAddExercise.TabIndex = 0;
            this.btnAddExercise.Text = "Добавить задачу";
            this.btnAddExercise.UseVisualStyleBackColor = true;
            this.btnAddExercise.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.группировкаРезультатовToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(391, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // группировкаРезультатовToolStripMenuItem
            // 
            this.группировкаРезультатовToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.заСегодняToolStripMenuItem});
            this.группировкаРезультатовToolStripMenuItem.Name = "группировкаРезультатовToolStripMenuItem";
            this.группировкаРезультатовToolStripMenuItem.Size = new System.Drawing.Size(184, 23);
            this.группировкаРезультатовToolStripMenuItem.Text = "Группировка результатов";
            // 
            // заСегодняToolStripMenuItem
            // 
            this.заСегодняToolStripMenuItem.Name = "заСегодняToolStripMenuItem";
            this.заСегодняToolStripMenuItem.Size = new System.Drawing.Size(144, 24);
            this.заСегодняToolStripMenuItem.Text = "за сегодня";
            this.заСегодняToolStripMenuItem.Click += new System.EventHandler(this.заСегодняToolStripMenuItem_Click);
            // 
            // MainPrepod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 269);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainPrepod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Режим преподавателя";
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddExercise;
        private System.Windows.Forms.Button btnAddTests;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem группировкаРезультатовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заСегодняToolStripMenuItem;
    }
}