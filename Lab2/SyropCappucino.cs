public class SyrupCappuccino : Cappuccino
{
    private SyrupType _syrup;
    public SyrupType Syrup
    {
        get => _syrup;
        set => _syrup = value;
    }

    public const string CoffeeType = "SyrupCappuccino";

    public SyrupCappuccino(Intensity intensity, int mlOfMilk, SyrupType syrup)
        : base(intensity, mlOfMilk)
    {
        _syrup = syrup;
    }

    public override void PrintDetails()
    {
        base.PrintDetails();
        Console.WriteLine($"Type: {CoffeeType}, Milk: {MlOfMilk} ml, Syrup: {Syrup}");
    }
}
