using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class Solution
	{
		private Dictionary<int, List<int>> map;
		//Given n = 6, edges = [[0, 3], [1, 3], [2, 3], [4, 3], [5, 4]]
		public IList<int> FindMinHeightTrees(int n, int[,] edges)
		{
			if (edges.GetLength(0) == 0)
			{
				var list = new List<int>();
				list.Add(0);
				return list;
			}

			getMap(edges);
			var resultMap = new Dictionary<int, List<int>>();
			var min = Int32.MaxValue;

			for (int vertex = 0; vertex < n; vertex++)
			{
				var height = getHeight(vertex, new HashSet<int>());
				min = Math.Min(height, min);

				if (resultMap.ContainsKey(height) == false)
				{
					resultMap.Add(height, new List<int>());
				}
				resultMap[height].Add(vertex);
			}

			return resultMap[min];
		}

		private int getHeight(int vertex, HashSet<int> hs)
		{
			hs.Add(vertex);
			var edges = map[vertex];
			var height = 0;

			foreach (var edge in edges)
			{
				if (hs.Contains(edge) == true) continue;
				height = 1 + getHeight(edge, hs);
			}

			return height;
		}

		private void getMap(int[,] edges)
		{
			map = new Dictionary<int, List<int>>();
			var height = edges.GetLength(0);

			for (int i = 0; i < height; i++)
			{
				var v1 = edges[i, 0];
				var v2 = edges[i, 1];
				if (map.ContainsKey(v1) == false)
				{
					map.Add(v1, new List<int>());
				}
				map[v1].Add(v2);
				if (map.ContainsKey(v2) == false)
				{
					map.Add(v2, new List<int>());
				}
				map[v2].Add(v1);
			}
		}
	}
}
