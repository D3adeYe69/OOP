public class Cappuccino : Coffee
{
    private int _mlOfMilk;
    public int MlOfMilk
    {
        get => _mlOfMilk;
        set => _mlOfMilk = value;
    }

    public const string CoffeeType = "Cappuccino";

    public Cappuccino(Intensity intensity, int mlOfMilk) : base(intensity)
    {
        _mlOfMilk = mlOfMilk;
    }

    public override void PrintDetails()
    {
        base.PrintDetails();
        Console.WriteLine($"Type: {CoffeeType}, Milk: {MlOfMilk} ml");
    }
}
