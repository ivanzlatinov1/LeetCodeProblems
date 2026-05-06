public class Problem1855
{
    public static int MaxDistance(int[] nums1, int[] nums2)
    {
        // Initialize result variable for maximum distance between indices
        int maxDistance = 0;

        // Loop through the first array
        for (int i = 0; i < nums1.Length; ++i)
        {
            // Arrays are sorted in non-increasing order so we use binary search
            // Initialize left = i, because we need left >= i to satisfy the condtions, and right as a border of the second array
            int left = i, right = nums2.Length - 1;
            while (left <= right)
            {
                // Calculate the mid index for basic binary search
                int mid = left + (right - left) / 2;

                // If this passes, the number we are looking for has index smaller than {mid}
                if (nums2[mid] < nums1[i]) right = mid - 1;
                else
                {
                    // Calculate maximum distance
                    maxDistance = Math.Max(mid - i, maxDistance);
                    // Update the left, because we can find a bigger maximum distance
                    left = mid + 1;
                }
            }
        }

        // Return the maximum distance, 0 if there was not a valid pair of indices
        return maxDistance;
    }
}