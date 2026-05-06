public class Problem2033
{
    public static int MinOperations(int[][] grid, int x)
    {
        // Determine the grid length
        int m = grid.Length, n = grid[0].Length;

        // Convert the m * n grid into a one-dimensional array
        int[] flatGrid = new int[m * n];
        int index = 0;

        // Fill the flattened array with the grid's values
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                flatGrid[index++] = grid[i][j];

        // Sort the array, so we can find the median
        Array.Sort(flatGrid);

        // Calculate the median with formula {length / 2}, because length is always dividable by 2
        int median = flatGrid[m * n / 2];
        int ops = 0;

        for (int i = 0; i < m * n; ++i)
        {
            // Seeing how far is the current element from the median
            int diff = Math.Abs(flatGrid[i] - median);

            // If that difference is not dividable by x, we cannot perform the operation, so return -1
            if (diff % x != 0) return -1;

            // We add the number of operations needed to the global variable in the function
            ops += diff / x;
        }

        return ops;
    }
}