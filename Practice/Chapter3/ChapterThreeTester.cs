using Practice.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class ChapterThreeTester : Util
    {
        public void Test(int q, int o)
        {
            if (q == 0)
            {
                if (o == 0)
                {
                    int n = 5, m = 10;
                    var stack = new StackS();

                    for (int i = 0; i < n; i++) stack.push(i);
                    PrintLn(stack.toString());
                    for (int i = 0; i < m; i++) stack.pop();
                    PrintLn("===== AFTER =====");
                    PrintLn(stack.toString());
                }
                else if (o == 1)
                {
                    int n = 5;
                    int m = 3;
                    var queue = new QueueS();

                    for (int i = 0; i < n; i++) queue.enq(i);
                    PrintLn(queue.toString());
                    for (int i = 0; i < m; i++)
                    {
                        var r = queue.deq();
                    }
                    PrintLn("===== AFTER =====");
                    PrintLn(queue.toString());
                }
            }
            else if (q == 1)
            {
                var s = new Stack2(3);

                s.push(1, 0);
                s.push(2, 1);
                s.push(3, 2);
                s.push(4, 2);
                s.push(5, 2);
                s.push(6, 1);
                s.pop(0);
                s.pop(2);
                s.pop(2);
                s.pop(2);
                s.pop(2);
                s.push(9, 2);
                s.push(9, 2);

                PrintLn(s.toString());
            }
        }
    }
}
