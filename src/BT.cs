using System;

namespace BST
{
    class BT
    {
        static void Main(string[] args)
        {

            BT<int> topTree = new BT<int>(23, null, null);
            BT<int> leftTree = new BT<int>(21, null, null);
            BT<int> rightTree = new BT<int>(20, null, null);
            BT<int> innerTree = new BT<int>(-1, null, null);

            topTree = BT<int>.SetLeft(topTree, leftTree);
            topTree = BT<int>.SetRight(topTree, rightTree);

            Console.WriteLine("Printing the whole tree:\n" + BT<int>.Print(topTree));
            Console.WriteLine("Result of looking for 20 in the above BT is: " + BT<int>.Search(20, topTree));
            Console.WriteLine();

            BT<int> tt = new BT<int>(23, null, null);

            BT<int>.Insert(ref tt, 21);
            BT<int>.Insert(ref tt, 19);
            BT<int>.Insert(ref tt, 18);
            BT<int>.Insert(ref tt, 1000);
            BT<int>.Insert(ref tt, -1);

            Console.WriteLine("Printing the whole tree:\n" + BT<int>.Print(tt));
            Console.WriteLine("Result of looking for -2 in the above BT is: " + BT<int>.Search(-2, tt));

            Console.ReadKey();
        }
    }

   /// <summary>
   /// Simple Binary Tree implementation using Generics with methods to manipulate, search and print it.
   /// <typeparam name="T">Implements IComperable</typeparam>
   class BT<T> where T : IComparable<T>
    {
        private T data;
        private BT<T> left;
        private BT<T> right;

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="data">Element to be stored in this BT</param>
        public BT(T data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }

        /// <summary>
        /// Sophisticated constructor
        /// </summary>
        /// <param name="data">Data to store</param>
        /// <param name="left">Left node</param>
        /// <param name="right">Right node</param>
        public BT(T data, BT<T> left, BT<T> right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }
        
        /// <summary>
        /// Inserts new data to an already existing tree following the BST principle (less than root -> go left, greater than root -> go right)
        /// </summary>
        /// <param name="tree">Tree we want to expand</param>
        /// <param name="data">Data we want to store in the given tree</param>
        /// <returns> Returns a <c>Bool</c>if the data </returns>
        public static bool Insert(ref BT<T> tree, T data)
        {
            if (tree == null)
            {
                tree = new BT<T>(data, null, null);
            }
            else
            {
                if (data.CompareTo(tree.data) < 0) return Insert(ref tree.left, data);
                else if (data.CompareTo(tree.data) > 0) return Insert(ref tree.right, data);
            }

            return false;
        }

        public static BT<T> SetLeft(BT<T> parent, BT<T> leftChild)
        {
            parent.left = leftChild;

            return parent;
        }

        public static BT<T> SetRight(BT<T> parent, BT<T> rightChild)
        {
            parent.right = rightChild;

            return parent;
        }

        /// <summary>
        /// Get <see cref="String"/> that contains an <bold>in-order</bold> list of all elements present in the given tree
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public static String Print(BT<T> tree)
        {
            if (tree == null) return "";

            return  Print(tree.left) + tree.data.ToString() + ", "+ Print(tree.right);

        }
   
        /// <summary>
        /// Returns a <see cref="Boolean"/> with the corresponding value if the element <paramref name="data"/> is present in the <paramref name="tree"/>
        /// </summary>
        /// <param name="data">Element we want to look for</param>
        /// <param name="tree">Tree we want to search for the given element</param>
        /// <returns></returns>
        public static Boolean Search(T data, BT<T> tree)
        {

            if (tree == null) return false;

            return tree.data.Equals(data) ? true : Search(data, tree.left) || Search(data, tree.right); 

        }

    }
}
