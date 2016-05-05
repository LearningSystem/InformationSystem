using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prepod
{
    public partial class menuPrepod : Form
    {
        string numPrepod;
        public menuPrepod(string numPrepod_)
        {
            InitializeComponent();
            numPrepod = numPrepod_;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataBlackBox dataBlackBox = new DataBlackBox(Convert.ToInt32(numPrepod));
            dataBlackBox.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //InfoTest newtest = new InfoTest(Convert.ToInt32(numPrepod));
            //newtest.Show();
            //this.Hide();
            TestWorkStart testwork = new TestWorkStart(Convert.ToInt32(numPrepod));
            testwork.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            taskWork tw = new taskWork(numPrepod, "1");
            tw.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Estimates frm = new Estimates(numPrepod, "1");
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeWork tw = new treeWork(numPrepod);
            tw.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            taskEditor te = new taskEditor(numPrepod);
            te.Show();
            this.Hide();
        }
    }
}
