﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_栈
{/// <summary>
/// 链栈的结点
/// </summary>
/// <typeparam name="T"></typeparam>
    class Node<T>
    {
        private T data;
        private Node<T> next;

        public Node()
        {
            data = default(T);
            next = null;
        }
        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }

        public T Data
        {
            get
            {return data;}
            set
            {data = value;}
        }

        public Node<T> Next
        {
            get
            { return next; }
            set
            { next = value; }
        }






    }
}
