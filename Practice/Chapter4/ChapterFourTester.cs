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
		public void Test(int q, int o)
		{
			//graph problems
			if (q == -1 || q == 2)
			{
				var adjList = GetSampleAdjList(q, o);
			} //binary search tree problems
			else if (q == 0 || q == 1 || q == 3 || q == 4 || q == 5)
			{
				var tree = GetSampleBST(q, o);
			}
			else if (q == 6)
			{
				var tree = GetSampleBinaryTree(q, o);
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
                    var isValidPath = adjList.IsValidPathByDepthFirstSearch(0, 10);
                    PrintLn("IsValidPath - Depth First: " + isValidPath);

                    adjList.AddEdge(3, 4);
                    adjList.AddEdge(4, 5);
                    adjList.AddEdge(5, 6);
                    adjList.AddEdge(6, 7);
                    adjList.AddEdge(7, 8);
                    adjList.AddEdge(8, 9);
                    isValidPath = adjList.IsValidPathByDepthFirstSearch(0, 9);
                    PrintLn("IsValidPath - Depth First: " + isValidPath);
                }
                else if (option == 1)
                {
                    adjList = new AdjListS(10);

                    adjList.AddEdge(0, 1);
                    adjList.AddEdge(0, 2);
                    adjList.AddEdge(0, 3);
                    var isValidPath = adjList.IsValidPathByBreadthFirstSearch(0, 10);
                    PrintLn("IsValidPath - Breadth First: " + isValidPath);

                    adjList.AddEdge(3, 4);
                    adjList.AddEdge(4, 5);
                    adjList.AddEdge(5, 6);
                    adjList.AddEdge(6, 7);
                    adjList.AddEdge(7, 8);
                    adjList.AddEdge(8, 9);
                    isValidPath = adjList.IsValidPathByBreadthFirstSearch(0, 9);
                    PrintLn("IsValidPath - Breadth First: " + isValidPath);
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
			else if (question == 3)
			{
				int n = 8;
				var array = new int[n];
				for (int i = 0; i < n; i++)
				{
					array[i] = i;
				}

				tree.Root = tree.Question3(array);

				tree.PrintLevelOrder();
				tree.PrintInOrder();
			}
			else if (question == 4)
			{
				//int n = 8;
				//var array = new int[n];
				//for (int i = 0; i < n; i++)
				//{
				//    array[i] = i;
				//}

				//tree.Root = tree.Question3(array);

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
				var dict = tree.Question4(tree);
				if (option == 1) dict = tree.Question4DFS(tree);

				tree.PrintLevelOrder();
				var sb = new StringBuilder();

				for (var i = 0; i < dict.Count; i++)
				{
					sb.Append("depth " + i + " : ");
					var depthList = dict[i];
					foreach (var depthNode in depthList)
					{
						sb.Append(depthNode.Value + ", ");
					}
					sb.Append("\n");
				}

				PrintLn(sb.ToString());
			}

			else if (question == 5)
			{
				var node1 = new BinaryTreeNodeS<int>(15);
				var node2 = new BinaryTreeNodeS<int>(0);
				var node3 = new BinaryTreeNodeS<int>(30);
				var node4 = new BinaryTreeNodeS<int>(-5);
				var node5 = new BinaryTreeNodeS<int>(2);
				var node6 = new BinaryTreeNodeS<int>(-10);
				var node7 = new BinaryTreeNodeS<int>(-3);
				var node8 = new BinaryTreeNodeS<int>(1);
				var node9 = new BinaryTreeNodeS<int>(3);
				var node10 = new BinaryTreeNodeS<int>(14);
				var node11 = new BinaryTreeNodeS<int>(10);
				var node12 = new BinaryTreeNodeS<int>(-1);
				var node13 = new BinaryTreeNodeS<int>(-2);
				var node14 = new BinaryTreeNodeS<int>(45);
				var node15 = new BinaryTreeNodeS<int>(20);
				var node16 = new BinaryTreeNodeS<int>(17);
				var node17 = new BinaryTreeNodeS<int>(25);
				var node18 = new BinaryTreeNodeS<int>(22);
				tree.Insert(node1);
				tree.Insert(node2);
				tree.Insert(node3);
				tree.Insert(node4);
				tree.Insert(node5);
				tree.Insert(node6);
				tree.Insert(node7);
				tree.Insert(node8);
				tree.Insert(node9);
				tree.Insert(node10);
				tree.Insert(node11);
				tree.Insert(node12);
				tree.Insert(node13);
				tree.Insert(node14);
				tree.Insert(node15);
				tree.Insert(node16);
				tree.Insert(node17);
				tree.Insert(node18);
				BinaryTreeNodeS<int>[] nodeList = {
					node1, node2, node3, node4, node5, node6, node7,
					node8, node9, node10, node11, node12, node13, node14,
					node15, node16, node17, node18
				};

				BinaryTreeNodeS<int> result = null;
				if (option == 0)
				{
					tree.PrintInOrder();
					PrintLn("In-Order Successor List -----");
					for (var i = 0; i < nodeList.Length; i++)
					{
						var testNode = nodeList[i];
						result = tree.Question5(testNode);
						PrintLn("Successor of " + testNode.Value + " : " + ((result == null) ? "none" : result.Value + ""));
					}
				}
				else if (option == 1)
				{
					tree.PrintPreOrder();
					PrintLn("Pre-Order Successor List -----");
					for (var i = 0; i < nodeList.Length; i++)
					{
						var testNode = nodeList[i];
						result = tree.Question5PreOrder(testNode);
						PrintLn("Successor of " + testNode.Value + " : " + ((result == null) ? "none" : result.Value + ""));
					}
				}
				else if (option == 2)
				{
					tree.PrintPostOrder();
					PrintLn("Post-Order Successor List -----");
					for (var i = 0; i < nodeList.Length; i++)
					{
						var testNode = nodeList[i];
						result = tree.Question5PostOrder(testNode);
						PrintLn("Successor of " + testNode.Value + " : " + ((result == null) ? "none" : result.Value + ""));
					}
				}
			}

            return tree;
		}

		private BinaryTreeS<int> GetSampleBinaryTree(int question, int option)
		{
			var tree = new BinaryTreeS<int>();

			if (question == 6)
			{
				var node1 = new BinaryTreeNodeS<int>(1);
				var node2 = new BinaryTreeNodeS<int>(2);
				var node3 = new BinaryTreeNodeS<int>(3);
				var node4 = new BinaryTreeNodeS<int>(4);
				var node5 = new BinaryTreeNodeS<int>(5);
				var node6 = new BinaryTreeNodeS<int>(6);
				var node7 = new BinaryTreeNodeS<int>(7);
				var node8 = new BinaryTreeNodeS<int>(8);
				var node9 = new BinaryTreeNodeS<int>(9);
				var node10 = new BinaryTreeNodeS<int>(10);
				var node11 = new BinaryTreeNodeS<int>(11);
				var node12 = new BinaryTreeNodeS<int>(12);
				var node13 = new BinaryTreeNodeS<int>(13);
				var node14 = new BinaryTreeNodeS<int>(14);
				var node15 = new BinaryTreeNodeS<int>(15);

				node1.Left = node2;
				node1.Right = node3;
				node2.Left = node4;
				node2.Right = node5;
				node3.Left = node6;
				node3.Right = node7;
				node4.Left = node8;
				node4.Right = node9;
				node5.Left = node10;
				node5.Right = node11;
				node6.Left = node12;
				node6.Right = node13;
				node7.Left = node14;
				node7.Right = node15;

				tree.Root = node1;
				tree.PrintLevelOrder();

				var n1 = node12;
				var n2 = node7;

				var firstCommonParent = tree.GetFirstCommonParent(n1, n2);
				PrintLn();
				PrintLn("First common parent of nodes " + n1.Value + " and " + n2.Value + " : " + firstCommonParent.Value);
			}

			return tree;
		}
	}
}
