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

		public bool isBalanced()
		{
			if (Root == null) return true;

			return GetMaxDepth(Root) - GetMinDepth(Root) < 2;
		}

		protected int GetMaxDepth(BinaryTreeNodeS<T> node)
		{
			if (node == null) return 0;

			return 1 + Math.Max(GetMaxDepth(node.Left), GetMaxDepth(node.Right));
		}

        protected int GetMinDepth(BinaryTreeNodeS<T> node)
		{
			if (node == null) return 0;

			return 1 + Math.Min(GetMinDepth(node.Left), GetMinDepth(node.Right));
		}

		public BinaryTreeNodeS<T> GetFirstCommonParent(BinaryTreeNodeS<T> n1, BinaryTreeNodeS<T> n2)
		{
			if (Root == null || n1 == null || n2 == null) return null;
			if (Root.Value.Equals(n1.Value) || Root.Value.Equals(n2.Value)) return null;

			return GetFirstCommonParent(Root, n1, n2);
		}

		private BinaryTreeNodeS<T> GetFirstCommonParent(BinaryTreeNodeS<T> cur, BinaryTreeNodeS<T> n1, BinaryTreeNodeS<T> n2)
		{
			if (cur == null) return null;

            if ((Contains(cur.Left, n1) && Contains(cur.Right, n2)) ||
                (Contains(cur.Left, n2) && Contains(cur.Right, n1)))
            {
                return cur;
            }
			else if (Contains(cur.Left, n1) && Contains(cur.Left, n2))
			{
                if (cur.Left == n1 || cur.Left == n2) return cur;
				else return GetFirstCommonParent(cur.Left, n1, n2);
			}
			else if (Contains(cur.Right, n1) && Contains(cur.Right, n2))
			{
                if (cur.Right == n1 || cur.Right == n2) return cur;
				else return GetFirstCommonParent(cur.Right, n1, n2);
			}

			return null;
		}

		public BinaryTreeNodeS<T> GetParentOf(BinaryTreeNodeS<T> node)
		{
			if (Root == null) return null;

			return GetParentOf(Root, node);
		}

		private BinaryTreeNodeS<T> GetParentOf(BinaryTreeNodeS<T> cur, BinaryTreeNodeS<T> node)
		{
			if (cur == null) return null;
			if (cur.Left != null && cur.Left.Value.Equals(node.Value) ||
				cur.Right != null && cur.Right.Value.Equals(node.Value)) return cur;

			if (Contains(cur.Left, node)) return GetParentOf(cur.Left, node);
			else if (Contains(cur.Right, node)) return GetParentOf(cur.Right, node);

			return null;
		}

		public bool Contains(BinaryTreeNodeS<T> node)
		{
			if (Root == null) return false;

			return Contains(Root, node);
		}

		private bool Contains(BinaryTreeNodeS<T> cur, BinaryTreeNodeS<T> node)
		{
			if (cur == null) return false;

			if (cur.Value.Equals(node.Value) == true) return true;

			if (Contains(cur.Left, node) == true) return true;
			if (Contains(cur.Right, node) == true) return true;

			return false;
		}

		public bool IsSubTreeOf(BinaryTreeS<T> tree)
		{
			var subTreeList = ToLevelOrderList();
			if (subTreeList == null) return false;

			var node = tree.GetNode(Root.Value);
			if (node == null) return false;

			var q = new Queue<BinaryTreeNodeS<T>>();
			var tmpList = new List<BinaryTreeNodeS<T>>();
			var i = 0;
			q.Enqueue(node);

			while (q.Count > 0 && i < subTreeList.Count)
			{
				var n = q.Dequeue();
				tmpList.Add(n);
				if (subTreeList[i].Equals(tmpList[i]) == false) return false;

				if (n.Left != null) q.Enqueue(n.Left);
				if (n.Right != null) q.Enqueue(n.Right);
			}

			if (subTreeList.Count > tmpList.Count) return false;

			return true;
		}

        public bool isSub(BinaryTreeNodeS<int> t1, BinaryTreeNodeS<int> t2)
        {
            if (t2 == null) return true;//empty tree is always a subtree

            return isSubTree(t1, t2);
        }

        private bool isSubTree(BinaryTreeNodeS<int> n1, BinaryTreeNodeS<int> n2)
        {
            if (n1 == null) return false;

            if (n1.Value == n2.Value)
            {
                if (isMatch(n1, n2)) return true;
            }

            return isSubTree(n1.Left, n2) || isSubTree(n1.Right, n2);
        }

        private bool isMatch(BinaryTreeNodeS<int> n1, BinaryTreeNodeS<int> n2)
        {
            if (n2 == null && n1 == null) return true;
            if (n2 != null && n1 == null) return false;
            if (n2 == null && n1 != null) return true;
            if (n1.Value != n2.Value) return false;

            return isMatch(n1.Left, n2.Left) && isMatch(n1.Right, n2.Right);
        }

        private BinaryTreeNodeS<T> GetNode(T val)
		{
			return GetNode(Root, val);
		}

		private BinaryTreeNodeS<T> GetNode(BinaryTreeNodeS<T> node, T val)
		{
			if (node == null) return null;
			if (node.Value.Equals(val)) return node;

			var leftResult = GetNode(node.Left, val);
			if (leftResult != null) return leftResult;

			return GetNode(node.Right, val);
		}

		public List<BinaryTreeNodeS<T>> ToLevelOrderList()
		{ 
			if (Root == null) return null;
			
			var list = new List<BinaryTreeNodeS<T>>();
			var q = new Queue<BinaryTreeNodeS<T>>();
			q.Enqueue(Root);

			while (q.Count > 0)
			{
				var node = q.Dequeue();
				list.Add(node);

				if (node.Left != null) q.Enqueue(node.Left);
				if (node.Right != null) q.Enqueue(node.Right);
			}

			return list;
		}

		public void PrintPathsThatSumTo(int n)
		{
			if (Root == null) return;

            var q = new Queue<BinaryTreeNodeS<T>>();
            q.Enqueue(Root);

            while (q.Count > 0)
            {
                var node = q.Dequeue();
                if (node.Left != null) q.Enqueue(node.Left);
                if (node.Right != null) q.Enqueue(node.Right);

                PrintPathsThatSumTo(node, 0, n, "");
            }
            //PrintPathsThatSumTo(Root, n);
        }

        private void PrintPathsThatSumTo(BinaryTreeNodeS<T> node, int n)
        {
            if (node == null) return;
            PrintPathsThatSumTo(node, 0, n, "");
            PrintPathsThatSumTo(node.Left, n);
            PrintPathsThatSumTo(node.Right, n);
        }

		private void PrintPathsThatSumTo(BinaryTreeNodeS<T> node, int cur, int n, string str)
		{
			if (node == null) return;
			
			var nodeValue = (int)Convert.ChangeType(node.Value, TypeCode.Int32);
			str += (nodeValue + "+");
			var sum = nodeValue + cur;

			if (sum == n)
			{
				PrintLn(str.Substring(0, str.Length - 1) + "=" + sum);
			}

			PrintPathsThatSumTo(node.Left, sum, n, str);
			PrintPathsThatSumTo(node.Right, sum, n, str);
		}
	}
}
