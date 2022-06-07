using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Nito.Collections;

namespace AdvanceQueues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Solve(9);
            //Solve1(12);
            //Solve(new List<int>() { 43, 35, 25, 5, 34, 5, 8, 7 }, 6);
            //Solve2(new List<int>() { 2, 3, 1, 5, 4 }, new List<int>() { 1, 3, 5, 4, 2 });
            //Solve("gu");
            SlidingMaximum(new List<int>() { 648, 614, 490, 138, 657, 544, 745, 582, 738, 229, 775, 665, 876, 448, 4, 81, 807, 578, 712, 951, 867, 328, 308, 440, 542, 178, 637, 446, 882, 760, 354, 523, 935, 277, 158, 698, 536, 165, 892, 327, 574, 516, 36, 705, 900, 482, 558, 937, 207, 368 }, 9);
           
        }

        /// <summary>
        /// N integers containing only 1, 2 & 3
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<int> Solve(int A)
        {
            Queue<int> queue = new Queue<int>();
            List<int> ans = new List<int>();
            if (A > 0)
            {
                queue.Enqueue(1);
            }
            if (A > 1)
            {
                queue.Enqueue(2);
            }
            if (A > 2)
            {
                queue.Enqueue(3);
            }
            int count = 3;
            while (count < A)
            {
                int temp = queue.Dequeue();
                ans.Add(temp);
                if (count < A)
                {
                    queue.Enqueue(temp * 10 + 1);
                    count++;
                }
                if (count < A)
                {
                    queue.Enqueue(temp * 10 + 2);
                    count++;
                }
                if (count < A)
                {
                    queue.Enqueue(temp * 10 + 2);
                    count++;
                }
            }
            while (queue.Count() > 0)
            {
                ans.Add(queue.Dequeue());
                
            }
            return ans;
        }

        /// <summary>
        /// Perfect Numbers
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static string Solve1(int A)
        {
            Queue<string> queue = new Queue<string>();
            if (A > 0)
            {
                queue.Enqueue("11");
            }
            if (A > 1)
            {
                queue.Enqueue("22");
            }
          
            int cnt = 2;
            string prevElement = queue.Peek();
            while (cnt < A)
            {
                string temp = queue.Dequeue();
                
                int n = temp.Length;
                queue.Enqueue(temp.Substring(0, n / 2) + prevElement + temp.Substring(n / 2, n / 2));
                cnt++;
                if (cnt < A)
                {
                    queue.Enqueue(temp.Substring(0, n / 2) + temp + temp.Substring(n / 2, n / 2));
                    cnt++;
                }
                //queue.Enqueue(temp);
                prevElement = temp;

            }
            return queue.Last();
        }

        /// <summary>
        /// Reversing Elements Of Queue
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static List<int> Solve(List<int> A, int B)
        {
            Queue<int> q = new Queue<int>();
            int i = 0;
            // Insert first B elements in queue
            for (i = 0; i < B; i++)
            {
                q.Enqueue(A[i]);
            }
               
            // Reverse the first B elements in the array A
            while (q.Count > 0)
            {
                i--;
                A[i] = q.Dequeue();
            }
            return A;

        }

        /// <summary>
        ///  Task Scheduling
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int Solve2(List<int> A, List<int> B)
        {
            int n = A.Count(), m = B.Count(), ans = 0;
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(A[i]);
            }
            for (int i = 0; i < m; i++)
            {
                while (B[i] != queue.Peek())
                {
                    queue.Enqueue(queue.Dequeue());
                    ans++;
                }
                queue.Dequeue();
                ans++;
            }
            return ans;
        }

        public static string Solve(string A)
        {
            int n = A.Length;
            Queue<char> queue = new Queue<char>();
            StringBuilder ans = new StringBuilder();
            int[] freqArray = new int[26];
            for (int i = 0; i < n; i++)
            {
                freqArray[A[i] - 'a']++;
                if (freqArray[A[i] - 'a'] == 1)
                {
                    queue.Enqueue(A[i]);
                }
                while (queue.Count() > 0 && freqArray[queue.Peek() - 'a'] > 1)
                {
                    queue.Dequeue();
                }
                if (queue.Count() > 0)
                {
                    ans.Append(queue.Peek());
                }
                else
                {
                    ans.Append("#");
                }
            }
            return ans.ToString();
        }

        /// <summary>
        ///  Sliding Window Maximum
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static List<int> SlidingMaximum(List<int> A, int B)
        {
            int n = A.Count();
            Deque<int> deque = new Deque<int>();
            List<int> ans = new List<int>();
            for (int i = 0; i < B; i++)
            {
                while (deque.Count() > 0 && A[deque.Last()] < A[i])
                {
                    deque.RemoveFromBack();
                }
                deque.AddToBack(i);
            }
            ans.Add(A[deque.First()]);
            int start = 0;
            for (int i = B; i < n; i++)
            {
                while (deque.Count() > 0 && A[deque.Last()] < A[i])
                {
                    deque.RemoveFromBack();
                }
                deque.AddToBack(i);
                while (start >= deque.First())
                {
                    deque.RemoveFromFront();
                }
                start++;
               
                ans.Add(A[deque.First()]);

            }
            return ans;
        }
    }
}
