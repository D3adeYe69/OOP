using System;

namespace CoffeeShopApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Coffee coffee = new Coffee(Intensity.NORMAL);
            coffee.PrintDetails();


            Cappuccino cappuccino = new Cappuccino(Intensity.STRONG, 150);
            cappuccino.PrintDetails();


            PumpkinSpiceLatte pumpkinLatte = new PumpkinSpiceLatte(Intensity.NORMAL, 100, 30);
            pumpkinLatte.PrintDetails();


            Americano americano = new Americano(Intensity.LIGHT, 200);
            americano.PrintDetails();


            SyrupCappuccino syrupCappuccino = new SyrupCappuccino(Intensity.NORMAL, 120, SyrupType.CARAMEL);
            syrupCappuccino.PrintDetails();
        }
    }
}
