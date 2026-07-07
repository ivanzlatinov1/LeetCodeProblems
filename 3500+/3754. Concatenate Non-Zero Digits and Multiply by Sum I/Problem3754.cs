public class Problem3754
{
    public static long SumAndMultiply(int n)
    {
        int num = 0, sum = 0, multiplier = 1;
        while (n > 0)
        {
            int digit = n % 10;

            if (digit != 0)
            {
                num = digit * multiplier + num;
                multiplier *= 10;
            }

            sum += digit;
            n /= 10;
        }

        return (long)num * sum;
    }
}