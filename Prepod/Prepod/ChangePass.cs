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
    public partial class ChangePass : Form
    {
        string numStudent;
        SqlConnection conn;
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public ChangePass(string _numStudent)
        {
            numStudent = _numStudent;
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string tekpass = "";
            string newpass = NewRtB.Text;
            bool flag = false;
            if (TekRtB.Text != "" && NewRtB.Text != "")
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select [Пароль] from Студент where [№ студента] = '" + numStudent + "'";
                SqlDataReader rdr = comm.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    tekpass = rdr[0].ToString().Trim();
                }
                rdr.Close();
                conn.Close();
                if (TekRtB.Text == tekpass)
                {
                    conn = new SqlConnection(connectionString);
                    conn.Open();
                    comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandText = "update [Студент] Set [Пароль]='" + newpass + "'" + " where [№ студента]='" + numStudent + "'";
                    try
                    {
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                        flag = true;
                    }
                    if (flag == false)
                    {
                        MessageBox.Show("Изменения сохранены.", "Смена пароля");
                        this.Hide();
                    }
                }
                else
                {
                    lblError.Visible = true;
                    TekRtB.Text = "";
                    NewRtB.Text = "";
                }
            }
            else
                MessageBox.Show("Заполните поля!", "Ошибка");
            conn.Close();
        }

        private void TekRtB_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }
    }
}
