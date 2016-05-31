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
    public partial class GeneratorTwo : Form
    {
        string TextPon;
        SqlConnection sconn;
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        ListView lst;
        string NumShab;
        string NumPrepod;
        public GeneratorTwo(string _numshab,string _tekpon, ListView _lstitem,string _numprepod)
        {
            InitializeComponent();
            NumShab = _numshab;
            TextPon = _tekpon;
            lst = _lstitem;
            NumPrepod = _numprepod;
        }

        private void GeneratorTwo_Load(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lst.CheckedItems)
            {
                //lstMetod.Items.Add(item.Text);
                //Loads(item.Tag.ToString());
                LoadMethod(item.Tag.ToString());
            }
        }
        void LoadMethod(string _select)
        {
            int index;
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                //scommand.CommandText = @"SELECT [Методы].[№ метода],[Название метода] from [Понятия и методы],[Методы] where [№ понятия]='" + _select + "' and [Методы].[№ метода]=[Понятия и методы].[№ метода]";
                scommand.CommandText = @"Select distinct [Методы].[№ метода],[Методы].[Название метода] from [Сходные понятия],[Методы],[Понятия и методы] where [Сходные понятия].[№ понятия]='" + _select + "' or ([Сходные понятия].[№ схожего понятия]='" + _select + "') and [Понятия и методы].[№ понятия]='" + _select + "'";
                try
                {
                    SqlDataReader dr = scommand.ExecuteReader();
                    while (dr.Read())
                    {
                        index=lstMetod.Items.Add(dr[1].ToString()).Index;
                        lstMetod.Items[index].Tag = dr[0].ToString();
                       
                    } dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } sconn.Close();
        }

        private void lstMetod_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dGVParameters.Rows.Clear();
            if (lstMetod.SelectedItems[0].Tag != null)
            {
                LoadPamOne(lstMetod.SelectedItems[0].Tag.ToString());
                LoadPamTwo(lstMetod.SelectedItems[0].Tag.ToString());
            }
            else
            {
                dGVParameters.Rows.Clear();
            }
        }
        
        void LoadPamOne(string _select)
        {
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = @"SELECT * from [Известные параметры] where [№ метода]='"+_select+"'";
                int k=0;
                try
                {
                    SqlDataReader dr = scommand.ExecuteReader();
                    while (dr.Read())
                    {
                        dGVParameters.Rows.Add();
                        dGVParameters.Rows[k].Cells[0].Value = dr[2].ToString() + " " + dr[3].ToString();
                        k++;

                    } dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } sconn.Close();
        }
        void LoadPamTwo(string _select)
        {
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                SqlCommand scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = @"SELECT * from [Неизвестные параметры] where [№ метода]='" + _select + "'";
                int k = 0;
                try
                {
                    SqlDataReader dr = scommand.ExecuteReader();
                    while (dr.Read())
                    {
                        dGVParameters.Rows.Add();
                        dGVParameters.Rows[k].Cells[1].Value = dr[2].ToString() + " "+ dr[3].ToString();
                        k++;

                    } dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } sconn.Close();
        }

        private void впередToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneratorThree genthree = new GeneratorThree(NumShab,TextPon,lst,lstMetod,NumPrepod);
            this.Hide();
            genthree.Show();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneratorOne genOne = new GeneratorOne(NumPrepod);
            this.Hide();
            genOne.Show();
        }

        private void lstMetod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Delete)
            {
                lstMetod.SelectedItems[0].Remove();
            }
        }
    }
}
