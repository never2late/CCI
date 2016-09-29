using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Solution
    {
        public string GetPermutation(int n, int k)
        {
            var str = "";
            for (int i = 1; i <= n; i++) str += i;

            var result = "";
            var s = str;
            var p = factorial(n);
            --k;
            var a = new int[5, 5];
            
            for (int i = n; i > 0; i--)
            {
                p /= i;
                var c = k / p;
                var t = s.ElementAt(c) + s.Substring(0, c) + s.Substring(c + 1);
                s = t.Substring(1);
                result += t.Substring(0, 1);
                k %= p;
            }

            return result;
        }

        private int factorial(int n)
        {
            for (int i = n - 1; i >= 2; i--) n *= i;

            return n;
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


