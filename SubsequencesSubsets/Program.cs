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
            HashSet<List<int>> hs = new HashSet<List<int>>();
            List<List<int>> vs = new List<List<int>>();
            //SUBARRAYOR(new List<int>() { 1, 2, 3, 4, 5 });
            //Solve("scsecugqsb");
            Subsets(new List<int>() { 1,2,3 });
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

    }
}
