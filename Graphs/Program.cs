using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> A = new List<List<int>>()
            {
                new List<int>(){0 , 50 , 39},
                new List<int>(){-1 , 0 , 1},
                new List<int>(){-1 , 10 , 0},
               
            };
            string input = "6";
            if (int.TryParse(input, out int num) && num > 5)
            {
                decimal temp = Convert.ToInt32(input);

            }
            //Solve(5, input);
            //Solve(new List<int>() { 1, 1, 1, 3, 3, 2, 2, 7, 6 }, 9, 1);

            //List<int> max = new List<int>();
            //var result = MaxPath(A, A.Count() - 1, 2, new List<int>() { A[A.Count() - 1].Max()}).Sum();
            //RottenOrganes(A);
            //Solve1(2, A);
            Solve(A);

            //TopologicalSort(8, A);


        }

        public static int Solve(int A, List<List<int>> B)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(B[0][1]);
            bool[] isVisited = new bool[A + 1];
            isVisited[1] = true;
            List<List<int>> graphs = new List<List<int>>();
            for(int i = 0; i <= A; i++)
            {
                graphs.Add(new List<int>());
            }
            for (int i = 0; i < B.Count(); i++)
            {
                graphs[B[i][0]].Add(B[i][1]);
            }

            while (queue.Count() > 0)
            {
                int current = queue.Dequeue();
                if(current == A)
                {
                    return 1;
                }
                isVisited[current] = true;
                for(int i = 0; i < graphs[current].Count(); i++)
                {
                    if (!isVisited[graphs[current][i]])
                    {
                        queue.Enqueue(graphs[current][i]);
                    }
                }

            }
            return 0;
        }

        public static int Solve(List<int> A, int B, int C)
        {
            int n = A.Count();
            List<List<int>> graph = new List<List<int>>();
            for (int i = 0; i <= n; i++)
            {
                graph.Add(new List<int>());
            }
            for (int i = 1; i < n; i++)
            {
                graph[A[i]].Add(i + 1);
            }
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(C);
            while(queue.Count() > 0)
            {
                int curr = queue.Dequeue();
                if (curr == B)
                {
                    return 1;
                }
                for(int i = 0; i < graph[curr].Count(); i++)
                {
                    queue.Enqueue(graph[curr][i]);
                }
            }
            return 0;
        }

        public static List<int> MaxPath(List<List<int>> A, int i, int j, List<int> max)
        {
            if (i == 0 || j == 0)
            {
                return max;
            }
            
            max.Add(Math.Max(A[i - 1][j - 1],  A[i - 1][j]));
            MaxPath(A, i - 1, j, max);
            MaxPath(A, i - 1, j - 1, max);
            return max;

        }

        public static int RottenOrganes(List<List<int>> A)
        {
            int n = A.Count(), m = A[0].Count(), ans = -1;
            Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();
            int[,] time = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (A[i][j] == 2)
                    {
                        queue.Enqueue(new KeyValuePair<int, int>(i, j));
                        time[i, j] = 0;
                    }
                }
            }
            queue.Enqueue(new KeyValuePair<int, int>(-1, -1));
            int[] x = { -1, +1, 0, 0 };
            int[] y = { 0, 0, -1, +1 };
            while (queue.Count() > 0)
            {
                var d = queue.Dequeue();
                int i = d.Key, j = d.Value;
                if(i == -1 && j == -1 )
                {
                    ans++;
                    if(queue.Count() > 0)
                    {
                        queue.Enqueue(new KeyValuePair<int, int>(-1, -1));
                    }
                }
                for (int k = 0; k < 4; k++)
                {
                    int a = i + x[k], b = j + y[k];
                    if (a >= 0 && a < n && b >= 0 && b < m && A[a][b] == 1)
                    {
                        A[a][b] = 2;
                        time[a, b] = time[i, j] + 1;
                        queue.Enqueue(new KeyValuePair<int, int>(a, b));
                    }
                }
            }
            return ans;
        }

        public static int BipartiteGraph(int A, List<List<int>> B)
        {
            List<List<int>> graph = new List<List<int>>();
            for(int i = 0; i <= A;i++)
            {
                graph.Add(new List<int>());
            }
            for(int i = 0; i < B.Count(); i++)
            {
                graph[B[i][0]].Add(B[i][1]);
                graph[B[i][1]].Add(B[i][0]);
            }
            int[] c = new int[A+1];
            for(int i = 0; i < A; i++)
            {
                if(c[i] != 0)
                {
                    continue;
                }
                c[i+1] = 1;
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(i);
                while(queue.Count() > 0)
                {
                    int u = queue.Dequeue();
                    for(int j = 0; j < graph[u].Count(); j++)
                    {
                        int v = graph[u][j];
                        if(c[u] == c[v])
                        {
                            return 0;
                        }
                        if(c[v] == 0)
                        {
                            c[v] = 3 - c[u];
                            queue.Enqueue(v);
                        }
                    }
                }
            }
            return 1;
  
        }

        public static int Solve1(int A, List<List<int>> B)
        {
            int n = B.Count();
            List<List<int>> graph = new List<List<int>>();
            for (int i = 0; i <= A; i++)
            {
                graph.Add(new List<int>());
            }
            for (int i = 0; i < n; i++)
            {
                graph[B[i][0]].Add(B[i][1]);
                graph[B[i][1]].Add(B[i][0]);
            }
            int[] c = new int[A + 1];
            for (int i = 1; i <= n; i++)
            {
                if (c[i] != 0)
                {
                    continue;
                }
                c[i] = 1;
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(i);
                while (queue.Count() > 0)
                {
                    int u = queue.Dequeue();
                    for (int j = 0; j < graph[u].Count(); j++)
                    {
                        int v = graph[u][j];
                        if (c[u] == c[v])
                        {
                            return 0;
                        }
                        if (c[v] == 0)
                        {
                            c[v] = 3 - c[u];
                            queue.Enqueue(v);
                        }
                    }
                }
            }
            long count1 = 0, count2 = 0, ans = 0;
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 1)
                {
                    count1++;
                }
                if (c[i] == 2)
                {
                    count2++;
                }
            }
            ans = (count1 * count2);
            ans %= 1000000007;
            ans -= A;
            ans %= 1000000007;
            return (int)ans;
        }

        public static List<int> TopologicalSort(int A, List<List<int>> B)
        {
            List<int> ans = new List<int>();
            int[] incoming = new int[A + 1];
            List<List<int>> graphs = new List<List<int>>();
            for (int i = 0; i <= A; i++)
            {
                graphs.Add(new List<int>());
            }
            for (int i = 0; i < B.Count(); i++)
            {
                graphs[B[i][0]].Add(B[i][1]);
            }
            for (int i = 0; i < graphs.Count(); i++)
            {
                for(int j = 0; j < graphs[i].Count(); j++)
                {
                    incoming[graphs[i][j]]++;

                }
            }
            PriorityQueue<int> queue = new PriorityQueue<int>();
            for (int i = 1; i <= A; i++)
            {
                if (incoming[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                ans.Add(u);
                for (int i = 0; i < graphs[u].Count(); i++)
                {
                    int v = graphs[u][i];
                    incoming[v]--;
                    if (incoming[v] == 0)
                    {
                        queue.Enqueue(v);
                    }
                }
            }
            for (int i = 1; i < incoming.Count(); i++)
            {
                if (incoming[i] > 0)
                {
                    return new List<int>();
                }
            }
            return ans;
        }


        public static List<List<int>> Solve(List<List<int>> A)
        {
            int n = A.Count(), m = A[0].Count();
            int[,] temp = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    temp[i,j] = int.MaxValue;
                }
            }
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        temp[i,j] = Math.Min(temp[i,j], A[i][k] + A[k][j]);
                    }
                }
            }
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    A[i][j] = temp[i, j];
                }
            }
            return A;

        }
    }
}
