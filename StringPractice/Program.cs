using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPractice
{
    internal class Program
    {
        int minStart = 0;
        int minEnd = 0;
        int maxLength = 0;
        static void Main(string[] args)
        {

            //Console.WriteLine(FirstOccurrenceOfWord1("abcd", "cd")); 
            //Console.WriteLine(Toupper("KRISHNA"));
            //string result = string.Empty;

            // Console.WriteLine(TrimFromEnd("**kris**h**")); 
            // Console.WriteLine(Solve("meayl"));  
            //Console.WriteLine(NumJewelsInStones("z","ZZ"));
            //AddBinary("1", "1");
            //List<List<string>> vs = new List<List<string>>() { new List<string>() { "phone", "blue", "pixel" }, new List<string>() { "computer", "silver", "lenovo" }, new List<string>() { "phone", "gold", "iphone" } };
            //CountMatches(vs, "color", "silver");
            //Reverse("krishna");
            //Program program = new Program();
            //program.LongestPalindrome("aaaabaaa");
            //Reverse1("the sky is blue");
            CheckPalindrome("yzfbzbyyrurquqf");
            Console.ReadLine();

        }
        public static string TrimFromEnd(string A)
        {
            char[] charArray = A.ToCharArray();
            int start = 0;
            while (start < A.Length && charArray[start] == '*')
            {
                start++;
            }
            if (A.Length == 1 && A[0] == '*')
            {
                return "";
            }
            int end = A.Length - 1;
            while (end > 0 && charArray[end] == '*')
            {
                end--;
            }
            return A.Substring(start, end - start + 1);
        }
        public static int FirstOccurrenceOfWord(string A, string B)
        {
            for (int i = 0; i <= A.Length - B.Length; i++)
            {
                if (A.Substring(i, B.Length) == B)
                {
                    return i + 1;
                }
            }
            return -1;
        }
        public static int FirstOccurrenceOfWord1(string A, string B)
        {
            for (int i = 0; i <= A.Length - 2; i = i + 2)
            {
                if (A.Substring(i, 2) == B)
                {
                    return i;
                }
            }
            return -1;
        }
        public static string Toupper(string A)
        {
            string ans = String.Empty;
            for (int i = 0; i < A.Length; i++)
            {

                ans += Convert.ToChar(Convert.ToInt32(A[i]) - 32);
            }
            return ans;
        }

        static bool Solve(string input)
        {
            int[] arr = new int[26];
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                arr[input[i] - 'a']++;
            }

            for (int j = 0; j < arr.Count(); j++)
            {
                if (arr[j] % 2 != 0)
                {
                    count++;
                }
            }


            return count > 1 ? false : true;

        }

        public static int NumJewelsInStones(string jewels, string stones)
        {
            int[] arr = new int[122];
            int jewelsLength = jewels.Length;
            int stonesLength = stones.Length;
            int count = 0;
            for (int i = 0; i < jewelsLength; i++)
            {
                arr[(int)jewels[i]]++;
            }
            for (int i = 0; i < stonesLength; i++)
            {
                count = count + arr[(int)stones[i]];
            }
            return count;
        }

        /// <summary>
        /// Shuffle String
        /// </summary>
        /// <param name="s"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        public static string RestoreString(string s, int[] indices)
        {
            int length = indices.Length;
            char[] temp = new char[length];
            string ans = string.Empty;
            for (int i = 0; i < length; i++)
            {
                temp[indices[i]] = s[i];
            }
            //for (int i = 0; i < length; i++)
            //{
            //    ans += temp[i];
            //}
            return new string(temp);
        }


        /// <summary>
        /// Add Binary Strings
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static string AddBinary(string A, string B)
        {
            StringBuilder b = new StringBuilder();
            StringBuilder a = new StringBuilder();
            int maxLength = Math.Max(A.Length, B.Length);
            int minLength = Math.Min(A.Length, B.Length);

            for (int i = 0; i < maxLength - minLength; i++)
            {
                if (minLength == A.Length)
                {
                    a.Append("0");
                }
                else
                {
                    b.Append("0");
                }

            }
            a.Append(A);
            b.Append(B);
            StringBuilder ans = new StringBuilder();
            int carry = 0;

            for (int i = maxLength - 1; i >= 0; i--)
            {
                int num1 = a[i] - '0';
                int num2 = b[i] - '0';
                int temp = num1 + num2 + carry;
                int sum = (temp % 2);
                ans.Append(Convert.ToChar(sum.ToString()));
                carry = temp / 2;
            }
            if (carry > 0)
            {
                ans.Append(carry);
            }
            StringBuilder result = new StringBuilder();
            for (int i = ans.Length - 1; i >= 0; i--)
            {
                result.Append(ans[i]);
            }
            return result.ToString();
        }

        /// <summary>
        /// Count Items Matching a Rule
        /// </summary>
        /// <param name="items"></param>
        /// <param name="ruleKey"></param>
        /// <param name="ruleValue"></param>
        /// <returns></returns>
        public static int CountMatches(List<List<string>> items, string ruleKey, string ruleValue)
        {
            int count = 0;
            int n = items.Count();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((ruleKey == "type" && items[i][j] == ruleValue) ||
                      (ruleKey == "color" && items[i][j] == ruleValue) ||
                      (ruleKey == "name" && items[i][j] == ruleValue))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static string Reverse(string A)
        {
            int n = A.Length;
            char temp = ' ';
            StringBuilder stringBuilder = new StringBuilder(A);
            for (int i = 0; i < n / 2; i++)
            {
                temp = stringBuilder[i];
                stringBuilder[i] = stringBuilder[n - 1 - i];
                stringBuilder[n - 1 - i] = temp;
            }
            return stringBuilder.ToString();
        }

        public  string LongestPalindrome(string A)
        {
            int n = A.Length;
            //string ans =  string.Empty;
            for (int i = 0; i < n; i++)
            {
                Expand(A, i, i, n);

            }
            for (int i = 0; i < n - 1; i++)
            {
                Expand(A, i, i + 1, n);
            }
            return A.Substring(minStart, minEnd);
            //int n = A.Length;
            //int maxLength = 0;
            //string ans = string.Empty;
            //for (int i = 1; i < n; i++)
            //{
            //    ans = Expand(A, i, i, n, maxLength, ans);
            //    maxLength = ans.Length;
            //}
            //for (int i = 1; i < n - 1; i++)
            //{
            //    ans = Expand(A, i, i + 1, n, maxLength, ans);
            //    maxLength = ans.Length;
            //}
            //return ans;

        }
        public  void Expand(string A, int start, int end, int length)
        {
            while (start >= 0 && end < length && A[start] == A[end])
            {
                start--;
                end++;

            }
            //Console.Write(start);
            if (end - start - 1 > maxLength)
            {
                // if(end == length)
                //     {
                //         end -= 1; 
                //     }
                //return A.Substring(start+1,end - start -1);
                minStart = start + 1;
                minEnd = end - start - 1;
            }
            maxLength = Math.Max(maxLength,end - start - 1);
            //while (start >= 0 && end < length && A[start] == A[end])
            //{
            //    start--;
            //    end++;

            //}
            //if (end - start - 1 > maxLength)
            //{
            //    //if(end == length)
            //    //{
            //    //    end -= 1; 
            //    //}
            //    return A.Substring(start + 1, end -start -1);
            //}
            //return ans;
        }

        public static void Reverse1(string s)
        {
            int n = s.Length;
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder1 = new StringBuilder();
            stringBuilder.Append(ReverseString(n, new StringBuilder(s)));
            List<string> arr = new List<string>();
            for (int i = 0; i < stringBuilder.Length; i++)
            {
                if(i == stringBuilder.Length - 1)
                {
                    stringBuilder1.Append(stringBuilder[i]);
                }
                if (stringBuilder[i] != ' ' && i != stringBuilder.Length - 1)
                {
                    stringBuilder1.Append(stringBuilder[i]);
                }
                else
                {
                    arr.Add(stringBuilder1.ToString());
                    stringBuilder1 = new StringBuilder();
                }
            }
            stringBuilder = new StringBuilder();
            for (int i = 0; i < arr.Count(); i++)
            {
                arr[i] = ReverseString(arr[i].Length, new StringBuilder(arr[i]));
                if(i != arr.Count() - 1)
                {
                    stringBuilder.Append(arr[i] + ' ');
                }
                else
                {
                    stringBuilder.Append(arr[i]);

                }
            }
        }

        private static string ReverseString(int n, StringBuilder stringBuilder)
        {
            for (int i = 0; i < n / 2; i++)
            {
                char temp = stringBuilder[i];
                stringBuilder[i] = stringBuilder[n - i - 1];
                stringBuilder[n - i - 1] = temp;
            }
            return stringBuilder.ToString();
        }


        /// <summary>
        /// Check Palindrome - II
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int CheckPalindrome(string A)
        {
            int n = A.Length;
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < n; i++)
            {
                if (!map.ContainsKey(A[i]))
                {
                    map.Add(A[i], 1);
                }
                else
                {
                    map[A[i]]++;
                }
            }
            int ans = 1;
            int count = 0;
            for (int i = 0; i < map.Count(); i++)
            {
                if (n % 2 == 0 && map.ElementAt(i).Value % 2 == 1)
                {
                    return 0;
                }
                else if (n % 2 == 1 && map.ElementAt(i).Value % 2 == 1)
                {
                    count++;
                }
            }

            return (n % 2 == 1 && count == 1) || (n % 2 == 0 && count == 0) ? ans : 0;
        }

        public static int Changecharacter(string A, int B)
        {
            int[] counts = new int[26];
            int ans = 0;
            for (int i = 0; i < A.Length; i++)
            {
                counts[A[i] - 'a']++;
            }
            Array.Sort(counts);
            for (int i = 0; i < 26; i++)
            {
                if (counts[i] != 0 && B - counts[i] >= 0)
                {
                    B -= counts[i];
                }
                else if (counts[i] != 0)
                {
                    ans++;
                }
            }
            return ans;
        }

        public static string StringOperations(string A)
        {
            StringBuilder sb = new StringBuilder(A);
            sb.Append(A);
            StringBuilder ans = new StringBuilder(A);
            int n = sb.Length;
            for (int i = 0; i < n; i++)
            {
                if (sb[i] >= 65 && sb[i] <= 90)
                {
                }
                else if (sb[i] == 'a' || sb[i] == 'i' || sb[i] == 'e' || sb[i] == 'o' || sb[i] == 'u')
                {
                    ans.Append('#');
                }
            }
            return ans.ToString();
        }


    }
}
