using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class ChapterFourTester : Util
	{
		public void Test(int q)
		{
			if (q == 0)
			{
				var tree = GetSampleBST(0);
				tree.PrintMode = BinaryTreePrintMode.InOrder;

				tree.PrintAllOrders();
			}
		}

		private BinarySearchTreeS<int> GetSampleBST(int t = 0)
		{
			var tree = new BinarySearchTreeS<int>();

			if (t == 0)
			{
				tree = new BinarySearchTreeS<int>();

				tree.Insert(10);
				tree.Insert(1);
				tree.Insert(0);
			}

			return tree;
		}
	}
}
