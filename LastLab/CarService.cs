public class CarStation
{
    private IDineable diningService;
    private IRefuelable electricStation;
    private IRefuelable gasStation;
    private IQueue<Car> queue;

    public CarStation(IDineable diningService, IRefuelable electricStation, IRefuelable gasStation)
    {
        this.diningService = diningService;
        this.electricStation = electricStation;
        this.gasStation = gasStation;
        queue = new ArrayQueue<Car>();  // Using the ArrayQueue implementation
    }

    public void AddCar(Car car)
    {
        queue.Enqueue(car);
    }

    public void ServeCars()
    {
        // Reset the served count of dinner
        int servedDinnerCount = 0;
        int gasRefueledCount = 0;   // Track gas cars refueled
        int electricChargedCount = 0; // Track electric cars charged

        while (!queue.IsEmpty())
        {
            Car car = queue.Dequeue();

            // Debugging: print out car info
            Console.WriteLine($"Processing car {car.Id} of type {car.Type}. Is Dining: {car.IsDining}");

            if (car.IsDining)
            {
                // Serving dinner if the car is marked as dining
                diningService.ServeDinner(car.Id.ToString());
                servedDinnerCount++;  // Track served dinners
            }

            // Refueling or charging cars based on their type
            if (car.Type == "ELECTRIC")
            {
                electricStation.Refuel(car.Id.ToString());  // Charge electric cars
                electricChargedCount++;  // Track electric cars charged
            }
            else if (car.Type == "GAS")
            {
                gasStation.Refuel(car.Id.ToString());  // Refuel gas cars
                gasRefueledCount++;  // Track gas cars refueled
            }
        }

        // Output the counts for debugging
        Console.WriteLine($"Total served dinners: {servedDinnerCount}");
        Console.WriteLine($"Total gas cars refueled: {gasRefueledCount}");
        Console.WriteLine($"Total electric cars charged: {electricChargedCount}");
    }
}
