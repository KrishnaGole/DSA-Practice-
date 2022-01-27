using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NoOfWays1(3,3));
            Console.ReadLine();
        }

        static int NoOfWays(int x, int y)
        {
            if(x == 1 && y == 1)
            {
                return 1;
            }
            if(x < 1 || y < 1)
            {
                return 0;
            }
            return NoOfWays(x - 1, y) + NoOfWays(x, y - 1);
        }
        static int NoOfWays1(int x, int y)
        {
            int[,] vs = new int[x+1, y+1];
            vs[0, 0] = 1;
            vs[0, 1] = 1;
            vs[0, 2] = 1;
            for(int r = 1; r < x; r++)
            {
                for(int c = 1; c <= y; c++)
                {
                    vs[r, c] = vs[r - 1, c] + vs[r, c-1];
                }
            }
            return vs[x, y];
        }

    }
}
