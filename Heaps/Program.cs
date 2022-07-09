using DotNetty.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Heaps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solve(new List<int>() { 1,18 });
        }

        public static int Solve(List<int> A)
        {
            return 1;

        }

        public static void Insert(List<int> arr, int ele)
        {
            arr.Add(ele);
            int index = arr.Count() - 1;
            int parent = (index - 1) / 2;
            while (index != 0 && arr[parent] > arr[index])
            {
                arr[index] = arr[index] * arr[parent];
                arr[parent] = arr[index] / arr[parent];
                arr[index] = arr[index] / arr[parent];
                index = parent;
                parent = (index - 1) / 2;
            }
        }
    }
}
