using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class BaseNode<T> { }

	public class NodeS<T> : BaseNode<T>
	{
		public NodeS() { }

		public NodeS(T value)
		{
			this.Value = value;
		}

		public String ToString()
		{
			return this.Value + "";
		}

		public T Value { get; set; }
		public String Name { get; set; }
	}
}
