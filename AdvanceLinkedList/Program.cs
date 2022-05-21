using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceLinkedList
{
    class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { this.val = x; this.next = null; }
    }

    internal class Program
    {
        public static ListNode head;
        static void Main(string[] args)
        {
            ListNode listNode = new ListNode(1)
            {
               // next = new ListNode(1)
            };
            //listNode.next.next = new ListNode(1);
            //listNode.next.next.next = new ListNode(2);
            //listNode.next.next.next.next = new ListNode(2);
            //listNode.next.next.next.next.next = new ListNode(2);
            //listNode.next.next.next.next.next = listNode.next.next;

            //listNode.next.next.next.next = new ListNode(5);
            //listNode.next.next.next.next.next = new ListNode(6);
            ////Insert_node(1, 1);
            ////Insert_node(2, 2);
            //Insert_node(3, 3);
            //Print_ll();
            //Insert_node(2, 4);
            //Print_ll();
            //Delete_node(2);
            //ReverseList(listNode, 3);
            //ReverseBetween(listNode, 2, 4);
            //DetectCycle(listNode);
            //Solve2(listNode);
            //ReorderList1(listNode);
            DeleteDuplicates(listNode);
            Console.ReadLine();

            //ReverseList(listNode);
        }
        public static int Solve(ListNode A)
        {
            //int size = Size(A);
            //int mid = size / 2;
            //ListNode temp = A;
            //while (mid > 0)
            //{
            //    temp = temp.next;
            //    mid--;
            //}
            //return temp.val;
            return 1;
        }

        public static int size = 0;
        public static ListNode ReverseList(ListNode A)
        {
            //int s = Size(A);
            ListNode temp = A;
            ListNode reverse = null;
            //reverse = new ListNode(temp.val);
            //temp = temp.next;
            while (temp != null)
            {
                var t = temp;
                temp = temp.next;
                t.next = reverse;
                reverse = t;


            }
            return reverse;
        }

        public static void Insert_node(int position, int value)
        {
            // @params position, integer
            // @params value, integer
            if(position > size + 1)
            {
                return;
            }
            ListNode node = new ListNode(value);
            ListNode temp = null;

            if(position == 1)
            {
                node.next = head;
                head = node;
            }
            else
            {
                temp = head;
                while(position > 2)
                {
                    temp = temp.next;
                    position--;
                }
                node.next = temp.next;
                temp.next = node;
            }
            size++;
           

        }

        public static void Print_ll()
        {
            // Output each element followed by a space
            ListNode temp = head;
            while(temp!= null)
            {
                if(temp.next != null)
                {
                    Console.Write(temp.val + " ");
                }
                else
                {
                    Console.Write(temp.val);
                }
                temp = temp.next;
            }

        }
        public static void Delete_node(int position)
        {
            // @params position, integer
            if(position > size)
            {
                return;
            }
            if(position == 1)
            {
                head = head.next;
            }
            else
            {
                ListNode temp = head;
                while(position > 2)
                {
                    temp = temp.next;
                    position--;
                }
                temp.next = temp.next.next;
            }
            size--;
        }

        public static ListNode ReverseList(ListNode A, int B)
        {
            ListNode temp = A;
            ListNode reverse = null;
            ListNode ans = null;
            int count = 1;
            while (temp != null)
            {
                ListNode t = temp;
                temp = temp.next;
                t.next = reverse;
                reverse = t;
                if(count % B == 0)
                {
                    if(ans == null)
                    {
                        ans = reverse;
                    }
                    else
                    {
                        ListNode list = ans;
                        while(list.next != null)
                        {
                            list = list.next;
                        }
                        list.next = reverse;
                    }
                    reverse = null;
                }
                count++;
            }
            return ans;
        }

        public static ListNode ReverseBetween(ListNode A, int B, int C)
        {
            ListNode current = A;
            ListNode first = null, from = null, to = null, last = null;
            int count = 0;
            while(current != null)
            {
                count++;
                if(count < B)
                {
                    first = current;
                }
                if(count == B)
                {
                    from = current;
                }
                if(count == C)
                {
                    to = current;
                    last = to.next;
                    break;
                }
                current = current.next;
            }
            to.next = null;
            Reverse(from);
            if(first != null)
            {
                first.next = to;
            }
            else
            {
                A = to;
            }
            from.next = last;
            return A;
        }

        public static void Reverse(ListNode listNode)
        {
            ListNode temp = listNode;
            ListNode reverse = null;
            while(temp != null)
            {
                ListNode t = temp;
                temp = temp.next;
                t.next = reverse;
                reverse = t;
            }
            listNode = reverse;
        }

        /// <summary>
        ///  List Cycle
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static ListNode DetectCycle(ListNode a)
        {
            ListNode slow = a;
            ListNode fast = a;
            ListNode h = a;
            bool isCycle = false;
            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    isCycle = true;
                    break;
                }
            }
            if (!isCycle)
            {
                return null;
            }
            while (true)
            {
                if (slow == h)
                {
                    return slow;
                }
                slow = slow.next;
                h = h.next;
            }
            return null;


        }

        /// <summary>
        /// Remove Loop from Linked List
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static ListNode Solve2(ListNode A)
        {
            ListNode slow = A, fast = A, start = A, temp = null;
            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                temp = fast.next.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    break;
                }
            }
            temp.next = null;
            //start = A;
            //while (slow != null && start != null)
            //{
            //    slow = slow.next;
            //    start = start.next;
            //    if (slow == start)
            //    {
            //        slow.next = null;
            //    }
               
            //}
            return A;
        }

        /// <summary>
        /// Reorder List
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static ListNode ReorderList(ListNode A)
        {
            ListNode slow = A, fast = A;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            fast = slow.next;
            slow.next = null;
            ListNode temp = fast, reverse = null;
            while(temp != null)
            {
                ListNode t = temp;
                temp = temp.next;
                t.next = reverse;
                reverse = t;
            }
            ListNode p1 = A, p2 = reverse;
            while(p1 != null && p2 != null)
            {
                ListNode temp1 = p1.next;
                ListNode temp2 = p2.next;
                p1.next = p2;
                p2.next = temp1;
                p1 = temp1;
                p2 = temp2;
            }
            
            return A;

        }

        public static ListNode ReorderList1(ListNode A)
        {
            List<int> nodes = new List<int>();
            ListNode temp = A;
            while(temp != null)
            {
                nodes.Add(temp.val);
                temp = temp.next;
            }
            int n = nodes.Count();
            if(n <= 2)
            {
                return A;
            }
            ListNode ans = new ListNode(nodes[0]);
            temp = ans;
            for(int i = 1; i <= n/2; i++)
            {
                temp.next = new ListNode(nodes[n - i]);
                temp = temp.next;
                if(i != (n - i))
                {
                    temp.next = new ListNode(nodes[i]);
                    temp = temp.next;
                }
            }
            return ans;

        }

        /// <summary>
        /// Remove Duplicates from Sorted List
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static ListNode DeleteDuplicates(ListNode A)
        {
            List<int> nodes = new List<int>();
            ListNode temp = A;
            while(temp != null)
            {
                nodes.Add(temp.val);
                temp = temp.next;
            }
            nodes = nodes.Distinct().ToList();
            int n = nodes.Count();
            temp = A;
            for(int i = 0; i < n; i++)
            {
                temp.val = nodes[i];
                if(i == n - 1)
                {
                    temp.next = null;
                }
                else
                {
                    temp = temp.next;
                }
            }
            return A;
        }
    }
}

