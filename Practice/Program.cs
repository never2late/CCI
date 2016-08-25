﻿using System;
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
            if (chapter == 1)
            {
                var tester = new ChapterOneTester();
                tester.Test(question, option);
            }
            else if (chapter == 2)
            {
                var tester = new ChapterTwoTester();
                tester.Test(question, option);
            }
            else if (chapter == 3)
            {
                var tester = new ChapterThreeTester();
                tester.Test(question, option);
            }
            else if (chapter == 4)
            {
                var tester = new ChapterFourTester();
                tester.Test(question, option);
            }
            else if (chapter == 5)
            {
                var tester = new ChapterFiveTester();
                tester.Test(question, option);
            }
            else if (chapter == 8)
            {
                var tester = new ChapterEightTester();
                tester.Test(question, option);
            }
            else if (chapter == 9)
            {
                var tester = new ChapterNineTester();
                tester.test(question, option);
            }
            else if (chapter == 10)
            {
                var tester = new ChapterTenTester();
                tester.test(question, option);
            }
            else if (chapter == 12)
            {
                var tester = new ChapterTwelveTester();
                tester.test(question, option);
            }
		}

		public static void TestSolution()
		{
			var solution = new Solution();
			var param = new int[5, 2] { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 3, 4 }, { 4, 5 } };
			solution.FindMinHeightTrees(6, param);
		}

		public static void Main(string[] args)
		{
			Console.WriteLine("================ Program Start ================\n\n");

			//Test(4, 2, 1);
			TestSolution();

			Console.WriteLine("\n\n================ Program Finish ================");

			Console.ReadKey();
		}
	}
}
