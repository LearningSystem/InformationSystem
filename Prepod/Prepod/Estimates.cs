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
        BindingSource bsTasks = new BindingSource();
        BindingSource bsTests = new BindingSource();


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
            dgSettings(tasks);
            dgSettings(tests);

            loadGroup();
            loadType("Самостоятельная работа");
            loadTasks();            
            tabControl1.SelectedTab = taskPage;           
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

        private void loadGroup()
        {
            try
            {
                conn.Open();
                comm.CommandText = "Select Название from Группа";
                SqlDataReader rdr = comm.ExecuteReader();
                group.Items.Clear();
                group.Items.Add("Все");
                while (rdr.Read())
                {
                    group.Items.Add(rdr[0].ToString());
                }
                rdr.Close();
                group.SelectedIndex = 0;
                                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
                throw;  
            }   
            finally
            {
                conn.Close();
            }                        
                                    
        }

        private void loadType(string typeTask)
        {
            try
            {
                conn.Open();
                comm.CommandText = "Select Текст from Вершина, [Тип вершины] where [Тип вершины].Код = Вершина.[Тип вершины] and [Тип вершины].Тип = '"+ typeTask +"'";
                SqlDataReader rdr = comm.ExecuteReader();
                type.Items.Clear();
                type.Items.Add("Все");
                while (rdr.Read())
                {
                    type.Items.Add(rdr[0].ToString());
                }
                rdr.Close();
                type.SelectedIndex = 0;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
                throw;
            }
            finally
            {
                conn.Close();
            }

        }

        private void loadTasks()
        {
            try
            {
                conn.Open();
                comm.CommandText = "Select * from [Успеваемость по задачам] where [№ дерева] = '" + numTree + "'";
                adapter = new SqlDataAdapter(comm);
                dataTasks.Clear();
                adapter.Fill(dataTasks);
                tasks.DataSource = dataTasks;
                tasks.Columns[3].Visible = false;
                tasks.Columns[4].Visible = false;
                tasks.Columns[9].Visible = false;
                tasks.Columns[10].Visible = false;
                tasks.ReadOnly = true;                
                bsTasks.DataSource = dataTasks;

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        private void loadTests()
        {
            try
            {
                conn.Open();
                comm.CommandText = "Select * from [Успеваемость по тестам] where [№ дерева] = '" + numTree + "'";
                adapter = new SqlDataAdapter(comm);
                dataTests.Clear();
                adapter.Fill(dataTests);
                tests.DataSource = dataTests;
                tests.Columns[0].Visible = false;
                tests.Columns[4].Visible = false;
                tests.Columns[5].Visible = false;
                tests.Columns[13].Visible = false;
                tests.ReadOnly = true;
                bsTests.DataSource = dataTests;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        

        private void group_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == taskPage)
            {
                if ((group.Text != "Все")&&(type.Text != "Все"))
                {
                    bsTasks.Filter = "Группа = '" + group.Text + "' and [Вид работы] = '"+ type.Text +"'";
                }
                if ((group.Text == "Все") && (type.Text != "Все"))
                {
                    bsTasks.Filter = "[Вид работы] = '" + type.Text + "'";
                }
                if ((group.Text != "Все") && (type.Text == "Все"))
                {
                    bsTasks.Filter = "Группа = '" + group.Text + "'";
                }
                if ((group.Text == "Все") && (type.Text == "Все"))
                {
                    bsTasks.Filter = null;
                }                
            }
            else
            {
                if ((group.Text != "Все") && (type.Text != "Все"))
                {
                    bsTests.Filter = "Группа = '" + group.Text + "' and [Вид работы] = '" + type.Text + "'";
                }
                if ((group.Text == "Все") && (type.Text != "Все"))
                {
                    bsTests.Filter = "[Вид работы] = '" + type.Text + "'";
                }
                if ((group.Text != "Все") && (type.Text == "Все"))
                {
                    bsTests.Filter = "Группа = '" + group.Text + "'";
                }
                if ((group.Text == "Все") && (type.Text == "Все"))
                {
                    bsTests.Filter = null;
                }                 
            }            
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == taskPage)
                loadType("Самостоятельная работа");
            else
                loadType("Тест");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == taskPage)
                loadType("Самостоятельная работа");
            else
                loadType("Тест");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }               
    }
}
