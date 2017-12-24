using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_栈
{
    ///链栈的类
    class LinkStack<T> : IStackDS<T>
    {
        private Node<T> top;//栈顶元素结点
        private int count = 0;//栈中元素的个数


        public int Count//个数,属性
        {
            get { return this.count; }
        }
        public int getLength()//个数，方法
        {
            return count;
        }
        /// <summary>
        /// 判断栈中是否有数据
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return count == 0;
        }
        /// <summary>
        /// 清空栈中的数据
        /// </summary>
        public void Clear()
        {
            top = null;
            count = 0;
        }






        public T Peek()
        {
            return top.Data;
        }

        public T Pop()
        {
            Node<T> temp = top;
            top = top.Next;


            return temp.Data;
        }

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>(item,top); ;
            top = newNode;
            count++;
        }
    }
}
