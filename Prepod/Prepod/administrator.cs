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
using System.IO;

namespace Prepod
{
    public partial class administrator : Form
    {
        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader rdr;
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        BindingSource bs = new BindingSource();
        //SqlDataAdapter adapter;
        DataTable data = new DataTable();
        DataTable dtPrepod = new DataTable();
        DataTable dataGroup = new DataTable();
        public administrator()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand();
            studForm();
            prepodForm();
        }

        private void dgSettings(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void studForm()
        {
            loadGroups();
            add.Enabled = upd.Enabled = del.Enabled = false;
            dgSettings(dg); 
        }

        private void prepodForm()
        {
            showPrepod();
            dgSettings(dgPrepod); 
        }

        private void loadGroups()
        {
            try
            {
                conn.Open();
                comm.Connection = conn;
                comm.CommandText = "Select [№ группы] as id, Название from Группа";

                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                dataGroup.Clear();
                adapter.Fill(dataGroup);
                group.DataSource = dataGroup;

                group.DisplayMember = "Название";
                group.ValueMember = "id";                                            
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }   
            finally
            {                
                conn.Close();
                if (group.Items.Count > 0)
                {
                    showGroup(group.SelectedValue.ToString());
                }
            }
        }

        private void showGroup(string id)
        {
            try
            {
                conn.Open();
                comm.Connection = conn;
                comm.CommandText = "Select * from Студент where [№ группы] = '"+ id +"'";

                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                data.Clear();
                adapter.Fill(data);
                dg.DataSource = data;
                dg.Columns[0].Visible = false;
                dg.Columns[4].Visible = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
            finally
            {
                groupName.Text = "Группа: " + group.Text;
                add.Enabled = upd.Enabled = del.Enabled = true;
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите название!");
            }
            else
            {
                if (prepod.SelectedValue != null)
                {
                    try
                    {
                        conn.Open();
                        comm.Connection = conn;
                        comm.CommandText = "Insert into Группа (Название, [№ преподавателя]) Values('" + textBox1.Text + "', '"+ prepod.SelectedValue.ToString() +"')";
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message.ToString());
                    }
                    finally
                    {
                        textBox1.Text = "";
                        conn.Close();
                        loadGroups();
                        group.SelectedIndex = group.Items.Count - 1;
                    }
                }
                else 
                { 
                    MessageBox.Show("Создайте преподавателя!");
                    tabControl1.SelectedTab = tabPage2;
                }
            }
        }

        private void group_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (group.SelectedValue != null)
            {
                string id = group.SelectedValue.ToString();
                string name = group.Text;
                showGroup(id);
            } 
            else
            { 
                dataGroup.Clear();
                dg.ClearSelection();
                groupName.Text = "";
                add.Enabled = upd.Enabled = del.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (group.SelectedValue != null)
            {
                try
                {
                    conn.Open();
                    comm.Connection = conn;
                    string delGroup = group.SelectedValue.ToString();                    
                    comm.CommandText = "Delete from Группа where [№ группы] ='" + delGroup + "'";
                    comm.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message.ToString());
                }
                finally
                {                    
                    conn.Close();
                    loadGroups();
                    group.SelectedIndex = group.Items.Count - 1;
                }
            }
        }

        private void administrator_Load(object sender, EventArgs e)
        {            
            if (group.Items.Count > 0)
                group.SelectedIndex = 0;
        }

        private void add_Click(object sender, EventArgs e)
        {
            editStudent es = new editStudent(group.SelectedValue, "", "", "", "", "", "");
            es.Show();
        }

