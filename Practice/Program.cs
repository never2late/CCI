using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class Program
	{
		private static void Test(int chapter, int question = 0, int option = 0)
		{
			if (chapter == 4)
			{
				var tester = new ChapterFourTester();
				tester.Test(question, option);
			}
			else if (chapter == 5)
			{
				var tester = new ChapterFiveTester();
				tester.Test(question, option);
			}
		}
		
		public static void Main(string[] args)
		{
			Console.WriteLine("================ Program Start ================\n\n");
			
			Test(5, 2, 0);

			Console.WriteLine("\n\n================ Program Finish ================");

			Console.ReadKey();
		}
	}
}
