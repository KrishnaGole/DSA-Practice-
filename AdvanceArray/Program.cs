using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceArray
{
    internal class Program
    {
        public class Interval
        {
            public int start;
            public int end;
            public Interval() { start = 0; end = 0; }
            public Interval(int s, int e) { start = s; end = e; }
        }
        static void Main(string[] args)
        {
            //int ans = Trap(new List<int>() { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
            // int ans = Trap(new List<int>() { 3,10,6,7,0,2,-1 });
            List<List<int>> vs = new List<List<int>>()
            {
               new List<int>(){1, 1, 1, 1, 1},
               new List<int>(){2, 2, 2, 2, 2},
               new List<int>(){3, 8, 6, 7, 3},
               new List<int>(){4, 4, 4, 4, 4},
               new List<int>(){5, 5, 5, 5, 5}
            };
            // Solve(vs, new List<int>() { 1}, new List<int>() { 1}, new List<int>() { 2 }, new List<int>() {2});
            //Maxset(new List<int>() { 756898537, -1973594324, -2038664370, -184803526, 1424268980 });
            //Flip("010");
            //Solve(new List<List<int>>() { new List<int>() { 1, 2 }, new List<int>() { 8, 10 } }, 3, 6);
            //FirstMissingPositive(new List<int>() { 2, 3, 1, 2 });
            //MaxArr(new List<int>() { 1, 3, -1 });
            //PlusOne(new List<int>() { 0, 6, 0, 6, 4, 8, 8, 1 });
            //(1, 10), (2, 9), (3, 8), (4, 7), (5, 6), (6, 6)
            //Merge(new List<Interval>() {
            //   new Interval(1,10),new Interval(2,9),new Interval(4,7),new Interval(3,8), new Interval(5,6), new Interval(6,6)});
            // Solve(vs, 3);
            //MaxSumSqrSubMatrix(vs, 3);
            //Candy(new List<int>() { 3, 1, 3 });
            //PickFromBothSide(new List<int>() { 5, -2, 3, 1, 2 }, 3);
            //Solve(new List<int>() { 1, 12, 10, 3, 14, 10, 5 }, 8);
            //Solve(new List<int>() { 1, 2, 3, 4, 0 });
            Solve1(new List<int>() { 1, 2, 3, 4, 0 });

        }

        /// <summary>
        /// Rain Water Trapped
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int Trap(List<int> A)
        {
            int n = A.Count();
            int ans = 0;
            List<int> pfMax = new List<int>();
            List<int> sfMax = new List<int>();
            pfMax.Add(A[0]);
            sfMax.Add(A[n - 1]);


            for (int i = 1; i < n; i++)
            {
                pfMax.Add(Math.Max(A[i], pfMax[i - 1]));
            }
            for (int i = n - 2; i >= 0; i--)
            {
                sfMax.Add(Math.Max(A[i], sfMax[n - i - 2]));
            }
            sfMax.Reverse();
            for (int i = 1; i < n - 1; i++)
            {
                int leftMax = pfMax[i - 1];
                int rightMax = sfMax[i + 1];
                int heigth = Math.Min(leftMax, rightMax);
                int temp = heigth - A[i];
                int water = Math.Max(temp, 0);
                ans += water;
                //ans += Math.Max(Math.Min(pfMax[i - 1], sfMax[i + 1]), 0);
            }
            return ans;

        }

        public static List<int> Solve(List<List<int>> A, List<int> B, List<int> C, List<int> D, List<int> E)
        {
            long[,] preSum = new long[A.Count + 1, A[0].Count + 1];

            List<int> res = new List<int>();
            for (int i = 1; i <= A.Count(); i++)
            {
                preSum[i, 1] = A[i-1][0];
                for (int j = 2; j <= A[0].Count(); j++)
                {

                    preSum[i, j] = (preSum[i, j - 1] + A[i-1][j-1] + 1000000007) % 1000000007;
                }
            }
            for (int i = 2; i < preSum.GetLength(0); i++)
            {
                // DP[i, 0] += DP[i,0];
                for (int j = 1; j < preSum.GetLength(1); j++)
                {
                    preSum[i, j] = (preSum[i - 1, j] + preSum[i, j] + 1000000007) % 1000000007;
                }
            }
            for (int i = 0; i < B.Count(); i++)
            {
                //long a = DP[D[i] - 1, E[i] - 1] % 1000000007;
                //long b = 0;
                //long c = 0;
                //long d = 0;
                //if (C[i] - 1 > 0)
                //{
                //    b = DP[D[i] - 1, C[i] - 2] % 1000000007;
                //}
                //if (B[i] - 1 > 0)
                //{
                //    c = DP[B[i] - 2, E[i] - 1] % 1000000007;
                //}
                //if (B[i] - 1 > 0 && C[i] - 1 > 0)
                //{
                //    d = DP[B[i] - 2, C[i] - 2] % 1000000007;
                //}
                //long x = (a - b + 1000000007) % 1000000007;
                //long y = (d - c + 1000000007) % 1000000007;
                //int result = (int)(x + y) % 1000000007;
                //int a1 = B[i], b1 = C[i], a2 = D[i], b2 = E[i], ans = 0;
                //ans = 
                //res.Add(result);

            }
            return res;

        }

        /// <summary>
        /// Max Non Negative SubArray
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<int> Maxset(List<int> A)
        {
            List<int> ans = new List<int>();
            List<int> temp = new List<int>();
            long sum = 0;
            long maxSum = Int64.MinValue;
            for (int i = 0; i < A.Count(); i++)
            {
                if (A[i] >= 0)
                {
                    sum += A[i];
                    temp.Add(A[i]);
                }
                else
                {
                    if (maxSum < sum)
                    {
                        ans = new List<int>(temp);
                        maxSum = sum;
                    }
                    sum = 0;
                    temp = new List<int>();

                }
            }
            if(maxSum < sum)
            {
                ans = new List<int>(temp);
            }
            return ans;
        }

        public static List<int> Flip(string A)
        {
            List<int> input = new List<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == '1')
                {
                    input.Add(-1);
                }
                else
                {
                    input.Add(1);
                }
            }

            int left = 0, ans = 0, sum = 0, rightIndex = Int32.MaxValue, leftIndex = Int32.MaxValue;

            for (int i = 0; i < input.Count(); i++)
            {
                if (sum + input[i] < 0)
                {
                    sum = 0;
                    left = i + 1;
                }
                else
                {
                    sum += input[i];
                }
                if (sum > ans)
                {
                    ans = sum;
                    leftIndex = left;
                    rightIndex = i;
                }
            }

            if (leftIndex == Int32.MaxValue)
            {
                return new List<int>();
            }
            return new List<int>() { leftIndex + 1, rightIndex + 1 };
        }

        public static List<List<int>> Solve(List<List<int>> A, int B, int C)
        {
            List<List<int>> ans = new List<List<int>>();
            bool flag = true;
            if (A.Count == 0)
            {
                return new List<List<int>>(){ new List<int>() { Math.Min(B, C), Math.Max(B, C) }};
            }
            else if (A[0][0] > B && A[0][1] > C)
            {
                A.Insert(0, new List<int>() { Math.Min(B, C), Math.Max(B, C) });
            }
            else if (A[A.Count - 1][0] < B && A[A.Count - 1][1] < C)
            {
                A.Add(new List<int>() { Math.Min(B, C), Math.Max(B, C) });
            }
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i][1] >= C && A[i][0] <= B)
                {
                    A[i][1] = C;
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                for(int i = 0; i < A.Count(); i++)
                {
                    if(A[i][0] < B && A[i][1] < C)
                    {
                        A.Insert(i+1, new List<int>() { Math.Min(B, C), Math.Max(B, C) });
                    }
                }
            }
            return A;

        }

        public static int FirstMissingPositive(List<int> A)
        {
            int n = A.Count();
            for (int i = 0; i < n; i++)
            {
                while (A[i] != i + 1 && A[i] > 0 && A[i] <= n)
                {
                    int temp = A[A[i] - 1];
                    if(A[A[i] - 1] == A[i])
                    {
                        break;
                    }
                    A[A[i] - 1] = A[i];
                    A[i] = temp;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (A[i] != i + 1)
                {
                    return i + 1;
                }
            }
            return n + 1;
        }

        public static int MaxArr(List<int> A)
        {
            int n = A.Count();
            int max1 = Int32.MinValue, max2 = Int32.MinValue, min1 = Int32.MaxValue, min2 = Int32.MaxValue;

            for (int i = 0; i < n; i++)
            {
                max1 = Math.Max(A[i] + i, max1);
                max2 = Math.Max(A[i] - i, max2);
                min1 = Math.Min(A[i] + i, min1);
                min2 = Math.Min(A[i] - i, min2);
            }

            return Math.Max(max1-min1, max2-min2);
        }

        public static List<int> PlusOne(List<int> A)
        {
            List<int> result = new List<int>();
            int sum = 0, carray = 1;
            for (int i = A.Count() - 1; i >= 0; i--)
            {
                sum = A[i] + carray;
                result.Add(sum % 10);
                if (sum == 10)
                {
                    carray = 1;
                }
                else
                {
                    carray = 0;
                }
            }
            if (carray == 1)
            {
                result.Add(1);
            }
            result.Reverse();
            for (int i = 0; i < result.Count(); i++)
            {
                if (result[i] == 0)
                {
                    result.RemoveAt(i);
                    i--;
                }
                else
                {
                    break;
                }
            }
            //result.Reverse();
            
            return result;
        }

        /// <summary>
        /// Merge Overlapping Intervals
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public static List<Interval> Merge(List<Interval> intervals)
        {

            List<Interval> ans = new List<Interval>();
            intervals.Sort((Interval a, Interval b) => {
                int start1 = a.start;
                int start2 = b.start;
                if (start1 < start2)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            });
            int j = 0;
            for (int i = 0; i < intervals.Count; i++)
            {
                for (j = i + 1; j < intervals.Count; j++)
                {
                    if (intervals[i].end >= intervals[j].start)
                    {
                        intervals[i].end = Math.Max(intervals[j].end, intervals[i].end);
                        intervals[i].start = Math.Min(intervals[j].start, intervals[i].start);
                    }
                    else
                    {

                        break;
                    }
                }
                ans.Add(intervals[i]);
                i = --j;

            }
            return ans;
        }

        public static int Solve(List<List<int>> A, int B)
        {
            int n = A.Count(), m = A[0].Count(), ans = A[0][0];
            
            return ans;
        }
        public static int MaxSubArrSum(List<int> arr)
        {
            int n = arr.Count(), ans = int.MinValue, sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += arr[i];
                ans = Math.Max(ans, sum);
                sum = Math.Max(0, sum);
            }
            return ans;
        }

        public static int MaxSumSqrSubMatrix(List<List<int>> A, int B)
        {
            var strips = new List<List<int>>();
            for (var i = 0; i < A.Count; i++)
            {
                strips.Add(new List<int>());
                for (var j = 0; j <= A.Count - B; j++)
                {
                    var sum = 0;
                    for (var k = j; k < j + B; k++)
                    {
                        sum += A[i][k];
                    }
                    strips[i].Add(sum);
                }
            }


            var maxSum = GetSum(strips, 0, 0, B);
            for (var i = 0; i <= A.Count - B; i++)
            {
                for (var j = 0; j <= A.Count - B; j++)
                {
                    var currSum = GetSum(strips, i, j, B);
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                    }
                }
            }
            return maxSum;
        }

        private static int GetSum(List<List<int>> matrix, int x, int y, int size)
        {
            var sum = 0;
            for (var i = x; i < x + size; i++)
            {
                sum += matrix[i][y];
            }
            return sum;
        }

        public static int Candy(List<int> A)
        {
            int n = A.Count();
            int[] candies = new int[n];
            candies[0] = 1;

            for (int i = 1; i < n; i++)
            {
                if (A[i] > A[i - 1])
                {
                    candies[i] = candies[i - 1] + 1;
                }
                else
                {
                    candies[i] = 1;
                }
            }

            for (int i = n - 2; i >= 0; i--)
            {
                if (A[i] > A[i + 1])
                {
                    candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
                }
            }

            return candies.ToList().Sum(); ;
        }

        public static int PickFromBothSide(List<int> ints, int B)
        {
            int n = ints.Count(), curr = 0, ans = int.MinValue;

            for(int i = 0; i < B; i++)
            {
                curr += ints[i];
            }
            int back = B - 1;
            ans = Math.Max(ans, curr);

            for(int i = n-1; i >= n-B; i--)
            {
                curr += ints[i];
                curr -= ints[back];
                back--;
                ans = Math.Max(ans, curr);
            }
            return ans;


        }

        public static int Solve(List<int> A, int B)
        {
            
            int n = A.Count(), ans = int.MaxValue, lessThanBcnt = 0;
            List<int> indexs = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (A[i] <= B)
                {
                    lessThanBcnt++;
                    indexs.Add(i);
                    
                }
            
            }
            for(int i = 0; i <  indexs.Count(); i++)
            {
                int cnt = lessThanBcnt, minCnt = 0;

                for (int j = indexs[i]; j < n; j++)
                {

                    if (A[j] > B && cnt > 0)
                    {
                        minCnt++;
                    }
                    cnt--;
                }
                if(cnt <= 0)
                {
                    ans = Math.Min(ans, minCnt);
                }

            }

            return ans;

        }

        public static int Solve(List<int> A)
        {
            int n = A.Count(), cnt = 0;
            for (int i = 0; i < n; i++)
            {
                while (A[i] != i)
                {
                    int curr = A[i];
                    int temp = A[curr];
                    A[curr] = curr;
                    A[i] = temp;
                    cnt++;
                }
            }
            return cnt;
        }

        public static int MaximumGap(List<int> A)
        {
            int n = A.Count(), ans = 0;
            List<Tuple<int, int>> tuples = new List<Tuple<int, int>>();
            for (int i = 0; i < n; i++)
            {
                tuples.Add(new Tuple<int, int>(A[i],i));
            }

           
            tuples.Sort((Tuple<int,int> a, Tuple<int,int> b) => {
                return a.Item1 - b.Item1;
                //if (a.Item1 < b.Item1)
                //{
                //    return -1;
                //}
                //else if(a.Item1 >  b.Item1)
                //{
                //    return 1;
                //}
                //return 0;
            });
            int min = n;
            for(int i = 0; i < n; i++)
            {

                ans = Math.Max(ans, tuples[i].Item2 - min);
                min = Math.Min(tuples[i].Item2, min);
               
            }
            return ans;
        }

        /// <summary>
        /// Max Chunks To Make Sorted
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int Solve1(List<int> A)
        {
            int cnt = 0, ma = 0, i = 0;
            foreach (int x in A)
            {
                ma = Math.Max(ma, x);
                // checks if the maximum number so far equals the index number
                if (ma == i)
                {
                   cnt += 1;
                }
                i += 1;
            }
            return cnt;
        }
    }
}
