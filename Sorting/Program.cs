using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> vs = new List<int>() {1,2,9,4,5,6 };
            //BubbleSort(vs);
            //Count(new List<int>() { 2, 1, 4, 3, 2 });
            kthsmallest(new List<int>() { 8, 16, 80, 55, 32, 8, 38, 40, 65, 18, 15, 45, 50, 38, 54, 52, 23, 74, 81, 42, 28, 16, 66, 35, 91, 36, 44, 9, 85, 58, 59, 49, 75, 20, 87, 60, 17, 11, 39, 62, 20, 17, 46, 26, 81, 92 }, 9);
           // Console.WriteLine(checkSorted(vs));
            Console.ReadLine();
        }

        static bool checkSorted(List<int> vs)
        {
            for(int i = 0; i < vs.Count() - 2; i++)
            {
                if(vs[i] > vs[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        //static bool recursiveCheckSorted(List<int> vs)
        //{
        //    //int i = 0;
           
        //    //if(i > vs.Count() - 2 && vs[i] > vs[i+1])
        //    //{
        //    //    return false;
        //    //}
        //    //return recursiveCheckSorted(, secondElement)
        //}

        static void BubbleSort(List<int> vs)
        {
            int count = 0;
            for (int i = 1; i < vs.Count(); i++)
            {
                count = 0;
                for(int j = 0; j <= vs.Count() - 1 - i; j++)
                {
                    if(vs[j] > vs[j + 1])
                    {
                        count++;
                        Swap(vs, j, j+1);
                    }
                }
                if(count == 0)
                {
                    break;
                }
            }
        }


        static void Swap(List<int> vs, int i, int j)
        {
            int temp = vs[i];
            vs[i] = vs[j];
            vs[j] = temp;
        }

        public static int Count(List<int> A)
        {
            int count = 0;
            for (int i = 1; i <= A.Count() - 1; i++)
            {
                for (int j = 0; j <= A.Count() - 1 - i; j++)
                {
                    if (A[j] > A[j + 1])
                    {
                        int temp = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = temp;
                        count++;
                    }
                }
            }
            return count;
        }

        public static int kthsmallest(List<int> A, int B)
        {
            int count = 0;
            for (int i = 1; i <= A.Count(); i++)
            {
                count = 0;
                for (int j = 0; j <= A.Count() - 1 - 1; j++)
                {
                    if (A[j] > A[j + 1])
                    {
                        count++;
                        int temp = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = temp;
                    }
                }
                if (count == 0)
                {
                    break;
                }
            }

            int start = 0;
            int end = A.Count();
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (A[mid] == B)
                {
                    return A[mid];
                }
                else if (A[mid] > B)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return -1;
        }

    }
}
