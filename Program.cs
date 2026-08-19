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

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = parts[0].ToLower();


            switch (command)
            {
                case "head":
                    Console.WriteLine("Head command");
                    break;

                case "tail":
                    Console.WriteLine("Tail command");
                    break;

                case "wc":
                    Console.WriteLine("Wc command");
                    break;

                case "exit":
                    return;

                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }
    }
}
