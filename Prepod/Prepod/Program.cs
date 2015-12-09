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
            Application.Run(new studentWork("1"));
            //Application.Run(new prepodWork(1));
=======
            Application.Run(new regForm());
            //Application.Run(new studentWork("1"));
            //Application.Run(new admin());
>>>>>>> 80243890ba84c40cfb2823c656884761feef6951
            //Application.Run(new Estimates("1"));
        }
    }
}
