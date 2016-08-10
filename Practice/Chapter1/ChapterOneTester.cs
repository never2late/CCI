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
            else if (q == 4)
            {
                string[] arr =
                {
                    "ABCD", "BCDA", "ABC", "BCD", "AA", "AAAA", "", "A", "LISTEN", "SILENT"
                };

                for (var i = 0; i < arr.Length - 1; i += 2)
                {
                    var s1 = arr[i];
                    var s2 = arr[i + 1];
                    var result = QuestionFour(s1, s2);
                    PrintLn(s1 + ", " + s2 + " - isAnagram : " + result);
                }
            }
            else if (q == 5)
            {
                string[] arr =
                {
                    "ABCD", "A B C", "A B C ", " ", "   ", "", "A       B "
                };

                foreach (var str in arr)
                {
                    var result = QuestionFive(str);
                    PrintLn("str: " + str + " - mix: " + result);
                }
            }
            else if (q == 6)
            {
                int n = 5;
                var arr1 = new char[5, 5];
                char c = 'a';
                for (int i = 0; i < arr1.GetLength(0); i++)
                {
                    for (int j = 0; j < arr1.GetLength(1); j++)
                    {
                        arr1[i, j] = c++;
                        Print(arr1[i, j] + "");
                    }
                    PrintLn("");
                }

                PrintLn("===== AFTER =====");
                var result = QuestionSix(arr1);

                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        Print(arr1[i, j] + "");
                    }
                    PrintLn("");
                }
            }
            else if (q == 7)
            {
                int m = 12;
                int n = 7;
                int[,] matrix = new int[n, m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        matrix[i, j] = 1;
                    }
                }

                //matrix[0, 0] = 0;
                //matrix[2, 4] = 0;
                matrix[1, 1] = 0;
                matrix[3, 5] = 0;
                matrix[5, 10] = 0;
                //matrix[1, 3] = 0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Print(matrix[i, j] + "");
                    }
                    PrintLn("");
                }

                QuestionSeven(matrix);

                PrintLn("===== AFTER =====");

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Print(matrix[i, j] + "");
                    }
                    PrintLn("");
                }
            }
            else if (q == 8)
            {
                string[] arr = {
                    "waterbottle", "erbottlewat",
                    "aaaaaaaaaaa", "aaaaaaaaaaa",
                    "aaaabbbbcccc", "bbccccaaaabb",
                    "abcdefg", "efgabcd",
                    "aaaaaaaaaaa", "aaaaaaaaaab",
                    "aaaabbbbcccc", "bbccccdaaabb",
                    "abcdefg", "!fgabcd",
                    "waterbottle", "erbottlewa",
                };

                for (int i = 0; i < arr.Length - 1; i+=2)
                {
                    var s1 = arr[i];
                    var s2 = arr[i + 1];
                    var result = QuestionEight(s1, s2);

                    PrintLn(s1 + " , " + s2 + " - isRotation : " + result);
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

        private bool QuestionFour(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2) || s1.Length != s2.Length) return false;

            var a1 = s1.ToArray();
            var a2 = s2.ToArray();
            Array.Sort(a1);
            Array.Sort(a2);

            return new string(a1).Equals(new string(a2));
        }

        private string QuestionFive(string str)
        {
            if (string.IsNullOrEmpty(str)) return "";

            int cnt = 0;
            for (int i = 0; i < str.Length; i++)
            {
                cnt = (str.ElementAt(i) == ' ') ? cnt + 1 : cnt;
            }
            //ab c--> ab%20c (4 --> 6)
            //a b c --> a%20b%20c%20 (6 --> 12)
            var arr = new char[str.Length + 2 * cnt];

            int index = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str.ElementAt(i);
                if (c == ' ')
                {
                    arr[index++] = '%';
                    arr[index++] = '2';
                    arr[index++] = '0';
                }
                else
                {
                    arr[index++] = c;
                }
            }

            return new string(arr);
        }
        //abcd      miea
        //efgh      njfb
        //ijkl      okgc
        //mnop      plhd
        private char[,] QuestionSix(char[,] arr)
        {
            int n = arr.GetLength(0);
            var result = new char[n, n];

            for (int i = 0; i < n >> 1; i++)
            {
                for (int j = i; j < n - i - 1; j++)
                {
                    var tmp = arr[i, j];
                    arr[i, j] = arr[n - j - 1, i];
                    arr[n - j - 1, i] = arr[n - i - 1, n - j - 1];
                    arr[n - i - 1, n - j - 1] = arr[j, n - i - 1];
                    arr[j, n - i - 1] = tmp;
                }
            }

            return result;
        }

        private void QuestionSeven(int[,] matrix)
        {
            var m = matrix.GetLength(1);
            var n = matrix.GetLength(0);
            var zeroRow = new bool[n];
            var zeroCol = new bool[m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        zeroRow[i] = true;
                        zeroCol[j] = true;
                    }
                }
            }

            for (int i = 0; i < zeroRow.Length; i++)
            {
                if (zeroRow[i] == true)
                    for (int k = 0; k < m; k++) matrix[i, k] = 0;
            }

            for (int j = 0; j < zeroCol.Length; j++)
            {
                if (zeroCol[j] == true)
                    for (int k = 0; k < n; k++) matrix[k, j] = 0;
            }
        }

        private bool QuestionEight(String s1, String s2)
        {
            if (string.IsNullOrEmpty(s1) == true || string.IsNullOrEmpty(s2) == true || s1.Length != s2.Length) return false;

            return isSubstring(s1, s2 + s2);
        }

        private bool isSubstring(String s1, String s2)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                if (s2.Substring(i, s1.Length).Equals(s1) == true) return true;
            }

            return false;
        }
	}
}
