public class Problem2078
{
    public static int MaxDistance(int[] colors)
    {
        // Store the maximum distance found between two houses with different colors
        int maxDistance = 0;

        // Total number of houses
        int n = colors.Length;

        // Iterate through the array (only need to go until n - 1)
        for (int i = 0; i < n - 1; i++)
        {
            // Compare current house with the first house (index -> 0)
            // If colors are different, calculate distance from index 0 to i
            if (colors[i] != colors[0])
                maxDistance = Math.Max(i, maxDistance);

            // Compare current house with the last house (index -> n - 1)
            // We use (n - 1 - i) to scan from the end towards the beginning
            // If colors are different, calculate distance from end to that position
            if (colors[i] != colors[n - 1 - i])
                maxDistance = Math.Max(n - 1 - i, maxDistance);
        }

        // Return the maximum distance found
        return maxDistance;
    }
}