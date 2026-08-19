namespace Terminal_Clone;

class Program
{
    static void Main(string[] args)
    {
        LineManager lineManager = new LineManager();

        string currentDirectory = Directory.GetCurrentDirectory();

        while (true)
        {
            Console.Write($"PS {currentDirectory}> ");

            string input = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }

            string[] parts = input.Split(
                ' ',
                StringSplitOptions.RemoveEmptyEntries
            );

            string command = parts[0].ToLower();

            try
            {
                switch (command)
                {
                    // LineManager
                    case "head":
                    {
                        if (TryGetLineArguments(
                            parts,
                            out string filePath,
                            out int numberOfLines))
                        {
                            lineManager.Head(filePath, numberOfLines);
                        }

                        break;
                    }

                    case "tail":
                    {
                        if (TryGetLineArguments(
                            parts,
                            out string filePath,
                            out int numberOfLines))
                        {
                            lineManager.Tail(filePath, numberOfLines);
                        }

                        break;
                    }

                    case "wc":
                    {
                        if (parts.Length != 2)
                        {
                            Console.WriteLine("Usage: wc <file>");
                            break;
                        }

                        string filePath = parts[1];

                        lineManager.Wc(filePath);
                        break;
                    }


                    // FileManager
                    case "touch":
                    {
                        if (parts.Length != 2)
                        {
                            Commands.ShowArgumentError("touch");
                            break;
                        }

                        Commands.Touch(parts);
                        break;
                    }

                    case "cp":
                    {
                        if (parts.Length != 3)
                        {
                            Commands.ShowArgumentError("cp");
                            break;
                        }

                        Commands.Copy(parts);
                        break;
                    }

                    case "mv":
                    {
                        if (parts.Length != 3)
                        {
                            Commands.ShowArgumentError("mv");
                            break;
                        }

                        Commands.Move(parts);
                        break;
                    }

                    case "rm":
                    {
                        if (parts.Length != 2)
                        {
                            Commands.ShowArgumentError("rm");
                            break;
                        }

                        Commands.Remove(parts);
                        break;
                    }


                    // InfoManager
                    case "echo":
                        Echo.Run(parts);
                        break;

                    case "cat":
                        Cat.Run(parts);
                        break;

                    case "ls":
                        Ls.Run(parts);
                        break;


                    // Program commands
                    case "exit":
                        return;

                    default:
                        Commands.ShowCommandNotFoundError(command);
                        break;
                }
            }
            catch (Exception)
            {
                Commands.ShowFileError();
            }
        }
    }


    static bool TryGetLineArguments(
        string[] parts,
        out string filePath,
        out int numberOfLines)
    {
        filePath = "";
        numberOfLines = 10;

        if (parts.Length == 2)
        {
            filePath = parts[1];
            return true;
        }

        if (parts.Length == 4 && parts[1] == "-n")
        {
            if (!int.TryParse(parts[2], out numberOfLines))
            {
                Console.WriteLine(
                    "Number of lines must be a valid number."
                );

                return false;
            }

            if (numberOfLines <= 0)
            {
                Console.WriteLine(
                    "Number of lines must be greater than 0."
                );

                return false;
            }

            filePath = parts[3];
            return true;
        }

        Console.WriteLine(
            "Usage: <command> <file> or <command> -n <number> <file>"
        );

        return false;
    }
}
