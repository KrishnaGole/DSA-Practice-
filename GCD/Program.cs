using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Solve(new List<int>() { 3, 9, 6, 8, 3 });
            //GCD1(16, 24);
            Solve1(new List<int>() { 1, 31, 1, 1, 1, 1, 14, 2, 1, 1, 1, 2, 22, 1, 11, 1, 1, 1, 1, 23, 1, 1, 11, 1, 11 });

        }

        public static int Solve(List<int> A)
        {
            List<int> pfGCD = new List<int>();
            int[] sfGCD = new int[A.Count()];
            int left = 0;
            int right = 0;
            int ans = 0;
            pfGCD.Add(A[0]);
            sfGCD[A.Count() - 1] = (A[A.Count() - 1]);

            for (int i = 1; i < A.Count(); i++)
            {
                pfGCD.Add(GCD(pfGCD[i - 1], A[i]));
            }

            for (int i = A.Count() - 2; i >= 0; i--)
            {
                sfGCD[i] = GCD(sfGCD[i + 1], A[i]);
            }

            for (int i = 0; i < A.Count(); i++)
            {
                if ((i - 1) >= 0)
                {
                    left = pfGCD[i - 1];
                }
                if ((i + 1) <= (A.Count() - 1))
                {
                    right = sfGCD[i + 1];
                }
                ans = Math.Max(ans, GCD(left, right));
            }
            return ans;
        }

        public static int GCD(int A, int B)
        {
            if (A == 0)
            {
                return B;
            }
            return GCD(B % A, A);
        }

        public static int GCD1(int A, int B)
        {
            if(A == 0)
            {
                return B;
            }
            if(B == 0)
            {
                return A;
            }
            while(A != B)
            {
                if(A > B)
                {
                    A = A - B;
                }
                else
                {
                    B = B - A;
                }
            }
            return A;
        }

        public static List<int> Solve1(List<int> A)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            List<int> B = new List<int>();
            A = A.OrderByDescending(x => x).ToList();
            foreach (var a in A)
            {
                if (map.ContainsKey(a) && map[a] > 0)
                {
                    map[a]--;
                }
                else
                {
                    foreach (var b in B)
                    {
                        int temp = Gcd(a, b);
                        if (map.ContainsKey(temp))
                        {
                            map[temp] += 2;
                        }
                        else
                        {
                            map.Add(temp, 2);
                        }

                    }
                    if (!map.ContainsKey(a))
                    {
                        map.Add(a, 1);
                    }
                    B.Add(a);
                }
            }
            B.Reverse();
            return B;
        }

        public static int Gcd(int A, int B)
        {
            if (B == 0)
            {
                return A;
            }
            return Gcd(B, A % B);
        }


    }
}
