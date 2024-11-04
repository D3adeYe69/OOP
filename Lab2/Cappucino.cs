// Cappuccino.cs
internal class Cappuccino : Coffee
{
    private readonly int _mlOfMilk;

    public Cappuccino(Intensity intensity, int mlOfMilk) : base(intensity)
    {
        _mlOfMilk = mlOfMilk;
    }

    protected void AddMilk(int mlOfMilk)
    {
        Console.WriteLine($"Adding {mlOfMilk} ml of milk");
    }
    public void MakeCappuccino()
    {
        Console.WriteLine("\nMaking Cappuccino");
        DisplayIntensity();
        AddMilk(_mlOfMilk);
    }
}
