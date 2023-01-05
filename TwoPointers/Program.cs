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
            //var ans = ThreeSum(new List<int>() { 1, -4, 0, 0, 5, -5, 1, 0, -2, 4, -4, 1, -1, -4, 3, 4, -1, -1, -3 });
            //Solve3(new List<int>() { 1, 2, 3, 4, 5 }, 5);
            //Solve(new List<int>() { 1 }, new List<int>() { 2,4 }, 4);
            //Solve4(new List<int>() { 1, 4, 5, 8, 10 }, new List<int>() { 6, 9, 15 }, new List<int>() { 2, 3, 6, 6 });
            //ThreeSumClosest(new List<int>() { 2, 1, -9, -7, -8, 2, -8, 2, 3, -8 }, -1);
            //SortColors(new List<int>() { 2, 0, 0, 1, 0, 0, 2, 2, 1, 1, 0, 0, 1, 0, 2, 2 });
            //Minimize(new List<int>() { 3, 5, 6 }, new List<int>() { 2 }, new List<int>() { 3, 4 });
            //SamePoint(new List<int>() { -1, 0, 1, 2, 3, 3 }, new List<int>() { 1, 0, 1, 2, 3, 4 });
            MinWindow("A", "A");
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

        /// <summary>
        ///  Another Count Rectangles
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int Solve3(List<int> A, int B)
        {
            int n = A.Count() - 1, l = 0, r = n, cnt = 0;
            while (l <= n && r >= 0)
            {
                if (A[l] * (long)A[r] < B)
                {
                    cnt += r + 1;
                    l++;
                }
                else
                {
                    r--;
                }
            }
            return cnt;
        }

        public static List<int> Solve(List<int> A, List<int> B, int C)
        {
            int n = A.Count(), m = B.Count(), diff = int.MaxValue, i = 0, j = m - 1,
            index1 = n, index2 = m;
            while (i < n && j >= 0)
            {
                int temp = Math.Abs(A[i] + B[j] - C);
                if (temp <= diff)
                {
                    diff = temp;
                    index1 = Math.Min(i, index1);
                    index2 = Math.Min(j, index2);

                }
                if(A[i] + B[j] > C)
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }
            return new List<int>() { index1, index2 };
        }

        public static int Solve4(List<int> A, List<int> B, List<int> C)
        {
            int n = A.Count(), m = B.Count(), o = C.Count(),
            i = 0, j = 0, k = 0, ans = int.MaxValue;
            while (i < n && j < m && k < o)
            {
                int min = Math.Min(A[i], Math.Min(B[j], C[k]));
                int diff = Math.Abs(Math.Max(A[i], Math.Max(B[j], C[k])) - min);
               // int diff = Math.Abs(Math.Max(A[i], Math.Max(B[j], C[k])) - Math.Min(A[i], Math.Min(B[j], C[k])));
                if (diff < ans)
                {
                    ans = diff;
                   
                }
                if (A[i] < B[j] && A[i] < C[k])
                {
                    i++;
                }
                else if (B[j] < A[i] && B[j] < C[k])
                {
                    j++;
                }
                else
                {
                    k++;
                }
            }
            return ans;
        }
        public static int ThreeSumClosest(List<int> A, int B)
        {
            A.Sort();
            int n = A.Count(), ans = 100000000;
            for (int i = 0; i < n; i++)
            {
                int j = i, k = n - 1;
                while (j < n && k > i)
                {
                    if (Math.Abs((A[i] + A[j] + A[k] - B)) < Math.Abs(ans - B))
                    {
                        ans = A[i] + A[j] + A[k];
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }
            }
            return ans;
        }

        /// <summary>
        /// Sort by Color
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<int> SortColors(List<int> A)
        {
            int n = A.Count(), i = 0, j = n - 1;
            for (int k = i + 1; k < j; k++)
            {
                if (A[k] != 1)
                {
                    if (A[k] == 0)
                    {
                        while (A[i] == 0 && i < j)
                        {
                            i++;
                        }
                        if(k != i && i < j)
                        {
                            int temp = A[i];
                            A[i] = A[k];
                            A[k] = temp;
                            
                        }
                       
                    }
                    else if (A[k] == 2)
                    {
                        while (A[j] == 2 && j > i)
                        {
                            j--;
                        }
                        if(k < j && j > i)
                        {
                            int temp = A[j];
                            A[j] = A[k];
                            A[k] = temp;
                            
                        }
                        
                    }
                }
            }
            return A;
        }


        /// <summary>
        /// Array 3 Pointers
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <returns></returns>
        public static int Minimize(List<int> A, List<int> B, List<int> C)
        {
            int i = 0, j = 0, k = 0, n = A.Count(), m = B.Count(), l = C.Count(),
            ans = int.MaxValue;
            while (i < n && j < m && k < l)
            {
                ans = Math.Min(ans, Math.Max(Math.Abs(A[i] - B[j]),
                Math.Max(Math.Abs(B[j] - C[k]), Math.Abs(C[k] - A[i]))));
                if (A[i] < B[j] && A[i] < C[k])
                {
                    i++;
                }
                else if (B[j] < A[i] && B[j] < C[k])
                {
                    j++;
                }
                else
                {
                    k++;
                }
            }
            return ans;
        }

        public static int SamePoint(List<int> A, List<int> B)
        {
            int n = A.Count(), ans = 0, curmax = 0, overlap = 0;
            Dictionary<string, int> map = new Dictionary<string, int>();
            if (n < 3)
            {
                return n;
            }
            for(int i = 0; i < n; i++)
            {
                curmax = 0;
                overlap = 0;
                for(int j = i + 1; j < n; j++)
                {
                    if (A[i] == A[j] && B[i] == B[j])
                    {
                        overlap++;
                    }
                    else
                    {
                        int xdiff = A[j] - A[i];
                        int ydiff = B[j] - B[i];
                        int z = GCD(xdiff, ydiff);
                        xdiff /= z;
                        ydiff /= z;
                        string temp = xdiff + "@" + ydiff;
                        if(!map.ContainsKey(temp))
                        {
                            map.Add(temp, 1);
                        }
                        else
                        {
                            map[temp]++;
                        }
                        curmax = Math.Max(curmax, map[temp]);
                    }
                }
                map.Clear();
                ans = Math.Max(ans, curmax + overlap + 1);
            }
            return ans;
           
        }
        public static int GCD(int x, int y)
        {
            if (x == 0)
            {
                return y;
            }

            return GCD(y%x, x);
        }

        public static string MinWindow(string A, string B)
        {
            int n = A.Length, m = B.Length, start = 0, end = 0, total = 0, minLen = n+1, index = -1;
            bool flag = false;
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < m; i++)
            {
                if (!map.ContainsKey(B[i]))
                {
                    map.Add(B[i], 1);
                }
                else
                {
                    map[B[i]]++;
                }
            }
            //ADOBECODEBANC

            while (end < n)
            {
                if (map.ContainsKey(A[end]))
                {
                    if (map[A[end]] > 0)
                    {
                        total++;
                    }
                    map[A[end]]--;
                }
                while (total == m)
                {
                    if (minLen > end - start + 1)
                    {
                        index = start;
                        minLen = end - start + 1;
                    }
                    if (map.ContainsKey(A[start]) && map[A[start]] <= 0)
                    {
                        map[A[start]]++;
                        if (map[A[start]] > 0)
                        {
                            total--;
                        }
                        
                    }
                    start++;


                }
                end++;
            }
            return index != -1 ? A.Substring(index, minLen) : string.Empty;
        }
    }
    
}
