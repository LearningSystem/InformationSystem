using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Prepod
{
    public partial class delTest : Form
    {
        int NumTeacher;
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        SqlConnection conn;
        SqlCommand comm;
        public delTest(int _numTeacher)
        {
            InitializeComponent();
            NumTeacher = _numTeacher;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand();
           // LoadTests();
        }
       
        void LoadTests()
        {
            foreach (ListViewItem item in lstViewTests.Items)
            {
                lstViewTests.Items.Remove(item);
            }
            conn = new SqlConnection(connectionString);
            using (conn)
            {
                conn.Open();
                comm.Connection = conn;
                try
                {
                    comm.CommandText = "select [Название] from Тест Where [№ преподавателя]='" + NumTeacher.ToString() + "'";
                    comm.ExecuteNonQuery();
                    SqlDataReader rdr = comm.ExecuteReader();
                    while (rdr.Read())
                    {
                        lstViewTests.Items.Add(rdr[0].ToString());
                    }
                    rdr.Close();
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message, "Ошибка!");
                }
            } conn.Close();
        }

        private void delTest_Load(object sender, EventArgs e)
        {
            Loads();
        }

        private void lstViewTests_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstViewTests.SelectedItems[0]!=null)
            {
                if (lbl1.Enabled==false)
                {
                    lbl1.Enabled = true;
                    lbl2.Enabled = true;
                    lbl3.Enabled = true;
                    lbl4.Enabled = true;
                    lbl5.Enabled = true;
                    toolStripButton1.Enabled = true;
                    conn = new SqlConnection(connectionString);
                    using (conn)
                    {
                        conn.Open();
                        comm.Connection = conn;
                        try
                        {
                            comm.CommandText = "select [Максимальный балл],[Срок сдачи],[Тема],[Описание],[Ссылка] from Тест Where [№ преподавателя]='" + NumTeacher.ToString() + "' and " + "[Название]='" + lstViewTests.SelectedItems[0].Text + "'";
                            comm.ExecuteNonQuery();
                            SqlDataReader rdr = comm.ExecuteReader();
                            while (rdr.Read())
                            {
                                txtBox1.Text = rdr[0].ToString();
                                txtBox2.Text = rdr[1].ToString();
                                txtBox3.Text = rdr[2].ToString();
                                txtBox4.Text = rdr[3].ToString();
                                txtBox5.Text = rdr[4].ToString();
                            }
                            rdr.Close();
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message, "Ошибка!");
                        }
                    } conn.Close();
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить тест?","Подтверждение",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                conn = new SqlConnection(connectionString);
                using (conn)
                {
                    conn.Open();
                    comm.Connection = conn;
                    try
                    {
                        comm.CommandText = "Delete from Тест Where [№ преподавателя]='" + NumTeacher.ToString() + "' and " + "[Название]='" + lstViewTests.SelectedItems[0].Text + "'";
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Ошибка!");
                    }
                } conn.Close();
                Loads();
            }
        }

        void Loads()
        {
            LoadTests();
            lbl1.Enabled = false;
            lbl2.Enabled = false;
            lbl3.Enabled = false;
            lbl4.Enabled = false;
            lbl5.Enabled = false;
            txtBox1.Text = "";
            txtBox2.Text = "";
            txtBox3.Text = "";
            txtBox4.Text = "";
            txtBox5.Text = "";
            toolStripButton1.Enabled = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TestWorkStart workStart= new TestWorkStart(NumTeacher);
            workStart.Show();
            this.Hide();
        }
    }
}
