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
    public partial class studentWork : Form
    {
        SqlConnection conn;
        
        //string connectionString =
        //        "Data Source=(local);Initial Catalog=Education; user id = sa; password = 1";
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        string numStudent;

        TreeNode newNode;
        SqlDataAdapter adapter;
        DataTable data = new DataTable();

        OpenFileDialog ofd;

        List<int> tasks = new List<int>();

        public studentWork(string _numStudent)
        {
            InitializeComponent();
            numStudent = _numStudent;
            loadTask.Enabled = false;
            pg.Visible = false;
            loadListView();
            loadListViewTasks();
            loadInf(); 
            richTextBox1.Visible = false;
            listView2.Visible = false;
            listView1.Visible = true;
        }
        string fio;
        private void loadInf()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "Select * from Студент Where [№ студента] = '"+ numStudent +"'";
            //считываем данные студента
            SqlDataReader rdr = comm.ExecuteReader();
            rdr.Read();
            name.Text = "";
            name.Text = rdr[1].ToString() + " " + rdr[2].ToString() + " " + rdr[3].ToString();
            fio = name.Text;
            string group = rdr[5].ToString();            

            rdr.Close();
            conn.Close();

        }

        private void loadListViewTasks()
        {
            //добавления колонок            
            ColumnHeader c = new ColumnHeader();
            c.Text = "Название";
            c.Width = c.Width + 80;
            ColumnHeader c1 = new ColumnHeader();
            c1.Text = "Уровень сложности";
            c1.Width = c1.Width + 60;
            ColumnHeader c2 = new ColumnHeader();
            c2.Text = "Максимальный балл";
            c2.Width = c2.Width + 60;
            ColumnHeader c3 = new ColumnHeader();
            c3.Text = "Срок сдачи";
            c3.Width = c3.Width + 60;
            ColumnHeader c4 = new ColumnHeader();
            c4.Text = "";
            c4.Width = 0;
            

            listView2.Columns.Add(c);
            listView2.Columns.Add(c1);
            listView2.Columns.Add(c2);
            listView2.Columns.Add(c3);
            listView2.Columns.Add(c4);
        }
        private void loadListView()
        {
            //добавления колонок            
            ColumnHeader c = new ColumnHeader();
            c.Text = "Имя";
            c.Width = c.Width + 80;
            ColumnHeader c1 = new ColumnHeader();
            c1.Text = "Тип";
            c1.Width = c1.Width + 60;
            ColumnHeader c2 = new ColumnHeader();
            c2.Text = "Номер дерева";
            c2.Width = c2.Width + 60;

            listView1.Columns.Add(c);
            listView1.Columns.Add(c1);
            listView1.Columns.Add(c2);
        }

        private void выбратьКурсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = false;
            listView2.Visible = false;
            listView1.Visible = true;
            listView1.Items.Clear();                        
            listView1.View = View.Tile;
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select [№ дерева], Предмет.Название from Дерево, Предмет where [№ преподавателя] in (select [№ преподавателя] from [Группы преподавателя], Студент where Студент.[№ группы] = [Группы преподавателя].[№ группы] and Студент.[№ студента] = '"+ numStudent +"')";

            SqlDataReader rdr = comm.ExecuteReader();

            //заполнение listView
            ListViewItem lv = new ListViewItem();
            string tName = "";
            string numTree = "";
            while (rdr.Read())
            {
                string type = "Курс обучения";
                tName = rdr[1].ToString();
                numTree = rdr[0].ToString();
                lv = new ListViewItem(new string[] { tName, type, numTree, "", "" }, 1);
                lv.Name = tName;
                listView1.Items.Add(lv);
            }
             
            rdr.Close();
            conn.Close();
            
            loadInf();
        }

        private void loadNodes(TreeNodeCollection nodes, string numTree)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;

            foreach (TreeNode node in nodes)
            {
                //считываем всех потомков на первом уровне  
                comm.CommandText = "SELECT Вершина.[№ вершины], Текст, [Тип вершины] FROM Вершина JOIN Связи ON (Вершина.[№ вершины] = Связи.[№ потомка]) WHERE (Связи.[№ вершины] = " + node.Tag + ") AND (Связи.Уровень = 1) and (Вершина.[№ дерева] = " + numTree + ") and (Связи.[№ вершины] <> Связи.[№ потомка])";
                SqlDataReader rdr = comm.ExecuteReader();
                rdr.Read();

                if (rdr.HasRows)
                {
                    do
                    {
                        newNode = new TreeNode(rdr[1].ToString());
                        newNode.Tag = rdr[0].ToString();
                        if ((rdr[2].ToString() == "2") || (rdr[2].ToString() == "5"))
                        {
                            newNode.ImageIndex = 1;
                        }
                        else { newNode.ImageIndex = 0; };
                        node.Nodes.Add(newNode);                                             

                    } while (rdr.Read());
                }
                rdr.Close();
                loadNodes(node.Nodes, numTree);
            }
            conn.Close();
        }

        private void LoadTree(string numTree)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            //загружаем корневую вершину
            comm.CommandText = "select Вершина.[№ вершины], Текст, [Тип вершины] from Вершина where Вершина.[№ вершины] in  (select Связи.[№ вершины] from Связи where [№ потомка] = 0) and [№ дерева] = " + numTree + "";
            SqlDataReader rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                string root = rdr[0].ToString();
                if (treeView1.SelectedNode == null)
                {
                    newNode = new TreeNode(rdr[1].ToString());
                    newNode.Tag = rdr[0].ToString();
                    newNode.ImageIndex = 0;
                    treeView1.Nodes.Add(newNode);
                    treeView1.Update();
                    treeView1.Select();
                }
                //загрузка всех потомков
                loadNodes(treeView1.Nodes, numTree);
            };
            rdr.Close();
            conn.Close();
        }
   
        private void listView1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            treeView1.Nodes.Clear();
            string numTree = listView1.SelectedItems[0].SubItems[2].Text;
            name.Text = name.Text + " | " + listView1.SelectedItems[0].SubItems[0].Text;
            LoadTree(numTree);
            treeView1.Tag = numTree;
            listView1.Items.Clear();
            listView1.Visible = false;
            richTextBox1.Visible = true;
            listView2.Visible = false;
            searchCPC();
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            pg.Visible = false;
            treeView1.SelectedImageIndex = treeView1.SelectedNode.ImageIndex;
            if (typeNode(treeView1.SelectedNode.Tag.ToString()) == "Самостоятельная работа")
            {

                showGenerate();
                nazad.Enabled = true;
            }
            else
            {
                nazad.Enabled = false;
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select Ссылка From Вершина where [№ вершины] = '" + treeView1.SelectedNode.Tag.ToString() + "'";

                SqlDataReader rdr = comm.ExecuteReader();
                rdr.Read();
                string path = rdr[0].ToString();
                if (path != "")
                {
                    richTextBox1.LoadFile(Application.StartupPath + path);
                }
                listView2.Visible = false;
                richTextBox1.Visible = true;
                listView1.Visible = false;
                rdr.Close();
                conn.Close();
            }
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {

        }

        private string typeNode(string Id)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select Тип from [Тип вершины], Вершина where Вершина.[Тип вершины] = [Тип вершины].Код and [№ вершины] = '" + Id + "'";
            SqlDataReader rdr = comm.ExecuteReader();
            string index = "";
            if (rdr.HasRows)
            {
                rdr.Read();
                index = rdr[0].ToString();
            }
            rdr.Close();
            return index;
        }

        private void showGenerate()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from Задача, [Выполненная задача] where Задача.[№ задачи]=[Выполненная задача].[№ задачи] and Задача.[№ вершины]='"+ treeView1.SelectedNode.Tag.ToString() +"' and [Выполненная задача].[№ студента] = '"+ numStudent +"'";

            ListViewItem lv = new ListViewItem();            

            SqlDataReader rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                listView2.Items.Clear();
                listView2.View = View.Details;
                while (rdr.Read())
                {
                    lv = new ListViewItem(new string[] { rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[0].ToString() }, 1);
                    lv.Name = rdr[1].ToString();
                    lv.Tag = rdr[6].ToString();
                    listView2.Items.Add(lv);

                }
                listView2.Visible = true;
                richTextBox1.Visible = false;                
                listView1.Visible = false;
            }
            rdr.Close();
            conn.Close();
           
            
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
           
        }

        private void proverka(string num)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;

            comm.CommandText = "select [Ссылка на работу] from [Выполненная задача] where [№ задачи] = '" + listView2.SelectedItems[0].SubItems[4].Text + "' and [№ студента] = '" + numStudent + "'";
            SqlDataReader rdr = comm.ExecuteReader();
            rdr.Read();
            string g = rdr[0].ToString();
            if (rdr[0].ToString() == "")
            {
                loadTask.Enabled = true;

            }
            else { loadTask.Enabled = false; };
            rdr.Close();
            conn.Close();
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            richTextBox1.Clear();
            proverka(listView2.SelectedItems[0].SubItems[4].ToString());
            richTextBox1.LoadFile(Application.StartupPath + listView2.SelectedItems[0].Tag.ToString());
            listView2.Visible = false;
            richTextBox1.Visible = true;            
            listView1.Visible = false;
        }

        private void generateTasks(string id, int count)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            //находим номера свободных задач
            comm.CommandText = "select [№ задачи] from Задача where [№ вершины] = '"+ id +"' and [№ задачи] not in (select [№ задачи] from [Выполненная задача])";
            SqlDataReader rdr = comm.ExecuteReader();
            List<string> nodes = new List<string>();
            nodes.Clear();
            int i = 1;
            //записываем первые count в список
            while (rdr.Read() && i<=count)
            {               
                nodes.Add(rdr[0].ToString());
                i++;
            }
            rdr.Close();
            //вставляем сгенерированные задачи в таблицу Выполненная задача
            foreach (string node in nodes) 
            {
                comm.CommandText = "insert into [Выполненная задача] ([№ задачи], [№ студента], Балл, [Дата сдачи]) Values ('" + node + "', '" + numStudent + "', '', '')";
                comm.ExecuteNonQuery();
            }                      
            conn.Close();
            
        }

        private void searchCPC()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            //находим Самостоятельные работы, для которых не сгенерены задачи
            comm.CommandText = "select [№ вершины], [Сколько каждому] from Вершина where Вершина.[№ дерева] = '" + treeView1.Tag.ToString() + "' and Вершина.[Тип вершины] = 1 and Вершина.[№ вершины] not in (select Вершина.[№ вершины] from [Выполненная задача], Задача, Вершина where [Выполненная задача].[№ студента] = '" + numStudent + "' and Задача.[№ задачи]=[Выполненная задача].[№ задачи] and Задача.[№ вершины]=Вершина.[№ вершины] and Вершина.[№ дерева]='" + treeView1.Tag.ToString() + "')";
            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                generateTasks(rdr[0].ToString(), Convert.ToInt32(rdr[1]));
            }
            rdr.Close();
            conn.Close();
        }
        private void studentWork_Load(object sender, EventArgs e)
        {
            nazad.Enabled = false;
            
        }

        private void nazad_Click(object sender, EventArgs e)
        {
            listView2.Visible = true;
            richTextBox1.Visible = false;
            listView1.Visible = false;
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            regForm rg = new regForm();
            rg.Show();
            this.Hide();
        }

        private void loadTask_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            
            DialogResult res = ofd.ShowDialog();
            if (res == DialogResult.OK)
            {
                pg.Visible = true;
                bwStream.RunWorkerAsync();
                
                insertTask(path);
                
                loadTask.Enabled = false;
            }
        }
        string path;
        private void bwStream_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathString;
            string studentFilePuth = Application.StartupPath + "\\StudentFiles";
            pathString = System.IO.Path.Combine(studentFilePuth, fio);
            System.IO.Directory.CreateDirectory(pathString);
            pathString = pathString + "\\" + ofd.SafeFileName;
            path = pathString.Remove(0, Application.StartupPath.Length);

            FileStream inputstream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
            FileStream outputstream = new FileStream(pathString, FileMode.Create, FileAccess.Write, FileShare.None);
            bwStream.ReportProgress(0);
            decimal part;
            int i = 0;
            try
            {
                byte readbyte = 0;
                while (inputstream.Position < inputstream.Length)
                {
                    i++;
                    if (i == 100)
                    {
                        part = (decimal)inputstream.Position / inputstream.Length * 100;
                        if (part < 100)
                            bwStream.ReportProgress((int)part);
                        i = 0;
                        if (bwStream.CancellationPending)
                        {
                            break;
                        }
                    }
                    readbyte = (byte)inputstream.ReadByte();
                    outputstream.WriteByte(readbyte);
                }                               
                if (!bwStream.CancellationPending)
                {
                    bwStream.ReportProgress(100);
                }
            }
            finally
            {
                outputstream.Close();
                inputstream.Close();
                
                //insertTask(pathString.Remove(0, Application.StartupPath.Length));
            }
        }

        private void insertTask(string path)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;

            comm.CommandText = "update  [Выполненная задача] set [Ссылка на работу] = '" + path + "' where [№ задачи] = '" + listView2.SelectedItems[0].SubItems[4].Text + "' and [№ студента] = '" + numStudent + "'";
            comm.ExecuteNonQuery();            
            conn.Close();
        }

        private void bwStream_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pg.Value = e.ProgressPercentage;
        }
    }
}
