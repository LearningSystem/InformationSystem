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

namespace CreateTest_2._0
{
    public partial class AddPartTree : Form
    {
        TestCreate form;
        public AddPartTree(TestCreate _form)
        {
            InitializeComponent();
            form = _form;
        }

        private void AddPartTree_Load(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath;
        }

        public void Add(object sender,String fileName,EventArgs e)
        {
            treeView1.Nodes.Clear();
            XmlTextReader reader = null;
            //string fileName = "example.xml";

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

        private void button1_Click(object sender, EventArgs e)
        {
            TreeNodeCollection collect = treeView1.Nodes;
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                Add(sender, openFileDialog1.FileName, e);
            }
        }
    }
}
