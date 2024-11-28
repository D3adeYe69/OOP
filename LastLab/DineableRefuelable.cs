public interface IDineable
{
    void ServeDinner(string carId);
}

public interface IRefuelable
{
    void Refuel(string carId);
}

public class PeopleDinner : IDineable
{
    private int servedCount = 0;

    public void ServeDinner(string carId)
    {
        servedCount++;
        Console.WriteLine($"Serving dinner to people in car {carId}");
    }

    public int GetServedCount() => servedCount;
}

public class RobotDinner : IDineable
{
    private int servedCount = 0;

    public void ServeDinner(string carId)
    {
        servedCount++;
        Console.WriteLine($"Serving dinner to robots in car {carId}");
    }

    public int GetServedCount() => servedCount;
}

public class ElectricStation : IRefuelable
{
    private int carsCharged = 0;

    public void Refuel(string carId)
    {
        carsCharged++;
        Console.WriteLine($"Charging electric car {carId}");
    }

    public int GetChargedCount() => carsCharged;
}

public class GasStation : IRefuelable
{
    private int carsRefueled = 0;

    public void Refuel(string carId)
    {
        carsRefueled++;
        Console.WriteLine($"Refueling gas car {carId}");
    }

    public int GetRefueledCount() => carsRefueled;
}