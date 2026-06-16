using System.Text;

public class Problem3612
{
    public static string ProcessStr(string s)
    {
        StringBuilder sb = new();

        for (int i = 0; i < s.Length; ++i)
        {
            if (char.IsLower(s[i]))
            {
                sb.Append(s[i]);
                continue;
            }

            if (sb.Length > 0)
            {
                if (s[i] == '*')
                {
                    sb.Remove(sb.Length - 1, 1);
                }
                else if (s[i] == '#')
                {
                    sb.Append(sb);
                }
                else if (s[i] == '%')
                {
                    int l = 0, r = sb.Length - 1;
                    while (l < r)
                    {
                        (sb[r], sb[l]) = (sb[l], sb[r]);
                        l++; r--;
                    }
                }
            }
        }

        return sb.ToString();
    }
}