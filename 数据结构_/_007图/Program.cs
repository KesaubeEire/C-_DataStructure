using System;
using System.Reflection.Emit;
using System.Security;

namespace _007图
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("233");
        }
    }

    #region 基本（领接矩阵）图

    /// <summary>
    /// 结点构造
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        private T data;

        public T Data
        {
            get => data;
            set => data = value;
        }

        public Node(T V)
        {
            data = V;
        }
    }

    /// <summary>
    /// 图的接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGragh<T>
    {
        /// <summary>
        /// 获取顶点的个数
        /// </summary>
        /// <returns></returns>
        int GetNumOfVertex();

        /// <summary>
        /// 获取边或弧的数量
        /// </summary>
        /// <returns></returns>
        int GetNumOfEdge();

        /// <summary>
        /// 在两个顶点之间添加一条权为v的边或弧
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v"></param>
        void SetEdge(Node<T> v1, Node<T> v2, int v);

        /// <summary>
        /// 删除顶点之间的边或弧
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        void DelEdge(Node<T> v1, Node<T> v2);

        /// <summary>
        /// 判断两个顶点之间是否有边或弧
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        bool IsEdge(Node<T> v1, Node<T> v2);
    }

    /// <summary>
    /// 一个无向图的领接矩阵类 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GraphMatrix<T> : IGragh<T>
    {
        //---------------------字段
        private Node<T>[] nodes; //一维数组表示顶点的信息
        private int edges; //边的数量

        public int Edges
        {
            get => edges;
            set => edges = value;
        }

        private int[,] mat; //数组表示领接矩阵中边的信息
        //---------------------构造 & 普通函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="n">结点的个数</param>
        public GraphMatrix(int n)
        {
            nodes = new Node<T>[n];
            mat = new int[n, n];
            edges = 0;
        }

        /// <summary>
        /// 获取索引为index的结点的信息
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns>返回的是整个结点，需要结点的信息还需要手动.Data</returns>
        public Node<T> GetNodes(int index)
        {
            return nodes[index];
        }

        /// <summary>
        /// 设置索引为index的结点为v结点
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="v">这里的结点是v结点</param>
        public void SetNode(int index, Node<T> v)
        {
            nodes[index] = v;
        }

        /// <summary>
        /// 设置索引为index的结点的值为v
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="v">这个v是希望赋给结点的值</param>
        public void SetNode(int index, T v)
        {
            nodes[index].Data = v;
        }

        /// <summary>
        /// 获取mat[index1,index2]的值，即判断这两个结点之间有没有相互连接
        /// </summary>
        /// <param name="index1">结点1</param>
        /// <param name="index2">结点2</param>
        /// <returns></returns>
        public int GetMat(int index1, int index2)
        {
            return mat[index1, index2];
        }

        /// <summary>
        /// 设置mat[index1,index2]的值，即让这两个点连接
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        public void SetMat(int index1, int index2)
        {
            mat[index1, index2] = 1;
            mat[index2, index1] = 1;
        }

        /// <summary>
        /// 判断V是否是图的顶点
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool isNode(Node<T> v)
        {
            foreach (Node<T> vrNode in nodes)
            {
                if (v.Equals(vrNode))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 获取顶点v在顶点数组中的索引
        /// </summary>
        /// <param name="v">这个是顶点哟</param>
        /// <returns></returns>
        public int GetIndex(Node<T> v)
        {
            int i = -1;
            for (i = 0; i < nodes.Length; i++) //遍历数组顶点
            {
                if (nodes[i] == v) return i;
            }

            return i;
        }


        //---------------------接口函数
        public int GetNumOfVertex()
        {
            return nodes.Length;
        }

        public int GetNumOfEdge()
        {
            return edges;
        }

        /// <summary>
        /// 本来是给两个顶点之间加一个权值为多少的边的，但是这是无向表，权值没用，so，改成了链接两个表
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v"></param>
        public void SetEdge(Node<T> v1, Node<T> v2)
        {
            if (!isNode(v1) || !isNode(v2))
            {
                Console.WriteLine("顶点错误，有顶点不属于本图");
                return;
            }

            SetMat(GetIndex(v1), GetIndex(v2));
        }

        public void SetEdge(Node<T> v1, Node<T> v2, int v)
        {
            if (!isNode(v1) || !isNode(v2))
            {
                Console.WriteLine("顶点错误，有顶点不属于本图");
                return;
            }

            SetMat(GetIndex(v1), GetIndex(v2));
            edges++; //别忘了加边的数量哟~
        }

        /// <summary>
        /// 删除结点的边
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public void DelEdge(Node<T> v1, Node<T> v2)
        {
            if (IsEdge(v1, v2))
            {
                mat[GetIndex(v1), GetIndex(v2)] = 0;
                mat[GetIndex(v2), GetIndex(v1)] = 0;
            }
        }

        /// <summary>
        /// 判断两个顶点之间是否有边
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public bool IsEdge(Node<T> v1, Node<T> v2)
        {
            if (!isNode(v1) || !isNode(v2))
            {
                Console.WriteLine("顶点错误，有顶点不属于本图");
                return false;
            }

            if (mat[GetIndex(v1), GetIndex(v2)] == 1) return true;
            else return false;
        }

        //---------------------
    }

    #endregion

    #region 领接表图

    /// <summary>
    /// 领接表的存储结构节点图
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class adjustListNode<T>
    {
        private int adjvex; //领接顶点
        private adjustListNode<T> next; //下一个领接顶点

        public int Adjvex
        {
            get => adjvex;
            set => adjvex = value;
        }

        public adjustListNode<T> Next
        {
            get => next;
            set => next = value;
        }

        public adjustListNode(int vex)
        {
            adjvex = vex;
            next = null;
        }
    }

    /// <summary>
    /// 顶点节点类，包括了顶点的数据信息和存储结构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class VexNode<T>
    {
        private Node<T> data;
        private adjustListNode<T> firstAdj;

        public Node<T> Data
        {
            get => data;
            set => data = value;
        }

        public adjustListNode<T> FirstAdj
        {
            get => firstAdj;
            set => firstAdj = value;
        }

        public VexNode(Node<T> data)
        {
            this.data = data;
            firstAdj = null;
        }

        public VexNode(Node<T> data, adjustListNode<T> firstAdj)
        {
            this.data = data;
            this.firstAdj = firstAdj;
        }

        public VexNode()
        {
            data = null;
            firstAdj = null;
        }
    }

    public class GraphAdjustList<T> : IGragh<T>
    {
        //-------------------------------------------Properties
        private VexNode<T>[] adjList; //领接表数组

        public VexNode<T> this[int index]
        {
            get => adjList[index];
            set => adjList[index] = value;
        }

        //-------------------------------------------Functions
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Nodes">节点数组</param>
        public GraphAdjustList(Node<T>[] Nodes)
        {
            adjList = new VexNode<T>[Nodes.Length];
            for (int i = 0; i < Nodes.Length; i++)
            {
                adjList[i].Data = Nodes[i];
                adjList[i].FirstAdj = null;
            }
        }

        public int GetNumOfVertex()
        {
            return adjList.Length;
        }

        public int GetNumOfEdge()
        {
            int i = 0;
            foreach (VexNode<T> node in adjList)
            {
                adjustListNode<T> p = node.FirstAdj;
                while (p != null)
                {
                    i++;
                    p = p.Next;
                }
            }

            return i / 2;
        }

        public bool isNode(Node<T> v)
        {
            foreach (VexNode<T> node in adjList)
            {
                if (v.Equals(node.Data))
                {
                    return true;
                }
            }

            return false;
        }

        public int GetIndex(Node<T> v)
        {
            int i = -1;
            if (isNode(v))
            {
                for (i = 0; i < adjList.Length; i++)
                {
                    if (adjList[i].Data.Equals(v)) return i;
                }
            }

            return i;
        }

        public void SetEdge(Node<T> v1, Node<T> v2, int v)
        {
            throw new NotImplementedException();
        }

        public void DelEdge(Node<T> v1, Node<T> v2)
        {
            throw new NotImplementedException();
        }

        public bool IsEdge(Node<T> v1, Node<T> v2)
        {
            if ((!isNode(v1)) || (!isNode(v2)))
            {
                Console.WriteLine("顶点出错，存在不属于图的顶点");
                return false;
            }

            adjustListNode<T> p = adjList[GetIndex(v1)].FirstAdj;
            foreach (VexNode<T> vexNode in adjList)
            {
                if (p.Adjvex == GetIndex(v2)) return true;
                p = p.Next;
            }

            return false;
        }
    }

    #endregion
}