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
	}
}
