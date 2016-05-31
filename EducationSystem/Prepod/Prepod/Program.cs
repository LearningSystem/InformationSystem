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
            //studentWork std=new studentWork("1","1");
            //Application.Run(new TestStart(1, "C:\\Users\\User\\Desktop\\Текущие проекты\\Версия на тестирование\\Prepod\\Prepod\\bin\\Debug\\Тесты\\лол.xml", std));
            //Application.Run(new regForm());
            //Application.Run(new StartForm());
            Application.Run(new TestStart(Int32.Parse("1041"), "C:\\Users\\User\\Desktop\\Текущие проекты\\Версия на тестирование\\EducationSystem\\Prepod\\Prepod\\bin\\Debug\\General\\Ромашкина Татьяна Витальевна\\Тесты\\Методы.xml",new studentWork("1041","1")));
            //string[] tasks = new string[2];
            //tasks[1] = "4096";
            //Application.Run(new BlackBox(tasks, "1041", "1016", "C:\\Users\\User\\Documents\\Visual Studio 2013\\Projects\\TaskOne\\TaskOne\\Program.cs"));
            //Application.Run(new studentWork("1040", "1"));
            //Application.Run(new GeneratorOne("1016"));
        }
    }
}
