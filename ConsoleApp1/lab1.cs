using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class TraitData
{
    public List<Individual> input { get; set; }
}

public class Individual
{
    public int id { get; set; }
    public bool? isHumanoid { get; set; }
    public string planet { get; set; }
    public int? age { get; set; }
    public List<string> traits { get; set; }
}

public class JsonReader
{
    public TraitData ReadJson(string filePath)
    {

        string jsonString = File.ReadAllText(filePath);


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

    public void DisplayFilteredData(TraitData traitData, bool filterEven)
    {

        var filteredIndividuals = traitData.input
            .Where(i => filterEven ? i.id % 2 == 0 : i.id % 2 != 0);


        Console.WriteLine($"Filtered Individuals (ID is {(filterEven ? "Even" : "Odd")}):");
        foreach (var individual in filteredIndividuals)
        {
            Console.WriteLine($"ID: {individual.id}");
        }
    }
    public void DisplayAges(TraitData traitData)
    {
        Console.WriteLine("Ages of Individuals:");
        foreach (var individual in traitData.input)
        {

            if (individual.age.HasValue)
            {
                Console.WriteLine($"ID: {individual.id}, Age: {individual.age}");
            }
        }
    }
}


class Program
{
    static void Main()
    {
        // Path to your JSON file
        string filePath = @"C:\Users\37367\Desktop\OOP\ConsoleApp1\resources\input.json";


        JsonReader jsonReader = new JsonReader();


        TraitData traitData = jsonReader.ReadJson(filePath);


        jsonReader.DisplayData(traitData);


        jsonReader.DisplayFilteredData(traitData, true);


        jsonReader.DisplayFilteredData(traitData, false);

        jsonReader.DisplayAges(traitData);
    }
}
