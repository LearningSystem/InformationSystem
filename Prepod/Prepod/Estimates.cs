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
    public partial class Estimates : Form
    {
        SqlConnection conn;
        string connectionString 
            = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        SqlDataAdapter adapter;
        DataTable data = new DataTable();


        string numPrepod;        
        public Estimates(string _numPrepod)
        {
            InitializeComponent();
            numPrepod = _numPrepod;
            loadInf();
        }

        private void loadInf()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;

            comm.CommandText = "Select Название from Группа";

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                group.Items.Add(rdr[0].ToString());
            }
            rdr.Close();

            comm.CommandText = "Select Вершина.Текст from Вершина Where [Тип вершины] = 1 and [№ дерева] = 4";

            rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                typeWork.Items.Add(rdr[0].ToString());
            }
            rdr.Close();

            conn.Close();
        }

        private void group_SelectedIndexChanged(object sender, EventArgs e)
        {
            data.Clear();
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;

            comm.CommandText = "Select * from [Успеваемость по задачам] where Группа = '"+ group.Text +"'";

            adapter = new SqlDataAdapter(comm);
            adapter.Fill(data);
            dataGridView1.DataSource = data;
            
            conn.Close();
        }

        private void typeWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            data.Clear();
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;

            comm.CommandText = "Select * from [Успеваемость по задачам] where [Вид работы] = '" + typeWork.Text + "'";

            adapter = new SqlDataAdapter(comm);
            adapter.Fill(data);
            dataGridView1.DataSource = data;

            conn.Close();
        }



       
    }
}
