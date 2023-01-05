using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeNode treeNode = new TreeNode(13);
            treeNode.left = new TreeNode(19);
            treeNode.left.left = new TreeNode(24);
            treeNode.left.right = new TreeNode(36);
            treeNode.right = new TreeNode(27);
            treeNode.right.right = new TreeNode(44);
            treeNode.right.left = new TreeNode(10);
            //treeNode.right.left = new TreeNode(4);
            //treeNode.right.right = new TreeNode(3);
            //IsSymmetric(treeNode);
            //Solve(treeNode, new List<int>() { 19, 8, 16, 5, 9 });

            TreeLinkNode treeLinkNode = new TreeLinkNode(1);
            treeLinkNode.left = new TreeLinkNode(2);
            treeLinkNode.right = new TreeLinkNode(5);
            treeLinkNode.left.left = new TreeLinkNode(3);
            treeLinkNode.left.right = new TreeLinkNode(4);
            treeLinkNode.right.right = new TreeLinkNode(7);

            Connect(treeLinkNode);

        }

        public static int IsSymmetric(TreeNode A)
        {
            TreeNode actual = A;
            Invert(A);
            return Compare(A, actual);
        }
        public static void Invert(TreeNode A)
        {
            if (A == null)
            {
                return;
            }
            Invert(A.left);
            Invert(A.right);
            TreeNode temp = A.left;
            A.left = A.right;
            A.right = temp;
        }

        public static int Compare(TreeNode A, TreeNode B)
        {
            if (A == null & B == null)
            {
                return 1;
            }
            if (A == null || B == null)
            {
                return 0;
            }
            if (A.val != B.val)
            {
                return 0;
            }
            return Compare(A.left, B.left) & Compare(A.right, B.right);

        }

        public static List<List<int>> Solve(TreeNode A, List<int> B)
        {
            List<int> treeNodeList = new List<int>();
            InOrder(A, treeNodeList);
            treeNodeList.Sort();
            int n = B.Count;
            List<List<int>> ans = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                int low = 0, high = treeNodeList.Count, floor = -1, ceil = -1;
                while (low <= high)
                {
                    int mid = (low + high) / 2;
                    if(mid == treeNodeList.Count)
                    {
                        break;
                    }
                    if (treeNodeList[mid] <= B[i])
                    {
                        floor = treeNodeList[mid];
                    }
                    if (treeNodeList[mid] < B[i])
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
                low = 0;
                high = treeNodeList.Count;
                while (low <= high)
                {
                    int mid = (low + high) / 2;
                    if (mid == treeNodeList.Count)
                    {
                        break;
                    }
                    if (treeNodeList[mid] >= B[i])
                    {
                        ceil = treeNodeList[mid];
                    }
                    if (treeNodeList[mid] < B[i])
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
                ans.Add(new List<int>() { floor, ceil });
            }
            return ans;

        }

        public static void InOrder(TreeNode treeNode, List<int> treeNodeList)
        {
            if (treeNode == null)
            {
                return;
            }
            InOrder(treeNode.left, treeNodeList);
            treeNodeList.Add(treeNode.val);
            InOrder(treeNode.right, treeNodeList);
        }

        public static void Connect(TreeLinkNode root)
        {
            TreeLinkNode temp = root;
            while(temp.left != null)
            {
                TreeLinkNode curr = temp;
                while(temp != null)
                {
                    temp.left.next = temp.right;
                    if(temp.next != null)
                    {
                        temp.right.next = temp.next.left;
                    }
                    temp = temp.next;
                }
                temp = curr.left;
            }

        }
    }

    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { this.val = x; this.left = this.right = null; }
    }

    class TreeLinkNode
    {
      public int val;
      public TreeLinkNode left;
      public TreeLinkNode right, next;
      public TreeLinkNode(int x) { this.val = x; this.left = this.right = null; this.next = null; }
    }
}
