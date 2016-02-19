﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace Prepod
{
    public partial class TestStart : Form
    {
        XmlReader xmlReader;
        //string XmlPath = "C:\\Users\\User\\Desktop\\Текущие проекты\\CreateTest 2.0\\CreateTest 2.0\\bin\\Debug\\СуперТест3.xml";
        ////string XmlPath = Application.StartupPath + "\\" + "Математика.xml";
        string XmlPath=null;
        int numStud = -1;
        public TextQuestion tq = new TextQuestion();
        List<TextQuestion> Questions = new List<TextQuestion>();
        List<TestAnswers> Answers = new List<TestAnswers>();
        public TestAnswers testAns = new TestAnswers();
        int pos = 1;
        string Theme = "";
        int Time = 0;
        public bool Report = false;
        public int t = 0;
        public bool First = false;
        int StudBall = 0;
        int[] NotRightAnswers;
        int numberTekQuest = 0;
        Image img;

        RichTextBox txtB1;
        RichTextBox txtB2;
        RichTextBox txtB3;
        RichTextBox txtB4;

        RadioButton rad1;
        RadioButton rad2;
        RadioButton rad3;
        RadioButton rad4;

        CheckBox cB1;
        CheckBox cB2;
        CheckBox cB3;
        CheckBox cB4;
        Label lbl2;
        Label lbl3;
        Label lbl4;
        Label lbl5;

        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public TestStart(int _numStud,string _pathxml)
        {
            InitializeComponent();
            numStud = _numStud;
            XmlPath = _pathxml;
            xmlReader = new XmlTextReader(XmlPath);
            xmlReader.Read();
        }

        private void TestStart_Load(object sender, EventArgs e)
        {
            if (MessageBox.Show("Для начала тестирования нажмите ОК","Внимание",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                LoadQuestions();
                //for(int h=1;h<=Questions.Count;h++)
                //{
                //    lstQuestion.Items.Add("Вопрос " + h);
                //}
                //rTB.ReadOnly = true;
                pBTime.Maximum = Time;
                pBTime.Minimum = 0;
                //MyTimer.Enabled = true;
                //MyTimer.Start();

                MouseEventArgs events = new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 2, lstQuestion.Items[0].Position.X, lstQuestion.Items[0].Position.Y,0);
                lstQuestion_MouseDoubleClick(lstQuestion.Items[numberTekQuest].Text, events);
            }
            else
            {
                Application.Exit();
               // this.Hide();
            }
        }
        
        void printAnswers(string type)
        {
            string[] answ = new string[4];
           // while (xmlReader.Value == "")
                xmlReader.Read();
            answ = xmlReader.Value.Split('|');
            if (type == "One"||type=="Several"||type=="Sequence"||type=="Comparison")
            {
                tq.answ1 = answ[0];
                tq.answ2 = answ[1];
                tq.answ3 = answ[2];
                tq.answ4 = answ[3];
            }
            else
            {
                tq.answ1 = answ[0];
            }
    }
        
        void printRightAnswers()
        {
            //string[] answ = new string[4];
            xmlReader.Read(); 
            //answ = xmlReader.Value.Split('|');
            //tq.rightans[0] = answ[0];
            //tq.rightans[1] = answ[1];
            //tq.rightans[2] = answ[2];
            //tq.rightans[3] = answ[3];
            string temp = xmlReader.Value.ToString();
            string tmp = "";
            int k = 1;
            for (int h = 0; h < temp.Length; h++)//последний ответ не сохраняется
            {
               if (temp[h].ToString() != "|")//Доработать! не робит
                {
                    tmp = tmp + temp[h];
                }
                else
                {
                    if (tmp == tq.answ1)
                        tq.rightans[0] = tmp;
                    else
                        if (tmp == tq.answ2)
                            tq.rightans[1] = tmp;
                        else
                            if (tmp == tq.answ3)
                                tq.rightans[2] = tmp;
                            else
                                tq.rightans[3] = tmp;
                    tmp = "";
                    k++;
                }
            }
            if (tmp!="")
            {
                if (tmp == tq.answ1)
                    tq.rightans[0] = tmp;
                else
                    if (tmp == tq.answ2)
                        tq.rightans[1] = tmp;
                    else
                        if (tmp == tq.answ3)
                            tq.rightans[2] = tmp;
                        else
                            tq.rightans[3] = tmp;
                tmp = "";
                k++;
            }
        }
        
        void printPart()
        {
            xmlReader.Read();
            string temp = xmlReader.Value.ToString();
            string tmp = "";
            int k = 0;
            if (temp != "")
            {
                for (int h = 0; h < temp.Length; h++)
                {
                    if (temp[h].ToString() != "|")
                    {
                        tmp = tmp + temp[h];
                    }
                    else
                    {
                        tq.part[k] = tmp;
                        tmp = "";
                        k++;
                    }
                }
            }
        }
        
        void LoadQuestions()
        {
            do xmlReader.Read();
            while (xmlReader.Name != "Theme");
            xmlReader.Read();
            Theme = xmlReader.Value.ToString();
            //do xmlReader.Read();
            //while (xmlReader.Name != "Time");
            //Time = Int32.Parse(xmlReader.GetAttribute("Time"));
            //do xmlReader.Read();
            //while (xmlReader.Name != "Report");
            //string tmpRep = xmlReader.GetAttribute("Report");
            //if (tmpRep == "Да")
            //    Report = true;
            //xmlReader.Close();

            do xmlReader.Read();
            while (xmlReader.Name != "Questions");
            int Numbers = Int32.Parse(xmlReader.GetAttribute("Number"));
            while(pos<=Numbers)
            {
                    do xmlReader.Read(); while (xmlReader.Name != "Question" + pos);
                    if (xmlReader.Name == "Question" + pos)
                    {
                        tq.num = pos-1;
                        do xmlReader.Read(); while (xmlReader.Name != "Text");
                        xmlReader.Read();

                        tq.question = xmlReader.Value.ToString();
                        //string temps = tq.question;
                        //while(temps.IndexOf("\\")!=-1)
                        //{
                        //    temps=temps.Replace("\\",@"\");
                        //}
                        //------------------------------------------------------------------------
                        do xmlReader.Read(); while (xmlReader.Name != "TypeAnswer");
                        xmlReader.Read();
                        tq.type_question = xmlReader.Value.ToString();
                        if (tq.type_question == "One")
                        {
                            do xmlReader.Read(); while (xmlReader.Name != "Answers");
                            printAnswers("One");
                            do xmlReader.Read(); while (xmlReader.Name != "RightAnswer");
                            xmlReader.Read();
                            tq.rightans[0] = xmlReader.Value.ToString();
                            do xmlReader.Read(); while (xmlReader.Name != "Part");
                            printPart();
                            do xmlReader.Read(); while (xmlReader.Name != "Price");
                            xmlReader.Read();
                            tq.price = Int32.Parse(xmlReader.Value.ToString());

                        }
                        else
                            if (tq.type_question == "Several")
                            {
                                do xmlReader.Read(); while (xmlReader.Name != "Answers");
                                printAnswers("Several");
                                do xmlReader.Read(); while (xmlReader.Name != "RightAnswer");
                               // xmlReader.Read(); 
                                //printAnswers("Several");
                                printRightAnswers();
                                printPart();
                                do xmlReader.Read(); while (xmlReader.Name != "Price");
                                xmlReader.Read();
                                tq.price = Int32.Parse(xmlReader.Value.ToString());
                            }
                            else
                                if (tq.type_question == "Sequence")
                                {
                                    do xmlReader.Read(); while (xmlReader.Name != "Answers");
                                    printAnswers("Sequence");
                                    do xmlReader.Read(); while (xmlReader.Name != "RightAnswer");
                                    printRightAnswers();
                                    printPart();
                                    do xmlReader.Read(); while (xmlReader.Name != "Price");
                                    xmlReader.Read();
                                    tq.price = Int32.Parse(xmlReader.Value.ToString());
                                }
                                else
                                    if (tq.type_question == "Writing")
                                    {
                                        do xmlReader.Read(); while (xmlReader.Name != "Answers");
                                        printAnswers("Writing");
                                        do xmlReader.Read(); while (xmlReader.Name != "RightAnswer");
                                        xmlReader.Read();
                                        tq.rightans[0] = xmlReader.Value.ToString();
                                        printPart();

                                        do xmlReader.Read(); while (xmlReader.Name != "Price");
                                        xmlReader.Read();
                                        tq.price = Int32.Parse(xmlReader.Value.ToString());
                                    }
                                    else
                                    {
                                        do xmlReader.Read(); while (xmlReader.Name != "Answers");
                                        printAnswers("Comparison");
                                        do xmlReader.Read(); while (xmlReader.Name != "RightAnswer");
                                        xmlReader.Read();
                                        string temp = xmlReader.Value.ToString();
                                        int oneid = temp.IndexOf("==");
                                        string one = "";
                                        for (int h = 0; h < oneid; h++)
                                        {
                                            one = one + temp[h];
                                        }
                                        tq.rightans[0] = one;
                                        int twoid = temp.IndexOf("|");
                                        string two = "";
                                        for (int h = oneid + 2; h < twoid; h++)
                                        {
                                            two = two + temp[h];
                                        }
                                        tq.rightans[1] = two;
                                        oneid = temp.LastIndexOf("==");
                                        one = "";
                                        two = "";
                                        for (int h = twoid + 1; h < oneid; h++)
                                        {
                                            one = one + temp[h];
                                        }
                                        tq.rightans[2] = one;
                                        for (int h = oneid + 2; h < temp.Length; h++)
                                        {
                                            two = two + temp[h];
                                        }
                                        tq.rightans[3] = two;
                                        printPart();
                                        do xmlReader.Read(); while (xmlReader.Name != "Price");
                                        xmlReader.Read();
                                        tq.price = Int32.Parse(xmlReader.Value.ToString());
                                    }
                    }
                    pos++;
                Questions.Add(tq);
                int index=Questions.IndexOf(tq);

                int numbQuest = pos-1;
                int index2=lstQuestion.Items.Add("Вопрос " + numbQuest).Index;
                lstQuestion.Items[index2].Tag = index;
                testAns = new TestAnswers();
                testAns.NumberQuestion = index;
                Answers.Add(testAns);
                //lstQuestion.Items[pos--].Tag = index;
                tq = new TextQuestion();
                //do xmlReader.Read(); while (xmlReader.Name != "Price");
                //do xmlReader.Read(); while (xmlReader.Name != "Question"+pos--);
                xmlReader.Read();
                };//while(xmlReader.Name!="Questions");
            do
            {
                xmlReader.Read();
            } while (xmlReader.Name != "Time");
            xmlReader.Read();
            Time = Int32.Parse(xmlReader.Value.ToString());
            do
            {
                xmlReader.Read();
            } while (xmlReader.Name != "Report");
            xmlReader.Read();
            string tempRep = xmlReader.Value.ToString();
            if (tempRep == "Нет")
                Report = false;
            else
                Report = true;
            NotRightAnswers = new int[Questions.Count];
   }
   
        void CreateElement(int _ind)
        {
           if (Questions[_ind].type_question == "One")
           {
               Clear();
               #region Создание дин.элементов для одного ответа
               txtB1 = new RichTextBox();
               txtB2 = new RichTextBox();
               txtB3 = new RichTextBox();
               txtB4 = new RichTextBox();

               rad1 = new RadioButton();
               rad2 = new RadioButton();
               rad3 = new RadioButton();
               rad4 = new RadioButton();
               //-------------------------
               txtB1.Name = "txtBQuest1";
               txtB1.Location = new Point(32, 53);
               txtB1.Size = new Size(278, 35);
               //txtB1.TextChanged += rtBQuestion_TextChanged;
               gB3.Controls.Add(txtB1);

               rad1.Name = "radQuest1";
               rad1.Location = new Point(14, 61);
               rad1.Size = new Size(14, 13);
               gB3.Controls.Add(rad1);
               //-------------------------
               txtB2.Name = "txtBQuest2";
               txtB2.Location = new Point(32, 132);
               txtB2.Size = new Size(278, 35);
               //txtB2.TextChanged += rtBQuestion_TextChanged;
               gB3.Controls.Add(txtB2);

               rad2.Name = "radQuest2";
               rad2.Location = new Point(14, 144);
               rad2.Size = new Size(14, 13);
               gB3.Controls.Add(rad2);
               //-------------------------

               txtB3.Name = "txtBQuest3";
               txtB3.Location = new Point(347, 53);
               txtB3.Size = new Size(278, 35);
               //txtB3.TextChanged += rtBQuestion_TextChanged;
               gB3.Controls.Add(txtB3);

               rad3.Name = "radQuest3";
               rad3.Location = new Point(332, 61);
               rad3.Size = new Size(14, 13);
               gB3.Controls.Add(rad3);
               //-------------------------
               txtB4.Name = "txtBQuest4";
               txtB4.Location = new Point(347, 132);
               txtB4.Size = new Size(278, 35);
               //txtB4.TextChanged += rtBQuestion_TextChanged;
               gB3.Controls.Add(txtB4);

               rad4.Name = "radQuest4";
               rad4.Location = new Point(332, 144);
               rad4.Size = new Size(14, 13);
               gB3.Controls.Add(rad4);
               label6.Visible = false;
               label7.Visible = false;
               //-------------------------
               #endregion
               //NumberList.Value = numList1.Value;
               txtB1.Text = Questions[_ind].answ1;
               txtB2.Text = Questions[_ind].answ2;
               txtB3.Text = Questions[_ind].answ3;
               txtB4.Text = Questions[_ind].answ4;
               txtB1.ReadOnly = true;
               txtB2.ReadOnly = true;
               txtB3.ReadOnly = true;
               txtB4.ReadOnly = true;
               lbl2 = new Label();
               lbl2.Location=new Point(11,24);
               lbl2.Size=new Size(49,13);
               lbl2.Text = "Ответ 1:";
               gB3.Controls.Add(lbl2);
               lbl3 = new Label();
               lbl3.Location = new Point(11, 103);
               lbl3.Size = new Size(49, 13);
               lbl3.Text = "Ответ 2:";
               gB3.Controls.Add(lbl3);
               lbl4 = new Label();
               lbl4.Location = new Point(329,24);
               lbl4.Size = new Size(49, 13);
               lbl4.Text = "Ответ 3:";
               gB3.Controls.Add(lbl4);
               lbl5 = new Label();
               lbl5.Location = new Point(329,103);
               lbl5.Size = new Size(49, 13);
               lbl5.Text = "Ответ 4:";
               gB3.Controls.Add(lbl5);
           }
           else
               if (Questions[_ind].type_question == "Several")
               {
                   Clear();
                   #region Создание дин.элементов для неск.ответов
                   txtB1 = new RichTextBox();
                   txtB2 = new RichTextBox();
                   txtB3 = new RichTextBox();
                   txtB4 = new RichTextBox();

                   cB1 = new CheckBox();
                   cB2 = new CheckBox();
                   cB3 = new CheckBox();
                   cB4 = new CheckBox();
                   //-------------------------
                   txtB1.Name = "txtBQuest1";
                   txtB1.Location = new Point(32, 53);
                   txtB1.Size = new Size(278, 35);
                   //txtB1.TextChanged += rtBQuestion_TextChanged;
                   gB3.Controls.Add(txtB1);

                   cB1.Name = "radQuest1";
                   cB1.Location = new Point(14, 61);
                   cB1.Size = new Size(14, 13);
                   gB3.Controls.Add(cB1);
                   //-------------------------
                   txtB2.Name = "txtBQuest2";
                   txtB2.Location = new Point(32, 132);
                   txtB2.Size = new Size(278, 35);
                   //txtB2.TextChanged += rtBQuestion_TextChanged;
                   gB3.Controls.Add(txtB2);

                   cB2.Name = "radQuest2";
                   cB2.Location = new Point(14, 144);
                   cB2.Size = new Size(14, 13);
                   gB3.Controls.Add(cB2);
                   //-------------------------

                   txtB3.Name = "txtBQuest3";
                   txtB3.Location = new Point(347, 53);
                   txtB3.Size = new Size(278, 35);
                   //txtB3.TextChanged += rtBQuestion_TextChanged;
                   gB3.Controls.Add(txtB3);

                   cB3.Name = "radQuest3";
                   cB3.Location = new Point(332, 61);
                   cB3.Size = new Size(14, 13);
                   gB3.Controls.Add(cB3);
                   //-------------------------
                   txtB4.Name = "txtBQuest4";
                   txtB4.Location = new Point(347, 132);
                   txtB4.Size = new Size(278, 35);
                   //txtB4.TextChanged += rtBQuestion_TextChanged;
                   gB3.Controls.Add(txtB4);

                   cB4.Name = "radQuest4";
                   cB4.Location = new Point(332, 144);
                   cB4.Size = new Size(14, 13);
                   gB3.Controls.Add(cB4);
                   label6.Visible = false;
                   label7.Visible = false;
                   //-------------------------
                   #endregion
                   //NumberList.Value = numList2.Value;
                   txtB1.Text = Questions[_ind].answ1;
                   txtB2.Text = Questions[_ind].answ2;
                   txtB3.Text = Questions[_ind].answ3;
                   txtB4.Text = Questions[_ind].answ4;
                   //txtB1.ReadOnly = true;
                   //txtB2.ReadOnly = true;
                   //txtB3.ReadOnly = true;
                   //txtB4.ReadOnly = true;
                   //txtB1.Text = Questions[_ind].answ1;
                   //txtB2.Text = Questions[_ind].answ2;
                   //txtB3.Text = Questions[_ind].answ3;
                   //txtB4.Text = Questions[_ind].answ4;
                   txtB1.ReadOnly = true;
                   txtB2.ReadOnly = true;
                   txtB3.ReadOnly = true;
                   txtB4.ReadOnly = true;
                   lbl2 = new Label();
                   lbl2.Location = new Point(11, 24);
                   lbl2.Size = new Size(49, 13);
                   lbl2.Text = "Ответ 1:";
                   gB3.Controls.Add(lbl2);
                   lbl3 = new Label();
                   lbl3.Location = new Point(11, 103);
                   lbl3.Size = new Size(49, 13);
                   lbl3.Text = "Ответ 2:";
                   gB3.Controls.Add(lbl3);
                   lbl4 = new Label();
                   lbl4.Location = new Point(329, 24);
                   lbl4.Size = new Size(49, 13);
                   lbl4.Text = "Ответ 3:";
                   gB3.Controls.Add(lbl4);
                   lbl5 = new Label();
                   lbl5.Location = new Point(329, 103);
                   lbl5.Size = new Size(49, 13);
                   lbl5.Text = "Ответ 4:";
                   gB3.Controls.Add(lbl5);
               }
               else
                   if (Questions[_ind].type_question == "Sequence")
                   {
                       Clear();
                       #region Создание дин.элементов для установки посл
                       txtB1 = new RichTextBox();
                       txtB2 = new RichTextBox();
                       txtB3 = new RichTextBox();
                       txtB4 = new RichTextBox();
                       //-------------------------
                       txtB1.Name = "txtBQuest1";
                       txtB1.Location = new Point(32, 53);
                       txtB1.Size = new Size(278, 35);
                       //txtB1.TextChanged += rtBQuestion_TextChanged;
                       gB3.Controls.Add(txtB1);

                       txtB2.Name = "txtBQuest2";
                       txtB2.Location = new Point(32, 132);
                       txtB2.Size = new Size(278, 35);
                       //txtB2.TextChanged += rtBQuestion_TextChanged;
                       gB3.Controls.Add(txtB2);

                       txtB3.Name = "txtBQuest3";
                       txtB3.Location = new Point(347, 53);
                       txtB3.Size = new Size(278, 35);
                       //txtB3.TextChanged += rtBQuestion_TextChanged;
                       gB3.Controls.Add(txtB3);

                       txtB4.Name = "txtBQuest4";
                       txtB4.Location = new Point(347, 132);
                       txtB4.Size = new Size(278, 35);
                       //txtB4.TextChanged += rtBQuestion_TextChanged;
                       gB3.Controls.Add(txtB4);

                       label6.Visible = false;
                       label7.Visible = false;
                       #endregion
                       //NumberList.Value = numList3.Value;
                       //txtB1.Text = Questions[_ind].answ1;
                       //txtB2.Text = Questions[_ind].answ2;
                       //txtB3.Text = Questions[_ind].answ3;
                       //txtB4.Text = Questions[_ind].answ4;
                       //txtB1.ReadOnly = true;
                       //txtB2.ReadOnly = true;
                       //txtB3.ReadOnly = true;
                       //txtB4.ReadOnly = true;
                       lbl2 = new Label();
                       lbl2.Location = new Point(11, 24);
                       lbl2.Size = new Size(49, 13);
                       lbl2.Text = "Ответ 1:";
                       gB3.Controls.Add(lbl2);
                       lbl3 = new Label();
                       lbl3.Location = new Point(11, 103);
                       lbl3.Size = new Size(49, 13);
                       lbl3.Text = "Ответ 2:";
                       gB3.Controls.Add(lbl3);
                       lbl4 = new Label();
                       lbl4.Location = new Point(329, 24);
                       lbl4.Size = new Size(49, 13);
                       lbl4.Text = "Ответ 3:";
                       gB3.Controls.Add(lbl4);
                       lbl5 = new Label();
                       lbl5.Location = new Point(329, 103);
                       lbl5.Size = new Size(49, 13);
                       lbl5.Text = "Ответ 4:";
                       gB3.Controls.Add(lbl5);
                   }
                   else
                   {
                       if (Questions[_ind].type_question == "Writing")
                       {
                           Clear();
                           #region Создание дин.элементов для письменного ответа
                           txtB1 = new RichTextBox();
                           txtB1.Name = "txtBQuest1";
                           txtB1.Location = new Point(32, 53);
                           txtB1.Size = new Size(278, 35);
                           //txtB1.TextChanged += rtBQuestion_TextChanged;
                           gB3.Controls.Add(txtB1);
                           label6.Visible = false;
                           label7.Visible = false;
                           #endregion
                           //NumberList.Value = numList4.Value;
                           //txtB1.Text = Questions[_ind].answ1;
                           //txtB2.Text = Questions[_ind].answ2;
                           //txtB3.Text = Questions[_ind].answ3;
                           //txtB4.Text = Questions[_ind].answ4;
                           //txtB1.ReadOnly = true;
                           //txtB2.ReadOnly = true;
                           //txtB3.ReadOnly = true;
                           //txtB4.ReadOnly = true;
                           lbl2 = new Label();
                           lbl2.Location = new Point(11, 24);
                           lbl2.Size = new Size(49, 13);
                           lbl2.Text = "Ответ 1:";
                           gB3.Controls.Add(lbl2);
                       }
                       else
                       {
                           Clear();
                           #region Создание дин.элементов для ответа сопоставления
                           txtB1 = new RichTextBox();
                           txtB2 = new RichTextBox();
                           txtB3 = new RichTextBox();
                           txtB4 = new RichTextBox();
                           //-------------------------
                           txtB1.Name = "txtBQuest1";
                           txtB1.Location = new Point(32, 53);
                           txtB1.Size = new Size(278, 35);
                           //txtB1.TextChanged += rtBQuestion_TextChanged;
                           gB3.Controls.Add(txtB1);

                           txtB2.Name = "txtBQuest2";
                           txtB2.Location = new Point(32, 132);
                           txtB2.Size = new Size(278, 35);
                           //txtB2.TextChanged += rtBQuestion_TextChanged;
                           gB3.Controls.Add(txtB2);

                           txtB3.Name = "txtBQuest3";
                           txtB3.Location = new Point(347, 53);
                           txtB3.Size = new Size(278, 35);
                           //txtB3.TextChanged += rtBQuestion_TextChanged;
                           gB3.Controls.Add(txtB3);

                           txtB4.Name = "txtBQuest4";
                           txtB4.Location = new Point(347, 132);
                           txtB4.Size = new Size(278, 35);
                           //txtB4.TextChanged += rtBQuestion_TextChanged;
                           gB3.Controls.Add(txtB4);

                           label6.Visible = true;
                           label7.Visible = true;
                           //Label lbl7 = new Label();
                           //lbl7.AutoSize = false;
                           //lbl7.Size = new Size(40, 10);
                           //lbl7.Location = new Point(243, 53);
                           //lbl7.Text = "     ";
                           //gB3.Controls.Add(lbl7);

                           //Label lbl8 = new Label();
                           //lbl8.AutoSize = false;
                           //lbl8.Size = new Size(40, 10);
                           //lbl8.Location = new Point(243, 53);
                           //lbl8.Text = "     ";
                           //gB3.Controls.Add(lbl8);

                           #endregion
                           //NumberList.Value = numList5.Value;
                           //txtB1.Text = Questions[_ind].answ1;
                           //txtB2.Text = Questions[_ind].answ2;
                           //txtB3.Text = Questions[_ind].answ3;
                           //txtB4.Text = Questions[_ind].answ4;
                           //txtB1.ReadOnly = true;
                           //txtB2.ReadOnly = true;
                           //txtB3.ReadOnly = true;
                           //txtB4.ReadOnly = true;
                           lbl2 = new Label();
                           lbl2.Location = new Point(11, 24);
                           lbl2.Size = new Size(49, 13);
                           lbl2.Text = "Ответ 1:";
                           gB3.Controls.Add(lbl2);
                           lbl3 = new Label();
                           lbl3.Location = new Point(11, 103);
                           lbl3.Size = new Size(49, 13);
                           lbl3.Text = "Ответ 2:";
                           gB3.Controls.Add(lbl3);
                           lbl4 = new Label();
                           lbl4.Location = new Point(329, 24);
                           lbl4.Size = new Size(49, 13);
                           lbl4.Text = "Ответ 3:";
                           gB3.Controls.Add(lbl4);
                           lbl5 = new Label();
                           lbl5.Location = new Point(329, 103);
                           lbl5.Size = new Size(49, 13);
                           lbl5.Text = "Ответ 4:";
                           gB3.Controls.Add(lbl5);
                       }
                   }
           if (File.Exists(Questions[_ind].question)==true)
           {
               img = Image.FromFile(Questions[_ind].question);
               Clipboard.Clear();
               Clipboard.SetImage(img);
               rTB.Paste();
               Clipboard.Clear();
           }
           else
              rTB.Text = Questions[_ind].question;

        }
        
        public void Clear()
        {
            gB3.Controls.Clear();
            lbl2 = null;
            lbl3 = null;
            lbl4 = null;
            lbl5 = null;

            rad1 = null;
            rad2 = null;
            rad3 = null;
            rad4 = null;
            txtB1 = null;
            txtB2 = null;
            txtB3 = null;
            txtB4 = null;
            cB1 = null;
            cB2 = null;
            cB3 = null;
            cB4 = null;
            rTB.Text = "";
            //добавить стиралку для 2 черт
        }

        private void lstQuestion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (First==false)
            {
                MyTimer.Enabled = true;
                MyTimer.Start();
                //First = true;
            }
            int num = 0;
            int num2 = 0;
            if (txtB1 != null)
            {
               // numberTekQuest = Int32.Parse(sender.ToString());
               num = Int32.Parse(lstQuestion.SelectedItems[0].Tag.ToString());
               num2 = Int32.Parse(lblNumberQuest.Text);
               SaveAnswers(num2);
               CreateElement(num);
                if (Answers[num].ans1 != null || Answers[num].ans2 != null || Answers[num].ans3 != null || Answers[num].ans4 != null || Answers[num].answer1 != false || Answers[num].answer2 != false || Answers[num].answer3 != false || Answers[num].answer4 != false)
                   LoadAnswers(num);
                lblNumberQuest.Text = num.ToString();
            }
            else
            {
                if (First == true)
                {
                    lblNumberQuest.Text = lstQuestion.SelectedItems[0].Tag.ToString();
                    CreateElement(Int32.Parse(lblNumberQuest.Text));
                }
                else
                {
                    //num = Int32.Parse(lstQuestion.SelectedItems[0].Tag.ToString());
                    lblNumberQuest.Text = "0";
                    CreateElement(Int32.Parse(lblNumberQuest.Text));
                }
            }
            if (First == false)
                numberTekQuest = 0;
            First = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int idTest = -1;
            SaveAnswers(Int32.Parse(lblNumberQuest.Text));
            if (MessageBox.Show("Вы уверены, что хотите сдать тест?", "Сдача теста", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "Select [№ теста] from [Тест] where [Ссылка] = '" + XmlPath + "'";
                SqlDataReader rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    idTest = Int32.Parse(rdr[0].ToString());
                }
                rdr.Close();

                for (int y = 0; y < Questions.Count; y++)
                {
                    Check(y);
                }
                if (Report == true)
                {
                    ReportForm RF = new ReportForm(idTest,numStud, Theme, StudBall, t, Questions, NotRightAnswers, Answers);
                    RF.Show();
                    this.Hide();

                }
                else
                {
                    //занести в БД результаты
                    conn.Open();
                    comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandText = "Insert into [Выполненный тест] ([№ теста],[Балл],[Дата сдачи],[Время выполнения],[№ студента]) values (" + "'" + idTest.ToString() + "'" + "," + "'" + StudBall.ToString() + "'" + "," + "'" + System.DateTime.Today.ToShortDateString() + "'" + "," + "'" + (t / 60000000).ToString() + "'" + "," + "'" + numStud.ToString() + "'" + ")";
                    comm.ExecuteNonQuery();
                    // ------
                    Application.Exit();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (t <= Time)
            {
                pBTime.Value = pBTime.Value+1;//100 минут длится пара
                pBTime.Update();
                t++;
            }
            else
            {
                MyTimer.Stop();
                MyTimer.Enabled = false;
                SaveAnswers(Int32.Parse(lblNumberQuest.Text));//ПРОВЕРИТЬ!
                btnNext_Click(sender, e);
                MessageBox.Show("Время истекло");
            }
        }

        void SaveAnswers(int _ind)
        {
            ClearAnswers(_ind);
            if (rad1 != null)
            {
                if (rad1.Checked == true)
                {
                    Answers[_ind].answer1 = true;
                }
                if (rad2.Checked == true)
                {
                    Answers[_ind].answer2 = true;
                }
                if (rad3.Checked == true)
                {
                    Answers[_ind].answer3 = true;
                }
                if (rad4.Checked == true)
                {
                    Answers[_ind].answer4 = true;
                }
            }
            else
            {
                if (cB1 != null)
                {
                    if (cB1.Checked == true)
                    {
                        Answers[_ind].answer1 = true;
                    }
                    if (cB2.Checked == true)
                    {
                        Answers[_ind].answer2 = true;
                    }
                    if (cB3.Checked == true)
                    {
                        Answers[_ind].answer3 = true;
                    }
                    if (cB4.Checked == true)
                    {
                        Answers[_ind].answer4 = true;
                    }
                }
                else
                {
                    if (txtB2 != null)
                    {
                        Answers[_ind].ans1 = txtB1.Text;
                        Answers[_ind].ans2 = txtB2.Text;
                        Answers[_ind].ans3 = txtB3.Text;
                        Answers[_ind].ans4 = txtB4.Text;
                    }
                    else
                    {
                        //Answers[_ind].answer1 = true;
                        if (txtB1 != null)
                            Answers[_ind].ans1 = txtB1.Text;
                    }

                }
            }
        }
        
        void ClearAnswers(int _ind)
        {
            Answers[_ind].answer1 = false;
            Answers[_ind].answer2 = false;
            Answers[_ind].answer3 = false;
            Answers[_ind].answer4 = false;
            Answers[_ind].ans1 = null;
            Answers[_ind].ans2 = null;
            Answers[_ind].ans3 = null;
            Answers[_ind].ans4 = null;
        }
        
        void LoadAnswers(int _ind)
        {
            if (Answers[_ind].answer1 != false)
                if (rad1 != null)
                    rad1.Checked = true;
                else
                    cB1.Checked = true;
            if (Answers[_ind].answer2 != false)
                if (rad2 != null)
                    rad2.Checked = true;
                else
                    cB2.Checked = true;
            if (Answers[_ind].answer3 != false)
                if (rad3 != null)
                    rad3.Checked = true;
                else
                    cB3.Checked = true;
            if (Answers[_ind].answer4 != false)
                if (rad4 != null)
                    rad4.Checked = true;
                else
                    cB4.Checked = true;
            //if (Answers[_ind].answer1 != false)
            //    if (rad1 != null)
            //        rad1.Checked = true;
            //    else
            //        cB1.Checked = true;
            if (Answers[_ind].ans1 != null)
                txtB1.Text = Answers[_ind].ans1;
            if (Answers[_ind].ans2 != null)
                if (txtB2!=null)
                   txtB2.Text = Answers[_ind].ans2;
            if (Answers[_ind].ans3 != null)
                if (txtB3 != null)
                  txtB3.Text = Answers[_ind].ans3;
            if (Answers[_ind].ans4 != null)
                if (txtB4 != null)
                   txtB4.Text = Answers[_ind].ans4;
        }

        void Check(int _ind)
        {
            if (Answers[_ind].answer1 != false || Answers[_ind].answer2 != false || Answers[_ind].answer3 != false || Answers[_ind].answer4 != false)
            {
                bool Right = true;
                //int NumberAnswer=0;
                //for (int u = 0; u <= 3;u++)
                //{
                //    if (Questions[_ind].rightans[u]!=null)
                //        NumberAnswer++;
                //}
                for (int u = 0; u <= 3; u++)
                {
                    if (Questions[_ind].rightans[u] != null)
                        if (u == 0)
                            //if (Answers[_ind].ans1 == Questions[_ind].rightans[u])
                            if (Answers[_ind].answer1 == true)
                                Right = Right && true;
                            else
                                Right = Right && false;
                    if (Questions[_ind].rightans[u] != null)
                        if (u == 1)
                            if (Answers[_ind].answer2 == true)
                                Right = Right && true;
                            else
                                Right = Right && false;
                    if (Questions[_ind].rightans[u] != null)
                        if (u == 2)
                            if (Answers[_ind].answer3 == true)
                                Right = Right && true;
                            else
                                Right = Right && false;
                    if (Questions[_ind].rightans[u] != null)
                        if (u == 3)
                            if (Answers[_ind].answer4 == true)
                                Right = Right && true;
                            else
                                Right = Right && false;

                }
                if (Right == false)
                    NotRightAnswers[_ind] = Questions[_ind].num + 1;
                else
                    StudBall = StudBall + Questions[_ind].price;
            }
            else
            {
                if (Answers[_ind].ans1 != null && Answers[_ind].ans2 == null && Answers[_ind].ans3 == null && Answers[_ind].ans4 == null)
                {
                    if (Questions[_ind].rightans[0] != null && Questions[_ind].rightans[0] == Answers[_ind].ans1 && Questions[_ind].rightans[1] == null && Questions[_ind].rightans[2] == null && Questions[_ind].rightans[3] == null)
                        StudBall = StudBall + Questions[_ind].price;
                    else
                    {
                        NotRightAnswers[_ind] = Questions[_ind].num + 1;
                    }
                }
                else
                {
                    NotRightAnswers[_ind] = Questions[_ind].num + 1;
                }
                if (Answers[_ind].ans1 != null || Answers[_ind].ans2 != null || Answers[_ind].ans3 != null || Answers[_ind].ans4 != null)
                {
                    if (Questions[_ind].rightans[0] != null && Questions[_ind].rightans[1] != null && Questions[_ind].rightans[2] != null && Questions[_ind].rightans[3] != null)
                        if (Answers[_ind].ans1 == Questions[_ind].rightans[0] && Answers[_ind].ans2 == Questions[_ind].rightans[1] && Answers[_ind].ans3 == Questions[_ind].rightans[2] && Answers[_ind].ans4 == Questions[_ind].rightans[3])
                            StudBall = StudBall + Questions[_ind].price;
                        else
                        {
                            NotRightAnswers[_ind] = Questions[_ind].num + 1;
                        }
                }
                else
                {
                    NotRightAnswers[_ind] = Questions[_ind].num + 1;
                }
            }
        }

        private void btnPrevQuestion_Click(object sender, EventArgs e)
        {
            MouseEventArgs events = new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 2, lstQuestion.Items[numberTekQuest + 1].Position.X, lstQuestion.Items[numberTekQuest + 1].Position.Y, 0);
            if ((numberTekQuest - 1)!=-1)
                if (lstQuestion.Items[numberTekQuest - 1] != null)
              lstQuestion_MouseDoubleClick(lstQuestion.Items[numberTekQuest-1].Text, events);
        }

        private void btnNextQuestion_Click(object sender, EventArgs e)
        {
            MouseEventArgs events = new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 2, lstQuestion.Items[numberTekQuest + 1].Position.X, lstQuestion.Items[numberTekQuest + 1].Position.Y, 0);
            if (lstQuestion.Items[numberTekQuest + 1] != null)
                lstQuestion_MouseDoubleClick(lstQuestion.Items[numberTekQuest + 1].Text, events);
        }
    }
}
