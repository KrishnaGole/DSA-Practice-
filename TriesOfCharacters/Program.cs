using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriesOfCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Solve(new List<string>() { "A", "B" }, new List<string>() { "A", "B" });
            Prefix(new List<string>() { "zebra", "dog", "duck", "dove" });
        }

        /// <summary>
        /// Spelling Checker

        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static List<int> Solve(List<string> A, List<string> B)
        {
            int n = A.Count(), m = B.Count();
            List<int> ans = new List<int>();
            Node root = new Node();
            for (int i = 0; i < n; i++)
            {
                Add(root, A[i]);
            }
            // for(int i = 0; i < m; i++){
            //     if(find(root, B[i])){
            //         ans.Add(1);
            //     }
            //     else{
            //         ans.Add(0);
            //     }
            // }
            return ans;

        }

        private static void Add(Node root, string word)
        {
            int n = word.Length;
            for (int i = 0; i < n; i++)
            {
                char ch = word[i];
                if (!root.map.ContainsKey(ch))
                {
                    Node t = new Node();
                    root.map.Add(ch, t);
                }
                root = root.map[ch];
            }
            root.isEnd = true;
        }

        public static List<string> Prefix(List<string> A)
        {
            int n = A.Count();
            Node root = new Node();
            List<string> ans = new List<string>();
            for (int i = 0; i < n; i++)
            {
                Add1(root, A[i]);
            }
            for (int i = 0; i < n; i++)
            {
                ans.Add(Find1(root, A[i]));
            }
            return ans;
        }

        public static void Add1(Node root, string word)
        {
            int n = word.Length;
            for (int i = 0; i < n; i++)
            {
                if (!root.map.ContainsKey(word[i]))
                {
                    root.map.Add(word[i], new Node());
                    root.map[word[i]].cnt = 1;
                }
                else
                {
                    root.map[word[i]].cnt++;
                }
                root = root.map[word[i]];
            }
        }

        public static string Find1(Node root, string word)
        {
            int n = word.Length, lastCharCnt = root.map[word[0]].cnt;
            StringBuilder sb = new StringBuilder();
            sb.Append(word[0]);
            root = root.map[word[0]];
            for (int i = 1; i < n; i++)
            {
                if (root.map.ContainsKey(word[i]) && lastCharCnt > 1)
                {
                    sb.Append(word[i]);
                    lastCharCnt = root.map[word[0]].cnt;
                    root = root.map[word[i]];
                }
                else
                {
                    return sb.ToString();
                }
            }
            return sb.ToString();
        }
    }

    public class Node
    {
        public Dictionary<char, Node> map;
        public bool isEnd;
        public int cnt;
        public Node()
        {
            map = new Dictionary<char, Node>();
        }
    }

}
