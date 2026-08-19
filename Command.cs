// Commands.cs
static class Echo
{
    public static void Run(string[] args)
        => Console.WriteLine(string.Join(" ", args.Skip(1)));
}

static class Cat
{
    public static void Run(string[] args)
        => Console.WriteLine(File.ReadAllText(args[1]));
}

static class Ls
{
    public static void Run(string[] args)
    {
        foreach (string path in Directory.GetFileSystemEntries("."))
            Console.WriteLine(Path.GetFileName(path));
    }
}