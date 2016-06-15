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
    public partial class editStudent : Form
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
        string folderName;

        public editStudent(Object groups, string tb1, string tb2, string tb3, string type_, string id_, string folderName_)
        {
            InitializeComponent();            
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand();
            textBox1.Text = tb1;
            textBox2.Text = tb2;
            textBox3.Text = tb3;
            loadGroups();
            group.SelectedValue = groups;
            type = type_;
            id = id_;
            folderName = folderName_;
        }

        private void editStudent_Load(object sender, EventArgs e)
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

        private void loadGroups()
        {
            try
            {
                conn.Open();
                comm.Connection = conn;
                comm.CommandText = "Select [№ группы] as id, Название from Группа";

                adapter = new SqlDataAdapter(comm);
                data.Clear();
                adapter.Fill(data);
                group.DataSource = data;

                group.DisplayMember = "Название";
                group.ValueMember = "id";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
            {
                try
                {
                    conn.Open();
                    comm.Connection = conn;
                    string idGroup = group.SelectedValue.ToString();
                    if (type == "update")
                    {                        
                        string dir = getPrepodPuth(group.SelectedValue);
                        string oldFolder = Application.StartupPath + dir + folderName;                        
                        string newFolder = Application.StartupPath + dir + "Работы студентов\\" + textBox1.Text + " " + textBox2.Text + " " + textBox3.Text;
                        DirectoryInfo drInfo = new DirectoryInfo(oldFolder.Remove(oldFolder.Length - 1));
                        drInfo.MoveTo(newFolder);
                        comm.CommandText = "update Студент set Фамилия = '" + textBox1.Text + "', Имя = '" + textBox2.Text + "', Отчество = '" + textBox3.Text + "', [№ группы] = '" + group.SelectedValue.ToString() + "', [Ссылка на работы] = 'Работы студентов\\" + textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + "\\' where [№ студента] = '" + id + "'";
                        //--------------------------------------добавка с файлом history.txt
                        //if (!File.Exists())
                    }
                    else
                    {
                        string dir = getPrepodPuth(group.SelectedValue);
                        string path = "Работы студентов\\" + textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + "\\";
                        comm.CommandText = "Insert into Студент (Фамилия, Имя, Отчество, [№ группы], Пароль, [Ссылка на работы]) Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + idGroup + "','1', '"+ path +"')";

                        DirectoryInfo drInfo = new DirectoryInfo(Application.StartupPath + dir + "Работы студентов\\" + textBox1.Text + " " + textBox2.Text + " " + textBox3.Text);
                        drInfo.Create();
                        //-----------------------------добавка с файлом history.txt---------------------
                        string temp=textBox1.Text + " " + textBox2.Text + " " + textBox3.Text;
                        File.Create(Application.StartupPath + dir + "Работы студентов\\" + temp + "\\" + temp + ".txt");
                    }   //-------------------------------------------------------------------------------                 
                    comm.ExecuteNonQuery();                   
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
                finally
                {
                    conn.Close();                   
                    this.Hide();
                }
            }
            else MessageBox.Show("Заполните все данные!");
        }

        string getPrepodPuth(object id)
        {
            comm.CommandText = "select [Путь к папке] from Преподаватель, Группа where Группа.[№ преподавателя] = Преподаватель.[№ преподавателя] and Группа.[№ группы] = '"+ id.ToString() +"'";
            comm.ExecuteNonQuery();
            rdr = comm.ExecuteReader();
            rdr.Read();
            string path  =rdr[0].ToString();
            rdr.Close();
            return path;
        }

        private void group_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
