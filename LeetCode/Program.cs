using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ListNode : Cat
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            ID = 23;
             this.val = val;
             this.next = next;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat();
            cat.MakeSound();
            //SumSubarrayMins(new int[] { 4, 7, 3, 8 });
            //Animal animal = new Animal();
            //animal.MakeSound();
            //ListNode listNode = new ListNode(1);
            //listNode.next = new ListNode(1);
            //listNode.next.next = new ListNode(2);
            //listNode.next.next.next = new ListNode(1);
            ////IsPalindrome(listNode);
            ////Search(new int[] { -1, 0, 3, 5, 9, 12 }, 13);
            ////SuccessfulPairs(new int[] { 5, 1, 3 }, new int[] { 1, 2, 3, 4, 5 }, 7);
            //PartitionString("abacaba");

            //MoveZeroes(new int[] { 0, 1, 0, 3, 12 });
            //IsPowerOfThree(9);

            //LargestRectangleArea(new int[] { 2, 1, 5, 6, 2, 3 });
            //OrderedStream orderedStream = new OrderedStream(5);
            //orderedStream.Insert(3, "ccccc");
            //orderedStream.Insert(1, "aaaaa");
            //orderedStream.Insert(2, "bbbbb");
            //orderedStream.Insert(5, "eeeee");
            //orderedStream.Insert(4, "ddddd");
            //RemoveDupplicates(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 });
            //PlusOne(new List<int>() { 1,9,9,9,9,9,9 });
            //Sqrt(2);
            //Merge(new int[] { 4, 5, 6, 0, 0, 0 },3, new int[] { 1, 2, 3 }, 3);
            //Generate(5);
            //MaxProfit(new List<int>() { 3, 2, 5, 8, 1, 9 });
            //IsPalindrome("0P");
            //MajorityElement(new int[] { 2, 2, 1, 1, 1, 2, 2 });
            //TitleToNumber("AB");
            //FizzBuzz(15);
            
            



            
        }
        public int Solve123(string A, string B)
        {
            var expA = GetExp(A);
            var expB = GetExp(B);
            return Enumerable.SequenceEqual(expA, expB) ? 1 : 0;
        }
        static  int[]  GetExp(string A)
        {
            var ans = new int[26];
            var signStack = new Stack<int>();
            int currSign = 1;
            for (int i = 0; i < A.Length; ++i)
            {
                if (A[i] == '(')
                {
                    signStack.Push(currSign);
                    currSign = 1;
                }
                else if (A[i] == ')')
                {
                    signStack.Pop();
                }
                else if (A[i] == '+')
                {
                    currSign = 1;
                }
                else if (A[i] == '-')
                {
                    currSign = -1;
                }
                else
                {
                    ans[A[i] - 'a'] += currSign * signStack.Sum();
                }
            }
            return ans;
        }

        public static int LargestRectangleArea(int[] heights)
        {
            int area = 0;
            int min = 0;
            for (int i = 0; i < heights.Count(); i++)
            {
                area = Math.Max(area, heights[i]);
                min = heights[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    min = Math.Min(min, heights[j]);
                    area = Math.Max(area, (min * ((i - j) + 1)));
                }
            }
            return area;
        }

        public static int TitleToNumber(string columnTitle)
        {
            int result = 0, n = columnTitle.Length;
            return TitleToNumber(columnTitle, 0, result);
        }

        public static int TitleToNumber(string columnTitle, int index, int result)
        {
            if (index == columnTitle.Length)
            {
                return result;
            }
            result = result * 26 + (columnTitle[index] - 'A' + 1);
            index++;
            TitleToNumber(columnTitle, index, result);
            return result;
        }

        public static int RemoveDupplicates(int[] nums)
        {
            int insertIndex = 1;
            for(int i = 1; i < nums.Length; i++)
            {
                if (nums[i-1] != nums[i])
                {
                    nums[insertIndex] = nums[i];
                    insertIndex++;
                }
            }
            return insertIndex;
        }

        public static List<int> PlusOne(List<int> A)
        {
            int carry = 1;
            for (int i = A.Count() - 1; i >= 0; i--)
            {
                if (A[i] < 9)
                {
                    A[i]++;
                    carry = 0;
                    break;
                }
                else
                {
                    carry = 1;
                    A[i] = 0;
                }
            }
            if (carry == 1)
            {
                A[0] = 1;
                A.Add(0);
                return A;
            }
            List<int> res = new List<int>();
            for (int i = 0; i < A.Count(); i++)
            {
                if (A[i] == 0 && res.Count() == 0)
                {
                    continue;
                }
                res.Add(A[i]);
            }
            return res;

        }

        public static int Sqrt(int A)
        {
            long num = 1;
            while(num * num <= A)
            {
                num++;
            }
            return (int)num;
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1, j = n - 1, k = nums1.Length - 1;
            while(j >= 0)
            {
                if(i >= 0 && nums1[i] > nums2[j])
                {
                    nums1[k] = nums1[i];
                    i--;
                    k--;
                }
                else
                {
                    nums1[k] = nums2[j];
                    k--;
                    j--;
                }
            }
        }

        /// <summary>
        /// Pascal Triangle
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public static IList<IList<int>> Generate(int numRows)
        {
            List<IList<int>> pascalTriangle = new List<IList<int>>();
            pascalTriangle.Add(new List<int>() { 1 });
            pascalTriangle.Add(new List<int>() { 1, 1 });
            for (int i = 2; i < numRows; i++)
            {
                List<int> temp = new List<int>();
                temp.Add(1);
                for (int j = 1; j < i; j++)
                {
                    temp.Add(pascalTriangle[i - 1][j - 1] + pascalTriangle[i - 1][j]);
                }
                temp.Add(1);
                pascalTriangle.Add(temp);
            }
            return pascalTriangle;

        }

        public static int MaxProfit(List<int> prices)
        {
            int i = 0, buy, sell, profit = 0, n = prices.Count() - 1;
            while (i < n)
            {
                while (i < n && prices[i+1] <= prices[i])
                {
                    i++;
                }
                buy = prices[i];

                while(i < n && prices[i+1] > prices[i])
                {
                    i++;
                }
                sell = prices[i];

                profit += sell - buy;
            }

            return profit;

            return profit;

        }

        public static int Solve(string A, string B)
        {
            int n = A.Length, m = B.Length, ans = 0, p1 = 0, p2 = n;
            Dictionary<char, int> mapA = new Dictionary<char, int>();
            Dictionary<char, int> mapB = new Dictionary<char, int>();

            for (int i = 0; i < n; i++)
            {
                if (mapA.ContainsKey(A[i]))
                {
                    mapA[A[i]]++;
                }
                else
                {
                    mapA.Add(A[i], 1);
                }

                if (mapB.ContainsKey(B[i]))
                {
                    mapB[B[i]]++;
                }
                else
                {
                    mapB.Add(B[i], 1);
                }

            }

            while (p2 < m)
            {
                if (mapA.Count() == mapB.Count() && CompareHashMaps(mapA, mapB))
                {
                    ans++;
                }
                if (mapB.ContainsKey(B[p2]))
                {
                    mapB[B[p2]]++;
                }
                else
                {
                    mapB.Add(B[p2], 1);
                }
                mapB[B[p1]]--;
                if (mapB[B[p1]] <= 0)
                {
                    mapB.Remove(B[p1]);
                }
                p1++;
                p2++;
            }

            return ans;
        }
        public static bool CompareHashMaps(Dictionary<char, int> mapA, Dictionary<char, int> mapB)
        {
            foreach (var b in mapB)
            {
                if (!mapA.ContainsKey(b.Key) || mapA.ContainsKey(b.Key) && mapA[b.Key] != b.Value)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsPalindrome(string s)
        {
            int i = 0, j = s.Length - 1;
            s = s.ToLower();
            while (i <= j)
            {
                if (!Char.IsLetterOrDigit(s[i]))
                {
                    i++;
                }
                else if (!(s[j] >= 97 && s[j] <= 122))
                {
                    j--;
                }
                else
                {
                    if (s[i] != s[j])
                    {
                        return false;
                    }
                    i++;
                    j--;
                }
            }

            return true;
        }


        /// <summary>
        /// Moores voting algo
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MajorityElement(int[] nums)
        {
            int max = nums[0], cnt = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (cnt == 0)
                {
                    max = nums[i];
                    cnt++;
                }
                else if (max == nums[i])
                {
                    cnt++;
                }
                else
                {
                    cnt--;
                }
            }
            return max;
        }

        public static bool IsPalindrome(ListNode head)
        {
            ListNode tempHead = head;
            ListNode reverse = Reverse(tempHead);
            ListNode original = Reverse(reverse);
            while (reverse != null && head != null)
            {
                if (reverse.val != head.val)
                {
                    return false;
                }
                reverse = reverse.next;
                head = head.next;
            }
            return true;
        }

        public static ListNode Reverse(ListNode head)
        {
            ListNode reverse = null;
            while (head != null)
            {
                ListNode temp = head;
                head = head.next;
                temp.next = reverse;
                reverse = temp;
            }
            return reverse;
        }

        public static int Search(int[] nums, int target)
        {
            int low = 0, high = nums.Length;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                if (nums[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }

        public static void MoveZeroes(int[] nums)
        {
            int n = nums.Length, i = 0, j = 1;
            while (i < n && j < n)
            {
                if (nums[i] == 0 && nums[j] != 0)
                {
                    nums[i] = nums[i] + nums[j];
                    nums[j] = nums[i] - nums[j];
                    nums[i] = nums[i] - nums[j];
                    i++;
                    j++;
                }
                else if (nums[i] == 0 && nums[j] == 0)
                {
                    j++;
                }
                else
                {
                    i++;
                    j++;
                }
            }
        }

        public static bool IsPowerOfThree(int n)
        {
            int i = 0;
            while (i < n)
            {
                if (Math.Pow(i, 3) == n)
                {
                    return true;
                }
                i++;
            }
            return false;
        }
        public static IList<string> FizzBuzz(int n)
        {
            IList<string> result = new List<string>();
            int i = 1;
            while (i <= n)
            {
                if(i == 15)
                {
                    Console.WriteLine();
                }
                if (i % 3 == 0)
                {
                    result.Add("Fizz");
                }
                else if (i % 5 == 0)
                {
                    result.Add("Buzz");
                }
                else
                {
                    result.Add(i.ToString());
                }
                i++;
            }
            return result;
        }

        public static int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {
            int n = spells.Length, m = potions.Length;
            int[] pairs = new int[n];
            List<List<int>> sortedSpells = new List<List<int>>();
            for (int k = 0; k < n; k++)
            {
                List<int> ints = new List<int>();
                ints.Add(spells[k]);
                ints.Add(k);
                sortedSpells.Add(ints);
            }
            Array.Sort(potions);
            sortedSpells.Sort((a, b) => a[0].CompareTo(b[0]));
            
            int i = 0, j = m - 1, cnt = 0;
            while (i < n)
            {

                while (j >= 0 && (long)potions[j] * sortedSpells[i][0] >= success)
                {
                    cnt++;
                    j--;
                }
                pairs[sortedSpells[i][1]] = cnt;
                i++;
            }

            return pairs;
        }

        public static int PartitionString(string s)
        {
            int[] last_pos = new int[26];
            int partitions = 0, last_end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (last_pos[s[i] - 'a'] >= last_end)
                {
                    partitions++;
                    last_end = i + 1;
                }
                last_pos[s[i] - 'a'] = i + 1;
            }
            return partitions;
        }

        public int MinimizeArrayValue(int[] nums)
        {
            long prefix = 0, ans = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                prefix += nums[i];
                ans = Math.Max(ans, (long)Math.Ceiling((double)prefix / (i + 1)));
            }
            return (int)ans;
        }

        public static int SumSubarrayMins(int[] A)
        {
            int MOD = 1000000007;
            int n = A.Length;
            int[] prevSmaller = new int[n];
            int[] nextSmaller = new int[n];
            Stack<int> stack = new Stack<int>();

            // Calculate the previous smaller element for each element
            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && A[stack.Peek()] > A[i])
                {
                    stack.Pop();
                }
                if (stack.Count > 0)
                {
                    prevSmaller[i] = stack.Peek() + 1;
                }
                stack.Push(i);
            }

            stack.Clear();

            // Calculate the next smaller element for each element
            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && A[stack.Peek()] >= A[i])
                {
                    stack.Pop();
                }
                if (stack.Count > 0)
                {
                    nextSmaller[i] = stack.Peek() - 1;
                }
                stack.Push(i);
            }

            int result = 0;

            // Calculate the sum of values of all possible subarrays
            for (int i = 0; i < n; i++)
            {
                int count = (i - prevSmaller[i] + 1) * (nextSmaller[i] - i + 1);
                result = (result + count * A[i]) % MOD;
            }

            return result;
        }


    }

    

    public class OrderedStream
    {
        string[] temp = null;
        public OrderedStream(int n)
        {
            temp = new string[n];
        }

        public IList<string> Insert(int idKey, string value)
        {
            List<string> ans = new List<string>();
            temp[idKey-1] = value;
            bool isEmpty = false;

            for (int i = idKey - 1; i < (idKey - 1) + idKey && i < temp.Count(); i++)
            {
                if (string.IsNullOrEmpty(temp[i]))
                {
                    isEmpty = true;
                    break;
                }
                else
                {
                    ans.Add(temp[i]);
                }
            }
            if (!isEmpty)
            {
                return ans;
            }
            else
            {
                return new List<string>();
            }
        }
    }

}
