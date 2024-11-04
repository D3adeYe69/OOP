public class PumpkinSpiceLatte : Cappuccino
{
    private int _mgOfPumpkinSpice;
    public int MgOfPumpkinSpice
    {
        get => _mgOfPumpkinSpice;
        set => _mgOfPumpkinSpice = value;
    }

    public const string CoffeeType = "PumpkinSpiceLatte";

    public PumpkinSpiceLatte(Intensity intensity, int mlOfMilk, int mgOfPumpkinSpice)
        : base(intensity, mlOfMilk)
    {
        _mgOfPumpkinSpice = mgOfPumpkinSpice;
    }

    public override void PrintDetails()
    {
        base.PrintDetails();
        Console.WriteLine($"Type: {CoffeeType}, Milk: {MlOfMilk} ml, Pumpkin Spice: {MgOfPumpkinSpice} mg");
    }
}
