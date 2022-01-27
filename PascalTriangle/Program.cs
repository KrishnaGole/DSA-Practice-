using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {

             PascalTriangleWith2DArray();
           // PascalTriangleWithFactorial();
        }
        static void PascalTriangleWith2DArray()
        {
            int num = 6;
            int[,] vs = new int[num, num];
            for(int n = 0; n < num; n++)
            {
                for(int k = 0; k <= n; k++)
                {
                    if(n==k || k == 0)
                    {
                        vs[n, k] = 1;
                    }
                    else
                    {
                        vs[n, k] = vs[n - 1, k - 1] + vs[n - 1, k];
                    }
                    Console.Write(vs[n,k] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        static void PascalTriangleWithFactorial()
        {
            int num = 5;
            for (int n = 0; n < num; n++)
            {
                for (int k = 0; k <= n; k++)
                {
                    long term = factorial(n) / (factorial(k) * factorial(n - k));
                    Console.Write(term + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        static long factorial(int num) 
        {
            long result = 1;
            for (int i = num; i > 0; i--)
            {
                result *= i;
            }
            return result;
        }
        
    }
}
