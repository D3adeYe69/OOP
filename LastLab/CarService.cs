public class CarStation
{
    private readonly List<Car> cars = new List<Car>();
    private readonly IRefuelable refuelStation;
    private readonly IDineable dineStation;

    public CarStation(IRefuelable refuelable, IDineable dineable)
    {
        refuelStation = refuelable;
        dineStation = dineable;
    }

    // AddCar method to add a car to the correct station and update the passenger counts
    public void AddCar(Car car)
    {
        cars.Add(car);

        // Check if the car has people or robots as passengers and add them to the dining station accordingly
        if (car.Passengers == "PEOPLE")
        {
            // Add people to the dining station (PeopleDinner)
            (dineStation as PeopleDinner)?.AddPeople(1);
        }
        else if (car.Passengers == "ROBOTS")
        {
            // Add robots to the dining station (RobotDinner)
            (dineStation as RobotDinner)?.AddRobots(1);
        }
    }

    // Declare counters for people and robots
    private int peopleDining = 0, robotsDining = 0, totalPeople = 0, totalRobots = 0;

    // ServeCars method to serve cars, refuel, and update statistics
    public void ServeCars()
    {
        // Process all cars in the list
        foreach (var car in cars)
        {
            // Refuel the car based on its type
            refuelStation.Refuel(car.Id.ToString());

            // If the car has passengers and is dining, serve dinner to people or robots
            if (car.IsDining)
            {
                if (car.Passengers == "PEOPLE")
                {
                    // Serve dinner to people and count them as dining
                    (dineStation as PeopleDinner)?.ServeDinner(car.Id.ToString());
                    peopleDining++;
                    totalPeople++;
                }
                else if (car.Passengers == "ROBOTS")
                {
                    // Serve dinner to robots and count them as dining
                    (dineStation as RobotDinner)?.ServeDinner(car.Id.ToString());
                    robotsDining++;
                    totalRobots++;
                }
            }
            else
            {
                // Count people or robots not dining
                if (car.Passengers == "PEOPLE")
                {
                    totalPeople++;
                }
                else if (car.Passengers == "ROBOTS")
                {
                    totalRobots++;
                }
            }
        }
    }
}
