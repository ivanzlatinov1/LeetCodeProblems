public class Problem1980
{
    public static string FindDifferentBinaryString(string[] nums)
    {
        var set = new HashSet<string>(nums);
        int n = nums[0].Length;

        string Find(string current)
        {
            if (current.Length == n)
                return set.Contains(current) ? null! : current;

            string startingWithZero = Find(current + '0');

            if (startingWithZero != null)
                return startingWithZero;

            return Find(current + '1');
        }

        return Find("");
    }
}