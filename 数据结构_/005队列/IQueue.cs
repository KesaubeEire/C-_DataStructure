using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005队列
{
    /// <summary>
    /// 队列实现的接口
    /// </summary>
    /// <typeparam name="T">T自定义类型</typeparam>
    public interface IQueue<T>
    {
        int Getlength();//取队列长度
        bool IsEmpty();//判断是否为空
        bool IsFull();//判断队列是否已满
        void Clear();//清空队列
        void In(T item);//将item入队
        T Out();//出队,队列头元素从队伍被取出
        T GetFront();//取头元素的值，队列不变
    }
}
