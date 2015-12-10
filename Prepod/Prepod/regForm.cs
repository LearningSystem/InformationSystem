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
    public partial class regForm : Form
    {
        SqlConnection conn;
        
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public regForm()
        {
            InitializeComponent();
            
        }


        private void regForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            label6.Visible = false;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Студент");
            comboBox1.Items.Add("Преподаватель");
            comboBox1.Items.Add("Администратор");
            comboBox1.SelectedIndex = 0;
        }

        private void checkStudent()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select [№ студента] from Студент where Фамилия = '"+ textBox1.Text +"' and Имя = '"+ textBox2.Text +"' and Отчество = '"+ textBox3.Text +"' and Пароль = '"+ textBox4.Text +"'";
            SqlDataReader rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                label6.Visible = false;
                rdr.Read();
                studentWork sw = new studentWork(rdr[0].ToString());
                sw.Show();
                this.Hide();
            }
            else
            {
                label6.Visible = true;
            }
            rdr.Close();
            conn.Close();
        }

        private void checkTeacher()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select [№ преподавателя] from Преподаватель where Фамилия = '" + textBox1.Text + "' and Имя = '" + textBox2.Text + "' and Отчество = '" + textBox3.Text + "' and Пароль = '" + textBox4.Text + "'";
            SqlDataReader rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                label6.Visible = false;
                rdr.Read();
                prepodWork pw = new prepodWork(Convert.ToInt32(rdr[0].ToString()));
                pw.Show();
                this.Hide();
            }
            else
            {
                label6.Visible = true;
            }
            rdr.Close();
            conn.Close();
        }

        private void checkAdmin()
        {
            if (textBox4.Text == "1")
            {
                admin a = new admin();
                a.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox4.Text != "") && (comboBox1.SelectedIndex >= 0) &&(textBox1.Text !="")&&(textBox2.Text !="")&&(textBox3.Text !=""))
            {
                switch (comboBox1.SelectedIndex.ToString())
                {
                    case "0":
                        {
                            checkStudent();                            
                        }break;
                    case "1":
                        {
                            checkTeacher();
                        }break;
                    case "2":
                        {
                            checkAdmin();
                        }break;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 2)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
            }
        }
    }
}
