public class Problem66
{
    public static int[] PlusOne(int[] digits)
    {
        // Example: [9, 8, 9] -> [9, 9, 0]
        // We treat the array as a number and add 1 to it

        // Start from the last digit
        int i = digits.Length - 1;

        // If the last digit is 9, we need to handle carry
        if (digits[i] == 9)
        {
            // Traverse the array from right to left
            while (i > 0)
            {
                // If current digit is not 9, no further carry is needed
                if (digits[i] != 9) return digits;

                // Set current digit to 0 (since 9 + 1 = 0 with carry 1)
                digits[i] = 0;

                // Check the previous digit
                if (digits[i - 1] < 9)
                {
                    // Add the carry to the previous digit
                    digits[i - 1] += 1;

                    // If no further carry is needed, return result
                    return digits;
                }

                // Move to the previous digit
                i--;
            }

            // If we reach here, all digits were 9 like [9,9,9]
            // So we create a new array with an extra digit -> [1,0,0,0]
            if (digits[i] == 9)
            {
                int[] result = new int[digits.Length + 1];
                result[0] = 1;
                return result;
            }
        }
        else
        {
            // If the last digit is less than 9, just increment it
            digits[i] += 1;
        }

        return digits;
    }
}
