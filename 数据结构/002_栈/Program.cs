using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _002_栈
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.使用BCL中的stack<T>
            //Stack<char> stack = new Stack<char>();
            SeqStack<char> stack = new SeqStack<char>(30);


            stack.Push('a');
            stack.Push('s');
            stack.Push('w');
            //push a s w之后的数据个数为
            Console.WriteLine("push a s w之后的数据个数为:"+stack.Count);
            //------------------------------------------------
            Console.WriteLine("---------------------------------------");
            char temp= stack.Pop();
            Console.WriteLine("pop之后的数据个数为:" + stack.Count);
            Console.WriteLine("---------------------------------------");
            char i= stack.Peek();
            Console.WriteLine("peek为:" + i);
            Console.WriteLine("peek之后的数据个数为:" + stack.Count);
            Console.WriteLine("---------------------------------------");
            stack.Clear();
            Console.WriteLine("clear之后的数据个数为:" + stack.Count);
            //当空栈的时候不要进行pick或peek操作
            //否则会出现异常



            Console.ReadKey();
        }
    }
}
