using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class Util
	{
		public static void Print(String str = "")
		{
			Console.Write(str);
		}

        public static void Print(StringBuilder sb)
        {
            Print(sb.ToString());
        }

        public static void PrintLn(String str = "")
		{
			Console.WriteLine(str);
		}

        public static void PrintLn(StringBuilder sb)
        {
            PrintLn(sb.ToString());
        }

		public static void PrintLn(int n)
		{
			Console.WriteLine("" + n);
		}
    }
}
