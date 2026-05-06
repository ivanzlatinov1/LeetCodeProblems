public class Problem1861
{
    public static char[][] RotateTheBox(char[][] boxGrid)
    {
        int m = boxGrid.Length, n = boxGrid[0].Length;

        // Transponated matrix of boxGrid
        char[][] result = new char[n][];

        for (int i = 0; i < n; ++i)
        {
            result[i] = new char[m];
            for (int j = 0; j < m; ++j)
            {
                // Assigning the current transponated cell of boxGrid
                result[i][j] = boxGrid[j][i];

                if (i > 0)
                {
                    // Checking if the current cell of result is '#' and the above one is '.'
                    // If so, we replace the two cells and repeat that until the above cell is out of the grid or a '#' or '*'
                    int k = i;
                    while (k > 0 && result[k][j] == '.' && result[k - 1][j] == '#')
                    {
                        (result[k][j], result[k - 1][j]) = (result[k - 1][j], result[k][j]);
                        k--;
                    }
                }
            }
        }

        // Reverse the rows to complete the transponate matrix
        for (int i = 0; i < n; ++i)
        {
            int j = 0, k = m - 1;
            while (j < k)
            {
                (result[i][j], result[i][k]) = (result[i][k], result[i][j]);
                j++;
                k--;
            }

            // Print matrix
            for (j = 0; j < m; ++j)
                Console.Write(result[i][j] + " ");
            Console.WriteLine();
        }

        return result;
    }
}