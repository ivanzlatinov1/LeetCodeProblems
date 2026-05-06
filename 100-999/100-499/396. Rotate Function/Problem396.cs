public class Problem396
{
    public static int MaxRotateFunction(int[] nums)
    {
        // Determine the array length
        int n = nums.Length;

        // Calculate the sum of the array
        long sum = 0;
        for (int i = 0; i < n; i++)
            sum += nums[i];

        // Get the F(0) value and set it as a maximum
        long current = InitialRotationValue(nums);
        long max = current;

        for (int k = 1; k < n; k++)
        {
            // Compute the next rotation value
            current = NextRotationValue(current, sum, nums, k);
            // Check if it is bigger from the current maximum
            max = Math.Max(max, current);
        }

        return (int)max;
    }

    // Calculate F(0)
    private static long InitialRotationValue(int[] nums)
    {
        long ans = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            ans += (long)i * nums[i];
        }
        return ans;
    }

    // Calculate F(k + 1)
    private static long NextRotationValue(long prev, long sum, int[] nums, int k)
    {
        int n = nums.Length;
        // F(k) = F(k-1) + sum - n * nums[n - k]
        return prev + sum - (long)n * nums[n - k];
    }
}