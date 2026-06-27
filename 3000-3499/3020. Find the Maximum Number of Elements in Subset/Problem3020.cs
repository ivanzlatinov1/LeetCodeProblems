public class Problem3020
{
    public static int MaximumLength(int[] nums)
    {
        Dictionary<long, int> numCounts = [];

        foreach (int x in nums)
            numCounts[x] = numCounts.GetValueOrDefault(x) + 1;

        int ans = 1;

        if (numCounts.TryGetValue(1, out int ones))
            ans = Math.Max(ans, ones % 2 == 0 ? ones - 1 : ones);

        foreach (long start in numCounts.Keys)
        {
            if (start == 1)
                continue;

            long cur = start;
            int length = 0;

            while (numCounts.TryGetValue(cur, out int freq) && freq >= 2)
            {
                length += 2;
                cur *= cur;
            }

            if (numCounts.TryGetValue(cur, out int freq2) && freq2 == 1)
                length++;
            else if (length > 0)
                length--;

            ans = Math.Max(ans, length);
        }

        return ans;
    }
}