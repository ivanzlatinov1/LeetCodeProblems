public class Problem1833
{
    public static int MaxIceCream(int[] costs, int coins)
    {
        // Sort the array via custom counting sort algorithm
        costs = CountingSort(costs);
        int ans = 0;

        for (int i = 0; i < costs.Length; ++i)
        {
            // If the coins are not enough to buy the current cost,
            // we return the number of items we already bought
            if (coins < costs[i]) return ans;

            // Otherwise, we buy the current item
            coins -= costs[i];
            ans++;
        }

        return ans;
    }

    private static int[] CountingSort(int[] arr)
    {
        int max = int.MinValue, n = arr.Length;

        // Find the maximum value of the array
        for (int i = 0; i < n; ++i)
            max = Math.Max(arr[i], max);

        // Initialize a count array where we store occurances for numbers [1 : max] in {arr}
        int[] counts = new int[max];

        // Count the occurrences of each number
        // We use arr[i] - 1 because array indices start at 0,
        // while our numbers start at 1
        for (int i = 0; i < n; ++i)
            counts[arr[i] - 1]++;

        // Index used to overwrite the original array
        int current = 0;

        // Rebuild the sorted array using the frequency information
        for (int i = 0; i < max; ++i)
        {
            // Insert the number (i + 1) exactly counts[i] times
            for (int j = 0; j < counts[i]; j++)
                arr[current++] = i + 1;
        }

        // Return the sorted array
        return arr;
    }
}