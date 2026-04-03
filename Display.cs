public static class Display
{
    public static void Problems()
    {
        string[] directories = Directory.GetDirectories(".");

        var sortedDirs = directories
            .Select(dir => new
            {
                Name = Path.GetFileName(dir),
                Number = GetProblemLeadingNumber(Path.GetFileName(dir))
            })
            .Where(x => x.Name != "bin" && x.Name != "obj" && x.Name != ".git")
            .OrderBy(x => x.Number);

        foreach (var dir in sortedDirs)
            Console.WriteLine(dir.Name);
    }

    private static int GetProblemLeadingNumber(string name)
    {
        string numberPart = new([.. name.TakeWhile(char.IsDigit)]);
        return int.TryParse(numberPart, out int result) ? result : int.MaxValue;
    }
}