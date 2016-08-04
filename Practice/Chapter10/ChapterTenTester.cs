using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
	public class ChapterTenTester : Util
	{
		public void test(int q, int o)
		{
			if (q == 0)
			{
				int a = 105;
				int b = 252;
				PrintLn("GCD(" + a + "," + b + ") = " + gcd(a, b));
				PrintLn("LCM(" + a + "," + b + ") = " + lcm(a, b));

				a = 24;
				b = 18;
				PrintLn("GCD(" + a + "," + b + ") = " + gcd(a, b));
				PrintLn("LCM(" + a + "," + b + ") = " + lcm(a, b));
			}
			else if (q == 3)
			{
				var l1 = new Line(2, 0);
				var l2 = new Line(2, 2);
				var l3 = new Line(4, 1);

				PrintLn("Intersects : " + QuestionThree(l1, l2));
				PrintLn("Intersects : " + QuestionThree(l1, l3));
			}
			else if (q == 4)
			{
				int a = 7;
				int b = 3;
				int c = -a;
				int d = -b;

				PrintLn(a + " x " + b + " = " + QuestionFourMultiply(a, b));
				PrintLn(a + " x " + d + " = " + QuestionFourMultiply(a, d));
				PrintLn(c + " x " + b + " = " + QuestionFourMultiply(c, b));
				PrintLn(c + " x " + d + " = " + QuestionFourMultiply(c, d));
				PrintLn();
				PrintLn(a + " - " + b + " = " + QuestionFourSubtract(a, b));
				PrintLn(c + " - " + b + " = " + QuestionFourSubtract(c, b));
				PrintLn(a + " - " + d + " = " + QuestionFourSubtract(a, d));
				PrintLn(c + " - " + d + " = " + QuestionFourSubtract(c, d));
				PrintLn();
				PrintLn(a + " / " + b + " = " + QuestionFourDivide(a, b));
				PrintLn(a + " / " + d + " = " + QuestionFourDivide(a, d));
				PrintLn(c + " / " + b + " = " + QuestionFourDivide(c, b));
				PrintLn(c + " / " + d + " = " + QuestionFourDivide(c, d));
				PrintLn();
				PrintLn(b + " - " + a + " = " + QuestionFourSubtract(b, a));
				PrintLn(d + " - " + a + " = " + QuestionFourSubtract(d, a));
				PrintLn();
				PrintLn(b + " / " + a + " = " + QuestionFourDivide(b, a));
				PrintLn(b + " / " + c + " = " + QuestionFourDivide(b, c));
				PrintLn(d + " / " + a + " = " + QuestionFourDivide(d, a));
				PrintLn(d + " / " + c + " = " + QuestionFourDivide(d, c));
			}
			else if (q == 6)
			{
				Point[] points = {
					new Point(0, 0), 
					new Point(1, 1), 
					new Point(2, 2),
					new Point(3, 3), 
					new Point(0, 4), 
					new Point(0, 5),
					new Point(2, 1), 
					new Point(7, 4),
					new Point(1, 0),
					new Point(2, 0),
					new Point(3, 0),
					new Point(4, 0),
				};

				var result = QuestionSix(points);
				var line = result.Item1;
				var cnt = result.Item2;
				PrintLn("Resulting Line : y = " + line.m + "x + " + line.yintercept + " , cnt : " + cnt);
			}
		}

		public int gcd(int a, int b)
		{
			while (b != 0)
			{
				int t = b;
				b = a % b;
				a = t;
			}

			return a;
		}
		//gcd(a,b) * lcm(a,b) = ab
		public int lcm(int a, int b)
		{
			if (a == 0 || b == 0) return 0;
			var t = gcd(a, b);
			if (t == 0) return 0;

			return (a * b) / t;
		}

		public bool QuestionThree(Line l1, Line l2)
		{
			float precision = 0.0000001f;
			return Math.Abs(l1.m - l2.m) > precision || Math.Abs(l1.yintercept - l2.yintercept) < precision;
		}

		public int QuestionFourMultiply(int n, int mult)
		{
			if (n == 0 || mult == 0) return 0;

			var result = 0;
			int cnt = Math.Abs(mult);
			bool plus = ((n < 0 && mult < 0) || (n > 0 && mult > 0)) ? true : false;
			var absN = Math.Abs(n);
			int start = (plus) ? absN : (~absN + 1);

			for (int i = 0; i < cnt; i++)
			{
				result += start;
			}

			return result;
		}

		public int QuestionFourSubtract(int n, int sub)
		{
			return n + (~sub + 1);
		}

		public int QuestionFourDivide(int n, int div)
		{
			if (div == 0) throw new Exception();
			if (n == 0) return 0;
			bool plus = ((n > 0 && div > 0) || (n < 0 && div < 0));
			int absDiv = (div > 0) ? div : ~div + 1;
			int negDiv = ~absDiv + 1;
			int absN = (n > 0) ? n : ~n + 1;
			int result = 0;

			for (int i = absN; i > absDiv; i += negDiv)
			{
				result++;
			}
			
			return (plus) ? result : ~result + 1;
		}

		public Tuple<Line, int> QuestionSix(Point[] points)
		{
			if (points.Length < 2) return null;

			var lineList = new List<Line>();
			var dict = new Dictionary<int, int>();
			

			int max = 0; Line result = null;
			for (int i = 0; i < points.Length - 1; i++)
			{
				for (int j = i + 1; j < points.Length; j++)
				{
					var line = new Line(points[i], points[j]);
					var hash = line.GetHashCode();
					if (dict.ContainsKey(hash) == false)
					{
						dict.Add(hash, 0);
					}
					++dict[hash];
					
					if (dict[hash] > max)
					{
						max = dict[hash];
						result = line;
					}
				}
			}

			return new Tuple<Line, int>(result, max);
		}
	}

	public class Point
	{
		public float x { get; set; }
		public float y { get; set; }
		public Point(float x, float y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public class Line
	{
		public float m { get; set; }
		public float yintercept { get; set; }
		private static Random r = new Random();

		public Line(float m, float yintercept)
		{
			this.m = m;
			this.yintercept = yintercept;
		}

		public Line(Point p1, Point p2)
		{
			this.m = getSlope(p1, p2);
			this.yintercept = getYintercept(m, p1);
		}

		private float getSlope(Point a, Point b)
		{
			if (b.x - a.x == 0) return float.PositiveInfinity;
			if (b.y - a.y == 0) return 0;

			return (b.y - a.y) / (b.x - a.x);
		}

		private float getYintercept(float m, Point p)
		{
			if (m == float.PositiveInfinity) return float.PositiveInfinity;

			return p.y - m * p.x;
		}

		public override int GetHashCode()
		{
			int sl = (int)((m + r.Next(1, 1234)) * 9876) + 56483;
			int yi = (int)((yintercept + r.Next(1, 34)) * 1234) + 7895;
			return sl | yi;
		}
	}
}
