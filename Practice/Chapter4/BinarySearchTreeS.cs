using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class BinarySearchTreeS<T> : BinaryTreeS<T>
	{
		private static BinaryTreeNodeS<T>[] treeList = new BinaryTreeNodeS<T>[256];

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
			if (cur == null) return node;

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
			Root.Remove(value, null);
		}

		private void Remove(BinaryTreeNodeS<T> toDelete, BinaryTreeNodeS<T> parent)
		{
			var compareResult = parent.CompareTo(toDelete);
			if (compareResult == 0)
			{
				if (toDelete.HasLeftChild() == true)
				{
					PercolateMaxUp(toDelete);
				}
			}
			else if (compareResult < 0)
			{
				Remove(toDelete.Left);
			}
			else
			{
				Remove(toDelete.Right);
			}
		}

		private void PercolateMaxUp(BinaryTreeNodeS<T> node)
		{
			var maxNode = GetMax(node.Left);
			RemoveMax(node.Left);
			node.Value = maxNode.Value;
		}

		public BinaryTreeNodeS<T> RemoveMax(BinaryTreeNodeS<T> node)
		{
			if (node == null) return null;

			if (node.HasRightChild() == true)
			{
				node.Right = RemoveMax(node.Right);
				return node;
			}
			else if (node.HasLeftChild() == true)
			{
				return node.Left;
			}

			return null;
		}
	}
}
