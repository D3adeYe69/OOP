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

public abstract class Character
{
    public bool isHumanoid { get; set; }
    public string planet { get; set; }
    public int? age { get; set; }
    public List<string> traits { get; set; }

    public abstract string GetRaceName();
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
public class View
{
    public int id { get; set; }
    public bool? isHumanoid { get; set; }
    public string planet { get; set; }
    public int? age { get; set; }
    public List<string> traits { get; set; }
}
