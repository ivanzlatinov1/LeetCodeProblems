public class Problem2540
{
    public static int GetCommon(int[] nums1, int[] nums2)
    {
        // Pointer for nums2
        int j = 0;

        // Iterate through nums1 manually using i
        for (int i = 0; i < nums1.Length;)
        {
            // If j reaches the end of nums2, there are no more possible matches
            if (j == nums2.Length) return -1;

            // If current nums2 value is greater, move i forward to catch up
            if (nums2[j] > nums1[i])
            {
                i++;
                continue;
            }

            // Found the smallest common element
            if (nums2[j] == nums1[i]) return nums1[i];

            // nums2[j] is smaller, so move j forward
            j++;
        }

        // No common element found
        return -1;
    }
}