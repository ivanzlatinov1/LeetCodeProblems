public class Problem1391
{
    public static bool HasValidPath(int[][] grid)
    {
        /*
        Each street type maps to [up, left, down, right] connectivity.
        'true' means the street connects in that direction.
        Index: 0=up, 1=left, 2=down, 3=right
    
          Street types:
          1: connects left and right
          2: connects up and down   
          3: connects left and down 
          4: connects right and down
          5: connects left and up   
          6: connects right and up
        */
        Dictionary<int, bool[]> directions = new()
        {
            [1] = [false, true, false, true],
            [2] = [true, false, true, false],
            [3] = [false, true, true, false],
            [4] = [false, false, true, true],
            [5] = [true, true, false, false],
            [6] = [true, false, false, true]
        };

        int m = grid.Length, n = grid[0].Length;

        // Track visited cells to avoid redundant recursive calls
        bool[][] visited = new bool[m][];
        for (int i = 0; i < m; i++)
            visited[i] = new bool[n];

        return MakeMove(0, 0, -1, -1, grid[0][0], directions, grid, m, n, visited);
    }

    // Recursively explores valid street paths from (posX, posY) toward (m-1, n-1).
    // prevX, prevY: the cell we came from, used to avoid immediately backtracking.
    // street: the street type at the current cell.
    private static bool MakeMove(int posX, int posY, int prevX, int prevY,
        int street, Dictionary<int, bool[]> directions, int[][] grid, int m, int n, bool[][] visited)
    {
        // Base case: reached the bottom-right destination
        if (posX == m - 1 && posY == n - 1) return true;

        // Skip already visited cells to avoid cycles and redundant work
        if (visited[posX][posY]) return false;
        visited[posX][posY] = true;

        bool up = directions[street][0],
             left = directions[street][1],
             down = directions[street][2],
             right = directions[street][3];

        // Try moving down: current street must connect down
        // Neighbor must connect up [index 0], and target must not be where we came from
        if (posX < m - 1 && down && directions[grid[posX + 1][posY]][0] && !(posX + 1 == prevX && posY == prevY))
            if (MakeMove(posX + 1, posY, posX, posY, grid[posX + 1][posY], directions, grid, m, n, visited)) return true;

        // Try moving up: current street must connect up
        // Neighbor must connect down [index 2], and target must not be where we came from
        if (posX > 0 && up && directions[grid[posX - 1][posY]][2] && !(posX - 1 == prevX && posY == prevY))
            if (MakeMove(posX - 1, posY, posX, posY, grid[posX - 1][posY], directions, grid, m, n, visited)) return true;

        // Try moving right: current street must connect right
        // Neighbor must connect left [index 1], and target must not be where we came from
        if (posY < n - 1 && right && directions[grid[posX][posY + 1]][1] && !(posX == prevX && posY + 1 == prevY))
            if (MakeMove(posX, posY + 1, posX, posY, grid[posX][posY + 1], directions, grid, m, n, visited)) return true;

        // Try moving left: current street must connect left
        // Neighbor must connect right [index 3], and target must not be where we came from
        if (posY > 0 && left && directions[grid[posX][posY - 1]][3] && !(posX == prevX && posY - 1 == prevY))
            if (MakeMove(posX, posY - 1, posX, posY, grid[posX][posY - 1], directions, grid, m, n, visited)) return true;

        // No valid path found from this cell
        return false;
    }
}