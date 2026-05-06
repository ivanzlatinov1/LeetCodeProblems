public static partial class Display
{
    public static void Problems()
    {
        string[] topDirectories = Directory.GetDirectories(".");

        var problems = topDirectories
            .Select(dir => Path.GetFileName(dir))
            .Where(name => !string.IsNullOrWhiteSpace(name) && IsRangeFolder(name))
            .SelectMany(rangeFolder => Directory.GetDirectories(rangeFolder)
                .Select(dir => Path.GetFileName(dir))
                .Where(name =>
                    !string.IsNullOrWhiteSpace(name) &&
                    ProblemDirectoryRegex().IsMatch(name)))
            .Select(name =>
            {
                int splitIndex = name.IndexOf('.');
                int number = int.Parse(name[..splitIndex]);
                string title = name[(splitIndex + 1)..].Trim();

                return new { Number = number, Title = title };
            })
            .OrderBy(x => x.Number)
            .ToList();

        Console.WriteLine("\nPROBLEMS");
        Console.WriteLine(new string('-', 60));

        foreach (var p in problems)
        {
            Console.WriteLine($"{p.Number,5}. {p.Title}");
        }

        Console.WriteLine(new string('-', 60));
        Console.WriteLine($"Total: {problems.Count}");
    }

    private static bool IsRangeFolder(string name) => RangeFolderRegex().IsMatch(name);

    [System.Text.RegularExpressions.GeneratedRegex(@"^\d+-\d+$")]
    private static partial System.Text.RegularExpressions.Regex RangeFolderRegex();

    [System.Text.RegularExpressions.GeneratedRegex(@"^\d+\.\s")]
    private static partial System.Text.RegularExpressions.Regex ProblemDirectoryRegex();
}