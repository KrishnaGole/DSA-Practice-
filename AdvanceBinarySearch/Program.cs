using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceBinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// SearchRange(new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }, 10);
            //SearchMatrix(new List<List<int>>()
            //{
            //  new List<int>(){ 22, 32, 67},
            //  //new List<int>(){ 10, 11, 16, 20 },
            //  //new List<int>(){ 23, 30, 34, 50 }
            //}, 93);
            //var ans = Solve(new List<int>() { 13, 13, 21, 21, 27, 50, 50, 102, 102, 108, 108, 110, 110, 117, 117, 120, 120, 123, 123, 124, 124, 132, 132, 164, 164, 166, 166, 190, 190, 200, 200, 212, 212, 217, 217, 225, 225, 238, 238, 261, 261, 276, 276, 347, 347, 348, 348, 386, 386, 394, 394, 405, 405, 426, 426, 435, 435, 474, 474, 493, 493 });
            //Sqrt(2147483647);

            //var ans =  Solve1(new List<int>() { 1, 20, 50, 40, 10 }, 5);
            //Solve(11, new List<int>() { -87, -61, -54, -29, 0, 28, 34, 48, 77, 86, 90 }, -35);
            //A: 807414236
            //B: 3788
            //C: 38141

            //Solve(7, 2, 3);
            AggressiveCows(new List<int>() { 1, 2, 3, 4, 5 }, 3);

        }

        public static int SearchInsert(List<int> A, int B)
        {
            int low = 0, high = A.Count() - 1, ans = 0;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (A[mid] == B)
                {
                    return B;
                }
                if (A[mid] < B)
                {
                    low = mid + 1;
                    
                }
                else
                {
                    ans = mid;
                    high = mid - 1;
                }
            }
            return ans;
        }

        public static List<int> SearchRange(List<int> A, int B)
        {
            int low = 0, high = A.Count() - 1, start = -1, end = -1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (A[mid] == B)
                {
                    start = mid;
                    high = mid - 1;
                }
                if (A[mid] < B)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            low = 0; high = A.Count() - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (A[mid] == B)
                {
                    end = mid;
                    low = mid + 1;
                }
                if (A[mid] <= B)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return new List<int>() { start, end };
        }

        public static int SearchMatrix(List<List<int>> A, int B)
        {
            int n = A.Count();
            int m = A[0] != null ? A[0].Count() : -1;
            int row = -1;

            int low = 0, high = n - 1;
            while(low <= high)
            {
                int mid = (low + high) / 2;
                if(A[mid][m-1] == B)
                {
                    return 1;
                }
                if(A[mid][m-1] < B)
                {
                    low = mid + 1;

                }
                else
                { 
                    row = mid;
                    high = mid - 1;
                }
            }

            low = 0; high = m - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (A[row][mid] == B)
                {
                    return 1;
                }
                if (A[row][mid] < B)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return 0;
        }

        /// <summary>
        /// Single Element in a Sorted Array
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int Solve(List<int> A)
        {
            int low = 0, n = A.Count(), high = n - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (mid >= 1 && mid <= n - 2 && A[mid] != A[mid - 1] && A[mid] != A[mid + 1])
                {
                    return A[mid];
                }
                else if (mid == 0 && A[mid] != A[mid + 1])
                {
                    return A[mid];
                }
                else if (mid == n - 1 && A[mid] != A[mid - 1])
                {
                    return A[mid];
                }
                else
                {
                    low = low + 1;
                }
            }
            low = 0; high = n - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (mid >= 1 && mid <= n - 2 && A[mid] != A[mid - 1] && A[mid] != A[mid + 1])
                {
                    return A[mid];
                }
                else if (mid == 0 && A[mid] != A[mid + 1])
                {
                    return A[mid];
                }
                else if (mid == n - 1 && A[mid] != A[mid - 1])
                {
                    return A[mid];
                }
                else
                {
                    high = high - 1;
                }
             }
            return -1;
        }

        /// <summary>
        /// Square Root of Integer

        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static long Sqrt(int A)
        {
            long low = 1, high = A, ans = 0;
            while (low <= high)
            {
                long mid = (low + high) / 2;
                if (mid * mid == A)
                {
                    return A;
                }
                if (mid * mid < A)
                {
                    ans = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return ans;
        }

        /// <summary>
        ///  Special Integer
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int Solve(List<int> A, int B)
        {
            int low = 0, high = A.Count(), ans = 0;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (Sum(A, mid) <= B)
                {
                    ans = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return ans;
        }
        
        public static int Sum(List<int> A, int k)
        {
            long sum = 0, ans = 0;
            for (int i = 0; i < k; i++)
            {
                sum += A[i];
            }
            ans = sum;
            for (int s = 1, e = k; s <= A.Count() - k; s++, e++){
                sum = sum - A[s - 1] + A[e];
                ans = Math.Max(sum, ans);
            }
            return (int)ans;
        }

        /// <summary>
        /// Search in Bitonic Array!
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int Solve1(List<int> A, int B)
        {
            int n = A.Count();
            int low = 1, high = n - 2, peek = -1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (A[mid] > A[mid + 1] && A[mid] > A[mid - 1])
                {
                    peek = mid;
                }
                else if (A[mid] > A[mid - 1] && A[mid] < A[mid + 1])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            int ans = SearchAscending(A, 0, peek, B);
            return ans != -1 ? ans : SearchDescending(A, peek + 1, n - 1, B);

        }
        public static int SearchAscending(List<int> A, int low, int high, int key)
        {
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (A[mid] == key)
                {
                    return mid;
                }
                else if (A[mid] < key)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }

        public static int SearchDescending(List<int> A, int low, int high, int key)
        {
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (A[mid] == key)
                {
                    return mid;
                }
                else if (A[mid] < key)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return -1;
        }

        /// <summary>
        /// Ceiling in a sorted array
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <returns></returns>
        public static int Solve(int A, List<int> B, int C)
        {
            int low = 0;
            int high = A - 1;
            int ans = -1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (B[mid] < C)
                {
                    low = mid + 1;
                }
                else
                {
                    return B[mid];
                    //high = mid - 1;
                }
            }
            return ans;
        }


        /// <summary>
        /// Ath Magical Number
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <returns></returns>
        public static int Solve(int A, int B, int C)
        {
            int mod = 1000000007;
            long low = 1, high = Math.Min(B, C) * 1L * A, ans = 0;
            long lcm = B * 1L * C / Gcd(B, C);
            while (low <= high)
            {
                long mid = (low + high) / 2;
                long count = mid / B + mid / C - mid / lcm;
                if(count < A)
                {
                    low = mid + 1;
                }
                else
                {
                    ans = mid;
                    high = mid - 1;
                }
            }
            return (int)(ans%mod);
           
        }

        public static long Gcd(long A, long B)
        {
            if(A == 0)
            {
                return B;
            }
            return Gcd(B % A, A);
        }


        public static int AggressiveCows(List<int> A, int B)
        {
            A.Sort();
            int n = A.Count(), low = MinAdjDistance(A, n), high = A[n - 1] - A[0], ans = 0;
            while(low <= high)
            {
                int mid = (low + high) / 2;
                if(Check(A, mid, B, n))
                {
                    ans = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return ans;

        }
        public static int MinAdjDistance(List<int> A, int N)
        {
            int ans = Int32.MaxValue;
            for(int i = 1; i < N - 1; i++)
            {
                ans = Math.Min(ans, A[i] - A[i - 1]);
            }
            return ans;
        }

        public static bool Check(List<int> distanceArr, int mid,  int cows, int n)
        {
            int last_placed = distanceArr[0], count = 1;
            for(int i = 1; i < n; i++)
            {
                if(distanceArr[i] - last_placed >= mid)
                {
                    count++;
                    last_placed = distanceArr[i];
                    if(count == cows)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
       

    }
}
