using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Solve(17);
            //List<List<int>> vs = new List<List<int>>()
            //{
            //    new List<int>(){ 17, 14, 19 },
            //    new List<int>(){ 12, 18, 9},
            //    new List<int>(){ 20, 10, 1 }
            //};
            //Adjacent(vs);
            //List<List<int>> vs = new List<List<int>>()
            //{
            //    new List<int>(){ 9 },
            //    new List<int>(){ 3, 8 },
            //    new List<int>(){ 0,2, 4  },
            //    new List<int>(){ 8, 3, 9, 0  },
            //    new List<int>(){ 5, 2, 2, 7, 3 },
            //    new List<int>(){ 7, 9, 0, 2, 3, 9  },
            //    new List<int>(){ 9, 7, 0, 3, 9, 8, 6  },
            //    new List<int>(){ 5, 7, 6, 2, 7, 0, 3, 9  },
            //    //new List<int>(){2},
            //    //new List<int>(){6,6},
            //    //new List<int>(){7,8,4}
            //};
            //CalculateMinimumHP(vs);
            //var result = Solve(vs);
            //Solve("abbcdgf", "bbadcgf");
            //List<int> A = new List<int>() { 60, 100, 120 };
            //List<int> B = new List<int>() { 60, 100, 120 };
            ////Solve(A, B, 50);
            //Coinchange2(new List<int>() { 4,5,6 }, 12);
            //List<int> vs1 = new List<int>() { 45, 17, 34, 27, 12, 22 };
            //Solve(vs1);
            //ChordCnt(3);
            //Knapsack2(new List<int>() { 6, 10, 12 }, new List<int>() { 10, 20, 30 }, 50);
            //int i = Solve1(3);

            //LengthOfLIS(new List<int>() { 5, 6, 3, 7, 9 });
            Solve("pvgcuhrydk");




        }
        public static string Solve(string A)
        {
            string ans = string.Empty;
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (!map.ContainsKey(A[i]))
                {
                    map[A[i]] = 1;
                }
                else
                {
                map[A[i]]++;

                }
            }
            map = map.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in map)
            {
                int cnt = item.Value;
                while (cnt > 0)
                {
                    ans += item.Key;
                    cnt--;
                }
            }
            return ans;
        }
        public static int Solve(string A, string B)
        {
            int n = A.Count(), m = B.Count(), len = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = m - 1; j >= 0; j--)
                {
                    if (A[i] == B[j])
                    {
                        len++;
                        i--;
                    }
                    else
                    {
                        while (A[i] != B[j])
                        {
                            
                            i--;
                            if(i < 0)
                            {
                                break;
                            }
                        }
                        if (i < 0)
                        {
                            break;
                        }
                        len++;
                    }
                }
            }
            return 0;
        }
        public static int MinimumTotal(List<List<int>> A)
        {
            int n = A.Count;
            for (int i = 1; i < n; i++)
            {
                for(int j = 0; j < A[i].Count(); j++)
                {
                    if(j == 0)
                    {
                        A[i][j] += A[i - 1][j];
                    }
                    else if (j == A[i].Count() - 1)
                    {
                        A[i][j] += A[i - 1][j - 1];
                    }
                    else
                    {
                        A[i][j] += Math.Min(A[i - 1][j], A[i-1][j-1]);
                    }
                   
                }
               
            }
            return A[n- 1].Min();
        }
        public static int Solve(int A)
        {
            List<int> dp = new List<int>() { 1, 1 };
            for (int i = 2; i <= A; i++)
            {
                dp.Add(dp[i - 1] + ((i - 1) * dp[i - 2]));
                
            }
            return dp[A];
        }

        public static int Adjacent(List<List<int>> A)
        {
            int n = A.Count(), maxSum = int.MinValue, j = 0, m = A[0].Count(); 
            List<int> dp = null;
            if(m == 1)
            {
                for (j = 0; j < n; j++)
                {
                   maxSum = Math.Max(maxSum, A[j][0]);
                }
            }
            else
            {
                dp = new List<int>() { A[0][0], Math.Max(A[0][0], A[0][1]) };
                for(j = 1; j < n; j++)
                {
                    dp[0] = Math.Max(dp[0], A[j][0]);
                    dp[1] = Math.Max(dp[1], Math.Max(dp[0], A[j][1]));
                }
                for (j = 2; j < m; j++)
                {
                    int max = Math.Max(dp[j - 1], dp[j - 2] + A[0][j]);
                    for (int k = 1; k < n; k++)
                    {
                        int tempMax = Math.Max(dp[j - 1], dp[j - 2] + A[k][j]);
                        max = Math.Max(max, tempMax);
                    }
                    max = Math.Max(max, A[0][j]);
                    dp.Add(max);
                }
                maxSum = Math.Max(maxSum, dp[dp.Count() - 1]);
            }
              
            return maxSum;
        }

        public static int MinPathSum(List<List<int>> A)
        {
            int n = A.Count, m = A[0].Count();
            int[,] dp = new int[n, m];
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < m - 1; j++)
                {
                    dp[i, j] = Math.Min(dp[i + 1, j], dp[i, j + 1]) + A[i][j];
                }
            }
            return dp[n - 1, m - 1];
        }


        public static int UniquePathsWithObstacles(List<List<int>> A)
        {
            int n = A.Count(), m = A[0].Count();
            int[,] dp = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                if (A[i][0] == 0)
                {
                    dp[i, 0] = 1;

                }
                else
                {
                    break;
                }
            }
            for (int j = 0; j < m; j++)
            {
                if (A[0][j] == 0)
                {
                    dp[0, j] = 1;
                }
                else
                {
                    break;
                }
            }
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (A[i][j] == 1)
                    {
                        dp[i, j] = 0;
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                    }
                }
            }
            return dp[n - 1, m - 1];
        }

        public static int CalculateMinimumHP(List<List<int>> A)
        {
            int n = A.Count(), m = A[0].Count();
            int[,] dp = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    dp[i, j] = -1;
                }
            }
            dp[n - 1, m - 1] = Math.Max(1, 1 - A[n - 1][m - 1]);
            return MinHealth(A, n, m, dp, 0, 0);
        }

        public static int MinHealth(List<List<int>> health, int n, int m, int[,] dp, int i, int j)
        {
            if (i == n || j == m)
            {
                return int.MaxValue;
            }
            if (dp[i, j] == -1)
            {
                int a = MinHealth(health, n, m, dp, i + 1, j);
                int b = MinHealth(health, n, m, dp, i, j + 1);
                dp[i, j] = Math.Max(1, Math.Min(a, b) - health[i][j]);
            }
            return dp[i, j];
        }


        public static int Solve(List<List<int>> A)
        {
            int n = A.Count();
            
            for(int i = 1; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    int temp = A[i][j];
                    A[i][j] = int.MaxValue;
                    if (j == 0)
                    {
                        for(int k = j+1; k < n; k++)
                        {
                            
                            A[i][j] = Math.Min(A[i][j], A[i - 1][k] + temp);
                        }
                    }
                    else if(j == n - 1)
                    {
                        for (int k = n-2; k >= 0; k--)
                        {
                            A[i][j] = Math.Min(A[i][j], A[i - 1][k] + temp);
                        }
                    }
                    else
                    {
                        for (int k = n - 1; k > j; k--)
                        {
                            A[i][j] = Math.Min(A[i][j], A[i - 1][k] + temp);
                        }
                        for (int k = 0; k < j; k++)
                        {
                            A[i][j] = Math.Min(A[i][j], A[i - 1][k] + temp);
                        }
                    }
                    
                }
            }
            int ans = int.MaxValue;
            for(int j = 0; j < n; j++)
            {
                ans = Math.Min(ans, A[n - 1][j]);
            }
            return ans;
        }

        public static int Solve(List<int> A, List<int> B, int C)
        {
            int n = A.Count();
            int[,] dp = new int[n + 1, C + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= C; j++)
                {
                    dp[i, j] = -1;
                }
            }
            return Knapsack(A, B, n -1, C, dp);
        }

        public static int Knapsack(List<int> values, List<int> weigths, int i, int j, int[,] dp)
        {
            if (i < 0 || j == 0)
            {
                return 0;
            }
            if (dp[i, j] == -1)
            {
                int temp = Knapsack(values, weigths, i - 1, j, dp);
                if (j >= weigths[i])
                {
                    temp = Math.Max(temp, Knapsack(values, weigths, i - 1, j - weigths[i], dp) + values[i]);
                }
                dp[i, j] = temp;
            }
            return dp[i, j];
        }

        public static int Coinchange2(List<int> A, int B)
        {
            int mod = 10000007;
            int[] dp = new int[B + 1];
            dp[0] = 1;
            for(int i = 0; i < A.Count(); i++)
            {
                for(int j = A[i]; j <= B; j++)
                {
                    dp[j] += dp[j - A[i]];
                    dp[j] %= mod;
                }
            }
           return dp[B];

        }
        public static int NoOfWays(List<int> A, int i, int j, int[,] dp)
        {
            if (i < 0 || j == 0)
            {
                return 0;
            }
            if (dp[i, j] == -1)
            {
                int temp = NoOfWays(A, i - 1, j, dp);
                if (j >= A[i])
                {
                    temp = (NoOfWays(A, i, j - A[i], dp) + 1);
                }
                dp[i, j] = temp;
            }
            return dp[i, j];
        }

        public static int Solve(List<int> A)
        {
            int n = A.Count();
            int[,] dp = new int[n + 1, n + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    dp[i, j] = -1;
                }
            }
            return MCM(1, n, A, dp);
        }
        public static int MCM(int i, int j, List<int> A, int[,] dp)
        {
            if (i == j)
            {
                return 0;
            }

            if (dp[i, j] == -1)
            {
                int ans = int.MinValue;
                for (int k = i; k < j; k++)
                {
                    int a = MCM(i, k, A, dp);
                    int b = MCM(k + 1, j, A, dp);
                    int c = A[i - 1] * A[k] * A[j-1];
                    ans = Math.Min(ans, a + b + c);
                }
                dp[i, j] = ans;
            }
            return dp[i, j];
        }

        public int ChordCnt(int A)
        {
            int[] chords = new int[A + 1];
            int mod = 100000007;
            chords[0] = 1;
            for (int k = 1; k <= A; k++)
            {
                int i = k - 1, j = 0, sum = 0;
                while (i >= 0)
                {
                    sum = (((sum % mod) + chords[i] % mod * chords[j] % mod % mod) % mod) % mod;
                    //sum %= mod;
                    i--;
                    j++;
                }
                chords[k] = sum;
            }
            return chords[A];
        }


        public static int Knapsack2(List<int> A, List<int> B, int C)
        {
            int n = A.Count(), m = A.Sum(); int? ans = null;
            int[,] dp = new int[2, m + 1];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    dp[i, j] = 1000000000;
                }
            }
            dp[0, 0] = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    int temp = dp[(i - 1)%2, j];
                    if (j >= A[i - 1])
                    {
                        temp = Math.Min(temp, dp[(i - 1)%2, j - A[i - 1]] + B[i - 1]);
                    }
                    dp[(i%2), j] = temp;
                }
            }
           
            for (int i = m; i >= 0; i--)
            {
                if (dp[1, i] <= C)
                {
                    return i;
                }
                //if (dp[1, i] <= C)
                //{ 
                //    if(ans == null)
                //    {
                //        ans = i;
                //    }
                //    if(i != 0 && dp[1, i] == dp[1, i-1])
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        ans = i;
                //        break;
                //  }
           // }
                
            }
            return 0;
        }

        //Find the number of ways you can have fun in A integer days, given you can sleep every day, Pizza can be eaten every alternate day and you can watch Tv shows every two days.
        //Since the answer could be large, return answer % 109 + 7.
        //input A = 2
        //output 7
        //There will be 7 ways to have fun:(SS), (SP), (ST), (PS), (PT), (TS), (TP).
        public static int Solve1(int A)
        {
               int mod = 1000000007;
            int[,] dp = new int[A + 1, 3];
            dp[0, 0] = 1;
                for (int i = 1; i   <= A; i++)
            {
                dp[i, 0] = ((dp[i - 1, 0] % mod) + (dp[i - 1, 1] % mod) + (dp[i - 1, 2] % mod)) % mod;
                dp[i, 1] = ((dp[i - 1, 0] % mod) + (dp[i - 1, 2] % mod)) % mod;
                dp[i, 2] = ((dp[i - 1, 0] % mod) + (dp[i - 1, 1] % mod)) % mod;
                }
                return ((dp[A, 0] % mod) + (dp[A, 1] % mod) + (dp[A, 2] % mod)) % mod;
        }

        //You are given an array A. You need to find the length of the Longest Increasing Subsequence in the array.
        //In other words, you need to find a subsequence of array A in which the elements are in sorted order, (strictly increasing) and as long as possible.
        public static int LengthOfLIS(List<int> nums)
        {
            int n = nums.Count();
            if (n == 0)
                return 0;

            List<int> lis = new List<int>();
            lis.Add(nums[0]);

            for (int i = 1; i < n; i++)
            {
                if (nums[i] > lis[lis.Count - 1])
                {
                    lis.Add(nums[i]);
                }
                else
                {
                    int index = BinarySearch(lis, nums[i]);
                    lis[index] = nums[i];
                }
            }

            return lis.Count;
        }

        private static int BinarySearch(List<int> lis, int target)
        {
            int left = 0;
            int right = lis.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (lis[mid] == target)
                    return mid;
                else if (lis[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return left;
        }

        public static int MinDistance(string A, string B)
        {
            Dictionary<char, int> mapA = new Dictionary<char, int>();
            Dictionary<char, int> mapB = new Dictionary<char, int>();
            int cnt = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (mapA.ContainsKey(A[i]))
                {
                    mapA[A[i]]++;
                }
                else
                {
                    mapA.Add(A[i], 1);
                }
            }
            for (int i = 0; i < B.Length; i++)
            {
                if (mapB.ContainsKey(B[i]))
                {
                    mapB[B[i]]++;
                }
                else
                {
                    mapB.Add(B[i], 1);
                }
            }
            foreach (var item in mapA)
            {
                if (mapB.ContainsKey(item.Key) && mapB[item.Key] != item.Value)
                {
                    cnt += Math.Abs(mapB[item.Key] - item.Value);
                }
                else if (!mapB.ContainsKey(item.Key))
                {
                    cnt++;
                }
            }
            if (A.Distinct().Count() < B.Distinct().Count())
            {
                cnt += Math.Abs(A.Length - B.Length);
            }

            return cnt;

        }



    }
}
