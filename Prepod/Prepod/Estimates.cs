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
        BindingSource bs = new BindingSource();


        string numPrepod;
        string numTree;
        public Estimates(string _numPrepod, string _numTree)
        {
            InitializeComponent();
            numPrepod = _numPrepod;
            numTree = _numTree;
            loadInf();
            group.SelectedIndex = 0;
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

            comm.CommandText = "Select Вершина.Текст from Вершина Where [Тип вершины] = 1 and [№ дерева] = '"+ numTree +"'";

            rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                typeWork.Items.Add(rdr[0].ToString());
            }
            rdr.Close();

            comm.CommandText = "Select * from [Успеваемость по задачам]";

            adapter = new SqlDataAdapter(comm);
            adapter.Fill(data);

            dataGridView1.DataSource = data;

            bs.DataSource = data;
            bs.Filter = "[№ дерева] = '" + numTree + "'";

            conn.Close();
        }

        private void group_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            bs.Filter = "Группа = '" + group.Text + "'";
        }

        private void typeWork_SelectedIndexChanged(object sender, EventArgs e)
        {

            bs.Filter = "[Вид работы] = '" + typeWork.Text + "' and Группа = '" + group.Text + "'";           
        }



       
    }
}
