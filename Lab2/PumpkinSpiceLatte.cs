internal class PumpkinSpiceLatte : Cappuccino
{
    private readonly int _mgOfPumpkinSpice;

    public PumpkinSpiceLatte(Intensity intensity, int mlOfMilk, int mgOfPumpkinSpice)
        : base(intensity, mlOfMilk)
    {
        _mgOfPumpkinSpice = mgOfPumpkinSpice;
    }

    public override void MakeRecipe()
    {
        base.MakeRecipe();
        Console.WriteLine($"Adding {_mgOfPumpkinSpice} mg of pumpkin spice");
    }

    public void MakePumpkinSpiceLatte()
    {
        Console.WriteLine("\nMaking Pumpkin Spice Latte");
        MakeRecipe();
    }
}
