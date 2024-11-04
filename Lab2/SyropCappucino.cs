// SyrupCappuccino.cs
internal class SyrupCappuccino : Cappuccino
{
    private readonly int _mlOfMilk;
    private readonly SyrupType _syrup;

    public SyrupCappuccino(Intensity intensity, int mlOfMilk, SyrupType syrup)
        : base(intensity, mlOfMilk)
    {
        _mlOfMilk = mlOfMilk;
        _syrup = syrup;
    }

    public void MakeSyrupCappuccino()
    {
        Console.WriteLine("\nMaking Syrup Cappuccino");
        DisplayIntensity();
        AddMilk(_mlOfMilk);
        Console.WriteLine($"Adding syrup: {_syrup}");
    }
}
