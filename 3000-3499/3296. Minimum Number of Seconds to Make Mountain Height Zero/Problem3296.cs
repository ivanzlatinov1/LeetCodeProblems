public class Problem3296
{
    public static long MinNumberOfSeconds(int mountainHeight, int[] workerTimes)
    {
        // Using binary search for the minimum time required to reduce the mountain to height 0
        long left = 0, right = (long)1e18, ans = right;
        while (left <= right)
        {
            // Calculate the midpoint time we want to test
            long mid = left + (right - left) / 2;

            // Check if it is possible to remove the entire mountain within {mid} seconds
            if (CanRemoveMountain(mid, mountainHeight, workerTimes))
            {
                // If it is possible, store this as a potential answer
                ans = mid;

                // Try to find a smaller valid time
                right = mid - 1;
            }
            else
                left = mid + 1; // If not possible, we need more time
        }

        // Return the minimum time that worked
        return ans;
    }

    // Helper function that checks if a given time is enough
    private static bool CanRemoveMountain(long time, int mountainHeight, int[] workerTimes)
    {
        // Total height removed by all workers
        long removed = 0;

        // Iterate through every worker
        foreach (int workerTime in workerTimes)
        {
            // workerTime * (1 + 2 + 3 + ... + k) <= time -> workerTime * k * (k + 1) / 2 
            // -> k * (k + 1) <= time / workerTime * 2
            long val = 2 * time / workerTime;

            // Solve quadratic equation to get k
            long k = (long)((Math.Sqrt(1 + 4 * val) - 1) / 2);

            // Add how many units this worker can remove
            removed += k;

            // If we already removed enough height, stop early
            if (removed >= mountainHeight)
                return true;
        }

        // If total removed height is still less than mountain height, the given time is not enough
        return false;
    }
}