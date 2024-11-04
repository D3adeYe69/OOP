public class SyrupCappuccino : Coffee
{
    private readonly int _mlOfMilk;
    private readonly SyrupType _syrup;

    public SyrupCappuccino(Intensity intensity, int mlOfMilk, SyrupType syrup)
        : base(intensity)
    {
        _mlOfMilk = mlOfMilk;
        _syrup = syrup;
    }

    public SyrupCappuccino MakeSyrupCappuccino()
    {
        Console.WriteLine("Making Syrup Cappuccino");
        DisplayIntensity();
        AddMilk(_mlOfMilk);
        Console.WriteLine($"Adding syrup: {_syrup}");

        return this;
    }
}
