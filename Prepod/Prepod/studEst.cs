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
    public partial class studEst : Form
    {
        SqlConnection conn;
        SqlCommand comm;

        string connectionString
            = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        SqlDataAdapter adapter;
<<<<<<< HEAD
        DataTable dataTasks = new DataTable();
        DataTable dataTests = new DataTable();

        BindingSource bs = new BindingSource();

        string numStud;
        string numTree;
        string viewTable;
        public studEst(string _numStud, string _numTree)
        {
            InitializeComponent();
            numStud = _numStud;
            numTree = _numTree;
           
            viewTable = "[Успеваемость по задачам]";
=======
        DataTable data = new DataTable();
        BindingSource bs = new BindingSource();

        string numStud;
        public studEst(string _numStud)
        {
            InitializeComponent();
            numStud = _numStud;
>>>>>>> d5f74ac7cb74f2aa2d0a722db7b10ad320858850

            conn = new SqlConnection(connectionString);
            comm = new SqlCommand();
            comm.Connection = conn;
        }

        private void loadInf()
<<<<<<< HEAD
        {                       
            conn.Open();            
            comm.CommandText = "Select * from "+ viewTable +" where [№ дерева] = '"+ numTree +"'";
            adapter = new SqlDataAdapter(comm);            

            if (viewTable == "[Успеваемость по задачам]")
            {
                dataTasks.Clear();
                adapter.Fill(dataTasks);
                tasks.DataSource = dataTasks;
                tasks.Columns[0].Visible = false;
                tasks.Columns[1].Visible = false;
                tasks.Columns[2].Visible = false;
                tasks.Columns[3].Visible = false;
                tasks.Columns[12].Visible = false;
                tasks.Columns[11].Visible = false;
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
                tests.Columns[1].Visible = false;
                tests.Columns[2].Visible = false;
                tests.Columns[3].Visible = false;
                tests.Columns[4].Visible = false;
                tests.Columns[13].Visible = false;
                tests.ReadOnly = true;
                tests.Visible = true;
                tasks.Visible = false;
                bs.DataSource = dataTests;
            }                     
=======
        {
            conn.Open();            
            comm.CommandText = "Select * from [Успеваемость по задачам]";

            adapter = new SqlDataAdapter(comm);
            adapter.Fill(data);

            dataGridView1.DataSource = data;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[0].Visible = false;

            bs.DataSource = data;
>>>>>>> d5f74ac7cb74f2aa2d0a722db7b10ad320858850
            bs.Filter = "[№ студента] = '" + numStud + "'";

            conn.Close();
        }

<<<<<<< HEAD

=======
        private void моиОценкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadInf();
        }
>>>>>>> d5f74ac7cb74f2aa2d0a722db7b10ad320858850

        private void рейтингToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void studEst_FormClosing(object sender, FormClosingEventArgs e)
        {
<<<<<<< HEAD
            studentWork sw = new studentWork(numStud);
            sw.Show();
            this.Hide();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (tableName.SelectedIndex == 0)
                viewTable = "[Успеваемость по задачам]";
            else
                viewTable = "[Успеваемость по тестам]";
            loadInf();
=======
            //studentWork sw = new studentWork(numStud);
            //sw.Show();
            //this.Hide();
>>>>>>> d5f74ac7cb74f2aa2d0a722db7b10ad320858850
        }

    }
}
