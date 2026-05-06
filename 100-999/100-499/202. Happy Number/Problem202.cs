public class Problem202
{
    public static bool IsHappy(int n)
    {
        // If we see the same number twice, we will encounter TLE
        HashSet<int> seen = [];

        int squareSum = 0;
        int current = n;

        // If the add method fails, that means we have encountered that number before, so we need to end the cycle
        while (seen.Add(current))
        {
            // Calculate the square sum of the digits of the number
            while (current > 0)
            {
                squareSum += (int)Math.Pow(current % 10, 2);
                current /= 10;
            }

            // If the sum is equal to 1, that is what we are looking for, so we return true
            if (squareSum == 1) return true;

            // Otherwise the current number becomes the previously calculated square sum
            current = squareSum;
            squareSum = 0;
        }

        return false;
    }
}