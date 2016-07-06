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

			var sb = new StringBuilder();
			PrintInOrder(Root, sb);
			var str = sb.ToString().Substring(0, sb.Length - 2);
			PrintLn(str);

			PrintLn("===== Printing In Order Finish =====");
		}

		private void PrintInOrder(BinaryTreeNodeS<T> node, StringBuilder sb)
		{
			if (node == null) return;

			PrintInOrder(node.Left, sb);

			sb.Append(node.ToString() + " - ");

			PrintInOrder(node.Right, sb);
		}

		public void PrintPreOrder()
		{
			PrintLn("===== Printing Pre Order Start =====");

			var sb = new StringBuilder();
			PrintPreOrder(Root, sb);
			var str = sb.ToString().Substring(0, sb.Length - 2);
			PrintLn(str);

			PrintLn("===== Printing Pre Order Finish =====");
		}

		private void PrintPreOrder(BinaryTreeNodeS<T> node, StringBuilder sb)
		{
			if (node == null) return;

			sb.Append(node.ToString() + " - ");

			PrintPreOrder(node.Left, sb);

			PrintPreOrder(node.Right, sb);
		}

		public void PrintPostOrder()
		{
			PrintLn("===== Printing Post Order Start =====");

			var sb = new StringBuilder();
			PrintPostOrder(Root, sb);
			var str = sb.ToString().Substring(0, sb.Length - 2);
			PrintLn(str);

			PrintLn("===== Printing Post Order Finish =====");
		}

		private void PrintPostOrder(BinaryTreeNodeS<T> node, StringBuilder sb)
		{
			if (node == null) return;

			PrintPostOrder(node.Left, sb);

			PrintPostOrder(node.Right, sb);

			sb.Append(node.ToString() + " - ");
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
