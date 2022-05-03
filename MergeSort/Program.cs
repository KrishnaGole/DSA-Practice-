using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var result = MergeTwoSortedArray(new List<int>() { 4, 7, 9 }, new List<int>() { 2, 11, 19 });
            //var result = Solve(new List<int>() { 0 , 1 , 5}, 1,5);
            MergeSort(new List<int>() { 1, 4, 10, 2, 1, 5 }, 0, 5);
        }

        public static List<int> MergeTwoSortedArray(List<int> A, List<int> B)
        {
            List<int> sorted = new List<int>();
            int p1 = 0, p2 = 0;
            int n = A.Count();
            int m = B.Count();

            while (p1 < n && p2 < m)
            {
                if (A[p1] <= B[p2])
                {
                    sorted.Add(A[p1]);
                    p1++;
                }
                else
                {
                    sorted.Add(B[p2]);
                    p2++;
                }
            }
            while (p1 < n)
            {
                sorted.Add(A[p1]);
            }
            while (p2 < m)
            {
                sorted.Add(B[p2]);
            }
            return sorted;

        }

        static void MergeSort(List<int> A, int s, int e)
        {
            if (s == e)
            {
                return;
            }
            int m = (s + e) / 2;
            MergeSort(A, s, m);
            MergeSort(A, m + 1, e);
            Merge(A, s, m, e);
        }
        static void Merge(List<int> A, int s, int m, int e)
        {
            List<int> temp = new List<int>();
            int p1 = s; int p2 = m + 1;
            while (p1 <= m && p2 <= e)
            {
                if (A[p1] <= A[p2])
                {
                    temp.Add(A[p1]);
                    p1++;
                }
                else
                {
                    temp.Add(A[p2]);
                    p2++;
                }
            }
            while (p1 <= m)
            {
                temp.Add(A[p1]);
                p1++;
            }
            while (p2 <= e)
            {
                temp.Add(A[p2]);
                p2++;
            }
            for (int i = 0; i < temp.Count(); i++)
            {
                A[i + s] = temp[i];
            }
        }
    }
}
