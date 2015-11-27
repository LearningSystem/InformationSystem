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
    public partial class newTree : Form
    {
        SqlConnection conn;
        //string connectionString =
        //        "Data Source=(local);Initial Catalog=Education; user id = sa; password = 1";
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        string numPrepod = "";
        public newTree(string numPrepod_)
        {
            InitializeComponent();
            numPrepod = numPrepod_;

        }
        string numPredmet = "";

        private void button1_Click(object sender, EventArgs e)
        {           
            if ((textBox1.Text != "") && (comboBox1.Text != ""))
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "insert into Дерево ([№ предмета], Название, [№ преподавателя]) Values ('"+ numPredmet +"', '"+ textBox1.Text +"', '"+ numPrepod +"')";
                comm.ExecuteNonQuery();
                conn.Close();
                this.Hide();
            }
            else
            {
                if (textBox1.Text == "")
                {
                    System.Windows.Forms.MessageBox.Show("Введите название!");
                }
                if (comboBox1.Text == "")
                {
                    System.Windows.Forms.MessageBox.Show("Выберите предмет!");
                }
            }
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;

            comm.CommandText = "select [№ предмета] from Предмет where Название = '" + comboBox1.Text + "'";
            SqlDataReader rdr = comm.ExecuteReader();
            rdr.Read();
            numPredmet = rdr[0].ToString();
            rdr.Close();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            this.Hide();
        }

        private void newTree_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;

            comm.CommandText = "Select Название from Предмет";
            comboBox1.Items.Clear();
            SqlDataReader rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    comboBox1.Items.Add(rdr[0]);

                }
            }
            rdr.Close();
            conn.Close();
        }
    }
}
