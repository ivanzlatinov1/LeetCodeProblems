public class Problem1758
{
    public static int MinOperations(string s)
    {
        // Initialize the first array, starting from 1 (10101010...)
        char[] startingOnes = new char[s.Length];
        int min1 = s[0] == '0' ? 1 : 0;
        startingOnes[0] = '1';

        // Initialize the second array, starting from 0 (0101010...)
        char[] startingZeros = new char[s.Length];
        int min2 = s[0] == '1' ? 1 : 0;
        startingZeros[0] = '0';

        for (int i = 1; i < s.Length; i++)
        {
            // Check if the current character matches the previous one in the "starting with 1" pattern
            if (startingOnes[i - 1] == s[i])
            {
                min1++;
                startingOnes[i] = s[i] == '1' ? '0' : '1';
            }
            else
                startingOnes[i] = s[i]; // Alternating rule is satisfied

            // Check if the current character matches the previous one in the "starting with 0" pattern
            if (startingZeros[i - 1] == s[i])
            {
                min2++;
                startingZeros[i] = s[i] == '1' ? '0' : '1';
            }
            else
                startingZeros[i] = s[i]; // Alternating rule is satisfied
        }

        // Getting the minimum operations out of the two arrays
        return Math.Min(min1, min2);
    }
}