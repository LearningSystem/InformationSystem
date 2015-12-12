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
        //string connectionString =
        //        "Data Source=(local);Initial Catalog=Education; user id = sa; password = 1";
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        int numPrepod;
        public prepodWork(int _numPrepod)
        {
            InitializeComponent();
            numPrepod = _numPrepod;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Form3 f3 = new Form3();
            //f3.Show();
            //System.Diagnostics.Process.Start(Application.StartupPath+"\\"+"CreateTest 2.0\\CreateTest 2.0\\bin\\Debug\\CreateTest 2.0.exe"+"", numPrepod.ToString());
            InfoTest newtest = new InfoTest(numPrepod);
            newtest.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            treeWork tw = new treeWork(numPrepod.ToString());
            tw.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
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
            comm.CommandText = "select Фамилия, Имя, Отчество, Телефон, Пароль from Преподаватель where Преподаватель.[№ преподавателя] ='" + numPrepod + "'";
            try
            {                
                rdr = comm.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    textBox1.Text = rdr[0].ToString();
                    textBox2.Text = rdr[1].ToString();
                    textBox3.Text = rdr[2].ToString();
                    textBox4.Text = rdr[3].ToString();
                    textBox5.Text = rdr[4].ToString();
                }
                rdr.Close();
                comm = new SqlCommand("select * from Группа", conn);
                rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                   comboBox1.Items.Add(rdr[1].ToString());
                }
                rdr.Close();
            }
            finally { }
        }

        private void button6_Click(object sender, EventArgs e)
        {            
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;

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

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string cmd = "Update into Преподаватель (Фамилия, Имя, Отчество, Телефон) Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            SqlCommand comm = new SqlCommand(cmd, conn);
            comm.ExecuteNonQuery();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Estimates frm = new Estimates(numPrepod.ToString());
            frm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            regForm rf = new regForm();
            rf.Show();
            this.Hide();
        }
    }
}
