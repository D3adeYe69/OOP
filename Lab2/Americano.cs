public class Americano : Coffee
{
    private readonly int _mlOfWater;

    public Americano(Intensity intensity, int mlOfWater) : base(intensity)
    {
        _mlOfWater = mlOfWater;
    }

    public Americano MakeAmericano()
    {
        Console.WriteLine("Making Americano");
        DisplayIntensity();
        Console.WriteLine($"Adding {_mlOfWater} mls of water");

        return this;
    }
}
