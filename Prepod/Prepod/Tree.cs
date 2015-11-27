using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Xml;
using System.Data.SqlClient;
using System.Configuration;

namespace Prepod
{
    public partial class Tree : Form
    {
        SqlConnection conn;
        //string connectionString =
        //        "Data Source=(local);Initial Catalog=Education; user id = sa; password = 1";
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        
        int numPrepod;
        int numTree = 1;

        TreeView tree = new TreeView();
        public Tree(int _numPrepod)
        {
            InitializeComponent();
            numPrepod = _numPrepod;
        }

        int count = 0;

        private void Tree_Load(object sender, EventArgs e)
        {
            string numPredmet;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select Название, [№ предмета] from Дерево where Дерево.[№ дерева] ='" + numTree.ToString() + "'";
              
                SqlDataReader rdr = comm.ExecuteReader();
                rdr.Read();
                textBox4.Text = rdr[0].ToString();
                numPredmet = rdr[1].ToString();
                rdr.Close();

                comm.CommandText = "select Название from Предмет where Предмет.[№ предмета] = '" + numPredmet + "'";
                rdr = comm.ExecuteReader();
                rdr.Read();
                textBox5.Text = rdr[0].ToString();
                rdr.Close();

            }
            finally
            {
                conn.Close();
                
            }

        }
        private void Delete(string name)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand comm3 = new SqlCommand("select count (*) from Литература where Литература.Название ='" + name + "'", conn);
                SqlDataReader rdr3 = comm3.ExecuteReader();
                rdr3.Read();  
                if (rdr3[0].ToString() != "0")
                {
                    rdr3.Close();
                    SqlCommand comm = new SqlCommand("delete from Литература where Литература.Название ='" + name + "'", conn);                    
                    comm.ExecuteNonQuery();
                }
                
                
            }
            finally
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show("Удаление завершено");                
            }
        }

        List<TreeNode> checkedNodes = new List<TreeNode>();
        void removeSelectNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked == true)
                {
                    checkedNodes.Add(node);
                    Delete(node.Text);
                    
                }
                    
                else
                    removeSelectNodes(node.Nodes);
            }
            foreach (TreeNode checkedNode in checkedNodes)
            {
                nodes.Remove(checkedNode);                
            }
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            count = count + 1;
            treeView1.SelectedNode.Nodes.Add("Новая_" + count.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            removeSelectNodes(treeView1.Nodes);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null
                && treeView1.SelectedNode.PrevNode != null)
            {
                // define edit collection
                TreeNodeCollection editNodes;
                if (treeView1.SelectedNode.Parent != null)
                    editNodes = treeView1.SelectedNode.Parent.Nodes;
                else
                    editNodes = treeView1.Nodes;

                // define indexes
                int indexSelectedNode = treeView1.SelectedNode.Index;
                int indexPreviousNode = treeView1.SelectedNode.PrevNode.Index;

                // store node
                TreeNode selectedNode = treeView1.SelectedNode;

                // swap
                editNodes.RemoveAt(indexSelectedNode);
                editNodes.Insert(indexPreviousNode, selectedNode);

                // select node
                treeView1.SelectedNode = selectedNode;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null
                && treeView1.SelectedNode.NextNode != null)
            {
                // define edit collection
                TreeNodeCollection editNodes;
                if (treeView1.SelectedNode.Parent != null)
                    editNodes = treeView1.SelectedNode.Parent.Nodes;
                else
                    editNodes = treeView1.Nodes;

                // define indexes
                int indexSelectedNode = treeView1.SelectedNode.Index;
                int indexNextNode = treeView1.SelectedNode.NextNode.Index;

                // store node
                TreeNode selectedNode = treeView1.SelectedNode;

                // swap
                editNodes.RemoveAt(indexSelectedNode);
                editNodes.Insert(indexNextNode, selectedNode);

                // select node
                treeView1.SelectedNode = selectedNode;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null
                 && treeView1.SelectedNode.PrevNode != null)
            {

                // define edit collection
                TreeNodeCollection editNodes;
                if (treeView1.SelectedNode.Parent != null)
                    editNodes = treeView1.SelectedNode.Parent.Nodes;
                else
                    editNodes = treeView1.Nodes;

                // store node
                TreeNode selectedNode = treeView1.SelectedNode;
                TreeNode previousNode = selectedNode.PrevNode;

                // move node
                editNodes.Remove(selectedNode);
                previousNode.Nodes.Add(selectedNode);

                // select node
                treeView1.SelectedNode = selectedNode;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null
                && treeView1.SelectedNode.Parent != null)
            {

                // define edit collection
                TreeNodeCollection editNodes;
                if (treeView1.SelectedNode.Parent.Parent != null)
                    editNodes = treeView1.SelectedNode.Parent.Parent.Nodes;
                else
                    editNodes = treeView1.Nodes;

                // store node
                TreeNode selectedNode = treeView1.SelectedNode;

                // define indexes
                int indexSelectedNode = treeView1.SelectedNode.Index;
                int indexParentNode = treeView1.SelectedNode.Parent.Index;

                // move node
                treeView1.SelectedNode.Parent.Nodes.Remove(selectedNode);
                editNodes.Insert(indexParentNode + 1, selectedNode);

                // select node
                treeView1.SelectedNode = selectedNode;
            }
        }

        private void updateEnablingButtons()
        {
            up.Enabled = (treeView1.SelectedNode != null
                            && treeView1.SelectedNode.PrevNode != null);

            down.Enabled = (treeView1.SelectedNode != null
                            && treeView1.SelectedNode.NextNode != null);

            left.Enabled = (treeView1.SelectedNode != null
                            && treeView1.SelectedNode.Parent != null);

            right.Enabled = (treeView1.SelectedNode != null
                                    && treeView1.SelectedNode.PrevNode != null);
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            button7.Enabled = false;
            updateEnablingButtons();
            textBox1.Text = treeView1.SelectedNode.Text;
            textBox2.Text = treeView1.SelectedNode.Name;
            textBox3.Text = "";
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand comm3 = new SqlCommand("select count (*) from Литература where Литература.Название ='" + treeView1.SelectedNode.Text + "' and Литература.[Ссылка на файл] != ''", conn);
                SqlDataReader rdr3 = comm3.ExecuteReader();
                rdr3.Read();
                if (rdr3[0].ToString() != "0")
                {
                    rdr3.Close();
                    SqlCommand comm = new SqlCommand("select Литература.[Ссылка на файл] from Литература where Литература.Название ='" + treeView1.SelectedNode.Text + "'", conn);
                    SqlDataReader rdr = comm.ExecuteReader();
                    rdr.Read();
                    textBox3.Text = rdr.GetString(0);
                    rdr.Close();
                }
            }
            finally
            {
                conn.Close();                
            }
        }

        

