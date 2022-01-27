using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(FirstOccurrenceOfWord1("abcd", "cd")); 
            //Console.WriteLine(Toupper("KRISHNA"));
            //string result = string.Empty;

            // Console.WriteLine(TrimFromEnd("**kris**h**")); 
            // Console.WriteLine(Solve("meayl"));  
            //Console.WriteLine(NumJewelsInStones("z","ZZ"));
            addBinary("1", "1");
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
            if(A.Length == 1 && A[0] == '*')
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
            for (int i = 0; i <= A.Length-B.Length; i++)
            {
                if(A.Substring(i,B.Length) == B)
                {
                    return i+1;
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
                
                ans += Convert.ToChar(Convert.ToInt32(A[i])-32);
            }
            return ans;
        }
        
        static bool Solve(string input)
        {
            int[] arr = new int[26];
            int count = 0;
            for(int i =0; i < input.Length; i++)
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
            
            
            return count > 1  ? false : true;

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
        public static string addBinary(string A, string B)
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
    }
}
