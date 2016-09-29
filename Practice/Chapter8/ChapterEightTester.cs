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

                for (int i = 0; i < list.Count; i++)
                {
                    PrintLn((i + 1) + ". " + list[i]);
                }
            }
            else if (q == 5)
            {
                int n = 5;

                QuestionFive(n);
            }
            else if (q == 6)
            {
                int[,] colors = {
                    { 1, 1, 0, 1, 1 },
                    { 1, 0, 0, 0, 1 },
                    { 0, 0, 3, 0, 0 },
                    { 1, 0, 0, 0, 1 },
                    { 1, 1, 0, 1, 1 }
                };

                Fill(colors, 2, 0, 2);

                int width = colors.GetLength(0);
                int height = colors.GetLength(1);
                var sb = new StringBuilder();
                for (int y = 0; y < height; y++)
                {
                    sb.Append("{ ");
                    for (int x = 0; x < width; x++)
                    {
                        sb.Append(colors[y, x] + ", ");
                    }
                    sb.Append("}\n");
                }

                PrintLn(sb.ToString());
            }
            else if (q == 7)
            {
                int n = 11; //cents
                var ways = QuestionSeven(n);

                foreach (var way in ways)
                {
                    var sb = new StringBuilder();
                    foreach (var coin in way)
                    {
                        sb.Append(coin + " + ");
                    }

                    sb.Remove(sb.Length - 2, 2);
                    sb.Append(" = " + n);
                    PrintLn(sb);
                }

                PrintLn("Number of ways of representing " + n + " cents : " + ways.Count);
            }
            else if (q == 8)
            {
                var allWays = QuestionEight();
                var sb = new StringBuilder();

                foreach (var way in allWays)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            sb.Append(way[j, i] + " ");
                        }
                        sb.Append("\n");
                    }
                    sb.Append("\n");
                }

                PrintLn(sb);
                PrintLn("Number of solutions : " + allWays.Count);

                var dict = new Dictionary<string, string>();
                string a = "";
                var b = a.ToCharArray();
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
			var list = new List<string>();
			GetPermutation("", s, list);
			return list;
		}
        /* 
            ABCD        ABC
            ABDC        ACB
            ACBD        BAC
            ACDB        BCA
            ADBC        CAB
            ADCB        CBA
            BACD 
        */
		private void GetPermutation(string left, string right, List<string> list)
		{
            if (right.Length == 0)
            {
                list.Add(left);
                return;
            }

			for (int i = 0; i < right.Length; i++)
			{
                var str = right.ElementAt(i) + right.Substring(0, i) + right.Substring(i + 1);
                GetPermutation(left + str.ElementAt(0), str.Substring(1), list);
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

        public void Fill(int[,] colors, int x, int y, int color)
        {
            int curColor = colors[y,x];

            Fill(colors, x, y, color, curColor);
        }

        private void Fill(int[,] colors, int x, int y, int color, int curColor)
        {
            int yLen = colors.GetLength(0);
            int xLen = colors.GetLength(1);
            if (y >= yLen || x >= xLen || x < 0 || y < 0) return;
            if (colors[y,x] != curColor) return;

            colors[y,x] = color;

            Fill(colors, x + 1, y, color, curColor);
            Fill(colors, x, y + 1, color, curColor);
            Fill(colors, x - 1, y, color, curColor);
            Fill(colors, x, y - 1, color, curColor);
        }

        public List<List<int>> QuestionSeven(int n)
        {
            if (n <= 0) return new List<List<int>>();

            return GetCoinCombinations(n);
        }

        private List<List<int>> GetCoinCombinations(int n)
        {
            var result = new List<List<int>>();
            var coinList = new List<int>();

            coinList.Add(25);
            coinList.Add(10);
            coinList.Add(5);
            coinList.Add(1);

            var cnt = 0;

            for (int i = 0; i < coinList.Count; i++)
            {
                var coin = coinList[i];
                cnt += GetCoinCombinations(n, coin, i, result, coinList, new List<int>());
            }

            PrintLn("CNT : " + cnt);
            return result;
        }

        private int GetCoinCombinations(int cur, int coin, int coinIndex, List<List<int>> result, List<int> coinList, List<int> list)
        {
            if (cur - coin < 0) return 0;

            cur -= coin;
            list.Add(coin);

            if (cur == 0)
            {
                result.Add(list);
                return 1;
            }

            var cnt = 0;
            for (int i = coinIndex; i < coinList.Count; i++)
            {
                cnt += GetCoinCombinations(cur, coinList[i], i, result, coinList, new List<int>(list));
            }

            return cnt;
        }

        public List<int[,]> QuestionEight()
        {
            var result = new List<int[,]>();
            var chessBoard = new int[8, 8];

            placeAllQueens(chessBoard, 0, 0, 0, result);

            return result;
        }

        private void placeAllQueens(int[,] chessBoard, int x, int y, int cnt, List<int[,]> result)
        {
            if (cnt == 8)
            {
                result.Add(chessBoard);
                return;
            } 
            if (x >= 8 || y >= 8) return;
            
            if (canPlaceQueen(chessBoard, x, y) == true)
            {
                chessBoard[y, x] = 1;
                var copy = new int[8, 8];
                Array.Copy(chessBoard, copy, chessBoard.Length);
                cnt++;
                
                placeAllQueens(copy, 0, y + 1, cnt, result);
                chessBoard[y, x] = 0;
                cnt--;
            }

            placeAllQueens(chessBoard, x + 1, y, cnt, result);
        }

        private bool canPlaceQueen(int[,] chessBoard, int x, int y)
        {
            if (x < 0 || y < 0 || x >= 8 || y >= 8) return false;

            int i = 0, j = 0;
            for (j = 0; j < 8; j++)
            {
                if (chessBoard[j, x] == 1) return false;
            }
            i = x + 1;
            j = y - 1;
            while (true)
            {
                if (i >= 8 || j < 0) break;
                if (chessBoard[j, i] == 1) return false;
                i++;
                j--;
            }
            i = x - 1;
            j = y + 1;
            while (true)
            {
                if (i < 0 || j >= 8) break;
                if (chessBoard[j, i] == 1) return false;
                i--;
                j++;
            }
            i = x - 1;
            j = y - 1;
            while (true)
            {
                if (i < 0 || j < 0) break;
                if (chessBoard[j, i] == 1) return false;
                i--;
                j--;
            }
            i = x + 1;
            j = y + 1;
            while (true)
            {
                if (i >= 8 || j >= 8) break;
                if (chessBoard[j, i] == 1) return false;
                i++;
                j++;
            }

            return true;
        }
    }
}
