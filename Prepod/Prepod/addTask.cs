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
    public partial class addTask : Form
    {
        string mainPath = Application.StartupPath;
        SqlConnection conn;
        SqlCommand comm;
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        DataTable data = new DataTable();        

        string numPrepod = "";        
        public addTask(string numPrepod_)
        {
            InitializeComponent();
            numPrepod = numPrepod_;            
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand();
            comm.Connection = conn;
            loadInf();
        }

        private void loadInf()
        {
            try
            {
                conn.Open();
                comm.CommandText = "select distinct Описание from Задача where [№ преподавателя] = '"+ numPrepod +"'";
                SqlDataReader rdr = comm.ExecuteReader();
                if (rdr.HasRows)
                {
                    comboBox1.Items.Clear();
                    while (rdr.Read())
                    {
                        comboBox1.Items.Add(rdr[0].ToString());
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

        private void addTask_Load(object sender, EventArgs e)
        {
            
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

        private void insertTask(string name, string description, string path)
        {
            try
            {
                //вставляем в таблицу Задача
                conn.Open();
                comm.CommandText = "insert into Задача (Название, Описание, Ссылка, [№ преподавателя]) Values ('" + name + "', '" + description + "', '" + path + "', '"+ numPrepod +"')";
                comm.ExecuteNonQuery();
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

        private void loadTasks()
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.FileName = "";
            OP.InitialDirectory = getPrepodPath() + "Задачи\\";
            OP.Filter = "RTF Files (*.rtf)|*.rtf";
            OP.Title = "Добавить файлы";
            OP.Multiselect = true;
            if (OP.ShowDialog() != DialogResult.Cancel)
            {                
                foreach (String file in OP.SafeFileNames)
                {                                   
                    string name = file.Remove(file.Length - 4, 4);                            
                    insertTask(name, comboBox1.Text, "Задачи\\" + file);                                                                    
                }
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                loadTasks();
            }
            else MessageBox.Show("Заполните поле описания!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
