using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var ans =  Primesum(10);
            //Solve(new List<int>() { 9, 9, 3, 6, 7, 5 });
            //CountDivisors(new List<int>() { 2,3,4,5 });
            //Solve(8);
            //var result = fac(27);

            //var result  = pow(2, fac(27) % 1000000007, 1000000007) % 1000000007;
            //Solve1(234);
            //Solve2(new List<int>() { 96, 98, 5, 41, 80 });
            CheckPerfectSquare(10, 0, 10);
        }

        public static List<int> Primesum(int A)
        {
            List<bool> prime = new List<bool>();
            prime.Add(false);
            prime.Add(false);
            List<int> ans = new List<int>();
            for (int i = 2; i <= A; i++)
            {
                prime.Add(true);
            }
            for (int i = 2; i * i <= A; i++)
            {
                if (prime[i])
                {
                    for (int j = i * i; j <= A; j += i)
                    {
                        prime[j] = false;
                    }
                }
            }

            for (int i = 2; i <= A; i++)
            {
                if (prime[i])
                {
                    ans.Add(i);
                }
            }
            for (int i = 0; i < ans.Count(); i++)
            {
                for (int j = i + 1; j < ans.Count(); j++)
                {
                    if (ans[i] + ans[j] == A)
                    {
                        return new List<int>() { ans[i], ans[j] };
                    }
                }
            }
            return new List<int>();

        }

        public static int Solve(List<int> A)
        {
            long count = 0;
            for (int i = 0; i < A.Count(); i++)
            {
                for (int j = i; j < A.Count(); j++)
                {
                    if (i == j)
                    {
                        if (IsPrime(A[i]))
                        {
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (IsPrime(A[i]) && IsPrime(A[j]))
                        {
                            count++;
                        }
                    }

                }
            }
            return (int)(count % 1000000007);
        }
        public static bool IsPrime(int A)
        {
            if (A < 2)
            {
                return false;
            }
            for (int i = 2; i * i <= A; i++)
            {
                if (A % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static List<int> CountDivisors(List<int> A)
        {

            List<int> spf = new List<int>();
            List<int> ans = new List<int>();
            int length = 1000000;
            for (int i = 0; i <= length; i++)
            {
                spf.Add(i);
            }
            for (int i = 2; i * i <= length; i++)
            {
                if (spf[i] == i)
                {
                    for (int j = i * i; j <= length; j = j + i)
                    {
                        if (spf[j] == j)
                        {
                            spf[j] = i;
                        }
                    }
                }
            }

            for (int i = 0; i < A.Count(); i++)
            {
                int x = A[i];
                List<int> p = new List<int>();
                while (x > 1)
                {
                    p.Add(spf[x]);
                    x /= spf[x];
                }
                if (p.Count() > 0)
                {
                    ans.Add(PrimeFactor(p));
                }
                else
                {
                    ans.Add(1);
                }
            }
            return ans;
        }

        public static int PrimeFactor(List<int> l)
        {
            int ans = 1, count = 0, p = l[0];
            for (int i = 0; i < l.Count(); i++)
            {
                if (p == l[i])
                {
                    count++;
                }
                else
                {
                    ans *= (count + 1);
                    count = 1;
                    p = l[i];
                }
            }
            return ans *= (count + 1);

        }

        public static int Solve(int A)
        {
            int[] ans = new int[A + 1];
            for (int i = 2; i < ans.Count(); i++)
            {
                if (ans[i] == 0)
                {
                    ans[i]++;
                    for (int j = i*2; j < ans.Count(); j= j+i)
                    {
                        ans[j]++;
                    }
                }

            }
            return 0;
        }


        public static int solve(int A, int B)
        {
            return (int)pow(A, fac(B), 1000000007);
        }
        public static long fac(long B)
        {
            if (B == 0)
            {
                return 1;
            }
            return (B % 1000000007 * fac(--B) % 1000000007)% 1000000007;
        }
        public static long pow(long A, long B, long C)
        {
            if (A == 0 && B == 0)
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
                return (he % C * he % C) % C;
            }
            else
            {
                return (he % C * he % C * A % C) % C;
            }
        }

        public static int Solve1(int A)
        {
            int ans = 0;
            List<int> primes = new List<int>();
            if (A == 2)
            {
                return 1;
            }
            else if (IsPrime1(A / 2))
            {
                return 2;
            }
            else
            {
                for (int i = 2; i < A; i++)
                {
                    if (IsPrime1(i))
                    {
                        primes.Add(i);
                    }
                }
            }
            for (int i = 0; i < primes.Count(); i++)
            {
                if (A < 0)
                {
                    break;
                }
                if (A - primes[i] >= 0)
                {
                    ans++;
                    A = A - primes[i];
                }
            }
            return ans;

        }
        public static long Solve2(List<int> A)
        {
            int length = A.Count();
            int sum = 0;
            HashSet<int> hs = new HashSet<int>();
            for (int i = 0; i < length; i++)
            {
                int n = A[i];
                for (int j = 2; j * j <= n; j+=2)
                {
                    if (A[i] % j ==0 )
                    {
                        hs.Add(j);
                        n /= i;
                    }
                }
            }

            return hs.Count();
            // return sum;

        }

        public static bool IsPrime1(int A)
        {
            for (int i = 2; i * i <= A; i++)
            {
                if (A % i == 0)
                {
                    return false;
                }
            }
            return true;
        }


        public static int CheckPerfectSquare(int N,
                                     int start,
                                     int last)
        {
            // Find the mid value
            // from start and last
            int mid = (start + last) / 2;

            if (start > last)
            {
                return -1;
            }

            // Check if we got the number which
            // is square root of the perfect
            // square number N
            if (mid * mid == N)
            {
                return mid;
            }

            // If the square(mid) is greater than N
            // it means only lower values then mid
            // will be possibly the square root of N
            else if (mid * mid > N)
            {
                return CheckPerfectSquare(N, start,
                                          mid - 1);
            }

            // If the square(mid) is less than N
            // it means only higher values then mid
            // will be possibly the square root of N
            else
            {
                return CheckPerfectSquare(N, mid + 1,
                                          last);
            }
        }
    }
}
