public class Problem61
{
    // Rotates a linked list to the right by k positions
    public static ListNode? RotateRight(ListNode head, int k)
    {
        // If the list is empty or no rotation is needed, return as it is
        if (head is null || k == 0) return head;

        // Get total number of nodes in the list
        int listLength = GetLength(head);

        // Rotating by the list length results in the same list
        int rotations = k % listLength;

        // If effective rotation is zero, no work is needed
        if (rotations == 0) return head;

        // Copy the first part of the list (everything except the last 'rotations' nodes)
        ListNode firstPart = PopulateNode(new(), head, 0, listLength - rotations);

        // Advance head so it points to the new beginning of the rotated list
        for (int i = 0; i < listLength - rotations; ++i)
            head = head.next!;

        // Append the copied first part to the end of the remaining list
        return MergeNodes(head, firstPart);
    }

    // Standard linked list node definition
    public class ListNode(int val = 0, ListNode? next = null)
    {
        public int val = val;
        public ListNode? next = next;
    }

    // Returns the length of the linked list
    private static int GetLength(ListNode head)
    {
        int length = 1;

        // Traverse until the end, counting nodes
        while (head.next != null)
        {
            length++;
            head = head.next;
        }

        return length;
    }

    // Creates a new linked list by copying 'length' nodes from 'source'
    private static ListNode PopulateNode(ListNode node, ListNode? source, int currentLength, int length)
    {
        // Stop if source ends or desired length is reached
        if (source is null || currentLength == length)
            return node;

        // Copy current value
        node.val = source.val;

        // If more nodes are needed, create next node and recurse
        if (currentLength + 1 != length)
        {
            node.next = new();
            PopulateNode(node.next, source.next, currentLength + 1, length);
        }
        else
        {
            // Final recursive step
            PopulateNode(node, source.next, currentLength + 1, length);
        }

        return node;
    }

    // Appends node2 to the end of node1
    private static ListNode MergeNodes(ListNode? node1, ListNode? node2)
    {
        // Found the last node of node1, attach node2 here
        if (node1 is not null && node1.next is null && node2 is not null)
        {
            node1.next = node2;
            return node1;
        }
        else if (node1 is not null)
        {
            // Continue traversing to the end
            MergeNodes(node1.next, node2);
        }

        // Return original head of node1
        return node1!;
    }

    // Helper method for printing the node list
    public static void PrintList(ListNode? head)
    {
        Console.Write("Merged Node List: ");
        while (head != null)
        {
            Console.Write(head.val);

            if (head.next != null)
                Console.Write(" -> ");

            head = head.next;
        }

        Console.WriteLine();
    }
}