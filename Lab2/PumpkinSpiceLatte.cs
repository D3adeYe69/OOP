// PumpkinSpiceLatte.cs
internal class PumpkinSpiceLatte : Cappuccino
{
    private readonly int _mlOfMilk;
    private readonly int _mgOfPumpkinSpice;

    public PumpkinSpiceLatte(Intensity intensity, int mlOfMilk, int mgOfPumpkinSpice)
        : base(intensity, mlOfMilk)
    {
        _mlOfMilk = mlOfMilk;
        _mgOfPumpkinSpice = mgOfPumpkinSpice;
    }

    public void MakePumpkinSpiceLatte()
    {
        Console.WriteLine("\nMaking Pumpkin Spice Latte");
        DisplayIntensity();
        AddMilk(_mlOfMilk);
        Console.WriteLine($"Adding {_mgOfPumpkinSpice} mg of pumpkin spice");
    }
}
