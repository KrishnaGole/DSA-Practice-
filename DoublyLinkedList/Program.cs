using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node node = new Node(1);
            node.next = new Node(2);
            node.next.prev = node;
            node.next.next = new Node(3);
            node.next.next.prev = node.next;
            var result = ReverseDLL(node);
            //var res = ReverseDLL1(node);



        }

        public static Node ReverseDLL(Node head)
        {
            //Your code here
            Node reverse = null;
            while (head != null)
            {
                Node t = head;
                head = head.next;
                t.next = reverse;
                t.prev = head;
                reverse = t;
            }
            return reverse;
        }

        public static Node ReverseDLL1(Node head)
        {
            //Your code here
            while (head != null)
            {
                Node pre = head.next;
                head.next = head.prev;
                head.prev = pre;
                if (pre == null)
                {
                    return head;

                }
                head = pre;
            }
            return head;
        }
    }
    class Node
    {
        public int data;
        public Node next, prev;
        public Node(int data)
        {
            this.data = data;
            this.next = null;
            this.prev = null;
        }
    }
}
