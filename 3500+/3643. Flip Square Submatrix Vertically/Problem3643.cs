public class Problem3643
{
    public static int[][] ReverseSubmatrix(int[][] grid, int x, int y, int k)
    {
        // Loop over the first half of the rows in the k x k submatrix
        // We only need to go k/2 because we swap top and bottom rows
        for (int i = 0; i < (int)Math.Floor((float)k / 2); ++i)
        {
            // Loop over all columns in the submatrix
            for (int j = 0; j < k; ++j)
            {
                // Swap the element in the top row (x + i) with the corresponding
                // element in the bottom row (x + k - i - 1), same column (y + j)
                (grid[i + x][j + y], grid[k - i + x - 1][j + y])
                = (grid[k - i + x - 1][j + y], grid[i + x][j + y]);
            }
        }

        // Return the modified grid after reversing the submatrix vertically
        return grid;
    }
}