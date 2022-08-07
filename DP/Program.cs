using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<int> vs1 = new List<int>() { 45, 17, 34, 27, 12, 22 };
            //Solve(vs1);
            ChordCnt(3);
           
            
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

        public static int ChordCnt(int A)
        {
            int[] chords = new int[A + 1];
            chords[0] = 1;
            for(int k = 1; k <= A; k++)
            {
                int i = k - 1, j = 0, sum = 0;
                while(i >= 0)
                {
                    sum += chords[i] * chords[j];
                    i--;
                    j++;
                }
            }
            return chords[A];
        }

    }
}