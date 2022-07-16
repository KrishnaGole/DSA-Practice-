using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking
{
    class Program
    {
        static List<List<int>> ans = new List<List<int>>();
        static void Main(string[] args)
        {
            //var result =   Subsets(new List<int>() { 15, 20, 12, 19, 4 });
            //List<List<int>> Appoitments = new List<List<int>>();
            //Appoitments.Add(new List<int> { 6, 7 });
            //Appoitments.Add(new List<int> { 2, 4 });
            //Appoitments.Add(new List<int> { 8, 12 });
            //Appoitments =  Appoitments.OrderBy(a => a[0]).ToList();
           var result =  SolveNQueens(4);
           



        }

        public static List<List<int>> Subsets(List<int> A)
        {
            PrintSubSet(A, A.Count(), 0, new List<int>());
            ans.Sort((o1, o2) => {

                //if (o1.Count() > o2.Count())
                //{
                //    return 1;
                //}
                //else if(o1.Count() == o2.Count())
                //{
                //    for(int i = 0; i < o1.Count(); i++)
                //    {
                //        if(o1[i] > o2[i])
                //        {
                //            return 1;
                //        }
                //    }
                //    return -1;
                //}
                //else
                //{
                //    return -1;
                //}
                if (o1.Count() == 0)
                {
                    return -1;
                }
                if (o2.Count() == 0)
                {
                    return 1;
                }
                for (int i = 0; i < Math.Min(o1.Count(), o2.Count()); i++)
                {
                    if (o1[i] < o2[i])
                    {
                        return -1;
                    }
                    if(o1[i] == o2[i])
                    {
                        if(o1.Count() < o2.Count())
                        {
                            return -1;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                }
                return 1;
            });
            return ans;



        }

        public static void PrintSubSet(List<int> A, int n, int i, List<int> arr)
        {
            if (i == n)
            {
                List<int> temp = new List<int>();
                foreach(var item in arr)
                {
                    temp.Add(item);
                }
                ans.Add(temp);
                return;
            }
            arr.Add(A[i]);
            PrintSubSet(A, n, i + 1, arr);
            arr.RemoveAt(arr.Count() - 1);
            PrintSubSet(A, n, i + 1, arr);
        }

        public static List<List<string>> SolveNQueens(int A)
        {
            List<List<string>> mat = new List<List<string>>();
            List<List<string>> ans = new List<List<string>>();
            for (int i = 0; i < A; i++)
            {
                List<string> temp = new List<string>();
                for(int j = 0; j < A; j++)
                {
                    temp.Add(".");
                }
                mat.Add(temp);
            }
            Queens(mat, A, 0, ans);
            
            return ans;
        }

        public static void Queens(List<List<string>> mat, int n, int i, List<List<string>> ans)
        {
            if (i == n)
            {
                List<string> temp = new List<string>();
                string res = string.Empty;
                //foreach (var item in mat)
                //{
                //    foreach(var ele in item)
                //    {
                //       res += ele;
                //    }
                //    if(mat.Count() > 1)
                //    {
                //        res += " ";
                //    }
                   
                //}

                for(int j = 0; j < mat.Count(); j++)
                {
                    for(int k = 0; k < mat[j].Count(); k++)
                    {
                        res += mat[j][k];
                    }
                    if(j != mat.Count() - 1)
                    {
                        res += " ";
                    }
                    
                }
                temp.Add(res);
                ans.Add(temp);
                return;
            }
            for (int j = 0; j < n; j++)
            {
                if (Check(mat, i, j, n))
                {
                    mat[i][j] = "Q";
                    Queens(mat, n, i + 1, ans);
                    mat[i][j] = ".";
                }
            }
        }

        public static bool Check(List<List<string>> mat, int i, int j, int n)
        {
            int r = 0, c = 0;
            for (r = 0; r < i; r++)
            {
                if (mat[r][j] == "Q")
                {
                    return false;
                }
            }
            r = i; c = j;
            while (r >= 0 && c >= 0)
            {
                if (mat[r][c] == "Q")
                {
                    return false;
                }
                r--;
                c--;
            }
            r = i; c = j;
            while (r >= 0 && c < n)
            {
                if (mat[r][c] == "Q")
                {
                    return false;
                }
                r--;
                c++;
            }
            return true;
        }


    }
}
