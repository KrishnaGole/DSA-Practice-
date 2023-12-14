using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    internal class Program
    {
        Node head = null;
        Node temp = null;
        List<int> min = new List<int>();
        int minVal = 0;
        public void push(int x)
        {
            if (head == null)
            {
                head = new Node(x);
            }
            else
            {
                temp = new Node(x);
                temp.next = head;
                head = temp;
            }
            if (min.Count  == 0)
            {
                min.Add(x);
            }
            else if(x <= min[min.Count - 1])
            {
                min.Add(x);
            }

        }

        public void pop()
        {
            if (head != null)
            {
                if (min.Count != 0 && head.data == min[min.Count - 1])
                {
                    min.RemoveAt(min.Count - 1);
                }
                head = head.next;
            }
        }

        public int top()
        {
            if (head != null)
            {
                return head.data;
            }
            else
            {
                return -1;
            }
        }

        public int getMin()
        {
            if (head != null)
            {
                return min[min.Count - 1];
            }
            else
            {
                return -1;
            }

        }
        static void Main(string[] args)
        {
            //Program program = new Program();
            //program.push(1);
            //program.push(2);
            //program.push(-2);
            //program.push(-2);
            //program.push(2);
            //program.pop();
            //program.pop();
            //program.getMin();
            //BalancedParantheses(")))");
            //Test(new List<int>() { 2,8,8 });
            //BalancedParantheses1("{([])}");
            //LargestRectangleArea(new List<int>() { 2, 1, 5, 6, 2, 3 });
            MinSwapsToBringTogether(new List<int>() { 1, 12, 10, 3, 14, 10, 5 }, 8);
            Console.ReadLine();

        }

        static int BalancedParantheses(string A)
        {
            int length = A.Length;
            Stack<char> charStack = new Stack<char>();
            int count = 0;
            for(int i = 0; i < length; i++)
            {
                if(A[i] == '(')
                {
                    charStack.Push('(');
                    count++;
                }
                else if(charStack.Count() > 0)
                {
                    charStack.Pop();
                }
            }
            if(count > 0 && charStack.Count() == 0)
            {
                return 1;
            }
            return 0;
        }
        static int BalancedParantheses1(string A)
        {
            int length = A.Length;
            Stack<char> charStack = new Stack<char>();
            for (int i = 0; i < length; i++)
            {
                if (A[i] == '{')
                {
                    charStack.Push('}');
                }
                else if (A[i] == '(')
                {
                    charStack.Push(')');
                }
                else if (A[i] == '[')
                {
                    charStack.Push(']');
                }
                else if(charStack.Peek() != A[i])
                {
                    return 0;
                }
                else
                {
                    charStack.Pop();
                }
            }
            if (charStack.Count() == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static List<int> Test(List<int> vs)
        {
            int min = Int32.MaxValue;
            List<int> ans = new List<int>();
            for (int i = 0; i < vs.Count; i++)
            {
                min = Int32.MaxValue;
                for (int j = 0; j < vs.Count; j++)
                {
                    if((vs[i] & j) > 0){
                        min = Math.Min(min, (vs[i] & j));
                    }
                }
                ans.Add(min);
            }
            return ans;
        }

        public static int LargestRectangleArea(List<int> A)
        {
            int n = A.Count(); long ans = int.MinValue;
            List<int> smallerLeftList = new List<int>() { -1 };
            List<int> smallerRightList = new List<int>() { n };
            Stack<int> height = new Stack<int>();
            height.Push(0);
            for (int i = 1; i < n; i++)
            {
                while (height.Count() > 0 && A[i] <= A[height.Peek()])
                {
                    height.Pop();
                }
                if (height.Count() > 0)
                {
                    smallerLeftList.Add(height.Peek());
                }
                else
                {
                    smallerLeftList.Add(-1);
                }
                height.Push(i);
            }
            height.Clear();
            height.Push(n - 1);
            for (int i = n - 2; i >= 0; i--)
            {
                while (height.Count() > 0 && A[i] <= A[height.Peek()])
                {
                    height.Pop();
                }
                if (height.Count() > 0)
                {
                    smallerRightList.Add(height.Peek());
                }
                else
                {
                    smallerRightList.Add(n);
                }
                height.Push(i);
            }
            smallerRightList.Reverse();
            for (int i = 0; i < n; i++)
            {
                int h = A[i];
                int w = smallerRightList[i] - smallerLeftList[i] - 1;
                //Console.WriteLine(smallerRightList[i] + " " + smallerLeftList[i]);
                ans = Math.Max(ans, h * w);
            }
            return (int)ans;

        }

        static int MinSwapsToBringTogether(List<int> A, int B)
        {
            int n = A.Count;
            int count = 0;

            // Count the number of elements greater than B in the entire array
            for (int i = 0; i < n; i++)
            {
                if (A[i] > B)
                {
                    count++;
                }
            }

            int minSwaps = count; // Initialize the minimum swap count with the count of elements greater than B

            // Count the elements greater than B in the initial window
            for (int i = 0; i < count; i++)
            {
                if (A[i] > B)
                {
                    count--;
                }
            }

            // Slide the window and update the count of elements greater than B
            for (int i = 0, j = count; j < n; i++, j++)
            {
                if (A[i] > B)
                {
                    count--;
                }
                if (A[j] > B)
                {
                    count++;
                }
                minSwaps = Math.Min(minSwaps, count);
            }

            return minSwaps;
        }
    }
    public class Node
    {
        public int data;
        public Node next;
        public Node(int data)
        {
            this.data = data;
            next = null;
        }
    }
}
