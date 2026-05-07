public class Problem3660
{
    // !TLE! Warning
    public static int[] MaxValue(int[] nums)
    {
        // Result array: ans[i] stores the maximum reachable value starting from i
        int[] ans = new int[nums.Length];

        // i = current starting index
        // j = index used to scan to the right of i
        // currentMax = best maximum reachable while scanning
        // leftMax = maximum value seen so far on the left side
        int i = 0, j = 1, currentMax = 0, leftMax = 0;

        while (i < nums.Length)
        {
            // This block runs only once per starting index i
            if (j == i + 1)
            {
                // Update the best value seen up to index i
                leftMax = Math.Max(leftMax, nums[i]);

                // Start current reachable maximum from leftMax
                currentMax = leftMax;

                // Minimum answer is at least leftMax
                ans[i] = leftMax;
            }

            // Reached end of array for this i
            if (j == nums.Length)
            {
                // Move to next starting index
                i++;
                j = i + 1;
                continue;
            }

            // If nums[j] is larger than everything seen on the left,
            // it may become the new maximum reachable
            if (nums[j] > leftMax)
            {
                currentMax = Math.Max(nums[j], currentMax);
            }
            // If nums[j] is smaller than leftMax,
            // then a valid jump condition is met
            else if (nums[j] < leftMax)
            {
                // Update answer for current starting index
                ans[i] = currentMax;

                // Extend leftMax since this region becomes reachable
                leftMax = currentMax;
            }

            // Continue scanning to the right
            j++;
        }

        return ans;
    }
}