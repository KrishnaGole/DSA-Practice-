using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTree
{
    class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { this.val = x; this.left = this.right = null; }
    }
   internal class Program
    {
        static Dictionary<int, int> map = new Dictionary<int, int>();
        List<int> path = new List<int>();
        public List<List<int>> solve(TreeNode A)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            List<List<int>> levelOrderList = new List<List<int>>();
            List<List<int>> result = new List<List<int>>();
            List<int> temp = new List<int>();
            queue.Enqueue(A);
            queue.Enqueue(null);
            while (queue.Count() > 0)
            {
                TreeNode t = queue.Dequeue();
                if (t == null)
                {
                    if (queue.Count() > 0)
                    {
                        queue.Enqueue(null);
                    }
                    levelOrderList.Add(temp);
                    temp = new List<int>();
                }
                else
                {
                    temp.Add(t.val);
                    if (t.left != null)
                    {
                        queue.Enqueue(t.left);
                    }
                    if (t.right != null)
                    {
                        queue.Enqueue(t.right);
                    }
                }
            }
            temp = levelOrderList[levelOrderList.Count() - 1];
            for (int i = 0; i < temp.Count(); i++)
            {
                path = new List<int>();
                check(A, temp[i]);
                result.Add(path);
            }
            return result;

        }

        public bool check(TreeNode root, int target)
        {
            if (root == null)
            {
                return false;
            }
            if (root.val == target)
            {
                path.Add(root.val);
                return true;
            }
            if (check(root.left, target) || check(root.right, target))
            {
                path.Add(root.val);
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            //17 29 10 15 28 28 29 4 4 - 1 - 1 - 1 - 1 - 1 - 1 - 1 - 1 - 1
            TreeNode treeNode = new TreeNode(1);
             treeNode.left = new TreeNode(4);
             treeNode.right = new TreeNode(9);
             treeNode.right.left = new TreeNode(-8);



            //treeNode.left = new TreeNode(2);
            //treeNode.right = new TreeNode(7);
            //treeNode.left.left = new TreeNode(1);
            //treeNode.left.right = new TreeNode(3);
            //treeNode.left.right.right = new TreeNode(4);
            //treeNode.left.right.right.right = new TreeNode(5);
            //treeNode.left.right = new TreeNode(3);
            //treeNode.right.right = new TreeNode(3);

            //TreeNode treeNode1 = new TreeNode(5);
            //treeNode1.left = new TreeNode(2);
            //treeNode1.right = new TreeNode(2);
            //treeNode1.left.right = new TreeNode(3);
            //treeNode1.right.right = new TreeNode(3);
            //treeNode1.left.right.left = new TreeNode(4);
            //treeNode1.right.right.right = new TreeNode(5);

            //Solve(treeNode, treeNode1);

            //TSum(treeNode, 40);




            //treeNode.right.right.left = new TreeNode(6);

            //LevelOrder(treeNode);
            //LeftView(treeNode);
            //VerticalOrderTraversal(treeNode);
            //DiagonalTraversal(treeNode);
            //SortedArrayToBST(new List<int>() { 90, 228, 245, 290, 397, 471, 572, 649, 688, 710, 823, 829, 830, 859, 932, 939, 962 });
            //IsSymmetric(null);
            //Solve(treeNode);
            //Kthsmallest(treeNode, 1);
            //Solve(treeNode, 10);
            //TreeNode node = BuildTree(new List<int>() { 6, 1, 3, 2 }, new List<int>() { 6, 3, 2, 1 });
            List<int> preOrder = new List<int>() { 1, 5, 6, 4 };
            TreeNode root = null;
            for(int i = 0; i < preOrder.Count(); i++)
            {
                root = Insert(root, preOrder[i]);
            }
        }

        public static List<List<int>> LevelOrder(TreeNode A)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            List<List<int>> ans = new List<List<int>>();
            List<int> temp = new List<int>();
            queue.Enqueue(A);
            queue.Enqueue(null);
            while (queue.Count() > 0)
            {
                TreeNode t = queue.Dequeue();
                if (t == null)
                {
                    ans.Add(temp);
                    temp = new List<int>();
                    if (queue.Count() > 0)
                    {
                        queue.Enqueue(null);
                    }
                }
                else
                {
                    temp.Add(t.val);
                    if (t.left != null)
                    {
                        queue.Enqueue(t.left);
                    }
                    if (t.right != null)
                    {
                        queue.Enqueue(t.right);
                    }
                }
            }
            return ans;
        }

        public static List<int> LeftView(TreeNode A)
        {
            List<int> leftView = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(A);
            queue.Enqueue(null);
            while (queue.Count() > 0)
            {
                TreeNode t = queue.Dequeue();
                if (t == null){
                    if(queue.Count() > 0){
                        queue.Enqueue(null);
                    }
                }
                else
                {
                    if (queue.First() == null)
                    {
                        leftView.Add(t.val);
                    }
                    if (t.right != null)
                    {
                        queue.Enqueue(t.right);
                    }
                    if (t.left != null)
                    {
                        queue.Enqueue(t.left);
                    }
                   
                }
            }
            return leftView;

        }

        public static List<List<int>> VerticalOrderTraversal(TreeNode A)
        {
            List<List<int>> ans = new List<List<int>>();
            Queue<KeyValuePair<TreeNode, int>> keyValuePairsQueue = new Queue<KeyValuePair<TreeNode, int>>();
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            keyValuePairsQueue.Enqueue(new KeyValuePair<TreeNode, int>(A, 0));
            int min = int.MaxValue, max = int.MinValue;
            while(keyValuePairsQueue.Count() > 0)
            {
                var t = keyValuePairsQueue.Dequeue();
                min = Math.Min(min, t.Value);
                max = Math.Max(max, t.Value);
                if (map.ContainsKey(t.Value))
                {
                    map[t.Value].Add(t.Key.val);
                }
                else
                {
                    map.Add(t.Value, new List<int>() { t.Key.val });
                }
                if(t.Key.left != null)
                {
                    keyValuePairsQueue.Enqueue( new KeyValuePair<TreeNode, int>(t.Key.left, t.Value - 1));
                }
                if (t.Key.right != null)
                {
                    keyValuePairsQueue.Enqueue(new KeyValuePair<TreeNode, int>(t.Key.right, t.Value + 1));
                }
            }
            for(int i = min; i <= max; i++)
            {
                ans.Add(map[i]);
            }
            return ans;

        }

        public static List<int> DiagonalTraversal(TreeNode A)
        {
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            List<int> ans = new List<int>();
            PreOrder(A, 0, map);
            foreach(var levels in map.OrderBy(x => x.Key))
            {
                ans.AddRange(levels.Value);
            }
            return ans;

        }

        public static TreeNode SortedArrayToBST(List<int> A)
        {
            List<int> vs = new List<int>() { 1, 2, 3, 5, 10 };
            var result =  BST(vs, 0, vs.Count -1);
            return result;
        }

        public static TreeNode BST(List<int> A, int start, int end)
        {
            if(start > end)
            {
                return null;
            }
            int mid = (start + end) / 2;
            TreeNode node = new TreeNode(A[mid]);
            node.left = BST(A, start, mid - 1);
            node.right = BST(A, mid + 1, end);
            return node;

        }

        public static void PreOrder(TreeNode A, int t, Dictionary<int, List<int>> map)
        {
            if (A == null)
            {
                return;
            }
            if (map.ContainsKey(t))
            {
                map[t].Add(A.val);
            }
            else
            {
                map.Add(t, new List<int>() { A.val });
            }
            PreOrder(A.left, t + 1, map);
            PreOrder(A.right, t, map);
        }

        public static int IsSymmetric(TreeNode A)
        {
            if (isSymmetric(A.left, A.right))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static bool isSymmetric(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
            {
                return true;
            }
            if ((left == null && right != null) || (left != null && right == null))
            {
                return false;
            }
            if (left.val != right.val)
            {
                return false;
            }
            isSymmetric(left.right, right.left);
            isSymmetric(left.left, right.right);
            return true;
        }

        public List<int> recoverTree(TreeNode A)
        {
            List<int> inorderList = inorder(A, new List<int>());
            int i = 0;
            for (i = 0; i < inorderList.Count() - 1; i++)
            {
                if (inorderList[i] > inorderList[i + 1])
                {
                    break;
                }
            }
            return new List<int>() { inorderList[i + 1], inorderList[i] };

        }
        public List<int> inorder(TreeNode A, List<int> inorderList)
        {
            if (A == null)
            {
                return inorderList;
            }
            inorder(A.left, inorderList);
            inorderList.Add(A.val);
            inorder(A.right, inorderList);
            return inorderList;
        }

        public static int Solve(TreeNode A, TreeNode B)
        {
            long ans = 0;
            int mod = 1000000007;
            Dictionary<int, int> map = new Dictionary<int, int>();
            Inoder(A, map);
            Inoder(B, map);
            
            foreach (var item in map)
            {
                if(item.Value >= 2)
                {
                    ans += item.Key;
                    ans %= mod;
                }
            }
            return (int)ans;
        }

        public static Dictionary<int, int> Inoder(TreeNode A, Dictionary<int, int> treeMap)
        {
            if (A == null)
            {
                return treeMap;
            }
            Inoder(A.left, treeMap);
            if (treeMap.ContainsKey(A.val))
            {
                treeMap[A.val]++;
            }
            else
            {
                treeMap.Add(A.val, 1);
            }
            Inoder(A.right, treeMap);
            return treeMap;
        }

        public static int TSum(TreeNode A, int B)
        {
            HashSet<int> hashSet = new HashSet<int>();
            InOrder(A, hashSet);
            foreach (int val in hashSet)
            {
                if (B - val != val && hashSet.Contains(B - val))
                {
                    return 1;
                }
            }
            return 0;



        }

        public static HashSet<int> InOrder(TreeNode A, HashSet<int> treeOrderSet)
        {
            if (A == null)
            {
                return treeOrderSet;
            }
            InOrder(A.left, treeOrderSet);
            treeOrderSet.Add(A.val);
            InOrder(A.right, treeOrderSet);
            return treeOrderSet;
        }


        /// <summary>
        /// Sum binary tree or not
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int Solve(TreeNode A)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            List<List<int>> levelOrder = new List<List<int>>();
            queue.Enqueue(A);
            queue.Enqueue(null);
            List<int> levels = new List<int>();
            while (queue.Count() > 0)
            {
                TreeNode temp = queue.Dequeue();
                if (temp == null)
                {
                    levelOrder.Add(levels);
                    levels = new List<int>();
                    if (queue.Count() > 0)
                    {
                        queue.Enqueue(null);
                    }
                    continue;
                }
               
                levels.Add(temp.val);
                if (temp.left != null)
                {
                    queue.Enqueue(temp.left);
                }
                if (temp.right != null)
                {
                    queue.Enqueue(temp.right);
                }
                
            }
            int n = levelOrder.Count(), sum = levelOrder[n - 1].Sum();
            for (int i = n - 2; i >= 0; i--)
            {
                int currSum = levelOrder[i].Sum();
                if (sum != currSum)
                {
                    return 0;
                }
                sum += currSum;
            }
            return 1;
        }

        public static int k = 0;
        public static int Kthsmallest(TreeNode A, int B)
        {
            k = B;
            var result =  InOrder(A);
            return result;
        }

        public static int InOrder(TreeNode A)
        {
            if (A == null)
            {
                return 0;
            }
            int k1 = InOrder(A.left);
            if(k == 0)
            {
                return k1;
            }
            k--;
            if(k == 0)
            {
                return A.val;
            }
            return InOrder(A.right);
        }

        public bool compare(TreeNode A, TreeNode B)
        {
            if (A == null && B == null)
            {
                return true;
            }
            if (A.left?.val != B.left?.val)
            {
                TreeNode temp = A.right;
                A.right = A.left;
                A.left = temp;
            }
            if (A.right?.val != B.right?.val)
            {
                TreeNode temp = A.left;
                A.left = A.right;
                A.right = temp;
            }
            if (A.left?.val != B.left?.val || A.right?.val != B.right?.val)
            {
                return false;
            }
            else
            {
                return compare(A.left, B.left) && compare(A.right, B.right); 
            }
        }


        public static int count = 0;
        public static int sum = 0;
        public static int Solve(TreeNode A, int B)
        {
            sum = 0;
            IsEqualToB(A, B);
            //if(A.val + A.left?.val == B)
            //{
            //    count++;
            //}
            //if(A.val + A.right?.val == B)
            //{
            //    count++;
            //}
            //int leftSum = IsEqualToB(A.left, B);
            //if (leftSum + A.val == B)
            //{
            //    count++;
            //}
            //sum = 0;
            //int rightSum = IsEqualToB(A.right, B);
            //if (rightSum + A.val == B)
            //{
            //    count++;
            //}
            //if(leftSum == B)
            //{
            //    count++;
            //}
            //if(rightSum == B)
            //{
            //    count++;
            //}


                return count;
        }

        public static int IsEqualToB(TreeNode A, int B)
        {
            if (A == null)
            {
                return sum;
            }
            if (A.val == B)
            {
                count++;
            }
            sum += A.val;
            if (sum == B)
            {
                count++;
            }
            //int leftSum = A.left != null ? IsEqualToB(A.left, B) : 0;
            //int rightSum = A.right != null ? IsEqualToB(A.right, B) : 0;
            IsEqualToB(A.left, B);
            IsEqualToB(A.right, B);
            return sum;
                //+ leftSum + rightSum;
        }

        public static TreeNode BuildTree(List<int> A, List<int> B)
        {
            int n = A.Count(), m = B.Count();
            for (int i = 0; i < n; i++)
            {
                map.Add(A[i], i);
            }
            //B.Reverse();
            return CBT(B, m-1, 0, A, 0, n - 1);
        }

        public static TreeNode CBT(List<int> postOrder, int postStart, int postEnd, List<int> inOrder, int inStart, int inEnd)
        {
            if (postEnd > postStart)
            {
                return null;
            }
            TreeNode root = new TreeNode(postOrder[postEnd]);
            int idx = map[root.val];
            int n = idx - inStart;
            root.left = CBT(postOrder, postEnd - n, postStart, inOrder, inStart, idx - 1);
            root.right = CBT(postOrder, postStart + n + 1, postEnd, inOrder, idx + 1, inEnd);
           // root.right = CBT(postOrder, postStart + n + 1, postEnd, inOrder, idx + 1, inEnd);
            //root.left = CBT(postOrder, postStart + 1, postStart + n, inOrder, inStart, idx - 1);

            return root;
        }

        public static TreeNode Insert(TreeNode root, int element)
        {
            if(root == null)
            {
                root = new TreeNode(element);
                return root;
            }
            var parent = root;
            var curr = root;
            while (curr != null)
            {
                parent = curr;
                if(element <= curr.val)
                {
                    curr = curr.left;
                }
                else
                {
                    curr = curr.right;
                }
            }
            if(element < parent.val)
            {
                parent.left = new TreeNode(element);
            }
            else
            {
                parent.right = new TreeNode(element);
            }
            return root;

        }
    }
}
