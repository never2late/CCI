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
    }
}
