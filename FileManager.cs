using System.IO;

public static class Commands
{
    // Creates a new empty file.
    public static void Touch(string[] parts)
    {
        // Get the filename from the command arguments.
        string filename = parts[1];

        // Only create the file if it does not already exist.
        if (!File.Exists(filename))
        {
            File.Create(filename).Dispose();
        }
    }


    // Copies a file to a new name or location.
    public static void Copy(string[] parts)
    {
        // Get the source file.
        string source = parts[1];

        // Get the destination.
        string destination = parts[2];

        // Copy the file to the destination.
        CopyOrMove(source, destination, false);
    }


    // Moves a file to a new location or renames it.
    public static void Move(string[] parts)
    {
        // Get the source file.
        string source = parts[1];

        // Get the destination.
        string destination = parts[2];

        // Move the file to the destination.
        CopyOrMove(source, destination, true);
    }


    // Handles the shared path logic for copy and move.
    private static void CopyOrMove(
        string source,
        string destination,
        bool move)
    {
        // Keep the original filename when the destination is a directory.
        if (Directory.Exists(destination))
        {
            destination = Path.Combine(
                destination,
                Path.GetFileName(source)
            );
        }

        // Move the file when requested.
        if (move)
        {
            File.Move(source, destination);
        }
        else
        {
            // Otherwise, copy the file.
            File.Copy(source, destination);
        }
    }


    // Deletes a file.
    public static void Remove(string[] parts)
    {
        // Get the filename from the command arguments.
        string filename = parts[1];

        // Delete the specified file.
        File.Delete(filename);
    }


    // Displays an error when a command has incorrect arguments.
    public static void ShowArgumentError(string command)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine(
            $"Incorrect usage of '{command}'."
        );

        Console.ResetColor();
    }


    // Displays an error when a file operation fails.
    public static void ShowFileError()
    {
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine(
            "The file operation could not be completed."
        );

        Console.ResetColor();
    }


    // Displays a PowerShell-style error for an unknown command.
    public static void ShowCommandNotFoundError(string command)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine(
            $"{command} : The term '{command}' is not recognized as the name of a cmdlet, function, script file, or operable program. Check the spelling of the name, or if a path was included, verify that the path is correct and try again."
        );

        Console.WriteLine("At line:1 char:1");
        Console.WriteLine($"+ {command}");
        Console.WriteLine(
            $"+ {new string('~', command.Length)}"
        );

        Console.WriteLine(
            $"    + CategoryInfo          : ObjectNotFound: ({command}:String) [], CommandNotFoundException"
        );

        Console.WriteLine(
            "    + FullyQualifiedErrorId : CommandNotFoundException"
        );

        Console.ResetColor();
    }
}