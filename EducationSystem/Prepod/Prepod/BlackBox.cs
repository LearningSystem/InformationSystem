using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;

namespace Prepod
{
    public partial class BlackBox : Form
    {
        string PathExec = Settings.CompilerPath;
        string PathPrograms = Application.StartupPath;
        string ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        string numTeacher;
        string numStud;

        string NumberExercise;
        string FioStud;
        string groupStud;
        string PathExercise; //путь к файлу с задачей ( cs файл)
        bool AllRight = true;
        //string[] answers=new string[100];
        string[] answers;
        Process newproc;
        string tempname;
        string PrepodPath;
        string studentPath;
        int TekTest = 1;//Номер текущего теста для вывода.
        public BlackBox(string[] _args, string _numStud, string _numTeacher,string _pathexercise)
        {
            InitializeComponent();
            numStud = _numStud;
            numTeacher = _numTeacher;
            NumberExercise = _args[1];
            PathExercise = _pathexercise;
        }
        public void Infa(string _selectinfa)
        {
            lstBox.Items.Add(_selectinfa);
        }
        public void SelectInfoStud()
        {
            string TaskPath=Application.StartupPath;
            SqlConnection connStart = new SqlConnection(ConnectionString);
            using (connStart)
            {
                connStart.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = connStart;
                scommand.CommandText = "Select [Фамилия],[Имя],[Отчество],[Название] From [Студент],[Группа] Where [Студент].[№ группы]=[Группа].[№ группы] and [Студент].[№ студента]='" + numStud + "'";
                SqlDataReader dr = scommand.ExecuteReader();
                while (dr.Read())
                {
                    FioStud = dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString();
                    groupStud = dr[3].ToString();
                }
                dr.Close();
            } connStart.Close();
            lbl1.Text = FioStud;
            lbl2.Text = groupStud;
            lbl3.Text=System.DateTime.Now.ToLongDateString();
            //---
            connStart = new SqlConnection(ConnectionString);
            using (connStart)
            {
                connStart.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = connStart;
                scommand.CommandText = "Select [Путь к папке] From [Преподаватель] Where [№ преподавателя]='" + numTeacher + "'";
                SqlDataReader dr = scommand.ExecuteReader();
                while (dr.Read())
                {
                    TaskPath = TaskPath + dr[0].ToString();
                    PrepodPath = dr[0].ToString();
                }
                dr.Close();
            } connStart.Close();
            //---
            connStart = new SqlConnection(ConnectionString);
            using (connStart)
            {
                connStart.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = connStart;
                scommand.CommandText = "Select [Ссылка] From [Задача] Where [№ задачи]='" + NumberExercise+ "'";
                SqlDataReader dr = scommand.ExecuteReader();
                while (dr.Read())
                {
                    TaskPath = TaskPath + dr[0].ToString();
                }
                dr.Close();
            } connStart.Close();
            rtbTask.LoadFile(TaskPath);
        }
        public void SelectPathExercise()
        {
            PathExercise = Application.StartupPath;
            SqlConnection sconn = new SqlConnection(ConnectionString);
            using (sconn)
            {
                sconn.Open();
                //SqlCommand scommand = new SqlCommand();
                //scommand.CommandText = "Select [Путь к папке] From [Преподаватель] Where [№ преподавателя]='" + numTeacher + "'";
                //SqlDataReader dr = scommand.ExecuteReader();
                //while (dr.Read())
                //{
                //    PathExercise = PathExercise + dr[0].ToString();
                //} dr.Close();
                SqlCommand scommands = new SqlCommand();
                scommands.Connection = sconn;
                scommands.CommandText = "Select [Ссылка на работу] From [Выполненная задача] Where [№ задачи]='" + NumberExercise + "' and [№ студента]='" + numStud + "'";
                SqlDataReader drs = scommands.ExecuteReader();
                while (drs.Read())
                {
                    PathExercise = PathExercise + "\\"+drs[0].ToString();
                } drs.Close();
            } sconn.Close();
        }
        public void SelectStudPath()
        {
            SqlConnection sconn = new SqlConnection(ConnectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommands = new SqlCommand();
                scommands.Connection = sconn;
                scommands.CommandText = "Select [Ссылка на работы] From [Студент] Where [№ студента]='" + numStud + "'";
                SqlDataReader drs = scommands.ExecuteReader();
                while (drs.Read())
                {
                    studentPath = drs[0].ToString();
                } drs.Close();
            } sconn.Close();
        }
        public void Compile(string _path)
        {
            newproc = new Process();
            Infa("Компиляция задачи ...");
            int pos1=_path.LastIndexOf(@"\");
            //string tempname = _path.Substring(pos1 + 1);
            tempname = _path.Substring(pos1 + 1);
            tempname = tempname.Remove(tempname.Length - 3, 3);
            string temp = "/out:" + tempname + ".exe" + " " + "\"" + _path + "\"";
            try
            {
                //Process newproc = new Process();
                newproc.StartInfo.FileName = PathExec;
                newproc.StartInfo.Arguments = temp;
                newproc.Start();
                try
                {
                    if (newproc.WaitForExit(5000) == true)
                    {
                        if (!File.Exists(Application.StartupPath + "\\" + tempname + ".exe"))
                        {
                            AllRight = false;
                            Infa("Ошибка компиляции.");
                        }
                    }
                    else
                    {
                        SqlConnection connStart = new SqlConnection(ConnectionString);
                        using (connStart)
                        {
                            connStart.Open();
                            SqlCommand scommand = new SqlCommand();
                            scommand.Connection = connStart;
                            scommand.CommandText = "Update [Выполненная задача] Set Балл=" + 0 + " Where [№ задачи]='" + NumberExercise + "' and [№ студента]='" + numStud + "'";
                            scommand.ExecuteNonQuery();
                        } connStart.Close();
                        AllRight = false;
                    }
                }
                catch (Exception el)
                { MessageBox.Show(el.Message); }

            }
            catch (Exception el)
            {
                MessageBox.Show(el.Message);
            }
            newproc = null;
            if (AllRight == true)
            {
                Infa("Компиляция прошла успешно.");
            }
        }
        public void StartProverka()
        {
            SqlConnection connStart = new SqlConnection(ConnectionString);
            using (connStart)
            {
                connStart.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = connStart;
                scommand.CommandText = "Select [№ проверки] From [Проверка] Where [Проверка].[№ задачи]=" + "'" + NumberExercise.ToString() + "'";
                SqlDataReader dr = scommand.ExecuteReader();
                while (dr.Read())
                {
                    Infa("Запуск теста № " + TekTest + ".");
                    Test(Int32.Parse(dr[0].ToString()));
                    TekTest++;
                }
                dr.Close();
                scommand = new SqlCommand();
                scommand.Connection = connStart;
                scommand.CommandText = "Select [Максимальный балл] from [Вершина],[Задача] where [Вершина].[№ вершины]=[Задача].[№ вершины] and [Задача].[№ задачи]='" + NumberExercise + "'";
                dr = scommand.ExecuteReader();
                int ExBall = -1;
                while (dr.Read())
                {
                    ExBall = Int32.Parse(dr[0].ToString());
                }
                dr.Close();
                if (AllRight == true)
                {
                    scommand.CommandText = "Update [Выполненная задача] Set Балл=" + ExBall + " Where [№ задачи]='" + NumberExercise + "'";
                    try
                    {
                        scommand.ExecuteNonQuery();
                        SelectStudPath();
                        File.Copy(PathExercise, PathPrograms+PrepodPath +studentPath+tempname+".cs");
                        //File.Copy()
                    }
                    catch (IOException copyError)
                    {
                        MessageBox.Show(copyError.Message);
                    }
                    finally
                    {
                        //удалением сделать Path
                        //string path = studentPath + ofd.SafeFileName;
                        string path = studentPath + tempname + ".cs";
                        insertTask(path, NumberExercise);
                    }
                    Infa("Поздравляем! Ваша программа прошла все тесты.");
                    Infa("Работа сдана.");
                }
                else
                {
                    scommand.CommandText = "Update [Выполненная задача] Set Балл=" + 0 + " Where [№ задачи]='" + NumberExercise + "'";
                    try
                    {
                        scommand.ExecuteNonQuery();
                    }
                    catch (Exception copyError)
                    {
                        MessageBox.Show(copyError.Message);
                    }
                    Infa("Увы! Ваша программа не прошла все тесты.");
                    Infa("Работа не сдана.");
                }
                //}
            }
        }
        public void Test(int _i)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            using (conn)
            {
                conn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = conn;
                scommand.CommandText = "Select [Входные данные].[№ параметра],[Входные данные].Значение From [Проверка],[Входные данные] Where [Проверка].[№ проверки]=[Входные данные].[№ проверки] and [Проверка].[№ проверки]=" + "'" + _i + "'";
                SqlDataReader dr = scommand.ExecuteReader();
                string temp = "";
                int k = 0;
                while (dr.Read())
                {
                    temp = temp + " " + dr[1].ToString();
                    temp = temp.TrimEnd();
                }
                dr.Close();
                temp = temp.TrimStart();
                scommand.CommandText = "Select [Выходные данные].[№ параметра],[Выходные данные].Значение From [Проверка],[Выходные данные] Where [Проверка].[№ проверки]=[Выходные данные].[№ проверки] and [Проверка].[№ проверки]=" + "'" + _i + "'";
                dr = scommand.ExecuteReader();
                string ans="";
                while (dr.Read())
                {
                    answers[k] = dr[1].ToString();
                    ans=ans+answers[k]+" ";
                    k++;
                }
                dr.Close();
                Infa("Входные параметры = " + temp + ", выходные параметры = " + ans);
           // } conn.Close();
                ///ТУТ!!!!
           // string tempname = _file.Remove(_file.Length - 3, 3);
            //string tempname = "";  
            //tempname = tempname.Remove(0, PathPrograms.Count());
            try
            {
                newproc = new Process();
                newproc.StartInfo.FileName = Application.StartupPath + "\\" + tempname + ".exe";
                newproc.StartInfo.Arguments = "\"" + PathPrograms + "\\" + tempname + ".txt" + "\""+" " + temp;////СМЕНИЛИ 27 числа
                newproc.Start();
                var temp1 = newproc.Handle;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при выполнении");
            }
            try
            {
                if (newproc.WaitForExit(20000) == true)
                    ///ТУТ!!!!
                    Check(answers, PathPrograms+"\\"+tempname+".txt");
                    //MessageBox.Show("Надо доделать");
                else
                {
                    newproc.Kill();
                    newproc.WaitForExit();
                    AllRight = false;
                }
            }
            catch (Exception el)
            {
                MessageBox.Show(el.Message, "Ошибка при выполнении.");

            }
          }
        }
        public void Check(string[] _answ, string _file)
        {
            string results = "";
            using (StreamReader sr = new StreamReader(_file, System.Text.Encoding.Default))
            {
                results = sr.ReadLine();
                while (results != "Answers:")
                {
                    results = sr.ReadLine();
                    // MessageBox.Show(results);
                }
                int index = 0;
                string tempasnwer = "";
                //while (_answ[index] != null)
                //{
                //    string youansw = sr.ReadLine();
                //    tempasnwer = tempasnwer + youansw;
                //    //Infa("Ваш ответ: " + youansw);
                //    if (_answ[index] == youansw)
                //    {
                //        AllRight = AllRight && true;
                //    }
                //    else
                //    {
                //        AllRight = AllRight && false;
                //    }
                //    index++;
                //}
                string[] myAnswers = new string[100];
                int newindex = 0;
                while(!sr.EndOfStream)
                {
                    myAnswers[0] = sr.ReadLine();
                    tempasnwer = tempasnwer + " " + myAnswers[0];
                    newindex++;
                }
                Infa("Ваш ответ: " + tempasnwer);
                if (_answ.SequenceEqual(myAnswers)==true)
                {
                    AllRight = AllRight && true;
                }
                else
                {
                    AllRight = AllRight && false;
                }
                //Infa("Ваш ответ: " + tempasnwer);
                //sr.ReadLine();
                //if (sr.EndOfStream == true)
                //    sr.Close();
                //else
                //{
                //    AllRight = AllRight && false;
                //    sr.Close();
                //}
                if (AllRight==true)
                    Infa("Ваш ответ верный.");
                else
                    Infa("Ваш ответ неверный.");
            }
        }

