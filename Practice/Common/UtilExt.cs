using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practice.ChapterNineTester;

namespace Practice.Common
{
    public static class UtilExt
    {
        public static string toString(this int[] n)
        {
            if (n == null) return "";

            var sb = new StringBuilder();
            sb.Append("{");

            for (int i = 0; i < n.Length; i++)
            {
                sb.Append(n[i] + ", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append("}");

            return sb.ToString();
        }

        public static string toString(this string[] arr)
        {
            if (arr == null) return "";

            var sb = new StringBuilder();
            sb.Append("{");

            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append(arr[i] + ", ");
            }

            sb.Remove(sb.Length - 2, 2);
            sb.Append("}");

            return sb.ToString();
        }

        public static string toString(this int[,] n)
        {
            int l = n.GetLength(0);
            int w = n.GetLength(1);
            var sb = new StringBuilder();

            for (int j = 0; j < l; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    sb.Append(n[j, i] + ", ");
                }
                sb.Remove(sb.Length - 2, 2);
                sb.Append("\n");
            }

            return sb.ToString();
        }

        public static string toString(this Person[] p)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < p.Length; i++)
            {
                sb.Append(p[i].ToString() + ", ");
            }

            sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }

        public static string toString(this StackS s)
        {
            if (s == null || s.top == null) return "";

            var sb = new StringBuilder();
            for (var node = s.top; node != null; node = node.next)
            {
                sb.Append(node.value + "->");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append("\nTop : " + s.top.value + " - Min : " + s.min());

            return sb.ToString();
        }

        public static string toString(this QueueS q)
        {
            if (q == null || q.head == null) return "";

            var sb = new StringBuilder();
            for (Node node = q.head; node != null; node = node.next)
            {
                sb.Append(node.value + "->");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append("\nHead : " + q.head.value + " / Tail : " + q.tail.value);

            return sb.ToString();
        }
    }
}
