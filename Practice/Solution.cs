using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practice.Solution;

namespace Practice
{
    public class Solution
    {
        public int kthSmallest(int[] arr, int k)
        {
            return kthSmallest(arr, 0, arr.Length - 1, k);
        }
        private int kthSmallest(int[] arr, int s, int e, int k)
        {
            if (s >= e) return arr[s];

            int p = ptt(arr, s, e);
            if (p == k - 1) return arr[p];
            else if (k - 1 < p) return kthSmallest(arr, s, p - 1, k);
            else return kthSmallest(arr, p + 1, e, k);
        }
        private int ptt(int[] arr, int s, int e)
        {
            int p = e;
            int piv = arr[p];
            for (int i = s; i < p; i++)
            {
                if (arr[i] > piv)
                {
                    swap(arr, i, p - 1);
                    swap(arr, p, p - 1);
                    i--;
                    p--;
                }
            }
            return p;
        }
        private void swap(int[] arr, int a, int b)
        {
            var tmp = arr[a];
            arr[a] = arr[b];
            arr[b] = tmp;
        }

        public void qsort(int[] n)
        {
            qsort(n, 0, n.Length - 1);
        }
        private void qsort(int[] n, int s, int e)
        {
            if (s >= e) return;

            int p = ptt(n, s, e);
            qsort(n, s, p - 1);
            qsort(n, p + 1, e);
        }

        public String toString(int[] n)
        {
            var sb = new StringBuilder();
            foreach (var i in n)
            {
                sb.Append(i + ", ");
            }
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }

        public class UndirectedGraphNode {
            public int label;
            public IList<UndirectedGraphNode> neighbors;
            public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
        };

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


    
    public static class TreeUtil
    {
        public static TreeNode GetTree(Nullable<int>[] param)
        {
            var root = new TreeNode((int)param[0]);
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            var i = 0;
            
            while (q.Count > 0 && i < param.Length)
            {
                var node = q.Dequeue();
                if (node == null)
                {
                    i += 2;
                    q.Enqueue(null);
                    q.Enqueue(null);
                    continue;
                }
                node.left = (++i < param.Length && param[i] != null) ? new TreeNode((int)param[i]) : null;
                node.right = (++i < param.Length && param[i] != null) ? new TreeNode((int)param[i]) : null;
                q.Enqueue(node.left);
                q.Enqueue(node.right);
            }

            return root;
        }
        private static TreeNode GetTree(Nullable<int>[] param, int l, int r)
        {
            if (l > r) return null;

            var m = l + ((r - l) >> 1);
            if (param[m] == null) return null;

            var node = new TreeNode((int)param[m]);
            node.left = GetTree(param, l, m - 1);
            node.right = GetTree(param, m + 1, r);
            return node;
        }
    }
}


