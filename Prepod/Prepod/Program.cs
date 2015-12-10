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
            //Application.Run(new studentWork("1"));
            Application.Run(new prepodWork(1));

            //Application.Run(new regForm());
            //Application.Run(new studentWork("1"));
            //Application.Run(new admin());

=======
            //Application.Run(new regForm());
            //Application.Run(new studentWork("1"));
            //Application.Run(new prepodWork(1));
            Application.Run(new regForm());
            //Application.Run(new studentWork("1"));
            //Application.Run(new admin());
>>>>>>> d8e1bf29a393fe3fa02f3524d1393a322d11374f
            //Application.Run(new Estimates("1"));
        }
    }
}
