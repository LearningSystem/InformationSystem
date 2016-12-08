using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;

namespace NewBlackBox
{
    public partial class BlackBox : Form
    {
        string PathExec = SaveSettings.CompilerPath;
        string PathPrograms = Application.StartupPath;
        //string ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        string temps;
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
        OpenFileDialog ofd;
        public BlackBox(string _numStud, string _numTeacher)
        {
            InitializeComponent();
            numStud = _numStud;
            //numTeacher = _numTeacher;
            //NumberExercise = _args[1];
            //PathExercise = _pathexercise;
            //File.Create(PathPrograms + "\\Users\\" + numStud + " " + System.DateTime.Now.ToLongDateString()+".txt");
            //string Shedule=numStud;
            temps = PathPrograms + "\\Users\\" + numStud + " " + System.DateTime.Now.ToShortDateString() + " ";
            temps = temps+System.DateTime.Now.ToLongTimeString().Replace(":", ".")+".txt";
            File.WriteAllText(temps,System.DateTime.Now.ToLongDateString()+ numStud + " начал(-а) работу в системе. \r\n");
        }
        public void Infa(string _selectinfa)
        {
            lstBox.Items.Add(_selectinfa);
            File.AppendAllText(temps, _selectinfa+"\r\n");
        }
        public void SelectInfoStud()
        {
            string TaskPath=Application.StartupPath;
            //lbl1.Text = FioStud;
            lbl1.Text=numStud;
            //lbl2.Text = groupStud;
            lbl3.Text=System.DateTime.Now.ToLongDateString();

            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\Exercises\\");
                //int max = 0;
            foreach (FileInfo file in dir.GetFiles("*.rtf"))
            {
                //MessageBox.Show(dir.GetFiles("*.txt").Max().ToString());
                int oneIndex = file.FullName.IndexOf(".");
                string temp = file.FullName.Remove(oneIndex, 4);
                int IndexTwo = temp.LastIndexOf("\\");
                temp = temp.Remove(0, IndexTwo + 1);
                comboBox1.Items.Add(temp);
            }
            if (comboBox1.Text == "")
                стартToolStripMenuItem.Enabled = false;
        ///---Сделать загрузку текста задачи на экран  
        //    rtbTask.LoadFile(TaskPath);
        }

