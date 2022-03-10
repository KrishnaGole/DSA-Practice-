using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LargestRectangleArea(new int[] { 2, 1, 5, 6, 2, 3 });
            OrderedStream orderedStream = new OrderedStream(5);
            orderedStream.Insert(3, "ccccc");
            orderedStream.Insert(1, "aaaaa");
            orderedStream.Insert(2, "bbbbb");
            orderedStream.Insert(5, "eeeee");
            orderedStream.Insert(4, "ddddd");
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
