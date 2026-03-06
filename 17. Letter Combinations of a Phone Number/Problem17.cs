public class Problem17
{
    public static IList<string> LetterCombinations(string digits)
    {
        // A list for all letter combinations
        var letterCombinations = new List<string>();

        // If the input is empty, return an empty list
        if (string.IsNullOrEmpty(digits))
            return letterCombinations;

        void Backtrack(string currentCombination, int index)
        {
            // Valid result if both lengths match
            if (currentCombination.Length == digits.Length)
            {
                letterCombinations.Add(currentCombination);
                return;
            }

            // The loop should iterate {number of letters in a digit} times (7 and 9 have 4 letters, others have only 3)
            for (int i = 0; i < ((digits[index] == '7' || digits[index] == '9') ? 4 : 3); i++)
            {
                // Convert the char digit into int
                int digit = digits[index] - '0';

                // Base offset, assuming each digit maps to 3 letter
                int offset = 3 * (digit - 2);

                // 7 and 9 have 4 letters, so we increase the offset by 1 
                // (check only for 7, because there is no number after 9)
                if (digit > 7) offset++;

                // Compute the actual letter using ASCII math
                char letter = (char)('a' + offset + i);

                // Recurse to build the next character in the combination
                Backtrack(currentCombination + letter, index + 1);
            }
        }

        // Start backtracking with and empty string from index = 0
        Backtrack("", 0);

        return letterCombinations;
    }
}