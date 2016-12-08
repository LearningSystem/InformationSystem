using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace NewBlackBox
{
    public partial class regForm : Form
    {
        //SqlConnection conn;
        
        //string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public regForm()
        {
            InitializeComponent();
            
        }


        private void regForm_Load(object sender, EventArgs e)
        {
            //textBox1.Text = "";
            //textBox2.Text = "";
            //textBox3.Text = "";
            //textBox4.Text = "";
            clearColumns();
            label6.Visible = false;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Студент");
            comboBox1.Items.Add("Преподаватель");
            //comboBox1.Items.Add("Администратор");
            comboBox1.SelectedIndex = 0;
            //textBox1.Focus();
        }

        private void checkStudent()
        {
            string fio = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text+" "+textBox5.Text;
            BlackBox bb = new BlackBox(fio, "-");
            bb.Show();    
            this.Hide();
        }

        private void checkTeacher()
        {
            MainPrepod mp = new MainPrepod();
            mp.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
                switch (comboBox1.SelectedIndex.ToString())
                {
                    case "0":
                        {
                            if ((comboBox1.SelectedIndex == 0) && (textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox5.Text!=""))
                            {
                                checkStudent();
                            }
                        }break;
                    case "1":
                        {
                            if ((textBox4.Text == "qwertyuiop") && (comboBox1.SelectedIndex == 1))
                            {
                                checkTeacher();
                            }
                            else
                                if ((comboBox1.SelectedIndex == 1))
                                    label6.Visible = true;

                        }break;
                }
            //if ((textBox1.Text!="")||(textBox2.Text!="")||(textBox3.Text!="")||(textBox4.Text!=""))
            //{
            //    label6.Visible = true;
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedIndex == 2)
            //{
            //    textBox1.Enabled = false;
            //    textBox2.Enabled = false;
            //    textBox3.Enabled = false;
            //}
            //else
            //{
            //    textBox1.Enabled = true;
            //    textBox2.Enabled = true;
            //    textBox3.Enabled = true;
            //}
            //clearColumns();
            //if (comboBox1.SelectedIndex == 1)
            //{
            //    clearColumns();
            //}
            clearColumns();
            if (comboBox1.SelectedIndex==0)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = false;
                textBox5.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = true;
                textBox5.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?","Выход",MessageBoxButtons.YesNoCancel)==DialogResult.Yes)
               Application.Exit();
        }

        private void clearColumns()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