        public void SelectPathPrepod(string _numprepod)
        {

        }

        void insertTask(string path, string numTask)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);//SqlConnection connStart = new SqlConnection(ConnectionString);
            try
            {
                //SqlConnection conn = new SqlConnection();
                conn.Open();
                SqlCommand comm=new SqlCommand();
                comm.Connection = conn;
                DateTime date = Convert.ToDateTime(DateTime.Today.ToShortDateString());
                //DateTime.Today.ToShortDateString(); ;
                comm.CommandText = "update  [Выполненная задача] set [Ссылка на работу] = '" + path + "', [Дата сдачи]='" + date.ToShortDateString() +"' where [№ задачи] = '" + numTask + "' and [№ студента] = '" + numStud + "'";
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

        private void BlackBox_Load(object sender, EventArgs e)
        {
            SelectInfoStud();
        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Podgotovka();
            //SelectFIOstud();
            Infa("Тестирование проходит: " + FioStud);
            Infa("Проверяется задача: " + NumberExercise);
            //SelectPathExercise();
            Compile(PathExercise);
            //Infa("Компиляция прошла успешно");
            if (AllRight == true)
            {
                StartProverka();
            }
            //else
            //{
            Infa("Проверка закончена.");
            DeleteTempFile();
            //}
        }
        public void DeleteTempFile()
        {
            if (tempname != "")
                if (File.Exists(PathPrograms + "\\" + tempname + ".exe"))
                {
                    File.Delete(PathPrograms + "\\" + tempname + ".exe");
                    if (File.Exists(PathPrograms + "\\" + tempname + ".txt"))
                        File.Delete(PathPrograms + "\\" + tempname + ".txt");
                }
        }
        public void Podgotovka()
        {
            AllRight = true;
            answers = new string[100];
            TekTest = 1;
            Infa("-------------------------------------------------------");
            DeleteTempFile();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}