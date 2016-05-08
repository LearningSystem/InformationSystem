using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Prepod
{
    public partial class TestWorkStart : Form
    {
        int numTeacher;
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public TestWorkStart(int _numTeacher)
        {
            InitializeComponent();
            numTeacher = _numTeacher;
        }

        private void TestWorkStart_Load(object sender, EventArgs e)
        {
            SqlConnection conn=new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select [Путь к папке] from Преподаватель where [№ преподавателя]=" + "'" + numTeacher.ToString() + "'";
                comm.ExecuteNonQuery();
                SqlDataReader rdr = comm.ExecuteReader();
                string path = "";
                while (rdr.Read())
                {
                    path = rdr[0].ToString();
                }
                rdr.Close();
                openPath.InitialDirectory = Application.StartupPath + path+"Тесты"+"\\";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при чтении из БД");
            }
            finally
            {
                conn.Close();
            }
        }

        private void radBut1_Click(object sender, EventArgs e)
        {
            if (radBut1.Checked || radBut3.Checked)
            {
                txtPath.Enabled = false;
                btnPath.Enabled = false;
                gBChanged.Enabled = false;
            }
            else
                if (radBut2.Checked)
                {
                    txtPath.Enabled = true;
                    btnPath.Enabled = true;
                    gBChanged.Enabled = true;
                }

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuPrepod menuPr = new menuPrepod(numTeacher.ToString());
            menuPr.Show();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            if (openPath.ShowDialog()==DialogResult.OK)
            {
                txtPath.Text = openPath.FileName;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (radBut1.Checked==true)
            {
                InfoTest test = new InfoTest(numTeacher);
                test.Show();
                this.Hide();
            }
            if (radBut2.Checked==true)
            {
                if (chBox1.Checked)
                {
                    TestEditXml testedit = new TestEditXml();
                    this.Hide();
                    testedit.Show();         
                }
            }
            if (radBut3.Checked==true)
            {
                delTest deltest = new delTest(numTeacher);
                deltest.Show();
                this.Hide();
            }
        }
    }
}
