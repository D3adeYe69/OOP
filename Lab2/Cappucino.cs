internal class Cappuccino : Coffee
{
    private readonly int _mlOfMilk;

    public Cappuccino(Intensity intensity, int mlOfMilk) : base(intensity)
    {
        _mlOfMilk = mlOfMilk;
    }

    public override void MakeRecipe()
    {
        base.MakeRecipe();
        Console.WriteLine($"Adding {_mlOfMilk} ml of milk");
    }

    public void MakeCappuccino()
    {
        Console.WriteLine("\nMaking Cappuccino");
        MakeRecipe();
    }
}
