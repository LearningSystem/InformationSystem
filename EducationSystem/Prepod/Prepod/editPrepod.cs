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
    public partial class editPrepod : Form
    {
        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader rdr;
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        BindingSource bs = new BindingSource();
        SqlDataAdapter adapter;
        DataTable data = new DataTable();
        string type;
        string id;
        public editPrepod(string tb1, string tb2, string tb3, string type_, string id_)
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand();
            textBox1.Text = tb1;
            textBox2.Text = tb2;
            textBox3.Text = tb3;            
            type = type_;
            id = id_;
        }

        private void editPrepod_Load(object sender, EventArgs e)
        {
            if (type == "update")
            {
                button1.Text = "Изменить";
                groupBox1.Text = "Редактировать данные";
            }
            else
            {
                button1.Text = "Добавить";
                groupBox1.Text = "Введите данные";
            }
        }

        private void createDir()
        {
            //главная папка для препода
            string nameDir = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text;
            string folderName = Application.StartupPath + "\\General\\" + nameDir;
            DirectoryInfo drInfo = new DirectoryInfo(folderName);
            drInfo.Create();
            //папка с материалами
            string folder = "\\Учебные материалы";
            drInfo = new DirectoryInfo(folderName + folder);
            drInfo.Create();
            drInfo = new DirectoryInfo(folderName + folder + "\\Теория");
            drInfo.Create();
            drInfo = new DirectoryInfo(folderName + folder + "\\Обучающие деревья");
            drInfo.Create();

            folder = "\\Тесты";
            drInfo = new DirectoryInfo(folderName + folder);
            drInfo.Create();
            folder = "\\Задачи";
            drInfo = new DirectoryInfo(folderName + folder);
            drInfo.Create();
            folder = "\\Работы студентов";
            drInfo = new DirectoryInfo(folderName + folder);
            drInfo.Create();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
            {
                try
                {
                    conn.Open();
                    comm.Connection = conn;
                    string nameDir = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text;
                    string path = "\\General\\" + nameDir + "\\";
                    if (type == "update")
                    {
                        //изменяем название папки
                        string dir = getPrepodPuth(id);
                        string oldFolder = Application.StartupPath + dir;
                        string newFolder = Application.StartupPath + "\\General\\" + nameDir;                        
                        DirectoryInfo drInfo = new DirectoryInfo(oldFolder);
                        drInfo.MoveTo(newFolder);
                        comm.CommandText = "update Преподаватель set Фамилия = '" + textBox1.Text + "', Имя = '" + textBox2.Text + "', Отчество = '" + textBox3.Text + "', [Путь к папке] = '"+ path +"' where [№ преподавателя] = '" + id + "'";
                    }
                    else
                    {                        
                        comm.CommandText = "Insert into Преподаватель (Фамилия, Имя, Отчество, Пароль, [Путь к папке]) Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','12345', '"+ path +"')";
                    }
                    comm.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message.ToString());
                }
                finally
                {
                    conn.Close();
                    createDir();
                    this.Hide();                    
                }
            }
            else MessageBox.Show("Заполните все данные!");
        }


        string getPrepodPuth(string id)
        {
            comm.CommandText = "select [Путь к папке] from Преподаватель where [№ преподавателя] = '" + id + "'";
            comm.ExecuteNonQuery();
            rdr = comm.ExecuteReader();
            rdr.Read();
            string path = rdr[0].ToString();
            rdr.Close();
            return path.Remove(path.Length - 1);
        }
    }

}
