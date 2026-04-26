public class Problem1559
{
    public static bool ContainsCycle(char[][] grid)
    {
        // Determine the lengths of the grid array
        int m = grid.Length, n = grid[0].Length;

        // Initialize an array to track which cells we have already visited
        bool[][] visited = new bool[m][];

        // Fill the visited array, default value is false
        for (int i = 0; i < m; ++i)
            visited[i] = new bool[n];

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                // This cell was already visited, so we skip it
                if (visited[i][j]) continue;

                // Check for a possible cycle starting from the current cell, if found -> return true
                if (CheckCycle(-1, -1, i, j, grid, visited, m, n))
                    return true;
            }
        }

        // No cycle of the same values was found, so we return false
        return false;
    }

    private static bool CheckCycle(int prevX, int prevY, int curX, int curY, char[][] grid, bool[][] visited, int m, int n)
    {
        // Reached an already-visited cell that isn't where we came from -> cycle found
        if (visited[curX][curY]) return true;

        // Mark the current cell as visited
        visited[curX][curY] = true;

        // Helper array for all directions -> up, left, right, down
        int[][] directions = [[1, 0], [-1, 0], [0, 1], [0, -1]];
        foreach (int[] d in directions)
        {
            // Determine coordinates of the possible next move
            int nextX = curX + d[0], nextY = curY + d[1];

            // Check boundaries
            if (nextX < 0 || nextX >= m || nextY < 0 || nextY >= n) continue;
            // Don't go back to previous cell
            if (nextX == prevX && nextY == prevY) continue;
            // Next cell must be same character
            if (grid[nextX][nextY] != grid[curX][curY]) continue;

            // Make the next move
            if (CheckCycle(curX, curY, nextX, nextY, grid, visited, m, n)) return true;
        }

        return false;
    }
}