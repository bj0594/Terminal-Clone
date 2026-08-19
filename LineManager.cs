namespace Terminal_Clone;

public class LineManager
{
    public void Head(string filePath, int numberOfLines = 6)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found...");
            return;
        }
        int lineCount = 0;

        foreach (string line in File.ReadLines(filePath))
        {
            Console.WriteLine(line);
            lineCount++;

            if (lineCount >= numberOfLines)
            {
                break;
            }
        }
    }
    public void Tail(string filePath, int numberOfLines = 6)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found...");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        int startIndex = Math.Max(0, lines.Length - numberOfLines);

        for (int i = startIndex; i < lines.Length; i++)
        {
            Console.WriteLine(lines[i]);
        }
    }
    public void Wc(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found...");
            return;
        }
        string text = File.ReadAllText(filePath);
    }
}