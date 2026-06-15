public class Problem2095
{
    public static ListNode? DeleteMiddle(ListNode head)
    {
        if (head.next == null) return null;

        // Determine the linked list length
        ListNode current = head;
        int n = 1;
        while (current.next != null)
        {
            n++;
            current = current.next;
        }

        // Find the node we want to remove (the middle node)
        int mid = n / 2;

        // Start from the beginning
        current = head;
        for (int i = 0; i < mid - 1; i++)
        {
            // Append every node until the mid one
            current = current.next!;
        }

        // Append the rest of the nodes skipping the mid one
        current.next = current.next!.next;

        return head;
    }
}