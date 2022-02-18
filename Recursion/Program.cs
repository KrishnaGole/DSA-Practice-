using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Solve("strings"));
            //Console.WriteLine(Pow(-1, 1, 20)); 
            // Console.WriteLine(MagicNumber(963)); 
            //Changecharacter("umeaylnlfd", 1);
            StringOperations("hgUe");
            Console.Read();
        }

        public static int Solve(string A)
        {
            return PalindomicString(A, 0, A.Length - 1);

        }

        public static int PalindomicString(string A, int start, int end)
        {
            if (start >= end)
            {
                return 1;
            }
            if (A[start] == A[end])
            {
               return PalindomicString(A, ++start, --end);
            }
            else
            {
                return 0;
            }
        
        }

        public static int Pow(int A, int B, int C)
        {
            if (A == 0 && B == 0)
            {
                return 0;
            }
            if (B == 0)
            {
                return 1;
            }
            long he = Pow(A, B / 2, C);
            long ha = ((he % C) * (he % C)) % C;
            if (B % 2 == 0)
            {
                if((int)ha < 0)
                {
                    return  + C;
                }
                return (int)ha;
            }
            else
            {
                if ((int)((ha % C * A % C) % C) < 0)
                {
                    return (int)((ha % C * A % C) % C) + C;
                }
                return (int)(ha % C * A % C) % C;
            }
        }

        public static int MagicNumber(int A)
        {
            int ans = IsMagic(A);
            while (ans > 9)
            {
                ans = IsMagic(ans);
            }
            if (ans == 1)
            {
                return 1;
            }
            return 0;

        }
        public static int IsMagic(int A)
        {
            if (A == 0)
            {
                return 0;
            }
            return (A % 10) + IsMagic(A / 10);
        }

        public static int KthSymbol(int A, int B)
        {
            List<int> ans = new List<int>();
            ans.Add(0);
            for (int i = 1; i <= A; i++)
            {
                List<int> temp = new List<int>();
                for (int j = 0; j < ans.Count(); j++)
                {
                    if (ans[i - 1] == 0)
                    {
                        temp.Add(1);
                    }
                    else
                    {
                        temp.Add(0);
                    }
                }
                for (int k = 0; k < temp.Count(); k++)
                {
                    ans.Add(temp[k]);
                }
            }
            return ans[B - 1];
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
                else if(counts[i] != 0)
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
