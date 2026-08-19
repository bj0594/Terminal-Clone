using System.IO;

public static class Commands
{
    // Creates a new empty file using the filename provided by the user.
    public static void Touch(string[] parts)
    {
        string filename = parts[1];
        File.Create(filename).Dispose();
    }


    // Copies a file from the source path to the destination path.
    public static void Copy(string[] parts)
    {
        string source = parts[1];
        string destination = parts[2];

        if(Directory.Exists(destination))
        {
            File.Copy(
                source,
                Path.Combine(
                    destination, 
                    Path.GetFileName(source)
                )
            );
        }
        else
        {
            File.Copy(source, destination);
        }
    }


    // Moves a file to a new location or renames it.
    public static void Move(string[] parts)
    {
        
    }


    // Deletes a file from the specified path.
    public static void Remove(string[] parts)
    {
        string filename = parts[1];
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