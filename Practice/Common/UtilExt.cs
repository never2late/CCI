using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
