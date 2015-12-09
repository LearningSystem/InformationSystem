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
    public partial class treeWork : Form
    {
        SqlConnection conn;
        //string connectionString =
        //        "Data Source=(local);Initial Catalog=Education; user id = sa; password = 1";
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;


        SqlDataAdapter adapter;
        DataTable data = new DataTable();
        TreeNode newNode;

        int activeList;

        string numPrepod = "";
        public treeWork(string _numPrepod)
        {
            InitializeComponent();
            numPrepod = _numPrepod;
            loadListView();
            loadListViewTasks();
            listView1.Visible = true;
            listView2.Visible = false;
            panel1.Visible = false;
        }

        private void showWindow(bool lv1, bool lv2, bool pnl1, bool rtb1)
        {

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
        private void создатьДеревоToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            newTree nT = new newTree(numPrepod);
            nT.Show();
        }
        string numDisc;
        private void моиДеревьяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = true;
            listView2.Visible = false;
            panel1.Visible = false;
            activeList = 1;
            listView1.Items.Clear();
            listView1.View = View.Tile;
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select [№ дерева], Название, [№ предмета] from Дерево where [№ преподавателя] = '" + numPrepod + "'";

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
                lv = new ListViewItem(new string[] { tName, type, numTree }, 1);
                lv.Name = tName;
                listView1.Items.Add(lv);
                numDisc = rdr[2].ToString();
            }
            rdr.Close();
            conn.Close();
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
                        //treeView1.SelectedNode.Nodes.Add(rdr[1].ToString()).Tag = rdr[0].ToString();
                        //treeView1.Update();                        

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

        private void searchNode(string Id, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag.ToString() == Id)
                {
                    treeView1.SelectedNode = node;
                    break;
                }
            }
        }

        private void insertTest(string id)
        {
            string typeNode = _typeNode("Тест");
            string numTree = treeView1.Tag.ToString();
            TreeNode node;

            if (treeView1.Nodes == null)
            {
                node = null;
            }
            else
            {
                node = treeView1.SelectedNode;
            }
            insertNode(node, numTree, "Тест", typeNode, "");

            
            
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (activeList == 1)
            {
                if (listView1.SelectedItems[0].SubItems[1].Text == "Тест")
                {
                    
                    insertTest(listView1.SelectedItems[0].SubItems[2].Text);                   
                    
                }
                else
                {
                    treeView1.Nodes.Clear();
                    string numTree = listView1.SelectedItems[0].SubItems[2].Text;
                    LoadTree(numTree);
                    treeView1.Tag = numTree;
                    listView1.Items.Clear();
                }
            }
            else
            {
                string numNode = listView1.SelectedItems[0].Tag.ToString();
                listView1.Items.Clear();
                searchNode(numNode, treeView1.SelectedNode.Nodes);
                loadDir(numNode);
                
            }
            
        }

        private void insertNode(TreeNode node, string numTree, string Text, string type, string Path)
        {
            string cmd = "";
            try
            {
                //вставляем в таблицу Вершина
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "insert into Вершина ([№ дерева], Текст, [Тип вершины], Ссылка, [Сколько каждому]) Values ('" + numTree + "', '" + Text + "', '" + type + " ', '" + Path + "', '0')";
                comm.ExecuteNonQuery();
                //находим номер вставленной вершины в БД
                comm.CommandText = "select SCOPE_IDENTITY()";
                SqlDataReader rdr = comm.ExecuteReader();
                string num="";
                //вставляем в таблицу Связи
                if (rdr.HasRows)
                {
                    rdr.Read();
                    num = rdr[0].ToString();
                    TreeNode child = new TreeNode(Text);
                    child.Name = Text;
                    child.Tag = num;
                    
                    if ((type == "2")||(type == "5"))
                        {
                            child.ImageIndex = 1;
                        }
                        else { child.ImageIndex = 0;}
                    if (node == null)
                    {
                        
                        treeView1.Nodes.Add(child);
                        treeView1.SelectedNode = child;
                        cmd = "INSERT INTO Связи ([№ вершины], [№ потомка], Уровень) select " + num + "," + num + ",0 UNION ALL select " + num + ", 0 ,0";
                    }
                    else
                    {
                        node.Nodes.Add(child);
                        cmd = "INSERT INTO Связи ([№ вершины], [№ потомка], Уровень) SELECT [№ вершины], " + child.Tag.ToString() + ", Уровень+1 FROM Связи WHERE [№ потомка] = " + node.Tag.ToString() + " UNION ALL select " + child.Tag.ToString() + ", " + child.Tag.ToString() + ", 0";
                    }
                }
                rdr.Close();
                comm.CommandText = cmd;
                comm.ExecuteNonQuery();
                if (type == "4")
                {
                    comm.CommandText = "Update Тест set [№ вершины] = '" + num + "' where [№ теста] = '" + listView1.SelectedItems[0].SubItems[2].Text + "'";
                    comm.ExecuteNonQuery();
                   
                }
            }
            finally
            {
                conn.Close();
                treeView1.Update();
            }
        }

        private string _typeNode(string type)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from [Тип вершины] where Тип = '" + type + "'";
            SqlDataReader rdr = comm.ExecuteReader();
            string typeNode = "";
            if (rdr.HasRows)
            {
                rdr.Read();
                typeNode = rdr[0].ToString();
            }
            rdr.Close();
            return typeNode;
        }

        private void newSection_Click(object sender, EventArgs e)
        {
            string typeNode = _typeNode("Новый раздел");
            string numTree = treeView1.Tag.ToString();
            TreeNode node;
            if (treeView1.Nodes == null)
            {
                node = null;
            }
            else
            {
                node = treeView1.SelectedNode;
            }
            insertNode(node, numTree, "Новый раздел", typeNode, "");
        }

        private void cpc_Click(object sender, EventArgs e)
        {
            string typeNode = _typeNode("Самостоятельная работа");
            string numTree = treeView1.Tag.ToString();
            TreeNode node;
            
            if (treeView1.Nodes == null)
            {
                node = null;
            }
            else
            {
                node = treeView1.SelectedNode;
            }
            insertNode(node, numTree, "Самостоятельная работа", typeNode, "");
        }

        private void insertTask(string name, string level, string max, string date, string parent, string path)
        {
            try
            {
                //вставляем в таблицу Вершина
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "insert into Задача (Название, Уровень, [Максимальный балл], [Срок сдачи], [№ вершины], Ссылка) Values ('" + name + "', '" + level + "', '" + max + " ', '" + date + "', '"+ parent +"', '"+ path +"')";
                comm.ExecuteNonQuery();                                                              
            }
            finally
            {
                conn.Close();             
            }
        }

        private void addFiles(string type, Boolean multiselect)
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.FileName = "";
            OP.InitialDirectory = Application.StartupPath;
            OP.Filter = "RTF Files (*.rtf)|*.rtf";
            OP.Title = "Добавить файлы";
            OP.Multiselect = multiselect;
            if (OP.ShowDialog() != DialogResult.Cancel)
            {
                TreeNode node = new TreeNode();
                node = treeView1.SelectedNode;

                foreach (String file in OP.FileNames)
                {
                    try
                    {
                        string path = file.Remove(0, OP.InitialDirectory.Length); //путь к файлу
                        string name = path.Remove(path.Length - 4, 4);
                        string Name = name.Remove(0, name.LastIndexOf("\\") + 1); // Имя файла

                        string typeNode = _typeNode(type);
                        
                        if (type == "Задача")
                        {
                            insertTask(Name, "", "", "", treeView1.SelectedNode.Tag.ToString(), path);
                        }
                        else
                        {
                            insertNode(treeView1.SelectedNode, treeView1.Tag.ToString(), Name, typeNode, path);
                        }
                    }
                    finally
                    {
                        treeView1.Update();
                    }
                }
                
            }
        }

        private void учебныеМатериалыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addFiles("Учебные материалы", true);
        }

        private void задачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addFiles("Задача", true);
            loadTasks(treeView1.SelectedNode.Tag.ToString());
        }

        private string indexType(string Id)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select [Тип вершины] from Вершина where [№ вершины] = '" + Id + "'";
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

        private void addNode_Click(object sender, EventArgs e)
        {

            if (treeView1.Nodes.Count == 0)
            {
                newSection.Enabled = true;
                cpc.Enabled = false;
                doc.Enabled = false;
                task.Enabled = false;
                test.Enabled = false;
            }
            else
            {
                switch (indexType(treeView1.SelectedNode.Tag.ToString()))
                {
                    case "5":
                        {
                            newSection.Enabled = false;
                            cpc.Enabled = false;
                            doc.Enabled = false;
                            task.Enabled = false;
                            test.Enabled = false;
                        }; break;
                    case "1":
                        {
                            newSection.Enabled = false;
                            cpc.Enabled = false;
                            doc.Enabled = true;
                            task.Enabled = true;
                            test.Enabled = false;
                        }; break;
                    case "2":
                        {
                            newSection.Enabled = false;
                            cpc.Enabled = false;
                            doc.Enabled = false;
                            task.Enabled = false;
                            test.Enabled = false;
                        }; break;
                    case "3":
                        {
                            newSection.Enabled = true;
                            cpc.Enabled = true;
                            doc.Enabled = true;
                            task.Enabled = false;
                            test.Enabled = true;

                        }; break;
                }
            }
        }

        private void updateEnablingButtons()
        {
            up.Enabled = (treeView1.SelectedNode != null
                            && treeView1.SelectedNode.PrevNode != null);

            down.Enabled = (treeView1.SelectedNode != null
                            && treeView1.SelectedNode.NextNode != null);
        }

        private string _type(string Id)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select Тип from [Тип вершины] where [Код] = '" + Id + "'";
            SqlDataReader rdr = comm.ExecuteReader();
            string type = "";
            if (rdr.HasRows)
            {
                rdr.Read();
                type = rdr[0].ToString();
            }
            rdr.Close();
            conn.Close();
            return type;
            
        }

        private void loadDir(string Id)
        {
            listView1.Visible = true;
            listView2.Visible = false;
            panel1.Visible = false; 

            string numTree = treeView1.Tag.ToString();

            listView1.Items.Clear();
            listView1.View = View.Tile;
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "SELECT Вершина.[№ вершины], Текст, [Тип вершины], Ссылка FROM Вершина JOIN Связи ON (Вершина.[№ вершины] = Связи.[№ потомка]) WHERE (Связи.[№ вершины] = " + Id + ") AND (Связи.Уровень = 1) and (Вершина.[№ дерева] = " + numTree + ") and (Связи.[№ вершины] <> Связи.[№ потомка])";
            SqlDataReader rdr = comm.ExecuteReader();

            //заполнение listView
            ListViewItem lv = new ListViewItem();
            string fName = "";
            while (rdr.Read())
            {
                fName = rdr[1].ToString();
                string type = rdr[2].ToString();
                string path = rdr[3].ToString();
                int indexImage;
                if ((_type(type) == "Задача") || (_type(type) == "Учебные материалы"))
                {
                    indexImage = 1;
                }
                else { indexImage = 0; }

                lv = new ListViewItem(new string[] { fName, _type(type), path }, indexImage);
                lv.Name = fName;
                lv.Tag = rdr[0].ToString();
                listView1.Items.Add(lv);
            }
            rdr.Close();
            conn.Close();

 
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

        private void loadListViewTasks()
        {
            //добавления колонок            
            ColumnHeader c = new ColumnHeader();
            c.Text = "Название";
            c.Width = c.Width + 80;
            ColumnHeader c2 = new ColumnHeader();
            c2.Text = "Максимальный балл";
            c2.Width = c2.Width + 60;
            ColumnHeader c3 = new ColumnHeader();
            c3.Text = "Срок сдачи";
            c3.Width = c3.Width + 60;
            ColumnHeader c1 = new ColumnHeader();
            c1.Text = "";
            c1.Width = c1.Width + 60;

            listView2.Columns.Add(c);            
            listView2.Columns.Add(c2);
            listView2.Columns.Add(c3);
            listView2.Columns.Add(c1);
        }

        private void loadTasks(string Id)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from Задача where [№ вершины] = '" + Id + "'";

            ListViewItem lv = new ListViewItem();

            SqlDataReader rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                listView2.Items.Clear();
                while (rdr.Read())
                {
                    lv = new ListViewItem(new string[] { rdr[1].ToString(), rdr[3].ToString(), rdr[4].ToString() }, 1);
                    lv.Name = rdr[1].ToString();
                    lv.Tag = rdr[0].ToString();
                    listView2.Items.Add(lv);

                }
                listView2.View = View.Details;
                listView2.Visible = true;                
                listView1.Visible = false;
                panel1.Visible = false;
            }
            rdr.Close();
            conn.Close();
           
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string type = typeNode(treeView1.SelectedNode.Tag.ToString());
            treeView1.SelectedImageIndex = treeView1.SelectedNode.ImageIndex;
            activeList = 2;
            name.Text = treeView1.SelectedNode.Text;
            if (type == "Новый раздел")
            {
                loadDir(treeView1.SelectedNode.Tag.ToString());
            }
            
            if (type == "Самостоятельная работа")
            {
                loadTasks(treeView1.SelectedNode.Tag.ToString());
            }            
            if (type == "Тест")
            {
                loadTest(treeView1.SelectedNode.Tag.ToString());
            }                                                          
        }

        private void loadTest(string id)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select Название, Тема, [Максимальный балл], [Срок сдачи], Ссылка from Тест where [№ вершины] = '" + id + "'";

            ListViewItem lv = new ListViewItem();

            SqlDataReader rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                listView2.Items.Clear();
                while (rdr.Read())
                {
                    lv = new ListViewItem(new string[] { rdr[0].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[1].ToString() }, 1);
                    lv.Name = rdr[1].ToString();
                    lv.Tag = rdr[4].ToString();//ссылка на xml файл
                    listView2.Items.Add(lv);

                }
                listView2.View = View.Details;
                listView2.Visible = true;
                listView1.Visible = false;
                panel1.Visible = false;
                
            }
            rdr.Close();
            conn.Close();
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Text = name.Text;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode.Parent;
            string id = treeView1.SelectedNode.Tag.ToString();
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select Вершина.[№ вершины] from Вершина join Связи on (Вершина.[№ вершины] = Связи.[№ потомка]) where Связи.[№ вершины] = " + id + "";
                SqlDataReader rdr = comm.ExecuteReader();
                int[] mas = new int[100];
                int i = 1;
                while (rdr.Read())
                {
                    mas[i] = Convert.ToInt32(rdr[0]);
                    i++;
                }
                rdr.Close();
                comm.CommandText = "delete from Связи where [№ потомка] in (select Вершина.[№ вершины] from Вершина join Связи on (Вершина.[№ вершины] = Связи.[№ потомка]) where Связи.[№ вершины] = " + id + ") or Связи.[№ вершины] = " + id + "";
                comm.ExecuteNonQuery();
                for (int j = 1; j < i; j++)
                {
                    comm.CommandText = "delete from [Выполненная задача]   where [№ задачи] in (select [№ задачи] from Задача where [№ вершины]='" + mas[j].ToString() + "')";
                    comm.ExecuteNonQuery();
                    comm.CommandText = "delete from Задача where [№ вершины]=" + mas[j].ToString() + "";
                    comm.ExecuteNonQuery();
                    comm.CommandText = "delete from Вершина where [№ вершины]=" + mas[j].ToString() + "";
                    comm.ExecuteNonQuery();
                }
            }
            finally
            {
                conn.Close();
                treeView1.SelectedNode.Remove();
                treeView1.SelectedNode = node;
            }
        }

        private void up_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null
                && treeView1.SelectedNode.PrevNode != null)
            {
                TreeNodeCollection editNodes;
                if (treeView1.SelectedNode.Parent != null)
                    editNodes = treeView1.SelectedNode.Parent.Nodes;
                else
                    editNodes = treeView1.Nodes;

                int indexSelectedNode = treeView1.SelectedNode.Index;
                int indexPreviousNode = treeView1.SelectedNode.PrevNode.Index;

                TreeNode selectedNode = treeView1.SelectedNode;

                editNodes.RemoveAt(indexSelectedNode);
                editNodes.Insert(indexPreviousNode, selectedNode);

                treeView1.SelectedNode = selectedNode;
            }
        }




        private void down_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null
                && treeView1.SelectedNode.NextNode != null)
            {
                TreeNodeCollection editNodes;
                if (treeView1.SelectedNode.Parent != null)
                    editNodes = treeView1.SelectedNode.Parent.Nodes;
                else
                    editNodes = treeView1.Nodes;

                int indexSelectedNode = treeView1.SelectedNode.Index;
                int indexNextNode = treeView1.SelectedNode.NextNode.Index;

                TreeNode selectedNode = treeView1.SelectedNode;

                editNodes.RemoveAt(indexSelectedNode);
                editNodes.Insert(indexNextNode, selectedNode);

                treeView1.SelectedNode = selectedNode;
            }
        }

        private void name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "update Вершина set Текст = '"+ name.Text +"' where [№ вершины] = '"+ treeView1.SelectedNode.Tag.ToString() +"'";
                comm.ExecuteNonQuery();
                conn.Close();
                treeView1.Focus();
            }
        }

        private void propTasks_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select [Сколько каждому] from Вершина where [№ вершины] = '"+ treeView1.SelectedNode.Tag.ToString() +"'";
            SqlDataReader rdr = comm.ExecuteReader();
            rdr.Read();
            textBox4.Text = rdr[0].ToString();
            rdr.Close();
            conn.Close();            
            if (listView2.SelectedItems.Count == 1)
            {
                textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = true;
                textBox1.Text = listView2.SelectedItems[0].SubItems[1].Text;
                textBox2.Text = listView2.SelectedItems[0].SubItems[2].Text;
                textBox3.Text = listView2.SelectedItems[0].SubItems[3].Text;

            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                if (listView2.SelectedItems.Count == 0)
                {
                    textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = false;
                }                
            }            
            panel1.Visible = true;
            listView2.Visible = false;
            listView1.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                foreach (ListViewItem task in listView2.SelectedItems)
                {
                    comm.CommandText = "update Задача set Уровень = '" + textBox1.Text + "', [Максимальный балл] = '" + textBox2.Text + "', [Срок сдачи] = '"+ textBox3.Text +"'   where [№ задачи] = '" + task.Tag.ToString() + "'";
                    comm.ExecuteNonQuery();
                    
                }
                conn.Close();
                loadTasks(treeView1.SelectedNode.Tag.ToString());
                panel1.Visible = false;
                listView2.Visible = true;
                listView1.Visible = false;
            }
            else               
            {
                if (textBox1.Enabled == true) { MessageBox.Show("Введите данные!"); }
            }
            if (textBox4.Text != "0")
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "update Вершина set [Сколько каждому] = '" + textBox4.Text + "' where [№ вершины] = '" + treeView1.SelectedNode.Tag.ToString() + "'";
                comm.ExecuteNonQuery();
                conn.Close();
                panel1.Visible = false;
                listView2.Visible = true;
                listView1.Visible = false;
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prepodWork pw = new prepodWork(Convert.ToInt32(numPrepod));
            pw.Show();
            this.Hide();
        }

        private void test_Click(object sender, EventArgs e)
        {
            listView1.Visible = true;
            listView2.Visible = false;
            panel1.Visible = false;
            activeList = 1;
            listView1.Items.Clear();
            listView1.View = View.Tile;
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select [№ теста], Название, Тема from Тест where [№ преподавателя] = '" + numPrepod + "'and [№ предмета] = '" + numDisc + "'";

            SqlDataReader rdr = comm.ExecuteReader();

            //заполнение listView
            ListViewItem lv = new ListViewItem();
            string tName = "";           
            while (rdr.Read())
            {
                string type = "Тест";
                tName = rdr[1].ToString();
                string numTest = rdr[0].ToString();
                lv = new ListViewItem(new string[] { tName, type, numTest }, 1);
                lv.Name = tName;
                listView1.Items.Add(lv);
            }
            rdr.Close();
            conn.Close();
        }



       

    }
}
