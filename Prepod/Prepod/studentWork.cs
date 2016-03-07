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
        string passStudent;
        string numTree;

        TreeNode newNode;
        SqlDataAdapter adapter;
        DataTable data = new DataTable();

        OpenFileDialog ofd;

        List<int> tasks = new List<int>();
        string puthEXE = Application.StartupPath+"\\"+"Tests\\Tests\\bin\\Debug\\Tests.exe";
        public studentWork(string _numStudent,string _passStudent)
        {
            InitializeComponent();
            numStudent = _numStudent;
            passStudent = _passStudent;
            loadTask.Enabled = false;
            pg.Visible = false;
            loadInf(); 
            rb.Visible = false;            
            listView1.Visible = true;
            startTest.Visible = false;
            nazad.Enabled = false;
            estMenu.Enabled = false;
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
            name.BackColor = Color.LawnGreen;
            string group = rdr[5].ToString();            

            rdr.Close();
            conn.Close();
        }

        private void loadListView(List<String> col)
        {
            foreach (ColumnHeader ch in listView1.Columns)
            {
                listView1.Columns.Remove(ch);
            }
            foreach (string c in col)
            {
                listView1.Columns.Add(c, 80);
            }
        }

        private void выбратьКурсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rb.Visible = false;            
            listView1.Visible = true;
            listView1.Items.Clear();                        
            listView1.View = View.Tile;
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select [№ дерева], Предмет.Название from Дерево, Предмет where [№ преподавателя] in (select [№ преподавателя] from [Группы преподавателя], Студент where Студент.[№ группы] = [Группы преподавателя].[№ группы] and Студент.[№ студента] = '"+ numStudent +"')";

            SqlDataReader rdr = comm.ExecuteReader();

            List<String> col = new List<string>();
            col.Add("Название");
            col.Add("Тип");
            col.Add("№ дерева");
            //заполнение listView
            loadListView(col);
            //заполнение listView
            ListViewItem lv = new ListViewItem();
            string tName = "";           
            while (rdr.Read())
            {
                string type = "Курс обучения";
                tName = rdr[1].ToString();
                numTree = rdr[0].ToString();
                lv = new ListViewItem(new string[] { tName, type, numTree }, 1);
                lv.Name = "Курс обучения";
                lv.Tag = numTree;
                listView1.Items.Add(lv);
            }
             
            rdr.Close();
            conn.Close();
            
            loadInf();
            if (passStudent == "1")
            {
                WarningPass chg = new WarningPass();
                chg.ShowDialog();
            }
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
                comm.CommandText = "SELECT Вершина.[№ вершины], Текст, [Тип вершины], Имя FROM Вершина JOIN Связи ON (Вершина.[№ вершины] = Связи.[№ потомка]) WHERE (Связи.[№ вершины] = " + node.Tag + ") AND (Связи.Уровень = 1) and (Вершина.[№ дерева] = " + numTree + ") and (Связи.[№ вершины] <> Связи.[№ потомка])";
                SqlDataReader rdr = comm.ExecuteReader();
                rdr.Read();

                if (rdr.HasRows)
                {
                    do
                    {
                        newNode = new TreeNode(rdr[1].ToString());
                        newNode.Tag = rdr[0].ToString();
                        newNode.Name = rdr[3].ToString();
                        if ((rdr[2].ToString() == "2") || (rdr[2].ToString() == "5") || (rdr[2].ToString() == "4"))
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
            comm.CommandText = "select Вершина.[№ вершины], Текст, [Тип вершины], Имя from Вершина where Вершина.[№ вершины] in  (select Связи.[№ вершины] from Связи where [№ потомка] = 0) and [№ дерева] = " + numTree + "";
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
                    newNode.Name = rdr[3].ToString();
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
            switch (listView1.SelectedItems[0].Name)
            {
                case "Курс обучения":
                    {
                        treeView1.Nodes.Clear();       
                        numTree = listView1.SelectedItems[0].SubItems[2].Text;
                        LoadTree(numTree);
                        treeView1.Tag = numTree;
                        name.Text = name.Text + " | " + listView1.SelectedItems[0].SubItems[0].Text;                        
                        estMenu.Enabled = true;
                        listView1.Items.Clear();  
                        searchCPC(); 
                    }; break;
                case "Тест":
                    {
                        startTest.Enabled = true;
                        startTest.Visible = true;
                        startTest.BackColor = Color.Lime;                       
                    }; break;
                case "Задача":
                    {
                        rb.LoadFile(Application.StartupPath + listView1.SelectedItems[0].Tag.ToString());
                        rb.Visible = true;
                        listView1.Visible = false;
                        nazad.Enabled = true;
                        proverka();
                    }; break;
            }
                                  
        }

        private bool dostup(string id)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select Доступ from Вершина where [№ вершины] = '" + id + "'";
            SqlDataReader rdr = comm.ExecuteReader();
            rdr.Read();
            bool flag = (Convert.ToInt32(rdr[0]) == 1);
            rdr.Close();
            conn.Close();
            return flag;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bool flag = dostup(treeView1.SelectedNode.Tag.ToString()); //считываем доступ
            startTest.Visible = false;
            pg.Visible = false;
            treeView1.SelectedImageIndex = treeView1.SelectedNode.ImageIndex;
            startTest.Visible = false;
            loadTask.Enabled = false;
            loadTask.BackColor = SystemColors.Control;
            if (flag)
            {
                switch (e.Node.Name.ToString())
                {
                    case "Самостоятельная работа":
                        {
                            loadTasks(e.Node.Tag.ToString());
                            nazad.Enabled = true;
                        }; break;
                    case "Тест":
                        {
                            loadTest(e.Node.Tag.ToString());
                        }; break;
                    case "Новый раздел":
                        {

                        }; break;
                    default:
                        {
                            nazad.Enabled = false;
                            rb.Visible = true;
                            listView1.Visible = false;
                            conn = new SqlConnection(connectionString);
                            conn.Open();
                            SqlCommand comm = new SqlCommand();
                            comm.Connection = conn;
                            comm.CommandText = "select Ссылка from Вершина where [№ вершины] = '" + e.Node.Tag.ToString() + "'";
                            SqlDataReader rdr = comm.ExecuteReader();
                            rdr.Read();
                            rb.LoadFile(Application.StartupPath + rdr[0].ToString());
                            rdr.Close();
                            conn.Close();
                        }; break;
                }
            }
        }

        private void loadText(string id)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select Ссылка From Вершина where [№ вершины] = '" + id + "'";

            SqlDataReader rdr = comm.ExecuteReader();
            rdr.Read();
            string path = rdr[0].ToString();
            if (path != "")
            {
                rb.LoadFile(Application.StartupPath + path);
            }            
            rb.Visible = true;
            listView1.Visible = false;
            rdr.Close();
            conn.Close();
        }
        private void loadTest(string id)
        {
            
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select Название, Тема, [Максимальный балл], [Срок сдачи], Ссылка from Тест where [№ вершины] = '" + id + "'";

            ListViewItem lv = new ListViewItem();

            List<String> col = new List<string>();
            col.Add("Название");            
            col.Add("Тема");
            col.Add("Максимальный балл");
            col.Add("Срок сдачи");
            
            //заполнение listView
            loadListView(col);

            SqlDataReader rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                listView1.Items.Clear();
                while (rdr.Read())
                {
                    lv = new ListViewItem(new string[] { rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString() }, 1);
                    lv.Name = "Тест";
                    lv.Tag = rdr[4].ToString();//ссылка на xml файл
                    listView1.Items.Add(lv);
                }
                listView1.View = View.Details;                
                listView1.Visible = true;
                rb.Visible = false;
            }
            rdr.Close();
            conn.Close();
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

        private void loadTasks(string id)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select Задача.Название, Вершина.Уровень, Вершина.[Максимальный балл], Вершина.[Срок сдачи], Задача.Ссылка, Задача.[№ задачи] from Задача, [Выполненная задача], Вершина where Вершина.[№ вершины] = Задача.[№ вершины] and Задача.[№ задачи]=[Выполненная задача].[№ задачи] and Задача.[№ вершины]='" + id + "' and [Выполненная задача].[№ студента] = '" + numStudent + "'";

            ListViewItem lv = new ListViewItem();

            List<String> col = new List<string>();
            col.Add("Номер");
            col.Add("Название");
            col.Add("Уровень");
            col.Add("Максимальный балл");
            col.Add("Срок сдачи");

            //заполнение listView
            loadListView(col);

            SqlDataReader rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                listView1.Items.Clear();
                listView1.View = View.Details;
                while (rdr.Read())
                {
                    lv = new ListViewItem(new string[] { rdr[5].ToString(), rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString() }, 1);
                    lv.Name = "Задача";
                    lv.Tag = rdr[4].ToString();
                    listView1.Items.Add(lv);

                }
                listView1.Visible = true;
                rb.Visible = false;                                
            }
            rdr.Close();
            conn.Close();                      
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
           
        }

        private void proverka()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;

            comm.CommandText = "select [Дата сдачи] from [Выполненная задача] where [№ задачи] = '" + listView1.SelectedItems[0].SubItems[0].Text + "' and [№ студента] = '" + numStudent + "'";
            SqlDataReader rdr = comm.ExecuteReader();
            rdr.Read();
            string g = rdr[0].ToString();
            if (rdr[0].ToString() == "")
            {
                loadTask.BackColor = Color.Lime;
                loadTask.Enabled = true;
            }
            else { loadTask.BackColor = SystemColors.Control; loadTask.Enabled = false; };
            rdr.Close();
            conn.Close();
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
                comm.CommandText = "insert into [Выполненная задача] ([№ задачи], [№ студента], [Дата сдачи]) Values ('" + node + "', '" + numStudent + "', '')";
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
            
            
        }

        private void nazad_Click(object sender, EventArgs e)
        {
            rb.Visible = false;
            listView1.Visible = true;
            nazad.Enabled = false;
            pg.Visible = false;
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
            ofd.Filter = "cs files (*.cs)|*.cs";
            if (res == DialogResult.OK)
            {
                if (!File.Exists(Application.StartupPath + "\\StudentFiles\\" + ofd.SafeFileName))
                {
                    pg.Visible = true;
                    bwStream.RunWorkerAsync();
                    //string path = "\\StudentFiles\\" + ofd.SafeFileName;
                    string path = ofd.SafeFileName;
                    insertTask(path);
                    loadTask.Enabled = false;
                    loadTask.BackColor = SystemColors.Control;
                }
                else
                {
                    MessageBox.Show("Такое имя уже существует. Переименуйте файл!");
                }
            }
        }
        
        private void bwStream_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathString;
            string studentFilePuth = "\\StudentFiles";
            //pathString = System.IO.Path.Combine(studentFilePuth, fio);
            //System.IO.Directory.CreateDirectory(pathString);
            string path = studentFilePuth + "\\" + ofd.SafeFileName;            

            FileStream inputstream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
            FileStream outputstream = new FileStream(Application.StartupPath + path, FileMode.Create, FileAccess.Write, FileShare.None);
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
                MessageBox.Show("Задача отправлена!");
                pg.Visible = false;
                //insertTask(pathString.Remove(0, Application.StartupPath.Length));
            }
        }

        private void insertTask(string path)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;

            comm.CommandText = "update  [Выполненная задача] set [Ссылка на работу] = '" + path + "', [Дата сдачи]='"+ DateTime.Today.ToShortDateString() +"' where [№ задачи] = '" + listView1.SelectedItems[0].SubItems[0].Text + "' and [№ студента] = '" + numStudent + "'";
            comm.ExecuteNonQuery();            
            conn.Close();
        }

        private void bwStream_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pg.Value = e.ProgressPercentage;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            startTest.Visible = true;
            startTest.BackColor = Color.Lime;
        }

        private void startTest_Click(object sender, EventArgs e)
        {
            string puthXML = listView1.SelectedItems[0].Tag.ToString(); // ссылка на xml
            //System.Diagnostics.Process.Start(puthEXE,numStudent.ToString()+" "+puthXML);
            TestStart goStart = new TestStart(Int32.Parse(numStudent), puthXML);
            this.Hide();
            goStart.Show();
        }

        private void успеваемостьToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            studEstimates se = new studEstimates(numStudent, numTree);
            se.Show();
        }

        private void сменитьПарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePass chpass = new ChangePass(numStudent);
            chpass.Show();
        }
    }
}
