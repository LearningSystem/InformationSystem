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
    public partial class MainPrepod : Form
    {
        public MainPrepod()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string flag="Exercise";
            AddExercise adex = new AddExercise(flag,false);
            adex.Show();
            this.Hide();
        }

        private void btnAddTests_Click(object sender, EventArgs e)
        {
            string flag = "Tests";
            AddExercise adex = new AddExercise(flag,false);
            adex.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            regForm reg = new regForm();
            reg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.Show();
            this.Hide();
        }

        private void заСегодняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string temp = System.DateTime.Now.ToShortDateString();
            //temp = temp.Remove(temp.Length - 2, 2);
            DirectoryInfo  dir= new DirectoryInfo(Application.StartupPath+"\\Users\\");
            string dist=Directory.CreateDirectory(Application.StartupPath+"\\Users\\"+temp).FullName+"\\";
            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.FullName.IndexOf(temp) != -1)
                {
                    File.Copy(file.FullName, dist + file.Name);
                    File.Delete(file.FullName);
                }
                
            }
            MessageBox.Show("Группировка завершена.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Edit newedit = new Edit();
            newedit.Show();
            this.Hide();
        }
    }
}
