public class Problem2770
{
    public static int MaximumJumps(int[] nums, int target)
    {
        // Get the nums length
        int n = nums.Length;

        // dp[i] = maximum number of jumps needed to reach index i
        int[] dp = new int[n];
        // Initialize all positions as unreachable
        Array.Fill(dp, -1);

        // Starting point: index 0 is reachable with 0 jumps
        dp[0] = 0;

        // Try to compute answer for every index i
        for (int i = 1; i < n; ++i)
        {
            // Check every earlier index j
            for (int j = 0; j < i; ++j)
            {
                // j must already be reachable
                if (dp[j] == -1)
                    continue;

                // Check if jump from j -> i is valid
                int diff = nums[i] - nums[j];
                if (diff >= -target && diff <= target)
                {
                    // If valid, try to maximize jumps to reach i
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }

        // If last index is unreachable, this will be -1
        return dp[n - 1];
    }
}