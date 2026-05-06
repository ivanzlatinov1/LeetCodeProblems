public class Problem136
{
    // Find the only number in the nums array which appears only once
    public static int SingleNumber(int[] nums)
    {
        // XOR all elements cumulatively -> duplicate numbers cancel out (n ^ n = 0)
        for (int i = 1; i < nums.Length; ++i)
            nums[i] ^= nums[i - 1];

        // The last element now holds the XOR of all values, so only the unique one remains
        return nums[^1];
    }
}