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

    public const string Name = "Coffee";

    public Coffee(Intensity intensity)
    {
        _coffeeIntensity = intensity;
    }

    public virtual void PrintDetails()
    {
        Console.WriteLine($"Name: {Name}, Intensity: {CoffeeIntensity}");
    }
}
