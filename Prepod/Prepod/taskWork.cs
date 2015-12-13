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
    public partial class taskWork : Form
    {
        SqlConnection conn;
        SqlCommand comm;
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        string numPrepod;
        string numTree;

        SqlDataAdapter adapter;
        DataTable data = new DataTable();
        BindingSource bs = new BindingSource();

        public taskWork(string _numPrepod, string _numTree)
        {
            InitializeComponent();
            numPrepod = _numPrepod;
            numTree = _numTree;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand();
            comm.Connection = conn;

            loadInf();
            loadStud();
            loadListView();
            group.SelectedIndex = 0;
            checkOneTask.Enabled =
                checkNewTask.Enabled = false;
            richTextBox1.Visible = false;
            dataGridView1.Visible = true;
            cancel.Visible = false;
            check.Enabled = show.Enabled = watch.Enabled = false;
        }



        private void loadInf()
        {
            conn.Open();
            comm.CommandText = "select * from Группа, [Группы преподавателя] where Группа.[№ группы] = [Группы преподавателя].[№ группы] and [Группы преподавателя].[№ преподавателя] = '" + numPrepod + "'";
            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                group.Items.Add(rdr[1].ToString());               
            }
            rdr.Close();
            conn.Close();
        }

        private void loadListView()
        {
            //добавления колонок            
            ColumnHeader c = new ColumnHeader();
            c.Text = "ФИО студента";
            c.Width = c.Width + 80;

            listView1.Columns.Add(c);
        }

        private void loadStud()
        {
            listView1.Items.Clear();
            conn.Open();
            comm.CommandText = "select Фамилия, Имя, Отчество, Название, [№ студента] from Студент, Группа where Группа.[№ группы] = Студент.[№ группы] and Группа.Название = '" + group.Text +"'";
            SqlDataReader rdr = comm.ExecuteReader();

            ListViewItem lv = new ListViewItem();
            string tName = "";            
            while (rdr.Read())
            {
                tName = rdr[0].ToString() + " " + rdr[1].ToString() + " " + rdr[2].ToString();
                lv = new ListViewItem(new string[] { tName });
                lv.Name = rdr[4].ToString();
                lv.Tag = rdr[4].ToString();
                listView1.Items.Add(lv);
            }

            rdr.Close();
            conn.Close();
        }

        private void group_SelectedIndexChanged(object sender, EventArgs e)
        {            
            loadStud();
        }



        private void updateData()
        {
            data.Clear();
            conn.Open();
            comm.CommandText = "Select Задача.[№ задачи], Название, Уровень, [Максимальный балл], [Срок сдачи], Балл, [Дата сдачи], Ссылка, [Ссылка на работу] from Задача, [Выполненная задача] where Задача.[№ задачи] = [Выполненная задача].[№ задачи] and [Выполненная задача].[№ студента] = '" + listView1.SelectedItems[0].Tag.ToString() + "'";

            adapter = new SqlDataAdapter(comm);
            adapter.Fill(data);

            dataGridView1.DataSource = data;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;

            conn.Close();

            richTextBox1.Visible = false;
            dataGridView1.Visible = true;
            cancel.Visible = false;
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            updateData();
        }





        private void проверитьЗадачуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "")
                {
                    string numTask = dataGridView1.CurrentRow.Cells[0].Value.ToString(); //номер задачи
                    string numStud = listView1.SelectedItems[0].Tag.ToString(); //номер студента
                    //checkTask(numTask, numStud); //тут надо запускать проверку задачи
                    updateData();
                }
                else
                {
                    MessageBox.Show("Эта задача уже проверена");
                }

            }
            else { MessageBox.Show("Выберите задачу"); };
        }



        private void проверитьВсеНовыеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string numStud = listView1.SelectedItems[0].Tag.ToString();//номер студента
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.IsNewRow) continue;                
                if (dr.Cells[6].Value.ToString() == "")
                {
                    string numTask = dr.Cells[0].Value.ToString(); //номер задачи                    
                    //checkTask(numTask, numStud); //тут надо запускать проверку задачи                    
                }
                updateData();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkOneTask.Enabled =
                checkNewTask.Enabled = true;
            check.Enabled = show.Enabled = watch.Enabled = true;
        }


        

        private void cancel_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = false;
            dataGridView1.Visible = true;
            cancel.Visible = false;
        }

        private void showNew_Click(object sender, EventArgs e)
        {
            bs.DataSource = data;
            bs.Filter = "[Дата сдачи] = ''";
        }

        private void showAll_Click(object sender, EventArgs e)
        {
            bs.DataSource = data;
            bs.Filter = null;
        }

        private void showTask_Click(object sender, EventArgs e)
        {
            bs.DataSource = data;
            bs.Filter = "[Дата сдачи] <> ''";
        }

        private void watchTask_Click(object sender, EventArgs e)
        {
            string path = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            if (path != "")
            {
                richTextBox1.LoadFile(Application.StartupPath + path, RichTextBoxStreamType.RichText);
                richTextBox1.Visible = true;
                dataGridView1.Visible = false;
                cancel.Visible = true;
            }
        }

        private void watchCode_Click(object sender, EventArgs e)
        {
            string path = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            if (path != "")
            {
                richTextBox1.LoadFile(Application.StartupPath + path, RichTextBoxStreamType.PlainText);
                richTextBox1.Visible = true;
                dataGridView1.Visible = false;
                cancel.Visible = true;
            }
            else { MessageBox.Show("Задача еще не сдана"); }
        }

    }
}
