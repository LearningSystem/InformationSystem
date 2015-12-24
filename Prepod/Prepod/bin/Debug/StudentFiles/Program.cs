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
        class Krug
        {
            double R;
            double S;
            public Krug(double _r)
            {
                R = _r;
            }
            public void PL1()
            {
                S = Math.PI * R * R;
            }
            public void PL2(double R)
            {
                S = Math.PI * R * R;
            }
            public double PL3(double R, double S)
            {
                return S = Math.PI * R * R;
            }
        }

        //string writePath = "C:\\Users\\User\\Documents\\Visual Studio 2013\\Projects\\Black\\Black\\bin\\Debug\\write.txt";
        static void Main(string[] args)
        {
            //int b=0;
            //string[]parametrs=new string[50];
            //while(args[b]!=null)
            //{
            //double r = Int32.Parse(args[b].ToString());
            double r = Int32.Parse(args[0].ToString());
            //    b++;
            //}
            Krug newKrug = new Krug(r);
            //double a = Double.Parse(args[0]);
            //double b=0;
            //if(args[1]!=null)
            //    b=Double.Parse(args[1]);
          
            using (StreamWriter sw = new StreamWriter("C:\\Programs\\"+"Program.txt", false, System.Text.Encoding.Default))
            {
                double answer = 0;
                //double answer1 = a * b;
                answer=newKrug.PL3(r,answer);
               // double answer2 = -a * b;
                sw.WriteLine("Parameters:");
                sw.WriteLine(r);
               // sw.WriteLine(a);
                //sw.WriteLine(b);
                sw.WriteLine("Answers:");
                //sw.WriteLine(answer1.ToString());
                //sw.WriteLine(answer2.ToString());
                sw.WriteLine(answer.ToString());
            }
        }
    }
}
