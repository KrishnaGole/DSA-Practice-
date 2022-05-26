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
    public class RandomListNode
    {
        public int label;
        public RandomListNode next, random;
        public RandomListNode(int x) { this.label = x; }
    };

    internal class Program
    {
        public static ListNode head;
        //public static RandomListNode random;
        static void Main(string[] args)
        {
            ListNode listNode = new ListNode(9)
            {
                next = new ListNode(9)
            };
            listNode.next.next = new ListNode(1);
            //listNode.next.next.next = new ListNode(4);
            //listNode.next.next.next.next = new ListNode(5);
            //listNode.next.next.next.next.next = new ListNode(6);
            //listNode.next.next.next.next.next.next = new ListNode(7);
            //listNode.next.next.next.next.next.next.next = new ListNode(8);
            //listNode.next.next.next.next.next.next.next.next= new ListNode(9);
            //listNode.next.next.next.next.next.next.next.next.next = new ListNode(10);
            //RandomListNode randomListNode = new RandomListNode(1);
            //randomListNode.next = new RandomListNode(2);
            //randomListNode.next.next = new RandomListNode(3);
            //randomListNode.random = randomListNode.next.next;
            //randomListNode.next.random = randomListNode;
            //randomListNode.next.next.random = randomListNode;

            ListNode listnode1 = new ListNode(1)
            {
                //next = new ListNode(1)
            };
            //listnode1.next.next = new ListNode(4);
            //listNode.next.next.next = new ListNode(4);
            //listNode.next.next.next.next = new ListNode(5);
            //listNode.next.next.next.next.next = new ListNode(2);
            // listNode.next.next.next.next.next = listNode.next.next;

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
            //DeleteDuplicates(listNode);
            //RemoveNthFromEnd(listNode, 1);
            //MergeTwoLists(listNode, listNode1);
            //var listnode = SortList(listNode);
            //CopyRandomList(randomListNode);
            //LRUCache solution = new LRUCache(2);
            //solution.Set(2, 1);
            //solution.Set(1, 1);
            //solution.Get(1);
            //solution.Set(2, 3);
            //solution.Set(4, 1);
            //solution.Get(1);
            //solution.Get(2);
            //SwapPairs(listNode);
            AddTwoNumbers(listNode, listnode1);
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
            if (A == null)
            {
                return A;
            }
            ListNode next;
            ListNode prevNode;
            int prev = A.val;
            next = A.next;
            prevNode = A;
            while (next != null)
            {
                if (next.val == prev)
                {
                    prevNode.next = next.next;
                }
                else
                {
                    prevNode = next;
                    prev = next.val;
                }
                next = next.next;
            }
            return A;
        }

        /// <summary>
        /// Remove Nth Node from List End
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static ListNode RemoveNthFromEnd(ListNode A, int B)
        {
            int size = 0;
            ListNode temp = A;
            while (temp != null)
            {
                size++;
                temp = temp.next;
            }
            if (B >= size)
            {
                A = A.next;
                return A;
            }
            size = Math.Abs(size - B);
            temp = A;
            while (size > 1)
            {
                temp = temp.next;
                size--;
            }
            temp.next = temp.next.next;
            return A;
        }

        /// <summary>
        /// Merge Two Sorted Lists
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static ListNode MergeTwoLists(ListNode A, ListNode B)
        {
            List<int> nodes = new List<int>();
            ListNode temp1 = A, temp2 = B;
            while(temp1 != null && temp2 != null)
            {
                if(temp1.val < temp2.val)
                {
                    nodes.Add(temp1.val);
                    temp1 = temp1.next;
                }
                else
                {
                    nodes.Add(temp2.val);
                    temp2 = temp2.next;
                }
            }
            while(temp1 != null)
            {
                nodes.Add(temp1.val);
                temp1 = temp1.next;
            }
            while (temp2 != null)
            {
                nodes.Add(temp2.val);
                temp2 = temp2.next;
            }
            ListNode temp = new ListNode(nodes[0]), ans = temp;
            int size = nodes.Count();
            for(int i = 1; i < size; i++)
            {
                temp.next = new ListNode(nodes[i]);
                temp = temp.next;
               
            }
            return ans;

        }

        public static ListNode SortList(ListNode A)
        {
            if (A == null || A.next == null)
            {
                return A;
            }
            ListNode h1 = A;
            ListNode node = GetMiddle(A);
            ListNode h2 = node.next;
            node.next = null;
            h1 = SortList(h1);
            h2 = SortList(h2);
            return Merge(h1, h2);
        }

        public static ListNode Merge(ListNode h1, ListNode h2)
        {
            ListNode node = new ListNode(0);
            ListNode head = node;
            while (h1 != null && h2 != null)
            {
                if (h1.val < h2.val)
                {
                    node.next = h1;
                    h1 = h1.next;
                }
                else
                {
                    node.next = h2;
                    h2 = h2.next;
                }
                node = node.next;
            }
            if (h1 != null)
            {
                node.next = h1;
            }
            else
            {
                node.next = h2;
            }
            return head.next;
        }

        public static ListNode GetMiddle(ListNode head)
        {
            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }

        /// <summary>
        /// Copy List
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static RandomListNode CopyRandomList(RandomListNode head)
        {
            RandomListNode current = head, temp = null;
            while(current != null)
            {
                temp = current.next;
                current.next = new RandomListNode(current.label);
                current.next.next = temp;
                current = temp;
            }
            current = head;
            while (current != null)
            {
                current.next.random = current.random.next;
                current = current.next.next;
            }
            RandomListNode newHead = head.next;
            current = newHead;
            while (current.next != null)
            {
                current.next = current.next.next;
                current = current.next;
            }


            return head;
            
            

        }

        /// <summary>
        /// Copy List
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static RandomListNode CopyRandomList1(RandomListNode head)
        {

            Dictionary<RandomListNode, RandomListNode> map = new Dictionary<RandomListNode, RandomListNode>();
            RandomListNode node = head.next;
            RandomListNode deepCopy = new RandomListNode(head.label);
            map.Add(head, deepCopy);
            RandomListNode deepCopyHead = deepCopy;
            while (node != null)
            {
                deepCopy.next = new RandomListNode(node.label);
                map.Add(node, deepCopy.next);
                node = node.next;
                deepCopy = deepCopy.next;
            }
            deepCopy = deepCopyHead;
            while (head != null)
            {
                if (head.random != null)
                    deepCopy.random = map[head.random];
                deepCopy = deepCopy.next;
                head = head.next;
            }
            return deepCopyHead.next;
        }

        /// <summary>
        /// Swap List Nodes in pairs
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static ListNode SwapPairs(ListNode A)
        {
            ListNode temp = A, reverse = null, temp1 = null, ans = null;
            int count = 0;
            while (temp != null)
            {
                count++;
                ListNode t = temp;
                temp = temp.next;
                t.next = reverse;
                reverse = t;
                if(count % 2 == 0)
                {
                    if(temp1 == null)
                    {
                        temp1 = reverse;
                        if (ans == null)
                        {
                            ans = temp1;
                        }
                        temp1 = temp1.next;
                    }
                    else
                    {
                        temp1.next = reverse;
                        temp1 = temp1.next.next;
                    }
                    reverse = null;
                }
            }
            if(reverse != null)
            {
                temp1.next = reverse;
            }
            return ans;
        }

        public static long Reverse(long num1)
        {
            long reverseNum1 = 0;
            while (num1 > 0)
            {
                reverseNum1 = reverseNum1 * 10 + (num1 % 10);
                num1 /= 10;
            }
            return reverseNum1;
        }

        /// <summary>
        ///  Add Two Numbers as Lists
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static ListNode AddTwoNumbers(ListNode A, ListNode B)
        {
            ListNode tempA = A, tempB = B, reverseA = null, reverseB = null, ans = new ListNode(0);
            int rem = -1, lastDigit = 0, countA = 0, countB = 0;
            while(tempA != null)
            {
                countA++;
                tempA = tempA.next;
            }
            while(tempB != null)
            {
                countB++;
                tempB = tempB.next;
            }
            tempA = A; tempB = B;
            while (tempA != null)
            {
                ListNode t = tempA;
                tempA = tempA.next;
                t.next = reverseA;
                reverseA = t;
            }
            while (tempB != null)
            {
                ListNode t = tempB;
                tempB = tempB.next;
                t.next = reverseB;
                reverseB = t;
            }
            if (countA != countB)
            {
                int diff = Math.Abs(countA - countB);
                if(countA > countB)
                {
                    while(diff > 0)
                    {
                        ListNode t = new ListNode(0);
                        t.next = reverseB;
                        reverseB = t;
                        diff--;
                    }
                   
                }
                else
                {
                    while (diff > 0)
                    {
                        ListNode t = new ListNode(0);
                        t.next = reverseA;
                        reverseA = t;
                        diff--;
                    }

                }
            }
            
           
            tempA = ans;
            while (reverseA != null && reverseB != null)
            {
                rem = (reverseA.val + reverseB.val) % 10;
                if(lastDigit > 0)
                {
                    int num = rem + lastDigit;
                    if(num == 10)
                    {
                        tempA.next = new ListNode(0);
                        tempA = tempA.next;
                        tempA.next = new ListNode(1);
                    }
                    else
                    {
                        tempA.next = new ListNode(num);
                    }
                }
                else
                {
                    tempA.next = new ListNode(rem);
                }
                lastDigit = (reverseA.val + reverseB.val) / 10;
                reverseA = reverseA.next;
                reverseB = reverseB.next;
                tempA = tempA.next;
               
            }
            return ans.next;
        }
    }

    class Solution
    {
        public int cap = 0;
        public Dictionary<int, ListNode> map = new Dictionary<int, ListNode>();
        ListNode head = null, tail = null;
        ListNode newNode = null;
        public Solution(int capacity)
        {
            cap = capacity;
            head = null;
            tail = null;
        }

        public int Get(int key)
        {
            if (map.ContainsKey(key))
            {
                ListNode node = map[key];
                return node.val;
            }
            else
            {
                return -1;
            }
        }

        public void Set(int key, int value)
        {
            if (map.ContainsKey(key))
            {
                ListNode node = map[key];
                if (node.next != null)
                {
                    node = node.next;
                }
                else
                {
                    node.val = value;
                }
            }
            else
            {
                ListNode newNode = new ListNode(value);
                if (map.Count() == cap)
                {
                    map.Remove(newNode.val);
                    head = head.next;
                }
                if (head == null)
                {
                    head = tail = newNode;
                }
                else if (tail == null && head != null)
                {
                    tail = newNode;
                }
                else
                {
                    tail.next = newNode;

                }
                map.Add(key, newNode);
            }
        }

    }

    public class LRUCache
    {
        private int _capacity;
        private Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> _cache;
        private LinkedList<KeyValuePair<int, int>> _lru;
       

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _cache = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>();
            _lru = new LinkedList<KeyValuePair<int, int>>();
        }

        public int Get(int key)
        {
            if (!_cache.TryGetValue(key, out var node))
            {
                return -1;
            }
            else
            {
                _lru.Remove(node);
                _cache[key] = _lru.AddFirst(node.Value);
                return node.Value.Value;
            }
        }

        public void Set(int key, int value)
        {
           if(_cache.TryGetValue(key, out var node))
           {
                _lru.Remove(node);
                _cache.Remove(key);
           }
            node = _lru.AddFirst(new KeyValuePair<int, int>(key, value));
            _cache[key] = node;
            if(_lru.Count > _capacity)
            {
                node = _lru.Last;
                _lru.Remove(node);
                _cache.Remove(node.Value.Key);
            }
        }
    }

    public class LRUCache1
    {
        private readonly int _capacity;
        private readonly Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> _cache;
        private readonly LinkedList<KeyValuePair<int, int>> _lru;

        public LRUCache1(int capacity)
        {
            _capacity = capacity;
            _cache = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>();
            _lru = new LinkedList<KeyValuePair<int, int>>();
        }
        
        public int Get(int key)
        {
            if (!_cache.TryGetValue(key, out var node))
            {
                return -1;
            }

            _lru.Remove(node);
            _cache[key] = _lru.AddFirst(node.Value);

            return node.Value.Value;
        }

        public void Set(int key, int value)
        {
            if (_cache.TryGetValue(key, out var node))
            {
                _lru.Remove(node);
                _cache.Remove(key);
            }

            node = _lru.AddFirst(new KeyValuePair<int, int>(key, value));
            _cache[key] = node;

            if (_lru.Count > _capacity)
            {
                node = _lru.Last;
                _lru.RemoveLast();
                _cache.Remove(node.Value.Key);
            }
        }
    }
    
}

