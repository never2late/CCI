using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class HanoiTower : Util
    {
        public void solve(int n)
        {
            if (n <= 0) return;

            solve(n, 'A', 'B', 'C');
        }

        private void solve(int n, char from, char tmp, char to)
        {
            if (n == 1)
            {
                PrintLn("Moving " + n + " from " + from + " to " + to);
                return;
            }

            solve(n - 1, from, to, tmp);
            PrintLn("Moving " + n + " from " + from + " to " + to);
            solve(n - 1, tmp, from, to);
        }
    }

    public class HanoiTowerUsingStacks : Util
    {
        private HanoiTower[] towers;
        private int step;

        public HanoiTowerUsingStacks()
        {
            towers = new HanoiTower[3];
            towers[0] = new HanoiTower('A');
            towers[1] = new HanoiTower('B');
            towers[2] = new HanoiTower('C');
        }

        public void solve(int n)
        {
            if (n <= 0) return;

            step = 0;

            for (int i = n; i > 0; i--) towers[0].push(i);

            solve(n, towers[0], towers[1], towers[2]);
        }

        private void solve(int n, HanoiTower from, HanoiTower tmp, HanoiTower to)
        {
            if (n == 1)
            {
                move(n, from, to);
                return;
            }

            solve(n - 1, from, to, tmp);
            move(n, from, to);
            solve(n - 1, tmp, from, to); 
        }

        private void move(int n, HanoiTower from, HanoiTower to)
        {
            PrintLn(++step + ". Move " + n + " from " + from.name + " to " + to.name);
            to.push(from.pop());
        }

        private class HanoiTower : StackS
        {
            public char name;

            public HanoiTower(char n)
            {
                name = n;
            }
        }
    }
}
