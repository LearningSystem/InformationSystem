using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NewBlackBox
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveSettings.CompilerPath = textBox1.Text;
            MainPrepod mp = new MainPrepod();
            mp.Show();
            this.Hide();        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainPrepod mp = new MainPrepod();
            mp.Show();
            this.Hide();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            textBox1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            FindFiles("C:\\Windows\\Microsoft.NET\\Framework\\","csc.exe");
            progressBar1.Value = progressBar1.Maximum;
        }
        public void FindFiles(string dir, string pattern)
        {
            this.FindInDir(new DirectoryInfo(dir), pattern, true);
        }
        public void FindInDir(DirectoryInfo dir,string pattern,bool recursive)
        {
            if (recursive)
            {
                foreach (FileInfo file in dir.GetFiles(pattern))
                {
                    textBox1.Text = file.FullName;
                    //progressBar1.Value = 100;
                    recursive = false;
                    //progressBar1.Visible = false;
                    textBox1.Enabled = true;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                }
                if (recursive)
                {
                    foreach (DirectoryInfo subdir in dir.GetDirectories())
                    {
                        if (recursive)
                        {
                            this.FindInDir(subdir, pattern, recursive);
                            //progressBar1.Value++;
                        }
                    }
                }
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            textBox1.Text = SaveSettings.CompilerPath;
        }
    }
}
