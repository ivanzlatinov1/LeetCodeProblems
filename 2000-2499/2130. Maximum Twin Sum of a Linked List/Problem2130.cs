public class Problem2130
{
    public static int PairSum(ListNode head)
    {
        List<int> nodes = [];
        while (head is not null)
        {
            nodes.Add(head.val);
            head = head.next!;
        }

        int maxPairSum = int.MinValue, n = nodes.Count;
        for (int i = 0; i < n / 2; ++i)
        {
            maxPairSum = Math.Max(nodes[i] + nodes[n - 1 - i], maxPairSum);
        }

        return maxPairSum;
    }
}