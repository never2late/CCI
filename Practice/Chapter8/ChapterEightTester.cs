using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class ChapterEightTester : Util
	{
		private static uint[] fibonacci = new uint[256];

		public void Test(int q, int o)
		{
			if (q == 1)
			{
				int max = 20;
				var sb = new StringBuilder();

				if (o == 0)
				{
					for (uint i = 0; i < max; i++)
					{
						var result = QuestionOne(i);

						sb.Append(result + ", ");
					}
				}
				else if (o == 1)
				{
					for (uint i = 0; i < max; i++)
					{
						var result = fibo(i);

						sb.Append(result + ", ");
					}
				}

				PrintLn(sb.ToString());
			}
			if (q == 2)
			{
				int n = 3;

				var result = QuestionTwo(n);

				PrintLn("Number of paths from top left to bottom right in a " + n + " x " + n + " matrix : " + result.Count);
				foreach (var str in result)
				{
					PrintLn(str);
				}
			}
			if (q == 3)
			{
				var set = new List<int>();
				int n = 4;

				for (int i = 0; i < n; i++)
				{
					set.Add(i);
				}

				var subsets = QuestionThree(set);
				var sb = new StringBuilder();
				sb.Append("{");
				foreach (var e in set)
				{
					sb.Append(e + ",");
				}
				sb.Remove(sb.Length - 1, 1);
				sb.Append("}");

				PrintLn("Subsets of " + sb.ToString());

				foreach (var subset in subsets)
				{
					if (string.IsNullOrEmpty(subset) == true) PrintLn("{null}");
					else
					{
						var str = subset.Substring(0, subset.Length - 1);
						PrintLn("{" + str + "}");
					}
				}
				PrintLn("TOTAL OF " + subsets.Count);
			}
			else if (q == 4)
			{
				var str = "ABCD";
				var list = QuestionFour(str);

				PrintLn("Permutation of " + str + ", total of : " + list.Count);

				foreach (var permutation in list)
				{
					PrintLn(permutation);
				}
			}
			else if (q == 5)
			{
				int n = 5;

				QuestionFive(n);
			}
		}
		//1, 2, 3, 5, ... 
		//f(n) = f(n-1) + f(n-2)
		private uint QuestionOne(uint n)
		{
			if (n == 0) return 1;
			if (n == 1) return 2;
			if (fibonacci[n] != 0) return fibonacci[n];

			var result = QuestionOne(n - 1) + QuestionOne(n - 2);
			fibonacci[n] = result;

			return result;
		}

		private uint fibo(uint n)
		{
			if (n == 0) return 1;
			if (n == 1) return 2;

			uint a = 1, b = 2, result = 0;
			for (int i = 1; i < n; i++)
			{
				result = a + b;
				a = b;
				b = result;
			}

			return result;
		}

		private List<string> QuestionTwo(int n)
		{
			var list = new List<string>();

			GetPaths(n - 1, 'R', "", list);
			GetPaths(n - 1, 'D', "", list);

			return list;
		}

		private void GetPaths(int limit, char c, string result, List<string> list)
		{
			if (GetCharCount(c, result) == limit || isValidPath(result) == false) return;

			result += c;

			if (result.Length == limit * 2)
			{
				list.Add(result);
				return;
			}
			
			GetPaths(limit, 'R', result, list);
			GetPaths(limit, 'D', result, list);
		}

		private int GetCharCount(char c, string s)
		{
			if (string.IsNullOrEmpty(s) == true) return 0;

			var cnt = 0;
			for (int i = 0; i < s.Length; i++)
			{
				if (s.ElementAt(i) == c) cnt++;
			}

			return cnt;
		}

		private bool isValidPath(string path)
		{
			//if (path == "RR") return false;

			return true;
		}

		public List<string> QuestionThree(List<int> set)
		{
			var list = new List<string>();
			list.Add("");

			for (int i = 0; i < set.Count; i++)
			{
				GetAllSubsets(set, i, "", list);
			}

			return list;
		}

		private void GetAllSubsets(List<int> set, int i, string result, List<string> list)
		{
			if (i >= set.Count) return;

			var value = set[i];
			result += (value + ",");
			list.Add(result);

			for (int x = i + 1; x < set.Count; x++)
			{
				GetAllSubsets(set, x, result, list);
			}
		}

		public List<string> QuestionFour(string s)
		{
			if (string.IsNullOrEmpty(s) == true) return null;
			
			var list = new List<string>();

			if (s.Length == 1)
			{
				list.Add(s);
				return list;
			}
			if (s.Length == 2)
			{
				list.Add("" + s.ElementAt(0) + s.ElementAt(1));
				list.Add("" + s.ElementAt(1) + s.ElementAt(0));
				return list;
			}

			GetPermutation("", s, list);

			return list;
		}

		private void GetPermutation(string prev, string s, List<string> list)
		{
			for (int i = 0; i < s.Length; i++)
			{
				char c = s.ElementAt(i);
				var before = s.Substring(0, i);
				var after = (i + 1 < s.Length) ? s.Substring(i + 1, s.Length - i - 1) : "";
				var comb = before + after;

				if (comb.Length == 2)
				{
					list.Add(prev + c + comb.ElementAt(0) + comb.ElementAt(1));
					list.Add(prev + c + comb.ElementAt(1) + comb.ElementAt(0));
				}
				else
				{
					GetPermutation(prev + c, comb, list);
				}
			}
		}

		public List<string> QuestionFive(int n)
		{
			if (n <= 0) return null;

			var list = new List<string>();
			var result = new List<List<int>>();

			for (int i = 1; i <= n; i++)
			{
				GetParanthesisList(n, 0, i, result, new List<int>());
			}

			PrintLn("TOTAL OF : " + result.Count);

			foreach (var intList in result)
			{
				foreach (var i in intList)
				{
					PrintParanthesis(i);
				}

				Print(", ");
			}

			return list;
		}

		private void GetParanthesisList(int n, int sum, int inc, List<List<int>> result, List<int> list)
		{
			sum += inc;
			list.Add(inc);

			if (sum == n)
			{
				result.Add(list);
				return;
			}

			for (int i = 1; sum + i <= n; i++)
			{
				GetParanthesisList(n, sum, i, result, new List<int>(list));
			}
		}

		private void PrintParanthesis(int n)
		{
			if (n <= 0) return;

			var sb = new StringBuilder();

			for (int i = 0; i < n; i++) sb.Append("(");
			for (int i = 0; i < n; i++) sb.Append(")");

			Print(sb.ToString());
		}
	}
}
