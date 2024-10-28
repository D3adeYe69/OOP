using System.IO;
using System.Text.Json;

public class JsonReader
{
    public static TraitData ReadJson(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<TraitData>(jsonString);
    }
}
