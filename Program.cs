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
                            Console.WriteLine("Usage: head <file> or head -n <number> <file>");
                            break;
                        }
                        if (parts[1] == "-n")
                        {
                            if (parts.Length < 4)
                            {
                                Console.WriteLine("Usage: head -n <number> <file>");
                                break;
                            }

                            if (!int.TryParse(parts[2], out int numberOfLines))
                            {
                                Console.WriteLine("Number of lines must be a valid number.");
                                break;
                            }

                            if (numberOfLines <= 0)
                            {
                                Console.WriteLine("Number of lines must be greater then 0.");
                                break;
                            }
                            string filePath = parts[3];
                            lineManager.Head(filePath, numberOfLines);
                        }
                        else
                        {
                            string filePath = parts[1];

                            lineManager.Head(filePath);
                        }
                        break;
                    }

                case "tail":
                    {
                        if (parts.Length < 2)
                        {
                            Console.WriteLine("Usage: tail <file>");
                            break;
                        }
                        if (parts[1] == "-n")
                        {
                            if (parts.Length < 4)
                            {
                                Console.WriteLine("Usage: tail -n <number> <file>");
                                break;
                            }

                            if (!int.TryParse(parts[2], out int numberOfLines))
                            {
                                Console.WriteLine("Number of lines must be a valid number.");
                                break;
                            }

                            if (numberOfLines <= 0)
                            {
                                Console.WriteLine("Number of lines must be greater then 0.");
                                break;
                            }
                            string filePath = parts[3];
                            lineManager.Tail(filePath, numberOfLines);
                        }
                        else
                        {
                            string filePath = parts[1];
                            lineManager.Tail(filePath);
                        }
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
