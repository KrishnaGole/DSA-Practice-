using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DP
{
    public class CopilotDemo
    {
        public static void Main(string[] args)
        {
          
        }
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            IList<IList<int>> ans = new IList<IList<int>>();
            IList<int> temp = new IList<int>();
            queue.Enqueue(root);
            queue.Enqueue(null);
            while (queue.Count() > 0)
            {
                TreeNode t = queue.Dequeue();
                if (t == null)
                {
                    ans.Add(temp);
                    temp = new IList<int>();
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
    }
}
