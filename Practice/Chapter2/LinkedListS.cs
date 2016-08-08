using Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class LinkedListS
    {
        public Node head;
        public Node tail;
    }

    public class DoublyLinkedListS
    {
        public Node head;
        public Node tail;
        public int count;

        public void add(int v)
        {
            if (head == null)
            {
                head = new Node(v);
                tail = head;
                count++;
                return;
            }

            tail.next = new Node(v);
            tail.next.prev = tail;
            tail = tail.next;
            count++;
        }

        public Node remove(int v)
        {
            if (head == null) return null;
            if (head.value == v)
            {
                if (head == tail)
                {
                    var ret = head;
                    head = null;
                    tail = null;
                    count--;
                    return ret;
                }

                var ret2 = head;
                head.next.prev = null;
                head = head.next;
                count--;
                return ret2;
            }

            for (var node = head.next; node.next != null; node = node.next)
            {
                if (node.value == v)
                {
                    node.prev.next = node.next;
                    node.next.prev = node.prev;
                    count--;
                    return node;
                }
            }

            if (tail.value == v)
            {
                var ret = tail;
                tail.prev.next = null;
                tail = tail.prev;
                count--;
                return ret;
            }

            return null;
        }

        public string toString(bool verbose = false)
        {
            var sb = new StringBuilder();
            sb.Append("{");

            for (Node node = head; node != null; node = node.next)
            {
                sb.Append(node.value + " - ");
            }

            if (head != null) sb.Remove(sb.Length - 3, 3);
            sb.Append("}");
            var headValue = (head == null) ? "null" : head.value + "";
            var tailValue = (tail == null) ? "null" : tail.value + "";
            if (verbose)
                sb.Append("\nHead : " + headValue + ", Tail : " + tailValue + ", Count : " + count);

            return sb.ToString();
        }
    }
}
