using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }

    public class Solution
    {
        public List<Interval> Merge(IList<Interval> intervals)
        {
            if (intervals == null || intervals.Count == 0) return new List<Interval>();
            if (intervals.Count == 1) return intervals.ToList();

            var arr = intervals.ToArray();
            Array.Sort(arr, new QComparer());
            var result = new List<Interval>();
            var s = intervals[0].start;
            var e = intervals[0].end;
            bool sFound = false, eFound = false;
            //[1,5],[0,4]
            for (int i = 1; i < arr.Length; i++)
            {
                sFound = false; eFound = false;
                var next = arr[i];
                if (s <= next.start && next.start <= e)
                {
                    s = (s < next.start) ? s : next.start;
                    sFound = true;
                }
                if (next.start <= e && e <= next.end)
                {
                    e = (e > next.end) ? e : next.end;
                    eFound = true;
                }
                //[1,5],[2,4] - [0,4],[1,4]
                if (sFound && !eFound)
                {
                    //e = cur.end;
                }
                else if (!sFound && eFound)
                { //[1,3],[0,4]
                    s = next.start;
                }
                //[1,3],[2,6],[8,10],[9,11] --> [1,6],[8,11]
                //[1,3],[2,6],[8,10],[15,18] --> [1,6],[8,10],[15,18]
                if (!sFound && !eFound)
                {
                    result.Add(new Interval(s, e));
                    s = next.start;
                    e = next.end;
                } 
            }
            //[0, 1],[2,3]
            if (!sFound && !eFound)
            {
                result.Add(new Interval(s, e));
            }
            else if (sFound || eFound)
            {
                result.Add(new Interval(s, e));
            }
            //[0,1],[2,3],[3,5]
            //[0,1],[1,2],[3,5]

            return result;
        }

        private class QComparer : IComparer<Interval>
        {
            public int Compare(Interval n1, Interval n2)
            {
                if (n1.start < n2.start) return -1;
                if (n1.start > n2.start) return 1;
                return 0;
            }
        }
    }
}


