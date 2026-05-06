public class Problem788
{
    public static int RotatedDigits(int n)
    {
        // We store the answer in a variable
        int goodNumbers = 0;

        // If any of the numbers contains one of these digits, it is not 'good'
        int[] invalidDigits = [3, 4, 7];

        // Every 'good' number needs to have at least one of these digits
        int[] validDigits = [2, 5, 6, 9];

        // Iterate from 1 to n
        for (int i = 1; i <= n; ++i)
        {
            int num = i;

            // Assuming that the current number is valid
            bool isGood = true;

            // If we encounter one of the valid digits, we make it true
            bool isValidDigitFound = false;
            while (num > 0)
            {
                // Get the digits from right to left
                int digit = num % 10;

                // If it has one of the invalid digits, that's not a 'good' number, so we exit from the while
                if (invalidDigits.Contains(digit))
                {
                    isGood = false;
                    break;
                }

                // That if ensures us that the number has at least one valid digit
                if (!isValidDigitFound && validDigits.Contains(digit))
                {
                    isValidDigitFound = true;
                }

                num /= 10;
            }

            if (isGood && isValidDigitFound) goodNumbers++;
        }

        return goodNumbers;
    }
}