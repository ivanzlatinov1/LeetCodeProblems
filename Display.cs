public static partial class Display
{
    public static void Problems()
    {
        var problems = GetProblemFoldersRecursive()
            .Select(name =>
            {
                int splitIndex = name.IndexOf('.');
                var number = int.Parse(name[..splitIndex]);
                var title = name[(splitIndex + 1)..].Trim();
                return new { Number = number, Title = title };
            })
            .OrderBy(x => x.Number)
            .ToList();

        Console.WriteLine("\nPROBLEMS");
        Console.WriteLine(new string('-', 60));

        foreach (var problem in problems)
            Console.WriteLine($"{problem.Number,5}.  {problem.Title}");

        Console.WriteLine(new string('-', 60));
        Console.WriteLine($"Total: {problems.Count}");
    }

    private static IEnumerable<string> GetProblemFoldersRecursive(string path = "./")
    {
        foreach (var dir in Directory.GetDirectories(path))
        {
            var name = Path.GetFileName(dir)!;

            if (ProblemDirectoryRegex().IsMatch(name))
                yield return name;
            else if (IsRangeFolder(name))
                foreach (var problem in GetProblemFoldersRecursive(dir))
                    yield return problem;
        }
    }

    private static bool IsRangeFolder(string name) => RangeFolderRegex().IsMatch(name);

    [System.Text.RegularExpressions.GeneratedRegex(@"^\d+-\d+$")]
    private static partial System.Text.RegularExpressions.Regex RangeFolderRegex();

    [System.Text.RegularExpressions.GeneratedRegex(@"^\d+\.\s")]
    private static partial System.Text.RegularExpressions.Regex ProblemDirectoryRegex();
}