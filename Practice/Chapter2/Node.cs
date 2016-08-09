using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Node
    {
        public int value { get; set; }
        public Node next { get; set; }
        public Node prev { get; set; }

        public Node(int v)
        {
            value = v;
        }

        public Node(int v, Node n, Node p)
        {
            value = v;
            next = n;
            prev = p;
        }
    }
}