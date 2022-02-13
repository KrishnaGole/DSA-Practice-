using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefixArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> vs = new List<int>() { 2,-1,3,1,4,3,2,-1};
            //Console.WriteLine(solve1(vs));

            //List<List<int>> vs = new List<List<int>>()
            //{
            //    new List<int>(){1,2,3,4},
            //    new List<int>(){5,6,7,0},
            //    new List<int>(){ 9, 2, 0, 4 }
            //};
            //List<List<int>> vs1 = new List<List<int>>()
            //{
            //    new List<int>(){5,6},
            //    new List<int>(){7,8},
            //};
            //vs.Count();
            //solve4(new List<int>() { 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1 }, 2);
            //List<List<int>> vs = new List<List<int>>() { new List<int>() { 6 }, new List<int>() { 2 }, new List<int>() { 3 }, new List<int>() { 10 }, new List<int>() { 1 }, 
            //new List<int>(){ 3} };
            //List<List<int>> vs1 = new List<List<int>>() { new List<int>() { 6 }, new List<int>() { 7 }, new List<int>() { 3 }, new List<int>() { 8 }, new List<int>() { 1 },
            //new List<int>(){ 2} };
            //solve5(vs, vs1);
            //rotate(new List<List<int>>() { new List<int>() { 1, 2, 3 }, new List<int>() { 4, 5, 6 }, new List<int>() { 7, 8, 9 } });
            //var result = generateMatrix(5);
            //solve6(vs, vs1);
            // solve7(vs);
            //solve8(new List<int>() { 1, 3, 5 }, new List<int>() { 1,2,3 });
           
            solve9(new List<int>() { 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1 }, 1);




            Console.ReadLine();
        }

        /// <summary>
        ///  Equilibrium index of an array
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int solve(List<int> A)
        {
            List<int> pfArr = new List<int>();
            pfArr.Add(A[0]);
            for (int i = 1; i < A.Count; i++)
            {
                pfArr.Add(pfArr[i - 1] + A[i]);
            }
            for (int j = 0; j < A.Count; j++)
            {
                int leftSum = 0;
                if (j == 0)
                {
                    leftSum = 0;
                }
                else
                {
                    leftSum = pfArr[j - 1];
                }
                int rightSum = pfArr[A.Count - 1] - pfArr[j];
                if (leftSum == rightSum)
                {
                    return j;
                }
            }
            return -1;
        }


        /// <summary>
        /// Count ways to make sum of odd and even indexed elements equal by removing an array element
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int solve1(List<int> A)
        {
            List<int> pfEven = new List<int>();
            List<int> pfOdd = new List<int>();
            pfEven.Add(A[0]);
            pfOdd.Add(0);
            int count = 0;
            for (int i = 1; i < A.Count; i++)
            {
                if (i % 2 == 0)
                {
                    pfEven.Add(pfEven[i - 1] + A[i]);
                }
                else
                {
                    pfEven.Add(pfEven[i - 1]);
                }
                if (i % 2 == 1)
                {
                    pfOdd.Add(pfOdd[i - 1] + A[i]);
                }
                else
                {
                    pfOdd.Add(pfOdd[i - 1]);
                }
            }
            for (int j = 0; j < A.Count; j++)
            {
                int evenLeftSum = 0, evenRightSum = 0, oddLeftSum = 0, oddRightSum = 0;
                if (j == 0)
                {
                    evenLeftSum = pfEven[j];
                    oddLeftSum = 0;
                }
                else
                {
                    evenLeftSum = pfEven[j - 1];
                    oddLeftSum = pfOdd[j - 1];
                }

                evenRightSum = pfEven[A.Count - 1] - pfEven[j];
                oddRightSum = pfOdd[A.Count - 1] - pfOdd[j];
                if ((evenLeftSum + evenRightSum) == (oddRightSum + oddLeftSum))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Subarray with least average
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int solve2(List<int> A, int B)
        {
            int sum = 0;
            int n = A.Count();
            int min = Int32.MaxValue;
            int ans = 0;
            for (int i = 1; i < n; i++)
            {
                A[i] = A[i - 1] + A[i];
            }

            for (int i = 0; i < (i + B - 1) && i <= n - B; i++)
            {
                if (i == 0)
                {
                    sum = A[i + (B - 1)];
                }
                else
                {
                    sum = A[i + (B - 1)] - A[i - 1];
                }
                if(min > sum)
                {
                    min = sum;
                    ans = i;
                }
            }
            return ans;
        }

        /// <summary>
        /// Good Subarrays Easy
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int solve3(List<int> A, int B)
        {
            int n = A.Count();
            int sum = 0;
            int countEven = 0;
            int countOdd = 0;
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                sum = 0;
                index = 1;
                for (int j = i; j < n; j++)
                {
                    sum += A[j];
                    if (index % 2 == 0 && sum < B)
                    {
                        countEven++;
                    }
                    else if (index % 2 == 1 && sum > B)
                    {
                        countOdd++;
                    }
                    index++;
                }
            }
            return countEven + countOdd;
        }

        /// <summary>
        ///  Alternating Subarrays Easy
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static List<int> solve4(List<int> A, int B)
        {
            int input = B * 2 + 1;
            int n = A.Count();
            bool isAlSubArr = true;
           
            List<int> ans = new List<int>();
            if (input == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    ans.Add(i);
                }
                return ans;
            }

            for (int i = 0; i <= n - input; i++)
            {
                isAlSubArr = true;
                for (int j = i; j < i + input - 1; j++)
                {
                    if (i == 0 && A[j] == A[j + 1])
                    {
                        isAlSubArr = false;
                        break;
                    }
                    else if (j == i + input - 1 && A[j] == A[j - 1])
                    {
                        isAlSubArr = false;
                        break;
                    }
                    else if (i != 0 && j != i + input - 1 && (A[j] == A[j + 1] || A[j] == A[j - 1]))
                    //else if (i != 0 && A[j] == A[j + 1] && A[j] == A[j - 1])
                    {
                        isAlSubArr = false;
                        break;
                    }
                }
                if (isAlSubArr)
                {
                    ans.Add(i + 1);
                }
            }

            return ans;
        }

        public static List<List<int>> solve5(List<List<int>> A, List<List<int>> B)
        {
            List<List<int>> ans = new List<List<int>>();
            List<int> sum = new List<int>();
            int n = A.Count();
           
            for (int i = 0; i < n; i++)
            {
                sum = new List<int>();
                if(A[i].Count() > 2)
                {
                    for (int j = 0; j < n; j++)
                    {

                        sum.Add(A[i][j] + B[i][j]);
                    }
                }
                else
                {
                    sum.Add(A[i][0] + B[i][0]);
                }
               
                ans.Add(sum);
            }
            return ans;
        }

        /// <summary>
        ///  Rotate Matrix
        /// </summary>
        /// <param name="a"></param>
        public static void rotate(List<List<int>> a)
        {
            int length = a.Count();
            for (int i = 0; i < length / 2; i++)
            {
                for (int j = i; j < length - i - 1; j++)
                {
                    int temp = a[i][j];
                    a[i][j] = a[length - j - 1][i];
                    a[length - j - 1][i] = a[length - i - 1][length - j - 1];
                    a[length - i - 1][length - j - 1] = a[length - j - 1][length - i - 1];
                    a[length - j - 1][length - i - 1] = temp;

                }
            }


        }

        /// <summary>
        /// Spiral Order Matrix II
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<List<int>> generateMatrix(int A)
        {
            // int[,] ans = new int[A,A];
            List<List<int>> ans = new List<List<int>>();
            List<int> temp = new List<int>();
            for(int i = 0; i < A; i++)
            {
                temp = new List<int>();
                for (int j = 0; j < A; j++)
                {
                    temp.Add(0);
                }
                ans.Add(temp);
            }
            int row = 0;
            int col = 0;
            int k = 1;
            int direction = 0;
            while(k <= A * A)
            {
                ans[row][col] = k;
                k++;
                if(direction  == 0)
                {
                    col++;
                    if (col == A || ans[row][col] != 0)
                    {
                        direction = 1;
                        col--;
                        row++;
                    }
                }
                else if (direction == 1)
                {
                    row++;
                    if(row == A || ans[row][col] != 0)
                    {
                        direction = 2;
                        row--;
                        col--;
                    }
                }
                else if (direction == 2)
                {
                    col--;
                    if(col == -1 || ans[row][col] != 0)
                    {
                        direction = 3;
                        col++;
                        row--;
                    }
                }
                else if(direction == 3)
                {
                    row--;
                    if(row == -1 || ans[row][col] != 0)
                    {
                        direction = 0;
                        row++;
                        col++;
                    }
                }
            }

            return ans;
        }

        /// <summary>
        /// Matrix Multiplication
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static List<List<int>> solve6(List<List<int>> A, List<List<int>> B)
        {
            List<List<int>> ans = new List<List<int>>();
            List<int> temp = new List<int>();
            int m = A[0].Count();
            int n = A.Count();
            for (int i = 0; i < n; i++)
            {
                temp = new List<int>();
                for (int j = 0; j < m; j++)
                {
                    temp.Add(0);
                }
                ans.Add(temp);

            }
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        ans[i][j] = ans[i][j] + A[i][k] * B[k][j];
                    }
                }
               
            }

            return ans;
        }

        public static List<List<int>> solve7(List<List<int>> A)
        {
            int n = A.Count();
            int m = A[0].Count();
            List<List<int>> indices = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (A[i][j] == 0)
                    {
                        indices.Add(new List<int>() { i, j });
                    }
                }
            }
            int length = indices.Count();
            for (int i = 0; i < length; i++)
            {
                int row = indices[i][0];
                int col = indices[i][1];
                for (int j = 0; j < m; j++)
                {
                    A[row][j] = 0;
                }
                for (int k = 0; k < n; k++)
                {
                    A[k] [col] = 0;
                }
            }
            return A;
        }


        /// <summary>
        /// Christmas Trees
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int solve8(List<int> A, List<int> B)
        {
            int length = B.Count() - 3;
            int minSum = Int32.MaxValue;
            for (int i = 0; i <= length; i++)
            {
                for (int j = i + 1; j < B.Count() - 1; j++)
                {
                    if (A[i] < A[j] && A[j] < A[j + 1])
                    {
                        minSum = Math.Min(minSum, B[i] + B[j] + B[j + 1]);
                    }
                }
            }
            return minSum;
        }

        /// <summary>
        /// Alternating Subarrays Easy
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static List<int> solve9(List<int> A, int B)
        {
            int input = B * 2 + 1;
            int n = A.Count();
            bool isAlSubArr = true;
            List<int> ans = new List<int>();
            if (input == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    ans.Add(i);
                }
                return ans;
            }

            for (int i = input / 2; i <= n - input; i++)
            {
                isAlSubArr = true;
                for (int j = i - 1; j < i + input; j++)
                {
                    if (i != j)
                    {
                        if (A[j] == A[j + 1])
                        {
                            isAlSubArr = false;
                        }
                    }

                }
                if (isAlSubArr)
                {
                    ans.Add(i);
                }

            }

            return ans;
        }

    }
}
