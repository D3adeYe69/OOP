// Coffee.cs
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

internal class Coffee
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

    public void DisplayIntensity()
    {
        Console.WriteLine($"Intensity set to {CoffeeIntensity}");
    }


}
