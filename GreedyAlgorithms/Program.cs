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
            //Mice(new List<int>() { -10, -79, -79, 67, 93, -85, -28, -94 }, new List<int>() { -2, 9, 69, 25, -31, 23, 50, 78 });
            //Seats("....xxx");
            //Solve("00010110", 3);
            List<int> A = new List<int>() { 7,2,2,5,3 };
            List<int> B = new List<int>() { 7, 2, 2, 5, 3 };
            List<List<int>> result = new List<List<int>>();
            result.Add(A);
            result.Add(B);
            List<int> flattened = result.SelectMany(x => x).ToList();
            List<List<int>> distinctCombinations = new List<List<int>>();

            foreach (var distinctValues in flattened.Distinct())
            {
                List<int> combination = new List<int> { distinctValues };
                distinctCombinations.Add(combination);
            }

         
            var ans  = result.Distinct().ToList();
            //List<int> currentCombination = new List<int>();
            //A.Sort();
            //A = A.Distinct().ToList();
            
            //Backtrack(result, currentCombination, A, 3, 0, 0);
           
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

        public static int Seats(string A)
        {
            List<int> indxList = new List<int>();

            int n = A.Length;

            for (int i = 0; i < n; i++)
            {
                if (A[i] == 'x')
                {
                    indxList.Add(i);

                }
            }
            if (indxList.Count() <= 1)
            {
                return 0;
            }
            int mid = indxList.Count() / 2;
            int start = indxList[mid] - mid;

            int mod = 10000003;
            int sum = 0;
            int currentVal = 0;
            for (int i = 0; i < indxList.Count(); i++)
            {
                currentVal = Math.Abs(start - indxList[i]);
                sum = (sum + currentVal) % mod;
                start++;
            }
            return sum;
        }

        public static int Solve(string A, int B)
        {
            int n = A.Length, flip = 0, ans = 0;
            int[] temp = new int[n];
            for (int i = 0; i < n; i++)
            {
                int curr = A[i] - '0';
                flip = flip - temp[i];
                if ((curr == 0 && (flip & 1) == 0) || (curr == 1 && (flip & 1) == 1))
                {
                    if (i + B > n)
                    {
                        return -1;
                    }
                    else if(i+B < n)
                    {
                        temp[i + B]++;
                    }
                    flip++;
                    ans++;
                }
            }
            return ans;

        }

        private static void Backtrack(List<List<int>> result, List<int> currentCombination, List<int> A, int B, int sum, int startIndex)
        {
            if (sum == B)
            {
                result.Add(new List<int>(currentCombination));
                return;
            }

            for (int i = startIndex; i < A.Count(); i++)
            {
                if (sum + A[i] > B)
                {
                    continue;
                }
                currentCombination.Add(A[i]);
                Backtrack(result, currentCombination, A, B, sum + A[i], i);
                currentCombination.Remove(currentCombination.Count() - 1);
                sum -= A[i];
            }
        }

        
    }
}
