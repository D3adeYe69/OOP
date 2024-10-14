using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.Json;

public class TraitData
{
    public List<Individual> input { get; set; }
}

public class Individual
{
    public int id { get; set; }
    public bool? isHumanoid { get; set; } // Nullable to handle cases where it's not provided
    public string planet { get; set; }
    public int? age { get; set; } // Nullable to handle cases where age may not be provided
    public List<string> traits { get; set; } // Nullable for cases where traits may not exist
}

public abstract class Character
{
    public bool isHumanoid { get; set; }
    public string planet { get; set; }
    public int? age { get; set; }
    public List<string> traits { get; set; }

    public abstract string GetRaceName(); // Method to get the race name
}

public class Wookie : Character
{
    public Wookie()
    {
        isHumanoid = false;
        planet = "Kashyyyk";
        traits = new List<string> { "HAIRY", "TALL" };
    }

    public override string GetRaceName() => "Star Wars Universe (Wookie)";
}

public class Ewok : Character
{
    public Ewok()
    {
        isHumanoid = false;
        planet = "Endor";
        traits = new List<string> { "SHORT", "HAIRY" };
    }

    public override string GetRaceName() => "Star Wars Universe (Ewok)";
}

public class Asgardian : Character
{
    public Asgardian()
    {
        isHumanoid = true;
        planet = "Asgard";
        traits = new List<string> { "BLONDE", "TALL" };
    }

    public override string GetRaceName() => "Marvel Universe (Asgardian)";
}

public class Betelgeusian : Character
{
    public Betelgeusian()
    {
        isHumanoid = true;
        planet = "Betelgeuse";
        traits = new List<string> { "EXTRA_ARMS", "EXTRA_HEAD" };
    }

    public override string GetRaceName() => "Hitchhiker's Universe (Betelgeusian)";
}

public class Vogon : Character
{
    public Vogon()
    {
        isHumanoid = false;
        planet = "Vogsphere";
        traits = new List<string> { "GREEN", "BULKY" };
    }

    public override string GetRaceName() => "Hitchhiker's Universe (Vogon)";
}

public class Elf : Character
{
    public Elf()
    {
        isHumanoid = true;
        planet = "Earth";
        traits = new List<string> { "BLONDE", "POINTY_EARS" };
    }

    public override string GetRaceName() => "Lord of the Rings Universe (Elf)";
}

public class Dwarf : Character
{
    public Dwarf()
    {
        isHumanoid = true;
        planet = "Earth";
        traits = new List<string> { "SHORT", "BULKY" };
    }

    public override string GetRaceName() => "Lord of the Rings Universe (Dwarf)";
}

public class JsonReader
{
    public TraitData ReadJson(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<TraitData>(jsonString);
    }

    public void DisplayData(TraitData traitData)
    {
        foreach (var individual in traitData.input)
        {
            // Output the original data
            Console.WriteLine($"ID: {individual.id}");
            Console.WriteLine($"Is Humanoid: {individual.isHumanoid}");
            Console.WriteLine($"Planet: {individual.planet}");
            Console.WriteLine($"Age: {individual.age?.ToString() ?? "Indefinite"}");
            Console.WriteLine($"Traits: {string.Join(", ", individual.traits ?? new List<string>())}");

            // Classify the individual and output the classification
            Character character = ClassifyIndividual(individual);
            if (character != null)
            {
                Console.WriteLine($"Universe: {character.GetRaceName()}");
            }
            else
            {
                Console.WriteLine("Universe: Unknown Universe");
            }

            Console.WriteLine(); // For spacing
        }
    }

