using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Сonsole1
{
    class Program
    {

        //string writePath = "C:\\Users\\User\\Documents\\Visual Studio 2013\\Projects\\Black\\Black\\bin\\Debug\\write.txt";
        static void Main(string[] args)
        {
			double r=Double.Parse(args[0]);
            using (StreamWriter sw = new StreamWriter("C:\\Programs\\"+"Program1.txt", false, System.Text.Encoding.Default))
            {
                double answer = r*r;
                sw.WriteLine("Parameters:");
                sw.WriteLine(r);
                sw.WriteLine("Answers:");
                sw.WriteLine(answer.ToString());
            }
        }
    }
}
