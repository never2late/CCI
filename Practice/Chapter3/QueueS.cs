using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class QueueS
    {
        public Node head;
        public Node tail;

        public void enq(int v)
        {
            if (head == null)
            {
                head = new Node(v);
                tail = head;
                return;
            }

            var node = new Node(v);
            tail.next = node;
            tail = node;
        }

        public int deq()
        {
            if (head == null) return -1;

            var ret = head.value;
            head = head.next;
            tail = (head == null) ? null : tail;
            return ret;
        }
    }
}
