
public class CarStation
{
    private readonly List<Car> cars = new List<Car>();
    private readonly IRefuelable refuelStation;
    private readonly IDineable dineStation;

    // Constructor accepts a refuelable and dineable station
    public CarStation(IRefuelable refuelable, IDineable dineable)
    {
        refuelStation = refuelable;
        dineStation = dineable;
    }

    // Add a car to the station and perform necessary actions
    public void AddCar(Car car)
    {
        cars.Add(car);
        Console.WriteLine($"Car with ID {car.Id} added to the station.");
    }

    // Serve cars at the station based on their type
    public void ServeCars()
    {
        foreach (var car in cars)
        {
            if (car.Type == "GAS")
            {
                refuelStation.Refuel(car.Id.ToString());
            }
            else if (car.Type == "ELECTRIC")
            {
                refuelStation.Refuel(car.Id.ToString());
            }

            if (car.IsDining)
            {
                if (car.Type == "GAS")
                {
                    dineStation.ServeDinner(car.Id.ToString());
                }
                else if (car.Type == "ELECTRIC")
                {
                    dineStation.ServeDinner(car.Id.ToString());
                }
            }
        }
    }
}
