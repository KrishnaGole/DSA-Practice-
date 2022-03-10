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
            BalancedParantheses1("{([])}");
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
