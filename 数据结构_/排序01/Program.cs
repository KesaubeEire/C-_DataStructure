using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 都是从小到大
/// </summary>
namespace 排序01
{
    class Program
    {

        /// <summary>
        /// 直接插入排序
        /// </summary>
        /// <param name="dataArray"></param>
        static void InsertSort(int[] dataArray)
        {
            for (int i = 1; i < dataArray.Length; i++)
            {
                int iValue = dataArray[i];
                bool isInsert = false;
                //拿到i位置的元素，跟前面的所有的元素作比较
                //如果发现比i大的，就让它向后移动
                for (int j = i - 1; j >= 0; j--)
                {
                    if (dataArray[j] > iValue)
                    {
                        dataArray[j + 1] = dataArray[j];
                    }
                    else
                    {
                        //发现一个比i小的值就不移动了
                        dataArray[j + 1] = iValue;
                        isInsert = true;
                        break;
                    }
                }
                if (isInsert == false) dataArray[0] = iValue;//isInsert没变化说明新值是最小的
            }
        }

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="dataArray"></param>
        static void BubbleSort(int[] dataArray)
        {

        }

        static void SelectSort(int[] dataArray)
        {
            for (int i = 0; i < dataArray.Length - 1; i++)
            {
                int min = dataArray[i];
                int index_min = i;
                for (int j = i + 1; j < dataArray.Length; j++)
                {
                    if (dataArray[j] < min)
                    {
                        min = dataArray[j];
                        index_min = j;
                    }
                }
                if (index_min != i)
                {
                    int temp = dataArray[i];
                    dataArray[i] = dataArray[index_min];
                    dataArray[index_min] = temp;
                }
            }
        }

        static void Main(string[] arg)
        {
            int[] data = new int[] { 345, 234, 2341, 215, 325213, 423, 412, 3421, 41, 4213, 234 };
            InsertSort(data);
            //SelectSort(data);
            foreach (var temp in data)
            {
                Console.Write(temp + "\t");
            }
            Console.ReadKey();
        }
    }
}
