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
        public TextQuestion tq = new TextQuestion();
        List<TextQuestion> Questions = new List<TextQuestion>();
        TextQuestion tek;
        public bool Changes = false;
        public int number = -1;
        public bool Picture = false;
        public string PicturePath = null;
        public int NumItems;
        public string NameTest;
        public bool SaveTest = false;
        int NumTeacher;
        
        string numTest;
        public TestCreate(XmlTextWriter _writer, string _numTest, string _nameTest,int _numTeacher)
        {
            InitializeComponent();
            writer = _writer;
            numTest = _numTest;
            NameTest = _nameTest;
            NumTeacher = _numTeacher;
            
        }//

        private void TestCreate_Load(object sender, EventArgs e)
        {
            cBSelect.SelectedIndex = -1;
            tabControl1.SelectedIndex = 1;
            lstViewQuestion.Items.Add("Вопрос № " + kolvoQuest);
            tek = new TextQuestion();
            cBOtch.SelectedIndex = 0;
            btnSaveQ.Enabled = false;
            btnAdd.Enabled = true;
            openFile.InitialDirectory = PathDirectory.TestPath;
            saveFileDialog1.InitialDirectory = PathDirectory.TestPath;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (numList1.Value == 0 || numList2.Value == 0 || numList3.Value == 0 || numList4.Value == 0)
                {
                    if (MessageBox.Show("Вы не установили разбаловку. Вы будете ее устанавливать?","Замечание",MessageBoxButtons.YesNo)==DialogResult.Yes)
                    {
                        tabControl1.SelectedIndex = 1;
                    }
                    else
                    {
                        tabControl1.SelectedIndex = 0;
                    }
                }
                cBSelect.SelectedIndex = 0;
                //добавить кусок кода про то чтобы вес вопроса сразу висел
            }
            //вставить кусок кода про то что не выставлена разбаловка
        }

        private void cBSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Changes = true;
            
            if (cBSelect.SelectedIndex == 0)
            {
                Clear();
                ShowHideControls(true);
                #region Создание дин.элементов для одного ответа
                //rad1 = new RadioButton();
                //rad2 = new RadioButton();
                //rad3 = new RadioButton();
                //rad4 = new RadioButton();
                ////-------------------------
                //rad1.Name = "radQuest1";
                //rad1.Location = new Point(6, 53);
                //rad1.Size = new Size(14, 13);
                //gB3.Controls.Add(rad1);
                ////-------------------------
                //rad2.Name = "radQuest2";
                //rad2.Location = new Point(285, 53);
                //rad2.Size = new Size(14, 13);
                //gB3.Controls.Add(rad2);
                ////-------------------------
                //rad3.Name = "radQuest3";
                //rad3.Location = new Point(6, 132);
                //rad3.Size = new Size(14, 13);
                //gB3.Controls.Add(rad3);
                ////-------------------------
                //rad4.Name = "radQuest4";
                //rad4.Location = new Point(285, 132);
                //rad4.Size = new Size(14, 13);
                //gB3.Controls.Add(rad4);
                //-------------------------
                CreateBut("rad");
                #endregion
                NumberList.Value = numList1.Value;
            }
            else
                if (cBSelect.SelectedIndex == 1)
                {
                    Clear();
                    ShowHideControls(true);
                    #region Создание дин.элементов для неск.ответов

                    //cB1 = new CheckBox();
                    //cB2 = new CheckBox();
                    //cB3 = new CheckBox();
                    //cB4 = new CheckBox();
                    ////-------------------------
                    //cB1.Name = "radQuest1";
                    //cB1.Location = new Point(6, 53);
                    //cB1.Size = new Size(14, 13);
                    //gB3.Controls.Add(cB1);
                    ////-------------------------
                    //cB2.Name = "radQuest2";
                    //cB2.Location = new Point(285, 53);
                    //cB2.Size = new Size(14, 13);
                    //gB3.Controls.Add(cB2);
                    ////-------------------------
                    //cB3.Name = "radQuest3";
                    //cB3.Location = new Point(6, 132);
                    //cB3.Size = new Size(14, 13);
                    //gB3.Controls.Add(cB3);
                    ////-------------------------
                    //cB4.Name = "radQuest4";
                    //cB4.Location = new Point(285, 132);
                    //cB4.Size = new Size(14, 13);
                    //gB3.Controls.Add(cB4);
                    CreateBut("cB");
                    //-------------------------
                    #endregion
                    NumberList.Value = numList2.Value;
                }
                else
                    if (cBSelect.SelectedIndex == 2)
                    {
                        Clear();
                        ShowHideControls(true);
                        NumberList.Value = numList3.Value;
                    }
                    else
                    {
                        if (cBSelect.SelectedIndex == 3)
                        {
                            Clear();
                            ShowHideControls(false);
                            label6.Visible = true;
                            NumberList.Value = numList4.Value;
                        }
                        else
                        {
                            Clear();
                            ShowHideControls(true);
                            #region Создание дин.элементов для ответа сопоставления

                            lbl7 = new Label();
                            lbl7.AutoSize = false;
                            lbl7.Size = new Size(45, 5);
                            lbl7.Location = new Point(245, 54);
                            lbl7.Text = "     ";
                            lbl7.BackColor = SystemColors.InactiveCaption;
                            lbl7.Visible = true;
                            gB3.Controls.Add(lbl7);
                        
                            lbl6 = new Label();
                            lbl6.AutoSize = false;
                            lbl6.Size = new Size(45, 5);
                            lbl6.Location = new Point(245, 134);
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
            //gB3.Controls.Clear();
            if (rad1 != null)
            {
                gB3.Controls.Remove(rad1);
                gB3.Controls.Remove(rad2);
                gB3.Controls.Remove(rad3);
                gB3.Controls.Remove(rad4);
                rad1 = null;
                rad2 = null;
                rad3 = null;
                rad4 = null;
            }
            if (cB1 != null)
            {
                gB3.Controls.Remove(cB1);
                gB3.Controls.Remove(cB2);
                gB3.Controls.Remove(cB3);
                gB3.Controls.Remove(cB4);
                cB1 = null;
                cB2 = null;
                cB3 = null;
                cB4 = null;
            }
            if (lbl6 != null)
            {
                gB3.Controls.Remove(lbl6);
                gB3.Controls.Remove(lbl7);
                lbl6 = null;
                lbl7 = null;
            }
            //добавить стиралку для 2 черт
        }

        public void ShowHideControls(bool status)
        {
            txtBox2.Visible = status;
            txtBox3.Visible = status;
            txtBox4.Visible = status;
            label6.Visible = status;
            label7.Visible = status;
            label8.Visible = status;
            label9.Visible = status;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            tek.num = kolvoQuest;
            tek.type_question = cBSelect.Text;
            if (Picture == false)
                tek.question = rtBQuestion.Text;
            else
                tek.question = PicturePath;
            tek.answ1 = txtBox1.Text;
            tek.price = Int32.Parse(NumberList.Value.ToString());
            if (cBSelect.SelectedIndex != 3)
            {
                tek.answ2 = txtBox2.Text;
                tek.answ3 = txtBox3.Text;
                tek.answ4 = txtBox4.Text;
            }
            if (cBSelect.SelectedIndex == 0)
                if (rad1.Checked == true)
                    tek.rightans[0] = txtBox1.Text;
                else
                    if (rad2.Checked == true)
                        tek.rightans[0] = txtBox2.Text;
                    else
                        if (rad3.Checked == true)
                            tek.rightans[0] = txtBox3.Text;
                        else
                            tek.rightans[0] = txtBox4.Text;
            if (cBSelect.SelectedIndex == 1)
            {
                if (cB1.Checked == true)
                    tek.rightans[0] = txtBox1.Text;
                if (cB2.Checked == true)
                    tek.rightans[1] = txtBox2.Text;
                if (cB3.Checked == true)
                    tek.rightans[2] = txtBox3.Text;
                if (cB4.Checked == true)
                    tek.rightans[3] = txtBox4.Text;
            }
            if (cBSelect.SelectedIndex == 2)
            {
                if (txtBox1.Text != "")
                    tek.rightans[0] = txtBox1.Text;
                if (txtBox2.Text != "")
                    tek.rightans[1] = txtBox2.Text;
                if (txtBox3.Text != "")
                    tek.rightans[2] = txtBox3.Text;
                if (txtBox4.Text != "")
                    tek.rightans[3] = txtBox4.Text;
            }
            if (cBSelect.SelectedIndex == 3)
                tek.rightans[0] = txtBox1.Text;
            if (cBSelect.SelectedIndex == 4)
            {
                tek.rightans[0] = txtBox1.Text;
                tek.rightans[1] = txtBox2.Text;
                tek.rightans[2] = txtBox3.Text;
                tek.rightans[3] = txtBox4.Text;
            }
            if (lstViewIstochnik.Items.Count == 0)
            {
                if (MessageBox.Show("Вы будете добавлять ссылки на теоритические вопросы?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnIstochnik_Click(sender, e);

                }
            }
            if (((rtBQuestion.Text == "" || txtBox1.Text == "" || txtBox2.Text == "" || txtBox3.Text == "" || txtBox4.Text == "") && cBSelect.SelectedIndex != 3) || ((rtBQuestion.Text == "" || txtBox1.Text == "") && cBSelect.SelectedIndex == 3))
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
            txtBox1.Text = "";
            if (cBSelect.SelectedIndex != 3)
            {
                txtBox2.Text = "";
                txtBox3.Text = "";
                txtBox4.Text = "";
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
            if (SaveTest == false)
            {
                writer.WriteStartAttribute("Number");
                int p = Questions.Count;
                writer.WriteString(p.ToString());
                writer.WriteEndAttribute();
                for (int i = 0; i <= Questions.Count - 1; i++)
                {
                    writer.WriteStartElement("Question" + Questions[i].num);

                    writer.WriteStartElement("Text");
                    writer.WriteString(Questions[i].question);
                    writer.WriteEndElement();

                    #region TypeAnswer
                    //writer.WriteStartAttribute("Type Answer");
                    writer.WriteStartElement("TypeAnswer");
                    if (Questions[i].type_question == "Один вариант ответа")
                    {
                        writer.WriteString("One");
                        Questions[i].price = Int32.Parse(numList1.Value.ToString());
                    }
                    else
                        if (Questions[i].type_question == "Несколько вариантов ответа")
                        {
                            writer.WriteString("Several");
                            Questions[i].price = Int32.Parse(numList2.Value.ToString());
                        }
                        else
                            if (Questions[i].type_question == "Выстроить последовательность")
                            {
                                writer.WriteString("Sequence");
                                Questions[i].price = Int32.Parse(numList3.Value.ToString());
                            }
                            else
                                if (Questions[i].type_question == "Свободный ответ")
                                {
                                    writer.WriteString("Writing");
                                    Questions[i].price = Int32.Parse(numList4.Value.ToString());
                                }
                                else
                                {
                                    writer.WriteString("Comparison");
                                    Questions[i].price = Int32.Parse(numList5.Value.ToString());
                                }
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
                                    tmp = Questions[i].rightans[0] + "==" + Questions[i].rightans[1];
                                    tmp = tmp + "|" + Questions[i].rightans[2] + "==" + Questions[i].rightans[3];
                                    writer.WriteString(tmp);
                                }
                    //writer.WriteEndAttribute();
                    writer.WriteEndElement();
                    #endregion

                    #region Part
                    //writer.WriteStartAttribute("Part");
                    writer.WriteStartElement("Part");
                    string temp = null;
                    for (int u = 0; u <= 9; u++)
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
                    for (int h = 0; h <= 9; h++)
                    {
                        if (temp != null)
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

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                //Завершение записи
                writer.WriteStartElement("Time");

                writer.WriteString(numTime.Value.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Report");
                writer.WriteString(cBOtch.Text);
                writer.WriteEndElement();

                //Завершаем написание документа
                writer.WriteEndElement(); //Закрывем основной тэг - test
                writer.WriteEndDocument(); //Закрываем документ

                writer.Close();

                MessageBox.Show("Тест был успешно создан!", "Выход");
                insertTest();
                SaveTest = true;
            }
            //ВСЕ РАВНО ПОТОМ ОТКРЫТЬ!
            string pathprepod = "";
            conn = new SqlConnection(connectionString);
            using (conn)
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                try
                {
                    comm.CommandText = "select [Путь к папке] from Преподаватель where [№ преподавателя]="+"'"+NumTeacher.ToString()+"'";
                    comm.ExecuteNonQuery();
                    SqlDataReader rdr = comm.ExecuteReader();
                    rdr.Read();
                    pathprepod = rdr[0].ToString();
                    rdr.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            string inputdir = Application.StartupPath + pathprepod + "Тесты\\" + NameTest + ".xml";
            File.Copy(Application.StartupPath + "\\" + NameTest + ".xml", inputdir);
            File.Delete(Application.StartupPath + "\\" + NameTest + ".xml");
            menuPrepod newmenu = new menuPrepod(NumTeacher.ToString());
            this.Hide();
            newmenu.Show();
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
            for (int g = 0; g <= Questions.Count - 1; g++)
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
            //MessageBox.Show(lstViewQuestion.SelectedItems[0].Tag.ToString());
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
                    tq.answ1 = txtBox1.Text;
                    tq.price = Int32.Parse(NumberList.Value.ToString());
                    if (cBSelect.Text != "Свободный ответ")
                    {
                        tq.answ2 = txtBox2.Text;
                        tq.answ3 = txtBox3.Text;
                        tq.answ4 = txtBox4.Text;
                    }
                    if (cBSelect.SelectedIndex == 0)
                        if (rad1.Checked == true)
                        {
                            tq.rightans[0] = txtBox1.Text;
                            rad1.Checked = false;
                        }
                        else
                            if (rad2.Checked == true)
                            {
                                tq.rightans[0] = txtBox2.Text;
                                rad2.Checked = false;
                            }
                            else
                                if (rad3.Checked == true)
                                {
                                    tq.rightans[0] = txtBox3.Text;
                                    rad3.Checked = false;
                                }
                                else
                                {
                                    if (rad4.Checked == true)
                                    {
                                        tq.rightans[0] = txtBox4.Text;
                                        rad4.Checked = false;
                                    }
                                }
                    if (cBSelect.SelectedIndex == 1)
                    {
                        if (cB1.Checked == true)
                        {
                            tq.rightans[0] = txtBox1.Text;
                            cB1.Checked = false;
                        }
                        if (cB2.Checked == true)
                        {
                            tq.rightans[1] = txtBox2.Text;
                            cB2.Checked = false;
                        }
                        if (cB3.Checked == true)
                        {
                            tq.rightans[2] = txtBox3.Text;
                            cB3.Checked = false;
                        }
                        if (cB4.Checked == true)
                        {
                            tq.rightans[3] = txtBox4.Text;
                            cB4.Checked = false;
                        }
                    }
                    if (cBSelect.SelectedIndex == 2)
                    {
                        if (txtBox1.Text != "")
                            tq.rightans[0] = txtBox1.Text;
                        if (txtBox2.Text != "")
                            tq.rightans[1] = txtBox2.Text;
                        if (txtBox3.Text != "")
                            tq.rightans[2] = txtBox3.Text;
                        if (txtBox4.Text != "")
                            tq.rightans[3] = txtBox4.Text;
                    }
                    if (cBSelect.SelectedIndex == 3)
                        tq.rightans[0] = txtBox1.Text;
                    if (cBSelect.SelectedIndex == 4)
                    {
                        tq.rightans[0] = txtBox1.Text;
                        tq.rightans[1] = txtBox2.Text;
                        tq.rightans[2] = txtBox3.Text;
                        tq.rightans[3] = txtBox4.Text;
                    }
                    for (int i = 0; i <= lstViewIstochnik.Items.Count - 1; i++)
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
                    //btnSaveQ.Visible = true;
                    btnSaveQ.Enabled = true;
                    //btnAdd.Visible = false;
                    btnAdd.Enabled = false;
                    int h = Int32.Parse(lstViewQuestion.SelectedItems[0].Tag.ToString());
                    //Clear();
                    if (Questions[h].type_question == "Один вариант ответа")
                    {
                        cBSelect.SelectedIndex = 0;
                       // CreateBut("rad");
                        //ShowHideControls(true);
                    }
                    if (Questions[h].type_question == "Несколько вариантов ответа")
                    {
                        cBSelect.SelectedIndex = 1;
                        //CreateBut("cB");
                        //ShowHideControls(true);
                    }
                    if (Questions[h].type_question == "Выстроить последовательность")
                    {
                        cBSelect.SelectedIndex = 2;
                        //ShowHideControls(true);
                    }
                    if (Questions[h].type_question == "Свободный ответ")
                    {
                        cBSelect.SelectedIndex = 3;
                        //ShowHideControls(false);
                    }
                    if( Questions[h].type_question == "Сопоставление")
                    {
                        cBSelect.SelectedIndex = 4;
                        //ShowHideControls(true);
                    }
                    if (File.Exists(Questions[h].question) == false)
                        rtBQuestion.Text = Questions[h].question;
                    else
                    {
                        img = Image.FromFile(Questions[h].question);
                        Clipboard.Clear();
                        Clipboard.SetImage(img);
                        rtBQuestion.Paste();
                        Clipboard.Clear();
                    }

                    txtBox1.Text = Questions[h].answ1;
                    if (cBSelect.SelectedIndex != 3)
                    {
                        txtBox2.Text = Questions[h].answ2;
                        txtBox3.Text = Questions[h].answ3;
                        txtBox4.Text = Questions[h].answ4;
                    }
                    NumberList.Value = Questions[h].price;
                    if (cBSelect.SelectedIndex == 0)
                    {
                        if (Questions[h].rightans[0] == txtBox1.Text)
                            rad1.Checked = true;
                        if (Questions[h].rightans[0] == txtBox2.Text)
                            rad2.Checked = true;
                        if (Questions[h].rightans[0] == txtBox3.Text)
                            rad3.Checked = true;
                        if (Questions[h].rightans[0] == txtBox4.Text)
                            rad4.Checked = true;
                    }
                    if (cBSelect.SelectedIndex == 1)
                    {
                        if (Questions[h].rightans[0] == txtBox1.Text)
                            cB1.Checked = true;
                        if (Questions[h].rightans[1] == txtBox2.Text)
                            cB2.Checked = true;
                        if (Questions[h].rightans[2] == txtBox3.Text)
                            cB3.Checked = true;
                        if (Questions[h].rightans[3] == txtBox4.Text)
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
                    //btnSaveQ.Visible = false;
                    btnSaveQ.Enabled = false;
                    //btnAdd.Visible = true;
                    btnAdd.Enabled = true;
                    //Clear();
                    if (tq.type_question == "Один вариант ответа")
                    {
                        cBSelect.SelectedIndex = 0;
                        //CreateBut("rad");
                        //ShowHideControls(true);
                    }
                    if (tq.type_question == "Несколько вариантов ответа")
                    {
                        cBSelect.SelectedIndex = 1;
                        //CreateBut("cB");
                        //ShowHideControls(true);
                    }
                    if (tq.type_question == "Выстроить последовательность")
                    { 
                        cBSelect.SelectedIndex = 2;
                        //ShowHideControls(true);
                    }
                    if (tq.type_question == "Свободный ответ")
                    {
                        cBSelect.SelectedIndex = 3;
                        //ShowHideControls(false);
                    }
                    if (tq.type_question == "Сопоставление")
                    {
                        cBSelect.SelectedIndex = 4;
                        //ShowHideControls(true);
                    }
                    if (File.Exists(tq.question) == false)
                        rtBQuestion.Text = tq.question;
                    else
                    {
                        img = Image.FromFile(tq.question);
                        Clipboard.Clear();
                        Clipboard.SetImage(img);
                        rtBQuestion.Paste();
                        Clipboard.Clear();
                    }
                    txtBox1.Text = tq.answ1;
                    if (cBSelect.SelectedIndex != 3)
                    {
                        txtBox2.Text = tq.answ2;
                        txtBox3.Text = tq.answ3;
                        txtBox4.Text = tq.answ4;
                    }

                    if (tq.type_question == "Один вариант ответа")
                    {
                        if (tq.rightans[0] == txtBox1.Text)
                            rad1.Checked = true;
                        if (tq.rightans[0] == txtBox2.Text)
                            rad2.Checked = true;
                        if (tq.rightans[0] == txtBox3.Text)
                            rad3.Checked = true;
                        if (tq.rightans[0] == txtBox4.Text)
                            rad4.Checked = true;
                    }
                    if (tq.type_question == "Несколько вариантов ответа")
                    {
                        if (tq.rightans[0] == txtBox1.Text)
                            cB1.Checked = true;
                        if (tq.rightans[1] == txtBox2.Text)
                            cB2.Checked = true;
                        if (tq.rightans[2] == txtBox3.Text)
                            cB3.Checked = true;
                        if (tq.rightans[3] == txtBox4.Text)
                            cB4.Checked = true;
                    }

                    NumberList.Value = tq.price;

                    lstViewIstochnik.Items.Clear();
                    for (int i = 0; i <= 9; i++)
                        if (tq.part[i] != null)
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
            if (lstViewQuestion.SelectedItems[0] != null)// && lstViewQuestion.SelectedItems[0].Tag != null)
            {
                if (lstViewQuestion.SelectedItems[0].Tag != null)
                {
                    int u = Int32.Parse(lstViewQuestion.SelectedItems[0].Tag.ToString());
                    Questions.RemoveAt(Int32.Parse(lstViewQuestion.SelectedItems[0].Tag.ToString()));
                    for (int y = u + 1; y < lstViewQuestion.Items.Count-1;y++ )
                    {
                        lstViewQuestion.Items[y].Tag = u;
                        u++;
                        //lstViewQuestion.Items[y].Text = "Вопрос №" + y.ToString();
                    }
                    lstViewQuestion.SelectedItems[0].Remove();
                    for (int y = 0; y <= lstViewQuestion.Items.Count - 1; y++)
                    {
                        lstViewQuestion.Items[y].Text = "Вопрос №" + (y + 1).ToString();
                    }
                    kolvoQuest--;
                    rtBQuestion.Text = "";
                    txtBox1.Text = "";
                    if (txtBox2 != null)
                    {
                        txtBox2.Text = "";
                        txtBox3.Text = "";
                        txtBox4.Text = "";
                    }
                    if (rad1!=null)
                    {
                        rad1.Checked = false;
                        rad2.Checked = false;
                        rad3.Checked = false;
                        rad4.Checked = false;
                    }
                    else
                    {
                        if (cB1!=null)
                        {
                            cB1.Checked = false;
                            cB2.Checked = false;
                            cB3.Checked = false;
                            cB4.Checked = false;
                        }
                    }


                }
                else
                {
                    MessageBox.Show("Добавьте вопрос, прежде чем удалить его!");
                }
            }
            else
            {
                if (lstViewQuestion.SelectedItems[0].Tag != null)
                     MessageBox.Show("Выберите вопрос!");
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (lstViewIstochnik.SelectedItems[0] != null)
            {
                int partindex = lstViewIstochnik.SelectedItems[0].Index;
                int quesindex = Int32.Parse(lstViewQuestion.SelectedItems[0].Tag.ToString());
                Questions[quesindex].part[partindex] = null;
                lstViewIstochnik.SelectedItems[0].Remove();
            }
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

        private void TestCreate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SaveTest == false)
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
                    case DialogResult.No:
                        writer.Close();
                        File.Delete(Application.StartupPath + "\\" + NameTest + ".xml");
                        SaveTest = true;
                        //Application.Exit();
                        break;
                }
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
            Questions[NumItems].answ1 = txtBox1.Text;
            Questions[NumItems].price = Int32.Parse(NumberList.Value.ToString());
            if (cBSelect.Text != "Свободный ответ")
            {
                Questions[NumItems].answ2 = txtBox2.Text;
                Questions[NumItems].answ3 = txtBox3.Text;
                Questions[NumItems].answ4 = txtBox4.Text;
            }
            if (cBSelect.SelectedIndex == 0)
                if (rad1.Checked == true)
                {
                    Questions[NumItems].rightans[0] = txtBox1.Text;
                    // rad1.Checked = false;
                }
                else
                    if (rad2.Checked == true)
                    {
                        Questions[NumItems].rightans[0] = txtBox2.Text;
                        //  rad2.Checked = false;
                    }
                    else
                        if (rad3.Checked == true)
                        {
                            Questions[NumItems].rightans[0] = txtBox3.Text;
                            //     rad3.Checked = false;
                        }
                        else
                        {
                            if (rad4.Checked == true)
                            {
                                Questions[NumItems].rightans[0] = txtBox4.Text;
                                //     rad4.Checked = false;
                            }
                        }
            if (cBSelect.SelectedIndex == 1)
            {
                if (cB1.Checked == true)
                {
                    Questions[NumItems].rightans[0] = txtBox1.Text;
                    //  cB1.Checked = false;
                }
                if (cB2.Checked == true)
                {
                    Questions[NumItems].rightans[1] = txtBox2.Text;
                    //    cB2.Checked = false;
                }
                if (cB3.Checked == true)
                {
                    Questions[NumItems].rightans[2] = txtBox3.Text;
                    //   cB3.Checked = false;
                }
                if (cB4.Checked == true)
                {
                    Questions[NumItems].rightans[3] = txtBox4.Text;
                    //    cB4.Checked = false;
                }
            }
            if (cBSelect.SelectedIndex == 2)
            {
                if (txtBox1.Text != "")
                    Questions[NumItems].rightans[0] = txtBox1.Text;
                if (txtBox2.Text != "")
                    Questions[NumItems].rightans[1] = txtBox2.Text;
                if (txtBox3.Text != "")
                    Questions[NumItems].rightans[2] = txtBox3.Text;
                if (txtBox4.Text != "")
                    Questions[NumItems].rightans[3] = txtBox4.Text;
            }
            if (cBSelect.SelectedIndex == 3)
                Questions[NumItems].rightans[0] = txtBox1.Text;
            if (cBSelect.SelectedIndex == 4)
            {
                Questions[NumItems].rightans[0] = txtBox1.Text;
                Questions[NumItems].rightans[1] = txtBox2.Text;
                Questions[NumItems].rightans[2] = txtBox3.Text;
                Questions[NumItems].rightans[3] = txtBox4.Text;
            }
            for (int i = 0; i <= lstViewIstochnik.Items.Count - 1; i++)
                Questions[NumItems].part[i] = null;
            for (int i = 0; i <= lstViewIstochnik.Items.Count - 1; i++)
                Questions[NumItems].part[i] = lstViewIstochnik.Items[i].Text;
            MessageBox.Show("Изменения сохранены.","Изменения");
        }

        private void вставкаКартинкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFilePicture.ShowDialog() == DialogResult.OK)
            {
                //string temp = openFile.InitialDirectory + openFile.FileName;
                string temp = openFilePicture.InitialDirectory + openFilePicture.FileName;
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

        private void тестГотовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            MessageBox.Show("Проверьте все настройки перед созданием теста!","Замечание");
        }

        void CreateBut(string nameBut)
        {
            if (nameBut == "rad")
            {
                rad1 = new RadioButton();
                rad2 = new RadioButton();
                rad3 = new RadioButton();
                rad4 = new RadioButton();
                //-------------------------
                rad1.Name = "radQuest1";
                rad1.Location = new Point(6, 53);
                rad1.Size = new Size(14, 13);
                gB3.Controls.Add(rad1);
                //-------------------------
                rad2.Name = "radQuest2";
                rad2.Location = new Point(285, 53);
                rad2.Size = new Size(14, 13);
                gB3.Controls.Add(rad2);
                //-------------------------
                rad3.Name = "radQuest3";
                rad3.Location = new Point(6, 132);
                rad3.Size = new Size(14, 13);
                gB3.Controls.Add(rad3);
                //-------------------------
                rad4.Name = "radQuest4";
                rad4.Location = new Point(285, 132);
                rad4.Size = new Size(14, 13);
                gB3.Controls.Add(rad4);
            }
            else
            {
                cB1 = new CheckBox();
                cB2 = new CheckBox();
                cB3 = new CheckBox();
                cB4 = new CheckBox();
                //-------------------------
                cB1.Name = "radQuest1";
                cB1.Location = new Point(6, 53);
                cB1.Size = new Size(14, 13);
                gB3.Controls.Add(cB1);
                //-------------------------
                cB2.Name = "radQuest2";
                cB2.Location = new Point(285, 53);
                cB2.Size = new Size(14, 13);
                gB3.Controls.Add(cB2);
                //-------------------------
                cB3.Name = "radQuest3";
                cB3.Location = new Point(6, 132);
                cB3.Size = new Size(14, 13);
                gB3.Controls.Add(cB3);
                //-------------------------
                cB4.Name = "radQuest4";
                cB4.Location = new Point(285, 132);
                cB4.Size = new Size(14, 13);
                gB3.Controls.Add(cB4);

            }

        }
    }
}
