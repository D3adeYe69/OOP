internal class Barista
{
    public void MakeCoffees(List<CoffeeOrder> coffeeOrders)
    {
        foreach (var order in coffeeOrders)
        {
            Coffee coffee;

            switch (order.CoffeeType)
            {
                case "Cappuccino":
                    coffee = new Cappuccino(order.Intensity, order.MlOfMilk);
                    ((Cappuccino)coffee).MakeCappuccino();
                    break;

                case "Pumpkin Spice Latte":
                    coffee = new PumpkinSpiceLatte(order.Intensity, order.MlOfMilk, order.MgOfPumpkinSpice);
                    ((PumpkinSpiceLatte)coffee).MakePumpkinSpiceLatte();
                    break;

                case "Americano":
                    coffee = new Americano(order.Intensity, order.MlOfWater);
                    ((Americano)coffee).MakeAmericano();
                    break;

                case "Syrup Cappuccino":
                    coffee = new SyrupCappuccino(order.Intensity, order.MlOfMilk, order.Syrup);
                    ((SyrupCappuccino)coffee).MakeSyrupCappuccino();
                    break;

                default:
                    Console.WriteLine("Unknown coffee type.");
                    continue;
            }
        }
    }
}

internal class CoffeeOrder
{
    public string CoffeeType { get; set; }
    public Intensity Intensity { get; set; }
    public int MlOfMilk { get; set; }
    public int MlOfWater { get; set; }
    public int MgOfPumpkinSpice { get; set; }
    public SyrupType Syrup { get; set; }
}
