public class Problem3418
{
    private static int[,,]? dp;

    public static int MaximumAmount(int[][] coins)
    {
        // Take the grid length
        int m = coins.Length, n = coins[0].Length;

        // Initialize dp[i, j, k] array
        // Representing the maximum coins we can get from coins[i][j], having k neutralizations used 
        dp = new int[m, n, 3];

        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                for (int k = 0; k < 3; k++)
                    dp[i, j, k] = int.MinValue;

        // Start DFS from coins[0][0] with 0 neutralizations used
        return DFS(coins, 0, 0, 0, m, n);
    }

    private static int DFS(int[][] grid, int i, int j, int neutralizations, int m, int n)
    {
        // If we go outside the grid -> invalid path
        if (i >= m || j >= n) return int.MinValue;

        // Memoization: this state was already solved
        if (dp![i, j, neutralizations] != int.MinValue)
            return dp[i, j, neutralizations];

        // Take the current cell's value
        int val = grid[i][j];

        // Base case: we reached the end of the grid
        if (i == m - 1 && j == n - 1)
        {
            int best = val;

            // Neutralize if cell's value is negative
            if (val < 0 && neutralizations < 2)
                best = Math.Max(best, 0);

            // Store and return the result
            return dp[i, j, neutralizations] = best;
        }

        // Move right and down
        int right = DFS(grid, i, j + 1, neutralizations, m, n);
        int down = DFS(grid, i + 1, j, neutralizations, m, n);

        // Choose the best path for the next move
        int nextBest = Math.Max(right, down);

        // If both directions are invalid -> stop
        if (nextBest == int.MinValue)
            return dp[i, j, neutralizations] = int.MinValue;

        // Case 1: take value normally
        int bestResult = val + nextBest;

        // Case 2: neutralize robber
        if (val < 0 && neutralizations < 2)
        {
            // Explore again with neutralizations + 1, because we've used one
            int right2 = DFS(grid, i, j + 1, neutralizations + 1, m, n);
            int down2 = DFS(grid, i + 1, j, neutralizations + 1, m, n);

            // Best path after neutralizing
            int nextBest2 = Math.Max(right2, down2);

            if (nextBest2 != int.MinValue)
                bestResult = Math.Max(bestResult, nextBest2); // Skip negative
        }

        // Store and return the result
        return dp[i, j, neutralizations] = bestResult;
    }
}