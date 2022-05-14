using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceHashing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LongestConsecutive(new List<int>() { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 });
            //Iszero(new List<int>() { 1, 2, -3, 3 });
            //LengthOfLongestSubstring("dadbc");
            //Solve(new List<int>() { 1, 1, 2, 3, 3 }, new List<int>() { 1, 2, 1, 2, 1 });
            //Solve(2, "bbaabb");
            //Solve(new List<List<int>>() { new List<int>() { 0, 6 } });
            //DNums(new List<int>() { 31, 51, 31, 51, 31, 31, 31, 31, 31, 31, 51, 31, 31 }, 3);
            DNums(new List<int>() { 1, 2, 1, 3, 4, 3 }, 3);
        }

        public static int LongestConsecutive(List<int> A)
        {
            int n = A.Count(), count = 1, ans = 0;
            HashSet<int> hs = new HashSet<int>();
           
            for (int i = 0; i < n; i++)
            {
                hs.Add(A[i]);
            }

            foreach (int element in hs)
            {
                if(!hs.Contains(element - 1))
                {
                    int ele = element+1;
                    while (hs.Contains(ele))
                    {
                        ele++;
                        count++;
                    }
                    ans = Math.Max(count, ans);
                    count = 1;
                }
            }
            return ans;
        }


        /// <summary>
        /// Sub-array with 0 sum
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int Solve(List<int> A)
        {
            HashSet<int> hs = new HashSet<int>();
            int n = A.Count(), prefix = 0;
            for (int i = 0; i < n; i++)
            {
                prefix = prefix + A[i];
                if (hs.Contains(prefix)){
                    return 1;
                }
                else if (prefix == 0)
                {
                    return 1;
                }
                else
                {
                    hs.Add(prefix);
                }
            }
            return 0;

        }

        /// <summary>
        ///  Largest Continuous Sequence Zero Sum
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<int> Iszero(List<int> A)
        {
            Dictionary<long, int> map = new Dictionary<long, int>();
            long prefix = 0, n = A.Count();
            List<int> ans = new List<int>();
            map.Add(prefix, 0);
            for (int i = 0; i < n; i++)
            {
                prefix += A[i];
                if (map.ContainsKey(prefix))
                {
                    ans = A.GetRange(map[prefix], i - map[prefix] + 1);
                }
                else
                {
                    map.Add(prefix, i+1);
                }
            }
            return ans;

        }

        /// <summary>
        ///  Longest Substring Without Repeat
        /// <param name="A"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstring(string A)
        {
            int n = A.Count(), p1 = 0, p2 = 0, ans = 0;
            HashSet<char> hs = new HashSet<char>();
            while (p2 < n)
            {
                if (hs.Contains(A[p2]))
                {
                    ans = Math.Max(ans, hs.Count());
                    hs.Remove(A[p1]);
                    p1++;
                }
                else
                {
                    hs.Add(A[p2]);
                    p2++;
                }
                ans = Math.Max(ans, hs.Count());
            }
            return ans;
        }

        /// <summary>
        ///  Count Right Triangles
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int Solve(List<int> A, List<int> B)
        {
            int n = A.Count(), mod = 1000000007; long ans = 0;
            Dictionary<int, int> hmx = new Dictionary<int, int>();
            Dictionary<int, int> hmy = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                if (!hmx.ContainsKey(A[i]))
                {
                    hmx.Add(A[i], 1);
                }
                else
                {
                    hmx[A[i]]++;
                }
                if (!hmy.ContainsKey(B[i]))
                {
                    hmy.Add(B[i], 1);
                }
                else
                {
                    hmy[B[i]]++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                ans += ((hmx[A[i]] - 1) % mod * (hmy[B[i]] - 1)) % mod;
            }
            return (int)ans;
        }

        /// <summary>
        ///  Replicating Substring
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int Solve(int A, string B)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            int n = B.Length;
            for (int i = 0; i < n; i++)
            {
                if (map.ContainsKey(B[i]))
                {
                    map[B[i]]++;
                }
                else
                {
                    map.Add(B[i], 1);
                }
            }
            if (map.Count() == 1 && map[B[0]] == A)
            {
                return 1;
            }
            foreach (var m in map)
            {
                if(m.Value % A != 0)
                {
                    return -1;
                }
            }
            return 1;
        }

        /// <summary>
        /// Unique 2D points
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int Solve(List<List<int>> A)
        {
            int n = A[0].Count();
            HashSet<string> hs = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                hs.Add($"{A[i][0]}, {A[i][1]}");
            }
            return hs.Count();
        }

        /// <summary>
        /// Count Rectangles
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int Solve1(List<int> A, List<int> B)
        {
            int n = A.Count();
            HashSet<string> hs = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                hs.Add($"{A[i]},{B[i]}");
            }
            int ans = 0;
            StringBuilder p1 = new StringBuilder(), p2 = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int x1 = A[i], y1 = B[i], x2 = A[j], y2 = B[j];
                    if (x1 == x2 || y1 == y2)
                    {
                        continue;
                    }
                    p1.Clear();
                    p2.Clear();
                    p1.Append($"{x1},{y2}"); 
                    p2.Append($"{x2},{y1}");
                    if (hs.Contains(p1.ToString()) && hs.Contains(p2.ToString()))
                    {
                        ans++;
                    }
                }
            }
            return ans / 2;
        }


        /// <summary>
        /// Distinct Numbers in Window
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static List<int> DNums(List<int> A, int B) {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int n = A.Count(), count = 0;
            List<int> ans = new List<int>();
            if (B > n)
            {
                return ans;
            }
            else
            {
                for (int i = 0; i < B; i++)
                {
                    if (map.ContainsKey(A[i]))
                    {
                        map[A[i]]++;
                    }
                    else
                    {
                        map.Add(A[i], 1);
                    }
                }
                ans.Add(map.Count());
                for (int i = B; i < n; i++)
                {
                    if (map.ContainsKey(A[i - B]) && map[A[i - B]] > 0){
                        map[A[i - B]]--;
                        if (map[A[i - B]] == 0){
                            map.Remove(A[i - B]);
                        }
                    }
                    if (map.ContainsKey(A[i]))
                    {
                        map[A[i]]++;
                    }
                    else
                    {
                        map.Add(A[i], 1);
                    }
                    ans.Add(map.Count());
                }
            }
            return ans;
        }

    }
}
