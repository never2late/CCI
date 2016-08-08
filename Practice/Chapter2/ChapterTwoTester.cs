using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class ChapterTwoTester : Util
    {
        public void Test(int q, int o)
        {
            if (q == 0)
            {
                var dll = new DoublyLinkedListS();
                dll.add(0);
                dll.add(1);
                dll.add(2);
                dll.add(3);
                dll.add(4);

                dll.remove(1);
                dll.remove(3);

                PrintLn(dll.toString(true));
            }
            else if (q == 1)
            {
                var dll = new DoublyLinkedListS();
                dll.add(1);
                dll.add(2);
                dll.add(2);
                dll.add(3);
                dll.add(3);
                dll.add(1);
                dll.add(4);
                dll.add(2);

                QuestionOne(dll, o);

                PrintLn(dll.toString());
            }
        }

        private void QuestionOne(DoublyLinkedListS list, int o)
        {
            if (o == 0) { 
                if (list == null || list.head == null) return;

                bool[] dup = new bool[256];
                Node prev = null;

                for (Node node = list.head; node != null; node = node.next) {
                    if (dup[node.value] == false) {
                        dup[node.value] = true;
                        prev = node;
                    } else {
                        prev.next = node.next;
                    }
                }
            } else if (o == 1) {
                if (list == null || list.head == null) return;

                var tail = list.head.next;
                var prev = list.head;

                for (var i = tail; i != null; i = i.next) {
                    Node j = list.head;
                    for (; j != tail; j = j.next) {
                        if (i.value == j.value) break;
                    }
                    if (j == tail) {
                        j.value = i.value;
                        prev = tail;
                        tail = tail.next;
                    }
                }

                prev.next = null;
            }
        }
    }
}
