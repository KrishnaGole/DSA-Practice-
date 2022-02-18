using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Solve(new List<int>() { 1, 2, 3, 4, 5 }, 5);
            //Solve(new List<int>() { 2, 1, 4, 10 }, new List<int>() { 3, 6, 2, 10, 10 });
            //var result =  IsZero(new List<int>() { 1, 2, -3, 3 });
            // Solve1(new List<int>() { 7, 1, 3, 4, 1, 7 });
            //Colorful(236);
            TwoSum(new List<int>() { 2, -9, -5, -8, -4, -2, 1, 1, 0, 6, -3, 9, -8, 2, -2, 9, 7, 6, 9, 1, 4, 1, 0, -5, -1, -4, 2, 2, 0, -2, 3, -4, -2, 1, 7, 5, -3, -1, -3, 6, 2, 6, 8, -6, -9, 7, 1, 6, -6, -6, -5, -6, -6, 7, -9, 8, -4, -1, 9, -7, 10, -5, -1, 10, 3, 2, -5, -4, 10, -10, 5, -2, 10, -3, 5, 3, 4, 9, 0, 0, -9 }, 4);
            Console.ReadLine();
        }

        /// <summary>
        /// Common Elements between two lists.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static List<int> Solve(List<int> A, List<int> B)
        {
            int n = A.Count();
            int m = B.Count();
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            List<int> ans = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (!dictionary.ContainsKey(A[i]))
                {
                    dictionary.Add(A[i], 1);
                }
                else
                {
                    dictionary.TryGetValue(A[i], out int val);
                    dictionary[A[i]] = ++val;
                }
            }
            for (int i = 0; i < m; i++)
            {
                dictionary.TryGetValue(B[i], out int val);
                if (dictionary.ContainsKey(B[i]) && val != 0)
                {
                    ans.Add(B[i]);
                    dictionary[B[i]] = --val;
                }
            }

            return ans;
        }

        /// <summary>
        ///  First Repeating element
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int Solve(List<int> A)
        {
            int n = A.Count();
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            for(int i = 0; i < n; i++)
            {
                if (!keyValuePairs.ContainsKey(A[i]))
                {
                    keyValuePairs.Add(A[i], 1);
                }
                else
                {
                    keyValuePairs.TryGetValue(A[i], out int val);
                    keyValuePairs[A[i]] = ++val;
                }
            }
           for(int i = 0; i < n; i++)
           {
                keyValuePairs.TryGetValue(A[i], out int val);
                if (keyValuePairs.ContainsKey(A[i]) && val > 1)
                {
                    return A[i];
                }
           }
            return -1;
    }


        /// <summary>
        ///  Largest Continuous Sequence Zero Sum
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<int> IsZero(List<int> A)
        {
            List<int> rst = new List<int>();
            Dictionary<int, int> map = new Dictionary<int, int>();
            if (A == null) return rst;
            int len = 0;
            int sum = 0;
            int l = -1, r = -1;
            map.Add(0, -1);
            for (int i = 0; i < A.Count(); i++)
            {
                sum += A[i];
                if (!map.ContainsKey(sum))
                    map.Add(sum, i);
                else
                {
                    if (i - map[sum] > len)
                    {
                        l = map[sum] + 1;
                        r = i;
                        len = i - map[sum];
                    }
                }
            }
            if (l >= 0 && r >= 0)
            {
                for (int i = l; i <= r; i++)
                {
                    rst.Add(A[i]);
                }
            }
            return rst;



        }


        /// <summary>
        /// Shaggy and distances
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int Solve1(List<int> A)
        {
            if (A.Count == 1)
            {
                return -1;
            }
            //stores <Value, Index> pair
            Dictionary<int, int> map = new Dictionary<int, int>();
            int result = A.Count;
            for (int i = 0; i < A.Count; i++)
            {
                if (map.ContainsKey(A[i]))
                {
                    result = Math.Min(result, i - map[A[i]]);
                }
                map[A[i]] = i;
            }
            return (result == A.Count) ? -1 : result;


        }

        /// <summary>
        /// Colorful Number
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static  int Colorful(int A)
        {
            List<int> digits = new List<int>();
            while (A != 0)
            {
                digits.Add(A % 10);
                A = A / 10;
            }
            int n = digits.Count();
            for (int i = 0; i < n / 2; i++)
            {
                int temp = digits[i];
                digits[i] = digits[n - 1 - i];
                digits[n - 1 - i] = temp;
            }
            int product = 1;
            HashSet<int> hashSet = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                product = 1;
                for (int j = i; j < n; j++)
                {
                    product *= digits[j];
                    if (hashSet.Contains(product))
                    {
                        return 0;
                    }
                    hashSet.Add(product);
                }
            }
            return 1;
        }

        public static int GetSum(int A, int B, List<int> C)
        {
            int ans = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < A; i++)
            {
                if (!map.ContainsKey(C[i]))
                {
                    map.Add(C[i], 1);
                }
                else
                {
                    map[C[i]]++;
                }
            }
            for (int i = 0; i < map.Count(); i++)
            {
                if (map.ElementAt(i).Value == B)
                {
                    ans += map.ElementAt(i).Key;
                }
            }
            return ans == 0 ? -1 : ans;
        }

        /// <summary>
        /// Subarray with given sum
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static List<int> Solve(List<int> A, int B)
        {
            int n = A.Count();
            List<int> prefixSum = new List<int>(A);
            for (int i = 1; i < n; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + prefixSum[i];
            }
            Dictionary<int, int> map = new Dictionary<int, int>
            {
                { 0, -1 }
            };
            for (int i = 0; i < n; i++)
            {
                if (!map.ContainsKey(prefixSum[i] - B))
                {
                    map.Add(prefixSum[i], i);
                }
                else
                {
                    A.GetRange(map[prefixSum[i] - B] + 1, i - map[prefixSum[i] - B]);
                }
            }
            return new List<int>() { -1 };
        }

        /// <summary>
        /// 2 Sum
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static List<int> TwoSum(List<int> A, int B)
        {
            int n = A.Count();
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            for(int i = 0; i < n; i++)
            {
                int a = A[i];
                int b = B - a;
                if (keyValuePairs.ContainsKey(b))
                {
                    return new List<int>()
                    {
                        ++keyValuePairs[b],
                        ++i
                    };
                }
                else if (!keyValuePairs.ContainsKey(A[i]))
                {
                    keyValuePairs.Add(A[i], i);
                }

            }
            return new List<int>();

          

        }
    }
}
