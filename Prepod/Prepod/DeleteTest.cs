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
    public partial class DeleteTest : Form
    {
        int numTeacher;
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        SqlConnection conn;
        public DeleteTest(int _numTeacher)
        {
            InitializeComponent();
            numTeacher = _numTeacher;
        }

        private void DeleteTest_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select [Название] from Тест where [№ преподавателя]=" + "'" + numTeacher.ToString() + "'";
                comm.ExecuteNonQuery();
                SqlDataReader rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    lstViewTest.Items.Add(rdr[0].ToString());
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при чтении из БД");
            }
            finally
            {
                conn.Close();
            }
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            txtB1.Visible = false;
            txtB2.Visible = false;
            txtB3.Visible = false;
            txtB4.Visible = false;
            txtB5.Visible = false;
        }

        private void lstViewTest_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstViewTest.SelectedItems != null)
            {
                if (lbl1.Visible==false)
                {
                    lbl1.Visible = true;
                    lbl2.Visible = true;
                    lbl3.Visible = true;
                    lbl4.Visible = true;
                    lbl5.Visible = true;
                    txtB1.Visible = true;
                    txtB2.Visible = true;
                    txtB3.Visible = true;
                    txtB4.Visible = true;
                    txtB5.Visible = true;
                }
                string name = lstViewTest.SelectedItems[0].Text;
                conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandText = "select [Максимальный балл],[Срок сдачи],[Тема],[Описание],[Ссылка] from Тест where [Название]=" + "'" + name + "'";
                    comm.ExecuteNonQuery();
                    SqlDataReader rdr = comm.ExecuteReader();
                    while (rdr.Read())
                    {
                        txtB1.Text = rdr[0].ToString();
                        txtB2.Text = rdr[1].ToString();
                        txtB3.Text = rdr[2].ToString();
                        txtB4.Text = rdr[3].ToString();
                        txtB5.Text = rdr[4].ToString();
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка при чтении из БД");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить выбранные тесты? Файлы будут удалены перманентно.", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (ListViewItem lstitem in lstViewTest.Items)
                {
                    if (lstitem.Checked)
                    {
                        string nameTest = lstitem.Text;
                        Delete(lstitem, nameTest);
                        lstViewTest.Items.Remove(lstitem);
                    }
                }
                MessageBox.Show("Удаление прошло успешно.", "Удаление");
            }
        }
        public void Delete(ListViewItem lst, string name)
        {
            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "delete from Тест where [Название]=" + "'" + name + "'";
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при удалении из БД");
            }
            finally
            {
                conn.Close();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestWorkStart str = new TestWorkStart(numTeacher);
            this.Hide();
            str.Show();
        }
    }
}
