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
    public partial class editPredmet : Form
    {
        SqlConnection conn;
        //string connectionString =
        //        "Data Source=(local);Initial Catalog=Education; user id = sa; password = 1";
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        BindingSource bs = new BindingSource();        
        DataTable data = new DataTable();
        public editPredmet()
        {
            InitializeComponent();
        }
       public void invalidate()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "Select * from Предмет";
            SqlDataReader rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    listBox1.Items.Add(rdr[1]);
                }
            }
            rdr.Close();
        }
        private void editPredmet_Load(object sender, EventArgs e)
        {
            invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                if (textBox1.Text != "")
                {
                    SqlCommand comm = new SqlCommand();                    
                    string cmd = "Insert into Предмет (Название) Values('" + textBox1.Text + "')";
                    comm.CommandText = cmd;
                    comm.Connection = conn;
                    comm.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Введите данные о студенте");
                }
            }
            finally
            {
                listBox1.Items.Clear();
                invalidate();
                System.Windows.Forms.MessageBox.Show("Добавление выполнено");                              
                conn.Close();
                textBox1.Text = "";                                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                if (listBox1.SelectedIndex != -1)
                {
                    SqlCommand comm = new SqlCommand();
                    string cmd = "Delete from Предмет where Предмет.Название ='" + listBox1.SelectedItem.ToString() + "'";
                    comm.CommandText = cmd;
                    comm.Connection = conn;
                    comm.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Введите данные о студенте");
                }
            }
            finally
            {
                listBox1.Items.Clear();
                invalidate();
                System.Windows.Forms.MessageBox.Show("Удаление выполнено");
                conn.Close();
                textBox1.Text = "";
            }
        }
    }
}
