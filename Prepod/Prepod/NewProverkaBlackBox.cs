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
    public partial class NewProverkaBlackBox : Form
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        SqlConnection sconn;
        SqlCommand scommand;
        string SelectExer;
        public NewProverkaBlackBox(string _selectExercise)
        {
            InitializeComponent();
            SelectExer = _selectExercise;
        }

        private void NewProverkaBlackBox_Load(object sender, EventArgs e)
        {
            sconn = new SqlConnection(connectionString);
            using (sconn)
            {
                sconn.Open();
                scommand = new SqlCommand();
                scommand.Connection = sconn;
                scommand.CommandText = @"Insert into Проверка ([№ задачи]) values ('"+SelectExer+"')";
                try
                {
                    scommand.ExecuteNonQuery();
                    scommand = new SqlCommand();
                    scommand.Connection = sconn;
                    scommand.CommandText = @"SELECT [№ проверки] from [Проверка] where [№ задачи]='"+SelectExer+"'";
                    SqlDataReader dr = scommand.ExecuteReader();
                    while(dr.Read())
                    {

                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } sconn.Close();
        }
    }
}
