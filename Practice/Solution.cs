using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Solution
    {
        List<TreeNode> result = new List<TreeNode>();

        public List<TreeNode> GenerateTrees(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                GenerateTrees(i, 1, n, n - 1, null);
            }
            return result;
        }
        
        private TreeNode GenerateTrees(int n, int min, int max, int cnt, TreeNode root)
        {
            var node = new TreeNode(n);
            if (root == null) root = node;

            for (int i = min; i < n; i++)
            {
                node.left = GenerateTrees(i, min, n - 1, --cnt, root);
            }

            for (int i = n + 1; i <= max; i++)
            {
                node.right = GenerateTrees(i, n + 1, max, --cnt, root);
            }

            if (cnt == 0)
            {
                result.Add(copy(root));
            }

            return node;
        }

        private TreeNode copy(TreeNode root)
        {
            if (root == null) return null;

            var node = new TreeNode(root.val);
            node.left = copy(root.left);
            node.right = copy(root.right);

            return node;
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
}


