

public class TrieNode
{
    public TrieNode[] Children { get; } = new TrieNode[2];
    public int Count { get; set; }
}

public class Trie
{
    private readonly TrieNode root = new TrieNode();

    public void Insert(int num)
    {
        TrieNode node = root;
        for (int i = 31; i >= 0; i--)
        {
            int bit = (num >> i) & 1;
            if (node.Children[bit] == null)
            {
                node.Children[bit] = new TrieNode();
            }
            node = node.Children[bit];
            node.Count++;
        }
    }

    public int Query(int num, int limit)
    {
        TrieNode node = root;
        int result = 0;
        for (int i = 31; i >= 0; i--)
        {
            int bitNum = (num >> i) & 1;
            int bitLimit = (limit >> i) & 1;

            if (bitLimit == 1) // If the limit's bit is 1
            {
                if (node.Children[bitNum] != null)
                {
                    result += node.Children[bitNum].Count;
                }
                node = node.Children[1 - bitNum];
            }
            else // If the limit's bit is 0
            {
                node = node.Children[bitNum];
            }

            if (node == null)
            {
                break;
            }
        }
        return result;
    }
}

public class Solution
{
    public static int Solve(List<int> A, int B)
    {
        int N = A.Count;
        Trie trie = new Trie();
        int xorValue = 0;
        int count = 0;
        int MOD = 1000000007;

        trie.Insert(0); // Insert the initial 0 into the trie
        for (int i = 0; i < N; i++)
        {
            xorValue ^= A[i];
            count += trie.Query(xorValue, B);
            count %= MOD;
            trie.Insert(xorValue);
        }

        return count;
    }
    public static void Main()
    {
        Solve(new List<int>() { 8, 3, 10, 2 }, 6);
    }
}
