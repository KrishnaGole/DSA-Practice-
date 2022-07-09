using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriesOfCharacters
{
    public class MaximumXOR
    {
        public int MaxXOR(List<int> A)
        {
            int max = A.Max(), n = A.Count(), ans = int.MinValue;
            int b = 0;
            while (max > 0)
            {
                max = max >> 1;
                b++;
            }
            Node1 root = new Node1();
            for (int i = 0; i < n; i++)
            {
                Insert(root, A[i], b);
            }

            for (int i = 0; i < n; i++)
            {
                ans = Math.Max(ans, Query(root, A[i], b));
            }

            return ans;
        }

        public void Insert(Node1 root, int element, int b)
        {
            for (int i = b; i >= 0; i--)
            {
                int e = IsBitSet(element, i);
                if (root.nodeList[e] == null)
                {
                    root.nodeList[e] = new Node1();
                }
                root = root.nodeList[e];
            }
        }

        public int Query(Node1 root, int element, int b)
        {
            double ans = 0;
            for (int i = b; i >= 0; i--)
            {
                int ele = IsBitSet(element, i);
                if (root.nodeList[1 - ele] != null)
                {
                    ans += (1 << i);
                    root = root.nodeList[1 - ele];
                }
                else
                {
                    root = root.nodeList[ele];
                }
            }
            return (int)ans;
        }
        public int IsBitSet(int ele, int pos)
        {
            int nRightp = ele >> pos;
            return nRightp & 1;
        }

    }

    public class Node1
    {
        public Node1[] nodeList;
        public Node1()
        {
            nodeList = new Node1[2];
        }
    }
}
