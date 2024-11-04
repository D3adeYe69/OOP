public enum Intensity
{
    LIGHT,
    NORMAL,
    STRONG
}
public enum SyrupType
{
    MACADAMIA,
    VANILLA,
    COCONUT,
    CARAMEL,
    CHOCOLATE,
    POPCORN
}

public class Coffee
{
    private Intensity _coffeeIntensity;

    public Intensity CoffeeIntensity
    {
        get => _coffeeIntensity;
        set => _coffeeIntensity = value;
    }

    public Coffee(Intensity intensity)
    {
        _coffeeIntensity = intensity;
    }

    // Prevent overriding by marking as sealed
    public void DisplayIntensity()
    {
        Console.WriteLine($"Intensity set to {CoffeeIntensity}");
    }

    // Helper method for additional shared steps (if needed)
    protected void AddMilk(int mlOfMilk)
    {
        Console.WriteLine($"Adding {mlOfMilk} mls of milk");
    }
}


