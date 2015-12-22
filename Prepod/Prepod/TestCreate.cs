using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Prepod
{
    //работает некрасиво
    //1- очистка происходит неоптимально
    //2- lstViewIstochnik имеет модификатор public, что противоречит ООП
    public partial class TestCreate : Form
    {
        SqlConnection conn;
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        int kolvoQuest = 1;
        XmlTextWriter writer;
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

        Label lbl6;
        Label lbl7;

        Image img = null;

        public int x;
        public bool Save = false;
        public TextQuestion tq=new TextQuestion();
        List<TextQuestion> Questions=new List<TextQuestion>();
        TextQuestion tek;
        public bool Changes = false;
        public int number = -1;
        public bool Picture = false;
        public string PicturePath = null;
        public int NumItems;

        string numTest;
        public TestCreate(XmlTextWriter _writer, string _numTest)
        {
            InitializeComponent();
            writer = _writer;
            numTest = _numTest;
        }//+

        private void TestCreate_Load(object sender, EventArgs e)
        {
            cBSelect.SelectedIndex = -1;
            tabControl1.SelectedIndex = 1;
            lstViewQuestion.Items.Add("Вопрос № " + kolvoQuest);
            tek = new TextQuestion();
            cBOtch.SelectedIndex = 0;
            btnSaveQ.Visible = false;
            btnAdd.Visible = true;
        }//+

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex==0)
            {
                cBSelect.SelectedIndex = 0;
            }
        }

        private void cBSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
           // Changes = true;
            if(cBSelect.SelectedIndex==0)
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
                txtB1.Location=new Point(28,26);
                txtB1.Size = new Size(170, 45);
                txtB1.TextChanged += rtBQuestion_TextChanged;
                gB3.Controls.Add(txtB1);
                
                rad1.Name = "radQuest1";
                rad1.Location = new Point(8,29);
                rad1.Size=new Size(14,13);
                gB3.Controls.Add(rad1);
                //-------------------------
                txtB2.Name = "txtBQuest2";
                txtB2.Location = new Point(28, 106);
                txtB2.Size = new Size(170, 45);
                txtB2.TextChanged += rtBQuestion_TextChanged;
                gB3.Controls.Add(txtB2);

                rad2.Name = "radQuest2";
                rad2.Location = new Point(8, 109);
                rad2.Size = new Size(14, 13);
                gB3.Controls.Add(rad2);
                //-------------------------

                txtB3.Name = "txtBQuest3";
                txtB3.Location = new Point(278, 26);
                txtB3.Size = new Size(170, 45);
                txtB3.TextChanged += rtBQuestion_TextChanged;
                gB3.Controls.Add(txtB3);

                rad3.Name = "radQuest3";
                rad3.Location = new Point(260, 29);
                rad3.Size = new Size(14, 13);
                gB3.Controls.Add(rad3);
                //-------------------------
                txtB4.Name = "txtBQuest4";
                txtB4.Location = new Point(278, 106);
                txtB4.Size = new Size(170, 45);
                txtB4.TextChanged += rtBQuestion_TextChanged;
                gB3.Controls.Add(txtB4);

                rad4.Name = "radQuest4";
                rad4.Location = new Point(260, 109);
                rad4.Size = new Size(14, 13);
                gB3.Controls.Add(rad4);
                //-------------------------
                #endregion 
                NumberList.Value = numList1.Value;
            }
            else
              if (cBSelect.SelectedIndex==1)
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
                  txtB1.Location = new Point(28, 26);
                  txtB1.Size = new Size(170, 45);
                  txtB1.TextChanged += rtBQuestion_TextChanged;
                  gB3.Controls.Add(txtB1);

                  cB1.Name = "radQuest1";
                  cB1.Location = new Point(8, 29);
                  cB1.Size = new Size(14, 13);
                  gB3.Controls.Add(cB1);
                  //-------------------------
                  txtB2.Name = "txtBQuest2";
                  txtB2.Location = new Point(28, 106);
                  txtB2.Size = new Size(170, 45);
                  txtB2.TextChanged += rtBQuestion_TextChanged;
                  gB3.Controls.Add(txtB2);

                  cB2.Name = "radQuest2";
                  cB2.Location = new Point(8, 109);
                  cB2.Size = new Size(14, 13);
                  gB3.Controls.Add(cB2);
                  //-------------------------

                  txtB3.Name = "txtBQuest3";
                  txtB3.Location = new Point(278, 26);
                  txtB3.Size = new Size(170, 45);
                  txtB3.TextChanged += rtBQuestion_TextChanged;
                  gB3.Controls.Add(txtB3);

                  cB3.Name = "radQuest3";
                  cB3.Location = new Point(260, 29);
                  cB3.Size = new Size(14, 13);
                  gB3.Controls.Add(cB3);
                  //-------------------------
                  txtB4.Name = "txtBQuest4";
                  txtB4.Location = new Point(278, 106);
                  txtB4.Size = new Size(170, 45);
                  txtB4.TextChanged += rtBQuestion_TextChanged;
                  gB3.Controls.Add(txtB4);

                  cB4.Name = "radQuest4";
                  cB4.Location = new Point(260, 109);
                  cB4.Size = new Size(14, 13);
                  gB3.Controls.Add(cB4);

                  //-------------------------
                  #endregion
                  NumberList.Value = numList2.Value;
              }
              else
                  if (cBSelect.SelectedIndex==2)
                  {
                      Clear();
                      #region Создание дин.элементов для установки посл
                      txtB1 = new RichTextBox();
                      txtB2 = new RichTextBox();
                      txtB3 = new RichTextBox();
                      txtB4 = new RichTextBox();
                      //-------------------------
                      txtB1.Name = "txtBQuest1";
                      txtB1.Location = new Point(28, 26);
                      txtB1.Size = new Size(170, 45);
                      txtB1.TextChanged += rtBQuestion_TextChanged;
                      gB3.Controls.Add(txtB1);

                      txtB2.Name = "txtBQuest2";
                      txtB2.Location = new Point(28, 106);
                      txtB2.Size = new Size(170, 45);
                      txtB2.TextChanged += rtBQuestion_TextChanged;
                      gB3.Controls.Add(txtB2);

                      txtB3.Name = "txtBQuest3";
                      txtB3.Location = new Point(278, 26);
                      txtB3.Size = new Size(170, 45);
                      txtB3.TextChanged += rtBQuestion_TextChanged;
                      gB3.Controls.Add(txtB3);

                      txtB4.Name = "txtBQuest4";
                      txtB4.Location = new Point(278, 106);
                      txtB4.Size = new Size(170, 45);
                      txtB4.TextChanged += rtBQuestion_TextChanged;
                      gB3.Controls.Add(txtB4);
                      #endregion
                      NumberList.Value = numList3.Value;
                  }
                  else
                  {
                      if (cBSelect.SelectedIndex == 3)
                      {
                          Clear();
                          #region Создание дин.элементов для письменного ответа
                          txtB1 = new RichTextBox();
                          txtB1.Name = "txtBQuest1";
                          txtB1.Location = new Point(28, 26);
                          txtB1.Size = new Size(170, 45);
                          txtB1.TextChanged += rtBQuestion_TextChanged;
                          gB3.Controls.Add(txtB1);
                          #endregion
                          NumberList.Value = numList4.Value;
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
                          txtB1.Location = new Point(28, 26);
                          txtB1.Size = new Size(170, 45);
                          txtB1.TextChanged += rtBQuestion_TextChanged;
                          gB3.Controls.Add(txtB1);

                          txtB2.Name = "txtBQuest2";
                          txtB2.Location = new Point(28, 106);
                          txtB2.Size = new Size(170, 45);
                          txtB2.TextChanged += rtBQuestion_TextChanged;
                          gB3.Controls.Add(txtB2);

                          txtB3.Name = "txtBQuest3";
                          txtB3.Location = new Point(278, 26);
                          txtB3.Size = new Size(170, 45);
                          txtB3.TextChanged += rtBQuestion_TextChanged;
                          gB3.Controls.Add(txtB3);

                          txtB4.Name = "txtBQuest4";
                          txtB4.Location = new Point(278, 106);
                          txtB4.Size = new Size(170, 45);
                          txtB4.TextChanged += rtBQuestion_TextChanged;
                          gB3.Controls.Add(txtB4);

                          lbl7 = new Label();
                          lbl7.AutoSize = false;
                          lbl7.Size = new Size(45, 5);
                          lbl7.Location = new Point(214,45);
                          //lbl7.Location = new Point(214, 45);
                          lbl7.Text = "     ";
                          lbl7.BackColor = SystemColors.InactiveCaption;
                          lbl7.Visible = true;
                          gB3.Controls.Add(lbl7);


                          lbl6 = new Label();
                          lbl6.AutoSize = false;
                          lbl6.Size = new Size(45, 5);
                          lbl6.Location = new Point(214,124);
                          //lbl6.Location = new Point(214, 124);
                          lbl6.Text = "     ";
                          lbl6.BackColor = SystemColors.InactiveCaption;
                          lbl6.Visible = true;
                          gB3.Controls.Add(lbl6);

                          #endregion
                          NumberList.Value = numList5.Value;
                      }
                  }
        }

        public void Clear()
        {
            gB3.Controls.Clear();
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
            lbl6 = null;
            lbl7 = null;
            //добавить стиралку для 2 черт
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Changes = false;
            
            tek.num = kolvoQuest;
            tek.type_question = cBSelect.Text;
            if (Picture == false)
                tek.question = rtBQuestion.Text;
            else
                tek.question = PicturePath;
            tek.answ1 = txtB1.Text;
            tek.price = Int32.Parse(NumberList.Value.ToString());
            if (cBSelect.SelectedIndex != 3)
            {
                tek.answ2 = txtB2.Text;
                tek.answ3 = txtB3.Text;
                tek.answ4 = txtB4.Text;
            }
            if (cBSelect.SelectedIndex == 0)
                if (rad1.Checked == true)
                    tek.rightans[0] = txtB1.Text;
                else
                    if (rad2.Checked == true)
                        tek.rightans[0] = txtB2.Text;
                    else
                        if (rad3.Checked == true)
                            tek.rightans[0] = txtB3.Text;
                        else
                            tek.rightans[0] = txtB4.Text;
            if (cBSelect.SelectedIndex == 1)
            {
                if (cB1.Checked == true)
                    tek.rightans[0] = txtB1.Text;
                if (cB2.Checked == true)
                    tek.rightans[1] = txtB2.Text;
                if (cB3.Checked == true)
                    tek.rightans[2] = txtB3.Text;
                if (cB4.Checked == true)
                    tek.rightans[3] = txtB4.Text;
            }
            if (cBSelect.SelectedIndex == 2)
            {
                if (txtB1.Text!="")
                    tek.rightans[0] = txtB1.Text;
                if (txtB2.Text != "")
                    tek.rightans[1] = txtB2.Text;
                if (txtB3.Text != "")
                    tek.rightans[2] = txtB3.Text;
                if (txtB4.Text != "")
                    tek.rightans[3] = txtB4.Text;
            }
            if (cBSelect.SelectedIndex == 3)
                tek.rightans[0] = txtB1.Text;
            if(cBSelect.SelectedIndex==4)
            {
                tek.rightans[0] = txtB1.Text;
                tek.rightans[1] = txtB2.Text;
                tek.rightans[2] = txtB3.Text;
                tek.rightans[3] = txtB4.Text;
            }
            if (lstViewIstochnik.Items.Count==0)
            {
                if (MessageBox.Show("Вы уверены, что не хотите добавить разделы?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    btnIstochnik_Click(sender, e);

                }
            }
            if (rtBQuestion.Text == "" && txtB1.Text == "" && txtB2.Text == "" && txtB3.Text == "" && txtB4.Text == "")
                MessageBox.Show("Заполните поля!");
            else
            {
                if (cBSelect.SelectedIndex == 0)
                    if (rad1.Checked == false && rad2.Checked == false && rad3.Checked == false && rad4.Checked == false)
                        MessageBox.Show("Вы не выбрали правильный ответ. Выберите какой из ответов верный.");
                    else
                    {
                        Next();
                    }
                if (cBSelect.SelectedIndex == 1)
                    if (cB1.Checked == false && cB2.Checked == false && cB3.Checked == false && cB4.Checked == false)
                        MessageBox.Show("Вы не выбрали правильный ответ. Выберите какой из ответов верный.");
                    else
                    {
                        Next();
                    }
                if (cBSelect.SelectedIndex == 2 || cBSelect.SelectedIndex == 3 || cBSelect.SelectedIndex == 4)
                    Next();
            }
            Picture = false;
            PicturePath = null;
       }
        
        public void Next()
        {
            for (int i = 0; i <= lstViewIstochnik.Items.Count - 1; i++)
            {
                tek.part[i] = lstViewIstochnik.Items[i].Text;
            }
            rtBQuestion.Text = "";
            txtB1.Text = "";
            if (cBSelect.SelectedIndex != 3)
            {
                txtB2.Text = "";
                txtB3.Text = "";
                txtB4.Text = "";
            }
            cBSelect.SelectedIndex = 0;
            if (cBSelect.SelectedIndex == 0)
            {
                rad1.Checked = false;
                rad2.Checked = false;
                rad3.Checked = false;
                rad4.Checked = false;
            }
            if (cBSelect.SelectedIndex == 1)
            {
                cB1.Checked = false;
                cB2.Checked = false;
                cB3.Checked = false;
                cB4.Checked = false;
            }
            lstViewIstochnik.Items.Clear();

            img = null;
            Clipboard.Clear();

            Questions.Add(tek);
            kolvoQuest++;
            int y = lstViewQuestion.Items.Add("Вопрос № " + kolvoQuest.ToString()).Index - 1;
            x = Questions.IndexOf(tek);
            lstViewQuestion.Items[y].Tag = x;
            tek = new TextQuestion();
        }
       
        private void btnIstochnik_Click(object sender, EventArgs e)
        {
            AddPartTree parttree = new AddPartTree(this);
            parttree.ShowDialog();
        }

        private void btnTestDone_Click(object sender, EventArgs e)
        {
            writer.WriteStartAttribute("Number");
            int p=Questions.Count;
            writer.WriteString(p.ToString());
            writer.WriteEndAttribute();
            for (int i = 0; i <= Questions.Count-1;i++ )
            {
                writer.WriteStartElement("Question" + Questions[i].num);

                //writer.WriteStartAttribute("Text");
                writer.WriteStartElement("Text");
                writer.WriteString(Questions[i].question);
                //writer.WriteEndAttribute();
                writer.WriteEndElement();

                #region TypeAnswer
                //writer.WriteStartAttribute("Type Answer");
                writer.WriteStartElement("TypeAnswer");
                if (Questions[i].type_question == "Один вариант ответа")
                    writer.WriteString("One");
                else
                    if (Questions[i].type_question == "Несколько вариантов ответа")
                        writer.WriteString("Several");
                    else
                        if (Questions[i].type_question == "Выстроить последовательность")
                            writer.WriteString("Sequence");
                        else
                            if (Questions[i].type_question == "Свободный ответ")
                                writer.WriteString("Writing");
                            else
                                writer.WriteString("Comparison");
                //writer.WriteEndAttribute();
                writer.WriteEndElement();
                #endregion

                #region Answers
                //writer.WriteStartAttribute("Answers");
                writer.WriteStartElement("Answers");
                if (Questions[i].answ2 != null)
                    writer.WriteString(Questions[i].answ1 + "|" + Questions[i].answ2 + "|" + Questions[i].answ3 + "|" + Questions[i].answ4);
                else
                    writer.WriteString(Questions[i].answ1);
                //writer.WriteEndAttribute();
                writer.WriteEndElement();
                #endregion

                #region RightAnswer
                //Записываем правильный ответ в атрибут Right answer
                //writer.WriteStartAttribute("Right answer");
                writer.WriteStartElement("RightAnswer");
                if (Questions[i].type_question == "Один вариант ответа")
                {
                    for (int h = 0; h <= 3; h++)
                    {
                        if (Questions[i].rightans[h] != null)
                            writer.WriteString(Questions[i].rightans[h]);
                    }
                }
                else
                    if (Questions[i].type_question == "Несколько вариантов ответа")
                    {
                        string tmp = null;
                        for (int h = 0; h <= 3; h++)
                        {
                            if (Questions[i].rightans[h] != null)
                            {
                                tmp = tmp + Questions[i].rightans[h];
                                tmp = tmp + "|";
                            }
                        }
                        for (int h = 0; h <= 3; h++)
                        {
                            if (tmp != null)
                                if (tmp.LastIndexOf("|") == tmp.Length - 1)
                                    tmp = tmp.Remove(tmp.Length - 1, 1);
                        }
                        writer.WriteString(tmp);

                    }

                    else
                        if (Questions[i].type_question == "Выстроить последовательность")
                        {
                            string tmp = null;
                            for (int h = 0; h <= 3; h++)
                            {
                                if (Questions[i].rightans[h] != null)
                                {
                                    tmp = tmp + Questions[i].rightans[h];
                                    tmp = tmp + "|";
                                }
                            }
                            if (tmp.LastIndexOf("|") == tmp.Length - 1)
                                tmp = tmp.Remove(tmp.Length - 1, 1);
                            writer.WriteString(tmp);
                        }
                        else
                            if (Questions[i].type_question == "Свободный ответ")
                                writer.WriteString(Questions[i].rightans[0]);
                            else
                            {
                                string tmp = null;
                                tmp = Questions[i].rightans[0] + "==" + Questions[i].rightans[2];
                                tmp = tmp + "|" + Questions[i].rightans[1] + "==" + Questions[i].rightans[3];
                                writer.WriteString(tmp);
                            }
                //writer.WriteEndAttribute();
                writer.WriteEndElement();
                #endregion

                #region Part
                //writer.WriteStartAttribute("Part");
                writer.WriteStartElement("Part");
                string temp=null;
                for (int u = 0; u<=9; u++)
                {
                    if (Questions[i].part[u] != null)
                    {
                        temp = temp + Questions[i].part[u];
                        temp = temp + "|";
                    }
                }
                //if(temp!=null)
                //  if (temp.LastIndexOf("|") == temp.Length - 1)
                //    temp.Remove(temp.Length - 1, 1);
                for (int h = 0; h <= 9;h++ )
                {
                    if (temp!=null)
                       if (temp.LastIndexOf("|") == temp.Length - 1)
                         temp.Remove(temp.Length - 1, 1);
                }
                    if (temp == null)
                        temp = "";
                writer.WriteString(temp);
                //writer.WriteEndAttribute();
                writer.WriteEndElement();
                #endregion

                #region Price
                  //writer.WriteStartAttribute("Price");
                writer.WriteStartElement("Price");
                writer.WriteString(Questions[i].price.ToString());
                //writer.WriteEndAttribute();
                writer.WriteEndElement();
                #endregion

               // writer.WriteEndElement();

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            //Завершение записи
            writer.WriteStartElement("Time");
            //вставка метода вычисления
            writer.WriteString(numTime.Value.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Report");
            writer.WriteString(cBOtch.Text);
            writer.WriteEndElement();

            //Завершаем написание документа
            //writer.WriteEndElement(); //Закрывем тэг вопросов
            writer.WriteEndElement(); //Закрывем основной тэг - test
            writer.WriteEndDocument(); //Закрываем документ

            writer.Close();

            MessageBox.Show("Тест был успешно создан!", "Выход");
            insertTest();
            //Application.Exit();
            this.Hide();
        }

        public void insertTest()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;

            string date = dateTimePicker1.Value.ToShortDateString();
            //int maxBall = Convert.ToInt32(numList1.Value) + Convert.ToInt32(numList2.Value) + Convert.ToInt32(numList3.Value) + Convert.ToInt32(numList4.Value) + Convert.ToInt32(numList5.Value);
            int maxBall = 0;
            for (int g = 0; g <= Questions.Count-1;g++ )
            {
                maxBall += Questions[g].price;
            }
                try
                {
                    comm.CommandText = "Update Тест set [Максимальный балл] = '" + maxBall.ToString() + "', [Срок сдачи] = '" + date + "' where [№ теста] = '" + numTest + "'";
                    comm.ExecuteNonQuery();
                }
                finally { conn.Close(); }   
        }

        private void numList1_ValueChanged(object sender, EventArgs e)
        {
          // Razbal = true;
        }

        private void lstViewQuestion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstViewQuestion.SelectedItems[0] != null)
            {
                if (Save == false)
                {
                    tq = new TextQuestion(); 
                }
                if (lstViewQuestion.SelectedItems[0].Index != kolvoQuest && Save == false)
                {
                    tq.num = kolvoQuest;
                    tq.type_question = cBSelect.Text;
                    if (Picture == false)
                        tq.question = rtBQuestion.Text;
                    else
                        tq.question = PicturePath;
                    tq.answ1 = txtB1.Text;
                    tq.price = Int32.Parse(NumberList.Value.ToString());
                    if (cBSelect.Text != "Свободный ответ")
                    {
                        tq.answ2 = txtB2.Text;
                        tq.answ3 = txtB3.Text;
                        tq.answ4 = txtB4.Text;
                    }
                    if (cBSelect.SelectedIndex == 0)
                        if (rad1.Checked == true)
                        {
                            tq.rightans[0] = txtB1.Text;
                            rad1.Checked = false;
                        }
                        else
                            if (rad2.Checked == true)
                            {
                                tq.rightans[0] = txtB2.Text;
                                rad2.Checked = false;
                            }
                            else
                                if (rad3.Checked == true)
                                {
                                    tq.rightans[0] = txtB3.Text;
                                    rad3.Checked = false;
                                }
                                else
                                {
                                    if (rad4.Checked == true)
                                    {
                                        tq.rightans[0] = txtB4.Text;
                                        rad4.Checked = false;
                                    }
                                }
                    if (cBSelect.SelectedIndex == 1)
                    {
                        if (cB1.Checked == true)
                        {
                            tq.rightans[0] = txtB1.Text;
                            cB1.Checked = false;
                        }
                        if (cB2.Checked == true)
                        {
                            tq.rightans[1] = txtB2.Text;
                            cB2.Checked = false;
                        }
                        if (cB3.Checked == true)
                        {
                            tq.rightans[2] = txtB3.Text;
                            cB3.Checked = false;
                        }
                        if (cB4.Checked == true)
                        {
                            tq.rightans[3] = txtB4.Text;
                            cB4.Checked = false;
                        }
                    }
                    if (cBSelect.SelectedIndex == 2)
                    {
                        if (txtB1.Text != "")
                            tq.rightans[0] = txtB1.Text;
                        if (txtB2.Text != "")
                            tq.rightans[1] = txtB2.Text;
                        if (txtB3.Text != "")
                            tq.rightans[2] = txtB3.Text;
                        if (txtB4.Text != "")
                            tq.rightans[3] = txtB4.Text;
                    }
                    if (cBSelect.SelectedIndex == 3)
                        tq.rightans[0] = txtB1.Text;
                    if(cBSelect.SelectedIndex==4)
                    {
                        tq.rightans[0] = txtB1.Text;
                        tq.rightans[1] = txtB2.Text;
                        tq.rightans[2] = txtB3.Text;
                        tq.rightans[3] = txtB4.Text;
                    }
                    for (int i = 0; i <= lstViewIstochnik.Items.Count-1; i++)
                        tq.part[i] = lstViewIstochnik.Items[i].Text;
                    Save = true;

                }
                if (kolvoQuest != lstViewQuestion.SelectedItems[0].Index + 1)//загрузка не последнего вопроса
                {
                    NumItems = Int32.Parse(lstViewQuestion.SelectedItems[0].Tag.ToString());
                    if (rad1 != null)
                        rad1.Checked = false;
                    if (rad2 != null)
                        rad2.Checked = false;
                    if (rad3 != null)
                        rad3.Checked = false;
                    if (rad4 != null)
                        rad4.Checked = false;
                    if (cB1 != null)
                        cB1.Checked = false;
                    if (cB2 != null)
                        cB2.Checked = false;
                    if (cB3 != null)
                        cB3.Checked = false;
                    if (cB4 != null)
                        cB4.Checked = false;
                    //----------------------------------------------------------------------------
                    btnSaveQ.Visible = true;
                    btnAdd.Visible = false;
                    int h = Int32.Parse(lstViewQuestion.SelectedItems[0].Tag.ToString());
                    if (Questions[h].type_question == "Один вариант ответа")
                        cBSelect.SelectedIndex = 0;
                    if (Questions[h].type_question == "Несколько вариантов ответа")
                        cBSelect.SelectedIndex = 1;
                    if (Questions[h].type_question == "Выстроить последовательность")
                        cBSelect.SelectedIndex = 2;
                    if (Questions[h].type_question == "Свободный ответ")
                        cBSelect.SelectedIndex = 3;

                    if (File.Exists(Questions[h].question)==false)
                       rtBQuestion.Text = Questions[h].question;
                    else
                    {
                        img = Image.FromFile(Questions[h].question);
                        Clipboard.Clear();
                        Clipboard.SetImage(img);
                        rtBQuestion.Paste();
                        Clipboard.Clear();
                    }

                    txtB1.Text = Questions[h].answ1;
                    if (cBSelect.SelectedIndex != 3)
                    {
                        txtB2.Text = Questions[h].answ2;
                        txtB3.Text = Questions[h].answ3;
                        txtB4.Text = Questions[h].answ4;
                    }
                    NumberList.Value = Questions[h].price;
                    if (cBSelect.SelectedIndex==0)
                    {
                        if (Questions[h].rightans[0]==txtB1.Text)
                            rad1.Checked=true;
                        if (Questions[h].rightans[0] == txtB2.Text)
                            rad2.Checked = true;
                        if (Questions[h].rightans[0] == txtB3.Text)
                            rad3.Checked = true;
                        if (Questions[h].rightans[0] == txtB4.Text)
                            rad4.Checked = true;
                    }
                    if (cBSelect.SelectedIndex==1)
                    {
                        if (Questions[h].rightans[0] == txtB1.Text)
                            cB1.Checked = true;
                        if (Questions[h].rightans[1] == txtB2.Text)
                            cB2.Checked = true;
                        if (Questions[h].rightans[2] == txtB3.Text)
                            cB3.Checked = true;
                        if (Questions[h].rightans[3] == txtB4.Text)
                            cB4.Checked = true;
                    }
                    lstViewIstochnik.Items.Clear();
                    for (int i = 0; i <= 9; i++)
                    {
                        if (Questions[h].part[i] != null)
                            lstViewIstochnik.Items.Add(Questions[h].part[i]);
                    }
                }
                if (kolvoQuest == lstViewQuestion.SelectedItems[0].Index + 1)//загрузка последнего вопроса
                {
                    if (rad1 != null)
                        rad1.Checked = false;
                    if (rad2 != null)
                        rad2.Checked = false;
                    if (rad3 != null)
                        rad3.Checked = false;
                    if (rad4 != null)
                        rad4.Checked = false;
                    if (cB1 != null)
                        cB1.Checked = false;
                    if (cB2 != null)
                        cB2.Checked = false;
                    if (cB3 != null)
                        cB3.Checked = false;
                    if (cB4 != null)
                        cB4.Checked = false;
//-----------------------------------------------------------------------------------------------
                    btnSaveQ.Visible = false;
                    btnAdd.Visible = true;
                    if (tq.type_question == "Один вариант ответа")
                        cBSelect.SelectedIndex = 0;
                    if (tq.type_question == "Несколько вариантов ответа")
                        cBSelect.SelectedIndex = 1;
                    if (tq.type_question == "Выстроить последовательность")
                        cBSelect.SelectedIndex = 2;
                    if (tq.type_question == "Свободный ответ")
                        cBSelect.SelectedIndex = 3;
                    if (File.Exists(tq.question)==false)
                        rtBQuestion.Text = tq.question;
                    else
                    {
                        img = Image.FromFile(tq.question);
                        Clipboard.Clear();
                        Clipboard.SetImage(img);
                        rtBQuestion.Paste();
                        Clipboard.Clear();
                    }
                    txtB1.Text = tq.answ1;
                    if (cBSelect.SelectedIndex != 3)
                    {
                        txtB2.Text = tq.answ2;
                        txtB3.Text = tq.answ3;
                        txtB4.Text = tq.answ4;
                    }

                    if (tq.type_question == "Один вариант ответа")
                    {
                        if (tq.rightans[0] == txtB1.Text)
                            rad1.Checked = true;
                        if (tq.rightans[0] == txtB2.Text)
                            rad2.Checked = true;
                        if (tq.rightans[0] == txtB3.Text)
                            rad3.Checked = true;
                        if (tq.rightans[0] == txtB4.Text)
                            rad4.Checked = true;
                    }
                    if (tq.type_question == "Несколько вариантов ответа")
                    {
                        if (tq.rightans[0] == txtB1.Text)
                            cB1.Checked = true;
                        if (tq.rightans[1] == txtB2.Text)
                            cB2.Checked = true;
                        if (tq.rightans[2] == txtB3.Text)
                            cB3.Checked = true;
                        if (tq.rightans[3] == txtB4.Text)
                            cB4.Checked = true;
                    }

                    NumberList.Value = tq.price;

                    lstViewIstochnik.Items.Clear();
                    for (int i = 0; i <= 9; i++)
                        if (tq.part[i]!=null)
                           lstViewIstochnik.Items.Add(tq.part[i]);
                    Save = false;
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lstViewQuestion.SelectedItems[0] != null)
            {
                MouseEventArgs mouseEvent = new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 1, Cursor.Position.X, Cursor.Position.Y, 0);
                lstViewQuestion_MouseDoubleClick(sender, mouseEvent);
            }
            else
                MessageBox.Show("Выделите вопрос!");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Нужны еще тесты!");
            if (lstViewQuestion.SelectedItems[0] != null)
            {
                Questions.RemoveAt(Int32.Parse(lstViewQuestion.SelectedItems[0].Tag.ToString()));
                lstViewQuestion.SelectedItems[0].Remove();
            }
            else
                MessageBox.Show("Выберите вопрос!");
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (lstViewIstochnik.SelectedItems[0] != null)
                lstViewIstochnik.SelectedItems[0].Remove();
            else
                MessageBox.Show("Выберите раздел!");
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            btnIstochnik_Click(sender, e);
        }

        private void rtBQuestion_TextChanged(object sender, EventArgs e)
        {
            //Changes = true;
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog()==DialogResult.OK)
            {
                string temp=openFile.InitialDirectory+openFile.FileName;
                PicturePath = temp;
                img = Image.FromFile(temp);
                if (img.Width > 635)
                    MessageBox.Show("Картинка слишком большая!");
                else
                {
                    Clipboard.Clear();
                    Clipboard.SetImage(img);
                    rtBQuestion.Paste();
                    Clipboard.Clear();
                    Picture = true;
                }
            }
        }

        private void TestCreate_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (MessageBox.Show("Сохранить тест? ", "Создатель тестов", MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Yes:
                    switch (saveFileDialog1.ShowDialog())
                    {
                        case DialogResult.OK:
                            {
                                EventArgs events = new EventArgs();
                                btnTestDone_Click(sender, events);
                            }
                            break;
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                    }
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

        private void btnSaveQ_Click(object sender, EventArgs e)
        {
            Questions[NumItems].num = kolvoQuest;
            Questions[NumItems].type_question = cBSelect.Text;
            if (Picture == false)
                Questions[NumItems].question = rtBQuestion.Text;
            else
                Questions[NumItems].question = PicturePath;
            Questions[NumItems].answ1 = txtB1.Text;
            Questions[NumItems].price = Int32.Parse(NumberList.Value.ToString());
            if (cBSelect.Text != "Свободный ответ")
            {
                Questions[NumItems].answ2 = txtB2.Text;
                Questions[NumItems].answ3 = txtB3.Text;
                Questions[NumItems].answ4 = txtB4.Text;
            }
            if (cBSelect.SelectedIndex == 0)
                if (rad1.Checked == true)
                {
                    Questions[NumItems].rightans[0] = txtB1.Text;
                   // rad1.Checked = false;
                }
                else
                    if (rad2.Checked == true)
                    {
                        Questions[NumItems].rightans[0] = txtB2.Text;
                      //  rad2.Checked = false;
                    }
                    else
                        if (rad3.Checked == true)
                        {
                            Questions[NumItems].rightans[0] = txtB3.Text;
                       //     rad3.Checked = false;
                        }
                        else
                        {
                            if (rad4.Checked == true)
                            {
                                Questions[NumItems].rightans[0] = txtB4.Text;
                           //     rad4.Checked = false;
                            }
                        }
            if (cBSelect.SelectedIndex == 1)
            {
                if (cB1.Checked == true)
                {
                    Questions[NumItems].rightans[0] = txtB1.Text;
                  //  cB1.Checked = false;
                }
                if (cB2.Checked == true)
                {
                    Questions[NumItems].rightans[1] = txtB2.Text;
                //    cB2.Checked = false;
                }
                if (cB3.Checked == true)
                {
                    Questions[NumItems].rightans[2] = txtB3.Text;
                 //   cB3.Checked = false;
                }
                if (cB4.Checked == true)
                {
                    Questions[NumItems].rightans[3] = txtB4.Text;
                //    cB4.Checked = false;
                }
            }
            if (cBSelect.SelectedIndex == 2)
            {
                if (txtB1.Text != "")
                    Questions[NumItems].rightans[0] = txtB1.Text;
                if (txtB2.Text != "")
                    Questions[NumItems].rightans[1] = txtB2.Text;
                if (txtB3.Text != "")
                    Questions[NumItems].rightans[2] = txtB3.Text;
                if (txtB4.Text != "")
                    Questions[NumItems].rightans[3] = txtB4.Text;
            }
            if (cBSelect.SelectedIndex == 3)
                Questions[NumItems].rightans[0] = txtB1.Text;
            if (cBSelect.SelectedIndex == 4)
            {
                Questions[NumItems].rightans[0] = txtB1.Text;
                Questions[NumItems].rightans[1] = txtB2.Text;
                Questions[NumItems].rightans[2] = txtB3.Text;
                Questions[NumItems].rightans[3] = txtB4.Text;
            }
            for (int i = 0; i <= lstViewIstochnik.Items.Count - 1; i++)
                Questions[NumItems].part[i] = lstViewIstochnik.Items[i].Text;
            MessageBox.Show("Изменения сохранены");
        }

    }
}
