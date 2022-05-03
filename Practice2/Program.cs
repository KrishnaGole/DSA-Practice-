using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    internal class Program
    {
        static int ans = 0;
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
            //ClosestMinMax(new List<int>() { 814, 761, 697, 483, 981 });
            //var ans = LargestNumber(new List<int>() { 3, 30, 34, 5, 9 });
            Fanstatic4(new List<int>() {  });
            //int[] arr = { 2, 2, 4, 5};

            //// Auxiliary space to store each path
            //List<int> path = new List<int>();

            //ans = 0;
            // PrintSubsequences(arr.ToList(), 0, new List<int>() { }, 3,7);
           // var result = Solve1(new List<int>() { 1,1,3,2,4,5,6});

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

        public static string  LargestNumber(List<int> A)
        {
            A.Sort((int a, int b) =>
            {
                string s1 = a.ToString() + b.ToString();
                string s2 = b.ToString() + a.ToString();
                return -s1.CompareTo(s2);
            });
            StringBuilder ans = new StringBuilder();
            bool flag = true;
            foreach (int a in A)
            {
                if(a != 0)
                {
                    flag = false;
                }
                ans.Append(a);
            }
            return ans.ToString();

        }

        public static int Fanstatic4(List<int> A)
        {
            int n = A.Count();
            List<int> temp = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if(A[i] % 4 != 0)
                {
                    temp.Add(A[i]);
                }
            }
            //if(temp.Count() % 2 != 0)
            //{
            //    return -1;
            //}
             if(temp.Sum() % 4 != 0)
            {
                return -1;
            }
            else
            {
                return temp.Sum() / 4;
            }
        }

        static void PrintSubsequences(List<int> arr, int index, List<int> path, int B, int C)
        {

            // Print the subsequence when reach
            // the leaf of recursion tree
            if (index == arr.Count())
            {

                // Condition to avoid printing
                // empty subsequence
                if (path.Count > 0)
                {
                    
                    int sum = path.Sum();
                    if(sum >= B && sum <= C)
                    {
                        for (int i = 0; i < path.Count(); i++)
                        {
                            if (PrimeNumber(path[i]))
                            {
                                ans++;
                                break;
                            }
                        }
                    }
                    
                }
            }

            else
            {

                // Subsequence without including
                // the element at current index
                PrintSubsequences(arr, index + 1, path, B, C);

                path.Add(arr[index]);

                // Subsequence including the element
                // at current index
                PrintSubsequences(arr, index + 1, path, B, C);

                // Backtrack to remove the recently
                // inserted element
                path.RemoveAt(path.Count - 1);
            }
            return;
        }

        public static bool PrimeNumber(int num)
        {
            bool isPrime = true;
            for(int i = 2; i * i <= num; i++)
            {
                if(num % i == 0)
                {
                    isPrime = false;
                }
            }
            return isPrime;
        }

        public static string Solve1(List<int> A)
        {
            List<int> temp = new List<int>(A);
            int count = 0;
            A.Sort();
            for(int i = 0; i < A.Count(); i++)
            {
                if(A[i] != temp[i])
                {
                    count++;
                }
            }
            return count == 3 ? "YES" : "NO";
        }

    }

    class MyComparer : IComparer<int>
    {
        public int Compare(int a, int b)
        {
            string s1 = a.ToString() + b.ToString();
            string s2 = b.ToString() + a.ToString();
            return -s1.CompareTo(s2);
        }
    }
    //class MyComparer : IComparer<string>
    //{
    //    public  int Compare(string x, string y)
    //    {
    //        int a = Convert.ToInt32(x+y);
    //        int b = Convert.ToInt32(y+x);
    //        return a  > b  ? -1 : 1;
    //    }
    //}
}
