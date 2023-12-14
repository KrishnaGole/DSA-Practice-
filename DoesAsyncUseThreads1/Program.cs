using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoesAsyncUseThreads1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Thread thread = new Thread(SomeMethod);
            //thread.Start();
            //SomeMethod();
            //Console.WriteLine("Main Method code" + Thread.CurrentThread.ManagedThreadId);
            //Console.ReadLine();
            //int num = 10;
            //PassByRef(out num);
            //Console.WriteLine(num);
            Solve(new List<int>() { 6,48,-19,36,-12 }, 24);
                
        }

        public static int Solve(List<int> A, int B)
        {
            int n = A.Count(), cnt = 0, sum = 0, ans = 0;
            for (int i = 0; i < n; i++)
            {
                cnt = 0; sum = 0;
                for (int j = i; j < n; j++)
                {
                    sum += A[j];
                    cnt++;
                    if (sum == B)
                    {
                        ans = Math.Max(ans, cnt);
                    }
                    
                    
                }
            }
            return ans;
        }
        static async void SomeMethod()
        {
            await Task.Delay(6000);
            Console.WriteLine("Asyn code finishes " + Thread.CurrentThread.ManagedThreadId);
        }
        
        // ref vs out 
        static void PassByRef(out int val)
        {
            val = 0;
            val+=  10;
            return;
        }
    }
}
