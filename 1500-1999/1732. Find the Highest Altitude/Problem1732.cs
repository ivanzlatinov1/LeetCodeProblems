public class Problem1732
{
    public static int LargestAltitude(int[] gain)
    {
        int prefixSum = 0, ans = 0;

        for(int i = 0; i < gain.Length; ++i)
        {
            prefixSum += gain[i];
            ans = Math.Max(ans, prefixSum);
        }

        return ans;
    }
}