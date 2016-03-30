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
    public partial class newTree : Form
    {
        SqlConnection conn;        
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        string numPrepod = "";
        public newTree(string numPrepod_)
        {
            InitializeComponent();
            numPrepod = numPrepod_;

        }       

        private void button1_Click(object sender, EventArgs e)
        {           
            if ((textBox1.Text != ""))
            {
                try
                {
                    conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandText = "insert into Дерево (Название, [№ преподавателя]) Values ('" + textBox1.Text + "', '" + numPrepod + "')";
                    comm.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message.ToString());
                }
                finally
                {
                    conn.Close();
                    this.Hide();
                }                
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Введите название!");
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";            
            this.Hide();
        }

        private void newTree_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
