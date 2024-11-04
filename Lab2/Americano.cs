// Americano.cs
internal class Americano : Coffee
{
    private readonly int _mlOfWater;

    public Americano(Intensity intensity, int mlOfWater) : base(intensity)
    {
        _mlOfWater = mlOfWater;
    }

    public void MakeAmericano()
    {
        Console.WriteLine("\nMaking Americano");
        DisplayIntensity();
        Console.WriteLine($"Adding {_mlOfWater} ml of water");
    }
}
