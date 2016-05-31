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
    public partial class GeneratorWorkData : Form
    {
        string NumTeacher;
        public GeneratorWorkData(string _numprepod)
        {
            InitializeComponent();
            NumTeacher = _numprepod;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            GeneratorOne genOne = new GeneratorOne(NumTeacher);
            this.Hide();
            genOne.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (radBtn1.Checked==true)
            {

            }
            else if (radBtn2.Checked==true)
            {
                GeneratorWorkToMethods genworktomethods = new GeneratorWorkToMethods();
                this.Hide();
                genworktomethods.Show();
            }
            else
            {

            }
        }
    }
}
