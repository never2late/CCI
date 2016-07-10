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

		public bool Remove(T value)
		{
            if (Root == null) return false;

            if (Root.Value.Equals(value) == true)
            {
                var tmpRoot = new BinaryTreeNodeS<T>();
                tmpRoot.Left = Root;
                Remove(tmpRoot, Root, value);
                Root = tmpRoot.Left;

                return true;
            }
            else
            {
                return Remove(null, Root, value);
            }
		}

        private bool Remove(BinaryTreeNodeS<T> parent, BinaryTreeNodeS<T> cur, T value)
        {
            if (cur == null) return false;

            var curValue = (int)Convert.ChangeType(cur.Value, TypeCode.Int32);
            var compareValue = (int)Convert.ChangeType(value, TypeCode.Int32);

            if (compareValue < curValue)
            {
                return Remove(cur, cur.Left, value);
            }
            else if (compareValue > curValue)
            {
                return Remove(cur, cur.Right, value);
            }
            else
            {
                if (cur.HasBothChildren() == true)
                {
                    var maxNode = GetMax(cur.Left);
                    cur.Value = maxNode.Value;
                    Remove(cur, cur.Left, cur.Value);
                }
                else if (parent.Left == cur)
                {
                    parent.Left = (cur.Left != null) ? cur.Left : cur.Right;
                }
                else
                {
                    parent.Right = (cur.Left != null) ? cur.Left : cur.Right;
                }

                return true;
            }
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
	}
}
