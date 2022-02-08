using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulerOperator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Solve(12,19);
            //FindMod("842554936302263", 41);
            var temp = 'a' - '0';
            int[] vs = new int[10];
            //Array.Sort(vs, new Comparer()

            Console.ReadLine();
        }

        /// <summary>
        /// A, B and Modulo
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int Solve(int A, int B)
        {
            return Math.Abs(A - B);
        }


        /// <summary>
        ///  Mod String
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int FindMod(string A, int B)
        {
            int len = A.Length;
            int count = 0;
            int ans = 0;
            for (int i = len - 1; i >= 0; i--)
            {
                ans = ans + (int)((A[i] - '0') % B * Math.Pow(10, count) % B) % B;
                count++;
            }
            return ans % B;
        }

    }
}
