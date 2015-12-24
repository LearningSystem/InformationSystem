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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            editStudent es = new editStudent();
            es.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            editPredmet ep = new editPredmet();
            ep.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            regForm rgForm = new regForm();
            this.Hide();
            rgForm.Show();
        }
    }
}
