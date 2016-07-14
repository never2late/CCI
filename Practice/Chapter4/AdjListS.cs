using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Model;

namespace Practice.Chapter4
{
	public class AdjListS : Util
	{
		private List<EdgeS>[] vertexList;

		public AdjListS(int count)
		{
			vertexList = new List<EdgeS>[count];

			for (int i = 0; i < count; i++)
			{
				vertexList[i] = new List<EdgeS>();
			}
		}

		public void DepthFirstSearch()
		{
			if (IsEmptyList() == true) return;

			PrintLn("Performing Depth First Search...\n");

			var hashSet = new HashSet<int>();
			DepthFirstSearch(0, hashSet);
		}

		public void DepthFirstSearch(int vertex, HashSet<int> hashSet)
		{
			hashSet.Add(vertex);
			var edgeList = vertexList[vertex];
			
			Print(vertex + " - ");

			foreach (var edge in edgeList)
			{
				if (hashSet.Contains(edge.Vertex) == true) continue;

				DepthFirstSearch(edge.Vertex, hashSet);
			}
		}

		public void BreadthFirstSearch()
		{
			if (IsEmptyList() == true) return;

			PrintLn("Performing Breadth First Search...\n");

			var q = new Queue<int>();
			q.Enqueue(0);

            while (q.Count > 0)
            {
                var vertex = q.Dequeue();
                var edgeList = vertexList[vertex];

                Print(vertex + " - ");

                foreach (var edge in edgeList)
                {
                    q.Enqueue(edge.Vertex);
                }
            }
        }

		public void AddEdge(int from, int to, int cost)
		{
			if (IsEmptyList() == true) return;

			var edge = new EdgeS(to, cost);
			vertexList[from].Add(edge);
		}

		public void AddEdge(int from, int to)
		{
			AddEdge(from, to, 0);
		}

		public void AddBidirectedEdge(int v1, int v2, int cost)
		{
			AddEdge(v1, v2, cost);
			AddEdge(v2, v1, cost);
		}

		public void AddBidirectedEdge(int v1, int v2)
		{
			AddBidirectedEdge(v1, v2, 0);
		}

		public void RemoveEdge(int from, int to)
		{
			if (IsEmptyList() == true) return;

			var edgeList = vertexList[from];
			edgeList.Remove(new EdgeS(to));
		}

		public void RemoveBidirectedEdge(int v1, int v2)
		{
			if (IsEmptyList() == true) return;

			RemoveEdge(v1, v2);
			RemoveEdge(v2, v1);
		}

		private bool IsEmptyList()
		{
			return vertexList == null || vertexList.Count() <= 0;
		}

		private bool HasEdges(int vertex)
		{
			if (IsEmptyList() == true) return false;
			if (vertex >= vertexList.Count()) return false;

			return vertexList[vertex].Count > 0;
		}

		public void Print()
		{
			if (IsEmptyList() == true) return;

			
			for (int vertex = 0; vertex < vertexList.Length; vertex++)
			{
				var edgeList = vertexList[vertex];
				var sb = new StringBuilder();
				sb.Append(vertex + " : ");
				
				foreach (var edge in edgeList)
				{
					sb.Append(edge.Vertex + ", ");
				}

				var str = sb.ToString().Substring(0, sb.Length - 2);
				PrintLn(str);
			}
		}
	}
}
