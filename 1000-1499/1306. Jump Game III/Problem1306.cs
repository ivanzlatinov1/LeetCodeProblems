public class Problem1306
{
    public static bool CanReach(int[] arr, int start)
    {
        // Ensure the starting index is within array bounds
        if (start < 0 || start >= arr.Length) return false;

        // Tracks which indices have already been visited to prevent infinite loops
        bool[] visited = new bool[arr.Length];

        // Start DFS traversal from the given start index
        return CanReachZero(arr, start, visited);
    }

    private static bool CanReachZero(int[] arr, int index, bool[] visited)
    {
        // If this index was already processed, stop exploring this path
        if (visited[index]) return false;

        // Mark current index as visited
        visited[index] = true;

        // If current value is 0, we reached the goal
        if (arr[index] == 0) return true;

        // Try jumping forward if the target index is inside the array
        if (index + arr[index] < arr.Length && CanReachZero(arr, index + arr[index], visited))
        {
            return true;
        }

        // Try jumping backward if the target index is inside the array
        if (index - arr[index] >= 0 && CanReachZero(arr, index - arr[index], visited))
        {
            return true;
        }

        // No path to a zero value was found from this index
        return false;
    }
}