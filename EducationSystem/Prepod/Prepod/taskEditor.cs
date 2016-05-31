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
    public partial class taskEditor : Form
    {
        string mainPath = Application.StartupPath;
        string numPrepod;

        public Boolean load;
        public Boolean textChanged;
        public string fileName;

        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader rdr;
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        BindingSource bs = new BindingSource();
        SqlDataAdapter adapter;
        DataTable data = new DataTable();        
        public taskEditor(string numPrepod_)
        {
            InitializeComponent();
            numPrepod = numPrepod_;            

            conn = new SqlConnection(connectionString);
            comm = new SqlCommand();
            comm.Connection = conn;
            dgSettings(dg);
            loadTasks();
            loadInf();
            

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


        private void задачуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load = true;
            MessageBox.Show("Перед добавлением задач в базу, переместите файлы с задачами в соответствующую папку!");
            addTask at = new addTask(numPrepod);
            at.Show();
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

        private void loadTasks()
        {
            try
            {
                conn.Open();                
                comm.CommandText = "Select * from Задача where [№ преподавателя] = '"+ numPrepod +"'";

                adapter = new SqlDataAdapter(comm);
                data.Clear();
                adapter.Fill(data);
                bs.DataSource = data;
                dg.DataSource = bs;

                dg.Columns[0].Visible = false;
                dg.Columns[2].Visible = false;
                dg.Columns[3].Visible = false;
                dg.Columns[5].Visible = false;
                dg.ReadOnly = true;
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

        private void taskEditor_Activated(object sender, EventArgs e)
        {
            if (load)
            {
                loadTasks();
                loadInf();
                load = false;
            }  
                      
        }

        private void filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            bs.Filter = "Описание = '" + filter.Text + "'";
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
                MessageBox.Show(exc.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            return path;
        }

        private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (textChanged)
            {
                switch (MessageBox.Show(string.Concat("Сохранить изменение в файле ", fileName, "?"), "Редактор задач", MessageBoxButtons.YesNoCancel))
                {
                    case (DialogResult.Yes):
                        {
                            this.сохранитьToolStripMenuItem_Click(sender, e);
                            break;
                        }
                    case (DialogResult.Cancel):
                        {                            
                            break;
                        }
                    case (DialogResult.No):
                        {
                            dg[3, e.RowIndex].Selected = true;
                            string name = dg[3, e.RowIndex].Value.ToString();
                            fileName = getPrepodPath() + name;
                            richTextBox1.Clear();
                            richTextBox1.LoadFile(fileName, RichTextBoxStreamType.RichText);
                            richTextBox1.SelectAll();
                            richTextBox1.SelectionIndent = 30;
                            richTextBox1.SelectionHangingIndent = -20;
                            richTextBox1.SelectionRightIndent = 12;                            
                            textChanged = false;
                            break;
                        }
                }

            }
            else
            {
                dg[3, e.RowIndex].Selected = true;
                string name = dg[3, e.RowIndex].Value.ToString();
                fileName = getPrepodPath() + name;
                richTextBox1.Clear();
                richTextBox1.LoadFile(fileName, RichTextBoxStreamType.RichText);
                richTextBox1.SelectAll();
                richTextBox1.SelectionIndent = 30;
                richTextBox1.SelectionHangingIndent = -20;
                richTextBox1.SelectionRightIndent = 12;
                textChanged = false;
            }             
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dg.CurrentRow != null)
            {
                try
                {
                    conn.Open();
                    comm.Connection = conn;
                    string id = dg.CurrentRow.Cells[0].Value.ToString();
                    comm.CommandText = "Delete from Задача where [№ задачи] ='" + id + "'";
                    comm.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message.ToString());
                }
                finally
                {
                    conn.Close();
                    loadInf();
                    loadTasks();
                    richTextBox1.Clear();
                }
            }
        }

        private void taskEditor_Load(object sender, EventArgs e)
        {
            System.Drawing.Text.InstalledFontCollection fontList = new System.Drawing.Text.InstalledFontCollection();
            toolStripComboBoxFonts.ComboBox.DisplayMember = "Name";
            toolStripComboBoxFonts.Items.AddRange(fontList.Families);
            toolStripComboBoxFonts.SelectedItem = richTextBox1.SelectionFont.FontFamily;

            //toolStripComboBoxSizes.ComboBox.DisplayMember = "Size";
            for (float i = 8; i != 36; i = i + 2)
            {
                toolStripComboBoxSizes.Items.Add(i);
            }

            //toolStripComboBoxSizes.Items.Add(null);

            toolStripComboBoxSizes.SelectedItem = (float)12;

            //System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
            //foreach (FontFamily font in fonts.Families)
            //{
            //    if (font.Name.)
            //    {
            //        toolStripComboBoxFonts.Items.Add(font.Name);
            //    }
            //}
        }

        private void taskEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            menuPrepod mp = new menuPrepod(numPrepod);
            mp.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionIndent = 30;
            richTextBox1.SelectionHangingIndent = -20;
            richTextBox1.SelectionRightIndent = 12;
        }

        private void toolStripButtonAlignmentLeft_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            toolStripButtonAlignmentLeft.Checked = true;
            toolStripButtonAlignmentRight.Checked = false;
            toolStripButtonAlignmentCenter.Checked = false;
        }

        private void toolStripButtonAlignmentCenter_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            toolStripButtonAlignmentLeft.Checked = false;
            toolStripButtonAlignmentRight.Checked = false;
            toolStripButtonAlignmentCenter.Checked = true;
        }

        private void toolStripButtonAlignmentRight_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            toolStripButtonAlignmentLeft.Checked = false;
            toolStripButtonAlignmentRight.Checked = true;
            toolStripButtonAlignmentCenter.Checked = false;
        }

        private void toolStripComboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (toolStripComboBoxFonts.SelectedItem != null)
                {
                    var fontFamily = toolStripComboBoxFonts.SelectedItem as FontFamily;
                    richTextBox1.SelectionFont = new Font(fontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
                }
            }
            catch
            {
                //toolStripComboBoxFonts.SelectedItem = font;
                //richTextBox.SelectionFont = font;
            }
        }

        private void toolStripComboBoxSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxSizes.SelectedItem != null)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, (float)toolStripComboBoxSizes.SelectedItem, richTextBox1.SelectionFont.Style);
            }
        }

        private void toolStripComboBoxSizes_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        try
                        {
                            //toolStripComboBoxSizes.Items.Add(float.Parse(toolStripComboBoxSizes.Text));
                            toolStripComboBoxSizes.SelectedItem = float.Parse(toolStripComboBoxSizes.Text);
                            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, float.Parse(toolStripComboBoxSizes.Text));
                            //toolStripComboBoxSizes.Items.Remove();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Неверный формат!");
                            //throw;
                        }
                        break;
                    }
            }
        }

        private void toolStripButtonBold_Click(object sender, EventArgs e)
        {
            FontStyle FS = richTextBox1.SelectionFont.Style;
            if (!richTextBox1.SelectionFont.Bold)
            {
                FS = FS | FontStyle.Bold;
                toolStripButtonBold.Checked = true;
            }
            else
            {
                FS = FS & ~FontStyle.Bold;
                toolStripButtonBold.Checked = false;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, (float)toolStripComboBoxSizes.SelectedItem, FS);
        }

        private void toolStripButtonItalic_Click(object sender, EventArgs e)
        {
            FontStyle FS = richTextBox1.SelectionFont.Style;
            if (!richTextBox1.SelectionFont.Italic)
            {
                FS = FS | FontStyle.Italic;
                toolStripButtonItalic.Checked = true;
            }
            else
            {
                FS = FS & ~FontStyle.Italic;
                toolStripButtonItalic.Checked = false;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, (float)toolStripComboBoxSizes.SelectedItem, FS);
        }

        private void toolStripButtonUnderline_Click(object sender, EventArgs e)
        {
            FontStyle FS = richTextBox1.SelectionFont.Style;
            if (!richTextBox1.SelectionFont.Underline)
            {
                FS = FS | FontStyle.Underline;
                toolStripButtonUnderline.Checked = true;
            }
            else
            {
                FS = FS & ~FontStyle.Underline;
                toolStripButtonUnderline.Checked = false;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, (float)toolStripComboBoxSizes.SelectedItem, FS);
        }

        private void переносПоСловамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.WordWrap)
            {
                richTextBox1.WordWrap = false;
                переносПоСловамToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
            else
            {
                richTextBox1.WordWrap = true;
                переносПоСловамToolStripMenuItem.CheckState = CheckState.Checked;
            }
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog.ShowColor = false;

            fontDialog.Font = richTextBox1.SelectionFont;

            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.SelectionFont = fontDialog.Font;
                updatestyles();
            }
        }

        private void updatestyles()
        {

            if (richTextBox1.SelectionFont.Style == FontStyle.Bold)
            {
                toolStripButtonBold.Checked = true;
            }
            else
            {
                toolStripButtonBold.Checked = false;
            }

            if (richTextBox1.SelectionFont.Style == FontStyle.Italic)
            {
                toolStripButtonItalic.Checked = true;
            }
            else
            {
                toolStripButtonItalic.Checked = false;
            }

            if (richTextBox1.SelectionFont.Style == FontStyle.Underline)
            {
                toolStripButtonUnderline.Checked = true;
            }
            else
            {
                toolStripButtonUnderline.Checked = false;
            }
        }

        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.Color = richTextBox1.SelectionColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog.Color;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            textChanged = true;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textChanged = false;
            richTextBox1.SaveFile(fileName, RichTextBoxStreamType.PlainText);
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            switch (richTextBox1.SelectionAlignment)
            {
                case HorizontalAlignment.Left:
                    {
                        toolStripButtonAlignmentLeft.Checked = true;
                        toolStripButtonAlignmentRight.Checked = false;
                        toolStripButtonAlignmentCenter.Checked = false;
                        break;
                    }
                case HorizontalAlignment.Center:
                    {
                        toolStripButtonAlignmentLeft.Checked = false;
                        toolStripButtonAlignmentRight.Checked = false;
                        toolStripButtonAlignmentCenter.Checked = true;
                        break;
                    }
                case HorizontalAlignment.Right:
                    {
                        toolStripButtonAlignmentLeft.Checked = false;
                        toolStripButtonAlignmentRight.Checked = true;
                        toolStripButtonAlignmentCenter.Checked = false;
                        break;
                    }
            }
            if (richTextBox1.SelectionFont != null)
            {
                toolStripComboBoxSizes.SelectedItem = richTextBox1.SelectionFont.Size;
                toolStripComboBoxFonts.SelectedItem = richTextBox1.SelectionFont.FontFamily;
                updatestyles();                
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();  
        }
    }
}
