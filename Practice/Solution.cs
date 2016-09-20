using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Solution
    {
        List<string> result = new List<string>();
        public List<string> Combinations(int num)
        {
            var bits = new int[8];
            Combinations(num, 0, 0, bits);
            return result;
        }

        private void Combinations(int num, int cnt, int i, int[] bits)
        {
            if (num == cnt)
            {
                var sb = new StringBuilder();
                foreach (var bit in bits) sb.Append(bit + "");
                result.Add(sb.ToString());
                return;
            }
            if (i >= bits.Length) return;

            bits[i] = 1;
            Combinations(num, cnt + 1, i + 1, bits);
            bits[i] = 0;
            Combinations(num, cnt, i + 1, bits);
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        private class Node
        {
            public char vertex;
            public int index;
            public Node(char c)
            {
                vertex = c;
            }
        }
    }
}


