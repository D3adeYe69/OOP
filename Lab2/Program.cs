using System;

namespace CoffeeShopApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test Coffee
            Coffee coffee = new Coffee(Intensity.NORMAL);
            Console.WriteLine($"Coffee Intensity: {coffee.CoffeeIntensity}");

            // Test Cappuccino
            Cappuccino cappuccino = new Cappuccino(Intensity.STRONG, 150);
            Console.WriteLine($"Cappuccino Intensity: {cappuccino.CoffeeIntensity}, Milk: {cappuccino.MlOfMilk} ml");

            // Test PumpkinSpiceLatte
            PumpkinSpiceLatte pumpkinLatte = new PumpkinSpiceLatte(Intensity.NORMAL, 100, 30);
            Console.WriteLine($"Pumpkin Spice Latte Intensity: {pumpkinLatte.CoffeeIntensity}, Milk: {pumpkinLatte.MlOfMilk} ml, Pumpkin Spice: {pumpkinLatte.MgOfPumpkinSpice} mg");

            // Test Americano
            Americano americano = new Americano(Intensity.LIGHT, 200);
            Console.WriteLine($"Americano Intensity: {americano.CoffeeIntensity}, Water: {americano.MlOfWater} ml");

            // Test SyrupCappuccino
            SyrupCappuccino syrupCappuccino = new SyrupCappuccino(Intensity.NORMAL, 120, SyrupType.CARAMEL);
            Console.WriteLine($"Syrup Cappuccino Intensity: {syrupCappuccino.CoffeeIntensity}, Milk: {syrupCappuccino.MlOfMilk} ml, Syrup: {syrupCappuccino.Syrup}");
        }
    }
}
