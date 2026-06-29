public class Problem1967
{
    public static int NumOfStrings(string[] patterns, string word)
    {
        int ans = 0;

        foreach (string pattern in patterns)
        {
            if (word.Contains(pattern)) ans++;
        }

        return ans;
    }
}