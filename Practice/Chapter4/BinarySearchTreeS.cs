using System;
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
			}
			else
			{
				cur.Right = Insert(cur.Right, node);
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
	}
}
