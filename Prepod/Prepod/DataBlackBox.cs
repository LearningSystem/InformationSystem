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
    public partial class DataBlackBox : Form
    {
        int i = -1;
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        SqlConnection sconn;
        int NumberProv;
        string temp = "";
        bool allright = true;
        int numTest = -1;
        string NumTeacher;
        public DataBlackBox(string _numTeacher)
        {
            InitializeComponent();
            NumTeacher = _numTeacher;
        }

        private void DataBlackBox_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void oToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ReadFile(openFileDialog1.InitialDirectory + openFileDialog1.FileName);
            }
        }
        void ReadFile(string path)
        {
            int num = -1;
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                string numberTask = sr.ReadLine();
                if (numberTask.IndexOf("Задача:") == 0 && numberTask.IndexOf("Задача №") == 0)
                {
                    allright = false;
                    MessageBox.Show("Формат файла нарушен!", "Ошибка!");
                }
                else
                    num = Int32.Parse(numberTask.Remove(0, 8));
                //---------------------------------------------------------------------------------
                sconn = new SqlConnection(connectionString);
                using (sconn)
                {
                    sconn.Open();
                    SqlCommand scommand = new SqlCommand();
                    scommand.Connection = sconn;
                    scommand.CommandText = @"Select [№ задачи] from [Задача]";
                    try
                    {
                        //scommand.CommandText = @"Select [№ проверки] from [Проверка] where [№ задачи]=" + num.ToString();
                        SqlDataReader dr = scommand.ExecuteReader();
                        bool good = true;
                        while (dr.Read())
                        {
                            if (Int32.Parse(dr[0].ToString()) == num)
                            {
                                good = true;
                                break;
                            }
                            else
                                good = false;

                        }
                        if (good == false)
                        {
                            MessageBox.Show("Такой задачи нет в БД!");
                            allright = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                } sconn.Close();
                //----------------------------------------------------------------------
                if (allright == true)
                {
                    //numTest = -1;
                    string kolvoTests = sr.ReadLine();
                    numTest = Int32.Parse(kolvoTests.Remove(0, 7));
                    i = 1;
                    while (i <= numTest)
                    {
                        if (allright == true)
                        {
                            insertNewProv(num);
                            ReadOneTest(sr);
                            i++;
                        }
                        else
                        {
                            MessageBox.Show("Формат файла нарушен! Тесты, которые были записаны корректно, внесены в БД.", "Ошибка!");
                            break;
                        }
                    }
                    if (allright == false)
                        MessageBox.Show("Формат файла нарушен! Тесты, которые были записаны корректно, внесены в БД.", "Ошибка!");
                    else
                        MessageBox.Show("Готово!");
                }
                else
                    MessageBox.Show("Ошибка!");
            }
        }
        void ReadOneTest(StreamReader str)
        {
            string tekTest;
            if (temp != "Тест " + i.ToString())
                tekTest = str.ReadLine();
            else
                tekTest = temp;
            if (Int32.Parse(tekTest.Remove(0, 5)) == i)
            {
                str.ReadLine();
                temp = str.ReadLine();
                while (temp != "Исходящие")
                {

                    insertOne(temp, "in");
                    temp = str.ReadLine();
                }
                //temp = "Исходящие";
                temp = str.ReadLine();
                while (temp != null && temp != "Тест " + (i + 1).ToString())
                {
                    insertOne(temp, "out");
                    temp = str.ReadLine();
                }
                if (temp == null)
                    if (i != numTest)
                        allright = false;
                if (temp != null)
                    if (i == numTest)
                        allright = false;
            }
            else
                MessageBox.Show("Формат файла нарушен!", "Ошибка!");
        }
        void insertOne(string one, string where)
        {
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                if (where == "in")
                    scommand.CommandText = @"Insert into [Входные данные] ([№ проверки],[Значение]) values (" + NumberProv + ",'" + one + "')";
                else
                    scommand.CommandText = @"Insert into [Выходные данные] ([№ проверки],[Значение]) values (" + NumberProv + ",'" + one + "')";
                try
                {
                    scommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            } sconn.Close();
        }
        void insertNewProv(int number)
        {
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = @"insert into Проверка ([№ задачи]) values (" + number + ")";
                try
                {
                    scommand.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            } sconn.Close();
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = @"Select [№ проверки] from [Проверка] where [№ задачи]=" + number.ToString();
                try
                {
                    //scommand.CommandText = @"Select [№ проверки] from [Проверка] where [№ задачи]=" + num.ToString();
                    SqlDataReader dr = scommand.ExecuteReader();
                    while (dr.Read())
                    {
                        NumberProv = Int32.Parse(dr[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } sconn.Close();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuPrepod menPred = new menuPrepod(NumTeacher);
            this.Hide();
            menPred.Show();
        }
    }
}
