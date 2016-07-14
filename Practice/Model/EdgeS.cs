using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Model
{
	public class EdgeS
	{
		public int Vertex { get; set; }
		public int Cost { get; set; }

		public EdgeS(int vertex, int cost)
		{
			Vertex = vertex;
			Cost = cost;
		}

		public EdgeS(int vertex)
		{
			Vertex = vertex;
			Cost = 0;
		}

		public bool Equals(EdgeS edge)
		{
			if (edge == null) return false;

			return Vertex == edge.Vertex;
		}
	}
}
