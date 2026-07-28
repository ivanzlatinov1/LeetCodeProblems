public class Problem3517
{
    public static string SmallestPalindrome(string s)
    {
        SortedDictionary<char, int> dict = [];

        for (int i = 0; i < s.Length; ++i)
        {
            if (!dict.ContainsKey(s[i]))
                dict[s[i]] = 0;

            dict[s[i]] += 1;
        }

        string ans = string.Empty;

        foreach ((char key, int count) in dict)
        {
            if (count % 2 == 0)
                ans += new string(key, count / 2);
            else if (count > 2 && s.Length > count + 1)
                ans += new string(key, count / 2);
        }

        foreach ((char key, int count) in dict.Where(x => x.Value % 2 != 0))
        {
            ans += key;
        }

        foreach ((char key, int count) in dict.OrderByDescending(x => x.Key))
        {
            if (count % 2 == 0)
                ans += new string(key, count / 2);
            else if (count > 2 && s.Length > count + 1)
                ans += new string(key, count / 2);
        }

        return ans;
    }
}