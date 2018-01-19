using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005队列
{
    public class LinkQueue<T> : IQueue<T>
    {
        private Node<T> front;
        private Node<T> rear;
        private int num;//队列节点个数
        //-------------------------------------------------------------
        //-------------------------------------------------------------
        public Node<T> Front { get => front; set => front = value; }
        public Node<T> Rear { get => rear; set => rear = value; }
        public int Num { get => num; set => num = value; }
        //-------------------------------------------------------------
        public void Clear()
        {
            front = rear = null;
            num = 0;
        }

        public T GetFront()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is Empty!!!");
                return default(T);
            }
            else return front.Data;
        }
        //-------------------------------------------------------------
        public Node<T> GetNext(Node<T> nownode)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is Empty!!!");
                return default(Node<T>);
            }
            if (nownode.Next == null)
            {
                Console.WriteLine("The next node is null, Sorry!");
                return default(Node<T>);
            }
            else return nownode.Next;
        }
        //-------------------------------------------------------------
        public int Getlength()
        {
            return num;
        }

        public void In(T item)
        {
            Node<T> q = new Node<T>(item);
            if (IsEmpty())
            {
                rear = q;
                front = q;
            }
            else
            {
                rear.Next = q;//链接,这步很关键要理解哟
                rear = q;//赋值
            }
            num++;
        }

        public bool IsEmpty()
        {
            if ((num == 0) && (front == rear))
                return true;
            else
                return false;
        }

        public T Out()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Nothing to get out!!! Quene is empty!!!");
                return default(T);
            }
            else
            {
                num--;
                T tep = front.Data;
                front = front.Next;
                if (front == null)
                    rear = null;
                return tep;
            }
        }

        //-------------------------------------------------------------我自己写的部分
        //-------------------------------------------------------------
    }
    public class Node<T>
    {
        private T data;//数据域
        private Node<T> next;//引用域
        public T Data { get => data; set => data = value; }
        public Node<T> Next { get => next; set => next = value; }
        /// <summary>
        /// 底下一大堆构造用的函数
        /// </summary>
        /// <param name="val">值</param>
        /// <param name="p">下一个值的指针</param>
        public Node(T val, Node<T> p)
        {
            Data = val;
            Next = p;
        }
        public Node(Node<T> p)
        {
            Next = p;
        }
        public Node(T val)
        {
            Data = val;
            Next = null;
        }
        public Node()
        {
            Data = default(T);
            Next = null;
        }
    }
}
