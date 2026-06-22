public class Problem1189
{
    public static int MaxNumberOfBalloons(string text)
    {
        Dictionary<char, int> chars = new()
        {
            ['b'] = 0,
            ['a'] = 0,
            ['l'] = 0,
            ['o'] = 0,
            ['n'] = 0
        };

        foreach (char symbol in text)
        {
            if (chars.ContainsKey(symbol))
                chars[symbol]++;
        }

        int occurances = int.MaxValue;
        foreach (char key in chars.Keys)
        {
            if (key != 'l' && key != 'o')
                occurances = Math.Min(occurances, chars[key]);
        }

        occurances = Math.Min(occurances, chars['l'] / 2);
        occurances = Math.Min(occurances, chars['o'] / 2);

        return occurances;
    }
}