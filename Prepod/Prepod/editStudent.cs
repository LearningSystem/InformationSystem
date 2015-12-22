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
    public partial class editStudent : Form
    {
        SqlConnection conn;
        //string connectionString =
        //        "Data Source=(local);Initial Catalog=Education; user id = sa; password = 1";
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        BindingSource bs = new BindingSource();
        SqlDataAdapter adapter;
        DataTable data = new DataTable();

        public editStudent()
        {
            InitializeComponent();
        }

        private void editStudent_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "Select * from Группа";
            comboBox1.Items.Clear();
            SqlDataReader rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    comboBox1.Items.Add(rdr[1]);
                }
            }
            rdr.Close();

            comm.CommandText = "Select * from Факультет";
            comboBox2.Items.Clear();
            rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    comboBox2.Items.Add(rdr[1]);
                }
            }
            rdr.Close();
                        
            comm.CommandText = "Select * from [Список группы]";

            adapter = new SqlDataAdapter(comm);
            adapter.Fill(data);
            dataGridView1.DataSource = data;

            bs.DataSource = data;
            bs.Filter = "Группа = '" + comboBox1.Text + "'";
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {           
            bs.Filter = "Группа = '" + comboBox1.Text + "'";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                if (textBox1.Text != "")
                {
                    // - - - находим номер факультета - -  -//
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandText = "select Факультет.[№ факультета] from Факультет where Факультет.Название ='" + comboBox2.Text + "'";
                    SqlDataReader rdr3 = comm.ExecuteReader();
                    rdr3.Read();
                    string idFak = rdr3[0].ToString();
                    rdr3.Close();

                    comm.CommandText = "select Группа.[№ Группы] from Группа where Группа.Название ='" + comboBox1.Text + "'";
                    rdr3 = comm.ExecuteReader();
                    rdr3.Read();
                    string idGroup = rdr3[0].ToString();
                    rdr3.Close();

                    // ---- Вставка студента
                    string cmd = "Insert into Студент (Фамилия, Имя, Отчество, [№ группы], [№ факультета]) Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + idFak + "','" + idGroup + "')";
                    comm = new SqlCommand(cmd, conn);
                    comm.ExecuteNonQuery();


                    System.Windows.Forms.MessageBox.Show("Добавление выполнено");
                }
                else
                {
                    MessageBox.Show("Введите данные о студенте");
                }
            }
            finally
            {
                data.Clear();
                adapter.Fill(data);
                dataGridView1.DataSource = data;
                conn.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                bs.Filter = "Группа = '" + comboBox1.Text + "'";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                conn = new SqlConnection(connectionString);
                conn.Open();

                string sname = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string oname = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = true;
                }
                //- - - - - Находим номер студента - - - - - - - //
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select Студент.[№ студента] from Студент where Студент.Имя ='" + name + "' and Студент.Фамилия ='" + sname + "' and Студент.Отчество ='" + oname + "'";
                SqlDataReader rdr = comm.ExecuteReader();
                rdr.Read();
                string idStud = "-1";
                if (rdr.HasRows)
                {
                    idStud = rdr[0].ToString();
                }

                rdr.Close();

                //- - - - - Удаляем из таблицы Студент - - - - - - //
                comm.CommandText = "delete from Студент where [№ студента] ='" + idStud + "'";
                comm.ExecuteNonQuery();
            }
            finally
            {
                data.Clear();
                adapter.Fill(data);
                dataGridView1.DataSource = data;
                conn.Close();
                System.Windows.Forms.MessageBox.Show("Удаление завершено");
                bs.Filter = "Группа = '" + comboBox1.Text + "'";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
