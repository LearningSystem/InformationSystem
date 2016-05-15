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
        SqlCommand comm;
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        string numStudent;
        string passStudent;
        string numTree;
        string numPrepod;
        string mainPath = Application.StartupPath;
        string puthXML;
        string numTask;
        string studentPath;
        string prepodPath;

        TreeNode newNode;
        TreeNode selectedNode;
        SqlDataAdapter adapter;
        DataTable data = new DataTable();

        OpenFileDialog ofd;

        List<int> tasks = new List<int>();
        string puthEXE = Application.StartupPath+"\\"+"Tests\\Tests\\bin\\Debug\\Tests.exe";
        bool find = false;
        public studentWork(string _numStudent,string _passStudent)
        {
            InitializeComponent();
            numStudent = _numStudent;
            passStudent = _passStudent;

            conn = new SqlConnection(connectionString);
            comm = new SqlCommand();
            comm.Connection = conn;

            loadInf(); 

            loadTask.Enabled = false;            
            groupBox4.Visible = false;                                                            
            rb.ReadOnly = true;

            tab.SelectedTab = textData;
        }
        string fio;
        private void loadInf()
        {            
            try
            {
                conn.Open();
                comm.CommandText = "Select * from Студент Where [№ студента] = '" + numStudent + "'";
                //считываем данные студента
                SqlDataReader rdr = comm.ExecuteReader();
                rdr.Read();
                name.Text = "";
                name.Text = rdr[1].ToString() + " " + rdr[2].ToString() + " " + rdr[3].ToString();
                fio = name.Text;
                name.BackColor = Color.LawnGreen;
                string group = rdr[5].ToString();
                studentPath = rdr[6].ToString();

                rdr.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                conn.Close();
                label4.Text = "";
                label5.Text = "";
                label6.Text = "";
            }
        }

        private void выбратьКурсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rb.Visible = false;
            try
            {
                conn.Open();
                comm.CommandText = "select Дерево.[№ дерева], Дерево.[№ преподавателя] from Дерево, Группа, Студент where Дерево.[№ дерева] = Группа.[№ дерева] and Группа.[№ группы] = Студент.[№ группы] and [№ студента] = '" + numStudent + "'";
                SqlDataReader rdr = comm.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    numTree = rdr[0].ToString();
                    numPrepod = rdr[1].ToString();                    
                }else numTree = "";                
                rdr.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                conn.Close();
                if (numTree != "")
                {
                    LoadTree(numTree);
                    prepodPath = getPrepodPath();
                }                    
                else MessageBox.Show("Для Вас еще нет курса обучения! Обратитесь к преподавателю.");
            }            
            
            //loadInf();
            //if (passStudent == "1")
            //{
            //    this.SendToBack();
            //    WarningPass chg = new WarningPass(numStudent,this);
            //    chg.ShowDialog();
            //    chg.BringToFront();
            //    //chg.Show();
            //}
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


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bool flag = dostup(tree.SelectedNode.Tag.ToString()); //считываем доступ                                             
            loadTask.Enabled = false;
            loadTask.BackColor = SystemColors.Control;
            groupBox4.Visible = false;
            rb.Clear();
            selectedNode = tree.SelectedNode;
            toolStrip3.Visible = false;
            if (flag)
            {
                switch (e.Node.Name.ToString())
                {
                    case "Самостоятельная работа":
                        {                            
                            openFileTask();
                            toolStrip3.Visible = true;
                        }; break;
                    case "Тест":
                        {
                            groupBox4.Visible = true;
                            loadTest(e.Node.Tag.ToString());
                        }; break;
                    case "Новый раздел":
                        {                            
                        }; break;
                    default:
                        {                                                        
                            openTextFile(e.Node.Tag.ToString());                            
                        }; break;
                }                
            }
            rb.Visible = true;
            tree.SelectedImageIndex = tree.SelectedNode.ImageIndex;
        }

        private void openFileTask()
        {
            string path = "";
            try
            {                
                conn.Open();                
                comm.CommandText = "select Задача.Название, Вершина.[Максимальный балл], Вершина.[Срок сдачи], Задача.Ссылка, Задача.[№ задачи] from Задача, [Выполненная задача], Вершина where Вершина.[№ вершины] = Задача.[№ вершины] and Задача.[№ задачи]=[Выполненная задача].[№ задачи] and Задача.[№ вершины]='" + tree.SelectedNode.Tag.ToString() + "' and [Выполненная задача].[№ студента] = '" + numStudent + "'";
                SqlDataReader rdr = comm.ExecuteReader();                
                if (rdr.HasRows)
                {
                    rdr.Read();                    
                    label4.Text = rdr[0].ToString();
                    label5.Text = rdr[1].ToString();
                    string date = rdr[2].ToString();
                    path = rdr[3].ToString();
                    if (date != "")
                        label6.Text = DateTime.Parse(date).ToShortDateString();
                    numTask = rdr[4].ToString();                                                            
                }
                else
                {
                    label4.Text = "";
                    label5.Text = "";
                    label6.Text = "";
                    MessageBox.Show("Для вас нет задачи по данной работе. Обратитесь к преподавателю.");
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
                if (path != "")
                {                    
                    string folder = prepodPath + path;
                    rb.LoadFile(folder);
                    tab.SelectedTab = textData;
                    proverka(numTask);
                }                
            }                      
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
                rb.LoadFile(prepodPath + name, RichTextBoxStreamType.RichText);                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
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
        
        private void loadTest(string id)
        {                  
            try
            {
                conn.Open();
                comm.CommandText = "select Название, Тема, [Максимальный балл], [Срок сдачи], Ссылка from Тест where [№ вершины] = '" + id + "'";

                SqlDataReader rdr = comm.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    puthXML = rdr[4].ToString(); // ссылка на xml
                    label4.Text = rdr[0].ToString();
                    label5.Text = rdr[2].ToString();
                    string date = rdr[4].ToString();
                    if (date != "")
                        label6.Text = DateTime.Parse(date).ToShortDateString();
                    groupBox4.Visible = true;
                    label8.Text = rdr[1].ToString();
                }
                else
                {
                    groupBox4.Visible = false;
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

        private void proverka(string numTask)
        {
            try
            {
                conn.Open();
                comm.CommandText = "select [Дата сдачи] from [Выполненная задача] where [№ задачи] = '" + numTask + "' and [№ студента] = '" + numStudent + "'";
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
                if (!File.Exists(prepodPath + studentPath + ofd.SafeFileName))
                {
                    pg.Visible = true;
                    bwStream.RunWorkerAsync();                    
                    string path = studentPath + ofd.SafeFileName;
                    insertTask(path, numTask);
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
            string path = prepodPath + studentPath + ofd.SafeFileName;            

            FileStream inputstream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
            FileStream outputstream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
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
            }
        }

        private void insertTask(string path, string numTask)
        {
            try
            {
                conn.Open();
                comm.CommandText = "update  [Выполненная задача] set [Ссылка на работу] = '" + path + "', [Дата сдачи]='" + DateTime.Today.ToShortDateString() + "' where [№ задачи] = '" + numTask + "' and [№ студента] = '" + numStudent + "'";
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

        private void bwStream_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pg.Value = e.ProgressPercentage;
        }

        private void успеваемостьToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            Estimates se = new Estimates(numPrepod, numTree);
            se.Show();
        }

        private void сменитьПарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePass chpass = new ChangePass(numStudent,this);
            chpass.Show();
        }

        #region Поиск в дереве
        
        public void Poisk(string NameRazdel)
        {
            find = false;
            TreeNodeCollection treecol = tree.Nodes;
            string RazdelName = NameRazdel;
            Poisk(treecol, RazdelName);
            if (find == false)
            {
                MessageBox.Show("Раздел не найден!");
                
            }
        }


        public void Poisk(TreeNodeCollection namenode, string FileNames)
        {

            foreach (TreeNode node in namenode)
            {
                if (node != null)
                {
                    if (node.Text == FileNames)
                    {
                        tree.SelectedNode = node;
                        //node.ForeColor = Color.Blue;
                        //tabControls.SelectedIndex = 0;
                        find = true;
                        //txtBoxVvod.Text = "";
                        break;
                    }
                    else
                    {
                        TreeNodeCollection nodeDir = node.Nodes;
                        Poisk(nodeDir, FileNames);
                    }
                }
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            TestStart goStart = new TestStart(Int32.Parse(numStudent), puthXML, this);
            this.Hide();
            goStart.Show();
        }

        private void textProg_Click(object sender, EventArgs e)
        {
            if (! loadTask.Enabled)
            {
                loadTextProg();
            }
        }

        private void loadTextProg()
        {            
            try
            {
                conn.Open();
                comm.CommandText = "select [Ссылка на работу] from [Выполненная задача] where [№ задачи] = '" + numTask + "' and [№ студента] = '" + numStudent + "'";
                SqlDataReader rdr = comm.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    string progPath = prepodPath + rdr[0].ToString();
                    rb.LoadFile(progPath, RichTextBoxStreamType.PlainText);
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

        private void textTask_Click(object sender, EventArgs e)
        {
            openFileTask();
        }
    }
}
