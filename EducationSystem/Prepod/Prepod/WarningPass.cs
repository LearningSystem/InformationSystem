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
        string numStudent;
        studentWork studentWorks;
        public WarningPass(string _numStud,studentWork _studw)
        {
            InitializeComponent();
            numStudent = _numStud;
            studentWorks = _studw;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - this.Height);
            GeneralTimer.Start();
        }

        private void ChangePassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Hide();
                //Form.ActiveForm.SendToBack();
                studentWorks.SendToBack();
                //Form.ActiveForm.SendToBack();
                ChangePass chpass = new ChangePass(numStudent, studentWorks);
                chpass.Show();
                chpass.BringToFront();
                studentWorks.Activate();
                Form.ActiveForm.SendToBack();
                //this.Opacity -= .03;
                //if (this.Opacity == 0)
                //    this.Hide();
            }
            else
            {
                this.Hide();
            }
        }

        private void GeneralTimer_Tick(object sender, EventArgs e)
        {
            this.Opacity += .03;
            if (this.Opacity == 1)
                GeneralTimer.Stop();
        }
    }
}
