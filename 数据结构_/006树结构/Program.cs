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

            /*Test
             * 
             * 
            BiTree<int> nini = new BiTree<int>(0);
            Node<int> l1 = new Node<int>(11);
            Node<int> r1 = new Node<int>(12);
            nini.Head.LChild = l1;
            nini.Head.RChild = r1;
            Node<int> r1l2 = r1.LChild = new Node<int>(21);
            Node<int> r1l2r3 = r1l2.RChild = new Node<int>(32);
            nini.PreOrder(nini.Head);
            */
            //  BiTree<int> nini = RandomGenerator_BitTree(100);
            //   nini.PreOrder(nini.Head);
            Console.WriteLine("233");
            Console.ReadKey();
        }


        static BiTree<int> RandomGenerator_BitTree(int randommax_numrange, int randommax_layer = 5)
        {
            int trigger = 0;

            int RR(int max)
            {
                Random ran = new Random();
                int a;
                a = ran.Next(0, max);
                return a;
            }

            void Regain(Node<int> root)
            {
                if (trigger == randommax_layer) return;
                trigger++;
                if (trigger <= randommax_layer)
                    Regain(BiTree<int>.InsertL(RR(randommax_numrange), root));
                trigger--;
                if (trigger <= randommax_layer)
                    Regain(BiTree<int>.InsertR(RR(randommax_numrange), root));
            }

            if (randommax_layer < 5 || randommax_layer > 11)
            {
                Console.WriteLine("no less than 5 layers and no more than 11 layers");
                return default(BiTree<int>);
            }

            BiTree<int> beep = new BiTree<int>(RR(randommax_numrange));
            Regain(beep.Head);

            return beep;
        }
    }


    /// <summary>
    /// 二叉树的节点类
    /// </summary>
    class Node<T>
    {
        public T Data; //数据域

        public Node<T> LChild; //左子树
        public Node<T> RChild; //右子树


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
        public Node<T> Head;


        //========================CONSTRUCTION FIELD
        public BiTree()
        {
            Head = null;
        }

        public BiTree(T val)
        {
            Node<T> p = new Node<T>(val);
            Head = p;
        }

        public BiTree(T val, Node<T> lp, Node<T> rp)
        {
            Node<T> p = new Node<T>(val, lp, rp);
            //这个十分有趣，得学学这个方式，没必要另造两个字段，这就他妈够了，巧用之前造的轮子！
            Head = p;
        }
        //========================CONSTRUCTION FIELD
        //========================FUNCTION FIELD

        /// <summary>
        /// 判断是否是空二叉树
        /// </summary>
        /// <returns><c>true</c>, if empty was ised, <c>false</c> otherwise.</returns>
        public bool isEmpty()
        {
            if (Head == null) return true; //不理解为什么这里是head == null 而不是子节点
            else return false;
        }

        /// <summary>
        /// 获取根节点
        /// </summary>
        /// <returns>The root.</returns>
        public Node<T> Root()
        {
            return Head;
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
        /// 将节点p的左子树插入值为val的新节点
        /// </summary>
        /// <param name="val">Value.</param>
        /// <param name="p">P.</param>
        static public Node<T> InsertL(T val, Node<T> p)
        {
            return p.LChild = new Node<T>(val);
        }

        /// <summary>
        /// 将节点p的右子树插入值为val的新节点
        /// </summary>
        /// <param name="val">Value.</param>
        /// <param name="p">P.</param>
        static public Node<T> InsertR(T val, Node<T> p)
        {
            return p.RChild = new Node<T>(val);
        }

        /// <summary>
        /// 若节点不为空，则删除该节点的左子树
        /// </summary>
        /// <returns>The l.</returns>
        /// <param name="p">P.</param>
        static public Node<T> DeleteL(Node<T> p)
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
        static public Node<T> DeleteR(Node<T> p)
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
        static public bool isLeaf(Node<T> p)
        {
            if (p != null && p.LChild == null && p.RChild == null) return true;
            else return false;
        }
        //========================FUNCTION FIELD
        //========================STATIC FUNCTION FIELD

        //========================STATIC FUNCTION FIELD
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
                if (root.LChild != null)
                {
                    id_Line_Pre++;
                    PreOrder(root.LChild);
                    id_Line_Pre--;
                }

                if (root.RChild != null)
                {
                    id_Line_Pre++;
                    PreOrder(root.RChild);
                    id_Line_Pre--;
                }
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

        ///层次遍历，我自己写的，完了对比对比能不能用
        /// 
        /// 
        /// 

        //设置一个队列装载所有的顺序队列
        //这招真他妈好用
        Queue<Node<T>> sq = new Queue<Node<T>>(1000);

        public void LevelOrder_Mine(Node<T> root)
        {
            int trigger = 0;
            if (root == null) return;
            else
            {
                //表示了本节点的数据
                Console.Write("dataContent:\t" + root.Data);

                if (root.LChild != null)
                {
                    sq.Enqueue(root.LChild);
                    trigger++;
                }

                if (root.RChild != null)
                {
                    sq.Enqueue(root.RChild);
                    trigger++;
                }
            }

            if (trigger != 0)
            {
                for (int i = trigger; i > 0; i--)
                {
                    LevelOrder_Mine(sq.Dequeue());
                }
            }
        }

        public void LevelOrder_Teacher(Node<T> root)
        {
            Queue<Node<T>> sq = new Queue<Node<T>>(500);
            //根节点入队
            sq.Enqueue(root);
            //队列非空，节点没有处理完
            while (sq.Count != 0)
            {
                //节点出队
                Node<T> tmp = sq.Dequeue();
                //处理当前节点
                Console.Write("dataContent:\t" + tmp.Data);
                //将当前的节点的左孩子入队
                if (tmp.LChild != null) sq.Enqueue(tmp.LChild);
                //将当前的节点的右孩子入队
                if (tmp.RChild != null) sq.Enqueue(tmp.RChild);
            }
        }


        //========================ESSENTIAL FUNCTION FIELD - 遍历二叉树的方法
    }
}