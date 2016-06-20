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
    public partial class GeneratorThree : Form
    {
        string NumShab;
        string TextPon;
        string[] listPon=new string[100];
        string[] listMetod = new string[100];
        string NumPrepod;
        SqlConnection sconn;
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public GeneratorThree(string _numshab,string _textpon,ListView _lst,ListView _lstMetod,string _numprepod)
        {
            InitializeComponent();
            NumShab = _numshab;
            TextPon = _textpon;
            NumPrepod=_numprepod;
            int i=0;
            foreach (ListViewItem item in _lst.CheckedItems)
            {
                //if (item.Tag != null)
                //{
                    listPon[i] = item.Tag.ToString();
                    i++;
                //}
            }
            i = 0;
            foreach (ListViewItem item in _lstMetod.CheckedItems)
            {
                listMetod[i] = item.Tag.ToString();
                i++;
            }
        }

        private void впередToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int k=1;
            while (k<=KolNum.Value)
            {
                try
                {
                    if (k == 1)
                    {
                        OneExercise newExercise = new OneExercise(txtPath.Text, NumShab, TextPon, listMetod, listPon, "1");
                    }
                    else
                    {
                        OneExercise newExercise = new OneExercise(txtPath.Text, NumShab, TextPon, listMetod, listPon, "2");
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                finally
                {
                    pgBar.Value += 10;
                    k++;
                }
            }
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneratorOne genOne = new GeneratorOne(NumPrepod);
            this.Hide();
            genOne.Show();
        }

        private void GeneratorThree_Load(object sender, EventArgs e)
        {
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = "SELECT [Путь к папке] from [Преподаватель] where [№ преподавателя]='" + NumPrepod + "'";
                try
                {
                    SqlDataReader dr = scommand.ExecuteReader();
                    while (dr.Read())
                    {
                        txtPath.Text = Application.StartupPath + dr[0].ToString() + @"Задачи\";
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            } sconn.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }
    }
}
