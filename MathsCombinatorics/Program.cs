using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsCombinatorics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Solve(5, 2, 13);
            //var ans = Factorial(4, 100);
            //var ans = Solve1(5, 2, 13);
            //var ans1 = Convert.ToInt32("jndnd");
            //FindAthFibonacci(4);

            //var ans = Reverse(0, input.Length - 1, new StringBuilder("krishna"));
            //var ans = Solve2(6);
            var ans = FindRank("view");
        }

        public static int Solve(int N, int R, int P)
        {
            int[,] v = new int[N + 1, R + 1];
            for (int j = 0; j <= R; j++)
            {
                v[0,j] = 0;
            }
            for (int i = 0; i <= N; i++)
            {
                v[i,0] = 1;
            }
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= R; j++)
                {
                    v[i,j] = (v[i - 1,j] + v[i - 1,j - 1]) % P;
                }
            }
            return v[N,R];

        }

        public static int Solve1(int N, int R, int P)
        {
            long[] Factorial = new long[N + 1];
            Factorial[0] = 1;
            Factorial[1] = 1;
            for (int i = 2; i <= N; i++)
            {
                Factorial[i] = (Factorial[i - 1] * i) % P;
            }
            long numerator = Factorial[N];
            long denominator = (Factorial[R] % P * Factorial[N - R] % P) % P;
            long y = Pow(denominator, P - 2, P) % P;
            return (int)((numerator % P * y % P) % P);

        }
        public static long Factorial(long A, long P)
        {
            if(A == 1 || A == 0)
            {
                return 1;
            }
            return ((A % P) * (Factorial(A - 1, P)%P))%P;
        }
        public static long Pow(long A, long B, long C)
        {
            if(A == 0 && B == 0)
            {
                return 0;
            }
            if(B == 0)
            {
                return 1;
            }
            long he = Pow(A, B / 2, C);
            if(B % 2 == 0)
            {
                return (he % C * he % C) % C;
            }
            else
            {
                return (he % C * he % C * A % C) % C;
            }
        }

        public int pow(int A, int B, int C)
        {
            if (A == 0)
            {
                return 0;
            }
            if (B == 0)
            {
                return 1;
            }
            long he = pow(A, B / 2, C);
            if (B % 2 == 0)
            {
                if ((he % C * he % C) % C < 0)
                {
                    return (int)((he % C * he % C) + C) % C;
                }
                return (int)(he % C * he % C) % C;
            }
            else
            {
                if ((he % C * he % C * A) % C < 0){
                    return (int)((he % C * he % C * A % C) + C) % C;
                }
                return (int)(he % C * he % C * A % C) % C;
            }
        }

        static List<int> ans = new List<int>();
        public static int FindAthFibonacci(int A)
        {
            ans.Add(Fib(A));
            return ans[A-1];
        }

        public static int Fib(int A)
        {
            if (A == 1)
            {
                return 1;
            }
            if (A == 0)
            {
             return 0;
            }
        
         
         
         return Fib(A-1)+Fib(A-2);
        }

        public static string Reverse(int start, int end, StringBuilder input)
        {
            if (start >= end)
            {
                return input.ToString();
            }
            char temp = input[start];
            input[start] = input[end];
            input[end] = temp;
            return Reverse(++start,--end, input);

        }
        static int count = 0;
        public static int Solve2(int A)
        {
            if (count > 0)
            {
                return 0;
            }
            if (A == 0 || A == 1)
            {
                return 1;
            }
            if (A == 2)
            {
                return 2;
            }
            return (Solve2(A - (++count)) + Solve2(A - (++count))) + A;

        }

        public static int FindRank(string A)
        {
            int count = 0; long sum = 0; int mod = 1000003;
            for (int i = 0; i < A.Length; i++)
            {
                count++;
                for (int j = i + 1; j < A.Length; j++)
                {
                    if (A[i] > A[j])
                    {
                        count++;
                    }
                }
                sum += count % mod * Fact(A.Length - 1 - i, mod);
            }
            return (int)(sum % mod);

        }

        public static int Fact(int A, int mod)
        {
            if (A == 0)
            {
                return 1;
            }
            return (A % mod * Fact(A - 1, mod) % mod) % mod;

        }
    }
}
