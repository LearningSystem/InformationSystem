﻿using System;
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

        string mainPath = Application.StartupPath;

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

            richTextBox1.Visible = false;
            dataGridView1.Visible = true;
            cancel.Visible = false;            
        }



        private void loadInf()
        {
            try
            {
                conn.Open();
                comm.CommandText = "select * from Группа where [Группа].[№ преподавателя] = '" + numPrepod + "'";
                SqlDataReader rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    group.Items.Add(rdr[1].ToString());
                }
                rdr.Close();
            }            
            finally
            {
                conn.Close();
            }
            
        }

        private void loadListView()
        {
            //добавления колонок            
            ColumnHeader c = new ColumnHeader();
            c.Text = "ФИО студента";
            c.Width = c.Width + 105;

            listView1.Columns.Add(c);
        }

        private void loadStud()
        {
            listView1.Items.Clear();
            try
            {
                conn.Open();
                comm.CommandText = "select Фамилия, Имя, Отчество, Название, [№ студента] from Студент, Группа where Группа.[№ группы] = Студент.[№ группы] and Группа.Название = '" + group.Text + "'";
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
            }            
            finally
            {
                conn.Close();
            }            
        }

        private void group_SelectedIndexChanged(object sender, EventArgs e)
        {            
            loadStud();
        }



        private void updateData()
        {
            data.Clear();
            try
            {
                conn.Open();
                comm.CommandText = "Select Задача.[№ задачи], Название, [Максимальный балл], [Срок сдачи], Балл, [Дата сдачи], Задача.[Ссылка], [Ссылка на работу] from Задача, [Выполненная задача],Вершина where Задача.[№ задачи] = [Выполненная задача].[№ задачи] and Вершина.[№ вершины] = Задача.[№ вершины] and [Выполненная задача].[№ студента] = '" + listView1.SelectedItems[0].Tag.ToString() + "'";

                adapter = new SqlDataAdapter(comm);
                adapter.Fill(data);

                dataGridView1.DataSource = data;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;

                dataGridView1.Columns[4].DefaultCellStyle.BackColor = Color.LightYellow;
                for (int i = 0; i <= 7; i++)
                {
                    if (i == 4)
                        dataGridView1.Columns[i].ReadOnly = false;
                    else
                        dataGridView1.Columns[i].ReadOnly = true;
                }
            }                            
            finally
            {
                conn.Close();
                richTextBox1.Visible = false;
                dataGridView1.Visible = true;
                cancel.Visible = false;
            }            
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
                    string[] tasks = new string[1];
                    tasks[0] = numTask;
                    //BlackBox frm = new BlackBox(tasks,numStud,numPrepod);
                    //frm.Show();
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
            string[] tasks = new string[dataGridView1.Rows.Count];
            int i = 0;
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.IsNewRow) continue;                
                if (dr.Cells[6].Value.ToString() == "")
                {
                    string numTask = dr.Cells[0].Value.ToString();
                    tasks[i] = numTask;//номер задачи                    
                    //checkTask(numTask, numStud); //тут надо запускать проверку задачи                    
                }
                updateData();
            }
            //BlackBox frm = new BlackBox(tasks,numStud,numPrepod);
            //frm.Show();
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
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                conn.Close();
            }
            return path;
        }

        private void watchTask_Click(object sender, EventArgs e)
        {
            string path = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            if (path != "")
            {
                richTextBox1.LoadFile(getPrepodPath() + path, RichTextBoxStreamType.RichText);
                richTextBox1.Visible = true;
                dataGridView1.Visible = false;
                cancel.Visible = true;
            }
        }

        private void watchCode_Click(object sender, EventArgs e)
        {
            string path = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            if (path != "")
            {
                richTextBox1.LoadFile(getPrepodPath() + path, RichTextBoxStreamType.PlainText);
                richTextBox1.Visible = true;
                dataGridView1.Visible = false;
                cancel.Visible = true;
            }
            else { MessageBox.Show("Задача еще не сдана"); }
        }

        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {            
            string numStud = listView1.SelectedItems[0].Tag.ToString();
            string numTask = dataGridView1[0, e.RowIndex].Value.ToString();
            conn.Open();
            comm.CommandText = "update [Выполненная задача] set Балл = '"+ e.Value.ToString() +"' where [№ студента] = '"+ numStud +"' and [№ задачи] = '"+ numTask +"'";
            comm.ExecuteNonQuery();
            conn.Close();

        }

    }
}
