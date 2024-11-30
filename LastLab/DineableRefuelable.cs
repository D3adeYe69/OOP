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
    private int totalPeople = 0;
    private int servedPeople = 0;

    public void AddPeople(int count)
    {
        totalPeople += count;
    }

    public void ServeDinner(string carId)
    {
        servedPeople++;
    }

    public int GetTotalPeopleCount() => totalPeople;
    public int GetServedCount() => servedPeople;
    public int GetNotDiningCount() => totalPeople - servedPeople;
}

public class RobotDinner : IDineable
{
    private int totalRobots = 0;
    private int servedRobots = 0;

    public void AddRobots(int count)
    {
        totalRobots += count;
    }

    public void ServeDinner(string carId)
    {
        servedRobots++;
    }

    public int GetTotalRobotCount() => totalRobots;
    public int GetServedCount() => servedRobots;
    public int GetNotDiningCount() => totalRobots - servedRobots;
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