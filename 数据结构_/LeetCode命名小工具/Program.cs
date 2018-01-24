using System;

namespace LeetCode命名小工具
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            char[] a = Console.ReadLine().ToCharArray();
            char[] b = new char[a.Length + 1];
            b[0] = '_';

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == ' ' || a[i] == '.')
                    a[i] = '_';
                b[i + 1] = a[i];
            }

            foreach (var VARIABLE in b)
            {
                Console.Write(VARIABLE);
            }
        }
    }
}