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
    public partial class editCPC : Form
    {
        string numTree;

        SqlConnection conn;
        //string connectionString =
        //        "Data Source=(local);Initial Catalog=Education; user id = sa; password = 1";
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;


        BindingSource bs = new BindingSource();
        SqlDataAdapter adapter;
        DataTable data = new DataTable();
        public editCPC(string _numTree)
        {
            InitializeComponent();
            numTree = _numTree;
        }


        public string _typeNode(string type)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select * from [Тип вершины] where Тип = '"+ type +"'";
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

        TreeNode newNode;
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
        private void selectCPC(string type)
        {

            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select [№ вершины], Текст from Вершина where [Тип вершины] = '"+ type +"' and [№ дерева] = '"+ numTree +"'";
            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {                
                newNode = new TreeNode(rdr[1].ToString());
                newNode.Tag = rdr[0].ToString();
                treeView1.Nodes.Add(newNode);
            }
            rdr.Close();
            conn.Close();
            //загрузка всех потомков
            loadNodes(treeView1.Nodes);
                       
        }



        private void editCPC_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            string typeNode = _typeNode("Самостоятельная работа");
            selectCPC(typeNode);
            
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

                string date = dateTimePicker1.Value.Day.ToString() + "." + dateTimePicker1.Value.Month.ToString() + "." + dateTimePicker1.Value.Year.ToString();

                comm.CommandText = "insert into Задача ([№ вершины], Название, Уровень, [Максимальный балл], [Срок сдачи], Ссылка) Values ('"+ node.Tag.ToString() +"', '"+ Name +"', '"+ textBox4.Text +"', '"+ textBox3.Text +"', '"+ date +"', '"+ path +"')";
                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }

        }


        private void Add_Click(object sender, EventArgs e)
        {
            if ((textBox3.Text != "") && (textBox4.Text != ""))
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "select Название, Уровень, [Максимальный балл], [Срок сдачи], Ссылка from Задача where [№ вершины] = '"+ treeView1.SelectedNode.Tag.ToString() +"'";

            SqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                string str1 = rdr[0].ToString();
                string str2 = rdr[1].ToString();
                string str3 = rdr[2].ToString();
                string str4 = rdr[3].ToString();
                string str5 = rdr[4].ToString();
                //ListViewItem item = new ListViewItem(new string[] { rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString() });
                ListViewItem item = new ListViewItem(new string[] { "dfgd", "dfg","ggg", "dd", "ddddd" });
                listView1.Items.Add(item);
            }          
            
        }
    }
}
