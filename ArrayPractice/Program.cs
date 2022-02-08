using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArrayPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //int[] arr = { 18,18,18, 18 };
            //foreach (int i in OccurencesOfN(arr, 18))
            //{
            //    if (i == -1)
            //    {
            //        break;
            //    }
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine(arr);
            //printAddress(arr);
            //GCHandle gch = GCHandle.Alloc(arr, GCHandleType.Pinned);
            //IntPtr pObj = gch.AddrOfPinnedObject();
            //Console.WriteLine(pObj.ToString());

            //List<List<int>> B = new List<List<int>>();
            //B.Add(new List<int>() { 1, 2, 10 });
            //B.Add(new List<int>() { 2, 3, 20 });
            //B.Add(new List<int>() { 2, 5, 25 });
            //BeggarsOutsideTemple(5, B);
            // List<int> vs = new List<int>() { 15, 20, 20, 15, 10, 30, 45 };
            // Newpaper1(2, new List<int>() { 1,0,0,0,0,0,0 });
            //int[,] arr = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
            //DisplayWave(arr);
            //Console.WriteLine(firstMissingPositive(new List<int> { 417, 929, 845, 462, 675, 175, 73, 867, 14, 201, 777, 407, 80, 882, 785, 563, 209, 261, 776, 362, 730, 74, 649, 465, 353, 801, 503, 154, 998, 286, 520, 692, 68, 805, 835, 210, 819, 341, 564, 215, 984, 643, 381, 793, 726, 213, 866, 706, 97, 538, 308, 797, 883, 59, 328, 743, 694, 607, 729, 821, 32, 672, 130, 13, 76, 724, 384, 444, 884, 192, 917, 75, 551, 96, 418, 840, 235, 433, 290, 954, 549, 950, 21, 711, 781, 132, 296, 44, 439, 164, 401, 505, 923, 136, 317, 548, 787, 224, 23, 185, 6, 350, 822, 457, 489, 133, 31, 830, 386, 671, 999, 255, 222, 944, 952, 637, 523, 494, 916, 95, 734, 908, 90, 541, 470, 941, 876, 264, 880, 761, 535, 738, 128, 772, 39, 553, 656, 603, 868, 292, 117, 966, 259, 619, 836, 818, 493, 592, 380, 500, 599, 839, 268, 67, 591, 126, 773, 635, 800, 842, 536, 668, 896, 260, 664, 506, 280, 435, 618, 398, 533, 647, 373, 713, 745, 478, 129, 844, 640, 886, 972, 62, 636, 79, 600, 263, 52, 719, 665, 376, 351, 623, 276, 66, 316, 813, 663, 831, 160, 237, 567, 928, 543, 508, 638, 487, 234, 997, 307, 480, 620, 890, 216, 147, 271, 989, 872, 994, 488, 291, 331, 8, 769, 481, 924, 166, 89, 824, -4, 590, 416, 17, 814, 728, 18, 673, 662, 410, 727, 667, 631, 660, 625, 683, 33, 436, 930, 91, 141, 948, 138, 113, 253, 56, 432, 744, 302, 211, 262, 968, 945, 396, 240, 594, 684, 958, 343, 879, 155, 395, 288, 550, 482, 557, 826, 598, 795, 914, 892, 690, 964, 981, 150, 179, 515, 205, 265, 823, 799, 190, 236, 24, 498, 229, 420, 753, 936, 191, 366, 935, 434, 311, 920, 167, 817, 220, 219, 741, -2, 674, 330, 909, 162, 443, 412, 974, 294, 864, 971, 760, 225, 681, 689, 608, 931, 427, 687, 466, 894, 303, 390, 242, 339, 252, 20, 218, 499, 232, 184, 490, 4, 957, 597, 477, 354, 677, 691, 25, 580, 897, 542, 186, 359, 346, 409, 655, 979, 853, 411, 344, 358, 559, 765, 383, 484, 181, 82, 514, 582, 593, 77, 228, 921, 348, 453, 274, 449, 106, 657, 783, 782, 811, 333, 305, 784, 581, 746, 858, 249, 479, 652, 270, 429, 614, 903, 102, 378, 575, 119, 196, 12, 990, 356, 277, 169, 70, 518, 282, 676, 137, 622, 616, 357, 913, 161, 3, 589, 327 }));
            //Console.WriteLine(firstMissingPositive(new List<int> { 417, 929, 845, 462, 675, 175, 73, 867, 14, 201, 777, 407, 80, 882, 785, 563, 209, 261, 776, 362, 730, 74, 649, 465, 353, 801, 503, 154, 998, 286, 520, 692, 68, 805, 835, 210, 819, 341, 564, 215, 984, 643, 381, 793, 726, 213, 866, 706, 97, 538, 308, 797, 883, 59, 328, 743, 694, 607, 729, 821, 32, 672, 130, 13, 76, 724, 384, 444, 884, 192, 917, 75, 551, 96, 418, 840, 235, 433, 290, 954, 549, 950, 21, 711, 781, 132, 296, 44, 439, 164, 401, 505, 923, 136, 317, 548, 787, 224, 23, 185, 6, 350, 822, 457, 489, 133, 31, 830, 386, 671, 999, 255, 222, 944, 952, 637, 523, 494, 916, 95, 734, 908, 90, 541, 470, 941, 876, 264, 880, 761, 535, 738, 128, 772, 39, 553, 656, 603, 868, 292, 117, 966, 259, 619, 836, 818, 493, 592, 380, 500, 599, 839, 268, 67, 591, 126, 773, 635, 800, 842, 536, 668, 896, 260, 664, 506, 280, 435, 618, 398, 533, 647, 373, 713, 745, 478, 129, 844, 640, 886, 972, 62, 636, 79, 600, 263, 52, 719, 665, 376, 351, 623, 276, 66, 316, 813, 663, 831, 160, 237, 567, 928, 543, 508, 638, 487, 234, 997, 307, 480, 620, 890, 216, 147, 271, 989, 872, 994, 488, 291, 331, 8, 769, 481, 924, 166, 89, 824, -4, 590, 416, 17, 814, 728, 18, 673, 662, 410, 727, 667, 631, 660, 625, 683, 33, 436, 930, 91, 141, 948, 138, 113, 253, 56, 432, 744, 302, 211, 262, 968, 945, 396, 240, 594, 684, 958, 343, 879, 155, 395, 288, 550, 482, 557, 826, 598, 795, 914, 892, 690, 964, 981, 150, 179, 515, 205, 265, 823, 799, 190, 236, 24, 498, 229, 420, 753, 936, 191, 366, 935, 434, 311, 920, 167, 817, 220, 219, 741, -2, 674, 330, 909, 162, 443, 412, 974, 294, 864, 971, 760, 225, 681, 689, 608, 931, 427, 687, 466, 894, 303, 390, 242, 339, 252, 20, 218, 499, 232, 184, 490, 4, 957, 597, 477, 354, 677, 691, 25, 580, 897, 542, 186, 359, 346, 409, 655, 979, 853, 411, 344, 358, 559, 765, 383, 484, 181, 82, 514, 582, 593, 77, 228, 921, 348, 453, 274, 449, 106, 657, 783, 782, 811, 333, 305, 784, 581, 746, 858, 249, 479, 652, 270, 429, 614, 903, 102, 378, 575, 119, 196, 12, 990, 356, 277, 169, 70, 518, 282, 676, 137, 622, 616, 357, 913, 161, 3, 589, 327 }));
            //ForVsWhile();
            //AllOccurences("Apple Apple ususuu Apple usuusus", "Apple");
            //RotateAMatrix90(new List<List<int>>() { new List<int>() { 1, 2, 3, 4}, new List<int>() { 5,6,7,8 } , new List<int>() { 9,10,11,12 } , new List<int>() { 13,14,15,16 } });
            List<int> vs = new List<int>() { 8986143, -5026827, 5591744, 4058312, 2210051, 5680315, -5251946, -607433, 1633303, 2186575 };

            Solve(vs);
            Console.ReadLine();
        }

        static void PrintAddress(int[] arr)
        {
            GCHandle gch = GCHandle.Alloc(arr, GCHandleType.Pinned);
            IntPtr pObj = gch.AddrOfPinnedObject();
            Console.WriteLine(pObj.ToString());
        }

        static int[] OccurencesOfN(int[] arr, int n)
        {
            int[] vs = new int[arr.Length + 1];
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == n)
                {
                    vs[count] = i;
                    count++;
                }

            }
            vs[count] = -1;

            return vs;
        }

        static List<int> BeggarsOutsideTemple(int A, List<List<int>> B)
        {
            int N = B.Count();
            int[] ans = new int[A];
            for (int i = 0; i < N; i++)
            {
                int leftIndex = B[i][0];
                int rightIndex = B[i][1];
                int val = B[i][2];
                ans[leftIndex - 1] += val;
                if (rightIndex < A)
                {
                    ans[rightIndex] -= val;
                }
            }

            for (int i = 1; i < A; i++)
            {
                ans[i] += ans[i - 1];
            }
            return ans.ToList();
        }
        public static int Newpaper(int A, List<int> B)
        {
            int sum = 0;
            int count = 0;
            int ans = 0;
            int[] input = B.ToArray();
            while (sum < A)
            {
                if (ans == 7)
                {
                    ans = 1;
                }
                sum += input[count];
                count++;
                ans++;
                if (count > 6)
                {
                    count = 0;
                }

            }
            return ans;
        }
        public static int Newpaper1(int A, List<int> B)
        {
            for (int i = 0; i < B.Count; i++)
            {

            }
            int cur = 0;          // currently read lines
            while (true)
            {
                if (A <= B[cur])   // If lines completed
                {
                    return cur + 1;
                }
                A -= B[cur];      // Read number of lines on this day
                cur = (cur + 1) % 7;  // Take mod 7 to cycle around days
            }
        }

        static void DisplayWave(int[,] arr)
        {
            //int count = 1;
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < arr.GetLength(0); j++)
                    {
                        Console.Write(arr[j, i] + " ");
                    }
                }
                else
                {

                    for (int j = arr.GetLength(0) - 1; j >= 0; j--)
                    {
                        Console.Write(arr[j, i] + " ");
                    }
                }
                // count++; 

            }
        }

        public static int FirstMissingPositive(List<int> A)
        {
            int missingNum = 0; int temp = 0;
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] <= A.Count && A[i] != i + 1 && A[i] > 0 && A[A[i] - 1] != A[i])
                {
                    //A[A[i] - 1] = A[A[i] - 1]  + A[i]; 
                    //A[i] = A[A[i] - 1] - A[i];
                    //A[A[i] - 1] = A[A[i] - 1] - A[i];

                    temp = A[i];
                    A[i] = A[A[i] - 1];
                    A[temp - 1] = temp;
                    i--;

                }
            }
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] != i + 1)
                {
                    missingNum = i + 1;
                    break;
                }
            }
            if (missingNum == 0)
            {
                missingNum = A[A.Count - 1] + 1;
            }
            return missingNum;
        }

        public static void ForVsWhile()
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 1000000000; i++)
            {
            }
            stopwatch.Stop();
            Console.WriteLine("Time Taken by For loop in millisecond " + stopwatch.ElapsedMilliseconds);

            int j = 0;
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            while (j < 1000000000)
            {
                j++;
            }
            stopwatch1.Stop();
            Console.WriteLine("Time Taken by while loop in millisecond " + stopwatch1.ElapsedMilliseconds);

        }

        static void RotateAMatrix90(List<List<int>> vs)
        {
            int length = vs.Count;
            for (int i = 0; i < length / 2; i++)
            {
                for (int j = i; j < length - i - 1; j++)
                {
                    int temp = vs[i][j];
                    vs[i][j] = vs[length - j - 1][i];
                    vs[length - j - 1][i] = vs[length - i - 1][length - j - 1];
                    vs[length - i - 1][length - j - 1] = vs[j][length - i - 1];
                    vs[j][length - i - 1] = temp;

                }
            }
        }

        /// <summary>
        ///Print All subArray
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static List<int> Solve(List<int> A)
        {
            int flag = 0;
            List<int> vs = new List<int>();
            for (int i = 0; i < A.Count(); i++)
            {
                for (int j = i; j < A.Count(); j++)
                {
                    flag = 0;
                    for (int k = i; k <= j; k++)
                    {
                        if (A[k] < 0)
                        {
                            flag = 1;
                            i = k;
                            j = k;
                            break;
                        }
                    }
                    if (flag == 0 && vs.Count() < j - i + 1)
                    {
                        vs = A.GetRange(i, j - i + 1);
                    }
                    else if(flag == 1)
                    {
                        break;
                    }
                }
            }
            return vs;


        }
    }
}
