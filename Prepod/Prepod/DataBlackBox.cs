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
using System.IO;
using System.Configuration;

namespace Prepod
{
    public partial class DataBlackBox : Form
    {
        int numPrepod;
        bool allright=true;
        SqlConnection sconn;
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        string temp = "";
        //---
        int i = 1;
        int numTest = -1;
        int NumberProv = 0;
        string[] index = new string[200];
        //--
        public DataBlackBox(int _numPrepod)
        {
            InitializeComponent();
            numPrepod = _numPrepod;
        }

        private void DataBlackBox_Load(object sender, EventArgs e)
        {
            LoadExercise();
            Started(false);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            menuPrepod menupr = new menuPrepod(numPrepod.ToString());
            menupr.Show();
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

        //private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    menuPrepod menPred = new menuPrepod(numPrepod.ToString());
        //    this.Hide();
        //    menPred.Show();
        //}

        private void изменениеДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        void LoadExercise()
        {
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = @"SELECT [№ задачи] from [Задача] where [№ преподавателя]='" + numPrepod.ToString() + "'";
                try
                {
                    SqlDataReader dr = scommand.ExecuteReader();
                    while (dr.Read())
                        cmBExer.Items.Add(dr[0].ToString());
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            } sconn.Close();
        }

        private void cmBExer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dGVData.Enabled == false)
                Started(true);
            rTBText1.Text = null;
            dGVData.DataSource = null;
            ReadTests(cmBExer.SelectedItem.ToString());
            LoadTextExer(cmBExer.SelectedItem.ToString());
        }
        void ReadTests(string _select)
        {
            cmBTest.Items.Clear();
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = @"SELECT [№ проверки] from [Проверка] where [№ задачи]='"+_select+"'";
                try
                {
                    SqlDataReader dr = scommand.ExecuteReader();
                    int elem = 1;
                    //string[] index=new string[200];
                    int p=0;
                    while (dr.Read())
                    {
                        cmBTest.Items.Add("Тест №" + elem.ToString());
                        index[p] = dr[0].ToString();
                        elem++;
                        p++;
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            } sconn.Close();
        }

        void LoadTextExer(string _select)
        {
            string _path=Application.StartupPath;
            sconn = new SqlConnection(connectionString);
            bool ok=true;
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = @"SELECT [Путь к папке] from [Преподаватель] where [№ преподавателя]='"+numPrepod.ToString()+"'";
                try
                {
                    SqlDataReader dr = scommand.ExecuteReader();
                    while (dr.Read())
                    {
                        _path=_path+dr[0].ToString();
                    }
                    if (_path==Application.StartupPath)
                    {
                        ok=false;
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            } sconn.Close();
            //------------------------------------------
            if (ok==true)
            {
                sconn = new SqlConnection(connectionString);
                 using (sconn)
                {
                    sconn.Open();
                    SqlCommand scommand = new SqlCommand();
                    scommand.Connection = sconn;
                    scommand.CommandText = @"SELECT [ССылка] from [Задача] where [№ задачи]='"+_select+"'";
                    try
                    {
                        SqlDataReader dr = scommand.ExecuteReader();
                        while (dr.Read())
                        {
                            _path=_path+dr[0].ToString();
                        }
                        dr.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                } sconn.Close();
                //------------------------------------
                 rTBText1.LoadFile(_path);
            }
            else
            {
                MessageBox.Show("Ссылка пути преподавателя считалась неверно");
            }
        }

        private void cmBTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dGVData.DataSource = null;
                sconn = new SqlConnection(connectionString);
                sconn.Open();
                string query = @"SELECT distinct [Входные данные].[Значение] AS 'Входные данные',[Выходные данные].[Значение] AS 'Выходные данные' from [Входные данные],[Выходные данные],[Проверка] where [Проверка].[№ задачи]='" + cmBExer.SelectedItem.ToString() + "' and [Выходные данные].[№ проверки]='" + index[cmBTest.SelectedIndex] + "' and [Входные данные].[№ проверки]='" + index[cmBTest.SelectedIndex] +"'";
                SqlDataAdapter sda = new SqlDataAdapter(query, sconn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dGVData.DataSource = dt;
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
            sconn.Close();
        }
        void Started(bool _select)
        {
            lblExerText.Enabled = _select;
            rTBText1.Enabled = _select;
            lblnumTest.Enabled = _select;
            cmBTest.Enabled = _select;
            dGVData.Enabled = _select;
            видИзмененияToolStripMenuItem.Enabled = _select;
        }
    }
}
