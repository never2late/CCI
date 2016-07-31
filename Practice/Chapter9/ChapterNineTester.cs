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
                int[] n4 = { 5, 5, 5, 5, 5};
                int[] n5 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                int[] n6 = { 3, 7, 8, 5, 2, 1, 9, 5, 4};
                int[] n7 = { 9, 9, 1, 1, 5, 5, 3, 3, 0, 0 };
                List<int[]> list = new List<int[]>();
                list.Add(n1);
                list.Add(n2);
                list.Add(n3);
                list.Add(n4);
                list.Add(n5);
                list.Add(n6);
                list.Add(n7);
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
                        quickSort(n);
                        PrintLn("After : " + n.toString());
                    }
                }
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
                for (int j = i;  j > 0 && n[j - 1] > n[j]; j--)
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

            for (int index = 0; index < count ; index++)
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

        public void quickSort(int[] n)
        {
            quickSort(n, 0, n.Length - 1);
        }
        //6, 5, 3, 1, 8, 7, 2, 4

        //5, 4, 3, 2, 1
        private void quickSort(int[] n, int s, int e)
        {
            if (s >= e) return;

            int p = partition(n, s, e);
            quickSort(n, s, p);
            quickSort(n, p + 1, e);
        }

        private int partition(int[] n, int s, int e)
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
    }
}
