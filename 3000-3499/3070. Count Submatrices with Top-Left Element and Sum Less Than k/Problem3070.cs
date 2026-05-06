public class Problem3070
{
    public static int CountSubmatrices(int[][] grid, int k)
    {
        // Initialize the subMatrices (the result), starting row, col and matrix lengths
        int subMatrices = 0, row = 0, col = 0, m = grid.Length, n = grid[0].Length;

        // Iterating through every row of the matrix
        while (row < m)
        {
            if (row == 0 && col > 0)
                grid[row][col] += grid[row][col - 1]; // Math for the first row
            else if (row > 0 && col == 0)
                grid[row][col] += grid[row - 1][col]; // Math for the first column
            else if (row > 0 && col > 0)
                grid[row][col] += grid[row - 1][col] + grid[row][col - 1] - grid[row - 1][col - 1]; // Math for the other matrixes


            // Turning the original grid into sum grid to see which sum is less than or equal to k
            if (grid[row][col] <= k)
                subMatrices++;

            // After all operations, we go to the next column
            col++;

            // If the next column is outside the grid, we go to the next row
            if (col == n)
            {
                col = 0;
                row++;
            }
        }

        // At the end, we return the number of matrices starting from [0, 0], whose sum is <= k
        return subMatrices;
    }
}