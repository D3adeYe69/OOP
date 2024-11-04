class Program
{
    static void Main(string[] args)
    {
        var pumpkinSpiceLatte = new PumpkinSpiceLatte(Intensity.NORMAL, 100, 50);
        pumpkinSpiceLatte.MakePumpkinSpiceLatte();

        var cappuccino = new Cappuccino(Intensity.STRONG, 150);
        cappuccino.MakeCappuccino();

        var americano = new Americano(Intensity.LIGHT, 200);
        americano.MakeAmericano();
    }
}
