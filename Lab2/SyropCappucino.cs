internal class SyrupCappuccino : Cappuccino
{
    private readonly SyrupType _syrup;

    public SyrupCappuccino(Intensity intensity, int mlOfMilk, SyrupType syrup)
        : base(intensity, mlOfMilk)
    {
        _syrup = syrup;
    }

    public override void MakeRecipe()
    {
        base.MakeRecipe();
        Console.WriteLine($"Adding syrup: {_syrup}");
    }

    public void MakeSyrupCappuccino()
    {
        Console.WriteLine("\nMaking Syrup Cappuccino");
        MakeRecipe();
    }
}
