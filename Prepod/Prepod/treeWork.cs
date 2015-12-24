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

        
        DataTable data = new DataTable();
        TreeNode newNode;        

        string numPrepod = "";
        string numTree;
        public treeWork(string _numPrepod)
        {
            InitializeComponent();
            numPrepod = _numPrepod;
                        
            listView1.Visible = true;
            rb.Visible = false;
            panel1.Visible = false;
            esimates.Enabled = checkTasks.Enabled = false;
        }

        private void showWindow(bool lv1, bool lv2, bool pnl1, bool rtb1)
        {

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
        private void создатьДеревоToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            newTree nT = new newTree(numPrepod);
            nT.Show();
        }
        string numDisc;
        private void моиДеревьяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = true;
            rb.Visible = false;
            panel1.Visible = false;            
            listView1.Items.Clear();
            listView1.View = View.Tile;
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select [№ дерева], Название, [№ предмета] from Дерево where [№ преподавателя] = '" + numPrepod + "'";

            SqlDataReader rdr = comm.ExecuteReader();

            List<String> col = new List<string>();
            col.Add("Название");
            col.Add("Тип");
            col.Add("№ дерева");
            //заполнение listView
            loadListView(col);
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
                    //treeView1.Select();
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
            insertNode(node, numTree, "Тест", typeNode, "", true);

            
            
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (listView1.SelectedItems[0].SubItems[1].Text)
            {
                case "Курс обучения":
                    {
                        esimates.Enabled = checkTasks.Enabled = true;
                        treeView1.Nodes.Clear();
                        numTree = listView1.SelectedItems[0].SubItems[2].Text;
                        LoadTree(numTree);
                        treeView1.Tag = numTree;
                        
                    }; break;
                case "Тест":
                    {
                        insertTest(listView1.SelectedItems[0].SubItems[2].Text);
                    }; break;                
            }
            listView1.Items.Clear();           
            
        }

        private void insertNode(TreeNode node, string numTree, string Text, string type, string Path, bool flag)
        {
            string cmd = "";
            try
            {
                //вставляем в таблицу Вершина
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "insert into Вершина ([№ дерева], Текст, [Тип вершины], Ссылка, [Сколько каждому], Доступ, Имя) Values ('" + numTree + "', '" + Text + "', '" + type + " ', '" + Path + "', '0', '" + flag.ToString() + "', '" + Text + "')";
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
                    child.Text = Text;
                    child.Tag = num;

                    if ((type == "2") || (type == "5") || (type == "4"))
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
            insertNode(node, numTree, "Новый раздел", typeNode, "", true);
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
            insertNode(node, numTree, "Самостоятельная работа", typeNode, "", true);
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
                            insertNode(treeView1.SelectedNode, treeView1.Tag.ToString(), Name, typeNode, path, true);
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

            if ((treeView1.Nodes.Count == 0) || (treeView1.SelectedNode == null))
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


        private void loadTasks(string Id)
        {

            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from Задача where [№ вершины] = '" + Id + "'";

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                TreeNode task = new TreeNode();
                task.Name = "Задача";
                task.Text = rdr[1].ToString();
                task.Tag = rdr[6].ToString();
                task.ImageIndex = 1;
                treeView1.SelectedNode.Nodes.Add(task);
            }          
            rdr.Close();
            conn.Close();
           
        }

        private bool dostup(string id)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select Доступ from Вершина where [№ вершины] = '"+ id +"'";
            SqlDataReader rdr = comm.ExecuteReader();
            rdr.Read();
            bool flag = (Convert.ToInt32(rdr[0]) == 1);
            return flag;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {            
            bool flag = true;
            if ((e.Node.Name != "Задача") && (e.Node.Name != "Тест"))
            {
                flag = dostup(e.Node.Tag.ToString()); //считываем доступ
            }
            access.SelectedIndex = Convert.ToInt32(flag);
            
            switch (e.Node.Name.ToString())
            {
                case "Задача":
                    {
                        rb.Visible = true;
                        listView1.Visible = false;
                        panel1.Visible = false;
                        rb.LoadFile(Application.StartupPath + e.Node.Tag.ToString());                        
                    }; break;
                case "Самостоятельная работа":
                    {
                        e.Node.Nodes.Clear();
                        loadTasks(e.Node.Tag.ToString());
                        loadInf(e.Node.Tag.ToString(),true);
                        e.Node.Expand();
                    }; break;
                case "Тест":
                    {
                        loadInf(e.Node.Tag.ToString(), false);
                        loadTest(e.Node.Tag.ToString());                        
                    }; break;
                case "Новый раздел":
                    {
                                                
                    }; break;
                default:
                    {
                        rb.Visible = true;
                        listView1.Visible = false;
                        panel1.Visible = false;

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
            treeView1.SelectedImageIndex = treeView1.SelectedNode.ImageIndex;
            
            name.Text = treeView1.SelectedNode.Text;                                                
        }

        private void loadInf(string id, bool flag)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            if (flag)
            {
                comm.CommandText = "select [Сколько каждому], Уровень, [Максимальный балл], [Срок сдачи] from Вершина where [№ вершины] = '" + treeView1.SelectedNode.Tag.ToString() + "'";
                textBox4.Enabled = true;
                textBox1.Enabled = true;
                SqlDataReader rdr = comm.ExecuteReader();
                rdr.Read();
                textBox4.Text = rdr[0].ToString();
                textBox1.Text = rdr[1].ToString();
                textBox2.Text = rdr[2].ToString();
                rdr.Close();
            }
            else
            {
                comm.CommandText = "select [Максимальный балл], [Срок сдачи] from Тест where [№ вершины] = '" + treeView1.SelectedNode.Tag.ToString() + "'";
                textBox4.Enabled = false;
                textBox1.Enabled = false;
                SqlDataReader rdr = comm.ExecuteReader();
                rdr.Read();
                textBox4.Text = "";
                textBox1.Text = "";
                textBox2.Text = rdr[0].ToString();
                rdr.Close();
            }

            
            //dateTimePicker1 = rdr[3].ToString();
            
            conn.Close();

            panel1.Visible = true;
            rb.Visible = false;
            listView1.Visible = false;
        }

        private void loadTest(string id)
        {
           
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
                    //comm.CommandText = "delete from [Выполненная задача]   where [№ задачи] in (select [№ задачи] from Задача where [№ вершины]='" + mas[j].ToString() + "')";
                    //comm.ExecuteNonQuery();
                    //comm.CommandText = "delete from Задача where [№ вершины]=" + mas[j].ToString() + "";
                    //comm.ExecuteNonQuery();
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
            panel1.Visible = true;
            rb.Visible = false;
            listView1.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                if (treeView1.SelectedNode.Name == "Самостоятельная работа")
                {
                    if ((textBox1.Text != "") && (textBox4.Text != ""))
                    {
                        comm.CommandText = "update Вершина set [Сколько каждому] = '" + textBox4.Text + "', Уровень = '" + textBox1.Text + "', [Максимальный балл] = '" + textBox2.Text + "', [Срок сдачи] = '" + dateTimePicker1.Value.ToShortDateString() + "' where [№ вершины] = '" + treeView1.SelectedNode.Tag.ToString() + "'";
                    }
                    else
                    {
                        MessageBox.Show("Введите данные!");
                    } 
                }
                else
                {
                    if (textBox2.Text != "") 
                    {
                        comm.CommandText = "update Тест set [Максимальный балл] = '" + textBox2.Text + "', [Срок сдачи] = '" + dateTimePicker1.Value.ToShortDateString() + "' where [№ вершины] = '" + treeView1.SelectedNode.Tag.ToString() + "'";
                    }
                    else
                    {
                        MessageBox.Show("Введите данные!");
                    } 
                }
                comm.ExecuteNonQuery();
                conn.Close();
                
                panel1.Visible = false;
                rb.Visible = true;
                listView1.Visible = false;                                   
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            regForm rf = new regForm();
            rf.Show();
            this.Hide();
        }

        private void test_Click(object sender, EventArgs e)
        {
            listView1.Visible = true;
            rb.Visible = false;
            panel1.Visible = false;            
            listView1.Items.Clear();
            listView1.View = View.Tile;
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select [№ теста], Название, Тема from Тест where [№ преподавателя] = '" + numPrepod + "'and [№ предмета] = '" + numDisc + "'";

            SqlDataReader rdr = comm.ExecuteReader();

            //заполнение listView
            List<string> col = new List<string>();
            col.Add("Название");
            col.Add("Тип");
            col.Add("№ теста");
            loadListView(col);

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

        private void access_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "update Вершина set Доступ = '" + access.SelectedIndex.ToString() + "' where [№ вершины] = '" + treeView1.SelectedNode.Tag.ToString() + "'";
            comm.ExecuteNonQuery();
            conn.Close();
        }

        private void удалитьДеревоToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void редактированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Estimates frm = new Estimates(numPrepod, numTree);
            frm.Show();
        }

        private void проверкаЗадачToolStripMenuItem_Click(object sender, EventArgs e)
        {
            taskWork tw = new taskWork(numPrepod, numTree);
            tw.Show();
        }

        private void личныеДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prepodWork pw = new prepodWork(numPrepod);
            pw.Show();
        }

        private void создатьТестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoTest newtest = new InfoTest(Convert.ToInt32(numPrepod));
            newtest.Show();
        }   
    }
}
