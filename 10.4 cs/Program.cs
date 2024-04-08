using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter text. Press Enter twice to finish:");
            List<string> lines = ReadLinesFromConsole();

            string outputFileName = GetOutputFileName();
            WriteLongestWordsToFile(outputFileName, lines);

            Console.WriteLine($"Results have been saved to the file: {outputFileName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        Console.ReadLine(); 
    }

    public static List<string> ReadLinesFromConsole()
    {
        List<string> lines = new List<string>();
        string line;
        while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
        {
            lines.Add(line);
        }
        return lines;
    }

    public static string GetOutputFileName()
    {
        Console.WriteLine("Enter the output file name (without extension):");
        string fileName = Console.ReadLine();
        return fileName + ".txt"; 
    }

    public static void WriteLongestWordsToFile(string outputFileName, List<string> lines)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                foreach (string line in lines)
                {
                    string[] words = line.Split(new char[] { ' ', ',', '.', ';', ':', '-', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length > 0)
                    {
                        string longestWord = words.OrderByDescending(w => w.Length).First();
                        writer.WriteLine($"{longestWord}, Length: {longestWord.Length}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error writing to file: {ex.Message}");
        }
    }
}
