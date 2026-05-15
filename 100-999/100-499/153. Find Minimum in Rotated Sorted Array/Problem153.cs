public class Problem153
{
    public static int FindMin(int[] nums)
    {
        // Initialize two pointers
        int left = 0, right = nums.Length - 1;

        // Do binary searching while the range is valid
        while (left < right)
        {
            // If the current range is already sorted, then the leftmost element is the minimum
            if (nums[left] < nums[right])
                return nums[left];

            // Find the middle index
            int mid = left + (right - left) / 2;

            if (nums[mid] > nums[right])
                // If middle element is greater than the rightmost element, the minimum must be in the right half
                left = mid + 1;
            else
                // Otherwise, the minimum is at mid or somewhere in the left half
                right = mid;
        }

        // Both pointers point to the minimum element, so return one of them
        return nums[left];
    }
}