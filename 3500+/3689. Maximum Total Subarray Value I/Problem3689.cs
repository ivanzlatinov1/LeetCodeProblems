public class Problem3689
{
    public static long MaxTotalValue(int[] nums, int k)
    {
        if (nums.Length == 1) return 0;

        long max = nums.Max();
        long min = nums.Min();

        return (max - min) * k;
    }
}