// Get the directory where the program is currently running.
string currentDirectory = Directory.GetCurrentDirectory();

while (true)
{
    // Display a PowerShell-style prompt showing the current directory.
    Console.Write(
        $"PS {currentDirectory}> "
    );

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

    switch (parts[0])
    {
        case "touch":
            Commands.Touch(parts);
            break;

        case "cp":
            Commands.Copy(parts);
            break;

        case "mv":
            Commands.Move(parts);
            break;

        case "rm":
            Commands.Remove(parts);
            break;

        default:
            Commands.ShowCommandNotFoundError(parts[0]);
            break;
    }
}