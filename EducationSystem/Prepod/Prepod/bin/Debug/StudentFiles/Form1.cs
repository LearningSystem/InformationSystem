using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Black
{
    public partial class Form1 : Form
    {
        string PathExec = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\csc.exe";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(PathExec, @"/out:My.exe C:\Program.cs");
                System.Diagnostics.Process.Start(Application.StartupPath + "\\My.exe ","4");
            }
            catch(Exception el)
            {
                MessageBox.Show(el.Message.ToString(),"Ошибка!");
            }
        }
    }
}
