using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //["MyLinkedList","addAtHead","addAtHead","addAtHead","addAtIndex","deleteAtIndex","addAtHead","addAtTail","get","addAtHead","addAtIndex","addAtHead"]
            //[[],[7],[2],[1],[3,0],[2],[6],[4],[4],[4],[5,0],[6]]
            MyLinkedList myLinkedList = new MyLinkedList();
            myLinkedList.AddAtHead(7);
            myLinkedList.AddAtHead(2);
            myLinkedList.AddAtHead(1);
            myLinkedList.AddAtIndex(3, 0);
            myLinkedList.DeleteAtIndex(2);
            myLinkedList.AddAtHead(6);
            myLinkedList.AddAtTail(4);
            myLinkedList.Get(4);
            myLinkedList.AddAtIndex(5, 0);
            myLinkedList.AddAtHead(6);

        }
    }

    public class MyLinkedList
    {
        int size;
        ListNode head;
        ListNode temp;
        public MyLinkedList()
        {
            size = -1;
            head = null;
            temp = null;
        }

        public int Get(int index)
        {
            if (index > size)
            {
                return -1;
            }
            temp = head;
            while (index > 0 && temp.next != null)
            {
                temp = temp.next;
                index--;
            }
            return temp.val;

        }

        public void AddAtHead(int val)
        {
            size++;
            temp = new ListNode(val);
            temp.next = head;
            head = temp;

        }

        public void AddAtTail(int val)
        {
            size++;
            if (head == null)
            {
                head = new ListNode(val);
                return;
            }
            temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = new ListNode(val);
        }

        public void AddAtIndex(int index, int val)
        {
            if (index > size + 1)
            {
                return;
            }
            size++;
            if (index == 0 && size == 0)
            {
                head = new ListNode(val);
            }
            else if (index == 0 && size > 0)
            {
                temp = new ListNode(val);
                temp.next = head;
                head = temp;
            }
            else
            {
                temp = head;
                while (index > 1 && temp.next != null)
                {
                    temp = temp.next;
                    index--;
                }
                ListNode nextNode = temp.next;
                temp.next = new ListNode(val);

                if (temp.next != null)
                {
                    temp = temp.next;
                    temp.next = nextNode;
                }
            }

        }

        public void DeleteAtIndex(int index)
        {
            if (index > size)
            {
                return;
            }
            size--;
            if (index == 0)
            {
                head = head.next;
            }
            else
            {
                temp = head;
                while (index > 1 && temp.next != null)
                {
                    temp = temp.next;
                    index--;
                }
                temp.next = temp.next?.next;
            }

        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val)
        {
            this.val = val;
            next = null;
        }
    }
}
