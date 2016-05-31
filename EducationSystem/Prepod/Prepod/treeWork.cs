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
    public partial class treeWork : Form
    {
        string mainPath = Application.StartupPath;
        SqlConnection conn;
        SqlCommand comm;
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        
        DataTable data = new DataTable();
        DataTable dataTask = new DataTable();
        DataTable dataGroup = new DataTable();
        TreeNode newNode;

        BindingSource bs = new BindingSource();

        string numPrepod = "";
        string numTree;
        public treeWork(string _numPrepod)
        {
            InitializeComponent();
            numPrepod = _numPrepod;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand();
            comm.Connection = conn;
            dgSettings(dg);
            //showGroup();
            loadGroups();
            toolStripButton4.Enabled = false;                                   
        }

        private void loadGroups()
        {
            try
            {
                conn.Open();
                comm.Connection = conn;
                comm.CommandText = "Select Название from Группа";                
                SqlDataReader rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    groups.Items.Add(rdr[0].ToString());
                }
                rdr.Close();
                groups.SelectedIndex = 0;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                conn.Close();                
                bs.DataSource = dataTask;                                              
            }
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

        private void showGroup(string id)
        {
            try
            {
                conn.Open();
                comm.Connection = conn;
                comm.CommandText = "Select * from [Варианты студентов] where [№ вершины] = '"+ id +"'";

                SqlDataAdapter adapter1 = new SqlDataAdapter(comm);
                dataTask.Clear();
                adapter1.Fill(dataTask);
                
                bs.DataSource = dataTask;
                dg.DataSource = bs.DataSource;
                if (groups.SelectedIndex == -1)
                    bs.Filter = null;
                else
                    this.groups.SelectedIndexChanged += new System.EventHandler(this.groups_SelectedIndexChanged);
                dg.Columns[3].Visible = false;
                dg.Columns[5].Visible = false;                
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
                        if ((rdr[3].ToString() == "Учебные материалы"))
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
                    rdr.Close();
                    loadNodes(tree.Nodes, numTree);
                };                
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
            string num = tree.SelectedNode.Tag.ToString();
            try
            {
                conn.Open();
                comm.CommandText = "Update Тест set [№ вершины] = '" + num + "' where [№ теста] = '" + listView1.SelectedItems[0].Tag.ToString() + "'";
                comm.ExecuteNonQuery();                        
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
            finally
            {
                conn.Close();
                loadTest(num);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (list.Text)
            {
                case "Задачи":
                    {
                        string path = getPrepodPath() + listView1.SelectedItems[0].Tag.ToString();
                        rb.LoadFile(path);
                        group.SelectedTab = textData;
                    }; break;
                case "Курс обучения":
                    {                        
                        tree.Nodes.Clear();
                        numTree = listView1.SelectedItems[0].Tag.ToString();
                        LoadTree(numTree);
                        tree.Tag = numTree;
                        tree.Visible = toolsTree.Visible = true;
                        group.SelectedTab = property;
                        splitContainer1.Panel1Collapsed = false;
                    }; break;
                case "Тесты":
                    {
                        //открытие редактора теста
                    }; break;
                case "Выберите тест":
                    {
                        insertTest(listView1.SelectedItems[0].Tag.ToString());
                    }; break;
                case "Выберите задачи":
                    {
                        this.okBtn.Click += new System.EventHandler(this.toolStripButton3_Click);
                        //insertTask(listView1.SelectedItems[0].Tag.ToString());
                    }; break;
            }
                      
            
        }

        private void insertNode(TreeNode node, string numTree, string Text, string type, string Path, bool flag, string name)
        {
            string cmd = "";
            try
            {
                //вставляем в таблицу Вершина
                conn.Open();
                comm.CommandText = "insert into Вершина ([№ дерева], Текст, [Тип вершины], Ссылка, Доступ, Имя) Values ('" + numTree + "', '" + Text + "', '" + type + "', '" + Path + "', '" + flag.ToString() + "', '" + name + "')";                                
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
                    rdr.Close();
                    conn.Close();

                    if (name == "Учебные материалы")
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
                else conn.Close();
                

                conn.Open();
                comm.CommandText = cmd;
                comm.ExecuteNonQuery();
                //if (Text == "Тест")
                //{
                //    comm.CommandText = "Update Тест set [№ вершины] = '" + num + "' where [№ теста] = '" + listView1.SelectedItems[0].Tag.ToString() + "'";
                //    comm.ExecuteNonQuery();

                //}
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.ToString());
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
            insertNode(node, numTree, "Новый раздел", typeNode, "", true, "Новый раздел");
        }

        private int countNode(string typeNode)
        {
            int count = 0;
            try
            {
                conn.Open();
                comm.CommandText = "select count(*) from Вершина, [Тип вершины] where [Тип вершины].Код = Вершина.[Тип вершины] and [Тип вершины].Тип = '"+ typeNode +"'";
                SqlDataReader rdr = comm.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    count = Convert.ToInt32(rdr[0]);
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
            return count;
        }

        string getNodePath(string id)
        {
            string path = "";
            try
            {
                conn.Open();
                comm.CommandText = "select Ссылка from Вершина where [№ вершины] = '" + id + "'";
                SqlDataReader rdr = comm.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    path = rdr[0].ToString();
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
            return path;
        }

        string getPrepodPath()
        {
            string path = mainPath;
            try
            {
                conn.Open();
                comm.CommandText = "select [Путь к папке] from Преподаватель where [№ преподавателя] = '" + numPrepod + "'";
                SqlDataReader rdr = comm.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    path = path + rdr[0].ToString();
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
            return path;
        }

        private void createFolder(string folderName)
        {
            DirectoryInfo drInfo = new DirectoryInfo(folderName);
            drInfo.Create();
        }

        private void cpc_Click(object sender, EventArgs e)
        {
            string typeNode = _typeNode("Самостоятельная работа");
            string text = "Самостоятельная работа";
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
            insertNode(node, numTree, text, typeNode, "", true, "Самостоятельная работа");            
        }

        private void insertTask(string id)
        {
            string num = tree.SelectedNode.Tag.ToString();
            try
            {
                //вставляем в таблицу Задача
                conn.Open();
                //comm.CommandText = "insert into Задача (Название, [№ вершины], Ссылка) Values ('" + name + "', '" + parent +"', '"+ path +"')";
                comm.CommandText = "Update Задача set [№ вершины] = '" + num + "' where [№ задачи] = '" + id + "'";
                comm.ExecuteNonQuery();                                                              
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            } 
            finally
            {
                conn.Close();
                afterSelect(tree.SelectedNode);
                              
            }
        }
        

        private void addFiles(string type, Boolean multiselect)
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.FileName = "";
            OP.InitialDirectory = getPrepodPath() + "Учебные материалы\\Теория\\";
            OP.Filter = "RTF Files (*.rtf)|*.rtf";
            OP.Title = "Добавить файлы";
            OP.Multiselect = multiselect;
            if (OP.ShowDialog() != DialogResult.Cancel)
            {
                TreeNode node = new TreeNode();
                node = tree.SelectedNode;
                
                foreach (String file in OP.SafeFileNames)
                {                                          
                    string name = file.Remove(file.Length - 4, 4);                        
                    string typeNode = _typeNode(type);
                    insertNode(tree.SelectedNode, tree.Tag.ToString(), name, typeNode, "Учебные материалы\\Теория\\" + file, true, "Учебные материалы");                        
                }
                
            }
        }

        private void учебныеМатериалыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addFiles("Учебные материалы", true);
        }

        private void loadInf()
        {
            try
            {
                conn.Open();
                comm.CommandText = "select distinct Описание from Задача where [№ преподавателя] = '" + numPrepod + "'";
                SqlDataReader rdr = comm.ExecuteReader();
                if (rdr.HasRows)
                {
                    filter.Items.Clear();
                    while (rdr.Read())
                    {
                        filter.Items.Add(rdr[0].ToString());
                    }
                    rdr.Close();
                }
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

        private void selectTasks(string commandText)
        {
            group.SelectedTab = list;
            list.Text = "Выберите задачи";
            listView1.Items.Clear();
            listView1.View = View.Tile;
            listView1.MultiSelect = true;

            try
            {
                conn.Open();
                comm.CommandText = commandText;
                
                SqlDataReader rdr = comm.ExecuteReader();

                //заполнение listView
                List<string> col = new List<string>();
                col.Add("№ задачи");
                col.Add("Название");
                col.Add("Описание");
                loadListView(col);

                ListViewItem lv = new ListViewItem();
                string tName = "";
                while (rdr.Read())
                {                    
                    tName = rdr[1].ToString();
                    string numTask = rdr[0].ToString();
                    string description = rdr[2].ToString();
                    lv = new ListViewItem(new string[] { numTask, tName, description }, 1);
                    lv.Name = tName;
                    lv.Tag = numTask;
                    
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

        private void задачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //addFiles("Задача", true);
            //loadTasks(tree.SelectedNode.Tag.ToString());
            //loadInf();
            //selectTasks("select [№ задачи], Название, Описание from Задача where [№ преподавателя] = '" + numPrepod + "'");
        }

        private string indexType(string Id)
        {
            string index = "";
            try
            {
                conn.Open();
                comm.CommandText = "select [Тип вершины] from Вершина where [№ вершины] = '" + Id + "'";
                SqlDataReader rdr = comm.ExecuteReader();                
                if (rdr.HasRows)
                {
                    rdr.Read();
                    index = rdr[0].ToString();
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
            return index;
        }

        private void addNode_Click(object sender, EventArgs e)
        {

            if ((tree.Nodes.Count == 0) || (tree.SelectedNode == null))
            {
                newSection.Enabled = true;
                cpc.Enabled = false;
                doc.Enabled = false;                
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
                            test.Enabled = false;
                        }; break;
                    case "1":
                        {
                            newSection.Enabled = false;
                            cpc.Enabled = false;
                            doc.Enabled = true;                            
                            test.Enabled = false;
                        }; break;
                    case "2":
                        {
                            newSection.Enabled = false;
                            cpc.Enabled = false;
                            doc.Enabled = false;                            
                            test.Enabled = false;
                        }; break;
                    case "3":
                        {
                            newSection.Enabled = true;
                            cpc.Enabled = true;
                            doc.Enabled = true;                            
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


        private void loadTasks(string Id)
        {
            group.SelectedTab = list;
            listView1.Items.Clear();
            listView1.View = View.Tile;
            list.Text = "Задачи";

            try
            {
                conn.Open();
                comm.CommandText = "select * from Задача  where [№ вершины] = '"+ Id +"'";

                SqlDataReader rdr = comm.ExecuteReader();

                //заполнение listView
                List<string> col = new List<string>();
                col.Add("№ задачи");
                col.Add("Название");
                col.Add("Описание");
                loadListView(col);

                ListViewItem lv = new ListViewItem();
                string tName = "";
                while (rdr.Read())
                {                    
                    tName = rdr[1].ToString();
                    string numTask = rdr[0].ToString();
                    string path = rdr[3].ToString();
                    string description = rdr[4].ToString();
                    
                    lv = new ListViewItem(new string[] { numTask, tName, description}, 1);
                    lv.Name = tName;
                    lv.Tag = path;                    
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

        private bool dostup(string id)
        {
            bool flag = false;
            try
            {
                conn.Open();
                comm.CommandText = "select Доступ from Вершина where [№ вершины] = '" + id + "'";
                SqlDataReader rdr = comm.ExecuteReader();
                rdr.Read();
                flag = (Convert.ToInt32(rdr[0]) == 1);
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
            return flag;
        }

        private void afterSelect(TreeNode node)
        {
            bool flag = dostup(node.Tag.ToString()); //считываем доступ            
            name.Text = node.Text;
            access.SelectedIndex = Convert.ToInt32(!flag);
            toolStripButton4.Enabled = false; //нельзя распределить варианты пока не встали на срс
            bs.Filter = null;
            back.Visible = false;

            switch (node.Name.ToString())
            {
                case "Самостоятельная работа":
                    {
                        toolStrip1.Visible = true;
                        toolStripButton4.Enabled = true;
                        groupBox4.Visible = true;
                        showGroup(node.Tag.ToString());
                        groups.SelectedIndex = -1;
                        loadTasks(node.Tag.ToString());
                        loadInf(node.Tag.ToString());
                        group.SelectedTab = listGroup;

                        filterBtn.Visible = addTestBtn.Visible = okBtn.Visible = false;
                        addTaskBtn.Visible = deleteTask.Visible = true;

                    }; break;
                case "Тест":
                    {
                        toolStrip1.Visible = true;
                        groupBox4.Visible = true;
                        loadInf(node.Tag.ToString());
                        loadTest(node.Tag.ToString());
                        group.SelectedTab = list;

                        filterBtn.Visible = okBtn.Visible = addTaskBtn.Visible = false;
                        addTestBtn.Visible = deleteTask.Visible = true;
                    }; break;
                case "Новый раздел":
                    {
                        groupBox4.Visible = false;
                        toolStrip1.Visible = false;
                        group.SelectedTab = property;
                    }; break;
                default:
                    {
                        groupBox4.Visible = false;
                        toolStrip1.Visible = false;
                        group.SelectedTab = textData;
                        openTextFile(node.Tag.ToString());

                    }; break;
            }
            tree.SelectedImageIndex = tree.SelectedNode.ImageIndex;
            rb.SelectAll();
            rb.SelectionIndent = 30;
            rb.SelectionHangingIndent = -20;
            rb.SelectionRightIndent = 12;                                                         
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            afterSelect(e.Node);
        }

        private void openTextFile(string id)
        {
            string name;
            try
            {
                conn.Open();
                comm.CommandText = "select Ссылка from Вершина where [№ вершины] = '" + id + "'";
                SqlDataReader rdr = comm.ExecuteReader();
                rdr.Read();
                name = rdr[0].ToString();                
                rdr.Close();
                conn.Close();
                rb.LoadFile(getPrepodPath() + name, RichTextBoxStreamType.RichText);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }            
        }

        private void loadInf(string id)
        {
            try
            {
                conn.Open();                
                comm.CommandText = "select [Максимальный балл], [Срок сдачи] from Вершина where [№ вершины] = '" + id + "'";
                name.Enabled = true;                    
                SqlDataReader rdr = comm.ExecuteReader();                                
                if (rdr.HasRows)
                {
                    rdr.Read();
                    maxBall.Text = rdr[0].ToString();
                    string date = rdr[1].ToString();
                    if (date != "")
                        dateTime.Value = DateTime.Parse(date);
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

        private void loadTest(string id)
        {
            group.SelectedTab = list;
            listView1.Items.Clear();
            listView1.View = View.Tile;
            list.Text = "Тесты";

            try
            {
                conn.Open();
                comm.CommandText = "select [№ теста], Название, Тема, Ссылка from Тест where [№ вершины] = '" + id + "'";

                SqlDataReader rdr = comm.ExecuteReader();

                //заполнение listView
                List<string> col = new List<string>();
                col.Add("№ теста");
                col.Add("Название");
                col.Add("Тема");
                loadListView(col);

                ListViewItem lv = new ListViewItem();
                string tName = "";
                while (rdr.Read())
                {
                    string theme = rdr[2].ToString();
                    tName = rdr[1].ToString();
                    string numTest = rdr[0].ToString();
                    lv = new ListViewItem(new string[] { numTest, tName, theme }, 1);
                    lv.Name = tName;
                    lv.Tag = numTest;
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

        private void name_TextChanged(object sender, EventArgs e)
        {
            //tree.SelectedNode.Text = name.Text;
        }

        private void deleteNode(string id)
        {
            SqlConnection conn1 = new SqlConnection(connectionString);
            SqlCommand comm1 = new SqlCommand();
            comm1.Connection = conn1; 
            try
            {
                conn1.Open();                
                comm1.CommandText = "delete from Вершина where [№ вершины]=" + id + "";
                comm1.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                conn1.Close();                
            }
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

                while (rdr.Read())
                {
                    deleteNode(rdr[0].ToString());                    
                }
                rdr.Close();
                //int[] mas = new int[100];
                //int i = 1;
                //while (rdr.Read())
                //{
                //    mas[i] = Convert.ToInt32(rdr[0]);
                //    i++;
                //}
                //rdr.Close();
                //comm.CommandText = "delete from Связи where [№ потомка] in (select Вершина.[№ вершины] from Вершина join Связи on (Вершина.[№ вершины] = Связи.[№ потомка]) where Связи.[№ вершины] = " + id + ") or Связи.[№ вершины] = " + id + "";
                //comm.ExecuteNonQuery();
                //for (int j = 1; j < i; j++)
                //{       
                //    comm.CommandText = "delete from Вершина where [№ вершины]=" + mas[j].ToString() + "";
                //    comm.ExecuteNonQuery();
                //}
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
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
                    tree.SelectedNode.Text = name.Text;
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
            string typeNode = _typeNode("Тест");
            string numTree = tree.Tag.ToString();
            string text = "Тест";
            TreeNode node;

            if (tree.Nodes == null)
            {
                node = null;
            }
            else
            {
                node = tree.SelectedNode;
            }
            insertNode(node, numTree, text, typeNode, "", true, "Тест");            
        }

        private void access_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool dostup = false;
            if (access.Text == "Доступна")
                dostup = true;            
            try
            {
                conn.Open();
                comm.CommandText = "update Вершина set Доступ = '" + dostup.ToString() + "' where [№ вершины] = '" + tree.SelectedNode.Tag.ToString() + "'";
                comm.ExecuteNonQuery();
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
            DataBlackBox dataBlackBox = new DataBlackBox(Convert.ToInt32(numPrepod));
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
            group.SelectedTab = list;
            toolStrip1.Visible = false;
                        
            listView1.Items.Clear();
            listView1.View = View.Tile;
            list.Text = "Курс обучения";

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

        private void filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string commandText = "select [№ задачи], Название, Описание from Задача where [№ преподавателя] = '" + numPrepod + "' and Описание = '" + filter.Text + "' and [№ вершины] is null and [№ задачи] in (select distinct [№ задачи] from Проверка)";
            selectTasks(commandText);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            loadInf();
            filterBtn.Visible = okBtn.Visible = back.Visible = true;
            addTaskBtn.Visible = deleteTask.Visible = addTestBtn.Visible = false;

            selectTasks("select [№ задачи], Название, Описание from Задача where [№ преподавателя] = '" + numPrepod + "' and [№ вершины] is null and [№ задачи] in (select distinct [№ задачи] from Проверка)");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            group.SelectedTab = list;
            okBtn.Visible = back.Visible = true;
            addTaskBtn.Visible = deleteTask.Visible = addTestBtn.Visible = filterBtn.Visible = false;

            listView1.Items.Clear();
            if (listView1.Items.Count > 0)
            {
                MessageBox.Show("Нельзя выбрать более одного теста!");
            }
            else
            {
                listView1.View = View.Tile;
                list.Text = "Выберите тест";
                listView1.MultiSelect = false;

                try
                {
                    conn.Open();
                    comm.CommandText = "select [№ теста], Название, Тема from Тест where [№ преподавателя] = '" + numPrepod + "'";

                    SqlDataReader rdr = comm.ExecuteReader();

                    //заполнение listView
                    List<string> col = new List<string>();
                    col.Add("№ теста");
                    col.Add("Название");
                    col.Add("Тема");
                    loadListView(col);

                    ListViewItem lv = new ListViewItem();
                    string tName = "";
                    while (rdr.Read())
                    {
                        string theme = rdr[2].ToString();
                        tName = rdr[1].ToString();
                        string numTest = rdr[0].ToString();
                        lv = new ListViewItem(new string[] { numTest, tName, theme }, 1);
                        lv.Name = tName;
                        lv.Tag = numTest;
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {                       
            foreach (ListViewItem item in listView1.SelectedItems)
            {                
                insertTask(item.Tag.ToString());
            }
            //listView1.SelectedItems[0].ToString();
        }

        private void tree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {

        }

        private void delTask(string id)
        {
            string num = tree.SelectedNode.Tag.ToString();
            try
            {
                //удаляем из таблицы задача
                conn.Open();                
                comm.CommandText = "Update Задача set [№ вершины] = NULL where [№ задачи] = '" + id + "'";
                comm.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                conn.Close();
                loadTasks(num);
            }
        }

        private void deleteTask_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                
                delTask(item.SubItems[0].Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string hhh = dateTime.Value.ToShortDateString();
                comm.CommandText = "update Вершина set [Максимальный балл] = '" + maxBall.Text + "', [Срок сдачи] = '"+ dateTime.Value.ToShortDateString() +"' where [№ вершины] = '" + tree.SelectedNode.Tag.ToString() + "'";
                comm.ExecuteNonQuery();
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
       

        

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            int countStud = 0;
            int countTask = 0;
            try
            {
                conn.Open();
                comm.CommandText = "select count(*) from Студент, Группа where Студент.[№ группы]=Группа.[№ группы] and Группа.Название ='" + groups.Text + "'";
                SqlDataReader rdr = comm.ExecuteReader();
                rdr.Read();
                countStud = Convert.ToInt32(rdr[0]); //количество студентов в группе
                rdr.Close();
                comm.CommandText = "select count(*) from Задача where [№ вершины] = '"+ tree.SelectedNode.Tag.ToString() +"'";
                rdr = comm.ExecuteReader();
                rdr.Read();
                countTask = Convert.ToInt32(rdr[0]);
                rdr.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
            finally
            {
                conn.Close();
                if (countStud * countTask != 0)
                    generate(countStud, countTask);
            } 
        }

        private void generate(int a, int b)
        {
            decimal k = a / b;
            int l = Convert.ToInt32(Math.Ceiling(k + 2));
            int[,] array = new int[l, b];
            try
            {
                conn.Open();                
                for (int m = 0; m < l; m++)
                    for (int n = 0; n < b; n++)
                        array[m, n] = 0;
                comm.CommandText = "select [№ задачи] from Задача where [№ вершины] = '" + tree.SelectedNode.Tag.ToString() + "'";
                SqlDataReader rdr = comm.ExecuteReader();
                int i = 0;
                while (rdr.Read())
                {
                    array[0, i] = Convert.ToInt32(rdr[0]);
                    i++;
                }
                rdr.Close();

                string id = tree.SelectedNode.Tag.ToString();
                comm.CommandText = "select Студент.[№ студента] from Студент, Группа where Студент.[№ студента] not in (select [Выполненная задача].[№ студента] from [Выполненная задача], Задача Where [Выполненная задача].[№ задачи] = Задача.[№ задачи] and Задача.[№ вершины] = '"+ id +"') and Студент.[№ группы]=Группа.[№ группы] and Группа.Название ='"+ groups.Text +"'";
                rdr = comm.ExecuteReader();
                Random rand = new Random();
                int j = 1;
                int count = 0;
                int num;
                while (rdr.Read())
                {
                    if (count > b) //если строка заполнилась
                        j++;
                    bool flag = true;
                    while (flag)
                    {
                        num = rand.Next(1, b);
                        if (array[j, num] == 0)
                        {
                            flag = false;
                            array[j, num] = Convert.ToInt32(rdr[0]);
                            SqlConnection conn1 = new SqlConnection(connectionString);
                            SqlCommand comm1 = new SqlCommand();
                            comm1.Connection = conn1;
                            conn1.Open();
                            comm1.CommandText = "insert into [Выполненная задача] ([№ задачи], [№ студента]) Values ('" + array[0, num].ToString() + "', '" + array[j, num].ToString() + "')";
                            comm1.ExecuteNonQuery();
                            conn1.Close();
                        }                            
                    }                    
                    count++;
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
                showGroup(tree.SelectedNode.Tag.ToString());                
            } 
        }

        private void groups_SelectedIndexChanged(object sender, EventArgs e)
        {
            bs.DataSource = dataTask;
            if ((tree.SelectedNode != null) && (tree.SelectedNode.Name == "Самостоятельная работа"))
                bs.Filter = "Группа = '" + groups.Text + "'";
            else
                bs.Filter = null;
        }

        private void открытьКурсToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Estimates se = new Estimates(numPrepod, numTree);
            se.Show();
        }

        private void back_Click(object sender, EventArgs e)
        {
            afterSelect(tree.SelectedNode);
            
        }   
    }
}
