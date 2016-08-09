using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class ChapterOneTester : Util
	{
		public void Test(int q, int o)
		{
			if (q == 1)
			{
				string[] arr = { "abcdef", "bbccdd", "abcdea", "", "nop p", "helo wrd!" };

				foreach (var str in arr)
				{
					PrintLn(str + " has all unique characters : " + QuestionOne(str, o));
				}
			}
		}

		private bool QuestionOne(string str, int option = 0)
		{
			if (option == 0)
			{
				var hs = new HashSet<char>();
				for (int i = 0; i < str.Length; i++)
				{
					char c = str.ElementAt(i);
					if (hs.Contains(c) == true) return false;
					hs.Add(c);
				}

				return true;
			}
			else if (option == 1)
			{
				bool[] arr = new bool[256];

				for (int i = 0; i < str.Length; i++)
				{
					var c = str.ElementAt(i);
					if (arr[c] == true) return false;
					arr[c] = true;
				}

				return true;
			}

			return false;
		}
	}
}
