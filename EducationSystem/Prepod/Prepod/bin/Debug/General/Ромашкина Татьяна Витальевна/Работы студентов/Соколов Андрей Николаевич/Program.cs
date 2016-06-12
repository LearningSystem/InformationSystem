using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace TaskOne
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter str = new StreamWriter(args[0]))
            {
                int a = Convert.ToInt32(args[1]);
                int b = Convert.ToInt32(args[2]);
                str.WriteLine("Parameters:");
                str.WriteLine(a);
                str.WriteLine(b);
                int min;
                if (a > b)
                    min = b;
                else
                    min = a;
                int i = min;
                int c = 0;
                while (i>0&&c==0)
                {
                    if ((a % i == 0) && (b % i == 0))
                        c = i;
                    i--;
                }
				//c = 0;
                str.WriteLine("Answers:");
                str.WriteLine(Convert.ToString(c));
				//str.WriteLine(a);
            }
        }
    }
}
