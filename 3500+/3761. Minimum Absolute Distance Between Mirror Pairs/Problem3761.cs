public class Problem3761
{
    public static int MinMirrorPairDistance(int[] nums)
    {
        // Initialize minimum distance as the biggest possible value
        int minDistance = int.MaxValue;

        // Mapping dictionary (key -> reversed number, value -> its first occurance in the array)
        Dictionary<int, int> dict = [];

        // Loop through all the digits in the array
        for (int i = 0; i < nums.Length; ++i)
        {
            // Compute the current reversed number
            int reversedNum = ReverseNumber(nums[i]);

            // If there was a reversed number of the current number before, get in the if statement
            if (dict.TryGetValue(nums[i], out int firstOccurence))
            {
                // Compute the minimum distance as currentIndex - firstOccurence
                minDistance = Math.Min(i - firstOccurence, minDistance);

                // Create new entry in the dictionary for the current reversed number
                dict[reversedNum] = i;
            }
            else
            {
                // First time seeing this number so we store its reversed value in the dictionary
                dict[reversedNum] = i;
            }
        }

        // Return minimum distance (-1 if there was no valid pair in the array)
        return minDistance == int.MaxValue ? -1 : minDistance;
    }

    // Helper method for reversing a number
    private static int ReverseNumber(int num)
    {
        // Turn the number into a char[]
        char[] digitsArray = num.ToString().ToCharArray();
        // Reverse the array
        Array.Reverse(digitsArray);

        for (int i = 0; i < digitsArray.Length; ++i)
            // We count the digits from the first occurence different from 0 to avoid numbers like 023, 0012, etc.
            if (digitsArray[i] != '0')
            {
                // Copy the reversed char array from the current index to another array, which we return as an integer
                char[] result = new char[digitsArray.Length - i];
                Array.Copy(digitsArray, i, result, 0, result.Length);
                return int.Parse(new string(result));
            }

        // If all the digits in the array were zeros, we return 0
        return 0;
    }
}