    private Character ClassifyIndividual(Individual individual)
    {
        // Check if humanoid or not
        if (individual.isHumanoid.HasValue)
        {
            if (individual.isHumanoid.Value)
            {
                if (individual.age.HasValue && individual.age.Value > 5000)
                {
                    return new Elf();
                }
                // Humanoid characters
                if (!string.IsNullOrEmpty(individual.planet))
                {

                    if (individual.planet == "Asgard") return new Asgardian();
                    if (individual.planet == "Earth")
                    {
                        if (individual.age.HasValue)
                        {
                            if (individual.age <= 200) return new Dwarf();
                            if (individual.age > 5000) return new Elf(); // Specific age condition for Elf
                        }
                        return new Elf(); // Default to Elf for indefinite age
                    }

                    if (individual.planet == "Betelgeuse") return new Betelgeusian();
                }
            }
            else
            {
                // Non-humanoid characters
                if (!string.IsNullOrEmpty(individual.planet))
                {
                    if (individual.planet == "Kashyyyk") return new Wookie();
                    if (individual.planet == "Endor") return new Ewok();
                    if (individual.planet == "Vogsphere") return new Vogon();
                }
            }
        }

        // If humanoid is null, check the planet and age
        if (!string.IsNullOrEmpty(individual.planet))
        {
            if (individual.planet == "Kashyyyk") return new Wookie();
            if (individual.planet == "Endor") return new Ewok();
            if (individual.planet == "Asgard") return new Asgardian();
            if (individual.planet == "Betelgeuse") return new Betelgeusian();
            if (individual.planet == "Vogsphere") return new Vogon();
            if (individual.planet == "Earth")
            {
                if (individual.age.HasValue)
                {
                    if (individual.age <= 200) return new Dwarf();
                    if (individual.age > 5000) return new Elf(); // Specific age condition for Elf
                }
                else if (individual.traits.Contains("SHORT") || individual.traits.Contains("BULKY"))
                {
                    return new Dwarf();
                }

            }
        }

        // Check traits if planet and age are not sufficient for classification
        if (individual.traits != null && individual.traits.Count > 0)
        {
            if (individual.isHumanoid.HasValue)
            {
                if (individual.isHumanoid.Value)
                {
                    if (individual.traits.Contains("SHORT") || individual.traits.Contains("BULKY"))
                        return new Dwarf();
                    else if ((individual.traits.Contains("BLONDE") || individual.traits.Contains("TALL")) && individual.age.HasValue && individual.age.Value <= 5000)
                        return new Asgardian();
                }
                else
                {
                    if (individual.traits.Contains("GREEN") || individual.traits.Contains("BULKY"))
                        return new Vogon();
                }
            }


            if ((individual.traits.Contains("HAIRY") || individual.traits.Contains("TALL")) && individual.age.HasValue && individual.age.Value <= 400) return new Wookie();
            if ((individual.traits.Contains("SHORT") || individual.traits.Contains("HAIRY")) && individual.age.HasValue && individual.age.Value <= 60) return new Ewok();
            if ((individual.traits.Contains("BLONDE") || individual.traits.Contains("TALL")) && individual.age.HasValue && individual.age.Value <= 5000) return new Asgardian();
            if ((individual.traits.Contains("EXTRA_ARMS") || individual.traits.Contains("EXTRA_HEAD")) && individual.age.HasValue && individual.age.Value <= 100) return new Betelgeusian();
            if ((individual.traits.Contains("GREEN") || individual.traits.Contains("BULKY")) && individual.age.HasValue && individual.age.Value <= 200) return new Vogon();
            if (individual.traits.Contains("BLONDE") || individual.traits.Contains("POINTY_EARS")) return new Elf();
            if ((individual.traits.Contains("SHORT") || individual.traits.Contains("BULKY")) && individual.age.HasValue && individual.age.Value <= 200) return new Dwarf();

        }

        return null; // No matching character found
    }


    class Program
    {
        static void Main()
        {
            string filePath = @"C:\Users\37367\Desktop\OOP\ConsoleApp1\resources\input.json";

            JsonReader jsonReader = new JsonReader();
            TraitData traitData = jsonReader.ReadJson(filePath);

            // Display the data along with classifications
            jsonReader.DisplayData(traitData);
        }
    }
}
