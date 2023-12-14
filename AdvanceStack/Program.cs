using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceStack
{
    internal class Program
    {
        public static  Dictionary<int, int> precedence = new Dictionary<int, int>()
        {
            { '^', 4},
            { '/', 3},
            { '*', 3},
            { '+', 2},
            { '-', 2},
        };
        
        
        static void Main(string[] args)
        {
            //Solve("abccbc");
            //Solve(new List<int>() { 5, 4, 3, 2, 1 });
            //Solve1("a*(r+o*h)");
            //EvalRPN(new List<string>() { "2", "3", "+", "4", "5", "+", "+", "6", "7", "+", "*", "2", "*" });
            // Braces1("(a+((b*c)+c))");
            //List<List<int>> vs = new List<List<int>>()
            //{
            //    new List<int>(){1,2},
            //    new List<int>(){1,2},
            //    new List<int>(){1,2},
            //    new List<int>(){1,2},
            //    new List<int>(){2,2}
            //};
            //Solve(2, vs, new List<int>() { 1,1,4,0,1 });
            // Solve1(new List<int>() { 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30 });
            // LargestRectangleArea(new List<int>() { 47, 69, 67, 97, 86, 34, 98, 16, 65, 95, 66, 69, 18, 1, 99, 56, 35, 9, 48, 72, 49, 47, 1, 72, 87, 52, 13, 23, 95, 55, 21, 92, 36, 88, 48, 39, 84, 16, 15, 65, 7, 58, 2, 21, 54, 2, 71, 92, 96, 100, 28, 31, 24, 10, 94, 5, 81, 80, 43, 35, 67, 33, 39, 81, 69, 12, 66, 87, 86, 11, 49, 94, 38, 44, 72, 44, 18, 97, 23, 11, 30, 72, 51, 61, 56, 41, 30, 71, 12, 44, 81, 43, 43, 27 });
            //Solve3(new List<int>() { 2, 3, 1, 4 });
            //Solve2(new List<int>() { 4, 7, 3, 8 });
            //Solve(new List<List<int>>() { new List<int>() { 0, 0, 1 }, new List<int>() { 0, 1, 1 } , new List<int>() { 1, 1, 1 } });
            SumOfSubarrayValues(new List<int>() { 4, 7, 3, 8 });



        }

        /// <summary>
        /// Double Character Trouble

        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static string Solve(string A)
        {
            Stack<char> stack = new Stack<char>();
            int length = A.Length;
            //bool flag = true;
            StringBuilder ans = new StringBuilder();
            for(int i = 0; i < length; i++)
            {
               
                if (stack.Count() > 0 && stack.Peek() == A[i])
                {
                    stack.Pop();
                    //flag = false;
                    
                }
                else
                {
                    stack.Push(A[i]);
                }
                //if (flag && (stack.Count() == 0 || stack.Peek() != A[i]))
                //{
                //    stack.Push(A[i]);
                //}
                //flag = true;

            }
            while(stack.Count > 0)
            {
                ans.Append(stack.Pop());
                
            }
            return new string(ans.ToString().Reverse().ToArray());
        }

        /// <summary>
        /// Sort stack using another stack
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<int> Solve(List<int> A)
        {
            int n = A.Count();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                stack.Push(A[i]);
            }
            stack = MergeSort(stack);
            A.Clear();
            while (stack.Count() > 0)
            {
                A.Add(stack.Pop());
            }
            return A;

        }

        public static Stack<int> MergeSort(Stack<int> A)
        {
            if (A.Count() <= 1)
            {
                return A;
            }
            int n = A.Count();
            Stack<int> B = new Stack<int>();
            for (int i = 0; i < n / 2; i++)
            {
                B.Push(A.Pop());
            }
            A = MergeSort(A);
            B = MergeSort(B);
            return Merge(A, B);
        }

        public static Stack<int> Merge(Stack<int> A, Stack<int> B)
        {
            Stack<int> C = new Stack<int>();
            while (A.Count() > 0 && B.Count() > 0)
            {
                if (A.Peek() < B.Peek())
                {
                    C.Push(A.Pop());
                }
                else
                {
                    C.Push(B.Pop());
                }
            }
            while (A.Count() > 0)
            {
                C.Push(A.Pop());
            }
            while (B.Count() > 0)
            {
                C.Push(A.Pop());
            }
            while (C.Count() > 0)
            {
                A.Push(C.Pop());
            }
            return A;
        }

        /// <summary>
        /// Infix to Postfix
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static string Solve1(string A)
        {

            int n = A.Length; StringBuilder ans = new StringBuilder();
            Stack<char> stack = new Stack<char>();
            for(int  i= 0; i < n; i++)
            {
                if (char.IsLetter(A[i])){
                    ans.Append(A[i]);
                }
                else if(A[i] == '(')
                {
                    stack.Push('(');
                }
                else if(A[i] == ')')
                {
                    while(stack.Peek() != '(')
                    {
                        ans.Append(stack.Pop());
                    }
                    stack.Pop();
                }
                else
                {
                    
                    while (stack.Count() > 0 && stack.Peek() != '(' && precedence[stack.Peek()] >= precedence[A[i]])
                    {
                        ans.Append(stack.Pop());
                    }
                    stack.Push(A[i]);
                }
            }
            while(stack.Count() > 0)
            {
                ans.Append(stack.Pop());
            }
            return ans.ToString();

        }

        /// <summary>
        ///  Evaluate Expression
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int EvalRPN(List<string> A)
        {
            int ans = int.MinValue, n = A.Count();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                if (A[i] == "*" || A[i] == "/" || A[i] == "+" || A[i] == "-")
                {
                    switch (A[i])
                    {
                        case "*":
                            if (ans == int.MinValue)
                            {
                                ans = (stack.Pop() * stack.Pop());
                            }
                            else
                            {
                                ans *= stack.Pop();
                            }
                            break;
                        case "/":
                            if (ans == int.MinValue)
                            {
                                int num1 = stack.Pop();
                                int num2 = stack.Pop();
                                ans = num2 / num1;
                            }
                            else
                            {
                                ans /= stack.Pop();
                            }
                            break;
                        case "-":
                            if (ans == int.MinValue)
                            {
                                int num1 = stack.Pop();
                                int num2 = stack.Pop();
                                ans = num2 - num1;
                            }
                            else
                            {
                                ans -= stack.Pop();
                            }
                            break;
                        case "+":
                            if (ans == int.MinValue)
                            {
                                ans = stack.Pop() + stack.Pop();
                            }
                            else
                            {
                                ans += stack.Pop();
                            }
                            break;
                    }
                }
                else
                {
                    stack.Push(Convert.ToInt32(A[i]));
                }

            }
            return ans;
        }

        public static int Braces(string A)
        {
            //(a+((b*c)+c))
            int n = A.Length;
            Stack<char> stack = new Stack<char>();
            bool isRedundant = true;
            for (int i = 0; i < n; i++)
            {
                if(A[i] == ')')
                {
                    while (stack.Peek() != '(')
                    {
                        char c = stack.Peek();
                        if (c == '+' || c == '*' || c == '-' || c == '/')
                        {
                            isRedundant = false;
                        }
                        stack.Pop();
                    }
                    if (isRedundant)
                    {
                        return 1;
                    }
                    stack.Pop();
                    isRedundant = true;
                }
                else
                {
                    stack.Push(A[i]);
                }
            }
            return 0;
        }

        public static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        public static int Braces1(String A)
        {

            int n = A.Length;
            Stack<char> st = new Stack<char>();
            foreach (char c in A)
            {
                if (c == '(')
                {
                    st.Push(c);
                }
                else if (c == ')')
                {
                    char top = st.Peek();
                    if (!IsOperator(top))
                    {
                        return 1;
                    }

                    while (IsOperator(st.Peek()))
                    {
                        st.Pop();
                    }

                    if (st.Peek() != '(')
                    {
                        return 1;
                    }
                    
                    st.Pop();
                }
                else if (IsOperator(c))
                {
                    st.Push(c);
                }
            }
            while (st.Count != 0 && IsOperator(st.Peek()))
            {
                st.Pop();
            }
            return st.Count == 0 ? 0 : 1;
        }

        /// <summary>
        /// Candies and Queries
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <returns></returns>
        public static  List<int> Solve(int A, List<List<int>> B, List<int> C)
        {
            int[] prefix = new int[A];
            List<int> ans = new List<int>();
            Dictionary<int, int> map = new Dictionary<int, int>();
            int n = B.Count(), m = C.Count();
            for (int i = 0; i < n; i++)
            {
                prefix[B[i][0] - 1] += 1;
                if (B[i][1] < A)
                {
                    prefix[B[i][1]] -= 1;
                }
            }
            n = prefix.Count();
            for (int i = 1; i < n; i++)
            {
                prefix[i] = prefix[i - 1] + prefix[i];
            }
            prefix = prefix.ToList().OrderByDescending(x => x).ToArray();
            for (int i = 0; i < n; i++)
            {
                if (map.ContainsKey(prefix[i]))
                {
                    map[prefix[i]]++;
                }
                else
                {
                    int val = 0;
                    if(prefix[i] > 0)
                    {
                        map.TryGetValue(prefix[prefix[i] - 1], out val);
                    }
                    map.Add(prefix[i], 1 + val);
                }
            }
            for (int i = 0; i < m; i++)
            {
                map.TryGetValue(C[i], out int val);
                ans.Add(val);
            }
            return ans;
        }

        public static string Solve1(List<int> A)
        {
            int n = A.Count();
            Dictionary<int, int> map = new Dictionary<int, int>();
            for(int i = 0; i < n; i++)
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

            if(map.Count() % 2 != 0)
            {
                return "LOSE";
            }
            foreach (var m in map)
            {
                if(n % m.Value != 0)
                {
                    return "LOSE";
                }
            }
            return "WIN";
        }

        /// <summary>
        ///  Largest Rectangle in Histogram
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int LargestRectangleArea(List<int> A)
        {
            int n = A.Count(), ans = int.MinValue;
            List<int> smallerLeft = new List<int>() { -1 };
            List<int> smallerRight = new List<int>() { n };
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            for(int i = 1; i < n; i++)
            {
                while(stack.Count() > 0 && A[i] < A[stack.Peek()])
                {
                    stack.Pop();
                }
                if(stack.Count() > 0)
                {
                    smallerLeft.Add(stack.Peek());
                }
                else
                {
                    smallerLeft.Add(-1);
                }
                stack.Push(i);
            }
            stack.Clear();
            stack.Push(n-1);
            for (int i = n-2; i >= 0; i--)
            {
                while (stack.Count() > 0 && A[i] < A[stack.Peek()])
                {
                    stack.Pop();
                }
                if (stack.Count() > 0)
                {
                    smallerRight.Add(stack.Peek());
                }
                else
                {
                    smallerRight.Add(n);
                }
                stack.Push(i);
            }
            smallerRight.Reverse();
            for(int i = 0; i < n; i++)
            {
                int h = A[i];
                int w = smallerRight[i] - smallerLeft[i] - 1;
                ans = Math.Max(ans, h * w);
            }
            return ans;
        }

        /// <summary>
        /// All Subarrays
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int Solve3(List<int> A)
        {
            int n = A.Count(), ans = 0;
            Stack<int> min = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                while (min.Count() > 0)
                {
                    ans = Math.Max(ans, A[min.Peek()] ^ A[i]);
                    if (A[min.Peek()] > A[i])
                    {
                        break;
                    }
                    else
                    {
                        min.Pop();
                    }
                }
                min.Push(i);
            }
            return ans;

        }

        /// <summary>
        /// MAX and MIN
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        /// 4, 7, 3, 8
        public static int Solve2(List<int> A)
        {
            int n = A.Count(), mod = 1000000007;
            long ans = 0;
            int min = int.MaxValue, max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                min = int.MaxValue;
                max = int.MinValue;
                for (int j = i; j < n; j++)
                {
                    min = Math.Min(min, A[j]);
                    max = Math.Max(max, A[j]);
                    ans += max - min;
                    ans %= mod;
                }
            }
            return (int)ans;

        }

        public static int Solve(List<List<int>> A)
        {
            if (A == null || A.Count() == 0)
            {
                return 0;
            }
            int n = A.Count(), m = A[0].Count();
            int[] histogram = new int[m];
            int maxArea = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (A[i][j] == 0)
                    {
                        histogram[j] = 0;
                    }
                    else
                    {
                        histogram[j]++;
                    }
                }
                maxArea = Math.Max(maxArea, CalculateMaxArea(histogram));
            }

            return maxArea;

        }

        static int CalculateMaxArea(int[] heights)
        {
            Stack<int> stack = new Stack<int>();
            int maxArea = 0;

            for (int i = 0; i < heights.Length; i++)
            {
                while (stack.Count() > 0 && heights[i] < heights[stack.Peek()])
                {
                    int height = heights[stack.Pop()];
                    int width = i;
                    if (stack.Count() > 0)
                    {
                        width = i - stack.Peek() - 1;
                    }
                    maxArea = Math.Max(maxArea, height * width);
                }
                stack.Push(i);
            }

            while (stack.Count() > 0)
            {
                int height = heights[stack.Pop()];
                int width = heights.Length;
                if (stack.Count() > 0)
                {
                    width = heights.Length - stack.Peek() - 1;
                }
                maxArea = Math.Max(maxArea, height * width);
            }
            return maxArea;
        }

        public static int SumOfSubarrayValues(List<int> A)
        {
            int MOD = 1000000007;
            int n = A.Count();

            long[] maxCount = new long[n];
            long[] minCount = new long[n];

            Stack<int> stack = new Stack<int>(); // For storing indices

            // Calculate maxCount array
            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && A[stack.Peek()] < A[i])
                {
                    stack.Pop();
                }
                if (stack.Count > 0)
                {
                    maxCount[i] = maxCount[stack.Peek()] + (i - stack.Peek()) * (long)A[i];
                }
                else
                {
                    maxCount[i] = (i + 1) * (long)A[i];
                }
                stack.Push(i);
            }

            stack.Clear();

            // Calculate minCount array
            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && A[stack.Peek()] > A[i])
                {
                    stack.Pop();
                }
                if (stack.Count > 0)
                {
                    minCount[i] = minCount[stack.Peek()] + (i - stack.Peek()) * (long)A[i];
                }
                else
                {
                    minCount[i] = (i + 1) * (long)A[i];
                }
                stack.Push(i);
            }

            long result = 0;

            // Calculate sum of values for all subarrays
            for (int i = 0; i < n; i++)
            {
                result += (maxCount[i] - minCount[i]) % MOD;
                result %= MOD;
            }

            return (int)(result % MOD);
        }

    }
}
