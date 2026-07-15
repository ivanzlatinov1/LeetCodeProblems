public class Problem3658
{
    public static int GcdOfOddEvenSums(int n)
    {
        int sumOdd = n * n, sumEven = n * (n + 1);

        for(int i = Math.Min(sumOdd, sumEven); i > 0; --i)
        {
            if(sumOdd % i == 0 && sumEven % i == 0) return i;
        }

        return 1;
    }
}