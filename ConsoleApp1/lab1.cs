using System;

public class Individual
{
    public bool IsHumanoid { get; private set; }
    public string Planet { get; private set; }
    public int Age { get; private set; }
    public string[] Traits { get; private set; }

    // Constructor for Individual class
    public Individual(bool isHumanoid, string planet, int age, string[] traits)
    {
        IsHumanoid = isHumanoid;
        Planet = planet;
        Age = age;
        Traits = traits;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Humanoid: {IsHumanoid}, Planet: {Planet}, Age: {Age}, Traits: {string.Join(", ", Traits)}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Test 1: Creating an individual (example: Asgardian)
        Individual asgardian = new Individual(true, "Asgard", 1500, new string[] { "BLONDE", "TALL" });
        asgardian.DisplayInfo();

        // Test 2: Creating another individual (example: Wookie)
        Individual wookie = new Individual(false, "Kashyyyk", 300, new string[] { "HAIRY", "TALL" });
        wookie.DisplayInfo();
    }
}
