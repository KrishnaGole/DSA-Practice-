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
            solve(3);
        }

        /// <summary>
        /// Single Number
        /// Given an array of integers A, every element appears twice except for one. Find that single one.
        /// NOTE: Your algorithm should have a linear runtime complexity.Could you implement it without using extra memory?
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int singleNumber(List<int> A)
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
        public static int numSetBits(int A)
        {
            int count = 0;
            while (A != 0)
            {
                A = A & (A - 1);
                count++;
            }
            return count;
        }

        public static long solve(long A)
        {
            long temp = 1 << 26;
            return 0;

        }
    }
}
