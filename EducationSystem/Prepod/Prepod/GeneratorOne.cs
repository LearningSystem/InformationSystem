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
    public partial class GeneratorOne : Form
    {
        string NumTeacher;
        SqlConnection sconn;
        string[] pathtofile = new string[100];
        string NumberTekPon;
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public GeneratorOne(string _numprepod)
        {
            InitializeComponent();
            NumTeacher = _numprepod.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NewPon();
            SxodPod();
            //GeneratorTwo genTwo = new GeneratorTwo(NumberTekPon,lstPon);
            if (cmBSchablon.SelectedItem != null)
            {
                this.Hide();
                GeneratorTwo genTwo = new GeneratorTwo(cmBSchablon.SelectedItem.ToString(), txtBoxPon.Text, lstPon,NumTeacher);
                genTwo.Show();
            }
            else
                MessageBox.Show("Выберите шаблон!", "Ошибка");
            //genTwo.Show();
        }

        private void GeneratorOne_Load(object sender, EventArgs e)
        {
            LoadSchabl();
            LoadPon();
        }

        void LoadSchabl()
        {
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = "SELECT [№ шаблона],[Файл] from [Шаблон] where [№ преподавателя]='" + NumTeacher + "'";
                try
                {
                    SqlDataReader dr = scommand.ExecuteReader();
                    
                    int k = 0;
                    while (dr.Read())
                    {
                        cmBSchablon.Items.Add(dr[0].ToString());
                        pathtofile[k] = dr[1].ToString();
                        k++;
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            } sconn.Close();
        }

        private void cmBSchablon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                rTBText.LoadFile(pathtofile[cmBSchablon.SelectedIndex]);
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        void LoadPon()
        {
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = "SELECT [Понятие],[№ понятия] from [Понятия]";
                try
                {
                    SqlDataReader dr = scommand.ExecuteReader();
                    while (dr.Read())
                    {
                        int index=lstPon.Items.Add(dr[0].ToString()).Index;
                        lstPon.Items[index].Tag = dr[1].ToString();
                    } dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            } sconn.Close();
        }

        void NewPon()
        {
            //sconn = new SqlConnection(connectionString);
            //using (sconn)
            //{
            //    sconn.Open();
            //    SqlCommand scommand = new SqlCommand();
            //    scommand.Connection = sconn;
            //    scommand.CommandText = "Insert into Понятия([Понятие]) values('"+txtBoxPon.Text+"')";
            //    try
            //    {
            //        scommand.ExecuteNonQuery();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }

            //} sconn.Close();
        }
        
        void SxodPod()
        {
            //sconn = new SqlConnection(connectionString);
            //using (sconn)
            //{
            //    sconn.Open();
            //    SqlCommand scommand = new SqlCommand();
            //    scommand.Connection = sconn;
            //    scommand.CommandText = @"SELECT TOP 1 [№ понятия] from [Понятия] order by [№ понятия] desc";
            //    try
            //    {
            //        scommand.ExecuteNonQuery();
            //        SqlDataReader dr = scommand.ExecuteReader();
            //        while (dr.Read())
            //        {
            //            NumberTekPon = dr[0].ToString();
            //        }
            //        dr.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //} sconn.Close();
            //foreach (ListViewItem item in lstPon.CheckedItems)
            //{
            //    WriteSxodPon(item.Tag.ToString());
            //}
        }

        void WriteSxodPon(string _select)
        {
            //sconn = new SqlConnection(connectionString);
            //using (sconn)
            //{
            //    sconn.Open();
            //    SqlCommand scommand = new SqlCommand();
            //    scommand.Connection = sconn;
            //    scommand.CommandText = @"INSERT INTO [Сходные понятия]([№ понятия],[№ схожего понятия]) values ('"+NumberTekPon+"','"+_select+"')";
            //    try
            //    {
            //        scommand.ExecuteNonQuery();
            //        scommand.CommandText = @"INSERT INTO [Сходные понятия]([№ понятия],[№ схожего понятия]) values ('" + _select + "','" + NumberTekPon + "')";
            //        scommand.ExecuteNonQuery();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //} sconn.Close();
        }

        private void работаСДаннымиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            GeneratorWorkData gendata = new GeneratorWorkData(NumTeacher);
            this.Hide();
            gendata.Show();
        }
    }
}
