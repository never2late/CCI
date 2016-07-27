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
	}
}
