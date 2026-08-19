if (args.Length == 0)
{
    Console.WriteLine("Ingen kommando gitt");
    return;
}

switch (args[0])
{
    case "echo": Echo.Run(args); break;
    case "cat":  Cat.Run(args);  break;
    case "ls":   Ls.Run(args);   break;

    default:
        Console.WriteLine($"Ukjent kommando: {args[0]}");
        break;
}