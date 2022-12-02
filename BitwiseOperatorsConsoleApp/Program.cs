using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitwiseOperatorsConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //singleNumber(new List<int>() { 4, 5, 6, 7, 4, 5, 6 });
            //numSetBits(11);
            //Solve(3);
            //Solve1(new List<int>() { 1, 2, 3, 1, 2, 4 });
            //SolveIII(new List<int>() { 186, 256, 102, 377, 186, 377 });
            //Solve2(10,3);
            //InterestingArray(new List<int>() { 1 });
            //RepeatAndMissingNumberArray(new List<int>() { 3, 1, 2, 5, 3, });
            //HammingDistance(new List<int>() { 2, 4, 6 });
            //Solve(new List<int>() { 1,2,3,4,5 }, 2);
            //SmallestXOR(4, 6);
            //MaximumSatisfaction(new List<int>() { 1, 18, 15, 16, 7, 127, 3, 83, 31, 23, 31 });
           int x = StrangeEquality(99);
           
        }

        /// <summary>
        /// Single Number
        /// Given an array of integers A, every element appears twice except for one. Find that single one.
        /// NOTE: Your algorithm should have a linear runtime complexity.Could you implement it without using extra memory?
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int SingleNumber(List<int> A)
        {
            int xor = A[0];
            int length = A.Count();
            for(int i = 1; i < length; i++)
            {
                xor = xor ^ A[i];
            }
            return xor;
        }

        /// <summary>
        /// Number of 1 Bits
        /// Write a function that takes an integer and returns the number of 1 bits it has.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int NumSetBits(int A)
        {
            int count = 0;
            while (A != 0)
            {
                A = A & (A - 1);
                count++;
            }
            return count;
        }

        public static int Solve(int A)
        {
            int count = 0;
            while(A > 0)
            {
                if((A & 1) == 1)
                {
                    count++;
                }
                A >>= 1;

            }
            return count;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<int> Solve(List<int> A)
        {
            int xor = 0;
            int n = A.Count();
            int mask = 0;
            for (int i = 0; i < n; i++)
            {
                xor ^= A[i];
            }
            mask = (xor & (xor - 1)) ^ xor;
            int a = 0, b = 0;
            for (int i = 0; i < n; i++)
            {
                if ((A[i] & mask) != 0)
                {
                    a = a ^ A[i];
                }
                else
                {
                    b = b ^ A[i];
                }
            }

            return new List<int>() { Math.Min(a, b), Math.Max(a, b) };
        }

        /// <summary>
        /// Single Number III
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<int> Solve1(List<int> A)
        {
            int xor = 0;
            int n = A.Count();
            int mask = 0;
            for (int i = 0; i < n; i++)
            {
                xor ^= A[i];
            }
            mask = (xor & (xor - 1)) ^ xor;
            int a = 0, b = 0;
            for (int i = 0; i < n; i++)
            {
                if ((A[i] & mask) != 0)
                {
                    a = a ^ A[i];
                }
                else
                {
                    b = b ^ A[i];
                }
            }

            return new List<int>() { Math.Min(a, b), Math.Max(a, b) };
        }

        /// <summary>
        /// Reverse Bits
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static long Solve2(long A, int B)
        {
            //long ans = 0;
            //for (int i = 0; i <= 32; i++)
            //{
            //    if (((A >> i) & 1) == 1)
            //    {
            //        ans = ans + ((long)1 << (31 - i));
            //    }
            //}
            //return ans;

            long ans = A;
            for (int i = 0; i < B; i++)
            {
                if (((A >> i) & 1) == 1)
                {
                    ans -= (1 << i);
                }
            }
            return ans;

        }

        /// <summary>
        ///  Single Number II
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int SingleNumber1(List<int> A)
        {
            int ans = 0;
            int count = 0;
            for (int i = 0; i <= 30; i++)
            {
                count = 0;
                for (int j = 0; j < A.Count(); j++)
                {
                    if (((A[j] >> i) & 1) == 1)
                    {
                        count++;
                    }
                }
                if (count % 3 == 1)
                {
                    ans += (1 << i);
                }
            }
            return ans;
        }

        /// <summary>
        /// Single Number III
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<int> SolveIII(List<int> A)
        {
            int xor = 0, pos = 0, num1 = 0, num2 = 0;
            for (int i = 0; i < A.Count(); i++)
            {
                xor ^= A[i];
            }
            for (int i = 31; i >= 0; i--)
            {
                if (((xor << i) & 1) == 1)
                {
                    pos = i;
                    break;
                }
            }

            //for (int i = 0; i < 31; i++)
            //{
            //    if (((xor << i) & 1) == 1)
            //    {
            //        pos = i;
            //        break;
            //    }
            //}

            for (int i = 0; i < A.Count(); i++)
            {
                if (((A[i] >> pos) & 1) == 1)
                {
                    num1 ^= A[i];
                }
                else
                {
                    num2 ^= A[i];
                }
            }

            return new List<int>() { num1, num2 };
        }

        public static string InterestingArray(List<int> A)
        {
            int count = 0;
            for (int i = 0; i < A.Count(); i++)
            {
                if ((A[i] & 1) == 0)
                {
                    count++;
                }
            }
            if ((count & 1) == 0 && count > 0)
            {
                return "Yes";
            }
            return "No";
        }

        /// <summary>
        /// Repeat and Missing Number Array
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<int> RepeatAndMissingNumberArray(List<int> A)
        {
            List<int> ans = new List<int>();
            for(int i = 0; i < A.Count(); i++)
            {
                int abs = Math.Abs(A[i]);
                if(A[abs - 1] > 0)
                {
                    A[abs - 1] = -A[abs - 1];
                }
                else
                {
                    ans.Add(abs);
                }

            }
            return ans;
        }


        public static int HammingDistance(List<int> A)
        {
            int sum = 0;
            for (int i = 0; i < A.Count(); i++)
             {
                 for (int j = 0; j < A.Count(); j++)
                 {
                    for(int b = 0; b <= 30; b++)
                    {
                        if (CheckBit(A[i], b) == true && CheckBit(A[j], b) == false)
                        {
                            sum++;
                        }
                        else if (CheckBit(A[i], b) == false && CheckBit(A[j], b) == true)
                        {
                            sum++;
                        }
                    }
                 }
             }

            
            return sum;

        }
        public static bool CheckBit(int n, int i)
        {
            if (((n >> i) & 1) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static int Solve(List<int> A, int B)
        {
            long count = 0; int mod = 1000000007;
            for (int i = 0; i < A.Count(); i++)
            {
                A[i] %= B;
            }
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < A.Count(); i++)
            {
                if (map.ContainsKey(A[i]))
                {
                    map[A[i]]++;
                }
                else
                {
                    map.Add(A[i], 1);
                }
            }
            if (map.ContainsKey(0))
            {
                count += ((map[0] % mod * ((map[0] - 1) % mod) / 2) % mod) % mod;
            }

            if (B % 2 == 0)
            {
                if (map.ContainsKey(B / 2))
                {
                    count += ((map[B / 2] % mod * ((map[(B / 2)] - 1) % mod) / 2) % mod);
                }
            }

            for (int i = 1; i < (B + 1) / 2; i++)
            {
                if (map.ContainsKey(B - i) && map.ContainsKey(i))
                {
                    count += (map[i] % mod * map[B - i] % mod) % mod;
                }
            }

            return (int)(count + mod) % mod;

        }

        public static int SmallestXOR(int A, int B)
        {

            int X = 0;

            for (int i = 31; i >= 0; i--)
            {

                if (B == 0)
                {
                    return X;
                }

              if ((A & (1 << i)) > 0)
                {

                    X |= (1 << i);

                    B--;

                }

            }

            for (int i = 0; i <= 31; i++)
            {

                if (B == 0) 
                    return X;

                if ((A & (1 << i)) == 0)
                {

                    X |= (1 << i);

                    B--;

                }

            }

            return X;

        }

        public static int MaximumSatisfaction(List<int> A)
        {
            int ans = 0, n = A.Count();
            for (int i = 31; i >= 0; i--)
            {
                int count = 0;
                for (int j = 0; j < n; j++)
                {
                    if(count == 4)
                    {
                        break;
                    }
                    int temp = ans | (1 << i);
                    if ((temp & A[j]) == temp)
                    {
                        count++;
                    }
                }
                if (count == 4)
                {
                    ans |= (1 << i);
                }
            }
            return ans;
        }

        public static int StrangeEquality(int A)
        {
            int x = 0, cnt = 0;
            int temp = A;
            while (temp > 0)
            {
                cnt++;
                temp /= 2;
            }
            for (int i = cnt - 1; i >= 0; i--)
            {
                if((A & (1 << i)) == 0)
                {
                    x |= (1 << i);
                }
            }
            x = BinaryToDecimal(x);
            return x ^ (1 << cnt);
            //double binary = DToB(A), x_binary = 0;
            //int cnt = 0;
            //while(binary != 0)
            //{
            //    if(binary % 10 == 1)
            //    {
            //        x_binary += 0 * (int)Math.Pow(10, cnt);
            //    }
            //    else
            //    {
            //        x_binary += 1 * (int)Math.Pow(10, cnt);
            //    }
            //    cnt++;
            //    binary /= 10;
            //}
            //double x = BinaryToDecimal(x_binary);
            //double y = (1 << cnt);
            //return (int)x ^ (int)y;
            return 12;
            
            
        }

        static int DToB(int num)
        {
            double decimalNum = 0;
            int count = 0;
            while (num > 0)
            {
                decimalNum += (num % 2) * Math.Pow(10, count);
                count++;
                num /= 2;
            }
            return (int)decimalNum;
        }

        public static int BinaryToDecimal(double num)
        {
            double sum = 0, count = 0;
            while (num != 0)
            {
                sum += (num % 10) * Math.Pow(2, count);
                count++;
                num = num / 10;
            }
            return (int)sum;
        }


    }
}
