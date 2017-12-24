using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_线性表
{
    class LinkList<T> : IListDS<T>
    {
        public T this[int index]
        {
            get
            {
                Node<T> temp = head;
                for (int i = 1; i <= index; i++)
                {
                    temp = temp.Next;
                }
                return temp.Data;
            }
        }

        private Node<T> head;//存储一个头结点
        public LinkList()
        {
            head = null;
        }


        /// <summary>
        /// 添加元素
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            Node<T> newNode = new Node<T>(item);
            //如果头结点为空，那么这个新的节点就是头结点
            if (head == null)
            {
                head = newNode;
            }
            else//头节点不为空则把新来的链表放到链表的尾部
            {//访问链表的尾结点
                Node<T> temp = head;
                while (true)
                {

                    if (temp.Next != null)
                    {
                        temp = temp.Next;
                    }
                    else
                    {
                        break;
                    }
                }
                temp.Next = newNode;//让新的结点放到链表的尾部
            }





        }
        /// <summary>
        /// 删除元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Delete(int index)
        {
            T data = default(T);
            if (index == 0)
            {
                data = head.Data;
                head = head.Next;
            }
            else
            {
                Node<T> temp = head;
                for (int i = 1; i < index; i++)
                {
                    //让temp向后移动一个位置
                    temp = temp.Next;
                }
                Node<T> preNode = temp;
                Node<T> currentNode = temp.Next;
                data = currentNode.Data;
                Node<T> nextNode = temp.Next.Next;
                preNode.Next = nextNode;
            }
            return data;
        }
        /// <summary>
        /// 插入一个元素
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        public void Insert(T item, int index)
        {
            Node<T> newNode = new Node<T>(item);
            if (index == 0)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                Node<T> temp = head;
                for (int i = 1; i < index; i++)
                {
                    //让temp向后移动一个位置
                    temp = temp.Next;
                }
                Node<T> preNode = temp;
                Node<T> currentNode = temp.Next;
                newNode.Next = currentNode;
                preNode.Next = newNode;


            }
        }
        /// <summary>
        /// 清空链表
        /// </summary>
        public void Clear()
        {
            head = null;
        }
        /// <summary>
        /// 获取元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetEle(int index)
        {
            return this[index];
        }
        /// <summary>
        /// 获取单链表的长度
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            if (head == null)
            {
                return 0;
            }
            Node<T> temp = head;
            int count = 1;
            while (true)
            {
                if (temp.Next != null)
                {
                    count++;
                    temp = temp.Next;
                }
                else
                {
                    break;
                }
            }
            return count;
        }
        /// <summary>
        /// 判断链表是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return head == null;
        }

        public int Locate(T value)
        {
            Node<T> temp = head;
            if (temp == null)
            {
                return -1;
            }
            else
            {
                int index = 0;
                while (true)
                {
                    if (temp.Data.Equals(value))
                    {
                        return index;
                    }
                    else
                    {
                        if (temp.Next != null)
                        {
                            temp = temp.Next;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }return -1;
        }
    }
}
