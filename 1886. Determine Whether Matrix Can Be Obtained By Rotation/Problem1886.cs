public class Problem1886
{
    public static bool FindRotation(int[][] mat, int[][] target)
    {
        int n = mat.Length;

        // Try all 4 rotations (0°, 90°, 180°, 270°)
        for (int r = 0; r < 4; r++)
        {
            if (IsEqual(mat, target)) // Check if current rotation matches target
                return true;

            // Rotate matrix 90° clockwise for next iteration
            Rotate90(mat, n);
        }

        // No rotation matched, return false
        return false;
    }

    // Check if two matrices are equal
    private static bool IsEqual(int[][] a, int[][] b)
    {
        int n = a.Length;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (a[i][j] != b[i][j])
                    return false; // Matrices are not equal
            }
        }

        // All elements match, matrices are equal
        return true;
    }

    // Rotate matrix 90 degrees clockwise (in-place)
    private static void Rotate90(int[][] mat, int n)
    {
        // Step 1: Transpose (swapping row and col indices)
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                (mat[j][i], mat[i][j]) = (mat[i][j], mat[j][i]);
            }
        }

        // Step 2: Reverse each row
        for (int i = 0; i < n; i++)
        {
            // Reverse the current row to complete 90° rotation
            Array.Reverse(mat[i]);
        }
    }
}