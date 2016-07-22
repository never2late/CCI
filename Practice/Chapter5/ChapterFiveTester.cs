using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class ChapterFiveTester : Util
	{
		public void Test(int q, int o)
		{
			if (q == 1)
			{
				int n = Convert.ToInt32("10000000000", 2);
				int m = Convert.ToInt32("10101", 2);
				int i = 2;
				int j = 6;

				var resultInt = QuestionOne(n, m, i, j);
				var result = Convert.ToString(resultInt, 2);

				PrintLn("Result : " + result);
			}
			else if (q == 2)
			{
				string n = "9.8125";
				var result = QuestionTwo(n);

				PrintLn(n + " = " + result);
			}
			else if (q == 3)
			{
				int num = 5;
				var result = QuestionThree(num);
				if (result != null)
				{
					var nextSmallest = result[0];
					var nextLargest = result[1];

					PrintLn("Current : " + num + "\nNext Smallest : " + nextSmallest + "\nNext Largest : " + nextLargest);
				}
			}
		}

		private int QuestionOne(int n, int m, int i, int j)
		{
			var max = ~0;
			int left = max << (j + 1);
			var right = (1 << i) - 1;
			var mask = left | right;

			var result = n & mask;
			result = result | (m << i);

			return result;
		}

		private string QuestionTwo(string n)
		{
			var split = n.Split('.');
			int num = Convert.ToInt32(split[0]);
			var dec = Convert.ToDouble("0." + split[1]);
			var decString = "";
			var stack = new Stack<char>();

			while (num > 0)
			{
				stack.Push((num % 2 == 0) ? '0' : '1');
				num >>= 1;
			}

			var sbNum = new StringBuilder();
			var sbDec = new StringBuilder();
			while (stack.Count > 0)
			{
				sbNum.Append(stack.Pop());
			}

			var numString = sbNum.ToString();

			while (true)
			{
				if (sbDec.Length >= 32) return "ERROR";
				dec = dec * 2;
				if (dec > 1.0f)
				{
					sbDec.Append('1');
					dec -= 1.0f;
				}
				else if (dec == 1.0f)
				{
					sbDec.Append('1');
					break;
				}
				else
				{
					sbDec.Append('0');
				}
			}

			decString = sbDec.ToString();

			return numString + "." + decString;
		}

		private int[] QuestionThree(int num)
		{
			var list = new int[2];

			list[0] = GetNextSmallest(num);
			list[1] = GetNextLargest(num);

			return list;
		}

		private int GetNextSmallest(int num)
		{
			int startBit = 1;

			while ((num & startBit) > 0)
			{
				startBit <<= 1;
			}
			while ((num & startBit) == 0)
			{
				if (startBit == 0) //already the smallest
				{
					return num;
				}

				startBit <<= 1;
			}

			var flipBit = startBit >> 1;
			var nextSmallest = num ^ startBit;
			nextSmallest = nextSmallest | flipBit;
			
			return nextSmallest;
		}

		private int GetNextLargest(int num)
		{
			int startBit = 1;
			while ((num & startBit) > 0)
			{
				startBit <<= 1;
			}
			while ((num & startBit) == 0)
			{
				if (startBit == 0) 
				{
					return num << 1;
				}

				startBit <<= 1;
			}

			var tmpBit = startBit >> 1;
			var nextLargest = num ^ tmpBit;
			nextLargest = nextLargest | startBit;

			return nextLargest;
		}
	}
}
