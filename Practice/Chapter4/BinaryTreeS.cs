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
			PrintLn("===== Printing In Order Start =====");

			PrintInOrder(Root);

			PrintLn("===== Printing In Order Finish =====");
		}

		private void PrintInOrder(BinaryTreeNodeS<T> node)
		{
			if (node == null) return;

			PrintInOrder(node.Left);

			PrintLn(node.ToString());

			PrintInOrder(node.Right);
		}

		public void PrintPreOrder()
		{
			PrintLn("===== Printing Pre Order Start =====");

			PrintPreOrder(Root);

			PrintLn("===== Printing Pre Order Finish =====");
		}

		private void PrintPreOrder(BinaryTreeNodeS<T> node)
		{
			if (node == null) return;

			PrintLn(node.ToString());

			PrintPreOrder(node.Left);

			PrintPreOrder(node.Right);
		}

		public void PrintPostOrder()
		{
			PrintLn("===== Printing Post Order Start =====");

			PrintPostOrder(Root);

			PrintLn("===== Printing Post Order Finish =====");
		}

		private void PrintPostOrder(BinaryTreeNodeS<T> node)
		{
			if (node == null) return;

			PrintPostOrder(node.Left);

			PrintPostOrder(node.Right);

			PrintLn(node.ToString());
		}

		public void PrintAllOrders()
		{
			PrintInOrder();
			PrintLn();
			PrintPreOrder();
			PrintLn();
			PrintPostOrder();
		}
	}
}
