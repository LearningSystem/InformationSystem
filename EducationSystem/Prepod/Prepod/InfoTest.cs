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

namespace Prepod
{
    public partial class InfoTest : Form
    {
        SqlConnection conn;
        int NumTeacher;     
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public InfoTest(int _NumTeacher)
        {
            InitializeComponent();
            NumTeacher = _NumTeacher;
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tBNameTest.Text != "" && rtBDescTest.Text != "" && tBThemeTest.Text != "")
            {
                TestCreate test = new TestCreate(tBNameTest.Text,rtBDescTest.Text,tBThemeTest.Text,NumTeacher);
                this.Hide();
                test.Show();
            }
            else
                MessageBox.Show("Заполнены не все поля!", "Ошибка");
        }

        //private void insertTask()
        //{
        //    conn = new SqlConnection(connectionString);
        //    conn.Open();
        //    SqlCommand comm = new SqlCommand();
        //    comm.Connection = conn;

        //    try
        //    {
        //        comm.CommandText = "Insert into Тест ([№ преподавателя], [Описание], [Тема], [Название], [Ссылка]) Values('" + NumTeacher.ToString() + "', '" + rtBDescTest.Text + "', '" + tBThemeTest.Text + "', '" + tBNameTest.Text + "','Тесты\\"  + tBNameTest.Text + ".xml')";
        //        comm.ExecuteNonQuery();
        //        comm.CommandText = "select SCOPE_IDENTITY()";
        //        SqlDataReader rdr = comm.ExecuteReader();
        //        rdr.Read();
        //        numTest = rdr[0].ToString();
        //        rdr.Close();
        //    }
        //    finally 
        //    { 
        //        conn.Close();
        //    }    
        //}

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы уверены, что хотите выйти?","Выход",MessageBoxButtons.YesNoCancel)==DialogResult.Yes)
               this.Hide();
        }

        private void InfoTest_Load(object sender, EventArgs e)
        {

        }
    }
}
