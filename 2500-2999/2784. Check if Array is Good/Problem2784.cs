public class Problem2784
{
    public static bool IsGood(int[] nums)
    {
        // Expected max value
        int n = nums.Length;

        // Largest number in array
        int max = nums.Max();

        // Max must equal length - 1
        if (max != n - 1)
            return false;

        // Tracks seen numbers
        bool[] visited = new bool[n + 1];

        for (int i = 0; i < n; i++)
        {
            int current = nums[i];

            // Number out of range
            if (current < 1 || current > max) return false;

            // Number already seen
            if (visited[current])
            {
                // Only max can repeat
                if (current != max) return false;

                // Marks second max
                visited[max + 1] = true;
            }
            else
            {
                // First occurrence
                visited[current] = true;
            }
        }

        // Check all required flags
        for (int i = 1; i <= max + 1; i++)
            if (!visited[i]) return false;

        return true;
    }
}