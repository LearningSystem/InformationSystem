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
        DataTable data = new DataTable();
        BindingSource bs = new BindingSource();

        string numStud;
        public studEst(string _numStud)
        {
            InitializeComponent();
            numStud = _numStud;

            conn = new SqlConnection(connectionString);
            comm = new SqlCommand();
            comm.Connection = conn;
        }

        private void loadInf()
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
            bs.Filter = "[№ студента] = '" + numStud + "'";

            conn.Close();
        }

        private void моиОценкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadInf();
        }

        private void рейтингToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void studEst_FormClosing(object sender, FormClosingEventArgs e)
        {
            //studentWork sw = new studentWork(numStud);
            //sw.Show();
            //this.Hide();
        }

    }
}
