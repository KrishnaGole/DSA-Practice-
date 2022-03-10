using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class ListNode
    {
      public int value;
      public ListNode next;
      public ListNode(int x) { this.value = x; this.next = null; }
    }
   
    internal class Program
    {
        public static ListNode Head = null;
        static void Main(string[] args)
        {
            // List<List<int>> vs = new List<List<int>>()
            // {
            //     new List<int>(){1, 13, -1},
            //     new List<int>(){3, 0, -1},
            //     new List<int>(){ 3, 1, -1 },
            //     new List<int>(){ 2, 15, 0 },
            //     new List<int>(){3, 0, -1},
            //     new List<int>(){ 1, 12, -1 },
            //     new List<int>(){3, 0, -1 },
            //     new List<int>(){ 1, 19, -1 },
            //     new List<int>(){ 1, 13, -1 },
            //     new List<int>(){3, 0, -1 },
            //     new List<int>(){ 0, 12, -1 },
            //     new List<int>(){1, 13, -1 },
            //     new List<int>(){ 3, 2, -1 }
            //     //new List<int>(){2, 6, 0},
            //     //new List<int>(){1, 17, -1},
            //     //new List<int>(){1, 19, -1},
            //     //new List<int>(){2, 16, 1},
            //     //new List<int>(){1, 13, -1},
            //     //new List<int>(){3, 3, -1},
            //     //new List<int>(){1, 19, -1},
            // };
            //Solve(vs);
            insert_node(1, 23);
            insert_node(2, 24);
            print_ll();
            delete_node(1);
            print_ll();


        }
        public static ListNode Solve(List<List<int>> A)
        {
            ListNode head = null;
            ListNode temp = null;

            for (int i = 0; i < A.Count(); i++)
            {
                if (A[i][0] == 0 && A[i][2] == -1)
                {
                    if (head == null)
                    {
                        head = new ListNode(A[i][1]);
                    }
                    else
                    {
                        ListNode node = new ListNode(A[i][1]);
                        node.next = head;
                        head = node;
                    }

                }
                else if (A[i][0] == 1 && A[i][2] == -1)
                {
                    ListNode node = new ListNode(A[i][1]);
                    if (head == null)
                    {
                        head = new ListNode(A[i][1]);
                    }
                    else
                    {
                        temp = head;
                        for (int j = 1; j < LinkedListSize(head); j++)
                        {
                            temp = temp.next;
                        }
                        temp.next = node;
                    }
                }
                else if (A[i][0] == 2 && A[i][2] <= LinkedListSize(head))
                {
                    ListNode node = new ListNode(A[i][1]);
                    if (A[i][2] == 0)
                    {
                        if (head == null)
                        {
                            head = node;
                        }
                        else
                        {
                            node.next = head;
                            head = node;
                        }
                    }
                    else if (A[i][2] == LinkedListSize(head))
                    {
                        if (head == null)
                        {
                            head = new ListNode(A[i][1]);
                        }
                        else
                        {
                            temp = head;
                            for (int j = 1; j < LinkedListSize(head); j++)
                            {
                                temp = temp.next;
                            }
                            temp.next = node;
                        }
                    }
                    else
                    {
                        ListNode index = head;

                        for (int j = 1; j < A[i][2]; j++)
                        {
                            index = index.next;
                        }
                        node.next = index.next;
                        index.next = node;
                    }

                }
                else if (A[i][0] == 3 && A[i][2] == -1 && head != null && A[i][1] < LinkedListSize(head))
                {
                    temp = head;
                    for (int j = 1; j < A[i][1]; j++)
                    {
                        temp = temp.next;
                    }
                    if (A[i][1] == 0 && LinkedListSize(head) > 1)
                    {
                        head = head.next;
                    }
                    else if(A[i][1] == 0 && LinkedListSize(head) == 1)
                    {
                        head = null;
                    }
                    else
                    {
                        temp.next = temp?.next?.next;
                    }
                }
            }
            return head;
        }
        public static int LinkedListSize(ListNode node)
        {
            if(node == null)
            {
                return 0;
            }
            int count = 0;
            ListNode temp = node;
            while (temp.next != null)
            {
                count++;
                temp = temp.next;
            }
            return ++count;
        }

        public static void insert_node(int position, int value)
        {
            // @params position, integer
            // @params value, integer
            ListNode node = new ListNode(value);
            ListNode temp = null;
            if (Head == null && position == 1)
            {
                Head = node;
            }
            else if(position > Count(Head) + 1)
            {
                return;
            }
            else if (position > 1)
            {
                temp = Head;
                for (int i = 2; i < position; i++)
                {
                    temp = temp.next;
                }
                temp.next = node;
                node.next = temp?.next?.next;
            }
            else
            {
                node.next = Head;
                Head = node;
            }

        }

        public static void delete_node(int position)
        {
            // @params position, integer
            ListNode temp = null;
            if (position > Count(Head) + 1)
            {
                return;
            }
            if (Count(Head) == 1 && position == 1)
            {
                Head = null;
            }
            else if (position == 1)
            {
                Head = Head.next;
            }
            else
            {
                temp = Head;
                for (int i = 0; i <= position; i++)
                {
                    temp = temp.next;
                }
                temp.next = temp?.next?.next;
            }
        }

        public static void print_ll()
        {
            // Output each element followed by a space
            ListNode temp = Head;
            while (temp != null)
            {
                if (temp.next != null)
                {
                    Console.Write(temp.value + " ");
                }
                else
                {
                    Console.Write(temp.value);
                }
                temp = temp.next;
            }
        }
        public static int Count(ListNode head)
        {
            if (head == null)
            {
                return 0;
            }
            int count = 0;
            ListNode temp = head;
            while (temp.next != null)
            {
                count++;
                temp = temp.next;
            }
            return ++count;
        }
    }
}
