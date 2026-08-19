namespace Terminal_Clone;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }

            if (input.ToLower() == "exit")
            {
                break;
            }
            Console.WriteLine($"You entered: {input}");
        }
    }
}
