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
    public partial class helpForm : Form
    {
        public helpForm(string user)
        {
            InitializeComponent();
            loadFile(user);
        }

        private void loadFile(string user)
        {
            if (user == "Студент")
                rb.LoadFile(Application.StartupPath + "//Resources//Руководство_для_студента.rtf", RichTextBoxStreamType.RichText);
            if (user == "Преподаватель")
                rb.LoadFile(Application.StartupPath + "//Resources//Руководство_для_преподавателя.rtf", RichTextBoxStreamType.RichText);
            if (user == "Администратор")
                rb.LoadFile(Application.StartupPath + "//Resources//Руководство_для_администратора.rtf", RichTextBoxStreamType.RichText);
            rb.SelectAll();
            rb.SelectionIndent = 30;
            rb.SelectionHangingIndent = -20;
            rb.SelectionRightIndent = 12;
        }

        private void rb_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (section.Text == "0")
                rb.Find("Р");
            else
                rb.Find(section.Text + ")");
        }
    }
}
