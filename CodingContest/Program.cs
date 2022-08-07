using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var ans =  Solve(new List<int>() { 1,2,3});
            //List<int> input = new List<int>() { -7, -6, 7, 10, -1, -9, -8, 7, -5, -4, -4, 1, 6, 5, 7, 1, 3, -2, 9, -8, -6, -9, -4, -5 };
            //var result = TwoSum(input, -2);
            List<List<int>> vs = new List<List<int>>() {
                new List<int>(){ 0,0, 0 },
                new List<int>(){ 0,1, 0 },
                new List<int>(){ 0,0, 0 },
               

            };
            //List<List<string>> products = new List<List<string>>()
            //{
            //    new List<string>(){"10", "sale", "january-sale"},
            //    new List<string>(){"200", "sale", string.Empty}
            //};
            //List<List<string>> discounts = new List<List<string>>()
            //{
            //    new List<string>(){"sale", "0", "10"},
            //    new List<string>(){ "january-sale", "1","10"}
            //};

            //FindLowestPrice(products, discounts);
            //UniquePathsWithObstacles(vs);
        }

        public static long Solve(List<int> A)
        {
            List<int> pq = new List<int>();
            int n = A.Count(); long res = 0;
            for (int i = 0; i < n; i++)
            {
                pq.Add(A[i]);
            }

            while (pq.Count() > 1)
            {
                pq.Sort();
                int a = pq[0];
                int b = pq[1];
                pq.RemoveAt(0);
                pq.RemoveAt(0);
                res = res + (a + b);
                pq.Add(a + b);

            }
            return res;
        }


        public static List<int> TwoSum(List<int> A, int B)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            
            for (int i = 0; i < A.Count(); i++)
            {
                if (map.ContainsKey(B - A[i]))
                {
                    return new List<int>() { ++map[B - A[i]], ++i };

                }
                else if (!map.ContainsKey(A[i]))
                {
                    map.Add(A[i], i);
                }
                

                
            }


            return new List<int>();
        }

      


        public static int FindLowestPrice(List<List<string>> products, List<List<string>> discounts)
        {
            int noOfProducts = products.Count(), totalPurchaseCose = 0;
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            for (int i = 0; i < discounts.Count(); i++)
            {
                keyValuePairs.Add(discounts[i][0], discounts[i][1] + "@" + discounts[i][2]);
            }
            for (int i = 0; i < noOfProducts; i++)
            {
                decimal productCost = Convert.ToDecimal(products[i][0]);
                for (int k = 1; k < products[i].Count(); k++)
                {
                    for (int j = 0; j < discounts.Count(); j++)
                    {
                        if (discounts[j][0] == products[i][k])
                        {
                            switch (discounts[j][1])
                            {
                                case "0":
                                    productCost = Math.Round(Math.Min(productCost, Convert.ToDecimal(discounts[j][2])));
                                    break;
                                case "1":
                                    decimal t = (Convert.ToDecimal(discounts[j][2]) / 100) * Convert.ToDecimal(products[i][0]);
                                    productCost = Math.Round(Math.Min(productCost, Convert.ToDecimal(products[i][0]) - t));
                                    break;
                                case "2":
                                    productCost = Math.Round(Math.Min(productCost, Convert.ToDecimal(products[i][0]) - Convert.ToDecimal(discounts[j][2])));
                                    break;
                            }
                        }
                    }
                    if (keyValuePairs.ContainsKey(products[i][k]))
                    {
                        //keyValuePairs.TryGetValue()
                        //var temp = keyValuePairs.TryGetValue(products[i][k]).Split('@');
                        //switch (keyValuePairs[temp[0]])
                        //{

                        //    case "0":
                        //        productCost = Math.Round(Math.Min(productCost, Convert.ToDecimal(temp[1])));
                        //        break;
                        //    case "1":
                        //        decimal t = (Convert.ToDecimal(temp[1]) / 100) * Convert.ToDecimal(products[i][0]);
                        //        productCost = Math.Round(Math.Min(productCost, Convert.ToDecimal(products[i][0]) - t));
                        //        break;
                        //    case "2":
                        //        productCost = Math.Round(Math.Min(productCost, Convert.ToDecimal(products[i][0]) - Convert.ToDecimal(temp[1])));
                        //        break;
                        //}
                    }

                }
                totalPurchaseCose += (int)productCost;

            }
            return totalPurchaseCose;
        }

        public static long MaximumProfit(List<int> inventory, long order)
        {
            Dictionary<long, long> map = new Dictionary<long, long>();
            long maxProfit = 0;
            inventory.Sort();
            for (int i = 0; i < inventory.Count(); i++)
            {
                if (!map.ContainsKey(inventory[i]))
                {
                    map.Add(inventory[i], 1);
                }
                else
                {
                    map[inventory[i]]++;
                }
            }
            while (order > 0)
            {
                long temp = inventory[inventory.Count() - 1];
                if (map.ContainsKey(temp))
                {
                    if (map[temp] <= order)
                    {
                        maxProfit += map[temp] * temp;
                    }
                    else
                    {
                        maxProfit += order * temp;
                    }
                }
                inventory[inventory.Count() - 1] = (int)temp - 1;
                var inven = inventory.Distinct().ToList();
                if (!map.ContainsKey(temp - 1))
                {
                    map.Add(temp - 1, map[temp]);
                }
                else
                {
                    map[temp - 1] += map[temp - 1] + inventory.Count() - inven.Count();
                }
                inventory = inven;

                order--;
            }
            return maxProfit;

        }



    }
}
