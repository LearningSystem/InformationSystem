using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace Prepod
{
    public partial class AddPartTree : Form
    {
        TestCreate form;
        TreeNode newNode;
        string numTree = "";
        SqlConnection conn;
        SqlCommand comm;
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        string NumPrepod;
        public AddPartTree(TestCreate _form, string _numTeacher)
        {
            InitializeComponent();
            form = _form;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand();
            comm.Connection = conn;
            NumPrepod = _numTeacher;
        }

        private void AddPartTree_Load(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath;
            SelectNumTree(NumPrepod);
            LoadTree(numTree);
        }

        private void SelectNumTree(string _numprepod)
        {
            try
            {
                conn.Open();
                //загружаем корневую вершину
                comm.CommandText = "select [№ дерева] from [Дерево] where [№ преподавателя]='"+_numprepod+"'";
                SqlDataReader rdr = comm.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    numTree = rdr[0].ToString();
                    rdr.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            TreeNodeCollection collect = tree.Nodes;
            Poisk(collect);
            this.Hide();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        void Poisk(TreeNodeCollection Dir)
        {
            foreach (TreeNode node in Dir)
            {
                if (node != null)
                {
                    if (node.Checked==true)
                    {
                        form.lstViewIstochnik.Items.Add(node.Text);
                    }
                    else
                    {
                        TreeNodeCollection nodeDir = node.Nodes;
                        Poisk(nodeDir);
                    }
                }
            }
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
    }
}
