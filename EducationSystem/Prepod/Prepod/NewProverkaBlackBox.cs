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
    public partial class NewProverkaBlackBox : Form
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        SqlConnection sconn;
        SqlCommand scommand;
        string SelectExer;
        string SelectNumbProv;
        string SelectNumbTest;
        bool changes;
        public NewProverkaBlackBox(string _selectExercise,string _selectNumberTest)
        {
            InitializeComponent();
            SelectNum(_selectExercise);
            SelectNumbTest = _selectNumberTest;
        }

        void SelectNum(string _select)
        {
            sconn = new SqlConnection(connectionString);
            sconn.Open();
            string query = @"SELECT [№ задачи] from [Задача] where [Название]='"+_select+"'";
            SqlCommand scommand = new SqlCommand(query, sconn);
            SqlDataReader dr = scommand.ExecuteReader();
            while (dr.Read())
            {
                SelectExer = dr[0].ToString();
            }
            dr.Close();
            sconn.Close();
        }
        private void NewProverkaBlackBox_Load(object sender, EventArgs e)
        {
            if (SelectNumbTest == "")
            {
                numberProv();
            }
            else
            {
                this.Text = "Изменение теста";
                try
                {
                    dgvGeneral.Rows.Clear();
                    sconn = new SqlConnection(connectionString);
                    sconn.Open();
                    //string query = @"SELECT distinct [Входные данные].[Значение] AS 'Входные данные',[Выходные данные].[Значение] AS 'Выходные данные' from [Входные данные],[Выходные данные],[Проверка] where [Проверка].[№ задачи]='" + cmBExer.SelectedItem.ToString() + "' and [Выходные данные].[№ проверки]='" + index[cmBTest.SelectedIndex] + "' and [Входные данные].[№ проверки]='" + index[cmBTest.SelectedIndex] +"'";
                    //SqlDataAdapter sda = new SqlDataAdapter(query, sconn);
                    string query = @"SELECT distinct [Входные данные].[Значение] from [Входные данные],[Проверка] where [Проверка].[№ задачи]='" + SelectExer + "' and [Входные данные].[№ проверки]='" + SelectNumbTest + "'";
                    SqlCommand scommand = new SqlCommand(query, sconn);
                    SqlDataReader dr = scommand.ExecuteReader();
                    //DataTable dt = new DataTable();
                    int gridindex = 0;
                    while (dr.Read())
                    {
                        dgvGeneral.Rows.Add();
                        dgvGeneral.Rows[gridindex].Cells[0].Value = dr[0].ToString();
                        gridindex++;
                    }
                    dr.Close();
                    //---
                    query = @"SELECT distinct [Выходные данные].[Значение] from [Выходные данные],[Проверка] where [Проверка].[№ задачи]='" + SelectExer + "' and [Выходные данные].[№ проверки]='" + SelectNumbTest + "'";
                    scommand = new SqlCommand(query, sconn);
                    dr = scommand.ExecuteReader();
                    gridindex = 0;
                    while (dr.Read())
                    {
                        //MessageBox.Show(dr[0].ToString());
                        dgvGeneral.Rows[gridindex].Cells[1].Value = dr[0].ToString();
                        gridindex++;
                    }
                    dr.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                sconn.Close();
            }
            changes = false;
        }
        void numberProv()
        {
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = @"Insert into Проверка ([№ задачи]) values ('" + SelectExer + "')";
                try
                {
                    scommand.ExecuteNonQuery();
                    scommand = new SqlCommand();
                    scommand.Connection = sconn;
                    //scommand.CommandText = @"SELECT [№ проверки] from [Проверка] where [№ задачи]='"+SelectExer+"'";
                    scommand.CommandText = @"SELECT TOP 1 [№ проверки] from [Проверка] order by [№ проверки] desc";
                    SqlDataReader dr = scommand.ExecuteReader();
                    while (dr.Read())
                    {
                        SelectNumbProv = dr[0].ToString();
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } sconn.Close();
        }
        
        //private void btnSaveOne_Click(object sender, EventArgs e)
        //{
        //    if (SelectNumbTest == "")
        //    {
        //        SaveProv();
        //        MessageBox.Show("Проверка успешно внесена в БД!", "Успешное выполнение операции");
        //    }
        //    else
        //    {
        //        DeleteRows();
        //        numberProv();
        //        SaveProv();
        //        MessageBox.Show("Проверка успешно изменена в БД!", "Успешное выполнение операции");
        //    }
        //    dgvGeneral.Rows.Clear();
        //    changes = false;
        //}
        
        void DeleteRows()
        {
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = @"Delete from [Проверка] where [№ задачи]='"+SelectExer+"' and [№ проверки]='"+SelectNumbTest+"'";
                try
                {
                    scommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } sconn.Close();
        }
        
        void SaveProv()
        {
            for (int i=0;i<dgvGeneral.RowCount;i++)
            {
                if (dgvGeneral.Rows[i].Cells[0].Value!=null)
                    InsertZnach(dgvGeneral.Rows[i].Cells[0].Value.ToString(), true);
                if (dgvGeneral.Rows[i].Cells[1].Value!=null)
                    InsertZnach(dgvGeneral.Rows[i].Cells[1].Value.ToString(), false);
            }
        }

        void InsertZnach(string _selectznach,bool _table)
        {
            if (_table==true)
            {
                Insertrun(_selectznach,"[Входные данные] ([Значение],[№ проверки])");
            }
            else
            {
                Insertrun(_selectznach, "[Выходные данные] ([№ проверки],[Значение])");
            }
        }

        void Insertrun(string _select,string dopquery)
        {
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                scommand = new SqlCommand();
                scommand.Connection = sconn;
                //if (SelectNumbTest == "")
                //{
                    if (dopquery == "[Входные данные] ([Значение],[№ проверки])")
                        scommand.CommandText = @"Insert into " + dopquery.ToString() + " values ('" + _select + "','" + SelectNumbProv.ToString() + "')";
                    else
                        scommand.CommandText = @"Insert into " + dopquery.ToString() + " values ('" + SelectNumbProv.ToString() + "','" + _select + "')";
                //}
                //else
                //{
                //    if (dopquery == "[Входные данные] ([Значение],[№ проверки])")
                //        scommand.CommandText = @"Insert into " + dopquery.ToString() + " values ('" + _select + "','" + SelectNumbTest + "')";
                //    else
                //        scommand.CommandText = @"Insert into " + dopquery.ToString() + " values ('" + SelectNumbTest + "','" + _select + "')";
                //}
                try
                {
                    scommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } sconn.Close();
        }

        private void dgvGeneral_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            changes = true;
        }

        private void NewProverkaBlackBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            Proverka();
            if (changes==true)
            {
                if (MessageBox.Show("Сохранить ваши данные?","Выход",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    EventArgs el=new EventArgs();
                    //btnSaveOne_Click(sender,el);
                    сохранитьToolStripMenuItem1_Click(sender,el);
                }
            }
        }

        private void dgvGeneral_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            changes = true;
        }

        private void dgvGeneral_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            changes = true;
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (SelectNumbTest == "")
            {
                SaveProv();
                MessageBox.Show("Тест успешно внесена в БД!", "Успешное выполнение операции");
                if(MessageBox.Show("Вы хотите добавить еще тест?","Вставка теста",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    numberProv();
                }
            }
            else
            {
                DeleteRows();
                numberProv();
                SaveProv();
                MessageBox.Show("Тест успешно изменена в БД!", "Успешное выполнение операции");
            }
            dgvGeneral.Rows.Clear();
            changes = false;
        }

        //private void btnClear_Click(object sender, EventArgs e)
        //{

        //}

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvGeneral.Rows.Clear();
            changes = true;
        }

        void Proverka()
        {
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = @"SELECT * from [Входные данные],[Выходные данные] where [Входные данные].[№ проверки]='" + SelectNumbProv + "' and [Выходные данные].[№ проверки]='"+ SelectNumbProv + "'";
                try
                {
                    SqlDataReader dr = scommand.ExecuteReader();
                    if(dr.HasRows==false)
                    {
                        dr.Close();
                        SqlCommand scomm = new SqlCommand();
                        scomm.Connection = sconn;
                        scomm.CommandText = @"DELETE FROM [Проверка] where [№ задачи]='" + SelectExer + "' and [№ проверки]='" + SelectNumbProv+"'" ;
                        scomm.ExecuteNonQuery();
                    }
                    //dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } sconn.Close();
        }
    }
}
