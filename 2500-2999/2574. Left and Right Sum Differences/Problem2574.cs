public class Problem2574
{
    public static int[] LeftRightDifference(int[] nums)
    {
        // Pre-define the sum and length of the array
        int sum = nums.Sum(), n = nums.Length;
        int[] ans = new int[n];

        // Only track the left sum
        int leftSum = 0;
        for (int i = 0; i < n; ++i)
        {
            // The left sum is counted from the second element of the array
            if (i > 0)
                leftSum += nums[i - 1];

            // Calculate ans[i] = |leftSum - rightSum| without the current element
            ans[i] = Math.Abs(leftSum - (sum - leftSum - nums[i]));
        }

        // Return the result array
        return ans;
    }
}