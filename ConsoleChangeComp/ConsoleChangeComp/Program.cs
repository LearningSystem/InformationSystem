using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleChangeComp
{
    class Program
    {
        static string text = "";
        static void Main(string[] args)
        {
            text = System.Environment.CurrentDirectory;
            Console.WriteLine(text);
            string str1 = text + @"\Prepod\App.config";
            Console.WriteLine(str1);
            Change(str1);
            text = text + @"\\Prepod\\bin\\Debug\\Prepod.exe.config";
            Console.WriteLine(text);
            Change(text);
        }
        static void Change(string _path)
        {
            string znach = "";
            znach = System.IO.File.ReadAllText(_path);
            Console.WriteLine(znach);
            //string oldchar = "Data Source=USER-PC";
            int pos1 = znach.IndexOf("Data Source=");
            int pos2 = znach.IndexOf(";Initial");
            string oldchar=znach.Substring(pos1,pos2-pos1);
            string newchar = "Data Source=" + System.Environment.MachineName;
            znach = znach.Replace(oldchar, newchar);
            Console.WriteLine(znach);
            System.IO.File.WriteAllText(_path, znach);
        }
    }
}
