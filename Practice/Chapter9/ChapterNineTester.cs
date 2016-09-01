using Practice.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class ChapterNineTester : Util
    {
        

        public void test(int q, int o)
        {
            if (q == 0)
            {
                int[] n1 = { 6, 5, 3, 1, 8, 7, 2, 4, 9, 0 };
                int[] n2 = { 0 };
                int[] n3 = { 6, 5, 5 };
                int[] n4 = { 5, 5, 5, 5, 5 };
                int[] n5 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                int[] n6 = { 3, 7, 8, 5, 2, 1, 9, 5, 4 };
                int[] n7 = { 9, 9, 1, 1, 5, 5, 3, 3, 0, 0 };
                int[] n8 = { 6, 5, 3, 1, 8 };
                List<int[]> list = new List<int[]>();
                list.Add(n1);
                list.Add(n2);
                list.Add(n3);
                list.Add(n4);
                list.Add(n5);
                list.Add(n6);
                list.Add(n7);
                list.Add(n8);
                //bubble sort
                if (o == 0)
                {
                    PrintLn("======= Performing Bubble Sort =======");
                    foreach (var n in list)
                    {
                        PrintLn("Before : " + n.toString());
                        bubbleSort(n);
                        PrintLn("After : " + n.toString());
                    }
                }
                //Selection sort
                else if (o == 1)
                {
                    PrintLn("======= Performing Selection Sort =======");
                    foreach (var n in list)
                    {
                        PrintLn("Before : " + n.toString());
                        selectionSort(n);
                        PrintLn("After : " + n.toString());
                    }
                }
                //Insertion sort
                else if (o == 2)
                {
                    PrintLn("======= Performing Insertion Sort =======");
                    foreach (var n in list)
                    {
                        PrintLn("Before : " + n.toString());
                        insertionSort(n);
                        PrintLn("After : " + n.toString());
                    }
                }
                //Merge sort
                else if (o == 3)
                {
                    PrintLn("======= Performing Merge Sort =======");
                    foreach (var n in list)
                    {
                        PrintLn("Before : " + n.toString());
                        var result = mergeSort(n);
                        PrintLn("After : " + result.toString());
                    }
                }
                //Quick sort
                else if (o == 4)
                {
                    PrintLn("======= Performing Quick Sort =======");
                    foreach (var n in list)
                    {
                        PrintLn("Before : " + n.toString());
                        quickSort(n, 0);
                        PrintLn("After : " + n.toString());
                    }
                }
                //Bucket Sort
                else if (o == 5)
                {
                    PrintLn("======= Performing Bucket Sort =======");
                    foreach (var n in list)
                    {
                        PrintLn("Before : " + n.toString());
                        bucketSort(n);
                        PrintLn("After : " + n.toString());
                    }
                }
            }
            else if (q == 1)
            {
                int[] n1 = { 6, 5, 3, 1, 8, 0, 0, 0, 0, 0 };
                int[] n7 = { 9, 9, 1, 1, 5 };

                PrintLn("Before : " + n1.toString());
                QuestionOne(n1, n7);
                PrintLn("After : " + n1.toString());
            }
            else if (q == 2)
            {
                string[] s = { "silent", "abcdef", "kfc", "listen", "tenlis", "a" };

                QuestionTwo(s);
                var sb = new StringBuilder();
                for (int i = 0; i < s.Length; i++)
                {
                    sb.Append(s[i] + ", ");
                }

                PrintLn(sb);
            }
            else if (q == 3)
            {
                int[] n = { 15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14 };
                int num = 5;

                var index = QuestionThree(n, num);

                PrintLn("Array : " + n.toString());
                PrintLn("Searching for " + num);
                PrintLn((index >= 0) ? "FOUND at " + index : "NOT FOUND");
            }
            else if (q == 4)
            {
                QuestionFour();
            }
            else if (q == 5)
            {
                string[] arr = { "at", "", "", "", "ball", "", "", "car", "", "", "dad", "", "" };
                string find = "ball";
                int index = QuestionFive(arr, find);

                PrintLn("Array : " + arr.toString());
                PrintLn("Searching for " + find);
                PrintLn((index >= 0) ? "FOUND at " + index : "NOT FOUND");
            }
            else if (q == 6)
            {
                int w = 3, l = 8;
                var n = new int[l, w];
                int x = -1, y = -1;
                int find = 20;

                int cnt = 0;
                for (int j = 0; j < l; j++)
                {
                    for (int i = 0; i < w; i++)
                    {
                        n[j, i] = cnt++;
                    }
                }

                QuestionSix(n, out x, out y, find);

                PrintLn(n.toString());
                PrintLn((x == -1) ? find + " NOT FOUND " : find + " FOUND : (" + x + ", " + y + ")");
            }
            else if (q == 7)
            {
                //Person[] p = {
                //    new Person(65, 100),
                //    new Person(70, 150),
                //    new Person(56, 90),
                //    new Person(75, 190),
                //    new Person(60, 95),
                //    new Person(68, 110)
                //};
                Person[] p = {
                    new Person(),
                    new Person(),
                    new Person(),
                    new Person(),
                    new Person(),
                    new Person(),
                    new Person(),
                    new Person(),
                    new Person(),
                    new Person(),
                    new Person(),
                    new Person(),
                };

                PrintLn(p.toString());

                var result = QuestionSeven(p);
                var listHeight = result.Item1;
                var listWeight = result.Item2;
                var bigger = result.Item3;

                PrintLn("HeightList : " + listHeight.ToArray().toString());
                PrintLn("WeightList : " + listWeight.ToArray().toString());
                PrintLn("RESULT : " + bigger.ToArray().toString());
            }
        }

        private void bubbleSort(int[] n)
        {
            for (int i = n.Length - 1; i >= 0; i--)
            {
                var swapped = false;
                for (int j = 0; j < i; j++)
                {
                    if (n[j] > n[j + 1])
                    {
                        var tmp = n[j + 1];
                        n[j + 1] = n[j];
                        n[j] = tmp;
                        swapped = true;
                    }
                }

                if (swapped == false) break;
            }
        }

        private void selectionSort(int[] n)
        {
            for (int i = 0; i < n.Length; i++)
            {
                int index = i;

                for (int j = i + 1; j < n.Length; j++)
                {
                    if (n[j] < n[index])
                    {
                        index = j;
                    }
                }

                int tmp = n[i];
                n[i] = n[index];
                n[index] = tmp;
            }
        }
        //6, 5, 3, 1, 8, 7, 2, 4, 9, 0 
        private void insertionSort(int[] n)
        {
            for (int i = 1; i < n.Length; i++)
            {
                for (int j = i; j > 0 && n[j - 1] > n[j]; j--)
                {
                    int tmp = n[j];
                    n[j] = n[j - 1];
                    n[j - 1] = tmp;
                }
            }
        }
        //6, 5, 3, 1, 8, 7, 2, 4
        private int[] mergeSort(int[] n)
        {
            return mergeSort(n, 0, n.Length);
        }

        private int[] mergeSort(int[] n, int s, int e)
        {
            if (e - s <= 1)
            {
                return new int[] { n[s] };
            }

            int mid = (s + e) / 2;
            int count = e - s;
            var left = mergeSort(n, s, mid);
            var right = mergeSort(n, mid, e);
            var tmp = new int[count];
            int li = 0;
            int ri = 0;

            for (int index = 0; index < count; index++)
            {
                if (li < left.Length && (ri >= right.Length || left[li] < right[ri]))
                {
                    tmp[index] = left[li++];
                }
                else
                {
                    tmp[index] = right[ri++];
                }
            }

            return tmp;
        }

        public void quickSort(int[] n, int o)
        {
            if (o == 0)
            {
                quickSort(n, 0, n.Length - 1);
            }
            else
            {
                quickSortFaster(n, 0, n.Length - 1);
            }
        }
        //6, 5, 3, 1, 8, 7, 2, 4
        private void quickSort(int[] n, int s, int e)
        {
            if (s >= e) return;

            int p = partition(n, s, e);
            quickSort(n, s, p - 1);
            quickSort(n, p + 1, e);
        }
        //6, 5, 3, 1, 8
        private int partition(int[] n, int s, int e)
        {
            int piv = n[e];
            int p = e;
            for (int i = 0; i < p; i++)
            {
                if (n[i] > piv)
                {
                    swap(n, i, p - 1);
                    swap(n, p, p - 1);
                    i--;
                    p--;
                }
            }

            return p;
        }
        //5, 4, 3, 2, 1
        private void quickSortFaster(int[] n, int s, int e)
        {
            if (s >= e) return;

            int p = partitionFaster(n, s, e);
            quickSortFaster(n, s, p);
            quickSortFaster(n, p + 1, e);
        }

        private int partitionFaster(int[] n, int s, int e)
        {
            int pivot = n[s];
            int i = s - 1, j = e + 1;

            while (true)
            {
                for (++i; n[i] < pivot; i++) { }
                for (--j; n[j] > pivot; j--) { }
                if (i >= j) return j;
                swap(n, i, j);
            }
        }

        private void swap(int[] n, int a, int b)
        {
            int tmp = n[a];
            n[a] = n[b];
            n[b] = tmp;
        }

        public void bucketSort(int[] n)
        {
            int max = Int32.MinValue;
            for (int i = 0; i < n.Length; i++) max = (n[i] > max) ? n[i] : max;

            var buckets = new List<int>[max + 1];
            for (int i = 0; i < buckets.Length; i++) buckets[i] = new List<int>();

            for (int i = 0; i < n.Length; i++)
            {
                var b = n[i] % (max + 1);
                buckets[b].Add(n[i]);
            }
            int index = 0;
            for (int i = 0; i < buckets.Length; i++)
            {
                var bucket = buckets[i];
                for (int j = 0; j < bucket.Count; j++)
                {
                    n[index++] = bucket[j];
                }
            }
        }

        public void QuestionOne(int[] n1, int[] n2)
        {
            int j = 0;
            for (int i = n1.Length - n2.Length; i < n1.Length; i++)
            {
                n1[i] = n2[j++];
            }

            qsort(n1);
        }

        private void qsort(int[] n)
        {
            qsort(n, 0, n.Length - 1);
        }

        private void qsort(int[] n, int s, int e)
        {
            if (s >= e) return;

            int p = ptt(n, s, e);
            qsort(n, s, p - 1);
            qsort(n, p + 1, e);
        }

        private int ptt(int[] n, int s, int e)
        {
            int piv = n[e];
            int p = e;
            for (int i = s; i < p; i++)
            {
                if (n[i] > piv)
                {
                    swap(n, i, p - 1);
                    swap(n, p, p - 1);
                    i--;
                    p--;
                }
            }

            return p;
        }

        public void QuestionTwo(string[] s)
        {
            Array.Sort(s, new AnagramComparer());
        }

        private class AnagramComparer : IComparer<String>
        {
            public int Compare(String s1, String s2)
            {
                var c1 = s1.ToArray();
                var c2 = s2.ToArray();
                Array.Sort(c1);
                Array.Sort(c2);
                var a1 = new string(c1);
                var a2 = new string(c2);
                
                return a1.CompareTo(a2);
            }
        }

        public void quickSort(char[] n)
        {
            quickSort(n, 0, n.Length - 1);
        }

        private void quickSort(char[] n, int s, int e)
        {
            if (s >= e) return;
            int p = partition(n, s, e);
            quickSort(n, s, p - 1);
            quickSort(n, p + 1, e);
        }

        private int partition(char[] n, int s, int e)
        {
            int piv = n[e];
            int p = e;
            for (int i = 0; i < p; i++)
            {
                if (n[i] > piv)
                {
                    swap(n, i, p - 1);
                    swap(n, p, p - 1);
                    i--;
                    p--;
                }
            }

            return p;
        }

        private void swap(char[] n, int s, int e)
        {
            char tmp = n[s];
            n[s] = n[e];
            n[e] = tmp;
        }
        //3, 4, 5, 1, 2
        //4, 5, 1, 2, 3
        public int QuestionThree(int[] n, int num)
        {
            int s = 0, e = n.Length - 1;
            for (int m = (s + e) / 2; s <= e; m = (s + e) / 2)
            {
                if (n[m] == num) return m;
                else if (n[s] < n[m])
                {
                    if (n[s] <= num && num < n[m]) e = m - 1;
                    else s = m + 1;
                }
                else
                {
                    if (n[m] < num && num <= n[e]) s = m + 1;
                    else e = m - 1;
                }
            }

            return -1;
        }

        public void QuestionFour()
        {

        }

        public int QuestionFive(string[] arr, string str)
        {
            return QuestionFive(arr, str, 0, arr.Length - 1);
        }

        public int QuestionFive(string[] arr, string str, int s, int e)
        {
            for (int m = (s + e) / 2; s <= e; m = (s + e) / 2)
            {
                if (arr[m].Equals(str) == true) return m;
                if (arr[m] == "")
                {
                    var result = QuestionFive(arr, str, s, m - 1);
                    if (result >= 0) return result;

                    return QuestionFive(arr, str, m + 1, e);
                }
                else if (str.CompareTo(arr[m]) < 0) e = m - 1;
                else s = m + 1;
            }

            return -1;
        }

        public void QuestionSix(int[,] n, out int x, out int y, int num)
        {
            x = -1; y = -1;
            var l = n.GetLength(0);
            var w = n.GetLength(1);
            int sx = 0, sy = 0, ex = w - 1, ey = l - 1;

            for (int midy = (sy + ey) >> 1; sy <= ey; midy = (sy + ey) >> 1)
            {
                if (n[midy, 0] <= num && num <= n[midy, ex])
                {
                    for (int midx = (sx + ex) >> 1; sx <= ex; midx = (sx + ex) >> 1)
                    {
                        if (num == n[midy, midx])
                        {
                            x = midx;
                            y = midy;
                            return;
                        }
                        else if (num < n[midy, midx]) ex = midx - 1;
                        else sx = midx + 1;
                    }

                    return;
                }
                else if (num < n[midy, 0]) ey = midy - 1;
                else sy = midy + 1;
            }
        }

        public Tuple<List<Person>, List<Person>, List<Person>> QuestionSeven(Person[] p)
        {
            var byHeight = new Person[p.Length];
            var byWeight = new Person[p.Length];
            var listHeight = new List<Person>();
            var listWeight = new List<Person>();
            p.CopyTo(byHeight, 0);
            p.CopyTo(byWeight, 0);
            Array.Sort(byHeight, new HeightComparer());
            Array.Sort(byWeight, new WeightComparer());

            listHeight.Add(byHeight[0]);
            var weight = byHeight[0].w;
            for (int i = 1; i < byHeight.Length; i++)
            {
                var person = byHeight[i];
                if (person.w > weight)
                {
                    weight = person.w;
                    listHeight.Add(person);
                }
            }

            listWeight.Add(byWeight[0]);
            var height = byWeight[0].h;
            for (int i = 1; i < byWeight.Length; i++)
            {
                var person = byWeight[i];
                if (person.h > height)
                {
                    height = person.h;
                    listWeight.Add(person);
                }
            }

            var bigger = (listHeight.Count > listWeight.Count) ? listHeight : listWeight;
            return new Tuple<List<Person>, List<Person>, List<Person>>(listHeight, listWeight, bigger);
        }

        public class Person
        {
            public int h { get; set; }
            public int w { get; set; }
            private static Random r = new Random(DateTime.Now.Millisecond);

            public Person()
            {
                this.h = r.Next(1, 100);
                this.w = r.Next(1, 100);
            }

            public Person(int h, int w)
            {
                this.h = h;
                this.w = w;
            }

            public override string ToString()
            {
                return "(" + h + "," + w + ")";
            }
        }

        private class HeightComparer : IComparer<Person>
        {
            public int Compare(Person p1, Person p2)
            {
                if (p1.h == p2.h) return 0;
                else if (p1.h < p2.h) return -1;
                return 1;
            }
        }

        private class WeightComparer : IComparer<Person>
        {
            public int Compare(Person p1, Person p2)
            {
                if (p1.w == p2.w) return 0;
                else if (p1.w < p2.w) return -1;
                return 1;
            }
        }
    }
}
