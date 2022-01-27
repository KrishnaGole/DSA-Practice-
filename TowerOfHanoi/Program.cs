using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    internal class Program
    {
        static int count = 0;
        static void Main(string[] args)
        {
           
            TOH(50, "A", "C", "B");
            Console.ReadLine();
        }
        static void TOH(int n, string source, string destination, string helper)
        {
            
            if (n == 0)
            {
                return;
            }
            TOH(n - 1, source, helper, destination);
            Console.WriteLine($"Step {++count} - Move {n} from {source} to {destination} ");
            TOH(n - 1, helper, destination, source);

        }
    }
}
