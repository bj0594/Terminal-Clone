using System.IO;

public static class Commands
{
    // Creates a new empty file using the filename provided by the user.
    public static void Touch(string[] parts)
    {
        // Get the filename from the command arguments.
        string filename = parts[1];

        // Create the file and immediately close it.
        File.Create(filename).Dispose();
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

        // Move the file when the command is "mv".
        if (move)
        {
            File.Move(source, destination);
        }
        else
        {
            // Copy the file when the command is "cp".
            File.Copy(source, destination);
        }
    }


    // Deletes a file from the specified path.
    public static void Remove(string[] parts)
    {
        // Get the filename from the command arguments.
        string filename = parts[1];

        // Delete the specified file.
        File.Delete(filename);
    }


    // Displays a PowerShell-style error when an unknown command is entered.
    public static void ShowCommandNotFoundError(string command)
    {
        // Use red text to make the error visually distinct.
        Console.ForegroundColor = ConsoleColor.Red;

        // Display the command that could not be found.
        Console.WriteLine(
            $"{command} : The term '{command}' is not recognized as the name of a cmdlet, function, script file, or operable program. Check the spelling of the name, or if a path was included, verify that the path is correct and try again."
        );

        // Reproduce the structure of a PowerShell error message.
        Console.WriteLine("At line:1 char:1");

        // Show the command that caused the error.
        Console.WriteLine($"+ {command}");

        // Underline the command with tildes.
        Console.WriteLine(
            $"+ {new string('~', command.Length)}"
        );

        // Display information about the type of error.
        Console.WriteLine(
            $"    + CategoryInfo          : ObjectNotFound: ({command}:String) [], CommandNotFoundException"
        );

        // Display the error identifier.
        Console.WriteLine(
            "    + FullyQualifiedErrorId : CommandNotFoundException"
        );

        // Restore the normal console text color.
        Console.ResetColor();
    }
}