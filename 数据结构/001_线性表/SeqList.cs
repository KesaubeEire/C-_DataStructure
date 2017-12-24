using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_线性表
{
    class SeqList<T> : IListDS<T>
    {



        private T[] data;//用来存储
        private int count = 0;//用来表示储存了多少数据


        public SeqList(int size)//size就是最大容量
        {
            data = new T[size];
            count = 0;
        }
        public SeqList() : this(10)//默认构造函数容量是10
        {


        }
        /// <summary>
        /// 取得数据的个数
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return count;
            Console.WriteLine("count:" + count);
        }




        /// <summary>
        /// 添加元素
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (count == data.Length)//array is full
            {
                Console.WriteLine("array is full");
            }
            else//arry isn't full
            {
                data[count] = item;
                count++;
            }
        }


        public void Clear()
        {
            count = 0;
        }



        public T Delete(int index)
        {
            T temp = data[index];
            for (int i = index + 1; i < count; i++)
            {
                data[i - 1] = data[i];
            }
            count--;
            return temp;
        }

        public T this[int index]
        {
            get { return GetEle(index); }
        }


        public T GetEle(int index)
        {
            if (index >= 0 && index <= count - 1)
            {
                return data[index];
            }
            else
            {
                Console.WriteLine("索引不存在");
                return default(T);
            }
        }



        public void Insert(T item, int index)
        {
            for (int i = count - 1; i >= index; i--)
            {
                data[i + 1] = data[i];
            }
            data[index] = item;
            count++;
        }



        public bool IsEmpty()
        {
            return count == 0;
        }



        public int Locate(T value)
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(value))
                { return i; }
            
            }
            return -1;
        }
    }
}
