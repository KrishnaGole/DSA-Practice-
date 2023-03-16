using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    internal class Program
    {
        static List<List<int>> ans = new List<List<int>>();
        static List<int> path = new List<int>();
        static List<int> inOrderList = new List<int>();
        static TreeNode1 prev = null;
        static int sum = 0;

        static void Main(string[] args)
        {
            TreeNode treeNode = new TreeNode(5);
            treeNode.left = new TreeNode(3);
            treeNode.left.left = new TreeNode(4);
            treeNode.left.right = new TreeNode(6);
            treeNode.right = new TreeNode(7);
            treeNode.right.right = new TreeNode(5);
            treeNode.right.left = new TreeNode(6);

            TreeNode1 treeNode1 = new TreeNode1(20);
            treeNode1.left = new TreeNode1(8);
            treeNode1.right = new TreeNode1(22);


            

            Solve2(treeNode1);
            //treeNode.right.left = new TreeNode(4);
            //treeNode.right.right = new TreeNode(3);
            //IsSymmetric(treeNode);
            //Solve(treeNode, new List<int>() { 19, 8, 16, 5, 9 });

            //TreeLinkNode treeLinkNode = new TreeLinkNode(1);
            //treeLinkNode.left = new TreeLinkNode(2);
            //treeLinkNode.right = new TreeLinkNode(5);
            //treeLinkNode.left.left = new TreeLinkNode(3);
            //treeLinkNode.left.right = new TreeLinkNode(4);
            //treeLinkNode.right.right = new TreeLinkNode(7);

            //Connect(treeLinkNode);

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

        public static List<List<int>> Solve(TreeNode A)
        {
            LeafNodePath(A);
            return ans;
        }
        public static void LeafNodePath(TreeNode A)
        {
            if (A == null)
            {
                return;
            }
            path.Add(A.val);
            if (A.left == null && A.right == null)
            {
                ans.Add(new List<int>(path));
                path.RemoveAt(path.Count - 1);
                return;
                
            }
            LeafNodePath(A.left);
            LeafNodePath(A.right);
            path.RemoveAt(path.Count - 1);
        }

        public static int Solve1(TreeNode A)
        {
            if (A == null)
            {
                return 0;
            }
            int leftSum = 0, rightSum = 0;
            leftSum = TreeSum(A.left);
            sum = 0;
            rightSum = TreeSum(A.right);
            if (Math.Abs(leftSum - rightSum) == A.val)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public static int TreeSum(TreeNode A)
        {
            if (A == null)
            {
                return sum;
            }
            sum += A.val;
            TreeSum(A.left);
            TreeSum(A.right);
            return sum;
        }

        static TreeNode1 Solve2(TreeNode1 A)
        {
            TreeNode1 dummy = new TreeNode1(-1);
            prev = dummy;
            InOrder(A);
            return dummy.right;
            
        }

        static void InOrder(TreeNode1 A)
        {
           if(A == null)
           {
               return;
           }
           InOrder(A.left);
           prev.right = A;
           A.left = prev;
           prev = prev.right;
           InOrder(A.right);
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

    class TreeNode1
    {
        public int val;
        public TreeNode1 left, right;
        public TreeNode1(int x)
        {
            val = x;
            left = right = null;
        }
    }
}
