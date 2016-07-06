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
	}
}
