public class Problem3740
{
    public static int MinimumDistance(int[] nums)
    {
        // Initialize minimum distance as max value
        int minDistance = int.MaxValue;

        // Dictionary maps number -> 
        //  count: how many times we've seen it so far,
        //  i, j, k: indices of occurrences,
        //  repeats: used to cycle through indices when count = 3
        Dictionary<int, (int count, int i, int j, int k, int repeats)> dict = [];

        // Iterate through the array
        for (int currentIndex = 0; currentIndex < nums.Length; currentIndex++)
        {
            // Try to get existing tracking info for current number
            if (!dict.TryGetValue(nums[currentIndex], out (int count, int i, int j, int k, int repeats) value))
            {
                // First time seeing this number
                // Initialize count = 1 and store currentIndex as i
                dict[nums[currentIndex]] = (1, currentIndex, -1, -1, 0);
            }
            else
            {
                // Case when we already have 3 occurrences tracked
                if (value.count == 3)
                {
                    // Rotate which index to overwrite using repeats counter
                    if (value.repeats + 1 == 1)
                        value.i = currentIndex; // overwrite i
                    else if (value.repeats + 1 == 2)
                        value.j = currentIndex; // overwrite j
                    else if (value.repeats + 1 == 3)
                        value.k = currentIndex; // overwrite k

                    // Update repeats counter (cyclic mod 3)
                    value.repeats = (value.repeats + 1) % 3;

                    // Compute distance for current triple (i, j, k)
                    minDistance = Math.Min(GetTupleDistance(value.i, value.j, value.k), minDistance);
                }
                else if (value.count == 2)
                {
                    value.count += 1;
                    value.k = currentIndex;

                    // This is the 3rd occurrence -> complete a valid triple
                    // Compute distance for (i, j, k)
                    minDistance = Math.Min(GetTupleDistance(value.i, value.j, value.k), minDistance);
                }
                else
                {
                    // Case when we have only 1 occurrence so far
                    // This becomes the second occurrence
                    value.count += 1;
                    value.j = currentIndex;
                }

                // Save updated tuple back into dictionary
                dict[nums[currentIndex]] = value;
            }
        }

        // If no valid triple was found, return -1
        return minDistance == int.MaxValue ? -1 : minDistance;
    }

    // Computes distance of a triple (i, j, k)
    // distance = |i - j| + |j - k| + |k - i|
    private static int GetTupleDistance(int i, int j, int k)
        => Math.Abs(i - j) + Math.Abs(j - k) + Math.Abs(k - i);
}