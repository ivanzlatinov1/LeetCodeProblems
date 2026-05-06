public class Problem1009
{
    // Reverting a number 'n' by his bits (0 -> 1 and 1 -> 0)
    public static int BitwiseComplement(int n)
    {
        // Base case for 0
        if (n == 0) return 1;

        // Initializing the result number
        int num = 0;
        // Keeping track of the powers of 2
        int pow = 0;

        while (n > 0)
        {
            // If the current bit is equal to 0, we need to perform an action
            if (n % 2 == 0)
                num += (int)Math.Pow(2, pow); // Add 2^pow to the result number

            // It doesn't matter if we have performed an operation, we divide the number by two and move on to the next power of 2
            n /= 2;
            pow++;
        }

        // Return the inverted number
        return num;
    }
}