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
    public partial class Form1 : Form
    {
        //создать список процессов, сколько задач столько процессов.

        string PathExec = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\csc.exe";
        string PathDirectory = "C:\\Programs\\";
        public int numberCore = 2;//!!!
        //public bool Right = true;
        string ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public int y=-1;
        public string[] numberExercises;
        public FileInfo Tekfile;
        public List<Thread> _thread = new List<Thread>();
        //public List<FileInfo> _file = new List<FileInfo>();
        public string[] filepath = new string[100];
        public bool[] Right = new bool[100];
        public Process newproc;
       // public int i = 0;
        //public string[] answers = new string[50];
        public struct AnswStr
        {
            public string[] answers;
            public int number;
        }

        public struct parametrs
        {
            public int y;
            public string fullName;
        }

        List<AnswStr> answ = new List<AnswStr>();
        List<Process> proc = new List<Process>();
        public Thread num;

        public Form1(string[] _args)
        {
            InitializeComponent();
            numberExercises = new string[_args.Count()];
            for (int h=0;h<=_args.Count()-1;h++)
            {
                numberExercises[h] = _args[h];
            }
            y = 0;
            for (int h = 0; h <= 99;h++ )
            {
                AnswStr num=new AnswStr();
                num.answers = new string[50];
                num.number = -1;
                answ.Add(num);
                Process newpr = new Process();
                proc.Add(newpr);
            }
            //StartCheck(y);
        }

        public void Starting(object data)
        {
            parametrs p = (parametrs)data;
            int y = p.y;
            //answ[Thread.CurrentThread.ManagedThreadId].number = y;
            filepath[Thread.CurrentThread.ManagedThreadId] = Tekfile.FullName;
            Right[Thread.CurrentThread.ManagedThreadId] = true;
            //Compile(filepath[Thread.CurrentThread.ManagedThreadId]);
            //Thread.Sleep(10000);
           // string tempname = filepath[Thread.CurrentThread.ManagedThreadId].Remove(filepath[Thread.CurrentThread.ManagedThreadId].Length - 3, 3);
           // tempname = tempname.Remove(0, PathDirectory.Count());
           // if (File.Exists(Application.StartupPath + "\\" + tempname + ".exe"))
            //{
                SqlConnection connStart = new SqlConnection(ConnectionString);
                using (connStart)
                {
                    try
                    {
                        connStart.Open();
                    }
                    catch(Exception el)
                    {
                        MessageBox.Show(el.Message);
                    }
                    SqlCommand scommand = new SqlCommand();
                    scommand.Connection = connStart;
                    scommand.CommandText = "Select [№ проверки] From [Проверка] Where [Проверка].[№ задачи]=" + "'" + numberExercises[y].ToString() + "'";
                    SqlDataReader dr = scommand.ExecuteReader();
                    while (dr.Read())
                    {
                        Test(Int32.Parse(dr[0].ToString()), filepath[Thread.CurrentThread.ManagedThreadId]);
                    }
                    dr.Close();
                    scommand = new SqlCommand();
                    scommand.Connection = connStart;
                    scommand.CommandText = "Select [Максимальный балл] from [Задача] where [№ задачи]='" + numberExercises[y] + "'";
                    dr = scommand.ExecuteReader();
                    int ExBall = -1;
                    while(dr.Read())
                    {
                        ExBall = Int32.Parse(dr[0].ToString());
                    }
                    dr.Close();
                    if (Right[Thread.CurrentThread.ManagedThreadId] == true)
                        scommand.CommandText = "Update [Выполненная задача] Set Балл="+ExBall+" Where [№ задачи]='"+numberExercises[y]+"'";
                    else
                        scommand.CommandText = "Update [Выполненная задача] Set Балл=" + 0 + " Where [№ задачи]='" + numberExercises[y] + "'";
                    scommand.ExecuteNonQuery();
                    Right[Thread.CurrentThread.ManagedThreadId] = true;
                    //int numb = Thread.CurrentThread.ManagedThreadId;
                    //filepath[numb] = null;
                    //_thread[y].Abort();
                    _thread.RemoveAt(y);
                    //_thread.RemoveAt(_thread[numb]);
                    //Thread.CurrentThread.Abort();
                }
                connStart.Close();
            //}
            //else
            //{
            //    Right[Thread.CurrentThread.ManagedThreadId] = false;
            //    MessageBox.Show("Ошибка компиляции");
            //}
            //if (Right == true && _thread.Count==0)
            //    MessageBox.Show("Все верно");
            //else
            //    MessageBox.Show("Не все решил правильно");
        }

        public void Compile(string _file)
        {
            string tempname = _file.Remove(_file.Length - 3, 3);
            tempname = tempname.Remove(0, PathDirectory.Count());
            string temp = "/out:" + tempname + ".exe" + " " + _file;
            try
            {
                newproc = new Process();
                newproc.StartInfo.FileName = PathExec;
                newproc.StartInfo.Arguments = temp;
                newproc.Start();
                try
                {
                    if (newproc.WaitForExit(5000) == true)
                    {
                        if (!File.Exists(Application.StartupPath + "\\" + tempname + ".exe"))
                        {
                            MessageBox.Show("Ошибка компиляции");
                        }
                    }
                    else
                    {
                        SqlConnection connStart = new SqlConnection(ConnectionString);
                        using (connStart)
                        {
                            SqlCommand scommand = new SqlCommand();
                            scommand.Connection = connStart;
                            scommand.CommandText = "Update [Выполненная задача] Set Балл=" + 0 + " Where [№ задачи]='" + numberExercises[y] + "'";
                            scommand.ExecuteNonQuery();
                            numberExercises[y] = null;
                        }
                        MessageBox.Show("Ошибка компиляции");
                    }
                }
                catch (Exception el)
                { }
            }
            catch (Exception el)
            { }
            newproc = null;
        }

        public void Check(string[] _answ, string _file)
        {
            string results = "";
            string tempname = _file.Remove(_file.Length - 3, 3);
            tempname = tempname.Remove(0, PathDirectory.Count());
            using (StreamReader sr = new StreamReader(PathDirectory + tempname + ".txt", System.Text.Encoding.Default))
            {
                results = sr.ReadLine();
                while (results != "Answers:")
                {
                    results = sr.ReadLine();
                    // MessageBox.Show(results);
                }
                int index = 0;
                while (_answ[index] != null)
                {
                    if (_answ[index] == sr.ReadLine())
                        Right[Thread.CurrentThread.ManagedThreadId] = Right[Thread.CurrentThread.ManagedThreadId] && true;
                    else
                        Right[Thread.CurrentThread.ManagedThreadId] = Right[Thread.CurrentThread.ManagedThreadId] && false;
                    index++;
                }
                sr.ReadLine();
                if (sr.EndOfStream == true)
                    sr.Close();
                else
                {
                    Right[Thread.CurrentThread.ManagedThreadId] = Right[Thread.CurrentThread.ManagedThreadId] && false;
                    sr.Close();
                }
            }
           // _thread.RemoveAt(_thread.IndexOf(num));
        }

        public void Test(int _i, string _file)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            using (conn)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception el)
                {
                    MessageBox.Show(el.Message);
                }
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
                while (dr.Read())
                {
                    answ[Thread.CurrentThread.ManagedThreadId].answers[k] = dr[1].ToString();
                    k++;
                }
                dr.Close();
                string tempname = _file.Remove(_file.Length - 3, 3);
                tempname = tempname.Remove(0, PathDirectory.Count());
                try
                {
                    //Thread.Sleep(3000);
                    newproc = new Process();
                    newproc.StartInfo.FileName = Application.StartupPath + "\\" + tempname + ".exe";
                    newproc.StartInfo.Arguments = temp;
                    //newproc.Start();
                    proc[Thread.CurrentThread.ManagedThreadId] = newproc;
                    proc[Thread.CurrentThread.ManagedThreadId].Start();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка при выполнении");
                }
                //System.Diagnostics.Process.Start(Application.StartupPath + "\\" + tempname + ".exe", temp);
                //System.Diagnostics.Process.GetCurrentProcess
                //timer1.Start();
                try
                    {
                        if (proc[Thread.CurrentThread.ManagedThreadId].WaitForExit(20000) == true)
                         Check(answ[Thread.CurrentThread.ManagedThreadId].answers, _file);
                     else
                     {
                         proc[Thread.CurrentThread.ManagedThreadId].Kill();
                         //ЗАПОМНИТЬ//newproc.WaitForExit()
                         //убить поток num
                         // num.Abort();
                         //_thread.RemoveAt(_thread.IndexOf(num));
                         //_thread[y].Abort();
                         _thread.RemoveAt(y);
                         Right[Thread.CurrentThread.ManagedThreadId] = false;
                         StartCheck(y + 1);

                     }
                    }
                catch(Exception el)
                    { }
               // if (newproc!=null
                //else
                //{
                //    Check(answers, _file);
                //}
                //System.Threading.Thread.Sleep(5000);

                //Check(answers, _file);
            }
            conn.Close();
        }
       
        void StartCheck(int y)
        {
            SqlConnection sconn = new SqlConnection(ConnectionString);
              using (sconn)
              {
                  try
                  {
                      sconn.Open();
                  }
                  catch (Exception el)
                  {
                      MessageBox.Show(el.Message);
                  }
                 SqlCommand scommand = new SqlCommand();
                 scommand.Connection = sconn;
                 while (y<=numberExercises.Count()-1)
                 {
                    scommand.CommandText = "Select [Ссылка на работу] From [Выполненная задача] Where [№ задачи]='"+numberExercises[y].ToString()+"'";
                    SqlDataReader dr = scommand.ExecuteReader();
                    while (dr.Read())
                    {
                        Tekfile = new FileInfo(PathDirectory+dr[0].ToString());
                       // _file.Add(Tekfile);
                        //filepath[Thread.CurrentThread.ManagedThreadId] = Tekfile.FullName;
                        //_file[Thread.CurrentThread.ManagedThreadId] = Tekfile;
                      //string filename = _file.Name.Remove(0, PathDirectory.Count());
                      if(_thread.Count()<=numberCore)
                      {
                          num = new Thread(new ParameterizedThreadStart (Starting));
                           _thread.Add(num);
                           parametrs par = new parametrs();
                           par.y = y;
                           par.fullName = Tekfile.FullName;
                           //Compile(par.fullName);
                           num.Start(par);
                           //filepath[Thread.CurrentThread.ManagedThreadId] = Tekfile.FullName;
                        }
                        else
                      {
                          while(_thread.Count!=0)
                          {
                              System.Threading.Thread.Sleep(5000);
                          }
                          StartCheck(y);
                      }
                    }
                    dr.Close();
                    y++;
                 }
              }
              sconn.Close();
            while(_thread.Count!=0)
            {
              //  System.Threading.Thread.Sleep(5000);
            }
            if (_thread.Count == 0)
            {
                MessageBox.Show("Работа закончена");
                Application.ExitThread();
                Application.Exit();
                //MessageBox.Show("Работа закончена");
            }
        }

        void ThreadKill(Thread _name)
        {
            //_name.Kill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sconn = new SqlConnection(ConnectionString);
            using (sconn)
            {
                try
                {
                    sconn.Open();
                }
                catch (Exception el)
                {
                    MessageBox.Show(el.Message);
                }
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                while (y <= numberExercises.Count() - 1)
                {
                    scommand.CommandText = "Select [Ссылка на работу] From [Выполненная задача] Where [№ задачи]='" + numberExercises[y].ToString() + "'";
                    SqlDataReader dr = scommand.ExecuteReader();
                    while (dr.Read())
                    {
                        Tekfile = new FileInfo(PathDirectory + dr[0].ToString());
                        Compile(Tekfile.FullName);
                    }
                    dr.Close();
                    y++;
                }
            } sconn.Close();
            y = 0;
            Tekfile = null;
            StartCheck(y);
            pgBar.Style = ProgressBarStyle.Marquee;
            button1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstBox.Items.Add("Готово к работе.");
            pgBar.Style = ProgressBarStyle.Blocks;
        }

    }
}
