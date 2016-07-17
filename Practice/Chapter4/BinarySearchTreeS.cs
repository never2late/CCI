using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class BinarySearchTreeS<T> : BinaryTreeS<T>
	{
		public int Count;

		public BinarySearchTreeS() { }

		public void Insert(T value)
		{
			var node = new BinaryTreeNodeS<T>(value);
			Insert(node);
		}

		public void Insert(BinaryTreeNodeS<T> node)
		{
			Root = Insert(Root, node);
		}

		private BinaryTreeNodeS<T> Insert(BinaryTreeNodeS<T> cur, BinaryTreeNodeS<T> node)
		{
			if (cur == null)
			{
				Count++;
				return node;
			}

			var compareResult = node.CompareTo(cur);

			if (compareResult < 0)
			{
				cur.Left = Insert(cur.Left, node);
                cur.Left.Parent = cur;
			}
			else
			{
				cur.Right = Insert(cur.Right, node);
                cur.Right.Parent = cur;
			}

			return cur;
		}

		public bool Contains(T value)
		{
			var toSearch = new BinaryTreeNodeS<T>(value);
			return Contains(toSearch);
		}

		public bool Contains(BinaryTreeNodeS<T> node)
		{
			return Contains(Root, node);
		}

		private bool Contains(BinaryTreeNodeS<T> cur, BinaryTreeNodeS<T> node)
		{
			if (cur == null) return false;

			var compareResult = node.CompareTo(cur);

			if (compareResult == 0) return true;
			else if (compareResult < 0) return Contains(cur.Left, node);
			else return Contains(cur.Right, node);
		}

		public void Remove(T value)
		{
			Root = Remove(Root, value);

			Count--;
		}

		private BinaryTreeNodeS<T> Remove(BinaryTreeNodeS<T> parent, T toDelete)
		{
			if (parent == null) throw new Exception("Nothing to remove");

			var compareTo = CompareTo(toDelete, parent);

			if (compareTo < 0)
			{
				parent.Left = Remove(parent.Left, toDelete);
			}
			else if (compareTo > 0)
			{
				parent.Right = Remove(parent.Right, toDelete);
			}
			else
			{
				if (parent.Left == null) return parent.Right;
				else if (parent.Right == null) return parent.Left;
				else //has both children
				{
					var maxNode = GetMax(parent.Left);
					parent.Value = maxNode.Value;
					parent.Left = Remove(parent.Left, parent.Value);
				}
			}

			return parent;
		}

		private int CompareTo(T toDelete, BinaryTreeNodeS<T> parent)
		{
			var parentValue = (int)Convert.ChangeType(parent.Value, TypeCode.Int32);
			var toDeleteValue = (int)Convert.ChangeType(toDelete, TypeCode.Int32);

			if (toDeleteValue < parentValue) return -1;
			else if (toDeleteValue > parentValue) return 1;
			else return 0;
		}

		public BinaryTreeNodeS<T> GetMax()
		{
			if (Root == null) return null;

			return GetMax(Root);
		}

		private BinaryTreeNodeS<T> GetMax(BinaryTreeNodeS<T> node)
		{
			if (node.Right == null) return node;

			return GetMax(node.Right);
		}

		/* 
			http://stackoverflow.com/questions/14001676/balancing-a-bst
			1. Build a dummy complete tree with n nodes. All the values to each node will be initialized to some garbage value.
			2. Degenerate the original tree into a queue by traversing in-order. 
			3. Traverse the dummy tree in-order and assign dequeued values to the dummy nodes.
		*/
		public void Balance()
		{
			if (Root == null) return;

			PrintLn("\n=========== Balancing BST ===========\n");

			var completeTree = CreateCompleteTree(Count);
			var inOrderQueue = ToInOrderQueue();

			SetInOrder(completeTree.Root, inOrderQueue);

			Root = completeTree.Root;
		}

		private Queue<T> ToInOrderQueue()
		{
			var q = new Queue<T>();
			ToInOrderQueue(Root, q);

			return q;
		}

		private void ToInOrderQueue(BinaryTreeNodeS<T> node, Queue<T> q)
		{
			if (node == null) return;

			ToInOrderQueue(node.Left, q);
			q.Enqueue(node.Value);
			ToInOrderQueue(node.Right, q);
		}

		private void SetInOrder(BinaryTreeNodeS<T> node, Queue<T> q)
		{
			if (node == null) return;

			SetInOrder(node.Left, q);
			node.Value = q.Dequeue();
			SetInOrder(node.Right, q);
		}

        public BinaryTreeNodeS<int> Question3(int[] array)
        {
            return Question3(array, 0, array.Length - 1);
        }

        private BinaryTreeNodeS<int> Question3(int[] array, int start, int end)
        {
            if (start > end) return null;

            int mid = (start + end) / 2;
            var node = new BinaryTreeNodeS<int>(array[mid]);
            node.Left = Question3(array, start, mid - 1);
            node.Right = Question3(array, mid + 1, end);

            return node;
        }

        public Dictionary<int, List<BinaryTreeNodeS<int>>> Question4(BinarySearchTreeS<int> bst)
        {
            if (bst.Root == null) return new Dictionary<int, List<BinaryTreeNodeS<int>>>();

            var dictionary = new Dictionary<int, List<BinaryTreeNodeS<int>>>();
            var q = new Queue<BinaryTreeNodeS<int>>();
            bst.Root.Depth = 0;
            q.Enqueue(bst.Root);

            while (q.Count > 0)
            {
                var node = q.Dequeue();
                var depth = node.Depth;
                if (dictionary.ContainsKey(depth) == false)
                {
                    var list = new List<BinaryTreeNodeS<int>>();
                    dictionary.Add(depth, list);
                }

                dictionary[depth].Add(node);

                if (node.Left != null)
                {
                    node.Left.Depth = depth + 1;
                    q.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    node.Right.Depth = depth + 1;
                    q.Enqueue(node.Right);
                }
            }

            return dictionary;
        }

        public Dictionary<int, List<BinaryTreeNodeS<int>>> Question4DFS(BinarySearchTreeS<int> bst)
        {
            if (bst.Root == null) return new Dictionary<int, List<BinaryTreeNodeS<int>>>();

            var dict = new Dictionary<int, List<BinaryTreeNodeS<int>>>();

            Question4DFS(bst.Root, dict, 0);

            return dict;
        }

        public void Question4DFS(BinaryTreeNodeS<int> node, Dictionary<int, List<BinaryTreeNodeS<int>>> dict, int depth)
        {
            if (node == null) return;

            Question4DFS(node.Left, dict, depth + 1);

            if (dict.ContainsKey(depth) == false)
            {
                var list = new List<BinaryTreeNodeS<int>>();
                dict.Add(depth, list);
            }

            dict[depth].Add(node);

            Question4DFS(node.Right, dict, depth + 1);
        }

        public BinaryTreeNodeS<int> Question5(BinaryTreeNodeS<int> node)
        {
            if (node == null) return null;
            if (node.Parent == null || node.Right != null) return LeftMost(node.Right);

            var cur = node;
            while (node.Parent != null)
            {
                node = node.Parent;
                if (node.Left == cur) return node;
                cur = node;
            }

            return null;
        }

        private BinaryTreeNodeS<int> LeftMost(BinaryTreeNodeS<int> node)
        {
            if (node == null) return null;

            while (node.Left != null) node = node.Left;

            return node;
        }

        public BinaryTreeNodeS<int> Question5PreOrder(BinaryTreeNodeS<int> node)
        {
            if (node == null) return null;
            if (node.Left != null) return node.Left;
            if (node.Right != null) return node.Right;

            var cur = node;
            while (node.Parent != null)
            {
                node = node.Parent;
                if (node.Left == cur && node.Right != null) return node.Right;
                cur = node;
            }

            return null; 
        }

        public BinaryTreeNodeS<int> Question5PostOrder(BinaryTreeNodeS<int> node)
        {
            if (node == null) return null;
            if (node.Parent == null) return null;
            if (node.Parent.Left == node)
            {
                if (node.Parent.Right == null) return node.Parent;

                node = node.Parent.Right;
                while (node.Left != null || node.Right != null)
                {
                    node = (node.Left != null) ? node.Left : node.Right;
                }
                return node;
            }
            if (node.Parent.Right == node) return node.Parent;
            return null;
        }
	}
}
