using System;
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
    public partial class prepodWork : Form
    {
        SqlConnection conn;
        SqlCommand comm;
       
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
         

        string numPrepod;
        public prepodWork(string _numPrepod)
        {
            InitializeComponent();
            numPrepod = _numPrepod;

            conn = new SqlConnection(connectionString);            
            comm = new SqlCommand();
            comm.Connection = conn;
        }


        private void Form1_Load(object sender, EventArgs e)
        {            
            conn.Open();                        
            comm.CommandText = "Select * from [Группы преподавателей] where [№ преподавателя] = '" + numPrepod + "'";
            SqlDataReader rdr = comm.ExecuteReader();
            groups.Items.Clear();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    groups.Items.Add(rdr[1]);
                }
            }
            rdr.Close();

            comm.CommandText = "select Фамилия, Имя, Отчество, Пароль from Преподаватель where Преподаватель.[№ преподавателя] ='" + numPrepod + "'";
            try
            {                
                rdr = comm.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    textBox1.Text = rdr[0].ToString();
                    textBox2.Text = rdr[1].ToString();
                    textBox3.Text = rdr[2].ToString();                    
                    textBox5.Text = rdr[3].ToString();
                }
                rdr.Close();

                comm.CommandText = "select * from Группа";
                rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                   comboBox1.Items.Add(rdr[1].ToString());
                }
                rdr.Close();
            }
            finally { conn.Close(); };
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Open();
            comm.CommandText = "Select [№ группы] from Группа where Группа.Название = '" + comboBox1.Text + "'";

            SqlDataReader rdr = comm.ExecuteReader();
            rdr.Read();
            string numGroup = rdr[0].ToString();
            rdr.Close();
            try
            {
                string cmd = "Insert into [Группы преподавателя] ([№ преподавателя], [№ группы]) Values('" + numPrepod.ToString() + "','" + numGroup + "')";
                comm.CommandText = cmd;
                comm.ExecuteNonQuery();
            }
            finally { }    
            
            comm.CommandText = "Select * from [Группы преподавателей]";
            rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    groups.Items.Add(rdr[1]);
                }               
            }
            rdr.Close();
            conn.Close();

            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            string cmd = "Update Преподаватель set Фамилия = '" + textBox1.Text + "', Имя = '" + textBox2.Text + "', Отчество = '" + textBox3.Text + "', Пароль = '" + textBox5.Text + "'";
            comm.CommandText = cmd;
            comm.ExecuteNonQuery();
            conn.Close();

            treeWork tw = new treeWork(numPrepod);
            tw.Show();
            this.Hide();
        }

        private void prepodWork_FormClosing(object sender, FormClosingEventArgs e)
        {
            //treeWork tw = new treeWork(numPrepod);
            //tw.Show();
            //this.Hide();
        }
    }
}
