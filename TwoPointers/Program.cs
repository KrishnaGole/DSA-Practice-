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
            //Solve2(new List<int>() { 1, 1,2 ,2, 2, 3, 4, 5, 6, 7, 8, 9 }, 2);
            var ans = ThreeSum(new List<int>() { 1, -4, 0, 0, 5, -5, 1, 0, -2, 4, -4, 1, -1, -4, 3, 4, -1, -1, -3 });
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
            int i = 0, j = A.Count - 1, mod = 1000 * 1000 * 1000 + 7;
            long ans = 0;
            while (i < j)
            {
                if (A[i] + A[j] == B)
                {
                    int ii = i, jj = j;
                    if (A[i] == A[j])
                    {
                        long cnt = j - i + 1;
                        ans += (cnt * (cnt - 1) / 2) % mod;
                        ans %= mod;
                        break;
                    }
                    else
                    {
                        // count number of elements with value A[i]
                        while (A[i] == A[ii])
                        {
                            ii++;
                        }
                        int cnt1 = ii - i;
                        i = ii;

                        // count number of elements with value A[i]
                        while (A[jj] == A[j])
                        {
                            jj--;
                        }
                        int cnt2 = j - jj;
                        j = jj;
                        ans += (cnt1 * cnt2) % mod;
                        ans %= mod;
                    }
                }
                else if (A[i] + A[j] > B)
                {
                    j--;
                }
                else i++;
            }
            return (int)ans;

        }

        /// <summary>
        /// 3 Sum Zero
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<List<int>> ThreeSum(List<int> A)
        {
            A.Sort();
            int n = A.Count();
            List<List<int>> ans = new List<List<int>>();
            for (int i = 0; i < n - 3; i++)
            {
                int p1 = i + 1, p2 = n - 1 - i;
                while (p1 < p2)
                {
                    if (A[p1] + A[p2] == 0 - A[i])
                    {
                        ans.Add(new List<int>() { A[i], A[p1], A[p2] });
                        //p1++;
                        p2--;
                    }
                    else if (A[p1] + A[p2] > 0 - A[i])
                    {
                        p2--;
                    }
                    else
                    {
                        p1++;
                    }
                }
            }
            return ans.GroupBy(x => string.Join(",", x), (g, items) => items.First()).ToList();
        }
    }
    
}
