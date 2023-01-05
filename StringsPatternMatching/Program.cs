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
            //Solve1("HIR", "HIRE");
            //Solve("aaaaa");
            //Solve(2, 3);
            //Atoi("-88297 248252140B12 37239U4622733246I218 9 1303 44 A83793H3G2 1674443R591 4368 7 97");
            //Solve2("hwmylitp", "hwmylitp");
           
            
        }

        public static int Atoi(string A)
        {
            long num = 0;
            int n = A.Length, i = 0;
            bool flag = false;
            if (A[i] == '+')
            {
                i++;
            }
            else if (A[i] == '-')
            {
                flag = true;
                i++;
            }
            while (i < n && A[i] >= 48 && A[i] <= 58)
            {
                num = Math.Abs(num);
                num = num * 10 + (A[i] - '0');
                if (flag)
                {
                    num = num * -1;
                }
                if (num > int.MaxValue)
                {
                    return int.MaxValue;
                }
                if (num < int.MinValue)
                {
                    return int.MinValue;
                }
                i++;

            }
            return (int)num;
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

        public static int Solve(string A)
        {

            StringBuilder rev = new StringBuilder(A);
            int n = A.Length, i = 0, j = 1, m = 0;
            for (i = 0; i < n / 2; i++)
            {
                char temp = rev[i];
                rev[i] = rev[n - 1 - i];
                rev[n - 1 - i] = temp;
            }
            string concat = A + "@" + rev;
            m = concat.Length;
            i = 0;
            int[] lps = new int[m];
            while (j < m)
            {
                if (concat[i] == concat[j])
                {
                    i++;
                    lps[j] = i;
                    j++;
                }
                else
                {
                    if (i != 0)
                    {
                        i = lps[i - 1]; 
                    }
                    else
                    {
                        lps[j] = 0;
                        j++;
                    }
                }
            }
            return n - lps.Last();
        }

        public string smallestPrefix(string A, string B)
        {
            int n = A.Length, m = B.Length, i = 0, j = 0;
            bool flagA = false, flagB = false;
            if (A[0] == B[0])
            {
                return A[0].ToString() + B[0].ToString(); ;
            }
            StringBuilder ans = new StringBuilder();
            while (i < n && j < m)
            {
                if (flagA && flagB)
                {
                    return ans.ToString();
                }
                if (A[i] < B[j])
                {
                    ans.Append(A[i]);
                    i++;
                    flagA = true;
                }
                else
                {
                    ans.Append(B[j]);
                    j++;
                    flagB = true;
                }
            }
            if (flagA && flagB)
            {
                return ans.ToString();
            }
            if (i == 0)
            {
                ans.Append(A[i]);
            }
            if (j == 0)
            {
                ans.Append(B[j]);
            }
            return ans.ToString();
        }

        public static int Solve(int A, int B)
        {
            long low = 0, high = (long)Math.Pow(2, A + 1) - 1;
            int ans = 0;
            //return (int)high;
            while (low < high)
            {
                long mid = low + (high - low) / 2;
                if (mid == B)
                {
                    break;
                }
                if (mid < B)
                {
                    ans = ans ^ 1;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return ans;

        }

        public int Solve1(string A)
        {
            int n = A.Length;
            StringBuilder even = new StringBuilder();
            StringBuilder odd = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                if (A[i] % 2 == 0)
                {
                    even.Append(A[i]);
                }
                else
                {
                    odd.Append(A[i]);
                }
            }
            
            even = new StringBuilder(String.Concat(even.ToString().OrderBy(x => x)));
            odd = new StringBuilder(String.Concat(odd.ToString().OrderBy(x => x)));
            if (Math.Abs(even[even.Length - 1] - odd[0]) != 1 || Math.Abs(odd[odd.Length - 1] - even[0]) != 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public static int Solve2(string A, string B)
        {
            int n = A.Length, m = B.Length, i = 0, j = 0, cnt = 0;
            int[] lps = new int[m];
            ComputeLPSArray(B, m, lps);
            while (i < Math.Min(n, m))
            {
                if (A[i] == B[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
                if (j == m)
                {
                    cnt++;
                    j = lps[j - 1];
                }
            }
            return cnt;

        }

        public static void ComputeLPSArray(string pattern, int m, int[] lps)
        {
            int len = 0, i = 1;
            while (i < m)
            {
                if (pattern[i] == pattern[len])
                {
                    lps[i] = len + 1;
                    len++;
                    i++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = lps[len - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }
        }


    }

    
    
}
