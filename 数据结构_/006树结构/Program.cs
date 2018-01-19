using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 树结构
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    /// <summary>
    /// 二叉树的节点类
    /// </summary>
    class Node<T>
    {
        private T data; //数据域
        private Node<T> lChild;//左子树
        private Node<T> rChild;//右子树

        public T Data { get => data; set => data = value; }
        internal Node<T> LChild { get => lChild; set => lChild = value; }
        internal Node<T> RChild { get => rChild; set => rChild = value; }

        //========================CONSTRUCTION FIELD

        /// <summary>
        /// Construction of the Tree Node
        /// </summary>
        /// <param name="val">Value.</param>
        /// <param name="lp">Left son of tree.</param>
        /// <param name="rp">Right son of tree.</param>
        public Node(T val, Node<T> lp, Node<T> rp)
        {
            Data = val;
            LChild = lp;
            RChild = rp;
        }
        public Node(Node<T> lp, Node<T> rp)
        {
            Data = default(T);
            LChild = lp;
            RChild = rp;
        }
        public Node(T val)
        {
            Data = val;
            LChild = default(Node<T>);
            RChild = default(Node<T>);
        }
        public Node()
        {
            Data = default(T);
            LChild = default(Node<T>);
            RChild = default(Node<T>);
        }
        //========================CONSTRUCTION FIELD
        //========================FUNCTION FIELD
    }

    class BiTree<T>
    {
        private Node<T> head;

        internal Node<T> Head { get => head; set => head = value; }

        //========================CONSTRUCTION FIELD
        public BiTree()
        {
            head = null;
        }
        public BiTree(T val)
        {
            Node<T> p = new Node<T>(val);
            head = p;
        }
        public BiTree(T val, Node<T> lp, Node<T> rp)
        {
            Node<T> p = new Node<T>(val, lp, rp);
            //这个十分有趣，得学学这个方式，没必要另造两个字段，这就他妈够了，巧用之前造的轮子！
            head = p;
        }
        //========================CONSTRUCTION FIELD
        //========================FUNCTION FIELD
        /// <summary>
        /// 判断是否是空二叉树
        /// </summary>
        /// <returns><c>true</c>, if empty was ised, <c>false</c> otherwise.</returns>
        public bool isEmpty()
        {
            if (head == null) return true;//不理解为什么这里是head == null 而不是子节点
            else return false;
        }

        /// <summary>
        /// 获取根节点
        /// </summary>
        /// <returns>The root.</returns>
        public Node<T> Root()
        {
            return head;
        }

        /// <summary>
        /// 获取节点的左子节点
        /// </summary>
        /// <returns>The LC hild.</returns>
        /// <param name="p">P.</param>
        public Node<T> GetLChild(Node<T> p)
        {
            return p.LChild;
        }
        /// <summary>
        /// 获取节点的右子节点
        /// </summary>
        /// <returns>The RC hild.</returns>
        /// <param name="p">P.</param>
        public Node<T> GetRChild(Node<T> p)
        {
            return p.RChild;
        }
        /// <summary>
        /// 将节点p的左子树插入值为val的新节点，原来的左子树成为新节点的左子树
        /// </summary>
        /// <param name="val">Value.</param>
        /// <param name="p">P.</param>
        public void InsertL(T val, Node<T> p)
        {
            // p.LChild.Data = val;
            // p.LChild.LChild = p.LChild;
            //上面是我的方法
            //下面是书上的方法
            Node<T> tem = new Node<T>(val);
            tem.LChild = p.LChild;
            p.LChild = tem;
            //他给的这个顺序对不对呢？
            //我感觉是
            /*
             * tem.LChild = p.LChild;
             * p.LChild = tem;
             * 这个顺序啊！
            */
            ///--------------------修改认知ver0.1
            /// 人家是对的，这个功能相当于在中间多插入了一层，人家的是对的
        }
        /// <summary>
        /// 将节点p的右子树插入值为val的新节点，原来的右子树成为新节点的右子树
        /// </summary>
        /// <param name="val">Value.</param>
        /// <param name="p">P.</param>
        public void InsertR(T val, Node<T> p)
        {
            Node<T> tem = new Node<T>(val);
            tem.RChild = p.RChild;
            p.RChild = tem;
        }
        /// <summary>
        /// 若节点不为空，则删除该节点的左子树
        /// </summary>
        /// <returns>The l.</returns>
        /// <param name="p">P.</param>
        public Node<T> DeleteL(Node<T> p)
        {
            if ((p == null) || (p.LChild == null))
            {
                return null;
            }
            Node<T> tmp = p.LChild;
            p.LChild = null;
            return tmp;
        }
        /// <summary>
        /// 若节点不为空，则删除该节点的右子树
        /// </summary>
        /// <returns>The r.</returns>
        /// <param name="p">P.</param>
        public Node<T> DeleteR(Node<T> p)
        {
            if ((p == null) || (p.RChild == null))
            {
                return null;
            }
            Node<T> tmp = p.RChild;
            p.RChild = null;
            return tmp;
        }
        /// <summary>
        /// 判断是否为叶子节点，即子节点存在但不存在子节点的子节点Is the leaf.
        /// </summary>
        /// <returns><c>true</c>, if leaf was ised, <c>false</c> otherwise.</returns>
        /// <param name="p">P.</param>
        public bool isLeaf(Node<T> p)
        {
            if (p != null && p.LChild == null && p.RChild == null) return true;
            else return false;
        }
        //========================FUNCTION FIELD
        //========================ESSENTIAL FUNCTION FIELD - 遍历二叉树的方法

        ///先序遍历，若二叉树为空，则结束遍历，否则：
        /// 1.访问根节点
        /// 2.先序遍历左子树
        /// 3.先序遍历右子树
        private int id_Line_Pre = 0;
        public void PreOrder(Node<T> root)
        {
            if (root == null) return;
            else
            {
                Console.Write("dataContent:\t" + root.Data);
                Console.WriteLine("\tline:\t" + id_Line_Pre);
                id_Line_Pre++;
                PreOrder(root.LChild);
                id_Line_Pre--;
                PreOrder(root.RChild);

            }
        }

        ///中序遍历，若二叉树为空，则结束遍历，否则：
        /// 1.中序遍历左子树
        /// 2.访问根节点
        /// 3.中序遍历右子树
        private int id_Line_In = 0;
        public void InOrder(Node<T> root)
        {
            if (root == null) return;
            else
            {
                id_Line_In++;
                InOrder(root.LChild);
                id_Line_In--;
                Console.Write("dataContent:\t" + root.Data);
                Console.WriteLine("\tline:\t" + id_Line_In);
                id_Line_In++;
                InOrder(root.RChild);
                id_Line_In--;
            }
        }

        ///后序遍历，若二叉树为空，则结束遍历，否则：
        /// 1.后序遍历左子树
        /// 2.后序遍历右子树
        /// 3.访问根节点
        private int id_Line_Post = 0;
        public void PostOrder(Node<T> root)
        {
            if (root == null) return;
            else
            {
                id_Line_Post++;
                PostOrder(root.LChild);
                PostOrder(root.RChild);
                id_Line_Post--;
                Console.Write("dataContent:\t" + root.Data);
                Console.WriteLine("\tline:\t" + id_Line_Post);
            }
        }

        ///层次遍历，
        /// 
        /// 
        /// 

        //设置一个队列装载所有的顺序队列
        //这招真他妈好用
        private Queue<Node<T>> sq = new Queue<Node<T>>(1000);
        public void LevelOrder(Node<T> root)
        {
            if (root == null) return;
            else
            {
                //表示了本节点的数据
                Console.Write("dataContent:\t" + root.Data);

                if (root.LChild != null)
                {
                    sq.
                }
                if (root.RChild != null)
                {
                    LevelOrder(root.RChild);
                }




            }


        }



        //========================ESSENTIAL FUNCTION FIELD - 遍历二叉树的方法
    }
}
