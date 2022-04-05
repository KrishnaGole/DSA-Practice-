using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsequencesSubsets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //HashSet<List<int>> hs = new HashSet<List<int>>();
            //List<List<int>> vs = new List<List<int>>();
            ////SUBARRAYOR(new List<int>() { 1, 2, 3, 4, 5 });
            ////Solve("scsecugqsb");
            //Subsets(new List<int>() { 1,2,3 });
            //Solve(new List<int>() { 43, 46, 33, 7 });
            // Solve1(new List<int>() { 5, 4, 2 });
            Solve("apple", "appel");
            Console.ReadLine();
        }

        public static int SUBARRAYOR (List<int> A)
        {
            int n = A.Count();
            int[] idx = new int[32];
            long ans = 0;
            for (int i = 1; i <= n; i++)
            {
                long temp = A[i - 1];
                for (int j = 0; j < 32; j++)
                {
                    long pw = 1 << j;
                    if ((temp & pw) != 0)
                    {
                        ans += pw * i;
                        idx[j] = i;
                    }
                    else if (idx[j] != 0)
                    {
                        ans += pw * idx[j];
                    }
                }
            }
            return (int)(ans % 1000000007);

        }

        /// <summary>
        ///  Little Ponny and 2-Subsequence
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static string Solve(string A)
        {
            string temp = String.Concat(A.OrderBy(c => c));
            string ans = "";
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == temp[0] || A[i] == temp[1])
                {
                    if (A[i] == temp[0])
                    {
                        ans += temp[0].ToString() + temp[1].ToString();
                        break;
                    }
                    else
                    {
                        ans += temp[1].ToString() + temp[0].ToString();
                        break;
                    }
                }
            }
            return ans;
        }

        public static List<List<int>> Subsets(List<int> A)
        {
            int n = A.Count();
            List<List<int>> ans = new List<List<int>>();
            
            for (int i = 0; i < (1 << n); i++)
            {
                List<int> temp = new List<int>();
                for (int j = 0; j < n; j++)
                {
                    if (((i & (1 << j)) > 0))
                    {
                        temp.Add(A[j]);
                    }
                }
                ans.Add(temp);
            }
            ans.Sort(new CustomTwoIntListComparer());
            //var result = ans.Select(lst => lst.OrderBy(i => i).ToList()).OrderBy(lst => lst[0]).ToList();
            return ans;
        }
        internal class CustomTwoIntListComparer : IComparer<List<int>>
        {
            public int Compare(List<int> x, List<int> y)
            {
                //StringBuilder s1 = new StringBuilder();
                //StringBuilder s2 = new StringBuilder();
                //foreach (var num in x)
                //{
                //    s1.Append(num);
                //}
                //foreach (var num in y)
                //{
                //    s2.Append(num);
                //}
                string s1 = "4";
                string s2 = "111";
               return s1.ToString().CompareTo(s2.ToString());
            }
        }

        /// <summary>
        /// Odd Even Subsequences
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int Solve(List<int> A)
        {
            int ans1 = 0;
            int ans2 = 0;
            bool isOdd = false;
            bool isEven = false;
            for (int i = 0; i < A.Count(); i++)
            {
                if (A[i] % 2 == 0 && !isEven)
                {
                    isEven = true;
                    ans1++;
                }
                else if (isEven && A[i] % 2 == 1)
                {
                    ans1++;
                    isEven = false;
                }
                else if (A[i] % 2 == 1 && !isOdd)
                {
                    isOdd = true;
                    ans2++;
                }
                else if (isOdd && A[i] % 2 == 0)
                {
                    ans2++;
                    isOdd = false;
                }
            }
            return Math.Max(ans1, ans2);
        }

        /// <summary>
        /// Sum the Difference
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int Solve1(List<int> A)
        {
            A.Sort();
            int maxsum = 0;
            int minsum = 0;
            int n = A.Count();
            for (int i = 0; i < n; i++)
            {
                maxsum = maxsum + A[i] * Pow(2, i, 1000000007);
            }
            A = A.OrderByDescending(x => x).ToList();
            for (int i = 0; i < n; i++)
            {
                minsum = minsum + Pow(2, i, 1000000007);
            }
            return maxsum - minsum;
        }

        public static int Pow(int A, int B, int C)
        {
            if (A == 0 && B == 0)
            {
                return 0;
            }
            if (B == 0)
            {
                return 1;
            }
            long he = Pow(A, B / 2, C);
            long ha = ((he % C) * (he % C)) % C;
            if (B % 2 == 0)
            {
                return (int)ha;
            }
            else
            {
                if ((int)((ha % C * A % C) % C) < 0)
                {
                    return (int)((ha % C * A % C) % C) + C;
                }
                return (int)(ha % C * A % C) % C;
            }
        }

        /// <summary>
        ///  Find subsequence
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static string Solve(string A, string B)
        {
            int length = B.Length;
            int j = 0;
            for (int i = 0; i < length; i++)
            {
                if (A[j] == B[i])
                {
                    ++j;
                }
                if ((j) == A.Length - 1)
                {
                    return "YES";
                }
            }


            return "NO";


        }
    }
}
