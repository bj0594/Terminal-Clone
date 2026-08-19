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
                        if (parts.Length < 2)
                        {
                            Console.WriteLine("Usage: head <file>");
                            break;
                        }
                        string filePath = parts[1];

                        lineManager.Head(filePath);
                        break;
                    }

                case "tail":
                    {
                        if (parts.Length < 2)
                        {
                            Console.WriteLine("Usage: tail <file>");
                            break;
                        }
                        string filePath = parts[1];
                        lineManager.Tail(filePath);
                        break;
                    }

                case "wc":
                    {
                        if (parts.Length < 2)
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
}
