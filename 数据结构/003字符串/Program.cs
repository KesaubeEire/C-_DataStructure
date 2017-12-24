using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003字符串
{
    class StringDS
    {
        static void Main(string[] arg)
        { }

        private char[] data;
        //用来存放字符串中的字符

        #region 两个构造方法
        public StringDS(char[] array)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = array[i];
            }
        }

        public StringDS(string str)
        {
            data = new char[str.Length];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = str[i];
            }
        }
        #endregion

        /// <summary>
        /// 长度的静态变量
        /// </summary>
        public int len
        {
            get
            {
                return this.GetLength();
            }
        }
        /// <summary>
        /// 索引器，根据索引访问字符的索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public char this[int index]
        {
            get
            {
                return data[index];
            }
        }

        /// <summary>
        /// 取得长度的方法
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return data.Length;
        }

        /// <summary>
        /// 如果两个字符串一样返回0
        /// 如果当前字符串小于s，返回-1
        /// 反之，返回1
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Compare(StringDS s)
        {
            int len = this.GetLength() < s.GetLength() ? this.GetLength() : s.GetLength();
            int index = -1;//存储不相等的索引的位置
            //取得两个字符串中短的字符串的长度
            for (int i = 0; i < len; i++)
            {
                if (this[i] != s[i])
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                if (this[index] < s[index])
                {
                    return -1;
                }
                else return 1;
            }
            if (index == -1)
            {
                if (this.GetLength() == s.GetLength())
                    return 0;
                else if (this.GetLength() > s.GetLength())
                {
                    return 1;
                }
                else if (this.GetLength() < s.GetLength())
                {
                    return -1;
                }
            }
            return index;
        }

        /// <summary>
        /// 字符串的提取子字符串
        /// </summary>
        /// <param name="index">开始提取目录</param>
        /// <param name="length">提取长度</param>
        /// <returns></returns>
        public StringDS SubString(int index, int length)
        {
            char[] newData = new char[length];
            if ((index + length) > this.GetLength())
            {
                return new StringDS("这个长度越界了哟");
            }
            for (int i = index; i < index + length; i++)
            {
                newData[i] = this[i];
            }
            return new StringDS(newData);
        }

        /// <summary>
        /// 将两个StringDS拼起来，第一个在前面第二个在后面，
        /// </summary>
        /// <param name="s1">前面的字符串</param>
        /// <param name="s2">后面的字符串</param>
        /// <returns></returns>
        public StringDS Concate(StringDS s1, StringDS s2)
        {
            //我的代码
            char[] newData = new char[s1.len + s2.len];
            for (int i = 0; i < newData.Length; i++)
            {
                if (i < s1.len)
                    newData[i] = s1[i];
                else
                    newData[i] = s2[i];
            }

            //人家的代码，就是不一样
            //for (int i = 0; i < s1.len; i++)
            //{
            //    newdata[i] = s1[i];
            //}
            //for (int i = s1.len; i < newdata.length; i++)
            //{
            //    newdata[i] = s2[i - s1.len];
            //}
            return new StringDS(newData);
        }

        /// <summary>
        /// 判断输入的子串在主串中的位置
        /// 位置是主串中第一个匹配的字符的位置
        /// 不是kmp的模式
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int IndexOf(StringDS s)
        {
            bool isEqual = true;
            for (int i = 0; i <= this.len + s.len; i++)
            {
                isEqual = true;
                for (int j = 0; j < i + s.len; j++)
                {
                    if (this[j] != s[j - i])
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual)
                {
                    return i;
                }
                else
                {
                    continue;
                }
            }
            return -1;
        }
    }
}
