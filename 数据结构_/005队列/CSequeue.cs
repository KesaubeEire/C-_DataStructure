using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005队列
{
    public class CSequeue<T> : IQueue<T>
    {
        //容量
        private int maxsize;
        //存取数据的数组
        private T[] data;
        //对头指针
        private int front;
        //队尾指针
        private int rear;
        /// <summary>
        /// 索引器，目录封装
        /// </summary>
        /// <param name="index">元素的index</param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
        /// <summary>
        /// 容量封装
        /// </summary>
        public int Maxsize
        {
            get
            {
                return maxsize;
            }
            set
            {
                maxsize = value;
            }
        }
        /// <summary>
        /// 队头封装
        /// </summary>
        public int Front
        {
            get => front; set => front = value;
        }
        /// <summary>
        /// 队尾封装
        /// </summary>
        public int Rear
        {
            get => rear; set => rear = value;
        }
        //-----------------------------------------------------
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="Size">容量</param>
        public CSequeue(int Size)
        {
            data = new T[Size];
            maxsize = Size;
            front = rear = -1;
        }
        //-----------------------------------------------------
        //-----------------------------------------------------

        public void Clear()
        {
            front = rear = -1;
        }

        public T GetFront()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Nothint to out, the Quene is empty");
                return default(T);
            }

            return data[front + 1];
        }

        public int Getlength()
        {
            return (rear - front + maxsize) % maxsize;
            ///这他妈是，，，没看懂为什么还要加一个maxsize
            ///大概是rear的大小被默认在maxsize之内
            ///当循环时需要加一个maxsize以证明队尾比队头大吧
        }

        public void In(T item)
        {
            if (IsFull())
            {
                Console.WriteLine("The Queue is too full to add one");
                return;
            }
            else
            {
                data[++rear] = item;//这里他妈用的真好，++rear相当于先加了rear，然后直接就把item放进去了，屌屌的
            }
        }

        public bool IsEmpty()
        {
            if (front == rear) return true;
            else return false;
        }

        public T Out()
        {
            T tmp = default(T);

            if (IsEmpty())
            {
                Console.WriteLine("Nothint to out, the Quene is empty");
                return tmp;
            }
            else tmp = data[++front];//这里他妈用的真好，++front相当于先加了front，然后直接就把tmp搞出去还扔出了队列，屌屌的
            return tmp;
        }

        public bool IsFull()
        {
            if (front == (rear + 1) % maxsize) return true;
            else return false;
        }
    }
}
