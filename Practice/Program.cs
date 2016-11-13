using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practice.Solution;

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
        //O(2n) --> O(n) [n + n/2 + n/4 + ... = 2n]
        public static void TestSolution()
        {
            var solution = new Solution();
            var param = new int[] { 0, 9, 7, 2, 3, 8, 7, 1, 0, 4, 2, 7, 3, 8, 9, 2, 4 };

            var k = 1;
            var a = solution.kthSmallest(param, k);
            solution.qsort(param);
            var sorted = solution.toString(param);

            Console.WriteLine(sorted);
            Console.WriteLine("kth: " + k + ", num: " + a);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("================ Program Start ================\n\n");

            //Test(8, 4, 2);
            TestSolution();

            Console.WriteLine("\n\n================ Program Finish ================");

            Console.ReadKey();
        }
    }
}


