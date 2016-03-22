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
            //Application.Run(new InfoTest(1));
            studentWork std=new studentWork("1","1");
            Application.Run(new TestStart(1, "C:\\Users\\User\\Desktop\\Текущие проекты\\Версия на тестирование\\Prepod\\Prepod\\bin\\Debug\\Тесты\\лол.xml", std));
            //Application.Run(new StartForm());
        }
    }
}
