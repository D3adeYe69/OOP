
using System.Text.Json;


public class FileWriter
{
    // Method to write universe classification data to files
    public static void WriteOutputToFiles(Dictionary<string, List<View>> universeClassification)
    {
        string baseDir = AppContext.BaseDirectory;
        var outputDirectory = Path.Combine(baseDir, "..", "..", "..", "resources");

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        foreach (var entry in universeClassification)
        {
            string universeName = entry.Key.Replace(" ", "_");
            string outputPath = Path.Combine(outputDirectory, $"{universeName}_output.json");

            string jsonOutput = JsonSerializer.Serialize(entry.Value, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(outputPath, jsonOutput);
        }
    }
}
