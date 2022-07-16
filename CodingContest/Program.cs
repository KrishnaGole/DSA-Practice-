using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var ans =  Solve(new List<int>() { 1,2,3});
        }

        public static long Solve(List<int> A)
        {
            List<int> pq = new List<int>();
            int n = A.Count(); long res = 0;
            for (int i = 0; i < n; i++)
            {
                pq.Add(A[i]);
            }

            while (pq.Count() > 1)
            {
                pq.Sort();
                int a = pq[0];
                int b = pq[1];
                pq.RemoveAt(0);
                pq.RemoveAt(0);
                res = res + (a + b);
                pq.Add(a + b);

            }
            return res;
        }
    }
}
