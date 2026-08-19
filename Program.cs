namespace Terminal_Clone;

class Program
{
    static void Main(string[] args)
    {
        LineManager lineManager = new LineManager();

        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = parts[0].ToLower();


            switch (command)
            {
                case "head":
                    {
                        if (TryGetLineArguments(parts, out string filePath, out int numberOfLines))
                        {
                            lineManager.Head(filePath, numberOfLines);
                        }
                        break;
                    }

                case "tail":
                    {
                        if (TryGetLineArguments(parts, out string filePath, out int numberOfLines))
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

                case "exit":
                    return;

                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }
    }
    static bool TryGetLineArguments(string[] parts, out string filePath, out int numberOfLines)
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
                Console.WriteLine("Number of lines must be valid number.");
                return false;
            }

            if (numberOfLines <= 0)
            {
                Console.WriteLine("Number of lines must be a greater than 0.");
                return false;
            }

            filePath = parts[3];
            return true;
        }
        Console.WriteLine("Usage: <command> <file> or <command> -n <number> <file>");
        return false;
    }
}
﻿// Get the directory where the program is currently running.
string currentDirectory = Directory.GetCurrentDirectory();

while (true)
{
    // Display the current directory as a PowerShell-style prompt.
    Console.Write($"PS {currentDirectory}> ");

    // Read the command entered by the user.
    string input = Console.ReadLine() ?? "";

    // Ignore empty input and return to the prompt.
    if (string.IsNullOrWhiteSpace(input))
    {
        continue;
    }

    // Split the input into the command and its arguments.
    string[] parts = input.Split(
        ' ',
        StringSplitOptions.RemoveEmptyEntries
    );

    try
    {
        switch (parts[0])
        {
            case "touch":

                // Check that a filename was provided.
                if (parts.Length != 2)
                {
                    Commands.ShowArgumentError("touch");
                    break;
                }

                Commands.Touch(parts);
                break;


            case "cp":

                // Check that a source and destination were provided.
                if (parts.Length != 3)
                {
                    Commands.ShowArgumentError("cp");
                    break;
                }

                Commands.Copy(parts);
                break;


            case "mv":

                // Check that a source and destination were provided.
                if (parts.Length != 3)
                {
                    Commands.ShowArgumentError("mv");
                    break;
                }

                Commands.Move(parts);
                break;


            case "rm":

                // Check that a filename was provided.
                if (parts.Length != 2)
                {
                    Commands.ShowArgumentError("rm");
                    break;
                }

                Commands.Remove(parts);
                break;


            default:

                // Display an error for an unknown command.
                Commands.ShowCommandNotFoundError(parts[0]);
                break;
        }
    }
    catch (Exception)
    {
        // Display a simple error without stopping the program.
        Commands.ShowFileError();
    }
}
