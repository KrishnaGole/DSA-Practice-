using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfNum
{
    internal class Program
    {
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
            Console.WriteLine(ReverseArray(new List<int>() { 1, 2, 3, 2, 1 }));
            Console.ReadLine();

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


    }
}
