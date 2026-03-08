public class Problem1980
{
    public static string FindDifferentBinaryString(string[] nums)
    {
        // Initializing a set, O(1) time complexity when searching in it
        var set = new HashSet<string>(nums);
        // Getting the length of a binary string in the array
        int n = nums[0].Length;

        // Recursive method to find a different binary string from those given
        string Find(string current)
        {
            // Returning when the length of the current string gets to n
            if (current.Length == n)
                return set.Contains(current) ? null! : current; // Returning the string if not present in the array, otherwise null

            // Starting to search for a binary string different from the others, appending a 0 to it
            string startingWithZero = Find(current + '0');

            if (startingWithZero != null)
                return startingWithZero;

            // If there is no string different from those given, starting with 0, there should be at least one, starting with 1
            return Find(current + '1');
        }

        return Find("");
    }
}