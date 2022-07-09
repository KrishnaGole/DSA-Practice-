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
            TreeNode treeNode = new TreeNode(1);
            treeNode.left = new TreeNode(2);
            treeNode.left.left = new TreeNode(3);
            treeNode.left.right = new TreeNode(4);
            treeNode.right = new TreeNode(2);
            treeNode.right.left = new TreeNode(4);
            treeNode.right.right = new TreeNode(3);
            IsSymmetric(treeNode);

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
    }

    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { this.val = x; this.left = this.right = null; }
    }
}
