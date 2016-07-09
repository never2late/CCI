using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class BinaryTreeNodeS<T> : NodeS<T>
	{
		public BinaryTreeNodeS() : base() { }
		public BinaryTreeNodeS(T value) : base(value) { }
		
		public BinaryTreeNodeS<T> Left { get; set; }
		public BinaryTreeNodeS<T> Right { get; set; }

		public bool HasLeftChild()
		{
			return Left != null;
		}

		public bool HasRightChild()
		{
			return Right != null;
		}

		public bool HasChildren()
		{
			return HasLeftChild() || HasRightChild();
		}

        public bool HasBothChildren()
        {
            return HasLeftChild() && HasRightChild();
        }

		public int CompareTo(BinaryTreeNodeS<T> node)
		{
			if (node.Value is int)
			{
				var thisValue = (int)Convert.ChangeType(this.Value, TypeCode.Int32);
				var nodeValue = (int)Convert.ChangeType(node.Value, TypeCode.Int32);

				if (thisValue < nodeValue) return -1;
				else if (thisValue == nodeValue) return 0;
				else return 1;
			}
			else if (node.Value is string)
			{
				var thisValue = (string)Convert.ChangeType(this.Value, TypeCode.String);
				var nodeValue = (string)Convert.ChangeType(node.Value, TypeCode.String);

				return thisValue.CompareTo(nodeValue);
			}

			throw new Exception("Invalid Compare Type");
		}

		public int CompareTo(T value)
		{
			if (value is int)
			{
				var thisValue = (int)Convert.ChangeType(this.Value, TypeCode.Int32);
				var compareValue = (int)Convert.ChangeType(value, TypeCode.Int32);

				if (thisValue < compareValue) return -1;
				else if (thisValue == compareValue) return 0;
				else return 1;
			}
			else if (value is string)
			{
				var thisValue = (string)Convert.ChangeType(this.Value, TypeCode.String);
				var nodeValue = (string)Convert.ChangeType(value, TypeCode.String);

				return thisValue.CompareTo(nodeValue);
			}

			throw new Exception("Invalid Compare Type");
		}

		public bool Remove(T value, BinaryTreeNodeS<T> parent)
		{
			var thisValue = (int) Convert.ChangeType(this.Value, TypeCode.Int32);
			var compareValue = (int) Convert.ChangeType(value, TypeCode.Int32);

			if (compareValue < thisValue)
			{
                return (Left != null) ? Left.Remove(value, this) : false;
			}
			else if (compareValue > thisValue)
			{
                return (Right != null) ? Right.Remove(value, this) : false;
			}
			else
			{
                if (this.HasBothChildren() == true)
                {
                    var maxChild = Left.GetMax();
                    Left.Remove(maxChild.Value, this);
                    Value = maxChild.Value;
                }
                else if (parent.Left == this)
                {
                    parent.Left = (Left != null) ? Left : Right;
                }
                else if (parent.Right == this)
                {
                    parent.Right = (Left != null) ? Left : Right;
                }

                return true;
			}
		}

		public BinaryTreeNodeS<T> GetMax()
		{
			if (Right == null) return this;

            return Right.GetMax();
		}

		public BinaryTreeNodeS<T> GetMin()
		{
			if (Left == null) return this;

            return Left.GetMin();
		}
	}
}
