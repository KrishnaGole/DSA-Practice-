using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitwiseOperatorsConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //singleNumber(new List<int>() { 4, 5, 6, 7, 4, 5, 6 });
            //numSetBits(11);
            //Solve(3);
            //Solve1(new List<int>() { 1, 2, 3, 1, 2, 4 });
            List<int> vs = new List<int>();

            Solve2(10,3);
        }

        /// <summary>
        /// Single Number
        /// Given an array of integers A, every element appears twice except for one. Find that single one.
        /// NOTE: Your algorithm should have a linear runtime complexity.Could you implement it without using extra memory?
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int SingleNumber(List<int> A)
        {
            int xor = A[0];
            int length = A.Count();
            for(int i = 1; i < length; i++)
            {
                xor = xor ^ A[i];
            }
            return xor;
        }

        /// <summary>
        /// Number of 1 Bits
        /// Write a function that takes an integer and returns the number of 1 bits it has.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int NumSetBits(int A)
        {
            int count = 0;
            while (A != 0)
            {
                A = A & (A - 1);
                count++;
            }
            return count;
        }

        public static int Solve(int A)
        {
            int count = 0;
            while(A > 0)
            {
                if((A & 1) == 1)
                {
                    count++;
                }
                A >>= 1;

            }
            return count;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<int> Solve(List<int> A)
        {
            int xor = 0;
            int n = A.Count();
            int mask = 0;
            for (int i = 0; i < n; i++)
            {
                xor ^= A[i];
            }
            mask = (xor & (xor - 1)) ^ xor;
            int a = 0, b = 0;
            for (int i = 0; i < n; i++)
            {
                if ((A[i] & mask) != 0)
                {
                    a = a ^ A[i];
                }
                else
                {
                    b = b ^ A[i];
                }
            }

            return new List<int>() { Math.Min(a, b), Math.Max(a, b) };
        }

        /// <summary>
        /// Single Number III
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<int> Solve1(List<int> A)
        {
            int xor = 0;
            int n = A.Count();
            int mask = 0;
            for (int i = 0; i < n; i++)
            {
                xor ^= A[i];
            }
            mask = (xor & (xor - 1)) ^ xor;
            int a = 0, b = 0;
            for (int i = 0; i < n; i++)
            {
                if ((A[i] & mask) != 0)
                {
                    a = a ^ A[i];
                }
                else
                {
                    b = b ^ A[i];
                }
            }

            return new List<int>() { Math.Min(a, b), Math.Max(a, b) };
        }

        /// <summary>
        /// Reverse Bits
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static long Solve2(long A, int B)
        {
            //long ans = 0;
            //for (int i = 0; i <= 32; i++)
            //{
            //    if (((A >> i) & 1) == 1)
            //    {
            //        ans = ans + ((long)1 << (31 - i));
            //    }
            //}
            //return ans;

            long ans = A;
            for (int i = 0; i < B; i++)
            {
                if (((A >> i) & 1) == 1)
                {
                    ans -= (1 << i);
                }
            }
            return ans;

        }
    }
}
