public class Problem2615
{
    public static long[] Distance(int[] nums)
    {
        // Map each value -> list of indices where it appears
        Dictionary<int, List<int>> map = [];

        for (int i = 0; i < nums.Length; ++i)
        {
            // Build groups of indices for each number
            if (!map.TryGetValue(nums[i], out List<int>? value))
                map[nums[i]] = [i];
            else
                value.Add(i);
        }

        // Result array
        long[] ans = new long[nums.Length];

        // Iterate through each group of equal values
        foreach (List<int> indices in map.Values)
        {
            int m = indices.Count;

            // Prefix sum where prefixSums[i] = sum of indices[0..i]
            long[] prefixSums = new long[m];
            prefixSums[0] = indices[0];

            for (int i = 1; i < m; i++)
                prefixSums[i] = prefixSums[i - 1] + indices[i];

            // For each index in this group, compute total distance
            for (int i = 0; i < m; i++)
            {
                // There are {i} elements to the left
                // Distance to left elements = indices[i] * i - sum(left_elements)
                long left = (long)indices[i] * i - (i > 0 ? prefixSums[i - 1] : 0);

                // There are {m - i - 1} elements to the right
                // Distance to right elements = sum(right_elements) - indices[i] * count
                long right = prefixSums[m - 1] - prefixSums[i] - (long)indices[i] * (m - i - 1);

                // Store result at the original position
                ans[indices[i]] = left + right;
            }
        }

        return ans;
    }
}