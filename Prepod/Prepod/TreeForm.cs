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
using System.IO;
using System.Configuration;

namespace Prepod
{
    public partial class TreeForm : Form
    {
        SqlConnection conn;
        //string connectionString =
        //        "Data Source=(local);Initial Catalog=Education; user id = sa; password = 1";
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;


        SqlDataAdapter adapter;
        DataTable data = new DataTable();
        TreeNode newNode;
     
        string numTree = "1";
        string numPrepod = "1";

        

        public TreeForm()
        {
            InitializeComponent();
           
        }

        


        private void button1_Click(object sender, EventArgs e)
        {
            string cmd="";
            try
            {                               
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "insert into Вершина ([№ дерева], Текст, [Тип вершины], Ссылка) Values ('"+ numTree +"', 'Новая', '3', '')";
                comm.ExecuteNonQuery();

                comm.CommandText = "select SCOPE_IDENTITY()";
                SqlDataReader rdr = comm.ExecuteReader();
                rdr.Read();
                string num;                
                if (rdr.HasRows)
                {
                    num =  rdr[0].ToString();
                    if (treeView1.SelectedNode == null)
                    {
                        treeView1.Nodes.Add("Новая").Tag = rdr[0].ToString();
                        cmd = "INSERT INTO Связи ([№ вершины], [№ потомка], Уровень) select " + num + "," + num + ",0 UNION ALL select " + num + ", 0 ,0";
                        treeView1.Select();
                    }
                    else
                    {
                        string head = treeView1.SelectedNode.Tag.ToString();
                        treeView1.SelectedNode.Nodes.Add("Новая").Tag = rdr[0].ToString();
                        cmd = "INSERT INTO Связи ([№ вершины], [№ потомка], Уровень) SELECT [№ вершины], "+ num +", Уровень+1 FROM Связи WHERE [№ потомка] = "+ head +" UNION ALL select "+num+", "+num+", 0";
                    }
                }                
                rdr.Close();
                comm.CommandText = cmd;
                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show("Добавление выполнено");
            }
            
            
        }

