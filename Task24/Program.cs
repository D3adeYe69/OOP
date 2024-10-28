using System;
using System.IO;
using System.Linq;

public class FileReader
{
    public string ReadFileIntoString(string path)
    {
        try
        {
            return File.ReadAllText(path);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file '{path}': {ex.Message}");
            return string.Empty;
        }
    }
}

public class TextData
{
    private string fileName;
    private string text;
    private int numberOfVowels;
    private int numberOfConsonants;
    private int numberOfLetters;
    private int numberOfSentences;
    private string longestWord;

    public TextData(string fileName, string text)
    {
        this.fileName = fileName;
        this.text = text;
        AnalyzeText();
    }

    private void AnalyzeText()
    {
        numberOfVowels = text.Count(c => "aeiouAEIOU".Contains(c));
        numberOfConsonants = text.Count(c => char.IsLetter(c) && !"aeiouAEIOU".Contains(c));
        numberOfLetters = text.Count(char.IsLetter);
        numberOfSentences = text.Count(c => c == '.' || c == '!' || c == '?');
        longestWord = text.Split(new[] { ' ', '.', '!', '?', ',', ';', ':' }, StringSplitOptions.RemoveEmptyEntries)
                          .OrderByDescending(w => w.Length)
                          .FirstOrDefault() ?? string.Empty;
    }

    public string GetFilename() => fileName;
    public string GetText() => text;
    public int GetNumberOfVowels() => numberOfVowels;
    public int GetNumberOfConsonants() => numberOfConsonants;
    public int GetNumberOfLetters() => numberOfLetters;
    public int GetNumberOfSentences() => numberOfSentences;
    public string GetLongestWord() => longestWord;

    public override string ToString()
    {
        return $"Filename: {fileName}\n" +
               $"Text: {text}\n" +  // Display the text content
               $"Text Length: {text.Length} characters\n" +
               $"Number of Vowels: {numberOfVowels}\n" +
               $"Number of Consonants: {numberOfConsonants}\n" +
               $"Number of Letters: {numberOfLetters}\n" +
               $"Number of Sentences: {numberOfSentences}\n" +
               $"Longest Word: {longestWord}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Please provide the name(s) of the .txt file(s).");
            return;
        }

        FileReader fileReader = new FileReader();

        foreach (string fileName in args)
        {

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            string fileContent = fileReader.ReadFileIntoString(filePath);

            if (string.IsNullOrEmpty(fileContent))
            {
                Console.WriteLine($"No content to process for file: {fileName}");
                continue;
            }

            TextData textData = new TextData(fileName, fileContent);
            Console.WriteLine(textData);
            Console.WriteLine();
        }
    }
}
