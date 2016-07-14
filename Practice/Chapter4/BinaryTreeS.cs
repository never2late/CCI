using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class BinaryTreeS<T> : Util
	{
		public BinaryTreeS() { }
		public BinaryTreeS(BinaryTreeNodeS<T> root)
		{
			Root = root;
		}

		public BinaryTreeNodeS<T> Root { get; set; }
		public BinaryTreePrintMode PrintMode { get; set; }

		public void Print()
		{
			if (PrintMode == BinaryTreePrintMode.Unknown)
			{
				return;
			}
			else if (PrintMode == BinaryTreePrintMode.InOrder)
			{
				PrintInOrder();
			}
			else if (PrintMode == BinaryTreePrintMode.PreOrder)
			{
				PrintPreOrder();
			}
			else if (PrintMode == BinaryTreePrintMode.PostOrder)
			{
				PrintPostOrder();
			}
		}

		public void PrintInOrder()
		{
			PrintLn("===== Printing In-Order Start =====");

			var sb = new StringBuilder();
			PrintInOrder(Root, sb);
			var str = sb.ToString().Substring(0, sb.Length - 2);
			PrintLn(str);

			PrintLn("===== Printing In-Order Finish =====");
		}

		private void PrintInOrder(BinaryTreeNodeS<T> node, StringBuilder sb)
		{
			if (node == null) return;

			PrintInOrder(node.Left, sb);

			sb.Append(node.ToString() + ", ");

			PrintInOrder(node.Right, sb);
		}

		public void PrintPreOrder()
		{
			PrintLn("===== Printing Pre-Order Start =====");

			var sb = new StringBuilder();
			PrintPreOrder(Root, sb);
			var str = sb.ToString().Substring(0, sb.Length - 2);
			PrintLn(str);

			PrintLn("===== Printing Pre-Order Finish =====");
		}

		private void PrintPreOrder(BinaryTreeNodeS<T> node, StringBuilder sb)
		{
			if (node == null) return;

			sb.Append(node.ToString() + ", ");

			PrintPreOrder(node.Left, sb);

			PrintPreOrder(node.Right, sb);
		}

		public void PrintPostOrder()
		{
			PrintLn("===== Printing Post-Order Start =====");

			var sb = new StringBuilder();
			PrintPostOrder(Root, sb);
			var str = sb.ToString().Substring(0, sb.Length - 2);
			PrintLn(str);

			PrintLn("===== Printing Post-Order Finish =====");
		}

		private void PrintPostOrder(BinaryTreeNodeS<T> node, StringBuilder sb)
		{
			if (node == null) return;

			PrintPostOrder(node.Left, sb);

			PrintPostOrder(node.Right, sb);

			sb.Append(node.ToString() + ", ");
		}

        public void PrintLevelOrder()
        {
            PrintLn("===== Printing Level-Order Start =====");

            if (Root != null)
            {
                var sb = new StringBuilder();
                var q = new Queue<BinaryTreeNodeS<T>>();

                q.Enqueue(Root);

                while (q.Count > 0)
                {
                    var node = q.Dequeue();
                    sb.Append(node.ToString() + ", ");
                    if (node.Left != null) q.Enqueue(node.Left);
                    if (node.Right != null) q.Enqueue(node.Right);
                }

                var str = sb.ToString().Substring(0, sb.Length - 2);
                PrintLn(str);
            }

            PrintLn("===== Printing Level-Order Finish =====");
        }

		public void PrintAllOrders()
		{
			PrintInOrder();
			PrintLn();
			PrintPreOrder();
			PrintLn();
			PrintPostOrder();
			PrintLn();
			PrintLevelOrder();
		}

		public int GetHeight()
		{
			if (Root == null) return 0;

			return GetHeight(Root);
		}

		private int GetHeight(BinaryTreeNodeS<T> node)
		{
			if (node == null) return -1;

			return 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
		}
		/* 
			http://www.geeksforgeeks.org/given-linked-list-representation-of-complete-tree-convert-it-to-linked-representation/
			1. Create an empty root node and enqueue it to a temporary queue. 
			2. Dequeue a node and assign next two values to its left and right. 
			3. Enqueue left and right nodes into the queue. 
			4. Repeat 2-4 until finished. 
		*/
		public BinaryTreeS<T> CreateCompleteTree(int count)
		{
			var completeTree = new BinaryTreeS<T>();
			var q = new Queue<BinaryTreeNodeS<T>>();

			completeTree.Root = new BinaryTreeNodeS<T>();
			q.Enqueue(completeTree.Root);

			for (var i = 1; i < count; i+=2)
			{
				var node = q.Dequeue();
				node.Left = new BinaryTreeNodeS<T>();
				node.Right = (i + 1 < count) ? new BinaryTreeNodeS<T>() : null;

				q.Enqueue(node.Left);
				if (node.Right != null) q.Enqueue(node.Right);
			}

			return completeTree;
		}
	}
}
