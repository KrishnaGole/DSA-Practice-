using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceContest2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Solve1("oyorooms", 1, "o");
            LCPrefix(new List<string>() { "ab", "ac", "bc" }, 1);
        }

        /// <summary>
        /// Contiguous characters
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <returns></returns>
        public static int Solve(string A, int B, string C)
        {
            char c = Convert.ToChar(C);
            int n = A.Count(), ans = int.MinValue, oddChar = 0;
            int j = 0;
            for (int i = 0; i < n; i++)
            {
                oddChar = 0;
                for ( j = i; j < n; j++)
                {
                    
                    if (A[j] != c)
                    {
                        oddChar++;
                    }
                    if (oddChar <= B)
                    {
                        ans = Math.Max(ans, j - i + 1);
                    }

                }
               
            }
            return ans;
        }

        /// <summary>
        /// Contiguous characters
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <returns></returns>
        public static int Solve1(string A, int B, string C)
        {
            char c = Convert.ToChar(C);
            int ans = 0, otherChar = 0, right = -1, n = A.Count();
            for(int i = 0; i < n; i++)
            {
                while (right + 1 < n)
                {
                    if(A[right+1] != c)
                    {
                        otherChar++;
                    }
                    if(otherChar <= B)
                    {
                        right++;
                    }
                    else
                    {
                        otherChar--;
                        break;
                    }
                    
                }
                ans = Math.Max(ans, right - i + 1);
                if (A[i] != c)
                {
                    otherChar--;
                }

            }
            return ans;
        }

        /// <summary>
        /// Longest common prefix ||
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int LCPrefix(List<string> A, int B)
        {
            int n = A.Count(), ans = 0, cnt = 1, mod = 1000000007;
            for (int i = 0; i < n; i++)
            {
                A[i] = A[i].Substring(0, B);
            }
            for (int i = 1; i < n; i++)
            {
                if (A[i] == A[i - 1])
                {
                    cnt++;
                }
                else
                {
                    ans += (cnt * (cnt + 1)) / 2;
                    ans %= mod;
                    cnt = 1;
                }
            }
            return ans;
        }
    }
}
