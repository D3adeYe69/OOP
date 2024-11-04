public class Americano : Coffee
{
    private int _mlOfWater;
    public int MlOfWater
    {
        get => _mlOfWater;
        set => _mlOfWater = value;
    }

    public const string CoffeeType = "Americano";

    public Americano(Intensity intensity, int mlOfWater) : base(intensity)
    {
        _mlOfWater = mlOfWater;
    }

    public override void PrintDetails()
    {
        base.PrintDetails();
        Console.WriteLine($"Type: {CoffeeType}, Water: {MlOfWater} ml");
    }
}
