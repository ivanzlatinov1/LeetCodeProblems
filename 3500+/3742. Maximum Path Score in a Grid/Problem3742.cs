public class Problem3742
{
    public static int MaxPathScore(int[][] grid, int k)
    {
        // Determine the grid's length
        int m = grid.Length, n = grid[0].Length;

        // Initialize a memoization array for optimization -> (row, col, remaining cost)
        int?[,,] memo = new int?[m, n, k + 1];

        int TryAllPaths(int i, int j, int k)
        {
            // Calculate the current cost
            int cost = grid[i][j] > 0 ? 1 : 0;

            // If it exceeds k, the path is not valid
            if (cost > k) return -1;

            // Otherwise we subtract that cost from k and get the score
            k -= cost;
            int score = grid[i][j];

            // If the bottom-right cell has been reached, return the score
            if (i == m - 1 && j == n - 1)
                return score;

            // If we went pass this cell already, return the result from it
            if (memo[i, j, k] is not null)
                return memo[i, j, k]!.Value;

            // Initialize as -1 -> means "no valid path found yet" from this cell
            int best = -1;

            // Move down
            if (i < m - 1)
            {
                int down = TryAllPaths(i + 1, j, k);
                if (down != -1)
                    best = Math.Max(best, score + down);
            }

            // Move right
            if (j < n - 1)
            {
                int right = TryAllPaths(i, j + 1, k);
                if (right != -1)
                    best = Math.Max(best, score + right);
            }

            // Store result in memo array to avoid recomputation
            memo[i, j, k] = best;

            // Return the best score from this state:
            // returns -1 if no valid path exists,
            // otherwise returns the maximum achievable score
            return best;
        }

        // Starting from (0, 0) with {k} remaining cost
        return TryAllPaths(0, 0, k);
    }
}