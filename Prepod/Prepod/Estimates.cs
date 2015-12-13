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
        public Estimates(string _numPrepod)
        {
            InitializeComponent();
            numPrepod = _numPrepod;
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

            comm.CommandText = "Select Вершина.Текст from Вершина Where [Тип вершины] = 1 and [№ дерева] = 4";

            rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                typeWork.Items.Add(rdr[0].ToString());
            }
            rdr.Close();

            comm.CommandText = "Select * from [Успеваемость по задачам]";

            adapter = new SqlDataAdapter(comm);
            adapter.Fill(data);


            conn.Close();
        }

        private void group_SelectedIndexChanged(object sender, EventArgs e)
        {
            bs.DataSource = data;
            bs.Filter = "Группа = '" + group.Text + "'";
        }

        private void typeWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            bs.DataSource = data;
            bs.Filter = "[Вид работы] = '" + typeWork.Text + "' and Группа = '" + group.Text + "'";           
        }



       
    }
}
