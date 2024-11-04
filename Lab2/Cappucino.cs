public class Cappuccino : Coffee
{
    private readonly int _mlOfMilk;

    public Cappuccino(Intensity intensity, int mlOfMilk) : base(intensity)
    {
        _mlOfMilk = mlOfMilk;
    }

    public Cappuccino MakeCappuccino()
    {
        Console.WriteLine("Making Cappuccino");
        DisplayIntensity();
        AddMilk(_mlOfMilk);

        return this; // Return instance as per task requirements
    }
}
