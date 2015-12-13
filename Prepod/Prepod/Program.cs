using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prepod
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            //Application.Run(new regForm());
            Application.Run(new taskWork("1"));
            //Application.Run(new prepodWork(1));
            

            //Application.Run(new regForm());
            //Application.Run(new studentWork("1"));
            //Application.Run(new admin());
            //Application.Run(new regForm());
            //Application.Run(new studentWork("1"));
            //Application.Run(new prepodWork(1));
            //Application.Run(new regForm());
=======
            //Application.Run(new prepodWork(1));
            Application.Run(new regForm());
>>>>>>> b5f6ccca8535d2d155404b87483af3e7729c00ac
            //Application.Run(new studentWork("1"));
            //Application.Run(new admin());
            //Application.Run(new Estimates("1"));
        }
    }
}
