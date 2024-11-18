internal class Americano : Coffee
{
    private readonly int _mlOfWater;

    public Americano(Intensity intensity, int mlOfWater) : base(intensity)
    {
        _mlOfWater = mlOfWater;
    }

    public override void MakeRecipe()
    {
        base.MakeRecipe();
        Console.WriteLine($"Adding {_mlOfWater} ml of water");
    }

    public void MakeAmericano()
    {
        Console.WriteLine("\nMaking Americano");
        MakeRecipe();
    }
}
