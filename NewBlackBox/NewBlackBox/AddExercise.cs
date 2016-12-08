using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NewBlackBox
{
    public partial class AddExercise : Form
    {
        string type = "";
        ComboBox comboBox1;
        RichTextBox richTextBox2;
        bool TestGo = false;
        string NumberTek;
        int NumberTekTest = 1;
        bool click = false;
        bool form_type;
        public AddExercise(string _type, bool _form_type)
        {
            InitializeComponent();
            type = _type;
            Podgotovka(type);
            form_type = _form_type;
        }

        void Podgotovka(string _type)
        {
            //label3.Text = "Тест №" + NumberTekTest.ToString();
            if (_type == "Exercise")
            {
                label3.Text = "Тест №" + NumberTekTest.ToString();
                lblName.Text = "Номер задачи:";
                richTextBox2 = new RichTextBox() { Location = new Point(153, 13), Height = 22, Width = 60, Enabled = true, Visible = true };
                panel1.Controls.Add(richTextBox2);
                TestGo = false;
            }
            else
            {
                this.Text = "Добавить тесты";
                label3.Text = "Тест №";
                lblName.Text = "Выберите задачу:";
                btnSave.Visible = false;
                btnSave.Enabled = false;
                comboBox1 = new ComboBox() { Location = new Point(153, 10), Height = 22, Width = 172, Enabled = true, Visible = true, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
                comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
                panel1.Controls.Add(comboBox1);
                TestGo = true;
                NotVisible(false);
            }
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FileInfo file = new FileInfo(Application.StartupPath + "\\Exercises\\" + comboBox1.Text + ".rtf");
            //richTextBox1.Text = File.ReadAllText(Application.StartupPath + "\\Exercises\\" + comboBox1.Text + ".rtf");
            richTextBox1.LoadFile(Application.StartupPath + "\\Exercises\\" + comboBox1.Text + ".rtf");
            //string temp = Application.StartupPath + "\\Exercises\\" + comboBox1.Text + ".rtf";
            richTextBox1.Enabled = false;
            try
            {
                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\Tests\\" + comboBox1.Text);
                int max = 0;
                foreach (FileInfo file in dir.GetFiles("*.txt"))
                {
                    //MessageBox.Show(dir.GetFiles("*.rtf").Max().ToString());
                    int oneIndex = file.FullName.IndexOf(".");
                    string temp = file.FullName.Remove(oneIndex, 4);
                    int IndexTwo = temp.LastIndexOf("\\");
                    temp = temp.Remove(0, IndexTwo + 1);
                    int one = Int32.Parse(temp);
                    if (one > max)
                        max = one;
                }
                max = max + 1;
                NumberTekTest = max;
            }
            catch (Exception ex)
            {
                NumberTekTest = 1;
            }
            label3.Text = "Тест №" + NumberTekTest.ToString();
            NotVisible(true);
        }

        private void AddExercise_Load(object sender, EventArgs e)
        {
            if (type == "Exercise")
            {
                //MessageBox.Show(Application.ExecutablePath);
                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\Exercises\\");
                int max = 0;
                foreach (FileInfo file in dir.GetFiles("*.rtf"))
                {
                    //MessageBox.Show(dir.GetFiles("*.rtf").Max().ToString());
                    int oneIndex = file.FullName.IndexOf(".");
                    string temp = file.FullName.Remove(oneIndex, 4);
                    int IndexTwo = temp.LastIndexOf("\\");
                    temp = temp.Remove(0, IndexTwo + 1);
                    int one = Int32.Parse(temp);
                    if (one > max)
                        max = one;
                }
                max = max + 1;
                richTextBox2.Text = max.ToString();
                richTextBox2.Enabled = false;
                if (TestGo)
                    NotVisible(true);
                else
                    NotVisible(false);
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\Exercises\\");
                //int max = 0;
                foreach (FileInfo file in dir.GetFiles("*.rtf"))
                {
                    //MessageBox.Show(dir.GetFiles("*.rtf").Max().ToString());
                    int oneIndex = file.FullName.IndexOf(".");
                    string temp = file.FullName.Remove(oneIndex, 4);
                    int IndexTwo = temp.LastIndexOf("\\");
                    temp = temp.Remove(0, IndexTwo + 1);
                    comboBox1.Items.Add(temp);
                }
                if (comboBox1.Items.Count == 0)
                    NotVisible(false);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (type == "Exercise")
            {
                if (MessageBox.Show("Вы уверены, что хотите сохранить задачу?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //File.WriteAllText(Application.StartupPath + "\\Exercises\\" + richTextBox2.Text + ".rtf", richTextBox1.Text);
                    //--
                    richTextBox1.SaveFile(Application.StartupPath + "\\Exercises\\" + richTextBox2.Text + ".rtf");
                    NumberTek = richTextBox2.Text;
                    Directory.CreateDirectory(Application.StartupPath + "\\Tests\\" + richTextBox2.Text);
                    MessageBox.Show("Ваша задача сохранена.", "Сохранение");
                    TestGo = true;
                    NotVisible(true);
                }
                else
                {
                    if (!File.Exists(Application.StartupPath + "\\Exercises\\" + richTextBox2.Text + ".rtf"))
                    {
                        TestGo = false;
                        NotVisible(false);
                    }
                }
            }

        }

        void NotVisible(bool _flag)
        {
            if (_flag)
            {
                btnAddTest.Enabled = true;
                richTextBox3.Enabled = true;
                richTextBox4.Enabled = true;
            }
            else
            {
                btnAddTest.Enabled = false;
                richTextBox3.Enabled = false;
                richTextBox4.Enabled = false;
            }
        }

        private void btnAddTest_Click(object sender, EventArgs e)
        {
            if (type == "Exercise")
            {
                //NumberTekTest = 1;
                //RichTextBox rb = new RichTextBox();
                //rb.Text = "Parameters:" + "\r\n" + richTextBox3.Text + " \r\n" + "Answers:" + "\r\n" + richTextBox4.Text + "\r\n";
                //rb.SaveFile(Application.StartupPath + "\\Tests\\" + NumberTek + "\\" + NumberTekTest + ".rtf");
                //File.WriteAllText(Application.StartupPath + "\\Tests\\" + NumberTek + "\\" + NumberTekTest + ".txt", "Parameters:" + Environment.NewLine + richTextBox3.Text + Environment.NewLine + "Answers:" + Environment.NewLine + richTextBox4.Text);
                Directory.CreateDirectory(Application.StartupPath + "\\Tests\\" + richTextBox2.Text);
                File.WriteAllText(Application.StartupPath + "\\Tests\\" + richTextBox2.Text + "\\" + NumberTekTest.ToString() + ".txt", "Parameters:" + Environment.NewLine);
                File.AppendAllLines(Application.StartupPath + "\\Tests\\" + richTextBox2.Text + "\\" + NumberTekTest.ToString() + ".txt", richTextBox3.Lines);
                File.AppendAllText(Application.StartupPath + "\\Tests\\" + richTextBox2.Text + "\\" + NumberTekTest.ToString() + ".txt", "Answers:" + Environment.NewLine);
                File.AppendAllLines(Application.StartupPath + "\\Tests\\" + richTextBox2.Text + "\\" + NumberTekTest.ToString() + ".txt", richTextBox4.Lines);
                NumberTekTest++;
            }
            else
            {
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\Tests\\" + comboBox1.Text);
                    int max = 0;
                    foreach (FileInfo file in dir.GetFiles("*.txt"))
                    {
                        //MessageBox.Show(dir.GetFiles("*.rtf").Max().ToString());
                        int oneIndex = file.FullName.IndexOf(".");
                        string temp = file.FullName.Remove(oneIndex, 4);
                        int IndexTwo = temp.LastIndexOf("\\");
                        temp = temp.Remove(0, IndexTwo + 1);
                        int one = Int32.Parse(temp);
                        if (one > max)
                            max = one;
                    }
                    max = max + 1;
                    NumberTekTest = max;
                }
                catch(Exception ex)
                {
                    NumberTekTest = 1;
                    Directory.CreateDirectory(Application.StartupPath + "\\Tests\\" + comboBox1.Text);
                }
                //File.WriteAllText(Application.StartupPath + "\\Tests\\" + comboBox1.Text + "\\" + NumberTekTest.ToString() + ".txt", "Parameters:" + Environment.NewLine + richTextBox3.Text + Environment.NewLine + "Answers:" + Environment.NewLine + richTextBox4.Text);
                File.WriteAllText(Application.StartupPath + "\\Tests\\" + comboBox1.Text + "\\" + NumberTekTest.ToString() + ".txt","Parameters:"+Environment.NewLine);
                File.AppendAllLines(Application.StartupPath + "\\Tests\\" + comboBox1.Text + "\\" + NumberTekTest.ToString() + ".txt", richTextBox3.Lines);
                File.AppendAllText(Application.StartupPath + "\\Tests\\" + comboBox1.Text + "\\" + NumberTekTest.ToString() + ".txt","Answers:" + Environment.NewLine);
                File.AppendAllLines(Application.StartupPath + "\\Tests\\" + comboBox1.Text + "\\" + NumberTekTest.ToString() + ".txt", richTextBox4.Lines);
                NumberTekTest++;
            }
            if (MessageBox.Show("Тест успешно добавлен. Хотите создать еще один тест?", "Добавление вопроса", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                richTextBox3.Text = "";
                richTextBox4.Text = "";
                label3.Text = "Тест №" + NumberTekTest.ToString();
                richTextBox3.Focus();
            }
            else
            {
                button1_Click(sender, e);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (form_type == false)
            {
                this.Hide();
                MainPrepod mainprep = new MainPrepod();
                mainprep.Show();
            }
            else
            {
                if (type == "Exercise")
                    MessageBox.Show("Задача добавлена успешно!", "Добавление задачи");
                else
                    MessageBox.Show("Тест добавлен успешно!", "Добавление теста");
                this.Hide();
            }
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (click == false)
            {
                richTextBox1.Text = "";
                click = true;
            }
        }
    }
}
