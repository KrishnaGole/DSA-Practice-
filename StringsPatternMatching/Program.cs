using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsPatternMatching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LpsValue("11111111111111111111");
            // Solve("deda", "qqedapeqpdooaooabbqeqqadeeqccepaocqadq");
            Solve1("HIR", "HIRE");
           
            
        }

        /// <summary>
        /// LPS array of the string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static List<int> LpsValue(string s)
        {
            int n = s.Length;
            List<int> lps = new List<int>();
            lps.Add(0);
            for(int i = 1; i < n; i++)
            {
                int x = lps[i - 1];
                while(s[x] != s[i])
                {
                    if(x == 0)
                    {
                        x = -1;
                        break;
                    }
                    x = lps[x - 1];
                }
                lps.Add(x + 1);
            }
            return lps;
        }

        /// <summary>
        /// Beggars Outside Temple
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int Solve(string A, string B)
        {
            int n = A.Length, m = B.Length, p1 = 0, p2 = n-1, ans = 0;
            Dictionary<int, int> mapA = new Dictionary<int, int>();
            Dictionary<int, int> mapB = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
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
            for(int i = 0; i < n-1; i++)
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
            while (p2 < m)
            {
                if (mapB.ContainsKey(B[p2]))
                {
                    mapB[B[p2]]++;
                }
                else
                {
                    mapB.Add(B[p2], 1);
                }
                
                if(mapA.Count() == mapB.Count())
                {
                    bool isSame = true;
                    for(int i = 0; i < mapA.Count(); i++)
                    {
                        mapB.TryGetValue(mapA.ElementAt(i).Key, out int value);
                        if (!mapB.ContainsKey(mapA.ElementAt(i).Key) ||  value != mapA.ElementAt(i).Value)
                        {
                            isSame = false;
                        }
                    }
                    if (isSame)
                    {
                        ans++;
                    }
                }
                mapB[B[p1]]--;
                if (mapB[B[p1]] <= 0)
                {
                    mapB.Remove(B[p1]);
                }
                p1++;
                
                p2++;
            }
            return ans;

        }

        public static int Solve1(string A, string B)
        {
            int n = A.Length, m = B.Length, i = 0, j = 0;
            for (i = 0; i < n; i++)
            {
                 bool isSame = false;
                while (j < m)
                {
                    if (B[j] != A[i])
                    {
                        break;
                    }
                    else
                    {
                        isSame = true;
                        j++;
                    }
                }
                if (!isSame)
                {
                    return 0;
                }
            }
            return 1;
        }


    }
}
