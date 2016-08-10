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
            else if (q == 2)
            {
                int n = 5;
                var list = new DoublyLinkedListS();

                for (int i = 1; i <= n; i++) list.add(i);

                PrintLn(list.toString());

                for (int i = 1; i <= n + 2; i++)
                {
                    var result = QuestionTwo(list, i, o);
                    PrintLn(i + "thToLast = " + result);
                }
            }
            else if (q == 3)
            {
                int n = 5;
                var list = new DoublyLinkedListS();

                for (int i = 1; i <= n; i++) list.add(i);
                Node node = list.head;
                for (int i = 0; i < n / 2; i++)
                {
                    node = node.next;
                }

                PrintLn(list.toString());

                QuestionThree(node);

                PrintLn("===== AFTER =====");
                PrintLn(list.toString());
            }
            else if (q == 4)
            {
                var l1 = new DoublyLinkedListS();
                l1.add(3);
                l1.add(1);
                l1.add(5);
                l1.add(6);
                var l2 = new DoublyLinkedListS();
                l2.add(5);
                l2.add(9);
                l2.add(2);
                l2.add(4);
                l2.add(7);
                l2.add(8);

                var sum = QuestionFour(l1, l2);

                PrintLn("  " + l1.toString());
                PrintLn("+ " + l2.toString());
                PrintLn("--------------------------------------");
                PrintLn("  " + sum.toString());
            }
            else if (q == 5)
            {
                var l1 = new DoublyLinkedListS();
                l1.add(1);
                l1.add(2);
                l1.add(3);
                l1.add(4);
                l1.add(5);
                l1.add(3);

                var result = QuestionFive(l1, o);

                PrintLn(l1.toString());
                PrintLn("Beginning of loop at : " + result);
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

        private int QuestionTwo(DoublyLinkedListS list, int nthToLast, int o)
        {
            if (o == 0)
            {
                if (list == null || list.head == null || nthToLast < 1) return -1;

                int cnt = 0;
                for (var node = list.head; node != null; node = node.next) cnt++;
                if (nthToLast > cnt) return -1;

                Node ret = list.head;
                for (int i = 0; i < cnt - nthToLast; i++)
                {
                    ret = ret.next;
                }

                return ret.value;
            }
            else if (o == 1)
            {
                if (list == null || list.head == null || nthToLast < 1) return -1;

                Node n1 = list.head;
                Node n2 = list.head;

                for (int i = 0; i < nthToLast - 1; i++)
                {
                    n1 = n1.next;
                    if (n1 == null) return -1;
                }

                for (var node = n1; node.next != null; node = node.next)
                {
                    n2 = n2.next;
                }

                return n2.value;
            }
            else if (o == 2)
            {
                if (list == null || list.head == null || nthToLast < 1) return -1;
                cnt = 0;
                return QuestionTwoHelper(list.head, nthToLast);
            }

            return -1;
        }

        private int cnt = 0;

        private int QuestionTwoHelper(Node node, int nthToLast)
        {
            if (node == null) return -1;

            var result = QuestionTwoHelper(node.next, nthToLast);
            if (++cnt == nthToLast)
            {
                result = node.value;
            }

            return result;
        }

        private void QuestionThree(Node node)
        {
            node.value = node.next.value;
            node.next = node.next.next;
        }

        private DoublyLinkedListS QuestionFour(DoublyLinkedListS l1, DoublyLinkedListS l2)
        {
            if (l1 == null || l2 == null || l1.head == null || l2.head == null) return null;

            var result = new DoublyLinkedListS();

            Node n1 = l1.head;
            Node n2 = l2.head;
            int carry = 0;

            while (n1 != null || n2 != null)
            {
                var v1 = (n1 != null) ? n1.value : 0;
                var v2 = (n2 != null) ? n2.value : 0;
                int sum = v1 + v2 + carry;
                carry = (sum >= 10) ? 1 : 0;
                sum %= 10;

                result.add(sum);

                n1 = (n1 != null) ? n1.next : null;
                n2 = (n2 != null) ? n2.next : null;
            }

            if (carry > 0) result.add(1);

            return result;
        }
        //1-2-3-4-5-3
        private int QuestionFive(DoublyLinkedListS list, int o)
        {
            if (o == 0)
            {
                if (list == null || list.head == null) return -1;
                var hs = new HashSet<int>();

                for (var node = list.head; true; node = node.next)
                {
                    if (hs.Contains(node.value) == false) hs.Add(node.value);
                    else return node.value;
                }
            }

            return -1;
        }
    }
}
