using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApplication1
{
    class Program
    {
        static void PROVERKA_DEL(ref int n, out bool k)
        {
            int a, b=0;
            while (n>0)
            {
                a = n % 10;// последняя цифра
                b = a + b;// сумма цифр в числе
                n = n / 10;
            }
            double c=b%9;
            if ((c < 0) | (c > 0)) k = false;
            else k = true;
         }
        static void Main(string[] args)
        {
            StreamWriter f3 = new StreamWriter(args[0]);
            //Console.Write("n=");
            string s=args[1];
            int n =Convert.ToInt32(s);
            bool k;
            PROVERKA_DEL(ref n, out k);
            //Console.WriteLine("k="+k);
			f3.WriteLine("Parameters:");
			f3.WriteLine(s);
			f3.WriteLine("Answers:");
            if (k) 
                f3.WriteLine("TRUE");
            else 
                f3.WriteLine("FALSE");
            f3.Close();
           // Console.ReadKey();

        }
    }
}
