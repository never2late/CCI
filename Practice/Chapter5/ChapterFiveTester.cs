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
			else if (q == 4)
			{
				QuestionFour();
			}
			else if (q == 5)
			{
				int a = 31, b = 14;

				var cnt = QuestionFive(a, b);

				PrintLn("Number of bits required to turn " + a + " to " + b + " : " + cnt);
			}
			else if (q == 6)
			{
				uint n = 45;
				var nStr = toBinaryString(n);

				var result = QuestionSix(n);
				var resultStr = toBinaryString(result);
				resultStr = (nStr.Length == resultStr.Length) ? resultStr : "0" + resultStr;

				PrintLn("swapping even and odd bits of " + nStr + " : " + resultStr);
			}
			else if (q == 7)
			{
				int[] n = { 2,3,4,5,6,7,8 };

				var result = QuestionSeven(n);

				PrintLn("Result : " + result);
			}
		}

		private string toBinaryString(uint n)
		{
			var stack = new Stack<char>();
			var sb = new StringBuilder();

			while (n > 0)
			{
				stack.Push(n % 2 == 0 ? '0' : '1');
				n >>= 1;
			}

			while (stack.Count > 0)
			{
				sb.Append(stack.Pop());
			}

			return sb.ToString();
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
            int cnt = 0;

			while (dec != 0.0)
			{
                if (cnt > 32) return "ERROR";

                dec *= 2;
                if (dec >= 1.0)
                {
                    sbDec.Append("1");
                    dec -= 1.0;
                }
                else
                {
                    sbDec.Append("0");
                }
                cnt++;
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

		private void QuestionFour()
		{
			PrintLn("((n & (n-1)) == 0) checks whether n is a power of 2 (or 0).");
		}

		private int QuestionFive(int a, int b)
		{
			int diff = a ^ b;
			int cnt = 0;

			while (diff > 0)
			{
				cnt += (diff & 0x1);
				diff >>= 1;
			}

			return cnt;
		}

		private uint QuestionSix(uint n)
		{
			return (((n & 0xaaaaaaaa) >> 1) | ((n & 0x55555555) << 1));
		}

		private int QuestionSeven(int[] n)
		{
			var evenList = new List<int>();
			var oddList = new List<int>();
			var testList = n.ToList<int>();
			var result = 0x0;

			int index = 0;

			while (true)
			{
				for (int i = 0; i < testList.Count; i++)
				{
					if (GetBitAtIndex(n[i], index) == 0) evenList.Add(n[i]);
					else oddList.Add(n[i]);
				}

				testList = (evenList.Count > oddList.Count) ? oddList : evenList;
				result |= (evenList.Count > oddList.Count) ? 0x1 << index : 0x0;
				
				if (oddList.Count <= 0 || evenList.Count <= 0) break;

				evenList = new List<int>();
				oddList = new List<int>();

				index++;
			}

			return result;
		}

		private byte GetBitAtIndex(int n, int index)
		{
			var mask = 0x1 << index;

			return ((n & mask) > 0) ? (byte) 1 : (byte) 0;
		}
	}
}
