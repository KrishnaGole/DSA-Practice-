using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Solve(new List<int>() { 4, 4, 8, 15, 6 }, new List<int>() { 9, 5, 15, 16, 7 });
            Mice(new List<int>() { -10, -79, -79, 67, 93, -85, -28, -94 }, new List<int>() { -2, 9, 69, 25, -31, 23, 50, 78 });
        }

        /// <summary>
        /// Finish Maximum Jobs
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int Solve(List<int> A, List<int> B)
        {
            int n = A.Count(), ans = 1, currMinTime = 0;
            List<KeyValuePair<int, int>> keyValuePairs = new List<KeyValuePair<int, int>>();
            for(int i = 0; i < n; i++)
            {
                keyValuePairs.Add(new KeyValuePair<int, int>(A[i], B[i]));
            }
            keyValuePairs.Sort((KeyValuePair<int, int> x, KeyValuePair<int, int> y) =>
            {
                //int i = x.Key.CompareTo(y.Key);
                //if (i == 0)
                //{
                //    i = x.Value.CompareTo(y.Value);
                //}
                //return i;
                return x.Value.CompareTo(y.Value);
            });
            keyValuePairs =  keyValuePairs.OrderBy(x => x.Value).ToList();
            currMinTime = keyValuePairs[0].Value;
            for(int i = 1; i < keyValuePairs.Count(); i++)
            {
                if(currMinTime <= keyValuePairs[i].Key)
                {
                    ans++;
                    currMinTime = keyValuePairs[i].Value;
                }
            }
            return ans;
        }

        /// <summary>
        /// Assign Mice to Holes
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int Mice(List<int> A, List<int> B)
        {
            int n = A.Count(), ans = int.MinValue;
            A.Sort();
            B.Sort();
            for (int i = 0; i < n; i++)
            {
                ans = Math.Max(ans, Math.Abs(A[i] -  B[i]));
            }
            return ans;

        }
    }
}
