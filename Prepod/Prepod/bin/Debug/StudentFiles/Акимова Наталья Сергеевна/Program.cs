using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace first
{
    class StackOverflawExcept : Exception
    {
        public StackOverflawExcept(string message)
            : base(message)
        {
        }
    }
    class NullStackExcept : Exception
    {
        public NullStackExcept(string message)
            : base(message)
        {
        }
    }
    class Steck
    {
        protected int K;
        public int n;
        private int[] mas;
        public Steck(int _n)
        {
            n = _n; K = -1;
            mas = new int[n];
        }
        public void Clear()
        {
            for (int i = K; i >= 0; i--)
                mas[i] = 0;
            K = -1;
        }
        public void Pop()
        {

            if (K > -1)
            {
                mas[K] = 0;
                K--;
            }
            else
            {
                NullStackExcept err = new NullStackExcept("Удаление из пустого стека");
                throw err;
            }
        }
        public void Print()
        {
            for (int i = K; i >= 0; i--)
                Console.Write(mas[i] + " ");
            Console.WriteLine();
        }
        public void Push(int elem)
        {
            if (K < n-1)
            {
                K++;
                mas[K] = elem;
            }
            else
            {
                StackOverflawExcept err = new StackOverflawExcept("Переполнение стека");
                throw err;
            }
        }
        public int Top()
        {
            if (K== -1)
            {
                NullStackExcept err = new NullStackExcept("Чтение из пустого стека");
                throw err;
            }
            return mas[K];

        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int N;
            string i;
            i = Console.ReadLine();
            N = Convert.ToInt32(i);
            Steck MyStek = new Steck(N);
            while (a != 6)
            {
                Console.WriteLine("1 - Clear");
                Console.WriteLine("2 - Print");
                Console.WriteLine("3 - Pop");
                Console.WriteLine("4 - Push");
                Console.WriteLine("5 - Top");
                Console.WriteLine("6 - Exit");

                i = Console.ReadLine();
                a = Convert.ToInt32(i);

                switch (a)
                {
                    case 1: MyStek.Clear(); break;
                    case 2: MyStek.Print(); break;
                    case 3: 
                        {
                            try
                            {
                                MyStek.Pop();
                            } 
                            catch (NullStackExcept e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case 4:
                        {
                            int x;
                            Console.WriteLine("enter element");
                            i = Console.ReadLine();
                            x = Convert.ToInt32(i);
                            try
                            {
                                MyStek.Push(x);
                            }
                            catch (StackOverflawExcept e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        } break;
                    case 5: Console.WriteLine(MyStek.Top()); ; break;
                }
            }

        }
    }
}
