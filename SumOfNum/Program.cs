using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfNum
{
    internal class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { this.val = x; this.next = null; }
        }
       
        static int[] numbers;
        static void Main(string[] args)
        {


            //int num1 = Convert.ToInt32(Console.ReadLine());
            //int num2 = Convert.ToInt32(Console.ReadLine());

            //FullNumericPyramid(5);
            //DecimalToBinary(num1);
            //PrimeNumber(num1);
            //BinaryToDecimal(num1);
            //Reverse(num);
            //PrimeNumber(num1, num2);
            //GCD(num1, num2);
            //inc(5);
            // dec(5);
            //numbers = new int[4 + 2];
            //numbers[1] = 1;
            //numbers[2] = 1;

            //Console.WriteLine(Fibonacci1(4));
            // Console.WriteLine(Pow(8,9));
            //Console.WriteLine(Multiply(3, 7));


            //int noOfOps = Convert.ToInt32(Console.ReadLine());
            //while (noOfOps != 0)
            //{
            //    int num1 = Convert.ToInt32(Console.ReadLine());
            //    int num2 = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine(HCF(num1,num2));

            //}
            // MagicNumbers2(10);
            //Console.WriteLine(Decimal(101101));
            //Binary(29);
            // checkfibonacci(8);
            //Fibonacci2(15);
            //Binary(969937577);
            // Console.WriteLine(DToB(10)); 
            //Console.WriteLine(MagicNumbers3(1));
            //solve(5);
            //trailingZeroes(9247);
            //SquareRoot(84630800);
            //RedOrGreen(5, "RGRGR");
            //FindSum("1abc23");
            //BalancedNumber("12345");
            //Console.WriteLine(RemoveDups("zvvo"));
            //Console.WriteLine(kthsmallest(new List<int>() { 94, 87, 100, 11, 23, 98, 17, 35, 43, 66, 34, 53, 72, 80, 5, 34, 64, 71, 9, 16, 41, 66, 96 }, 19));
            //Console.WriteLine(ReverseArray(new List<int>() { 1, 2, 3, 2, 1 }));
            //Console.ReadLine();
            //string[] str = new string[5];
            //str[0] = "2";
            //str[1] = "3";
            //str[2] = "1";
            //str[3] = "4";
            //str[4] = "2";
            //for (int i = 0; i < 5; i++)
            //{
            //    if (i != 3 - 1)
            //    eve{
            //        Console.Write(5 + " ");
            //        // Console.Write(input[i] + " ");
            //    }
            //    Console.Write(str[i] + " ");
            //}
            //List<int> prices = new List<int>() { 3, 2, 1 };

            //Console.WriteLine(MaxProfite(prices));
            //Solve("abdaccc", "baacd");
            //FindMinimumXOR(9, 3);
            //Jump(new List<int>() { 7, 1, 3, 4, 1, 7 });
            //ListNode listNode = new ListNode(1);
            //listNode.next = new ListNode(3);
            //listNode.next.next = new ListNode(5);
            //listNode.next.next.next = new ListNode(3);
            //Solve(listNode, 5);
            //Solve(5, new List<string>() { "mmo", "oo", "cmw", "cc", "c" });
            //Solveq(new List<int>() { 27, 19, 44, 10, 24, 36 }, new List<int>() { 19, 8, 16, 5, 9 });
            //Solve(new List<int>() { 1, 2, 3, 5, 4, 6, 4, 5, 4, 1, 2, 6, 4, 7, 8, 9, 4, 51, 1, 12 });
            //Foo(3, 5);
            Test123();
            Console.ReadLine();

        }

        public static int Solve(List<int> A, int B)
        {
            int n = A.Count();
            int ans = 0;
            for (int i = 0; i < n - 1; i++)
            {
                if (A[i] + A[i + 1] > B)
                {
                    if (A[i] > A[i + 1])
                    {
                        A[i]--;
                    }
                    else
                    {
                        A[i + 1]--;
                    }
                    ans++;
                    i--;
                }
            }
            return ans;
        }

        public static void Reverse(int num)
        {
            while (num != 0)
            {
                Console.Write(num % 10);
                num = num / 10;
            }

        }
        public static void PrimeNumber(int a, int b)
        {
            bool isPrime = true;
            Console.Write("Prime numbers between {0} and {1} are ", a, b);
            for (int i = a; i <= b; i++)
            {
                for (int j = 2; j <= i - 1; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    else
                    {
                        isPrime = true;
                    }
                }
                if (isPrime)
                {
                    Console.Write(i + " ");
                }
            }
        }

        public static int GCD(int num1, int num2)
        {
            int remainder = 0;
            while (num2 != 0)
            {
                remainder = num1 % num2;
                num1 = num2;
                num2 = remainder;
            }
            return num1;

        }

        public static void PrimeNumber(int num)
        {
            bool isPrime = true; bool noPrime = true;
            for (int i = 2; i <= num; i++)
            {
                //Console.WriteLine($"square root of i {i} " + Math.Sqrt(i));
                isPrime = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                    }
                }
                if (isPrime)
                {
                    noPrime = false;
                    Console.Write(i + " ");
                }
            }
            if (noPrime)
            {
                Console.WriteLine("There are no prime numbers less than or equal to " + num);
            }
        }
        public static void BinaryToDecimal(int num)
        {
            double sum = 0, count = 0;
            while (num != 0)
            {
                sum += (num % 10) * Math.Pow(2, count);
                count++;
                num = num / 10;
            }
            Console.WriteLine(sum);
        }

        public static void DecimalToBinary(int num)
        {
            int[] vs = new int[32];
            int count = 0;
            while (num != 0)
            {
                vs[count] = num % 2;
                num = num / 2;
                count++;
            }
            for (int i = count - 1; i >= 0; i--)
            {
                Console.Write(vs[i]);
            }
        }

        public static void FullNumericPyramid(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(0 + " ");
                }

                for (int j = i; j <= 2 * i - 1; j++)
                {
                    Console.Write(j + " ");
                }
                for (int j = 2 * i - 2; j >= i; j--)
                {
                    Console.Write(j + " ");
                }
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(0 + " ");
                }
                Console.WriteLine();
            }
        }

        public static void inc(int n)
        {
            if (n == 0)
            {
                return;
            }
            inc(n - 1);
            Console.WriteLine(n);

        }

        public static void dec(int n)
        {
            if (n == 0)
            {
                return;
            }
            Console.WriteLine(n);
            dec(n - 1);
        }
        public static int Fibonacci(int n)
        {
            if ((n == 0) || (n == 1))
            {
                return n;
            }
           return Fibonacci(n - 1) + Fibonacci(n - 2);

        }
        public static int Fibonacci1(int n)
        {
            if (numbers[n]==0)
            {
               numbers[n] = Fibonacci1(n - 1) + Fibonacci1(n - 2);
            }
            return numbers[n];

        }
        public static long Pow(int num, int n)
        {
            if(n == 0)
            {
                return 1;
            }
            return num * Pow(num, n-1);

        }

        static int Multiply(int num, int n)
        {
            if(n == 0)
            {
                return 0;
            }
            return num + Multiply(num, n - 1);
        }

        static int Sum(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            return n % 10 + Sum(n / 10);
        }

        static int HCF(int num1, int num2)
        {
            if(num1 == 0)
            {
                return num2;
            }
            return HCF(num2%num1, num1);
        }

        static int MagicNumbers(int A)
        {
            int sum = 0;
            int[] nums = new int[A];
            
            int count = 1;

            for (int i = 0; i < A; i++)
            {

                if(i == 0)
                {
                    sum = 5;
                    nums[0] = sum;
                }
                else if (i % 2 != 0)
                {
                    sum = nums[i - count] * 5;
                    nums[i] = sum;
                    count++;
                }
                else
                {
                    sum = sum + 5;
                    nums[i] = sum;

                }

            }
            return sum;

        }

        static int MagicNumbers1(int A)
        {
            int count = 0;
            double num = 0;
            while (A>0)
            {
                count++; 
                if (A%2==1)
                {
                    num = num + Math.Pow(5, count);
                }
                A =A/2;

            }
            return (int)num;
        }

        static int Decimal(int A)
        {
            int count = 0;
            double num = 0;
           
            while (A != 0)
            {
                num += A % 10 * Math.Pow(2, count);
                A = A / 10;
                count++;
            }
            return Convert.ToInt32(num);
        }

        static void Binary(int A)
        {
            int binary = 0;
            int count = 0;
            while (A > 0)
            {
                binary +=  (int)Math.Pow(10,count)*(A%2);
                A = A/2;
                count++;
            }
            Console.WriteLine(binary);
        }
        static void MagicNumbers2(int A)
        {
            int count = 1;
            int num = 0;
            while (A > 0)
            {
                if (A%2==1)
                num = num + (int)Math.Pow(5, count);
                A = A / 2;
                count++;
            }

            Console.WriteLine(num);

        }

        static bool checkfibonacci(int n)
        {
            int a = 0;
            int b = 1;
            if (n == a || n == b) 
                return 
                    true;
            int c = a + b;
            while (c <= n)
            {
                if (c == n) 
                    return true;
                a = b;
                b = c;
                c = a + b;
            }
            return false;
        }

        static void Fibonacci2(int n)
        {
            int a = 0;
            int b = 1;
            int c = 0;
            Console.Write(a + " ");
            Console.Write(b+ " ");
            for (int i = 2; i <= n; i++)
            {
                c = a + b;
                Console.Write(c + " ");
                a = b;
                b = c;
            }
        }


        static int DToB(int num)
        {
            double decimalNum =0;
            int count = 0;
            while (num > 0)
            {
                decimalNum += (num % 2) * Math.Pow(10, count);
                count++;
                num /= 2;
            }
            return (int)decimalNum;
        }

        static int trailingZeroes(int A)
        {
            int zeros = 0;
            int count = 5;
            while (A / count != 0)
            {
                zeros += A / count;
                count *= 5;
            }
            return zeros;
        }

        static int MagicNumbers3(int A)
        {
            int p = 5;
            double ans = 0;
            while(A > 0)
            {
                ans += A % 2 * p;
                p = p * 5;
                A /= 2;
            }
             return (int)ans;
        }

        public static List<List<int>> solve(int A)
        {
            List<List<int>> vs = new List<List<int>>();
            List<int> ts;
            int numertor = 0;
            int demonitor = 0;
            for (int i = 0; i <= A; i++)
            {
               
                ts = new List<int>();
                //ts.Add(1);
                for (int j = 0; j < A; j++)
                {
                    if (j == 0 )
                    {
                        ts.Add(1);
                    }
                    else if(i == 0 || j > i)
                    {
                        ts.Add(0);
                    }
                    else
                    {
                        numertor = 0;
                        demonitor = 1;
                        for (int n = 1; n <= i; n++)
                        {
                            numertor += i * n;
                            demonitor *= n;
                            ts.Add(numertor / demonitor);
                            numertor = 0;
                            demonitor = 1;
                        }
                    }

                }
                vs.Add(ts);
            }
            return vs;
        }

        /// <summary>
        /// Square root of a number
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int SquareRoot(int A)
        {
            for (decimal i = 1; i <= A; i++)
            {
                if (i * i == A)
                {
                    return Convert.ToInt32(i);
                }
            }
            return -1;
        }

        public static int RedOrGreen(int N, string S)
        {
            int rCount = 0, gCount = 0;
            for (int i = 1; i <= N; i++)
            {
                if (S[i] == 'R')
                {
                    rCount++;
                }
                if (S[i] == 'G')
                {
                    gCount++;
                }
            }
            if (rCount == gCount)
            {
                return 1;
            }
            else if (rCount < gCount)
            {
                return rCount;
            }
            else
            {
                return gCount;
            }
        }

        /// <summary>
        /// Sum of numbers in string 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int FindSum(string str)
        {

            // Your code here
            int sum = 0;
            string s = string.Empty;
            for(int i = 0; i < str.Length; i++)
            {
                if(str[i] >= '0' && str[i] <= '9')
                {
                    s += str[i];
                }
                else
                {
                    sum += Convert.ToInt32(s);
                    s = "0";

                }
              
            }
            sum += Convert.ToInt32(s);
            return sum;

        }

        /// <summary>
        /// Remove Duplicates from given string
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        static string RemoveDups(string S)
        {
           
            string ans = S[0].ToString();

            // Your code goes here
            for (int i = 1; i < S.Length; i++)
            {
                if (!ans.Contains(S[i]))
                {
                    ans += S[i];
                }
            }
            return ans;
        }

        /// <summary>
        /// Check if the number is balanced in given string 
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        static bool BalancedNumber(string N)
        {
            // code here
            int mid = N.Length / 2;
            int left = 0;
            int right = 0;
            for (int i = 0; i < mid; i++)
            {
                left = left + (N[i] - 48);
                right = right + (N[N.Length - i - 1] - 48);
            }
            if (left == right)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Kth Smallest Element
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int kthsmallest(List<int> A, int B)
        {
            int minValueIndex = 0;
            for (int i = 0; i < B; i++)
            {
                minValueIndex = 0;
                for (int j = 0; j < A.Count() - i; j++)
                {
                    if (A[minValueIndex] > A[j])
                    {
                        minValueIndex = j;
                    }
                }
                if (minValueIndex != (A.Count() - i - 1))
                {
                    int temp = A[A.Count() - i - 1];
                    A[A.Count() - i - 1] = A[minValueIndex];
                    A[minValueIndex] = temp;
                }

            }
            return A[A.Count - B];
        }

        /// <summary>
        ///  Reverse the Array
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<int> ReverseArray(List<int> A)
        {
            int start = 0;
            int end = A.Count() - 1;
            while (start < end)
            {
                A[start] = A[start] * A[end];
                A[end] = A[start] / A[end];
                A[start] = A[start] / A[end];
                start++;
                end--;
            }
            return A;
        }

        public static int Solve(List<int> A, int B, int C)
        {
            int n = A.Count(); string temp = string.Empty; int ans = 0; string temp1 = string.Empty;
            for (int i = 0; i < n; i++)
            {
                temp = string.Empty;
                temp += A[i];
                for (int j = 0; j < n; j++)
                {
                    temp1 = Convert.ToString(Convert.ToInt16(temp));
                    if (temp.Length < B && Convert.ToInt32(temp) < C)
                    {
                        temp += A[j];
                    }
                    else
                    {
                        if (temp1.Length == B && Convert.ToInt32(temp) < C)
                        {
                            ans++;
                        }
                        temp = A[i].ToString();
                        if (j > 0)
                        {
                            j--;
                        }
                    }
                }
                string s = Convert.ToString(Convert.ToInt16(temp));
                if (A.Count > 1 && s.Length == B && Convert.ToInt32(temp) < C)
                {
                    ans++;
                }

            }
            return ans;
        }


        static int MaxProfite(List<int> prices)
        {
            if (prices.Count() <= 1)
            {
                return 0;
            }
            int n = prices.Count();
            List<int> s0 = new List<int>();
            List<int> s1 = new List<int>();
            List<int> s2 = new List<int>();
            for (int i = 0; i < n; i++)
            {
                s0.Add(0);
                s1.Add(0);
                s2.Add(0);
            }
            s0[0] = 0;
            s1[0] = int.MinValue;
            s2[0] = int.MinValue;
            for (int i = 1; i < prices.Count(); i++)
            {
                s0[i] = Math.Max(s0[i - 1], s2[i - 1]);
                s1[i] = Math.Max(s1[i - 1], s0[i - 1] - prices[i]);
                s2[i] = s1[i - 1] + prices[i];
            }
            return Math.Max(s0[prices.Count() - 1], s2[prices.Count() - 1]);
        }

        public static int Solve(string A, string B)
        {
            int[] arr = new int[26];
            int n = A.Length, m = B.Length;
            for (int i = 0; i < m; i++)
            {
                arr[B[i] - 'a']++;
            }
            for (int i = 0; i < n; i++)
            {
                arr[A[i] - 'a']--;
            }
            for (int i = 0; i < 26; i++)
            {
                if (arr[i] > 0)
                {
                    return 0;
                }
            }
            return 1;

        }

        static int FindMinimumXOR(int A, int B)
        {
            int X = 0;
            int count = 0;

            for (int i = 31; i >= 0; i--)
            {
                int bit = (A >> i) & 1;

                if (bit == 1)
                {
                    if (count < B)
                    {
                        X |= (1 << i);
                        count++;
                    }
                }
                else
                {
                    if (count >= B)
                    {
                        X |= (1 << i);
                    }
                }
            }

            return X;
        }

        static int CountSetBits(int number)
        {
            int count = 0;

            while (number != 0)
            {
                if ((number & 1) == 1)
                    count++;

                number >>= 1;
            }

            return count;
        }

         static public int Jump(List<int> A) {
            int n = A.Count(), ans = int.MaxValue;
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
               
            for (int i = 0; i < n; i++){
                if(!dic.ContainsKey(A[i])){
                    List<int> indexes = new List<int>(){i};
                    dic.Add(A[i], indexes);
                }
                else{
                    dic[A[i]].Add(i);
                }
            }

            foreach (var item in dic)
            {
                int size = item.Value.Count;
                if (size <= 1)
                {
                    continue;
                }
                else
                {
                    ans = Math.Min(ans, Math.Abs(item.Value[size - 1] - item.Value[size - 2]));
                }
            }
            return ans;
        
         }

        public static ListNode Solve(ListNode A, int K)
        {
            List<KeyValuePair<int, int>> keyValuePair = new List<KeyValuePair<int, int>>();
            KeyValuePair<int, int> keyValuePair1 = new KeyValuePair<int, int>();

            keyValuePair.Add(new KeyValuePair<int, int>(12, 12));
            keyValuePair.OrderByDescending(x => x.Key);
            ListNode current = A;

            while (current != null)
            {
                ListNode prev = current;
                ListNode next = current.next;

                int prevDiff = int.MaxValue;
                int nextDiff = int.MaxValue;

                if (prev != null)
                    prevDiff = Math.Abs(K - (prev.val % K));

                if (next != null)
                    nextDiff = Math.Abs(K - (next.val % K));

                if (prevDiff < nextDiff)
                    current.val = prev.val + (prev.val % K > 0 ? K - (prev.val % K) : 0);
                else
                    current.val = next.val + (next.val % K > 0 ? K - (next.val % K) : 0);

                current = current.next;
            }

            return A;

        }

        private static ListNode FindClosestMultiple(ListNode node, int target, int B)
        {
            ListNode closestMultipleNode = null;
            int minDifference = int.MaxValue;

            while (node != null)
            {
                if (node.val % B == 0)
                {
                    return node;
                }

                int difference = Math.Abs(node.val - target);

                if (difference < minDifference)
                {
                    minDifference = difference;
                    closestMultipleNode = node;
                }

                node = node.next;
            }

            return closestMultipleNode;
        }
    
        public static List<int> Solveq(List<int> arr, List<int> B)
        {
            List<int> ans = new List<int>();
            arr.Sort();
            for (int i = 0; i < B.Count(); i++)
            {
                int left = 0, right = arr.Count() - 1, temp = -1;
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    if (arr[mid] <= B[i])
                    {
                        temp = arr[mid];
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                ans.Add(temp);
            }
            return arr;
        }

        public static int Solve(int A, List<string> B)
        {
            List<KeyValuePair<int, int>> happiness = new List<KeyValuePair<int, int>>();
            int n = B.Count(), ans = 0;
            for (int i = 0; i < n; i++)
            {
                string temp = B[i];
                int sum = 0;
                for (int j = 0; j < temp.Length; j++)
                {
                    if (temp[j] == 'c')
                    {
                        sum += 4;
                    }
                    else if (temp[j] == 'w')
                    {
                        sum += 3;
                    }
                    else if (temp[j] == 'm')
                    {
                        sum += 2;
                    }
                    else if (temp[j] == 'o')
                    {
                        sum += 1;
                    }
                }
                sum *= temp.Length;
                happiness.Add(new KeyValuePair<int, int>(sum, temp.Length));
            }
            happiness = happiness.OrderByDescending(pair => pair.Key).ToList();
            for (int i = 0; i < happiness.Count(); i++)
            {
                int C = A;
                var keyvaluepair = happiness[i];
                int sum = 0;
                if (C - keyvaluepair.Value  >= 0)
                {
                    sum += keyvaluepair.Key;
                    C -= keyvaluepair.Value;
                }
                else
                {
                    continue;
                }
                for (int j = i + 1; j < happiness.Count(); j++)
                {
                    var pair = happiness[j];
                    if (C - pair.Value  >= 0)
                    {
                        sum += pair.Key;
                        C -= pair.Value;
                    }
                }
                if(C == 0)
                {
                    ans = Math.Max(ans, sum);

                }
            }
            return ans;
        }

        public int black(List<string> A)
        {
            if (A == null || A.Count() == 0)
            {
                return 0;
            }
            int rows = A.Count();
            int cols = A[0].Length;
            int count = 0;
            char[,] charArr = new char[rows,cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    charArr[i,j] = A[i][j];

                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {

                    if (charArr[i,j] == 'X')
                    {
                        count++;
                        DFS(charArr, i, j, rows, cols);
                    }
                }
            }
            return count;
        }

        private void DFS(char[,] A, int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols || A[row,col] != 'X')
            {
                return;
            }
            A[row,col] = 'O';
            DFS(A, row - 1, col, rows, cols);
            DFS(A, row + 1, col, rows, cols);
            DFS(A, row, col - 1, rows, cols);
            DFS(A, row, col + 1, rows, cols);
        }

        public static int Solve(List<int> A)
        {
            int n = A.Count(), ans = 0;
            int dis = A.Distinct().Count();
            ans = Math.Abs(dis - n);
            return ans;
        }
        public static int Bar(int x, int y)
        {
            if (y == 0)
            {
                return 0;
            }
            return (x + Bar(x, y - 1));
        }

        public static int Foo(int x, int y)
        {
            if(y == 0)
            {
                return 1;
            }
            return Bar(x, Foo(x, y - 1));
        }

        public static void Test123()
        {
            int j = 0;
            for (int i = 0; i < 5; i++)
            {
                while (j <= i)
                {
                    Console.WriteLine(i+j); 
                    j++;
                }
            }
            Console.ReadKey();
        }
    }


}
