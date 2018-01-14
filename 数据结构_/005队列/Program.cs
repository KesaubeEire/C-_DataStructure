using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005队列
{
    class Program
    {
        static void Main(string[] args)
        {
            Lq();
            Console.ReadKey();
        }

        static public void Cq()
        {
            CSequeue<int> Q1 = new CSequeue<int>(10);
            while (true)
            {
                Console.WriteLine("Please input a num");
                var a = Console.ReadLine();
                int ResultNum;
                if (int.TryParse(a, out ResultNum) == false)
                {
                    Console.WriteLine("Please look I need a num! You idiot!");
                    continue;
                }
                else
                {
                    Q1.In(int.Parse(a));
                    Console.WriteLine("The number you input is:\t" + a);
                }
                //   if (true) Console.WriteLine("Please look I need a num! You idiot!");
                //  else Q1.In(a);
                Console.WriteLine("Input K to print, or an Enter to circle");
                if ("K" == Console.ReadLine())
                {
                    for (int i = 0; i < Q1.Getlength(); i++)
                    {
                        Console.WriteLine(Q1[i]);
                    }
                }
            }

        }
        static public void Lq()
        {
            LinkQueue<int> Q1 = new LinkQueue<int>();
            while (true)
            {
                Console.WriteLine("Please input a num");
                var a = Console.ReadLine();
                int ResultNum;
                if (int.TryParse(a, out ResultNum) == false)
                {
                    Console.WriteLine("Please look I need a num! You idiot!");
                    continue;
                }
                else
                {
                    Q1.In(int.Parse(a));
                    Console.WriteLine("The number you input is:\t" + a);
                }
                //   if (true) Console.WriteLine("Please look I need a num! You idiot!");
                //  else Q1.In(a);
                Console.WriteLine("Input K to print, or an Enter to circle");
                if ("K" == Console.ReadLine())
                {
                    Node<int> a1 = Q1.Front;
                    for (int i = 0; i < Q1.Getlength(); i++)
                    {
                        Console.Write("这是第" + (i + 1) + "个");
                        Console.WriteLine(a1.Data);
                        a1 = Q1.GetNext(a1);
                    }
                }
            }

        }
    }
}
