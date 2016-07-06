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
				var root = GetSampleRoot(0);

				var binaryTree = new BinaryTreeS<int>(root);
				binaryTree.PrintMode = BinaryTreePrintMode.InOrder;

				binaryTree.PrintAllOrders();
			}
		}

		private BinaryTreeNodeS<int> GetSampleRoot(int t = 0)
		{
			var root = new BinaryTreeNodeS<int>();

			if (t == 0)
			{
				root = new BinaryTreeNodeS<int>(2);
				var leftNode = new BinaryTreeNodeS<int>(1);
				var rightNode = new BinaryTreeNodeS<int>(3);

				root.Left = leftNode;
				root.Right = rightNode;
			}

			return root;
		}
	}
}
