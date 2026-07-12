public class Problem1331
{
    public static int[] ArrayRankTransform(int[] arr)
    {
        int n = arr.Length;
        int[] sortedArr = [..arr];
        Array.Sort(sortedArr);

        Dictionary<int, int> numbers = [];

        for (int i = 0, j = 0; i < n; i++)
        {
            if (!numbers.ContainsKey(sortedArr[i]))
            {
                numbers.Add(sortedArr[i], j++);
            }
        }

        for (int i = 0; i < n; i++)
        {
            arr[i] = numbers[arr[i]] + 1;
        }

        return arr;
    }
}