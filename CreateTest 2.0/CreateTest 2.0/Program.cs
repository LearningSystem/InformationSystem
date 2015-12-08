using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateTest_2._0
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            int num = Int32.Parse(args[0].ToString());
            if (args[1] != null)
            {
                string PathXml = args[1].ToString();
                Application.Run(new InfoTest(num, PathXml));
            }
            else
                Application.Run(new InfoTest(num, null));
        }
    }
}
