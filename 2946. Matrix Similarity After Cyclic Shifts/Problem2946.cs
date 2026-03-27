public class Problem2946
{
    public static bool AreSimilar(int[][] mat, int k)
    {
        int m = mat.Length, n = mat[0].Length;

        // Create a new matrix reference
        int[][] result = new int[m][];

        // Copy mat into result
        for (int i = 0; i < m; i++)
            result[i] = (int[])mat[i].Clone(); // Copy the current row to the new result matrix (not shallow copy)

        for (int i = 0; i < m; i++)
        {
            // Apply shift depending on row index parity
            if (i % 2 == 0)
                ShiftEvenRow(result, k % n, i); // even rows → left shift
            else
                ShiftOddRow(result, k % n, i);  // odd rows → right shift

            // Compare shifted row with original row
            if (!AreRowsEqual(mat[i], result[i]))
                return false;
        }

        // If all rows are identical, return true
        return true;
    }

    private static void ShiftEvenRow(int[][] grid, int shifts, int currentRowIndex)
    {
        int n = grid[0].Length;
        int[] newRow = new int[n];
        int currentIndex = 0;

        // Copy elements starting from 'shifts' to end -> left shift part
        for (int i = shifts; i < n; i++)
        {
            newRow[currentIndex++] = grid[currentRowIndex][i];
        }

        // Copy the first 'shifts' elements to the end
        for (int i = 0; i < shifts; i++)
        {
            newRow[currentIndex++] = grid[currentRowIndex][i];
        }

        // Replace original row with shifted row
        grid[currentRowIndex] = newRow;
    }

    private static void ShiftOddRow(int[][] grid, int shifts, int currentRowIndex)
    {
        int n = grid[0].Length;
        int[] newRow = new int[n];
        int currentIndex = 0;

        // Copy last 'shifts' elements -> right shift part
        for (int i = n - shifts; i < n; i++)
        {
            newRow[currentIndex++] = grid[currentRowIndex][i];
        }

        // Copy remaining elements from start
        for (int i = 0; i < n - shifts; i++)
        {
            newRow[currentIndex++] = grid[currentRowIndex][i];
        }

        // Replace original row with shifted row
        grid[currentRowIndex] = newRow;
    }

    private static bool AreRowsEqual(int[] row1, int[] row2)
    {
        // Compare elements one by one
        for (int i = 0; i < row1.Length; i++)
            if (row1[i] != row2[i])
                return false;

        return true; // rows are identical
    }
}