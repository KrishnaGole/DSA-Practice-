using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoPointers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> input = new List<int>()
            //{
            //   //1,4,6,20,3,8,9
            //   //1,2,3,4,5
            //    //5, 10, 20, 100, 105
            //    1, 1000000000
            //};
            //Solve(input, 1000000000);
            Solve2(new List<int>() { 2, 3, 3, 5, 7, 7, 8, 9, 9, 10, 10 }, 11);
        }

        /// <summary>
        /// Subarray with given sum
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static List<int> Solve(List<int> A, int B)
        {
            int p1 = 0, p2 = 0, n = A.Count(), sum = 0;
            while (p2 < n)
            {
                if (sum == B)
                {
                    return A.GetRange(p1, p2 - p1);
                }
                else if (sum > B)
                {
                    sum -= A[p1];
                    p1++;
                }
                else
                {
                    sum += A[p2];
                    p2++;
                }
            }
            if(sum - A[p1] == B)
            {
                p1++;
                return A.GetRange(p1, p2 - p1);
            }

            return new List<int>() { -1 };
        }

        /// <summary>
        /// Pairs with Given Difference
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int Solve1(List<int> A, int B)
        {
            A.Sort();
            int p1 = 0, p2 = 1, count = 0;
            int n = A.Count();
            while (p2 < n)
            {
                if (p1 == p2)
                {
                    p2++;
                    continue;
                }
                int x = A[p1], y = A[p2];
                if (A[p2] - A[p1] == B)
                {
                    count++;
                    while (p1 < n && A[p1] == x)
                    {
                        p1++;
                    }
                    while (p2 < n && A[p2] == y)
                    {
                        p2++;
                    }
                }
                else if (A[p2] - A[p1] > B)
                {
                    p1++;
                }
                else
                {
                    p2++;
                }
            }
            return count;
        }


        /// <summary>
        /// Pairs with given sum II
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int Solve2(List<int> A, int B)
        {
            int n = A.Count(), p1 = 0, p2 = n - 1;
            long ans = 0;
            while (p1 < p2)
            {
                int x = A[p1], y = A[p2];
                if (A[p1] + A[p2] == B)
                {
                    ans++;
                    while (p1 < n && A[p1] == x)
                    {
                        p1++;
                    }
                    while (p1 < p2 && p2 < n && A[p2] == y)
                    {
                        p2--;
                    }
                }
                if (A[p1] + A[p2] > B)
                {
                    p2--;
                }
                else
                {
                    p1++;
                }
            }
            return (int)(ans % 1000000007);
        }
    }
    
}
