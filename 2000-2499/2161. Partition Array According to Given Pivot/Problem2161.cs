public class Problem2161
{
    public static int[] PivotArray(int[] nums, int pivot)
    {
        int n = nums.Length, left = 0, mid = 0;

        for (int i = 0; i < n; ++i)
        {
            if (nums[i] < pivot) left++;
            else if (nums[i] == pivot) mid++;
        }

        int[] result = new int[nums.Length];

        int l = 0;
        int m = left;
        int r = left + mid;

        foreach (int x in nums)
        {
            if (x < pivot)
                result[l++] = x;
            else if (x == pivot)
                result[m++] = x;
            else
                result[r++] = x;
        }

        return result;
    }
}