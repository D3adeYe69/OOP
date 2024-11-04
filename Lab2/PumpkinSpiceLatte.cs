public class PumpkinSpiceLatte : Coffee
{
    private readonly int _mlOfMilk;
    private readonly int _mgOfPumpkinSpice;

    public PumpkinSpiceLatte(Intensity intensity, int mlOfMilk, int mgOfPumpkinSpice)
        : base(intensity)
    {
        _mlOfMilk = mlOfMilk;
        _mgOfPumpkinSpice = mgOfPumpkinSpice;
    }

    public PumpkinSpiceLatte MakePumpkinSpiceLatte()
    {
        Console.WriteLine("Making Pumpkin Spice Latte");
        DisplayIntensity();
        AddMilk(_mlOfMilk);
        Console.WriteLine($"Adding {_mgOfPumpkinSpice} mls of pumpkin spice");

        return this;
    }
}
