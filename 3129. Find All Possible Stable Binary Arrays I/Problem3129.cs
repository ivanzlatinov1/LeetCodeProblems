public class Problem3129
{
    public static int NumberOfStableArrays(int zero, int one, int limit)
    {
        // Required modulo for this problem
        const int MOD = (int)1e9 + 7;

        /*
        Memoization array -> memo[zeros, ones, last, streak]

        zeros = how many zeros we have already used
        ones  = how many ones we have already used
        last  = what the last number we placed was
                 0 -> last was 0
                 1 -> last was 1
                 -1 -> start state (no previous number)
        streak = how many times the last number has appeared consecutively

        The value stored is the number of valid arrays we can build from this state
        */
        long[,,,] memo = new long[zero + 1, one + 1, 3, limit + 1];

        // Initialize memo array with -1 for all dimensions
        for (int i = 0; i <= zero; i++)
            for (int j = 0; j <= one; j++)
                for (int k = 0; k < 3; k++)
                    for (int s = 0; s <= limit; s++)
                        memo[i, j, k, s] = -1;

        long CountArrays(int zeroCount, int oneCount, int lastNum, int streak)
        {
            // If we used all the zeros and ones, its a valid stable array
            if (zeroCount == zero && oneCount == one)
                return 1;

            // Convert lastNum to an index for the memo array
            int lastIndex = lastNum + 1;

            // If we already solved this state, reuse the answer
            if (memo[zeroCount, oneCount, lastIndex, streak] != -1)
                return memo[zeroCount, oneCount, lastIndex, streak];

            long count = 0;

            // Option 1: Place a 1 (we still have ones left and placing it won't create more than {limit} consecutive ones)
            if (oneCount < one && !(lastNum == 1 && streak == limit))
                count += CountArrays(
                    zeroCount,
                    oneCount + 1,
                    1,
                    lastNum == 1 ? streak + 1 : 1);

            // Option 2: Place a 0 (we still have zeros left and placing it won't create more than {limit} consecutive zeros)
            if (zeroCount < zero && !(lastNum == 0 && streak == limit))
                count += CountArrays(
                    zeroCount + 1,
                    oneCount,
                    0,
                    lastNum == 0 ? streak + 1 : 1);

            // Apply modulo to keep the answer small
            count %= MOD;

            // Save result using memoization so we never recompute this state again
            memo[zeroCount, oneCount, lastIndex, streak] = count;

            return count;
        }

        // Start recursion (0 zeros used, 0 ones used, none last number (-1), streak is 0)
        return (int)CountArrays(0, 0, -1, 0);
    }
}