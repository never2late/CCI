using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class Program
	{
		private static void Test(int chapter, int question = 0)
		{
			if (chapter == 4)
			{
				var tester = new ChapterFourTester();
				tester.Test(question);
			}
		}
		
		public static void Main(string[] args)
		{
			Console.WriteLine("================ Program Start ================");
			//test comment
			Test(4, 0);

			Console.WriteLine("================ Program Finish ================");

			Console.ReadKey();
		}
	}
}
