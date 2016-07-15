using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Chapter4;

namespace Practice
{
	public class ChapterFourTester : Util
	{
		public void Test(int question, int option)
		{
			if (question == -1)
			{
				var adjList = GetSampleAdjList(question, option);
			}
			else if (question == 0)
			{
				var tree = GetSampleBST(question, option);
				tree.PrintMode = BinaryTreePrintMode.InOrder;
			}
			else if (question == 1)
			{
				var tree = GetSampleBST(question, option);
			}
			else if (question == 2)
			{
				var adjList = GetSampleAdjList(question, option);
			}
		}

		private AdjListS GetSampleAdjList(int question, int option = 0)
		{
			AdjListS adjList = null;

			if (question == -1)
			{
				if (option == 0)
				{
					adjList = new AdjListS(8);

					adjList.AddBidirectedEdge(2, 0);
					adjList.AddBidirectedEdge(2, 1);
					adjList.AddBidirectedEdge(2, 3);
					adjList.AddBidirectedEdge(2, 4);
					adjList.AddBidirectedEdge(5, 1);
					adjList.AddBidirectedEdge(5, 6);
					adjList.AddBidirectedEdge(5, 7);

					adjList.Print();
				}
				else if (option == 1)
				{
					adjList = new AdjListS(7);

					adjList.AddBidirectedEdge(0, 1);
					adjList.AddBidirectedEdge(0, 2);
					adjList.AddBidirectedEdge(0, 3);
					adjList.AddBidirectedEdge(1, 4);
					adjList.AddBidirectedEdge(1, 5);
					adjList.AddBidirectedEdge(2, 6);
					adjList.AddBidirectedEdge(3, 5);

					//adjList.Print();
					adjList.DepthFirstSearch();
				}
				else if (option == 2)
				{
					adjList = new AdjListS(8);

					adjList.AddEdge(0, 1);
					adjList.AddEdge(0, 2);
					adjList.AddEdge(1, 3);
					adjList.AddEdge(1, 4);
					adjList.AddEdge(2, 5);
					adjList.AddEdge(2, 6);
					adjList.AddEdge(4, 7);

					//adjList.Print();
					adjList.BreadthFirstSearch();
				}
			}
			else if (question == 2)
			{
				if (option == 0)
				{
					adjList = new AdjListS(10);

					adjList.AddEdge(0, 1);
					adjList.AddEdge(0, 2);
					adjList.AddEdge(0, 3);
					var isValidPath = adjList.IsValidPath(0, 10);
					PrintLn("IsValidPath : " + isValidPath);

					adjList.AddEdge(3, 4);
					adjList.AddEdge(4, 5);
					adjList.AddEdge(5, 6);
					adjList.AddEdge(6, 7);
					adjList.AddEdge(7, 8);
					adjList.AddEdge(8, 9);
					isValidPath = adjList.IsValidPath(0, 9);
					PrintLn("IsValidPath : " + isValidPath);
				}
			}

			return adjList;
		}

		private BinarySearchTreeS<int> GetSampleBST(int question, int option = 0)
		{
			var tree = new BinarySearchTreeS<int>();

			if (question == 0)
			{
				if (option == 0)
				{
					tree = new BinarySearchTreeS<int>();

					tree.Insert(5);
					tree.Insert(0);
					tree.Insert(10);
					tree.Insert(15);

					tree.PrintAllOrders();
				}
				else if (option == 1)
				{
					tree = new BinarySearchTreeS<int>();

					tree.Insert(7);
					tree.Insert(1);
					tree.Insert(9);
					tree.Insert(0);
					tree.Insert(3);
					tree.Insert(8);
					tree.Insert(10);
					tree.Insert(2);
					tree.Insert(5);
					tree.Insert(4);
					tree.Insert(6);

					tree.PrintAllOrders();
				}
				else if (option == 2)
				{
					tree = new BinarySearchTreeS<int>();

					tree.Insert(7);
					tree.Insert(4);
					tree.Insert(4);
					tree.Insert(12);
					tree.Insert(2);
					tree.Insert(6);
					tree.Insert(9);
					tree.Insert(19);
					tree.Insert(3);
					tree.Insert(5);
					tree.Insert(8);
					tree.Insert(11);
					tree.Insert(15);
					tree.Insert(15);
					tree.Insert(20);

					tree.PrintAllOrders();

					//for (var i = 0; i <= 30; i++)
					//{
					//	PrintLn("Tree contains " + i + " : " + tree.Contains(i));
					//}
				}
				else if (option == 3)
				{
					tree = new BinarySearchTreeS<int>();

					tree.Insert(15);
					tree.Insert(0);
					tree.Insert(30);
					tree.Insert(-5);
					tree.Insert(2);
					tree.Insert(-10);
					tree.Insert(-3);
					tree.Insert(1);
					tree.Insert(3);
					tree.Insert(14);
					tree.Insert(10);
					tree.Insert(-1);
					tree.Insert(-2);

					PrintLn("COUNT : " + tree.Count);

					tree.Remove(15);
					tree.Remove(14);
					tree.Remove(10);
					tree.Remove(3);
					tree.Remove(2);
					tree.Remove(1);

					PrintLn("COUNT : " + tree.Count);

					tree.PrintAllOrders();
					PrintLn();
					var height = tree.GetHeight();
					PrintLn("Height : " + height);

					tree.Balance();
					tree.PrintAllOrders();
					PrintLn();
					height = tree.GetHeight();
					PrintLn("Height : " + height);
				}
			}
			else if (question == 1)
			{
				if (option == 0)
				{
					tree = new BinarySearchTreeS<int>();

					tree.Insert(15);
					tree.Insert(0);
					tree.Insert(30);
					tree.Insert(-5);
					tree.Insert(2);
					tree.Insert(-10);
					tree.Insert(-3);
					tree.Insert(1);
					tree.Insert(3);
					tree.Insert(14);
					tree.Insert(10);
					tree.Insert(-1);
					tree.Insert(-2);

					var isBalanced = tree.isBalanced();
					PrintLn("Is Balanced : " + isBalanced);

					tree = new BinarySearchTreeS<int>();

					tree.Insert(2);
					tree.Insert(-2);
					tree.Insert(14);
					isBalanced = tree.isBalanced();
					PrintLn("Is Balanced : " + isBalanced);

					tree.Insert(-5);
					isBalanced = tree.isBalanced();
					PrintLn("Is Balanced : " + isBalanced);

					tree.Insert(0);
					tree.Insert(10);
					isBalanced = tree.isBalanced();
					PrintLn("Is Balanced : " + isBalanced);

					tree.Insert(-10);
					isBalanced = tree.isBalanced();
					PrintLn("Is Balanced : " + isBalanced);

					tree.Insert(15);
					isBalanced = tree.isBalanced();
					PrintLn("Is Balanced : " + isBalanced);
				}
			}

			return tree;
		}
	}
}
