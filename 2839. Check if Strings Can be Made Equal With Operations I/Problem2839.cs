public static class Problem2839
{
    // Private property to check if the modified strings are equal
    private static bool _areEqual = false;
    public static bool CanBeEqual(string s1, string s2)
    {
        // If the two strings are equal, no work needed
        if (s1 == s2) return true;

        // Conditionally, the length of both strings is equal to 4
        // Start by replacing indices in ascending order (0 -> 2 and 1 -> 3)
        ReplaceIndicesFromAscending(s1, s2, 0, 2);

        // If the strings still differ, try replacing indices in descending order (2 -> 4, 1 -> 3)
        if (!_areEqual)
            ReplaceIndicesFromDescending(s1, s2, 1, 3);

        return _areEqual;
    }

    private static void ReplaceIndicesFromAscending(string str1, string str2, int i, int j)
    {
        // If the two strings are equal, we modify the global boolean
        if (str1 == str2)
        {
            _areEqual = true;
            return;
        }

        // Stop swapping indices when they get out of bounds
        if (j == 4) return;

        // Swap the two indices of str1
        char[] charArr = str1.ToCharArray();
        (charArr[i], charArr[j]) = (charArr[j], charArr[i]);

        // Recurse for the next (and last) iteration
        ReplaceIndicesFromAscending(new string(charArr), str2, i + 1, j + 1);
    }

    private static void ReplaceIndicesFromDescending(string str1, string str2, int i, int j)
    {
        // Same approach here
        if (str1 == str2)
        {
            _areEqual = true;
            return;
        }

        // Stop swapping indices when they get out of bounds
        if (i == -1) return;

        // Swapping the indices
        char[] charArr = str1.ToCharArray();
        (charArr[i], charArr[j]) = (charArr[j], charArr[i]);

        // Continuing to the next iteration
        ReplaceIndicesFromDescending(new string(charArr), str2, i - 1, j - 1);
    }
}