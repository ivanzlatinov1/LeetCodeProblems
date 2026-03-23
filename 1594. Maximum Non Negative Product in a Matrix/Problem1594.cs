public class Problem1594
{
    public static int MaxProductPath(int[][] grid)
    {
        // A modulo needed for this problem
        const int MOD = (int)1e9 + 7;

        // Determing the grid dimensions
        int m = grid.Length, n = grid[0].Length;

        // The maximum product we've ever reached this cell with
        long[,] maxSeen = new long[m, n];

        // The minimum product we've ever reached this cell with
        long[,] minSeen = new long[m, n];

        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
            {
                // maxSeen starts with very small values and minSeen with very big values
                maxSeen[i, j] = long.MinValue;
                minSeen[i, j] = long.MaxValue;
            }

        // Stores the best (maximum) product found at the destination
        long product = long.MinValue;

        void Backtrack(int i, int j, long currentProduct)
        {
            // If we've already reached this cell with a higher max and a lower min
            // then the current product is useless (it can't lead to a better result)
            if (currentProduct <= maxSeen[i, j] && currentProduct >= minSeen[i, j])
                return;

            // Update best values for the current cell
            maxSeen[i, j] = Math.Max(maxSeen[i, j], currentProduct);
            minSeen[i, j] = Math.Min(minSeen[i, j], currentProduct);

            // Reached the bottom right cell
            if (i == m - 1 && j == n - 1)
            {
                // Update the global maximum product
                product = Math.Max(product, currentProduct);
                return;
            }

            // Move right
            if (j < n - 1)
                Backtrack(i, j + 1, currentProduct * grid[i][j + 1]);

            // Move down
            if (i < m - 1)
                Backtrack(i + 1, j, currentProduct * grid[i + 1][j]);
        }

        // Start backtracking from top-left corner
        Backtrack(0, 0, grid[0][0]);

        // Applying modulo at the end of the problem
        return product < 0 ? -1 : (int)(product % MOD);
    }
}