﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Prepod
{
    public partial class regForm : Form
    {
        SqlConnection conn;
        
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
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
            comboBox1.Items.Add("Администратор");
            comboBox1.SelectedIndex = 0;
            //textBox1.Focus();
        }

        private void checkStudent()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select [№ студента] from Студент where Фамилия = '"+ textBox1.Text +"' and Имя = '"+ textBox2.Text +"' and Отчество = '"+ textBox3.Text +"' and Пароль = '"+ textBox4.Text +"'";
            SqlDataReader rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                label6.Visible = false;
                rdr.Read();
                studentWork sw = new studentWork(rdr[0].ToString(),textBox4.Text);
                sw.Show();
                this.Hide();
            }
            else
            {
                label6.Visible = true;
                clearColumns();
            }
            rdr.Close();
            conn.Close();
        }

        private void checkTeacher()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select [№ преподавателя] from Преподаватель where Фамилия = '" + textBox1.Text + "' and Имя = '" + textBox2.Text + "' and Отчество = '" + textBox3.Text + "' and Пароль = '" + textBox4.Text + "'";
            SqlDataReader rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                label6.Visible = false;
                rdr.Read();
                menuPrepod tw = new menuPrepod(rdr[0].ToString());
                tw.Show();
                this.Hide();
            }
            else
            {
                label6.Visible = true;
                clearColumns();
            }
            rdr.Close();
            conn.Close();
        }

        private void checkAdmin()
        {
            if (textBox4.Text == "1")
            {
                administrator a = new administrator();
                a.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {            
                switch (comboBox1.SelectedIndex.ToString())
                {
                    case "0":
                        {
                            if ((textBox4.Text != "") && (comboBox1.SelectedIndex >= 0) && (textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
                            {
                                checkStudent();
                            }
                        }break;
                    case "1":
                        {
                            if ((textBox4.Text != "") && (comboBox1.SelectedIndex >= 0) && (textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
                            {
                                checkTeacher();
                            }
                        }break;
                    case "2":
                        {
                            if (textBox4.Text != "")
                            {
                                checkAdmin();
                            }
                        }break;
                }
            if ((textBox1.Text!="")||(textBox2.Text!="")||(textBox3.Text!="")||(textBox4.Text!=""))
            {
                label6.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 2)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                textBox1.Text = "Ромашкина";
                textBox2.Text = "Татьяна";
                textBox3.Text = "Витальевна";
                textBox4.Text = "12345";
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
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
