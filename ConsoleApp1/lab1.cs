
using System.Text.Json;


public class TraitData
{
    public List<Input> input { get; set; }
}

public class Input
{
    public int id { get; set; }
    public bool? isHumanoid { get; set; } // Nullable to handle cases where it's not provided
    public string planet { get; set; }
    public int? age { get; set; } // Nullable to handle cases where it's not provided
    public List<string> traits { get; set; } // Nullable for cases where traits may not exist
}



public class JsonReader
{
    public TraitData ReadJson(string filePath)
    {
        // Read the JSON file
        string jsonString = File.ReadAllText(filePath);

        // Deserialize the JSON into the TraitData object
        TraitData traitData = JsonSerializer.Deserialize<TraitData>(jsonString);

        return traitData;
    }

    public void DisplayData(TraitData traitData)
    {
        // Output the data
        foreach (var input in traitData.input)
        {
            Console.WriteLine($"ID: {input.id}");
            Console.WriteLine($"Is Humanoid: {input.isHumanoid}");
            Console.WriteLine($"Planet: {input.planet}");
            Console.WriteLine($"Age: {input.age}");
            Console.WriteLine($"Traits: {string.Join(", ", input.traits ?? new List<string>())}");
            Console.WriteLine();
        }
    }
}



class Program
{
    static void Main()
    {
        // Path to your JSON file
        string filePath = @"C:\Users\37367\Desktop\OOP\ConsoleApp1\resources\input.json";


        // Create an instance of JsonReader
        JsonReader jsonReader = new JsonReader();

        // Read the JSON file
        TraitData traitData = jsonReader.ReadJson(filePath);

        // Display the data
        jsonReader.DisplayData(traitData);
    }
}
