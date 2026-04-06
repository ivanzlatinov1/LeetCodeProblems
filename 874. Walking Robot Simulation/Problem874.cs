public class Problem874
{
    public static int RobotSim(int[] commands, int[][] obstacles)
    {
        // Initialize starting position of the robot
        int posX = 0, posY = 0, maxDistance = 0;
        // Assuming at the start the robot is facing 'N' (North)
        char currentPos = 'N';

        foreach (int command in commands)
        {
            // For command == -1 -> the robot turns right
            if (command == -1)
            {
                switch (currentPos)
                {
                    case 'N':
                        currentPos = 'E';
                        break;
                    case 'E':
                        currentPos = 'S';
                        break;
                    case 'S':
                        currentPos = 'W';
                        break;
                    case 'W':
                        currentPos = 'N';
                        break;
                }
                continue;
            }
            // For command == -2 -> the robot turns left
            else if (command == -2)
            {
                switch (currentPos)
                {
                    case 'N':
                        currentPos = 'W';
                        break;
                    case 'W':
                        currentPos = 'S';
                        break;
                    case 'S':
                        currentPos = 'E';
                        break;
                    case 'E':
                        currentPos = 'N';
                        break;
                }
                continue;
            }

            // Helping variable to determine if the robot has moved through an obstacle
            bool hasMoved = false;
            foreach (int[] obstacle in obstacles)
            {
                // Checking for each direction if the robot encounters an obstacle
                // If the direction matches, the robot is on the same lane as the obstacle,
                // his starting position is smaller than the obstacle position,
                // and his starting position + command (steps) is more than the obstacle position,
                // the robot moves in front of (or behind, depends on the direction) the obstacle.
                if (currentPos == 'N' && posX == obstacle[0] && posY < obstacle[1] && posY + command >= obstacle[1])
                {
                    posY = obstacle[1] - 1;
                    hasMoved = true;
                    break;
                }
                if (currentPos == 'E' && posY == obstacle[1] && posX < obstacle[0] && posX + command >= obstacle[0])
                {
                    posX = obstacle[0] - 1;
                    hasMoved = true;
                    break;
                }
                if (currentPos == 'S' && posX == obstacle[0] && posY > obstacle[1] && posY - command <= obstacle[1])
                {
                    posY = obstacle[1] + 1;
                    hasMoved = true;
                    break;
                }
                if (currentPos == 'W' && posY == obstacle[1] && posX > obstacle[0] && posX - command <= obstacle[0])
                {
                    posX = obstacle[0] + 1;
                    hasMoved = true;
                    break;
                }
            }

            // If the robot did not encounter an obstacle, he moves normally
            if (!hasMoved)
            {
                if (currentPos == 'N')
                    posY += command;
                else if (currentPos == 'S')
                    posY -= command;
                else if (currentPos == 'W')
                    posX -= command;
                else
                    posX += command;
            }

            // Calculating the current distance of the robot and comparing it to the max distance
            int currentDistance = (int)(Math.Pow(posX, 2) + Math.Pow(posY, 2));
            maxDistance = Math.Max(currentDistance, maxDistance);
        }

        // Returning the max distance the robot has reached
        return maxDistance;
    }
}