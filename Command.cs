// Commands.cs
static class Echo
{
    public static void Run(string[] args)
        => Console.WriteLine(string.Join(" ", args.Skip(1)));
}

static class Cat
{
    public static void Run(string[] args)
{
    if (args.Length < 2)
    {
        Console.WriteLine("cat: mangler filnavn");
        return;
    }

    try
    {
        Console.WriteLine(File.ReadAllText(args[1]));
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine($"cat: {args[1]}: filen finnes ikke");
    }
    catch (DirectoryNotFoundException)
    {
        Console.WriteLine($"cat: {args[1]}: mappen finnes ikke");
    }
    catch (UnauthorizedAccessException)
    {
        Console.WriteLine($"cat: {args[1]}: ingen tilgang");
    }
    catch (Exception e)
    {
        Console.WriteLine($"cat: en feil oppstod: {e.Message}");
    }
}
}

static class Ls
{
    public static void Run(string[] args)
    {
        foreach (string path in Directory.GetFileSystemEntries("."))
            Console.WriteLine(Path.GetFileName(path));
    }
}