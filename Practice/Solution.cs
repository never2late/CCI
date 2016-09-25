using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Solution
    {
        public int IntegerBreak(int n)
        {
            if (n == 2) return 1;

            var result = Int32.MinValue;

            for (int i = 1; i <= n >> 1; i++)
            {
                for (int j = 2; i + j <= n; j++)
                {
                    result = Math.Max(i * integerBreak(n, i, j), result);
                }
            }
            
            return result;
        }

        private int integerBreak(int n, int sum, int cur)
        {
            if (sum + cur >= n) return n - sum;
            //5
            sum += cur;
            //2 * 2 * 1
            return cur * integerBreak(n, sum, cur);
        }

        public bool IsValidBST(TreeNode root) {
            return IsValidBST(root, Int32.MinValue, Int32.MaxValue);
        }

        private bool IsValidBST(TreeNode node, int min, int max) {
            if (node == null) return true;
            if (min >= node.val || node.val >= max) return false;

            return IsValidBST(node.left, min, node.val) && IsValidBST(node.right, node.val, max);
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


