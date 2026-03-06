public class Problem1784
{
    public static bool CheckOnesSegment(string s)
    {
        // The string is guaranteed to start with '1' so there is exactly one segment of ones
        if (s.Length == 1) return true;

        // Boolean to check when the segment is over
        bool segmentEnded = false;
        for (int i = 1; i < s.Length; i++)
        {
            // If true, we cannot accept more segments of ones
            if (s[i] == '0')
                segmentEnded = true;
            // If true, there is at least one more segment of ones, which makes the condition false
            else if (segmentEnded && s[i] == '1')
                return false;
        }

        // There is exactly one segment of ones in the string so we are returning true
        return true;
    }
}