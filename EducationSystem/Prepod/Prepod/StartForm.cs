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
    public partial class StartForm : Form
    {
        int time = 0;
        public StartForm()
        {
            InitializeComponent();
            StartTimer.Start();
        }

        private void StartTimer_Tick(object sender, EventArgs e)
        {
            this.Opacity += .03;
            if (this.Opacity == 1)
            {
                if (time == 100)
                {
                    StartTimer.Stop();
                    regForm registr = new regForm();
                    this.Hide();
                    registr.Show();
                }
                else
                    time += 1;
            }
        }
    }
}
