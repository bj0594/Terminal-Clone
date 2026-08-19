// Keeps the program running and waits for a new command after each operation.
while (true)
{
    // Display the terminal prompt.
    Console.Write("> ");

    // Read the complete command entered by the user.
    string input = Console.ReadLine() ?? "";

    // Ignore empty input and return to the prompt.
    if (string.IsNullOrWhiteSpace(input))
    {
        continue;
    }

    // Split the input into the command and its arguments.
    // For example: "touch test.txt" becomes ["touch", "test.txt"].
    string[] parts = input.Split(
        ' ',
        StringSplitOptions.RemoveEmptyEntries
    );

    // Use the first part of the input to determine which command to run.
    switch (parts[0])
    {
        case "touch":

            // Create a new file.
            Commands.Touch(parts);
            break;

        case "cp":

            // Copy an existing file.
            Commands.Copy(parts);
            break;

        case "mv":

            // Move or rename an existing file.
            Commands.Move(parts);
            break;

        case "rm":

            // Remove an existing file.
            Commands.Remove(parts);
            break;

        default:

            // The entered command does not match any supported command.
            Commands.ShowCommandNotFoundError(parts[0]);
            break;
    }
}