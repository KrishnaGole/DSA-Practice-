using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchAndSorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BinarySearchCls binarySearchCls = new BinarySearchCls();
            //List<int> A = new List<int>() { 3, 4, 4, 6 };
            //List<int> B = new List<int>() { 20, 4, 10, 2 };
            //binarySearchCls.solve(A, B);
            //SearchInsert(new int[] { 1, 3, 5, 6 }, 2);
            //List<int> vs = new List<int>(1000000);
            //for (int i = 0; i < 10; i++)
            //{
            //    vs.Add(i);
            //}
            ClimbStairs(3);
            //Console.WriteLine(binarySearchCls.IndexOfElement(vs, 3));
            //Sorting sorting = new Sorting();
            //Console.WriteLine(sorting.sqrt1(11));
            Console.ReadLine();
        }

        public static int SearchInsert(int[] nums, int target)
        {
            int n = nums.Length, low = 0, high = n - 1, mid = 0;
            while (low <= high)
            {
                mid = (low + high) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                if (nums[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return low;
        }

        public static int ClimbStairs(int n)
        {
            int nminusone = 1, nminustwo = 1, total = 0;
            for (int i = 2; i <= n; i++)
            {
                total = nminusone + nminustwo;
                nminusone = nminustwo;
                nminustwo = total;
            }
            return total;
        }
    }

    class BinarySearchCls
    {
        public int IndexOfElement(List<int> vs, int key)
        {
            int start = 0;
            int end = vs.Count()-1;
            while(start <= end)
            {
                int mid = (start + end) / 2;
                if(vs[mid] == key)
                {
                    return mid;
                }
                else if(vs[mid] > key)
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

        public List<int> solve(List<int> A, List<int> B)
        {
            List<int> vs = new List<int>();
            for (int i = 0; i < B.Count(); i++)
            {
                vs.Add(binarySearch(A, B[i]));
            }
            return vs;
        }

        public int binarySearch(List<int> vs, int key)
        {
            int start = 0;
            int count = 0;
            int end = vs.Count() - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (vs[mid] <= key)
                {
                    count++;
                    start = mid;
                }
                else if (vs[mid] > key)
                {
                    end = mid - 1;
                }
                else
                {
                    start = start + 1;
                }
            }
            return count;
        }

    }
    class Sorting
    {
        public int sqrt(int A)
        {
            if(A == 1)
            {
                return 1;
            }
            int start = 0;
            int end = A ;
            long mid = 0;
            while(start <= end)
            {
                mid = (start + end) / 2;
                if(mid*mid == A || (mid*mid < A && (mid+1) * (mid+1) > A)){
                    return (int)mid;
                }
                else if(mid* mid > A)
                {
                    end = (int)mid - 1;
                }
                else
                {
                    start = (int)mid + 1;
                }
            }
            return (int)mid;

        }

        public int sqrt1(int A)
        {
            int low = 1, high = A, root = 0;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (mid == A / mid && (A % mid == 0))
                    return mid;
                if (mid <= A / mid)
                {
                    root = mid;
                    low = mid + 1;
                }
                else
                    high = mid - 1;
            }
            return root;
        }
    }
    
}