        //public void SelectPathExercise()
        //{
        //    PathExercise = Application.StartupPath;
        //    SqlConnection sconn = new SqlConnection(ConnectionString);
        //    using (sconn)
        //    {
        //        sconn.Open();
        //        //SqlCommand scommand = new SqlCommand();
        //        //scommand.CommandText = "Select [Путь к папке] From [Преподаватель] Where [№ преподавателя]='" + numTeacher + "'";
        //        //SqlDataReader dr = scommand.ExecuteReader();
        //        //while (dr.Read())
        //        //{
        //        //    PathExercise = PathExercise + dr[0].ToString();
        //        //} dr.Close();
        //        SqlCommand scommands = new SqlCommand();
        //        scommands.Connection = sconn;
        //        scommands.CommandText = "Select [Ссылка на работу] From [Выполненная задача] Where [№ задачи]='" + NumberExercise + "' and [№ студента]='" + numStud + "'";
        //        SqlDataReader drs = scommands.ExecuteReader();
        //        while (drs.Read())
        //        {
        //            PathExercise = PathExercise + "\\"+drs[0].ToString();
        //        } drs.Close();
        //    } sconn.Close();
        //}
        //public void SelectStudPath()
        //{
        //    SqlConnection sconn = new SqlConnection(ConnectionString);
        //    using (sconn)
        //    {
        //        sconn.Open();
        //        SqlCommand scommands = new SqlCommand();
        //        scommands.Connection = sconn;
        //        scommands.CommandText = "Select [Ссылка на работы] From [Студент] Where [№ студента]='" + numStud + "'";
        //        SqlDataReader drs = scommands.ExecuteReader();
        //        while (drs.Read())
        //        {
        //            studentPath = drs[0].ToString();
        //        } drs.Close();
        //    } sconn.Close();
        //}
        public void Compile(string _path)
        {
            newproc = new Process();
            Infa("Компиляция задачи ...");
            int pos1 = _path.LastIndexOf(@"\");
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
                            Infa("Ошибка компиляции. 0 баллов");
                        }
                    }
                    else
                    {
                        //File.AppendAllText(PathPrograms + "\\Users\\" + numStud + " " + System.DateTime.Now.ToLongDateString(), "Программа не скомпилировалась. 0 Баллов.");
                        Infa("Программа не скомпилировалась. 0 Баллов.");
                        AllRight = false;
                    }
                }
                catch (Exception el)
                { 
                    MessageBox.Show(el.Message);
                    AllRight = false;
                }
            }
            catch (Exception el)
            {
                MessageBox.Show(el.Message);
                AllRight = false;
            }
            newproc = null;
            if (AllRight == true)
            {
                Infa("Компиляция прошла успешно.");
            }
        }
        public void StartProverka()
        {
            //TekTest=1;
            //DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\Tests\\" + NumberExercise+"\\");ТУТ!
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\Tests\\"+comboBox1.Text+"\\");
            foreach (FileInfo file in dir.GetFiles("*.txt"))
                {
                    if (AllRight)
                    {
                        Infa("Запуск теста № " + TekTest + ".");
                        Test(file.FullName);
                        TekTest++;
                    }
                }
            //---Вставка про макс. Балл!!
            if (AllRight == true)
            {
                string sostav = rtbTask.Text;
                int start = rtbTask.Find("Max score:");
                start = start + 10;
                string tempus = "";
                for (int i = start; i < sostav.Count(); i++)
                    tempus = tempus + sostav[i];
                Infa("Максимальный балл!" +" "+ Int32.Parse(tempus).ToString() + " баллов.");
            }
                if (AllRight == true)
                {
                    try
                    {
                       // File.Copy(numStud+" "+ label1.Text+" "+comboBox1.Text, Application.StartupPath + "\\Source\\" + numStud + " " + System.DateTime.Now.ToShortDateString() + ".cs");
                        File.Copy(ofd.FileName, Application.StartupPath + "\\Source\\" + numStud + " " + System.DateTime.Now.ToShortDateString() + ".cs");
                        //MessageBox.Show(Application.StartupPath + "\\Source\\" + numStud + " " + System.DateTime.Now.ToShortDateString() + ".cs");
                        //MessageBox.Show(Application.StartupPath + "\\Source\\" + numStud + " " + label1.Text + " " + comboBox1.Text + " " + System.DateTime.Now.ToShortDateString() + ".cs");
                        File.Move(Application.StartupPath + "\\Source\\" + numStud + " " + System.DateTime.Now.ToShortDateString() + ".cs", Application.StartupPath + "\\Source\\" + numStud + " " + "Задача"+" "+comboBox1.Text + " " + System.DateTime.Now.ToShortDateString()+".cs");
                    }
                    catch (Exception copyError)
                    {
                        MessageBox.Show(copyError.Message);
                    }
                    finally
                    {
                        //удалением сделать Path
                        //string path = studentPath + ofd.SafeFileName;
                        string path = studentPath + tempname + ".cs";
                        //insertTask(path, NumberExercise);
                    }
                    Infa("Поздравляем! Ваша программа прошла все тесты.");
                    Infa("Работа сдана.");
                }
                else
                {
                    Infa("Увы! Ваша программа не прошла все тесты.");
                    Infa("Работа не сдана.");
                }
        }

        public void Test(string _file)
        {
                string temp = "";
                string line;
                int k = 0;
                StreamReader str=new StreamReader(_file);
                line = str.ReadLine();
                while(line !="Answers:")
                {
                    if (line!="Parameters:")
                    {
                        temp = temp + " " + line;
                        temp = temp.TrimEnd();
                    }
                    line = str.ReadLine();
                }
                //dr.Close();
                temp = temp.TrimStart();
                //scommand.CommandText = "Select [Выходные данные].[№ параметра],[Выходные данные].Значение From [Проверка],[Выходные данные] Where [Проверка].[№ проверки]=[Выходные данные].[№ проверки] and [Проверка].[№ проверки]=" + "'" + _i + "'";
                //dr = scommand.ExecuteReader();
                string ans = "";
                string temp_line=str.ReadLine();
                while (temp_line!= null)//СЮДА 
                {
                    answers[k] = temp_line;
                    ans = ans + answers[k] + " ";
                    k++;
                    temp_line = str.ReadLine();
                }
                //dr.Close();
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
                    newproc.StartInfo.Arguments = "\"" + PathPrograms + "\\" + tempname + ".txt" + "\"" + " " + temp;////СМЕНИЛИ 27 числа
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
                        Check(answers, PathPrograms + "\\" + tempname + ".txt");
                    //MessageBox.Show("Надо доделать");
                    else
                    {
                        newproc.Kill();
                        newproc.WaitForExit();
                        AllRight = false;
                        Infa("Ваша программа зациклилась.");
                    }
                }
                catch (Exception el)
                {
                    MessageBox.Show(el.Message, "Ошибка при выполнении.");

                }
            }

        public void Check(string[] _answ, string _file)
        {
            string results = "";
            
            using (StreamReader sr = new StreamReader(_file, System.Text.Encoding.Default))
            {
                if (!sr.EndOfStream)
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
                    while (!sr.EndOfStream)
                    //string line = sr.ReadLine();
                    //while (line!="Max score:")
                    {
                        myAnswers[newindex] = sr.ReadLine();
                        tempasnwer = tempasnwer + " " + myAnswers[newindex];
                        newindex++;
                        //line = sr.ReadLine();
                    }
                    Infa("Ваш ответ: " + tempasnwer);
                    if (_answ.SequenceEqual(myAnswers) == true)
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
                    if (AllRight == true)
                        Infa("Ваш ответ верный.");
                    else
                        Infa("Ваш ответ неверный.");
                }
                else
                {
                    AllRight = false;
                    Infa("При запуске вашей программы с нужными значениями, ваша программа произошла ошибка! Проверьте ваш код и попробуйте еще раз.");
                }
            }
        }

        public void SelectPathPrepod(string _numprepod)
        {

        }

        private void BlackBox_Load(object sender, EventArgs e)
        {
            SelectInfoStud();
        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            
            DialogResult res = ofd.ShowDialog();
            ofd.Filter = "cs files (*.cs)|*.cs";
            string[] tasks = new string[2];
            if (res == DialogResult.OK)
            {
                if (!File.Exists(Application.StartupPath + "\\Tests\\" + ofd.SafeFileName))
                {
                    //запускаем проверку
                    //string[] tasks = new string[2];
                    //tasks[1] = numTask;ТУТ!!
                    tasks[1] = comboBox1.Text;
                    PathExercise = ofd.FileName;
                    //--
                    Podgotovka();
                    Infa("Тестирование проходит: " + numStud);
                    Infa("Проверяется задача: " + tasks[1]);
                    Compile(PathExercise);
                    if (AllRight == true)
                    {
                        StartProverka();
                    }
                    Infa("Проверка закончена.");
                    DeleteTempFile();
                }
                else
                    MessageBox.Show("Такое имя уже существует. Переименуйте файл!");
            }
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
            //TekTest = 1;
            Infa("-------------------------------------------------------");
            //DeleteTempFile();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //File.AppendAllText(temps, System.DateTime.Now.ToLongDateString() + numStud + " закончил(-а) работу в системе. \r\n");
            Infa(System.DateTime.Now.ToLongDateString() + numStud + " закончил(-а) работу в системе. \r\n");
            this.Hide();
            regForm regf = new regForm();
            regf.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            стартToolStripMenuItem.Enabled = true;
            //rtbTask.Text = File.ReadAllText(Application.StartupPath + "\\Exercises\\" + comboBox1.Text + ".rtf");
            rtbTask.LoadFile(Application.StartupPath + "\\Exercises\\" + comboBox1.Text + ".rtf");
            rtbTask.Enabled = false;
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helpForm hf = new helpForm("Студент");
            hf.Show();
        }
    }
}