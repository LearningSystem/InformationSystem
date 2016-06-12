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
        static bool server = false;
        static string text = "";
        static string ServerName = "";
        static void Main(string[] args)
        {
            text = System.Environment.CurrentDirectory;
            //Console.WriteLine(text);
            string str1 = text + @"\Prepod\App.config";
            //Console.WriteLine(str1);
            Change(str1);
            text = text + @"\\Prepod\\bin\\Debug\\Prepod.exe.config";
            //Console.WriteLine(text);
            bool correct=false;
            do
            {
                Console.WriteLine("Server mode (Y/N)?");
                string tempAnsw = Console.ReadLine();
                if (tempAnsw == "Y" || tempAnsw=="y")
                {
                    server = true;
                    Console.Write("Server name = ");
                    ServerName = Console.ReadLine();
                    correct = true;
                }
                else 
                if (tempAnsw == "N" || tempAnsw=="n")
                {
                    //correct = false;
                    //Console.WriteLine("Repeat please.");
                    server = false;
                    correct = true;
                }
                else
                {
                    server = false;
                    correct = true;
                    correct = false;
                    Console.WriteLine("Repeat please.");
                }
            }
            while (correct == false);
            Change(str1);
            Change(text);
        }
        static void Change(string _path)
        {
            string znach = "";
            znach = System.IO.File.ReadAllText(_path);
            //Console.WriteLine(znach);
            //string oldchar = "Data Source=USER-PC";
            int pos1 = znach.IndexOf("Data Source=");
            int pos2 = znach.IndexOf(";Initial");
            string oldchar=znach.Substring(pos1,pos2-pos1);
            string newchar="";
            if (server==false)
                newchar = "Data Source=" + System.Environment.MachineName;
            else
                newchar= "Data Source="+ServerName;
            znach = znach.Replace(oldchar, newchar);
            //Console.WriteLine(znach);
            System.IO.File.WriteAllText(_path, znach);
        }
    }
}
