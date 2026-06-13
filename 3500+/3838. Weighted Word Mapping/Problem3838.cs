using System.Text;

public class Problem3838
{
    public static string MapWordWeights(string[] words, int[] weights)
    {
        // Initialize a string builder for the result string
        StringBuilder sb = new();

        // Iterate through each word in the words array
        foreach (string word in words)
        {
            int sum = 0;
            foreach (char letter in word)
            {
                // We map the letter from the word to the corresponding index of it from the 26-indexed weights array
                // by subtracting 97, because the ascii code of the first alphabet letter 'a' is 97
                // so that if, for example, the current letter is 'a' with ascii code 97, it will map to weights[0]
                // then add that weight to the sum
                sum += weights[letter - 97];
            }

            // We need to take the letter that is {sum % 26} positions away from the last alphabet letter 'z'
            // whose ascii code is 122, so we subtract the sum from it to find the searched letter and append it to result
            sb.Append((char)(122 - sum % 26));
        }

        return sb.ToString();
    }
}