        private void showPrepod()
        {            
            try
            {
                conn.Open();
                comm.Connection = conn;
                comm.CommandText = "Select * from Преподаватель";

                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                dtPrepod.Clear();
                adapter.Fill(dtPrepod);
                dgPrepod.DataSource = dtPrepod;
                dgPrepod.Columns[0].Visible = false; 
               
                //комбобокс
                prepod.DataSource = dtPrepod;
                prepod.DisplayMember = "Фамилия";
                prepod.ValueMember = "№ преподавателя";
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }        
        private void administrator_Activated(object sender, EventArgs e)
        {
            if (group.SelectedValue != null)
                showGroup(group.SelectedValue.ToString());
            showPrepod();            
        }

        private void upd_Click(object sender, EventArgs e)
        {
            if (dg.CurrentRow != null)
            {
                string id = dg.CurrentRow.Cells[0].Value.ToString();
                string surname = dg.CurrentRow.Cells[1].Value.ToString();
                string name = dg.CurrentRow.Cells[2].Value.ToString();
                string name2 = dg.CurrentRow.Cells[3].Value.ToString();
                string path = dg.CurrentRow.Cells[6].Value.ToString();
                editStudent es = new editStudent(group.SelectedValue, surname, name, name2, "update", id, path);

                es.Show();

            }
            else
            {
                MessageBox.Show("Выберите студента!");
            }            
        }

        private void del_Click(object sender, EventArgs e)
        {
            if (dg.CurrentRow != null)
            {
                try
                {
                    conn.Open();
                    comm.Connection = conn;
                    string id = dg.CurrentRow.Cells[0].Value.ToString();
                    comm.CommandText = "Delete from Студент where [№ Студента] ='" + id + "'";
                    comm.ExecuteNonQuery();

                    //удаление папки
                    string dir = getPrepodPuth(group.SelectedValue);
                    string folderName = dg.CurrentRow.Cells[6].Value.ToString();
                    string currentFolder = Application.StartupPath + dir + folderName.Remove(folderName.Length - 1);
                    DirectoryInfo drInfo = new DirectoryInfo(currentFolder);
                    drInfo.Delete(true);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message.ToString());
                }
                finally
                {
                    conn.Close();
                    showGroup(group.SelectedValue.ToString());
                }
            }
            else
            {
                MessageBox.Show("Выберите студента!");
            }
        }

        string getPrepodPuth(object id)
        {
            comm.CommandText = "select [Путь к папке] from Преподаватель, Группа where Группа.[№ преподавателя] = Преподаватель.[№ преподавателя] and Группа.[№ группы] = '" + id.ToString() + "'";
            comm.ExecuteNonQuery();
            rdr = comm.ExecuteReader();
            rdr.Read();
            string path = rdr[0].ToString();
            rdr.Close();
            return path;
        }

        private void addPrepod_Click(object sender, EventArgs e)
        {
            editPrepod ep = new editPrepod("", "", "", "", "");
            ep.Show();
        }

        private void updPrepod_Click(object sender, EventArgs e)
        {
            if (dgPrepod.CurrentRow != null)
            {
                string id = dgPrepod.CurrentRow.Cells[0].Value.ToString();
                string surname = dgPrepod.CurrentRow.Cells[1].Value.ToString();
                string name = dgPrepod.CurrentRow.Cells[2].Value.ToString();
                string name2 = dgPrepod.CurrentRow.Cells[3].Value.ToString();
                editPrepod ep = new editPrepod(surname, name, name2, "update", id);
                ep.Show();
            }
            else
            {
                MessageBox.Show("Выберите преподавателя!");
            }
        }

        private void delPrepod_Click(object sender, EventArgs e)
        {
            if (dgPrepod.CurrentRow != null)
            {
                try
                {
                    conn.Open();
                    comm.Connection = conn;
                    string id = dgPrepod.CurrentRow.Cells[0].Value.ToString();
                    comm.CommandText = "Delete from Преподаватель where [№ преподавателя] ='" + id + "'";
                    comm.ExecuteNonQuery();
                    //удаляем папку                    
                    string folderName = dgPrepod.CurrentRow.Cells[6].Value.ToString();
                    string currentFolder = Application.StartupPath + folderName.Remove(folderName.Length - 1);
                    DirectoryInfo drInfo = new DirectoryInfo(currentFolder);
                    drInfo.Delete(true);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message.ToString());
                }
                finally
                {
                    conn.Close();
                    showPrepod();
                }
            }
            else
            {
                MessageBox.Show("Выберите преподавателя!");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }

        private void administrator_FormClosed(object sender, FormClosedEventArgs e)
        {
                        
        }

        private void administrator_FormClosing(object sender, FormClosingEventArgs e)
        {
            regForm rf = new regForm();
            rf.Show();
        }



    }
}
