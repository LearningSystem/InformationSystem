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

        XmlTextWriter writer;
        int NumTeacher;
        string numTest;
        string PathXml;
        //public string ConnectionString { get; set; }
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public InfoTest(int _NumTeacher)
        {
            InitializeComponent();
            NumTeacher = _NumTeacher;
            //PathXml = _PathXml;
            //var sb = new SqlConnectionStringBuilder
            //{
            //    DataSource = "USER-ПК",
            //    InitialCatalog = "Education",
            //    IntegratedSecurity = true
            //};
            //ConnectionString = sb.ConnectionString;
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            writer = new XmlTextWriter(tBNameTest.Text + ".xml", Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("Test");

            writer.WriteStartElement("Discription");
            writer.WriteString(rtBDescTest.Text);
            writer.WriteEndElement();

            writer.WriteStartElement("Author");
            writer.WriteString(tBAuthorTest.Text);
            writer.WriteEndElement();

            writer.WriteStartElement("Theme");
            writer.WriteString(tBThemeTest.Text);
            writer.WriteEndElement();


            writer.WriteStartElement("Discipline");
            writer.WriteString(cBDiscip.Text);
            writer.WriteEndElement();

            writer.WriteStartElement("Course");
            writer.WriteString("");
            writer.WriteEndElement();

            writer.WriteStartElement("Questions");
            insertTask();
            TestCreate test = new TestCreate(writer, numTest);
            
            this.Hide();
            test.Show();
            
        }

        private void insertTask()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;

            comm.CommandText = "Select [№ предмета] from Предмет where Название = '" + cBDiscip.Text + "'";
            SqlDataReader rdr = comm.ExecuteReader();
            string numDisc = "1";
            if (rdr.HasRows)
            {
                rdr.Read();
                numDisc = rdr[0].ToString();
            }            
            rdr.Close();

            try
            {
                comm.CommandText = "Insert into Тест ([№ преподавателя], [№ предмета], [Описание], [Тема], [Название], [Ссылка]) Values('" + NumTeacher.ToString() + "','" + numDisc + "', '" + rtBDescTest.Text + "', '" + tBThemeTest.Text + "', '" + tBNameTest.Text + "', '" + tBNameTest.Text + ".xml')";
                comm.ExecuteNonQuery();
                comm.CommandText = "select SCOPE_IDENTITY()";
                rdr = comm.ExecuteReader();
                rdr.Read();
                numTest = rdr[0].ToString();
            }
            finally { conn.Close(); }    
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void InfoTest_Load(object sender, EventArgs e)
        {
            SqlConnection sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = @"Select [Фамилия],[Имя],[Отчество] From [Преподаватель] Where [Преподаватель].[№ преподавателя]="+"'"+ NumTeacher.ToString()+"'";
                SqlDataReader dr = scommand.ExecuteReader();
                while (dr.Read())
                {
                    tBAuthorTest.Text = tBAuthorTest.Text +" "+ dr[0].ToString()+" "+dr[1].ToString()+" "+dr[2].ToString();
                }
                dr.Close();

                scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = @"Select [Предмет].[Название] From [Предмет],[Дерево],[Преподаватель] Where [Преподаватель].[№ преподавателя]=[Дерево].[№ преподавателя] and [Дерево].[№ предмета]=[Предмет].[№ предмета] and [Преподаватель].[№ преподавателя]=" + "'" + NumTeacher.ToString() + "'";
                dr = scommand.ExecuteReader();
                while (dr.Read())
                {
                    cBDiscip.Items.Add(dr[0].ToString());
                }
            }
            cBDiscip.SelectedIndex = 0;
            if (tBAuthorTest.Text!="")
            {
                tBAuthorTest.Enabled = false;
            }
        }
    }
}
