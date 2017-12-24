using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_线性表
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用我们的顺序表
            SeqList<string> seqlist = new SeqList<string>();
            seqlist.Add("233");
            seqlist.Add("666");
            seqlist.Add("999");

            Console.WriteLine(seqlist.GetEle(2));
            Console.WriteLine(seqlist[2]);
            Console.WriteLine("------------------------------------------");
            seqlist.Insert("777", 1);
            for (int i = 0; i < seqlist.GetLength(); i++)
            {
                Console.WriteLine(seqlist[i]);
            }
            Console.WriteLine("------------------------------------------");
            seqlist.Delete(0);
            for (int i = 0; i < seqlist.GetLength(); i++)
            {
                Console.WriteLine(seqlist[i]);
            }
            Console.WriteLine("------------------------------------------");
            seqlist.Clear();
            for (int i = 0; i < seqlist.GetLength(); i++)
            {
                Console.WriteLine(seqlist[i]);
            }





            Console.ReadKey();
        }
    }
}
