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
    public partial class WarningPass : Form
    {
        public WarningPass()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - this.Height);
            GeneralTimer.Start();
        }

        private void ChangePassword_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            //this.Opacity -= .03;
            //if (this.Opacity == 0)
            //    this.Hide();
        }

        private void GeneralTimer_Tick(object sender, EventArgs e)
        {
            this.Opacity += .03;
            if (this.Opacity == 1)
                GeneralTimer.Stop();
        }
    }
}