// - - - - - - - Save Tree in XML - - - - - - - -  - - - - - - - - - - 
        XmlTextWriter writer;
        private void saveNode(TreeNode root, XmlTextWriter writer)
        {
            if (root == null)
            {
                // writer.WriteEndElement();
                return;
            }
            else
            {
                writer.WriteStartElement("Вершина");
                writer.WriteAttributeString("Имя", root.Text);
                saveNode(root.FirstNode, writer);
                writer.WriteEndElement();
            }
            // writer.WriteStartElement("Подвершина");
            saveNode(root.NextNode, writer);
        }
        private void button4_Click_1(object sender, EventArgs e)
        {

            string fileName = "example.xml";
            writer = new XmlTextWriter(fileName, Encoding.UTF8);
            //читабельность
            writer.Formatting = Formatting.Indented;
            //Начинаем документ
            writer.WriteStartDocument(); //Открываем документ
            writer.WriteStartElement("Дерево"); //Открываем основной тэг

            writer.WriteStartElement("Вершины");
            saveNode(treeView1.Nodes[0], writer);

            writer.WriteEndElement(); //Закрывем тэг вопросов
            writer.Close();
        }
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

// - - - - - - - - - - Load Tree from XML - - - - - - - - - - - - - - - - - - - - - -
        private void addTreeNode(XmlNode xmlNode, TreeNode treeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList xNodeList;
            if (xmlNode.HasChildNodes) //The current node has children
            {
                xNodeList = xmlNode.ChildNodes;
                for (int x = 0; x <= xNodeList.Count - 1; x++)
                //Loop through the child nodes
                {
                    xNode = xmlNode.ChildNodes[x];
                    treeNode.Nodes.Add(new TreeNode(xNode.Name));
                    tNode = treeNode.Nodes[x];
                    addTreeNode(xNode, tNode);
                }
            }
            else //No children, so add the outer xml (trimming off whitespace)
                treeNode.Text = xmlNode.OuterXml.Trim();
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            XmlTextReader reader = null;
            string fileName = "example.xml";
            try
            {                
                treeView1.BeginUpdate();
                reader = new XmlTextReader(fileName);
                TreeNode parentNode = null;
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "Вершина")
                        {
                            TreeNode newNode = new TreeNode();
                            bool isEmptyElement = reader.IsEmptyElement;
                            
                            int attributeCount = reader.AttributeCount;
                            if (attributeCount > 0)
                            {
                                for (int i = 0; i < attributeCount; i++)
                                {
                                    if (i == 0)
                                    {
                                        reader.MoveToAttribute(i);
                                        // SetAttributeValue(newNode, reader.Name, reader.Value);
                                        newNode.Text = reader.Value;
                                    }
                                    else
                                    {
                                        reader.MoveToAttribute(i);
                                        newNode.Tag = reader.Value;
                                    }

                                }
                            }
                            // add new node to Parent Node or TreeView
                            if (parentNode != null)
                                parentNode.Nodes.Add(newNode);
                            else
                                treeView1.Nodes.Add(newNode);

                            // making current node 'ParentNode' if its not empty
                            if (!isEmptyElement)
                            {
                                parentNode = newNode;
                            }
                        }
                    }
                    // moving up to in TreeView if end tag is encountered
                    else if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        if (reader.Name == "Вершина")
                        {
                            parentNode = parentNode.Parent;
                        }
                    }
                    else if (reader.NodeType == XmlNodeType.XmlDeclaration)
                    {
                        //Ignore Xml Declaration                    
                    }
                    else if (reader.NodeType == XmlNodeType.None)
                    {
                        return;
                    }
                    else if (reader.NodeType == XmlNodeType.Text)
                    {
                        parentNode.Nodes.Add(reader.Value);
                    }

                }
            }
            finally
            {
                // enabling redrawing of treeview after all nodes are added
                treeView1.EndUpdate();
                reader.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = checkBox1.Checked;
            button3.Enabled = checkBox1.Checked;
            checkBox2.Checked = false;
            button6.Enabled = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            textBox3.Enabled = checkBox1.Checked;
            button3.Enabled = checkBox1.Checked;
            button6.Enabled = checkBox2.Checked;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Insert()
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                if (textBox1.Text != "")
                {
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandText = "select count (*) from Литература where Литература.Название ='" + treeView1.SelectedNode.Text + "'";
                    SqlDataReader rdr = comm.ExecuteReader();
                    rdr.Read();
                   // string idGroup = rdr3[0].ToString();                    
                    string cmd;
                    string name ="";
                    if (checkBox3.Checked) name = "СРС";
                    if (checkBox4.Checked) name = "Литература";
                    if (rdr[0].ToString() != "0")
                    {                        
                        cmd = "update " + name + " set Название='" + textBox1.Text + "', [Ссылка на файл]='" + textBox3.Text + "' where Литература.Название = " + treeView1.SelectedNode.Text;
                    }
                    else
                    {
                        cmd = "Insert into " + name + " (Название, [Ссылка на файл], [№ дерева]) Values('" + textBox1.Text + "','" + textBox3.Text + "','" + numTree.ToString() + "')";
                    }
                    rdr.Close();
                    // ---- Вставка литературы                   
                    comm.CommandText = cmd;
                    comm.ExecuteNonQuery();                    
                }
                else
                {
                    MessageBox.Show("Введите данные о литературе");
                }
            }
            finally
            {
                conn.Close();
                System.Windows.Forms.MessageBox.Show("Добавление выполнено");
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Text = textBox1.Text;
            treeView1.SelectedNode.Name = textBox2.Text;
            Insert();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.FileName = "";
            OP.Filter = "TXT File (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf";
            OP.Title = "Открыть документ";
            if (OP.ShowDialog() != DialogResult.Cancel)
            {
                {
                    try
                    {
                        textBox3.Text = OP.SafeFileName;                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), ex.Source);
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            button7.Enabled = checkBox4.Checked;
            checkBox3.Checked = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            button7.Enabled = checkBox3.Checked;
            checkBox4.Checked = false;
        }
    }
}