        private void Delete_Click(object sender, EventArgs e)
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
                for (int j = 1; j<i; j++)
                {
                    comm.CommandText = "delete from Вершина where [№ вершины]="+ mas[j].ToString() +"";
                    comm.ExecuteNonQuery();
                }
            }
            finally
            {
                conn.Close();
                treeView1.SelectedNode.Remove();
                System.Windows.Forms.MessageBox.Show("Удаление выполнено");
                treeView1.SelectedNode = node;
            }
            
        }

        private void TreeForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Today;
            button5.Enabled = false;
            if (comboBox1.Text == "")
            {
                Add.Enabled = false;
                Delete.Enabled = false;
                Up.Enabled = false;
                Down.Enabled = false;               
            };
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;

            comm.CommandText = "Select [№ дерева], Название from Дерево where [№ преподавателя] = '" + numPrepod + "'";
            comboBox1.Items.Clear();
            SqlDataReader rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    comboBox1.Items.Add(rdr[1]);
                    
                }
            }
            rdr.Close();

            comm.CommandText = "Select * from [Тип вершины]";
            comboBox2.Items.Clear();
            rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    comboBox2.Items.Add(rdr[1]);
                }
            }
            rdr.Close();           

            conn.Close();            
        }

        private void Up_Click(object sender, EventArgs e)
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

        private void Down_Click(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            
        }

        
        private void loadNodes(TreeNodeCollection nodes)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;

            foreach (TreeNode node in nodes)
            {
                //считываем всех потомков на первом уровне  
                comm.CommandText = "SELECT Вершина.[№ вершины], Текст FROM Вершина JOIN Связи ON (Вершина.[№ вершины] = Связи.[№ потомка]) WHERE (Связи.[№ вершины] = " + node.Tag + ") AND (Связи.Уровень = 1) and (Вершина.[№ дерева] = " + numTree + ") and (Связи.[№ вершины] <> Связи.[№ потомка])";
                SqlDataReader rdr = comm.ExecuteReader();
                rdr.Read();

                if (rdr.HasRows)
                {
                    do
                    {
                        newNode = new TreeNode(rdr[1].ToString());
                        newNode.Tag = rdr[0].ToString();
                        node.Nodes.Add(newNode);
                        //treeView1.SelectedNode.Nodes.Add(rdr[1].ToString()).Tag = rdr[0].ToString();
                        //treeView1.Update();                        
                        
                    } while (rdr.Read());
                }
                rdr.Close();
                loadNodes(node.Nodes);
            }                                  
            conn.Close(); 
        }

        private void LoadTree()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            //загружаем корневую вершину
            comm.CommandText = "select Вершина.[№ вершины], Текст from Вершина where Вершина.[№ вершины] in  (select Связи.[№ вершины] from Связи where [№ потомка] = 0) and [№ дерева] = "+ numTree +"";
            SqlDataReader rdr = comm.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                string root = rdr[0].ToString();
                if (treeView1.SelectedNode == null)
                {
                    newNode = new TreeNode(rdr[1].ToString());
                    newNode.Tag = rdr[0].ToString();
                    treeView1.Nodes.Add(newNode);
                    treeView1.Update();
                    treeView1.Select();
                }                
                //загрузка всех потомков
                loadNodes(treeView1.Nodes);
            };
            rdr.Close();
            conn.Close();            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {       
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;

            comm.CommandText = "select [№ дерева], Название, [№ предмета] from Дерево where Название = '"+ comboBox1.Text +"'";
            SqlDataReader rdr = comm.ExecuteReader();
            rdr.Read();
            numTree = rdr[0].ToString();
            label2.Text = "Название дерева: " + rdr[1].ToString();
            string numPredmet = rdr[2].ToString();
            rdr.Close();

            comm.CommandText = "select Название from Предмет where [№ предмета] = '" + numPredmet + "'";
            rdr = comm.ExecuteReader();
            rdr.Read();
            label3.Text = "Предмет: " + rdr[0].ToString();
            rdr.Close();

            treeView1.Nodes.Clear();
            LoadTree(); //загружаем дерево
           
            conn.Close();
            if (comboBox1.Text != "")
            {
                Add.Enabled = true;
                Delete.Enabled = true;
                Up.Enabled = true;
                Down.Enabled = true;              
            };
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            newTree nT = new newTree(numPrepod);
            nT.Show();

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textBox1.Text = treeView1.SelectedNode.Text;

            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "Select Тип from [Тип вершины], Вершина where [№ вершины] = '"+ treeView1.SelectedNode.Tag +"' and Вершина.[Тип вершины] = [Тип вершины].Код";           
            SqlDataReader rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();                
                comboBox2.Text = rdr[0].ToString();  
                if (comboBox2.Text == "Самостоятельная работа")
                {
                    button5.Enabled = true;
                }
                else { button5.Enabled = false; }
            }
            else
            {
                comboBox2.Text = "";

            }
            rdr.Close();

            comm.CommandText = "select Ссылка from Вершина where [№ вершины] = '"+ treeView1.SelectedNode.Tag.ToString() +"'";
            rdr = comm.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                label8.Text = rdr[0].ToString();
            }
            else 
            {
                label8.Text = "Нет файла";
            }

            conn.Close();           
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {          
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;

            comm.CommandText = "select * from [Тип вершины] where Тип = '"+ comboBox2.Text +"'";
            SqlDataReader rdr = comm.ExecuteReader();
            rdr.Read();
            string typeNode = rdr[0].ToString();
            rdr.Close();

            comm.CommandText = "update Вершина set  Текст = '" + textBox1.Text + "',[Тип вершины] = '"+ typeNode +"', Ссылка = '"+ Puth +"' where [№ вершины] = '" + treeView1.SelectedNode.Tag + "'";
            comm.ExecuteNonQuery();          

            conn.Close();
            treeView1.SelectedNode.Text = textBox1.Text;           
        }


        private void updateNode(string puth, string num)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                if (label8.Text != "")
                {                    
                    comm.CommandText = "update Вершина set Ссылка = '" + puth + "' where [№ вершины] = '" + num + "'";

                    comm.ExecuteNonQuery();
                }
                else
                {                   
                    comm.CommandText = "insert into Вершина (Ссылка) Values ('" + puth + "') where [№ вершины] = '" + num + "'";

                    comm.ExecuteNonQuery();
                }
            }
            finally
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show("Добавление выполнено");
            }
        }

        string Puth = "";
        string Id = "";
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.FileName = "";
            OP.InitialDirectory = Application.StartupPath;
            OP.Filter = "RTF Files (*.rtf)|*.rtf";
            OP.Title = "Открыть документ";
            if (OP.ShowDialog() != DialogResult.Cancel)
            {
                {
                    try
                    {
                        string puth = OP.FileName.Remove(0, OP.InitialDirectory.Length);
                        label8.Text = OP.SafeFileName.Remove(OP.SafeFileName.Length - 4, 4);
                        Puth = puth;
                        Id = treeView1.SelectedNode.Tag.ToString();
                       // updateNode(puth, treeView1.SelectedNode.Tag.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), ex.Source);
                    }
                }
            }
        }

        private void insertNode(string Name, string path, TreeNode node, TreeNode child)
        {
            string cmd = "";
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;                

                string typeNode = "";
                comm.CommandText = "select * from [Тип вершины] where Тип = 'Задача'";
                SqlDataReader rdr = comm.ExecuteReader();
                               
                rdr.Read();
                if (rdr.HasRows)
                {
                    typeNode = rdr[0].ToString();
                }
                rdr.Close();

                string date = dateTimePicker1.Value.Day.ToString() +"." + dateTimePicker1.Value.Month.ToString() +"." + dateTimePicker1.Value.Year.ToString();
                comm.CommandText = "insert into Вершина ([№ дерева], Текст, [Тип вершины], Ссылка, [Максимальный балл], Уровень, [Срок сдачи]) Values ('" + numTree + "', '" + Name + "', '" + typeNode + "', '" + path + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" +  date + "')";
                comm.ExecuteNonQuery();

                comm.CommandText = "select SCOPE_IDENTITY()";
                rdr = comm.ExecuteReader();
                rdr.Read();                
                if (rdr.HasRows)
                {
                    child.Tag = rdr[0].ToString();
                    node.Nodes.Add(child);
                    cmd = "INSERT INTO Связи ([№ вершины], [№ потомка], Уровень) SELECT [№ вершины], " + child.Tag.ToString() + ", Уровень+1 FROM Связи WHERE [№ потомка] = " + node.Tag.ToString() + " UNION ALL select " + child.Tag.ToString() + ", " + child.Tag.ToString() + ", 0";
                }
                rdr.Close();
                comm.CommandText = cmd;
                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }

        }


        private void button5_Click(object sender, EventArgs e)
        {
            if ((textBox3.Text != "") && (textBox4.Text != "") )
            {
                OpenFileDialog OP = new OpenFileDialog();
                OP.FileName = "";
                OP.InitialDirectory = Application.StartupPath;
                OP.Filter = "RTF Files (*.rtf)|*.rtf";
                OP.Title = "Добавить задачи";
                OP.Multiselect = true;
                if (OP.ShowDialog() != DialogResult.Cancel)
                {
                    TreeNode node = new TreeNode();
                    node = treeView1.SelectedNode;

                    foreach (String file in OP.FileNames)
                    {
                        try
                        {

                            string path = file.Remove(0, OP.InitialDirectory.Length);
                            string name = path.Remove(path.Length - 4, 4);
                            string Name = name.Remove(0, name.LastIndexOf("\\") + 1);
                            newNode = new TreeNode(Name);
                            insertNode(Name, path, node, newNode);
                        }
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show(ex.ToString(), ex.Source);
                        //}
                        finally
                        {
                            treeView1.Update();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните информацию о задачах");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            editCPC f = new editCPC(numTree);
            f.Show();
        }


    }
}
