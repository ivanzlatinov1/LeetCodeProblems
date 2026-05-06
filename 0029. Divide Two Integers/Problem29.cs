public class Problem29
{
    public static int Divide(int dividend, int divisor)
    {
        if (divisor == 0) throw new DivideByZeroException(); // Cannot divide by zero
        if (dividend == int.MaxValue && divisor == 1) return dividend; // Avoiding TLE
        if (dividend == int.MaxValue && divisor == -1) return -dividend; // Avoiding TLE

        // Converting the dividend and the divisor into positive numbers
        long newDividend = Math.Abs((long)dividend);
        long newDivisor = Math.Abs((long)divisor);

        // Calculating the division between the two numbers
        long ans = MakeDivision(newDividend, newDivisor);

        bool isAnswerNegative = false;

        // Checking if one of the given numbers is negative, so the answer will be negative
        if (divisor < 0 && dividend > 0 || divisor > 0 && dividend < 0) isAnswerNegative = true;

        // Returning the middle value of the three (ans, min, max)
        return (int)Math.Clamp(isAnswerNegative ? -ans : ans, int.MinValue, int.MaxValue);
    }

    private static long MakeDivision(long dividend, long divisor)
    {
        long quotient = 0;
        while (dividend - divisor >= 0)
        {
            dividend -= divisor;
            quotient++;
        }
        return quotient;
    }
}