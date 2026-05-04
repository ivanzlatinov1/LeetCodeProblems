public class Problem48
{
    public static void Rotate(int[][] matrix)
    {
        int n = matrix.Length;
        // Transponate matrix -> make rows to be cols
        for (int i = 0; i < n; ++i)
        {
            for (int j = i; j < n; ++j)
            {
                (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
            }
        }

        // Reverse rows
        for (int i = 0; i < n; ++i)
        {
            // Two pointers: one for start, another for end of matrix[i]
            int j = 0, k = n - 1;
            while (j < k)
            {
                (matrix[i][j], matrix[i][k]) = (matrix[i][k], matrix[i][j]);
                j++;
                k--;
            }

            // Print matrix
            for (j = 0; j < n; ++j)
                Console.Write(matrix[i][j] + " ");
            Console.WriteLine();
        }
    }
}