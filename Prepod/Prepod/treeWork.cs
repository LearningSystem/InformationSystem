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
        SqlCommand comm;
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        
        DataTable data = new DataTable();
        TreeNode newNode;        

        string numPrepod = "";
        string numTree;
        public treeWork(string _numPrepod)
        {
            InitializeComponent();
            numPrepod = _numPrepod;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand();
            comm.Connection = conn;                                                                      
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


        private void loadNodes(TreeNodeCollection nodes, string numTree)
        {
            //conn = new SqlConnection(connectionString);
            //conn.Open();
            //SqlCommand comm = new SqlCommand();
            //comm.Connection = conn;

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
            //conn.Close();
        }

        private void LoadTree(string numTree)
        {       
            try
            {
                conn.Open();
                //загружаем корневую вершину
                comm.CommandText = "select Вершина.[№ вершины], Текст, [Тип вершины], Имя from Вершина where Вершина.[№ вершины] in  (select Связи.[№ вершины] from Связи where [№ потомка] = 0) and [№ дерева] = " + numTree + "";
                SqlDataReader rdr = comm.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    string root = rdr[0].ToString();
                    if (tree.SelectedNode == null)
                    {
                        newNode = new TreeNode(rdr[1].ToString());
                        newNode.Tag = rdr[0].ToString();
                        newNode.ImageIndex = 0;
                        newNode.Name = rdr[3].ToString();
                        tree.Nodes.Add(newNode);
                        tree.Update();
                        //treeView1.Select();
                    }
                    //загрузка всех потомков
                    loadNodes(tree.Nodes, numTree);
                };
                rdr.Close();
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

        private void searchNode(string Id, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag.ToString() == Id)
                {
                    tree.SelectedNode = node;
                    break;
                }
            }
        }

        private void insertTest(string id)
        {
            string typeNode = _typeNode("Тест");
            string numTree = tree.Tag.ToString();
            TreeNode node;

            if (tree.Nodes == null)
            {
                node = null;
            }
            else
            {
                node = tree.SelectedNode;
            }
            insertNode(node, numTree, "Тест", typeNode, "", true);

            
            
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (listView1.SelectedItems[0].SubItems[1].Text)
            {
                case "Курс обучения":
                    {                        
                        tree.Nodes.Clear();
                        numTree = listView1.SelectedItems[0].Tag.ToString();
                        LoadTree(numTree);
                        tree.Tag = numTree;
                        tree.Visible = toolsTree.Visible = true;
                        tabControl1.SelectedTab = property;
                        splitContainer1.Panel1Collapsed = false;
                    }; break;
                case "Тест":
                    {
                        //insertTest(listView1.SelectedItems[0].SubItems[2].Text);
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
                conn.Open();
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
                        
                        tree.Nodes.Add(child);
                        tree.SelectedNode = child;
                        
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
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
            finally
            {
                conn.Close();
                tree.Update();
            }
        }

        private string _typeNode(string type)
        {
            string typeNode = "";
            try
            {
                conn.Open();
                comm.CommandText = "select * from [Тип вершины] where Тип = '" + type + "'";
                SqlDataReader rdr = comm.ExecuteReader();
                
                if (rdr.HasRows)
                {
                    rdr.Read();
                    typeNode = rdr[0].ToString();
                }
                rdr.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
            finally
            {                
                conn.Close();                
            }            
            return typeNode;
        }

        private void newSection_Click(object sender, EventArgs e)
        {
            string typeNode = _typeNode("Новый раздел");
            string numTree = tree.Tag.ToString();
            TreeNode node;
            if (tree.Nodes == null)
            {
                node = null;
            }
            else
            {
                node = tree.SelectedNode;
            }
            insertNode(node, numTree, "Новый раздел", typeNode, "", true);
        }

        private void cpc_Click(object sender, EventArgs e)
        {
            string typeNode = _typeNode("Самостоятельная работа");
            string numTree = tree.Tag.ToString();
            TreeNode node;
            
            if (tree.Nodes == null)
            {
                node = null;
            }
            else
            {
                node = tree.SelectedNode;
            }
            insertNode(node, numTree, "Самостоятельная работа", typeNode, "", true);
        }

        private void insertTask(string name, string level, string max, string date, string parent, string path)
        {
            try
            {
                //вставляем в таблицу Вершина
                conn.Open();
                comm.CommandText = "insert into Задача (Название, Уровень, [Максимальный балл], [Срок сдачи], [№ вершины], Ссылка) Values ('" + name + "', '" + level + "', '" + max + " ', '" + date + "', '"+ parent +"', '"+ path +"')";
                comm.ExecuteNonQuery();                                                              
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
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
                node = tree.SelectedNode;

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
                            insertTask(Name, "", "", "", tree.SelectedNode.Tag.ToString(), path);
                        }
                        else
                        {
                            insertNode(tree.SelectedNode, tree.Tag.ToString(), Name, typeNode, path, true);
                        }
                    }
                    finally
                    {
                        tree.Update();
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
            loadTasks(tree.SelectedNode.Tag.ToString());
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

            if ((tree.Nodes.Count == 0) || (tree.SelectedNode == null))
            {
                newSection.Enabled = true;
                cpc.Enabled = false;
                doc.Enabled = false;
                task.Enabled = false;
                test.Enabled = false;
            }
            else
            {
                switch (indexType(tree.SelectedNode.Tag.ToString()))
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
            up.Enabled = (tree.SelectedNode != null
                            && tree.SelectedNode.PrevNode != null);

            down.Enabled = (tree.SelectedNode != null
                            && tree.SelectedNode.NextNode != null);
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
            try
            {
                conn.Open();
                comm.CommandText = "select * from Задача where [№ вершины] = '" + Id + "'";

                SqlDataReader rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    TreeNode task = new TreeNode();
                    task.Name = "Задача";
                    task.Text = rdr[1].ToString();
                    task.Tag = rdr[6].ToString();
                    task.ImageIndex = 1;
                    tree.SelectedNode.Nodes.Add(task);
                }
                rdr.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                conn.Close();                
            }
           
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
            name.Text = e.Node.Text;
            access.SelectedIndex = Convert.ToInt32(flag);
            
            switch (e.Node.Name.ToString())
            {
                case "Задача":
                    {
                        rb.LoadFile(Application.StartupPath + e.Node.Tag.ToString());
                        tabControl1.SelectedTab = textData;
                    }; break;
                case "Самостоятельная работа":
                    {
                        e.Node.Nodes.Clear();
                        loadTasks(e.Node.Tag.ToString());
                        loadInf(e.Node.Tag.ToString(),true);
                        e.Node.Expand();
                        tabControl1.SelectedTab = list;
                    }; break;
                case "Тест":
                    {
                        loadInf(e.Node.Tag.ToString(), false);
                        loadTest(e.Node.Tag.ToString());
                        tabControl1.SelectedTab = list;
                    }; break;
                case "Новый раздел":
                    {
                        tabControl1.SelectedTab = property;                      
                    }; break;
                default:
                    {
                        try
                        {
                            conn.Open();
                            comm.CommandText = "select Ссылка from Вершина where [№ вершины] = '" + e.Node.Tag.ToString() + "'";
                            SqlDataReader rdr = comm.ExecuteReader();
                            rdr.Read();
                            rb.LoadFile(Application.StartupPath + rdr[0].ToString());
                            rdr.Close();
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.Message.ToString());
                        }
                        finally
                        {                            
                            conn.Close();
                        }
                    }; break;
            }
            tree.SelectedImageIndex = tree.SelectedNode.ImageIndex;                                                                       
        }

        private void loadInf(string id, bool flag)
        {
            try
            {
                conn.Open();
                if (flag)
                {
                    comm.CommandText = "select [Сколько каждому], Уровень, [Максимальный балл], [Срок сдачи] from Вершина where [№ вершины] = '" + tree.SelectedNode.Tag.ToString() + "'";
                    name.Enabled = true;
                    textBox1.Enabled = true;
                    SqlDataReader rdr = comm.ExecuteReader();
                    rdr.Read();
                    name.Text = rdr[0].ToString();
                    textBox1.Text = rdr[1].ToString();
                    textBox2.Text = rdr[2].ToString();
                    rdr.Close();
                }
                else
                {
                    comm.CommandText = "select [Максимальный балл], [Срок сдачи] from Тест where [№ вершины] = '" + tree.SelectedNode.Tag.ToString() + "'";
                    name.Enabled = false;
                    textBox1.Enabled = false;
                    SqlDataReader rdr = comm.ExecuteReader();
                    rdr.Read();
                    name.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = rdr[0].ToString();
                    rdr.Close();
                }
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

        private void loadTest(string id)
        {
           
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            //tree.SelectedNode.Text = name.Text;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            TreeNode node = tree.SelectedNode.Parent;
            string id = tree.SelectedNode.Tag.ToString();
            try
            {                
                conn.Open();      
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
                    comm.CommandText = "delete from Вершина where [№ вершины]=" + mas[j].ToString() + "";
                    comm.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
            finally
            {
                conn.Close();
                tree.SelectedNode.Remove();
                tree.SelectedNode = node;
            }
        }

        private void up_Click(object sender, EventArgs e)
        {
            if (tree.SelectedNode != null
                && tree.SelectedNode.PrevNode != null)
            {
                TreeNodeCollection editNodes;
                if (tree.SelectedNode.Parent != null)
                    editNodes = tree.SelectedNode.Parent.Nodes;
                else
                    editNodes = tree.Nodes;

                int indexSelectedNode = tree.SelectedNode.Index;
                int indexPreviousNode = tree.SelectedNode.PrevNode.Index;

                TreeNode selectedNode = tree.SelectedNode;

                editNodes.RemoveAt(indexSelectedNode);
                editNodes.Insert(indexPreviousNode, selectedNode);

                tree.SelectedNode = selectedNode;
            }
        }

        private void down_Click(object sender, EventArgs e)
        {
            if (tree.SelectedNode != null
                && tree.SelectedNode.NextNode != null)
            {
                TreeNodeCollection editNodes;
                if (tree.SelectedNode.Parent != null)
                    editNodes = tree.SelectedNode.Parent.Nodes;
                else
                    editNodes = tree.Nodes;

                int indexSelectedNode = tree.SelectedNode.Index;
                int indexNextNode = tree.SelectedNode.NextNode.Index;

                TreeNode selectedNode = tree.SelectedNode;

                editNodes.RemoveAt(indexSelectedNode);
                editNodes.Insert(indexNextNode, selectedNode);

                tree.SelectedNode = selectedNode;
            }
        }

        private void name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    conn.Open();
                    comm.CommandText = "update Вершина set Текст = '" + name.Text + "' where [№ вершины] = '" + tree.SelectedNode.Tag.ToString() + "'";
                    comm.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message.ToString());
                }
                finally
                {
                    conn.Close();
                    tree.Focus();
                }                                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                //conn = new SqlConnection(connectionString);
                //conn.Open();
                //SqlCommand comm = new SqlCommand();
                //comm.Connection = conn;
                //if (tree.SelectedNode.Name == "Самостоятельная работа")
                //{
                //    if ((textBox1.Text != "") && (name.Text != ""))
                //    {
                //        comm.CommandText = "update Вершина set [Сколько каждому] = '" + name.Text + "', Уровень = '" + textBox1.Text + "', [Максимальный балл] = '" + textBox2.Text + "', [Срок сдачи] = '" + dateTimePicker1.Value.ToShortDateString() + "' where [№ вершины] = '" + tree.SelectedNode.Tag.ToString() + "'";
                //    }
                //    else
                //    {
                //        MessageBox.Show("Введите данные!");
                //    } 
                //}
                //else
                //{
                //    if (textBox2.Text != "") 
                //    {
                //        comm.CommandText = "update Тест set [Максимальный балл] = '" + textBox2.Text + "', [Срок сдачи] = '" + dateTimePicker1.Value.ToShortDateString() + "' where [№ вершины] = '" + tree.SelectedNode.Tag.ToString() + "'";
                //    }
                //    else
                //    {
                //        MessageBox.Show("Введите данные!");
                //    } 
                //}
                //comm.ExecuteNonQuery();
                //conn.Close();                                  
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuPrepod rf = new menuPrepod(numPrepod);
            rf.Show();
            this.Hide();
        }

        private void test_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = list;                                   
            listView1.Items.Clear();
            listView1.View = View.Tile;
            
            try
            {
                conn.Open();
                comm.CommandText = "select [№ теста], Название, Тема from Тест where [№ преподавателя] = '" + numPrepod + "'";

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

        private void access_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "update Вершина set Доступ = '" + access.SelectedIndex.ToString() + "' where [№ вершины] = '" + tree.SelectedNode.Tag.ToString() + "'";
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

        private void данныеДляПроверкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBlackBox dataBlackBox = new DataBlackBox();
            dataBlackBox.Show();
        }

        private void менюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newTree nT = new newTree(numPrepod);
            nT.Show();
        }

        private void открытьКурсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            tree.Visible = toolsTree.Visible = false;
            rb.Clear();            
            tree.Visible = false;            
            tabControl1.SelectedTab = list;
                        
            listView1.Items.Clear();
            listView1.View = View.Tile;

            try
            {
                conn.Open();
                comm.CommandText = "select [№ дерева], Название from Дерево where [№ преподавателя] = '" + numPrepod + "'";

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
                    lv.Tag = numTree;
                    listView1.Items.Add(lv);
                }
                rdr.Close();
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
    }
}
