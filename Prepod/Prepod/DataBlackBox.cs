using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prepod
{
    public partial class DataBlackBox : Form
    {
        public DataBlackBox()
        {
            InitializeComponent();
        }

        private void DataBlackBox_Load(object sender, EventArgs e)
        {
            //// TODO: This line of code loads data into the 'viewExitData._ViewExitData' table. You can move, or remove it, as needed.
            //this.viewExitDataTableAdapter.Fill(this.viewExitData._ViewExitData);
            //// TODO: This line of code loads data into the 'viewEnterData._ViewEnterData' table. You can move, or remove it, as needed.
            //this.viewEnterDataTableAdapter.Fill(this.viewEnterData._ViewEnterData);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
