// Get the directory where the program is currently running.
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