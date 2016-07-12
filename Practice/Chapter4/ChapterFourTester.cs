using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class ChapterFourTester : Util
	{
		public void Test(int question, int option)
		{
			if (question == 0)
			{
				var tree = GetSampleBST(option);
				tree.PrintMode = BinaryTreePrintMode.InOrder;
			}
		}

		private BinarySearchTreeS<int> GetSampleBST(int option = 0)
		{
			var tree = new BinarySearchTreeS<int>();

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

			return tree;
		}
	}
}
