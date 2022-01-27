using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> A = new List<int>() { 1, 2, 3, 4, 5 };
            //List<int> B = new List<int>() { 2, 3 };
            //solve(A, B);
            //List<int> A = new List<int>() { 2,5,1,4,8,0,1,3, 8, 8};
            //Console.WriteLine(solve1(A));
            //List<int> vs = new List<int>() { 2, 1, 6, 4 };
            //Console.WriteLine(solve2(vs));
            //List<int> vs = new List<int>() { 1, 2, 3, 4, 5 };
            //var result = SuffixArray(vs);
            //foreach (var item in result)
            //{
            //    Console.Write(item + " ");
            //}
            //PickFromBothSide(new List<int>() { -533, -666, -500, 169, 724, 478, 358, -38, -536, 705, -855, 281, -173, 961, -509, -5, 942, -173, 436, -609, -396, 902, -847, -708, -618, 421, -284, 718, 895, 447, 726, -229, 538, 869, 912, 667, -701, 35, 894, -297, 811, 322, -667, 673, -336, 141, 711, -747, -132, 547, 644, -338, -243, -963, -141, -277, 741, 529, -222, -684, 35 }, 48);
            ClosestMinMax(new List<int>() { 814, 761, 697, 483, 981 });
            Console.ReadLine();
           

        }

        public static List<List<int>> solve(List<int> A, List<int> B)
        {
            List<List<int>> vs = new List<List<int>>();
            for (int i = 0; i < B.Count; i++)
            {
                List<int> vs1 = new List<int>();
                for(int j = 0; j < A.Count; j++)
                {
                    vs1.Add(A[(j + B[i]) % A.Count]);
                    
                }
                vs.Add(vs1);
                //B[i] = B[i] % A.Count;
                //List<int> arr = new List<int>();
                //arr = A.Select(x => x).ToList();
                //reverse(arr, 0, arr.Count - 1);
                //reverse(arr, 0, arr.Count - B[i] - 1);
                //reverse(arr, arr.Count - B[i], arr.Count - 1);
                //vs.Add(arr);
            }
            return vs;

        }
        public static void reverse(List<int> vs, int start, int end)
        {
            while (start <= end)
            {
                int temp = vs[start];
                vs[start] = vs[end];
                vs[end] = temp;
                start++;
                end--;
            }

        }

        static int solve1(List<int> vs)
        {
            int count = 0;
            int max = int.MinValue;
            for(int i = 0; i < vs.Count; i++)
            {
                if(vs[i] >= max)
                {
                    if(max == vs[i])
                    {
                        count++;
                    }
                    else
                    {
                        count = 1;
                    }
                    max = vs[i];    
                }
            }
            return vs.Count - count;
        }

        public static int solve2(List<int> A)
        {
            List<int> pfEven = new List<int>();
            List<int> pfOdd = new List<int>();
            pfEven.Add(A[0]);
            pfOdd.Add(0);
            int count = 0;
            for (int i = 1; i < A.Count; i++)
            {
                if (i % 2 == 0)
                {
                    pfEven.Add(pfEven[i - 1] + A[i]);
                }
                else
                {
                    pfEven.Add(pfEven[i - 1]);
                }
                if (i % 2 == 1)
                {
                    pfOdd.Add(pfOdd[i - 1] + A[i]);
                }
                else
                {
                    pfOdd.Add(pfOdd[i - 1]);
                }
            }
            for (int j = 0; j < A.Count; j++)
            {
                int evenLeftSum = 0, evenRightSum = 0, oddLeftSum = 0, oddRightSum = 0;
                if (j == 0)
                {
                    evenLeftSum = 0;
                    oddLeftSum = 0;
                }
                else
                {
                    evenLeftSum = pfEven[j - 1];
                    oddLeftSum = pfOdd[j - 1];
                }

                evenRightSum = pfEven[A.Count - 1] - pfEven[j];
                oddRightSum = pfOdd[A.Count - 1] - pfOdd[j];
                if ((evenLeftSum + oddRightSum) == (oddLeftSum + evenRightSum))
                {
                    count++;
                }
            }
            return count;
        }

        public static List<int> PrefixArray(List<int> vs)
        {
            List<int> prefixArr = new List<int>();
            prefixArr.Add(vs[0]);
            for(int i = 1; i < vs.Count; i++)
            {
                prefixArr.Add( prefixArr[i - 1] + vs[i]);
            }
            return prefixArr;
        }

        public static List<int> SuffixArray(List<int> vs)
        {
            int[] suffixArr = new int[vs.Count];
            suffixArr[vs.Count-1] = vs[vs.Count-1];
            for (int i = vs.Count - 2; i >= 0; i--)
            {
                suffixArr[i] = suffixArr[i + 1] + vs[i];
            }
            return suffixArr.ToList();
        }

        public static int PickFromBothSide(List<int> A, int B)
        {
            int n = A.Count;
            int[] prefixArr = new int[n];
            int[] suffixArr = new int[n];
            int max = 0;
            prefixArr[0] = A[0];
            suffixArr[n - 1] = A[n - 1];
            for (int i = 1; i < n; i++)
            {
                prefixArr[i] = prefixArr[i - 1] + A[i];
            }
            for (int j = n - 2; j >= 0; j--)
            {
                suffixArr[j] = suffixArr[j + 1] + A[j];
            }
            for (int i = 0; i < B-1 && B+i < n; i++)
            {
                if((prefixArr[i] + suffixArr[B+i]) > max)
                {
                    max = prefixArr[i] + suffixArr[B + i];
                }
            }
            if(suffixArr[B] > max)
            {
                max = suffixArr[B];
            }
            else if(prefixArr[B] > max){
                max = prefixArr[B];
            }
            return max;
        }

        public static int ClosestMinMax(List<int> A)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            int length = A.Count();
            int minIndex = -1, maxIndex = -1;
            for (int i = 0; i < length; i++)
            {
                min = Math.Min(min, A[i]);
                max = Math.Max(max, A[i]);
            }
            if (min == max)
            {
                return 1;
            }
            for (int i = 0; i < length; i++)
            {

                if (A[i] == min)
                {
                    minIndex = i;
                    if (maxIndex > -1)
                    {
                        length = Math.Min(length, (minIndex - maxIndex) + 1);
                    }
                }
                else if (A[i] == max)
                {
                    maxIndex = i;
                    if (minIndex > -1)
                    {
                        length = Math.Min(length, (minIndex - maxIndex) + 1);
                    }
                }
            }
            return length;
        }

    }
}
