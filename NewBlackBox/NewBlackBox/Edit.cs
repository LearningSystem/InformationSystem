using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NewBlackBox
{
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
            toolStripButton5.Enabled = false;
            toolStripButton5.Visible = false;
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            LoadExercise();
            //splitContainer1.Panel2Collapsed = true;
        }
        public void LoadExercise()
        {
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\Exercises\\");
            foreach (FileInfo file in dir.GetFiles("*.rtf"))
            {
                //MessageBox.Show(dir.GetFiles("*.rtf").Max().ToString());
                int oneIndex = file.FullName.IndexOf(".");
                string temp = file.FullName.Remove(oneIndex, 4);
                int IndexTwo = temp.LastIndexOf("\\");
                temp = temp.Remove(0, IndexTwo + 1);
                int one = Int32.Parse(temp);
                int index = tV.Nodes.Add("Задача № " + one.ToString()).Index;
                tV.Nodes[index].Tag = one.ToString();
                try
                {
                    dir = new DirectoryInfo(Application.StartupPath + "\\Tests\\" + tV.Nodes[index].Tag.ToString());
                    foreach (FileInfo files in dir.GetFiles("*.txt"))
                    {
                        oneIndex = files.FullName.IndexOf(".");
                        temp = files.FullName.Remove(oneIndex, 4);
                        IndexTwo = temp.LastIndexOf("\\");
                        temp = temp.Remove(0, IndexTwo + 1);
                        one = Int32.Parse(temp);
                        //index = lstTests.Items.Add("Тест № " + one).Index;
                        //testsNum[index] = one.ToString();
                        int newindex = tV.Nodes[index].Nodes.Add("Тест № " + one).Index;
                        tV.Nodes[index].Nodes[newindex].Tag = one.ToString();
                    }
                }
                catch(Exception ex)
                {
                }
                //lstExer.Items[index].Tag = one.ToString();
                //numberExer[index] = one.ToString();
                //lstExer.Items[index].
            }
        }

        private void tV_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            splitContainer1.Panel2Collapsed = false;
            if (tV.SelectedNode.Text.IndexOf("Задача") == -1)
            {
                //DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\Tests\\" + tV.SelectedNode.Parent.Tag+"\\");
                rTB.Text = File.ReadAllText(Application.StartupPath + "\\Tests\\" + tV.SelectedNode.Parent.Tag + "\\" + tV.SelectedNode.Tag.ToString() + ".txt");

            }
            else
            {
                //rTB.Text = File.ReadAllText(Application.StartupPath + "\\Tests\\" + tV.SelectedNode.Parent.Tag + "\\" + tV.SelectedNode.Tag.ToString() + ".rtf");
                rTB.LoadFile(Application.StartupPath + "\\Exercises\\" + tV.SelectedNode.Tag.ToString() + ".rtf");
                //rTB.Text = File.ReadAllText(Application.StartupPath + "\\Exercises\\" + tV.SelectedNode.Tag.ToString() + ".rtf");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AddExercise adexer = new AddExercise("Exercise", true);
            adexer.Show();
            toolStripButton5.Visible = true;
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = false;
            toolStripButton4.Enabled = false;
            tV.Enabled = false;
            toolStripButton5.Enabled = true;
            rTB.Enabled = false;
            toolStripButton1.Enabled = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            AddExercise adexer = new AddExercise("Tests", true);
            adexer.Show();
            toolStripButton5.Visible = true;
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = false;
            toolStripButton4.Enabled = false;
            tV.Enabled = false;
            toolStripButton5.Enabled = true;
            rTB.Enabled = false;
            toolStripButton1.Enabled = false;
        }

        private void tV_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //splitContainer1.Panel2Collapsed = false;
            //if (tV.SelectedNode.Text.IndexOf("Задача") == -1)
            //{
            //    MessageBox.Show(Application.StartupPath + "\\Tests\\" + tV.SelectedNode.Parent.Tag + "\\" + tV.SelectedNode.Tag.ToString() + ".rtf");
            //    //DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\Tests\\" + tV.SelectedNode.Parent.Tag+"\\");
            //    rTB.Text = File.ReadAllText(Application.StartupPath + "\\Tests\\" + tV.SelectedNode.Parent.Tag + "\\" + tV.SelectedNode.Tag.ToString() + ".rtf");

            //}
            //else
            //{
            //    MessageBox.Show(Application.StartupPath + "\\Exercises\\" + tV.SelectedNode.Tag.ToString() + ".rtf");
            //    //rTB.Text = File.ReadAllText(Application.StartupPath + "\\Tests\\" + tV.SelectedNode.Parent.Tag + "\\" + tV.SelectedNode.Tag.ToString() + ".rtf");
            //    rTB.Text = File.ReadAllText(Application.StartupPath + "\\Exercises\\" + tV.SelectedNode.Tag.ToString() + ".rtf");
            //}
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (tV.SelectedNode != null)
            {
                if (tV.SelectedNode.Text.IndexOf("Задача") == -1)
                {

                    if (MessageBox.Show("Вы уверены, что хотите удалить Тест № " + tV.SelectedNode.Tag + "?", "Удаление теста", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        File.Delete(Application.StartupPath + "\\Tests\\" + tV.SelectedNode.Parent.Tag + "\\" + tV.SelectedNode.Tag.ToString() + ".txt");
                        MessageBox.Show("Успешно удалено!", "Удаление теста");
                        tV.Nodes.Clear();
                        rTB.Text = "";
                        LoadExercise();
                    }
                }
                else
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить Задача № " + tV.SelectedNode.Tag + "?", "Удаление задачи", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        File.Delete(Application.StartupPath + "\\Exercises\\" + tV.SelectedNode.Tag.ToString() + ".rtf");
                        //DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\Tests\\" + tV.SelectedNode.Tag.ToString());
                        if (Directory.Exists(Application.StartupPath + "\\Tests\\" + tV.SelectedNode.Tag.ToString()))
                        {
                            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\Tests\\" + tV.SelectedNode.Tag.ToString());
                            foreach (FileInfo file in dir.GetFiles("*.txt"))
                            {
                                file.Delete();
                            }
                            Directory.Delete(Application.StartupPath + "\\Tests\\" + tV.SelectedNode.Tag.ToString());
                            MessageBox.Show("Успешно удалено!", "Удаление задачи");
                            tV.Nodes.Clear();
                            rTB.Text = "";
                            LoadExercise();
                        }
                        else
                        {
                            MessageBox.Show("Успешно удалено!", "Удаление задачи");
                            tV.Nodes.Clear();
                            rTB.Text = "";
                            LoadExercise();
                        }
                    }
                }
            }else
            {
                //----
               //вставить если несколько
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            toolStripButton5.Visible = false;
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = true;
            toolStripButton4.Enabled = true;
            tV.Enabled = true;
            toolStripButton5.Enabled = false;
            rTB.Enabled = true;
            toolStripButton1.Enabled = true;
            tV.Nodes.Clear();
            LoadExercise();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (tV.SelectedNode.Text.IndexOf("Задача") == -1)
            {
                File.WriteAllText(Application.StartupPath + "\\Tests\\" + tV.SelectedNode.Parent.Tag + "\\" + tV.SelectedNode.Tag.ToString() + ".txt", rTB.Text);
            }
            else
            {
                //File.WriteAllText(Application.StartupPath + "\\Exercises\\" + tV.SelectedNode.Tag.ToString() + ".rtf", rTB.Text);
                rTB.SaveFile(Application.StartupPath + "\\Exercises\\" + tV.SelectedNode.Tag.ToString() + ".rtf");
            }
            MessageBox.Show("Сохранено успешно!", "Сохранение");
        }

        private void Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            MainPrepod mp = new MainPrepod();
            mp.Show();

        }

    }
}