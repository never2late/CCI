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
                var s = new Stack1(3);

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
            else if (q == 2)
            {
                StackS stack = null;
                if (o == 0)
                {
                    stack = new StackS();
                }
                else if (o == 1)
                {
                    stack = new Stack2();
                }

                stack.push(5);
                PrintLn(stack.toString());

                stack.push(10);
                PrintLn(stack.toString());

                stack.push(3);
                PrintLn(stack.toString());

                stack.push(3);
                PrintLn(stack.toString());

                stack.push(8);
                PrintLn(stack.toString());

                stack.push(2);
                PrintLn(stack.toString());

                stack.push(1);
                PrintLn(stack.toString());

                for (int i = 0; i < 10; i++)
                {
                    stack.pop();
                    PrintLn(stack.toString());
                }
            }
            else if (q == 3)
            {
                int n = 7;
                int m = 10;
                int c = 3;

                var stack = new SetOfStacks(c);

                for (int i = 1; i <= n; i++) stack.push(i);
                //for (int i = 1; i <= m; i++) stack.pop();
                PrintLn(stack.toString());
                stack.popAt(0);
                stack.popAt(0);
                stack.popAt(1);

                PrintLn(stack.toString());
            }
            else if (q == 4)
            {
                int n = 5;
                if (o == 0)
                {
                    var tower = new HanoiTower();
                    tower.solve(n);
                }
                else if (o == 1)
                {
                    var tower = new HanoiTowerUsingStacks();
                    tower.solve(n);
                }
            }
            else if (q == 5)
            {
                var queue = new Queue5();
                int n = 5;
                int m = 10;

                for (int i = 1; i <= n; i++) queue.enq(i);
                PrintLn(queue.deq());
                PrintLn(queue.deq());
                queue.enq(6);
                queue.enq(7);

                for (int i = 1; i <= m; i++)
                {
                    PrintLn(queue.deq());
                }
            }
            else if (q == 6)
            {
                var stack = new StackS();
                stack.push(3);
                stack.push(1);
                stack.push(6);
                stack.push(2);
                stack.push(4);
                stack.push(5);

                //stack.pop();
                //stack.pop();
                //stack.pop();

                stack.sort();

                PrintLn(stack.toString());
            }
        }
    }
}
