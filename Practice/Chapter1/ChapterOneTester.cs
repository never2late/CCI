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
            else if (q == 2)
            {
                string[] arr =
                {
                    "ABCD", "AAA", "AB", "", "\0"
                };

                foreach (var str in arr)
                {
                    var result = QuestionTwo(str);
                    PrintLn("str: " + str + " - reverse: " + result);
                }
            }
            else if (q == 3)
            {
                string[] arr =
                {
                    "ABCD", "AAA", "ABAB", "ABBA", "ABBC", "ABBCA", "", "A", "ABBBBBA", "AAABBB"
                };

                foreach (var str in arr)
                {
                    var result = QuestionThree(str, o);
                    PrintLn("str: " + str + " - removeDup: " + result);
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

        private string QuestionTwo(string str)
        {
            if (String.IsNullOrEmpty(str) == true) return "";

            var result = new char[str.Length + 1];
            result[0] = '\0';

            int index = 1;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                result[index++] = str.ElementAt(i);
            }

            return new string(result);
        }

        private string QuestionThree(string str, int o = 0)
        {
            if (o == 0)
            {
                if (string.IsNullOrEmpty(str) == true) return "";

                int tail = 1;
                string result = str.ElementAt(0) + "";
                for (int i = 1; i < str.Length; i++)
                {
                    int j = 0;
                    for (; j < tail; j++)
                    {
                        if (result.ElementAt(j) == str.ElementAt(i)) break;
                    }
                    if (j == tail)
                    {
                        result += ("" + str.ElementAt(i));
                        tail++;
                    }
                }

                return result;
            } //with buffer
            else if (o == 1)
            {
                if (string.IsNullOrEmpty(str) == true) return "";

                var arr = str.ToArray();
                var dup = new bool[256];
                var list = new List<char>();

                for (int i = 0; i < arr.Length; i++)
                {
                    if (dup[arr[i]] == true) continue;

                    var c = arr[i];
                    dup[c] = true;
                    list.Add(c);
                }

                return new string(list.ToArray());
            }
            else if (o == 2)
            {
                if (string.IsNullOrEmpty(str) == true) return "";

                var arr = str.ToArray();
                int tail = 1;

                for (int i = 1; i < arr.Length; i++)
                {
                    int j = 0;
                    for (; j < tail; j++)
                    {
                        if (arr[i] == arr[j]) break;
                    }
                    if (j == tail)
                    {
                        arr[j] = arr[i];
                        tail++;
                    }
                }

                var result = new char[tail];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = arr[i];
                }

                return new string(result);
            }

            return "";
        }
	}
}
