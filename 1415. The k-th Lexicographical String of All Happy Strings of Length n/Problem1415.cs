public class Problem1415
{
    public static string GetHappyString(int n, int k)
    {
        // Initializing a list where we can store happy strings
        List<string> happyStrings = [];

        // Backtracking method to find all strings with length n
        void Backtrack(string current, char prev)
        {
            // If the current string length is equal to n, we add it to the list
            if (current.Length == n)
            {
                happyStrings.Add(current);
                return;
            }

            // Adding if-checks to prevent from having two same letters next to each other
            // Keeping the lexicographic order a -> b -> c
            if (prev != 'a')
                Backtrack(current + 'a', 'a'); // Calling the backtracking method with the new formed string
            if (prev != 'b')
                Backtrack(current + 'b', 'b');
            if (prev != 'c')
                Backtrack(current + 'c', 'c');
        }

        // Starting values: current = "" (empty string) and previous letter = something different from [a, b, c] (ex. '?')
        Backtrack("", '?');

        // If k is outside the bounds of the list, we return an empty string, otherwise we return the wanted happy string
        return happyStrings.Count < k ? string.Empty : happyStrings[k - 1];
    }
}