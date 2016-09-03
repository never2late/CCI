using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Solution
    {
        public bool Exist(char[,] board, string word)
        {
            if (board == null || board.GetLength(0) == 0 || board.GetLength(1) == 0) return false;
            if (string.IsNullOrEmpty(word) == true) return true;

            int imax = board.GetLength(0), jmax = board.GetLength(1);
            if (word.Length == 1)
            {
                for (int i = 0; i < imax; i++)
                {
                    for (int j = 0; j < jmax; j++)
                    {
                        if (board[i, j] == word.ElementAt(0)) return true;
                    }
                }
            }
            var nodes = new Node[imax, jmax];
            for (int i = 0; i < imax; i++)
            {
                for (int j = 0; j < jmax; j++)
                {
                    nodes[i, j] = new Node(board[i, j]);
                }
            }
            var vertices = new Dictionary<Node, List<Node>>();
            for (int i = 0; i < imax; i++)
            {
                for (int j = 0; j < jmax; j++)
                {
                    var vertex = nodes[i, j];
                    vertices.Add(vertex, new List<Node>());
                    if (j + 1 < jmax) vertices[vertex].Add(nodes[i, j + 1]);
                    if (i + 1 < imax) vertices[vertex].Add(nodes[i + 1, j]);
                    if (j - 1 >= 0) vertices[vertex].Add(nodes[i, j - 1]);
                    if (i - 1 >= 0) vertices[vertex].Add(nodes[i - 1, j]);
                }
            }
           
            var correctKeyList = new List<Node>();
            foreach (var key in vertices.Keys)
            {
                if (key.vertex == word.ElementAt(0)) correctKeyList.Add(key);
            }
            foreach (var key in correctKeyList)
            {
                var hs = new HashSet<Node>();
                var q = new Queue<Node>();
                key.index = 1;
                q.Enqueue(key);
                hs.Add(key);
                while (q.Count > 0)
                {
                    var vertex = q.Dequeue();
                    var found = false;
                    foreach (var v in vertices[vertex])
                    {
                        if (hs.Contains(v) == true) continue;
                        if (v.vertex == word.ElementAt(vertex.index))
                        {
                            if (vertex.index == word.Length - 1) return true;
                            found = true;
                            v.index = vertex.index + 1;
                            hs.Add(v);
                            q.Enqueue(v);
                        }
                    }
                    if (found == false)
                    {
                        hs.Remove(vertex);
                    }
                }
            }

            return false;
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


For example,
        Given board = 
         
        [
          ["ABCE"], 
          ["SFCS"], 
          ["ADEE"] 
        ] 
        word = "ABCCED", -> returns true, 
        word = "SEE", -> returns true, 
        word = "ABCB", -> returns false. 