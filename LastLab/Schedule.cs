using Newtonsoft.Json;
public class CarScheduler : IDisposable
{
    private readonly Semaphore _semaphore;
    private readonly CancellationTokenSource _cancellationToken;
    private bool _disposed;
    private const int PROCESS_DELAY_MS = 2000; // 2 seconds delay for adding to the queue
    private const int SERVING_DELAY_MS = 1000; // 1 second delay for serving each car

    private List<Car> _carQueue = new List<Car>();

    private int _totalCarsProcessed = 0;
    private int _totalElectricCars = 0;
    private int _totalGasCars = 0;
    private int _totalPeoplePassengers = 0;
    private int _totalRobotsPassengers = 0;
    private int _totalDining = 0;
    private int _totalNotDining = 0;
    private int _totalElectricConsumption = 0;
    private int _totalGasConsumption = 0;

    public CarScheduler(Semaphore semaphore)
    {
        _semaphore = semaphore;
        _cancellationToken = new CancellationTokenSource();
        _disposed = false;
    }

    public async Task ProcessAllCars(CancellationToken externalCancellationToken = default)
    {
        ThrowIfDisposed();
        Console.WriteLine("Starting to process all cars...");

        CancellationToken combinedCancellationToken = CancellationTokenSource
            .CreateLinkedTokenSource(_cancellationToken.Token, externalCancellationToken).Token;

        string currentDir = Directory.GetCurrentDirectory();
        string projectDir = Path.GetFullPath(Path.Combine(currentDir, "..", "..", ".."));
        string queueFolderPath = Path.Combine(projectDir, "queue");

        var jsonFiles = Directory.GetFiles(queueFolderPath, "*.json")
            .OrderBy(f => int.Parse(Path.GetFileNameWithoutExtension(f).Replace("Car", "")))
            .ToArray();

        Console.WriteLine($"Found {jsonFiles.Length} cars to process");

        foreach (var jsonFile in jsonFiles)
        {
            combinedCancellationToken.ThrowIfCancellationRequested();

            try
            {
                Console.WriteLine($"\nProcessing: {Path.GetFileName(jsonFile)}");
                string jsonContent = await File.ReadAllTextAsync(jsonFile, combinedCancellationToken);
                var car = JsonConvert.DeserializeObject<Car>(jsonContent);

                if (car != null)
                {
                    Console.WriteLine($"Adding Car {car.Id} (Type: {car.Type}, Passengers: {car.Passengers}, Dining: {car.IsDining}) to queue");
                    _carQueue.Add(car);
                    await Task.Delay(PROCESS_DELAY_MS, combinedCancellationToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {jsonFile}: {ex.Message}");
            }
        }

        Console.WriteLine("\nPress Enter to serve all cars...");
        Console.ReadLine();

        Console.WriteLine("Processing all queued cars...");
        await ServeCarsWithDelay(combinedCancellationToken);

        DisplayTotalData();
        Console.WriteLine("All cars have been processed");
    }

    private async Task ServeCarsWithDelay(CancellationToken cancellationToken)
    {
        foreach (var car in _carQueue)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Console.WriteLine($"Serving Car {car.Id} (Type: {car.Type}, Passengers: {car.Passengers}, Dining: {car.IsDining})");
            await Task.Delay(SERVING_DELAY_MS, cancellationToken);

            _totalCarsProcessed++;
            if (car.Type == "ELECTRIC") _totalElectricCars++;
            if (car.Type == "GAS") _totalGasCars++;
            if (car.Passengers == "PEOPLE") _totalPeoplePassengers++;
            if (car.Passengers == "ROBOTS") _totalRobotsPassengers++;
            if (car.IsDining) _totalDining++;
            else _totalNotDining++;
            if (car.Type == "ELECTRIC") _totalElectricConsumption += car.Consumption;
            if (car.Type == "GAS") _totalGasConsumption += car.Consumption;
        }
    }

    private void DisplayTotalData()
    {
        Console.WriteLine("\nTotal Data After Serving All Cars:");
        Console.WriteLine($"Total Cars Processed: {_totalCarsProcessed}");
        Console.WriteLine($"Electric Cars: {_totalElectricCars}");
        Console.WriteLine($"Gas Cars: {_totalGasCars}");
        Console.WriteLine($"People Passengers: {_totalPeoplePassengers}");
        Console.WriteLine($"Robots Passengers: {_totalRobotsPassengers}");
        Console.WriteLine($"Cars Dining: {_totalDining}");
        Console.WriteLine($"Cars Not Dining: {_totalNotDining}");
        Console.WriteLine($"Total Electric Consumption: {_totalElectricConsumption} units");
        Console.WriteLine($"Total Gas Consumption: {_totalGasConsumption} units");
        Console.WriteLine("=========================================");
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _cancellationToken.Cancel();
                _cancellationToken.Dispose();
            }
            _disposed = true;
        }
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(CarScheduler));
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~CarScheduler()
    {
        Dispose(false);
    }
}

// Add stubs for other classes (Car, PeopleDinner, RobotDinner, Semaphore, etc.) for the full example if needed.
