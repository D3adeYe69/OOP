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
    private readonly Intensity _coffeeIntensity;

    public Coffee(Intensity intensity)
    {
        _coffeeIntensity = intensity;
    }

    public virtual void MakeRecipe()
    {
        Console.WriteLine($"Setting intensity to {_coffeeIntensity}");
    }
}
