using System.Text;

public class Problem2075
{
    public static string DecodeCiphertext(string encodedText, int rows)
    {
        // Edge case: If rows is zero, we cannot form a grid
        if (rows == 0) return string.Empty;

        // Determine number of columns in the grid
        int cols = encodedText.Length / rows;

        // Create a 2D grid (jagged array)
        char[][] grid = new char[rows][];

        // Fill the grid row by row using the encoded text
        int indexer = 0;
        for (int i = 0; i < rows; i++)
        {
            grid[i] = new char[cols];
            for (int j = 0; j < cols; j++)
                grid[i][j] = encodedText[indexer++];
        }

        // StringBuilder to efficiently build the decoded text
        StringBuilder originalText = new();

        // Traverse the grid diagonally
        // Start from each column in the first row
        for (int i = 0; i < cols; i++)
        {
            // Move diagonally down-right
            for (int j = 0; j < rows; j++)
            {
                // Ensure we stay within column bounds
                if (j + i >= cols) continue;

                // Append the character at the diagonal position
                originalText.Append(grid[j][j + i]);
            }
        }

        // Remove trailing spaces at the end and return result
        return originalText.ToString().TrimEnd();
    }
}