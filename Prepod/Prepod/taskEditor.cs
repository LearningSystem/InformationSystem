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
using System.IO;

namespace Prepod
{
    public partial class taskEditor : Form
    {
        string mainPath = Application.StartupPath;
        string numPrepod;
        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader rdr;
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        BindingSource bs = new BindingSource();
        SqlDataAdapter adapter;
        DataTable data = new DataTable();
        public taskEditor(string numPrepod_)
        {
            InitializeComponent();
            numPrepod = numPrepod_;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand();
            comm.Connection = conn;
            dgSettings(dg);
            loadInf();

        }

        private void loadInf()
        {
            try
            {
                conn.Open();
                comm.CommandText = "select distinct Описание from Задача where [№ преподавателя] = '" + numPrepod + "'";
                SqlDataReader rdr = comm.ExecuteReader();
                if (rdr.HasRows)
                {
                    filter.Items.Clear();
                    while (rdr.Read())
                    {
                        filter.Items.Add(rdr[0].ToString());
                    }
                    rdr.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                conn.Close();
            }
        }


        private void задачуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Перед добавлением задач в базу, переместите файлы с задачами в соответствующую папку!");
            addTask at = new addTask(numPrepod);
            at.Show();
        }

        private void dgSettings(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void loadTasks()
        {
            try
            {
                conn.Open();                
                comm.CommandText = "Select * from Задача where [№ преподавателя] = '"+ numPrepod +"'";

                adapter = new SqlDataAdapter(comm);
                data.Clear();
                adapter.Fill(data);
                bs.DataSource = data;
                dg.DataSource = bs;

                dg.Columns[0].Visible = false;
                dg.Columns[2].Visible = false;
                dg.Columns[3].Visible = false;
                dg.Columns[5].Visible = false;
                dg.ReadOnly = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void taskEditor_Activated(object sender, EventArgs e)
        {
            loadTasks();
            loadInf();
        }

        private void filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            bs.Filter = "Описание = '" + filter.Text + "'";
        }

        string getPrepodPath()
        {
            string path = mainPath;
            try
            {
                conn.Open();
                comm.CommandText = "select [Путь к папке] from Преподаватель where [№ преподавателя] = '" + numPrepod + "'";
                SqlDataReader rdr = comm.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    path = path + rdr[0].ToString();
                }
                rdr.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            return path;
        }

        private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dg.CurrentRow.Cells[3].Value.ToString();
            string path = getPrepodPath() + name;
            richTextBox1.Clear(); 
            richTextBox1.LoadFile(path, RichTextBoxStreamType.RichText);                
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dg.CurrentRow != null)
            {
                try
                {
                    conn.Open();
                    comm.Connection = conn;
                    string id = dg.CurrentRow.Cells[0].Value.ToString();
                    comm.CommandText = "Delete from Задача where [№ задачи] ='" + id + "'";
                    comm.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message.ToString());
                }
                finally
                {
                    conn.Close();
                    loadInf();
                    loadTasks();
                    richTextBox1.Clear();
                }
            }
        }

        private void taskEditor_Load(object sender, EventArgs e)
        {

        }

        private void taskEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            menuPrepod mp = new menuPrepod(numPrepod);
            mp.Show();
        }
    }
}
