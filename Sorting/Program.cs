using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> vs = new List<int>() {1,2,9,4,5,6 };
            //BubbleSort(vs);
            //Count(new List<int>() { 2, 1, 4, 3, 2 });
            //kthsmallest(new List<int>() { 8, 16, 80, 55, 32, 8, 38, 40, 65, 18, 15, 45, 50, 38, 54, 52, 23, 74, 81, 42, 28, 16, 66, 35, 91, 36, 44, 9, 85, 58, 59, 49, 75, 20, 87, 60, 17, 11, 39, 62, 20, 17, 46, 26, 81, 92 }, 9);
            // Console.WriteLine(checkSorted(vs));
            //ElementRemoval(new List<int>() { 3, 5, 1, -3 });
            //LargestNum(new List<int>() { 8,89 });
            //QuickSorting quickSorting = new QuickSorting();
            //List<int> vs = new List<int>() { 10, 7, 8, 9, 1, 5 };
            // quickSorting.QuickSort(vs, 0, vs.Count() - 1);
            solve(new List<int>() { 1, 2, 3 });
            Console.ReadLine();
        }

        static bool checkSorted(List<int> vs)
        {
            for(int i = 0; i < vs.Count() - 2; i++)
            {
                if(vs[i] > vs[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        //static bool recursiveCheckSorted(List<int> vs)
        //{
        //    //int i = 0;
           
        //    //if(i > vs.Count() - 2 && vs[i] > vs[i+1])
        //    //{
        //    //    return false;
        //    //}
        //    //return recursiveCheckSorted(, secondElement)
        //}

        static void BubbleSort(List<int> vs)
        {
            int count = 0;
            for (int i = 1; i < vs.Count(); i++)
            {
                count = 0;
                for(int j = 0; j <= vs.Count() - 1 - i; j++)
                {
                    if(vs[j] > vs[j + 1])
                    {
                        count++;
                        Swap(vs, j, j+1);
                    }
                }
                if(count == 0)
                {
                    break;
                }
            }
        }


        static void Swap(List<int> vs, int i, int j)
        {
            int temp = vs[i];
            vs[i] = vs[j];
            vs[j] = temp;
        }

        public static int Count(List<int> A)
        {
            int count = 0;
            for (int i = 1; i <= A.Count() - 1; i++)
            {
                for (int j = 0; j <= A.Count() - 1 - i; j++)
                {
                    if (A[j] > A[j + 1])
                    {
                        int temp = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = temp;
                        count++;
                    }
                }
            }
            return count;
        }

        public static int kthsmallest(List<int> A, int B)
        {
            int count = 0;
            for (int i = 1; i <= A.Count(); i++)
            {
                count = 0;
                for (int j = 0; j <= A.Count() - 1 - 1; j++)
                {
                    if (A[j] > A[j + 1])
                    {
                        count++;
                        int temp = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = temp;
                    }
                }
                if (count == 0)
                {
                    break;
                }
            }

            int start = 0;
            int end = A.Count();
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (A[mid] == B)
                {
                    return A[mid];
                }
                else if (A[mid] > B)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return -1;
        }


        /// <summary>
        /// Elements Removal
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int ElementRemoval(List<int> A)
        {
            int n = A.Count();
            int ans = 0;
            A = A.OrderByDescending(x => x).ToList();
            for(int i = 0; i < n; i++)
            {
                ans += A[i] * (i + 1);
            }
            return ans;
        }


        public static string LargestNum(List<int> A)
        {
            int n = A.Count();
           
            StringBuilder ans = new StringBuilder();
            A.Sort(new CustomNumberComparer());
            for(int i = 0; i < n; i++)
            {
                ans.Append(A[i]);
            }
            return ans.ToString();
        }

        public static int solve(List<int> A)
        {
            A.Sort();
            long max = 0, min = 0, mod = 1000000007;
            int n = A.Count(), p1 = 0, p2 = n - 1;
            for (int i = 0; i < n; i++)
            {
                max = (A[i] % mod * pow(2, p1, mod) % mod) % mod;
                min = (A[i] % mod * pow(2, p2, mod) % mod) % mod;
                p1++;
                p2--;
            }
            long ans = (max - min) % mod;
            return ans < 0 ? (int)(ans + mod) : (int)ans;
        }

        public static long pow(long A, long B, long C)
        {
            if (B == 0)
            {
                return 1;
            }

            long ha = pow(A, B / 2, C);
            long he = (ha % C * ha % C) % C;
            if (B % 2 == 0)
            {
                return he;
            }
            else
            {
                return (he % C * A % C) % C;
            }
        }
    }

    public class CustomNumberComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            string a1 = x.ToString() + y.ToString();
            string b1 = y.ToString() + x.ToString();
            return Convert.ToInt32(a1) > Convert.ToInt32(b1) ? -1 : 1;
        }
    }

    public class QuickSorting
    {
        public void QuickSort(List<int> A, int start, int end)
        {
            if(start >= end)
            {
                return;
            }
            int pivot_idex = Partition(A, start, end);
            QuickSort(A, start, pivot_idex - 1);
            QuickSort(A, pivot_idex + 1, end);
        }

        private int Partition(List<int> arr, int low, int high)
        {
            int pivot = arr[high];
            int temp = 0;
            int i = (low - 1); // index of smaller element 
            for (int j = low; j < high; j++)
            {
                // If current element is smaller than or 
                // equal to pivot 
                if (arr[j] <= pivot)
                {
                    i++;

                    // swap arr[i] and arr[j] 
                    //temp = arr[i];
                    //arr[i] = arr[j];
                    //arr[j] = temp;
                    Swap(arr, i, j);
                }
            }

            // swap arr[i+1] and arr[high] (or pivot) 
            //temp = arr[i + 1];
            //arr[i + 1] = arr[high];
            //arr[high] = temp;
            Swap(arr, i + 1, high);

            return i + 1;
            //int pivot_index = 0, pivot = A[end];
            //for (int i = start; i < end - 1; i++)
            //{
            //    if (A[i] < pivot)
            //    {
            //        Swap(A, A[i], pivot_index);
            //        pivot_index++;
            //    }
            //}
            //Swap(A, end, pivot_index + 1);
            //return pivot_index + 1;
        }

        private void Swap(List<int> A, int x, int pivot_index)
        {
            int temp = A[x];
            A[x] = A[pivot_index];
            A[pivot_index] = temp;
        }
    }
}
