
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Xml;

internal class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello");
        //int[] arr = new int[10] {1,2,3,4,5,0,9,6,20,12 };
        //int expectedSum = 14;
        //int[] result = SumIndexes(arr, expectedSum);
        // int ans = MinFolders(1, 1, 0, 1);
        //Reverse(42);
        //NumUniqueEmails(new string[] { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" });
        //SubdomainVisits(new string[] { "900 google.mail.com", "50 yahoo.com", "1 intel.mail.com", "5 wiki.org" });
        //DecodeString("3[a]2[bc]");
        //ReorganizeString("zhmyo");
        //NumRescueBoats(new int[] { 2,4 }, 5);
        //FindLength(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 });
        //SearchRange(new int[] { 1 }, 1);
        //Exist(new char[][] {
        //    new char[] { 'A', 'B', 'C', 'E' },
        //    new char[] { 'S', 'F', 'C', 'S' },
        //    new char[] { 'A', 'D', 'E', 'F' }
        //}, "ABCCED");
        //CoinChange(new int[] { 1, 2, 5 }, 11);
        LengthOfLongestSubstring("pwwkew");



    }
    public static int[] SumIndexes(int[] ints, int expectedSum)
    {
        Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
        
        for(int i = 0; i < ints.Length; i++)
        {
            keyValuePairs.Add(ints[i], i);
            int complement = expectedSum - ints[i];
            if(keyValuePairs.ContainsKey(complement))
            {
                return new int[] { Math.Min(i, keyValuePairs[complement]), Math.Max(keyValuePairs[complement], i)  };
            }
           
        }
        return new int[] { };
    }

    public static int MinFolders(int cssFiles, int jsFiles, int readMeFiles, int capacity)
    {
        int folder = 0;
        while (cssFiles + jsFiles + readMeFiles > 0)
        {
            int cssCount = 0, jsCount = 0, readmeCount = 0;
            bool hasReadMe = false;
            folder++;
            for (int i = 0; i < capacity; i++)
            {
                if (!hasReadMe && readMeFiles > 0)
                {
                    readMeFiles--;
                    hasReadMe = true;
                    readmeCount++;
                }
                else if (cssFiles > 0 && cssCount <= readmeCount + jsCount)
                {
                    cssCount++;
                    cssFiles--;
                }
                else if (jsFiles > 0 && jsCount <= readmeCount + cssCount)
                {
                    jsFiles--;
                    jsCount++;
                }
            }
        }
        return folder;
    }

    private static int Reverse(int num)
    {
        int rev = 0, cnt = 0;
        while (num > 0)
        {
            rev *= 10;
            rev += num % 10;
           
            cnt++;
            num /= 10;
        }
        return rev;
    }

    public static int NumUniqueEmails(string[] emails)
    {
        int n = emails.Length;
        HashSet<string> uniqueEmails = new HashSet<string>();
        for (int i = 0; i < n; i++)
        {
            string[] temp = emails[i].Split('@');
            string localName = temp[0].Replace(".", string.Empty);
            localName = localName.Split('+')[0];
            string domainName = temp[1];
            uniqueEmails.Add(localName + "@" + domainName);
        }
        return uniqueEmails.Count();
    }

    public static IList<string> SubdomainVisits(string[] cpdomains)
    {
        Dictionary<string, int> map = new Dictionary<string, int>();
        IList<string> result = new List<string>();

        foreach (string cpdomain in cpdomains)
        {
            string[] countedPair = cpdomain.Split(" ");
            int count = Convert.ToInt32(countedPair[0]);
            string domain = countedPair[1];

            string[] spiltedDomain = domain.Split(".");
            for (int i = 0; i < spiltedDomain.Length; i++)
            {
                string subdomain = string.Join(".", spiltedDomain, i, spiltedDomain.Length - i);
                if (map.ContainsKey(subdomain))
                {
                    map[subdomain] += count;
                }
                else
                {
                    map.Add(subdomain, count);
                }
            }
        }

        foreach (var entry in map)
        {
            result.Add($"{entry.Value} {entry.Key}");
        }

        return result;
    }

    //3[a]2[bc]
    public static string DecodeString(string s)
    {
        Stack<int> countStack = new Stack<int>();
        Stack<string> resultStack = new Stack<string>();
        int index = 0;
        string currentString = string.Empty;
        while (index < s.Length)
        {
            char currentChar = s[index];
            if (Char.IsDigit(currentChar))
            {
                int count = 0;
                while (char.IsDigit(s[index]))
                {
                    count = count * 10 + (s[index] - '0');
                    index++;
                }
                countStack.Push(count);
            }
            else if (currentChar == '[')
            {
                resultStack.Push(currentString);
                currentString = string.Empty;
                index++;
            }
            else if (currentChar == ']')
            {
                StringBuilder temp = new StringBuilder(resultStack.Pop());
                int repeatTimes = countStack.Pop();
                for (int i = 0; i < repeatTimes; i++)
                {
                    temp.Append(currentString);
                }
                currentString = temp.ToString();
                index++;
            }
            else
            {
                currentString += currentChar;
                index++;
            }
        }
        return currentString;
    }

    private SortedDictionary<int, int> bookedIntervals = new SortedDictionary<int, int>();

    public bool Book(int start, int end)
    {
        //var overlap = bookedIntervals.(start, end - 1);//bookedIntervals.Where(kv => start < kv.Value && end > kv.Key);
        //if (overlap.Count() > 0)
        //{
        //    return false;
        //}
        //bookedIntervals[start] = end;
        return true;
    }

    public static string ReorganizeString(string s)
    {
        int[] hash = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            hash[s[i] - 'a']++;
        }
        int max = 0, letter = 0;
        for (int i = 0; i < hash.Length; i++)
        {
            if (hash[i] > max)
            {
                max = hash[i];
                letter = i;
            }
        }
        if (max > (s.Length + 1) / 2)
        {
            return string.Empty;
        }
        char[] res = new char[s.Length];
        int idx = 0;
        while (hash[letter] > 0)
        {
            res[idx] = (char)(letter + 'a');
            idx += 2;
            hash[letter]--;
        }
        //idx = 1;
        for (int i = 0; i < hash.Length; i++)
        {
            while (hash[i] > 0)
            {
                if (idx >= res.Length)
                {
                    idx = 1;
                }
                res[idx] = (char)(i + 'a');
                idx += 2;
                hash[i]--;
            }
        }

        return new string(res.ToArray());

    }
    public static int NumRescueBoats(int[] people, int limit)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();
        int cnt = 0;
        for (int i = 0; i < people.Length; i++)
        {
            if (map.ContainsKey(people[i]))
            {
                map[people[i]]++;
            }
            else
            {
                map.Add(people[i], 1);
            }
        }

        for (int i = 0; i < people.Length; i++)
        {
            if (map.ContainsKey(people[i]) && map[people[i]] > 0)
            {
                if (map.ContainsKey(limit - people[i]) && map[limit - people[i]] > 0)
                {
                    cnt++;
                    map[limit - people[i]]--;
                }
                else if (map[people[i]] <= limit)
                {
                    cnt++;
                }

            }
        }
        return cnt;

    }

    public static int FindLength(int[] nums1, int[] nums2)
    {
        int n = nums1.Length, m = nums2.Length, cnt = 0, maxCnt = 0;
        for (int i = 0; i < n; i++)
        {
            cnt = 0;
            int idx = i;
            for (int j = 0; j < m; j++)
            {
                if (idx < n && nums1[idx] == nums2[j])
                {
                    cnt++;
                    idx++;
                }
                else
                {
                    maxCnt = Math.Max(cnt, maxCnt);
                    break;
                }
            }
        }
        return maxCnt;
    }

    public static int[] SearchRange(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (nums[mid] == target && mid + 1 < nums.Length && nums[mid + 1] == target)
            {
                return new int[] { mid, mid + 1 };
            }
            else if (nums[mid] == target && mid + 1 == nums.Length)
            {
                return new int[] { mid, mid };
            }
            else if (nums[mid] < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        return new int[] { -1, -1 };
    }

    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        int target = 0;
        Array.Sort(nums);
        HashSet<List<int>> set = new HashSet<List<int>>();
        List<IList<int>> output = new List<IList<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            int j = i + 1;
            int k = nums.Length - 1;

            while (j < k)
            {
                int sum = nums[i] + nums[j] + nums[k];

                if (sum == target)
                {
                    set.Add(new List<int> { nums[i], nums[j], nums[k] });
                    j++;
                    k--;
                }
                else if (sum < target)
                {
                    j++;
                }
                else
                {
                    k--;
                }
            }
        }

        output.AddRange(set);
        return output;
    }

    public static bool Exist(char[][] board, string word)
    {
        
        int rows = board.Length;
        int cols = board[0].Length;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (ExistRecursive(board, word, i, j, 0))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static bool ExistRecursive(char[][] board, string word, int row, int col, int index)
    {
        if (index == word.Length)
        {
            return true; // All characters in the word have been found
        }

        // Check boundaries and if the current cell matches the current character in the word
        if (row < 0 || row >= board.Length || col < 0 || col >= board[0].Length || board[row][col] != word[index])
        {
            return false;
        }

        // Temporarily mark the cell as visited
        char temp = board[row][col];
        board[row][col] = ' ';

        // Explore adjacent cells
        bool result = ExistRecursive(board, word, row + 1, col, index + 1) ||
                      ExistRecursive(board, word, row - 1, col, index + 1) ||
                      ExistRecursive(board, word, row, col + 1, index + 1) ||
                      ExistRecursive(board, word, row, col - 1, index + 1);

        // Restore the cell's original value
        board[row][col] = temp;

        return result;
    }

    public static int CoinChange(int[] coins, int amount)
    {
       if(amount < 0)
       {
            return -1;
       }
        int[] dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);
        dp[0] = 0;
        for(int i = 1; i <= amount; i++)
        {
            foreach(int coin in coins)
            {
                if(i >= coin)
                {
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }

        }
        return dp[amount] > amount ? -1 : dp[amount];
    }

    public static int LengthOfLongestSubstring(string s)
    {
        int n = s.Count(), p1 = 0, p2 = 0, ans = 0;
        HashSet<char> hs = new HashSet<char>();
        while (p2 < n)
        {
            if (!hs.Contains(s[p2]))
            {
                hs.Add(s[p2]);
                ans = Math.Max(ans, hs.Count());
                p2++;
            }
            else
            {
                hs.Remove(s[p1]);
                p1++;
            }
        }
        return ans;
    }




}
