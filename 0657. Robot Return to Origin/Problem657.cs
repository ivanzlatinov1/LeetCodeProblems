public class Problem657
{
    public static bool JudgeCircle(string moves)
    {
        // Initialize starting position of the robot (0, 0)
        int posX = 0, posY = 0;

        // Iterate through the robot's moves
        for (int i = 0; i < moves.Length; ++i)
            switch (moves[i])
            {
                case 'R':
                    posY += 1; // Move right
                    break;
                case 'L':
                    posY -= 1; // Move left
                    break;
                case 'U':
                    posX += 1; // Move up
                    break;
                case 'D':
                    posX -= 1; // Move down
                    break;
            }

        // If the position is the same as the starting one, return true, otherwise -> false
        return posX == posY && posX == 0;
    }
}