public class Problem2452
{
    public static IList<string> TwoEditWords(string[] queries, string[] dictionary)
    {
        // Initialize a collection where we will store words from queries array, 
        // that match with some words from dictionary array after a maximum of two edits
        List<string> ans = [];

        // Brute-forcing the problem
        for (int i = 0; i < queries.Length; i++)
        {
            // For each word from queries, we iterate through each word from dictionary
            for (int j = 0; j < dictionary.Length; j++)
            {
                int edits = 0;
                for (int k = 0; k < queries[i].Length; k++)
                {
                    // If the two words differ by more than 2 letters, we exit
                    if (edits > 2)
                        break;

                    // If they differ on this letter, increment the edits variable
                    if (queries[i][k] != dictionary[j][k] && edits <= 2)
                        edits++;
                }

                // If the two words differ by maximum of 2 letters (which we search for)
                // We add the word from the queries array to the list
                if (edits <= 2)
                {
                    ans.Add(queries[i]);
                    break;
                }
            }
        }

        return ans;
    }
}