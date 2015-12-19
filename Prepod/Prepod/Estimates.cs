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
        SqlCommand comm;
        string connectionString 
            = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        SqlDataAdapter adapter;
        DataTable dataTasks = new DataTable();
        DataTable dataTests = new DataTable();
        BindingSource bs = new BindingSource();


        string numPrepod;
        string numTree;

        string viewTable;
        public Estimates(string _numPrepod, string _numTree)
        {
            InitializeComponent();
            numPrepod = _numPrepod;
            numTree = _numTree;

            conn = new SqlConnection(connectionString);
            comm = new SqlCommand();
            comm.Connection = conn;

            loadInf();
            tableName.SelectedIndex = 0;
            group.SelectedIndex = 0;
            
        }

        private void loadInf()
        {            
            conn.Open();
            comm.CommandText = "Select Название from Группа";
            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                group.Items.Add(rdr[0].ToString());
            }
            rdr.Close();

            comm.CommandText = "Select Вершина.Текст from Вершина, [Тип вершины] Where Вершина.[Тип вершины] = [Тип вершины].Код and [Тип вершины].Тип = 'Задача' and [№ дерева] = '"+ numTree +"'";
            rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                typeWork.Items.Add(rdr[0].ToString());
            }
            rdr.Close();

            //comm.CommandText = "Select Вершина.Текст from Вершина, [Тип вершины] Where Вершина.[Тип вершины] = [Тип вершины].Код and [Тип вершины].Тип = 'Тест' and [№ дерева] = '" + numTree + "'";
            //rdr = comm.ExecuteReader();
            //while (rdr.Read())
            //{
            //    typeTest.Items.Add(rdr[0].ToString());
            //}
            //rdr.Close();
            conn.Close();
                                    
        }

        private void loadDataGrid()
        {
            conn.Open();
            comm.CommandText = "Select * from " + viewTable + " where [№ дерева] = '" + numTree + "'";
            adapter = new SqlDataAdapter(comm);

            if (viewTable == "[Успеваемость по задачам]")
            {
                dataTasks.Clear();
                adapter.Fill(dataTasks);
                tasks.DataSource = dataTasks;
                tasks.Columns[11].Visible = false;
                tasks.Columns[12].Visible = false;
                tasks.ReadOnly = true;
                tasks.Visible = true;
                tests.Visible = false;
                bs.DataSource = dataTasks;
            }
            else
            {
                dataTests.Clear();
                adapter.Fill(dataTests);
                tests.DataSource = dataTests;
                tests.Columns[0].Visible = false;
                tests.Columns[13].Visible = false;
                tests.ReadOnly = true;
                tests.Visible = true;
                tasks.Visible = false;
                bs.DataSource = dataTests;
            }            
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

        private void tableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tableName.SelectedIndex == 0)
            {
                typeWork.Enabled = true;
                //typeTest.Enabled = false;
                viewTable = "[Успеваемость по задачам]";
            }                
            else
            {
                //typeTest.Enabled = true;
                typeWork.Enabled = false;
                viewTable = "[Успеваемость по тестам]";
            }
                
            loadDataGrid();
        }



       
    }
}
