public class Problem796
{
    public static bool RotateString(string s, string goal)
    {
        // Rotated strings must have the same length
        if (s.Length != goal.Length) return false;

        // If both strings are empty, they are trivially rotations
        if (s.Length == 0) return true;

        int n = s.Length;

        // A valid rotation must start with goal[0]
        char startingLetter = goal[0];

        // Store every index in s where a rotation could begin
        List<int> indices = [];

        for (int i = 0; i < n; ++i)
        {
            if (s[i] == startingLetter)
                indices.Add(i);
        }

        // If goal[0] never appears in s, no rotation can match
        if (indices.Count == 0) return false;

        // Try every possible rotation start
        foreach (int index in indices)
        {
            int j = 0;
            bool isMatch = true;

            // Compare from the chosen start index to the end of s
            for (int i = index; i < n; ++i)
            {
                if (s[i] != goal[j++])
                {
                    isMatch = false;
                    break;
                }
            }

            // If the suffix already failed, try the next candidate
            if (!isMatch) continue;

            // Wrap around and compare from the start of s up to index - 1
            for (int i = 0; i < index; ++i)
            {
                if (s[i] != goal[j++])
                {
                    isMatch = false;
                    break;
                }
            }

            // If every character matched, goal is a valid rotation
            if (isMatch) return true;
        }

        // No rotation matched goal
        return false;
    }

    // Alternative solution
    public static bool RotateString2(string s, string goal)
        => s.Length == goal.Length && (s + s).Contains(goal);
}