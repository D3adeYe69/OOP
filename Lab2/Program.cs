// Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Barista barista = new Barista();
        List<CoffeeOrder> coffeeOrders = new List<CoffeeOrder>();
        string moreOrders = "yes";

        do
        {
            Console.WriteLine("What type of coffee would you like? (Cappuccino, Pumpkin Spice Latte, Americano, Syrup Cappuccino)");
            string coffeeType = Console.ReadLine().Trim();

            Intensity intensity = GetIntensityFromUser();
            CoffeeOrder order = new CoffeeOrder { CoffeeType = coffeeType, Intensity = intensity };

            switch (coffeeType)
            {
                case "Cappuccino":
                    Console.WriteLine("How much milk (in ml) would you like?");
                    order.MlOfMilk = int.Parse(Console.ReadLine());
                    break;

                case "Pumpkin Spice Latte":
                    Console.WriteLine("How much milk (in ml) would you like?");
                    order.MlOfMilk = int.Parse(Console.ReadLine());
                    Console.WriteLine("How much pumpkin spice (in mg) would you like?");
                    order.MgOfPumpkinSpice = int.Parse(Console.ReadLine());
                    break;

                case "Americano":
                    Console.WriteLine("How much water (in ml) would you like?");
                    order.MlOfWater = int.Parse(Console.ReadLine());
                    break;

                case "Syrup Cappuccino":
                    Console.WriteLine("How much milk (in ml) would you like?");
                    order.MlOfMilk = int.Parse(Console.ReadLine());
                    order.Syrup = GetSyrupFromUser();
                    break;

                default:
                    Console.WriteLine("Invalid coffee type. Please try again.");
                    continue;
            }

            coffeeOrders.Add(order);

            Console.WriteLine("Would you like to add another order? (yes/no)");
            moreOrders = Console.ReadLine().Trim().ToLower();

        } while (moreOrders == "yes");

        // Pass the orders to the Barista to prepare them
        barista.MakeCoffees(coffeeOrders);
    }

    static Intensity GetIntensityFromUser()
    {
        Console.WriteLine("Select coffee intensity (Light, Normal, Strong):");
        string intensityInput = Console.ReadLine().Trim();

        if (Enum.TryParse(intensityInput, true, out Intensity intensity))
        {
            return intensity;
        }
        else
        {
            Console.WriteLine("Invalid intensity. Defaulting to Normal.");
            return Intensity.NORMAL;
        }
    }

    static SyrupType GetSyrupFromUser()
    {
        Console.WriteLine("Select syrup type (Macadamia, Vanilla, Coconut, Caramel, Chocolate, Popcorn):");
        string syrupInput = Console.ReadLine().Trim();

        if (Enum.TryParse(syrupInput, true, out SyrupType syrup))
        {
            return syrup;
        }
        else
        {
            Console.WriteLine("Invalid syrup type. Defaulting to Vanilla.");
            return SyrupType.VANILLA;
        }
    }
}
