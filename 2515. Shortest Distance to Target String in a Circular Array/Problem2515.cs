public class Problem2515
{
    public static int ClosestTarget(string[] words, string target, int startIndex)
    {
        // Get the length of the array
        int n = words.Length;

        // Check both directions step by step
        for (int i = 0; i < n; i++)
        {
            // Move right (clockwise)
            if (words[(startIndex + i) % n] == target)
                return i;

            // Move left (counter-clockwise)
            if (words[(startIndex - i + n) % n] == target)
                return i;
        }

        // Target not found
        return -1;
    }
}