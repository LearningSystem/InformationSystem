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
    public partial class studEstimates : Form
    {
        SqlConnection conn;
        SqlCommand comm;

        string connectionString
            = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        SqlDataAdapter adapter;
        DataTable dataTasks = new DataTable();
        DataTable dataTests = new DataTable();

        BindingSource bs = new BindingSource();

        string numStud;
        string numTree;
        string viewTable;
        public studEstimates(string _numStud, string _numTree)
        {
            InitializeComponent();
            numStud = _numStud;
            numTree = _numTree;

            conn = new SqlConnection(connectionString);
            comm = new SqlCommand();
            comm.Connection = conn;

            viewTable = "[Успеваемость по задачам]";
            tableName.SelectedIndex = 0;
            
        }

        private void loadInf()
        {
            conn.Open();
            comm.CommandText = "Select * from " + viewTable + " where [№ дерева] = '" + numTree + "'";
            adapter = new SqlDataAdapter(comm);

            if (viewTable == "[Успеваемость по задачам]")
            {
                dataTasks.Clear();
                adapter.Fill(dataTasks);
                tasks.ClearSelection();
                tasks.DataSource = dataTasks;
                tasks.Columns[0].Visible = false;
                tasks.Columns[1].Visible = false;
                tasks.Columns[2].Visible = false;
                tasks.Columns[3].Visible = false;
                tasks.Columns[12].Visible = false;
                tasks.Columns[11].Visible = false;
                tasks.ReadOnly = true;
                tasks.Visible = true;
                //tests.Visible = false;
                bs.DataSource = dataTasks;
            }
            else
            {
                dataTests.Clear();
                adapter.Fill(dataTests);
                tasks.ClearSelection();
                tasks.DataSource = dataTests;
                //tests.Columns[0].Visible = false;
                //tests.Columns[1].Visible = false;
                //tests.Columns[2].Visible = false;
                //tests.Columns[3].Visible = false;
                //tests.Columns[4].Visible = false;
                //tests.Columns[13].Visible = false;
                //tests.ReadOnly = true;
                //tests.Visible = true;
                //tasks.Visible = false;
                bs.DataSource = dataTests;
            }
            bs.Filter = "[№ студента] = '" + numStud + "'";

            conn.Close();
        }



        private void tableName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (tableName.SelectedIndex == 0)
                viewTable = "[Успеваемость по задачам]";
            else
                viewTable = "[Успеваемость по тестам]";
            loadInf();
        }

        private void studEstimates_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            this.Hide();
        }
    }
}
