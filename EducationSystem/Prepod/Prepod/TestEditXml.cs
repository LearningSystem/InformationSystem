using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Prepod
{
    public partial class TestEditXml : Form
    {
        string path;
        bool changes = false;
        int numTeacher;
        public TestEditXml(int _numTeacher,string _path)
        {
            InitializeComponent();
            path = _path;
            numTeacher = _numTeacher;
        }

        private void TestEditXml_Load(object sender, EventArgs e)
        {
            LoadTest(path);
            splitContainer1.Panel2Collapsed = true;
        }

        void LoadTest(string _selectpath)
        {
            string text = System.IO.File.ReadAllText(_selectpath);
            rTB.Text = text;
        }

        private void rTB_TextChanged(object sender, EventArgs e)
        {
            changes = true;
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (changes == true)
            {
                if (MessageBox.Show("Вы уверены, что хотите сохранить изменения?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string textTwo = rTB.Text;
                    System.IO.File.WriteAllText(path, textTwo);
                }
            }
        }

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog()==DialogResult.OK)
            {
                LoadTest(openFile.FileName);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuPrepod menupr = new menuPrepod(numTeacher.ToString());
            menupr.Show();
            this.Hide();
        }

        private void легендаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2Collapsed == true)
            {
                splitContainer1.Panel2Collapsed = false;
                rTBLegend.LoadFile(Application.StartupPath+"\\Resources\\Legend.rtf");
                rTBLegend.ReadOnly = true;
            }
            else
                splitContainer1.Panel2Collapsed = true;
        }
    }
}
