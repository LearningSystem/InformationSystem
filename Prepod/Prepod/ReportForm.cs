using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace Prepod
{
    public partial class ReportForm : Form
    {
        string TestTheme = null;
        int StudBall = 0;
        int StudTime=0;
        int NumStud = -1;
        int idTest = -1;
        List<TextQuestion> Questions = new List<TextQuestion>();
        List<TestAnswers> Answers = new List<TestAnswers>();
        int[] notRightAnswer;

        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public ReportForm(int _idTest,int _NumStud,string _theme, int _ball, int _time, List<TextQuestion> _questions, int[] _mass, List<TestAnswers> _answers)
        {
            InitializeComponent();
            idTest = _idTest;
            NumStud = _NumStud;
            TestTheme = _theme;
            StudBall=_ball;
            StudTime=_time;
            Questions = _questions;
            notRightAnswer = _mass;
            Answers = _answers;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            lblName.Text="Имя";
            lblGroup.Text = "Группа";
            lblTheme.Text = TestTheme;
            lblBall.Text = StudBall.ToString();
            DoStart();
            CreateTree();
        }
        void CreateTree()
        {
            int m = 0;
            for (int j = 0; j <= Questions.Count - 1; j++)
            {
                int number = j + 1;
                int index = treeViewTest.Nodes.Add("Вопрос №" + number).Index;
                if (File.Exists(Questions[j].question))
                    treeViewTest.Nodes[index].Nodes.Add("Текст вопроса: " + "представлен картинкой");
                else
                    treeViewTest.Nodes[index].Nodes.Add("Текст вопроса: " + Questions[j].question);
                string RightAns = "";
                if (Questions[j].type_question == "One")
                {
                    for (int k = 0; k <= 3; k++)
                    {
                        if (Questions[j].rightans[k] != null)
                        {
                            RightAns = Questions[j].rightans[k];
                            treeViewTest.Nodes[index].Nodes.Add("Правильный ответ: " + RightAns);
                        }
                    }

                }
                else
                    if (Questions[j].type_question == "Several")
                    {
                        m = 1;
                        for (int k = 0; k <= 3; k++)
                        {
                            if (Questions[j].rightans[k] != null)
                            {
                                treeViewTest.Nodes[index].Nodes.Add("Правильный ответ № " + m + " : " + Questions[j].rightans[k]);
                                m++;
                            }
                        }
                    }
                    else
                        if (Questions[j].type_question == "Writing")
                            treeViewTest.Nodes[index].Nodes.Add("Правильный ответ: " + Questions[j].rightans[0]);
                        else
                            if (Questions[j].type_question == "Sequence")
                            {
                                m = 1;
                                for (int k = 0; k <= 3; k++)
                                {
                                    if (Questions[j].rightans[k] != null)
                                    {
                                        treeViewTest.Nodes[index].Nodes.Add(" Правильный ответ № " + m + " : " + Questions[j].rightans[k]);
                                        m++;
                                    }
                                }
                            }
                            else
                            {
                                treeViewTest.Nodes[index].Nodes.Add("Правильный ответ: " + Questions[j].rightans[0] + " cоответствует ответу " + Questions[j].rightans[1] + ", а ответ " + Questions[j].rightans[2] + " ответу " + Questions[j].rightans[3]);
                            }
                //ваш ответ
                if ((Answers[j].answer1 != false || Answers[j].answer2 != false || Answers[j].answer3 != false || Answers[j].answer4 != false) || (Answers[j].ans1 != "" || Answers[j].ans2 != "" || Answers[j].ans3 != "" || Answers[j].ans4 != ""))
                {
                    if (Answers[j].answer1 != false || Answers[j].answer2 != false || Answers[j].answer3 != false || Answers[j].answer4 != false)
                    {
                        m = 1;
                        if (Answers[j].answer1 != false)
                        {
                            treeViewTest.Nodes[index].Nodes.Add("Ваш ответ № " + m + ": " + Questions[j].answ1);
                            m++;
                        }
                        if (Answers[j].answer2 != false)
                        {
                            treeViewTest.Nodes[index].Nodes.Add("Ваш ответ № " + m + ": " + Questions[j].answ2);
                            m++;
                        }
                        if (Answers[j].answer3 != false)
                        {
                            treeViewTest.Nodes[index].Nodes.Add("Ваш ответ № " + m + ": " + Questions[j].answ3);
                            m++;
                        }
                        if (Answers[j].answer4 != false)
                        {
                            treeViewTest.Nodes[index].Nodes.Add("Ваш ответ № " + m + ": " + Questions[j].answ4);
                            m++;
                        }
                    }
                    else
                    {
                        if (Questions[j].type_question == "")
                        {
                            m = 1;
                            if (Answers[j].ans1 != "")
                            {
                                treeViewTest.Nodes[index].Nodes.Add("Ваш ответ № " + m + ": " + Answers[j].ans1+" соответствует ответу");
                                m++;
                            }
                            if (Answers[j].ans3 != "")
                            {
                                treeViewTest.Nodes[index].Nodes.Add("Ваш ответ № " + m + ": " + Answers[j].ans3+", а ответ ");
                                m++;
                            }
                            if (Answers[j].ans2 != "")
                            {
                                treeViewTest.Nodes[index].Nodes.Add("Ваш ответ № " + m + ": " + Answers[j].ans2+" ответу ");
                                m++;
                            }
                            if (Answers[j].ans4 != "")
                            {
                                treeViewTest.Nodes[index].Nodes.Add("Ваш ответ № " + m + ": " + Answers[j].ans4);
                                m++;
                            }
                        }
                        else
                        {
                            m = 1;
                            if (Answers[j].ans1 != "")
                            {
                                treeViewTest.Nodes[index].Nodes.Add("Ваш ответ № " + m + ": " + Answers[j].ans1);
                                m++;
                            }
                            if (Answers[j].ans2 != "")
                            {
                                treeViewTest.Nodes[index].Nodes.Add("Ваш ответ № " + m + ": " + Answers[j].ans2);
                                m++;
                            }
                            if (Answers[j].ans3 != "")
                            {
                                treeViewTest.Nodes[index].Nodes.Add("Ваш ответ № " + m + ": " + Answers[j].ans3);
                                m++;
                            }
                            if (Answers[j].ans4 != "")
                            {
                                treeViewTest.Nodes[index].Nodes.Add("Ваш ответ № " + m + ": " + Answers[j].ans4);
                                m++;
                            }
                        }
                    }
                }
                else
                {
                    m = 1;
                    treeViewTest.Nodes[index].Nodes.Add("Ваш ответ: Вы ничего не ответили");
                    //for (int l = 0; l <= 9; l++)
                    //{
                    //    if (Questions[j].part[l] != "")
                    //    {
                    //        treeViewTest.Nodes[index].Nodes.Add("Рекомендация №" + m + "Изучить раздел: " + Questions[j].part[l]);
                    //        m++;
                    //    }
                    //}
                }
                m = Questions.Count;

                for (int h = 0; h <= m - 1; h++)
                {
                    int bl = 1;
                    if (notRightAnswer[h] == j + 1)
                    {
                        for (int y = 0; y <= 9; y++)
                            if (Questions[j].part[y] != null)
                            {
                                treeViewTest.Nodes[index].Nodes.Add("Рекомендация №" + bl + ": Изучить раздел: " + Questions[j].part[y]);
                                bl++;
                            }
                        //bl++;
                    }
                }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            //добавить в БД данные
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "Insert into [Выполненный тест] ([№ теста],[Балл],[Дата сдачи],[Время выполнения],[№ студента]) values (" + "'" + idTest.ToString() + "'" + "," + "'" + StudBall.ToString() + "'" + "," + "'" + System.DateTime.Today.ToShortDateString() + "'" + "," + "'" + (StudTime / 60000000).ToString() + "'" + "," + "'" + NumStud.ToString() + "'" + ")";
            comm.ExecuteNonQuery();

            this.Hide();
            studentWork studWork = new studentWork(NumStud.ToString());
            studWork.Show();
        }
        void DoStart()
        {
            for (int j = 0; j <= Questions.Count - 1; j++)
            {
                if (Answers[j].ans1 == null)
                    Answers[j].ans1 = "";
                if (Answers[j].ans2 == null)
                    Answers[j].ans2 = "";
                if (Answers[j].ans3 == null)
                    Answers[j].ans3 = "";
                if (Answers[j].ans4 == null)
                    Answers[j].ans4 = "";
            }

        }
        private void btnOK_Click(object sender, EventArgs e)
        {

        }

    }
}
