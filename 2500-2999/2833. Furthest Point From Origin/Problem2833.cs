public class Problem2833
{
    public static int FurthestDistanceFromOrigin(string moves)
    {
        // Count the moves to the left, right and the flexible '_' ones
        int leftCount = 0, rightCount = 0, blankCount = 0;

        // Iterate through each character in the string
        for (int i = 0; i < moves.Length; ++i)
        {
            // Mandatory move to the left
            if (moves[i] == 'L') leftCount++;
            // Mandatory move to the right
            else if (moves[i] == 'R') rightCount++;
            // Flexible move: can be L or R
            else blankCount++;
        }

        // If left moves are more, assign all blanks to the left
        // to maximize distance in the negative direction
        if (leftCount > rightCount)
            return leftCount + blankCount - rightCount;

        // If right moves are more, assign all blanks to the right
        // to maximize distance in the positive direction
        if (rightCount > leftCount)
            return rightCount + blankCount - leftCount;

        // If both sides are equal, use all blanks in one direction
        // to get the maximum possible distance
        return blankCount;
    }
}