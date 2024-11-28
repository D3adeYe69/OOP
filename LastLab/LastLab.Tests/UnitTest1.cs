[TestClass]
public class QueueTests
{
    [TestMethod]
    public void TestArrayQueue()
    {
        Console.WriteLine("Running TestArrayQueue...");
        IQueue<int> queue = new ArrayQueue<int>();
        TestQueueOperations(queue);
        Console.WriteLine("TestArrayQueue passed.");
    }

    [TestMethod]
    public void TestLinkedQueue()
    {
        Console.WriteLine("Running TestLinkedQueue...");
        IQueue<int> queue = new LinkedQueue<int>();
        TestQueueOperations(queue);
        Console.WriteLine("TestLinkedQueue passed.");
    }

    [TestMethod]
    public void TestCircularQueue()
    {
        Console.WriteLine("Running TestCircularQueue...");
        IQueue<int> queue = new CircularQueue<int>();
        TestQueueOperations(queue);
        Console.WriteLine("TestCircularQueue passed.");
    }

    [TestMethod]
    public void TestCarQueue()
    {
        Console.WriteLine("Running TestCarQueue...");
        IQueue<Car> queue = new ArrayQueue<Car>();
        var car = new Car
        {
            Id = 1,
            Type = "ELECTRIC",
            Passengers = "ROBOTS",
            IsDining = true,
            Consumption = 34
        };

        queue.Enqueue(car);
        Console.WriteLine($"Enqueued Car with ID: {car.Id}");
        Assert.AreEqual(1, queue.Count);
        Assert.AreEqual(1, queue.Peek().Id);
        Console.WriteLine("TestCarQueue passed.");
    }

    private void TestQueueOperations(IQueue<int> queue)
    {
        Console.WriteLine("Queue is initially empty.");
        Assert.IsTrue(queue.IsEmpty());
        Assert.AreEqual(0, queue.Count);

        queue.Enqueue(1);
        Console.WriteLine("Enqueued 1");
        queue.Enqueue(2);
        Console.WriteLine("Enqueued 2");
        queue.Enqueue(3);
        Console.WriteLine("Enqueued 3");

        Assert.AreEqual(3, queue.Count);
        Assert.IsFalse(queue.IsEmpty());
        Assert.AreEqual(1, queue.Peek());
        Console.WriteLine("Peeked value: 1");
        Assert.AreEqual(1, queue.Dequeue());
        Console.WriteLine("Dequeued value: 1");
        Assert.AreEqual(2, queue.Count);
        Console.WriteLine("TestQueueOperations passed.");
    }
}

[TestClass]
public class DineableRefuelableTests
{
    [TestMethod]
    public void TestPeopleDinner()
    {
        Console.WriteLine("Running TestPeopleDinner...");
        var dinner = new PeopleDinner();
        dinner.ServeDinner("1");
        Assert.AreEqual(1, dinner.GetServedCount());
        Console.WriteLine("TestPeopleDinner passed.");
    }

    [TestMethod]
    public void TestRobotDinner()
    {
        Console.WriteLine("Running TestRobotDinner...");
        var dinner = new RobotDinner();
        dinner.ServeDinner("1");
        Assert.AreEqual(1, dinner.GetServedCount());
        Console.WriteLine("TestRobotDinner passed.");
    }

    [TestMethod]
    public void TestElectricStation()
    {
        Console.WriteLine("Running TestElectricStation...");
        var station = new ElectricStation();
        station.Refuel("1");
        Assert.AreEqual(1, station.GetChargedCount());
        Console.WriteLine("TestElectricStation passed.");
    }

    [TestMethod]
    public void TestGasStation()
    {
        Console.WriteLine("Running TestGasStation...");
        var station = new GasStation();
        station.Refuel("1");
        Assert.AreEqual(1, station.GetRefueledCount());
        Console.WriteLine("TestGasStation passed.");
    }
}

[TestClass]
public class CarStationTests
{
    [TestMethod]
    public void TestServeCars_ProcessesAllCars()
    {
        Console.WriteLine("Running TestServeCars_ProcessesAllCars...");

        var diningService = new PeopleDinner();
        var electricStation = new ElectricStation();
        var gasStation = new GasStation();
        var carStation = new CarStation(diningService, electricStation, gasStation);

        carStation.AddCar(new Car { Id = 1, Type = "GAS", IsDining = true });
        carStation.AddCar(new Car { Id = 2, Type = "ELECTRIC", IsDining = false });
        carStation.AddCar(new Car { Id = 3, Type = "GAS", IsDining = true });

        carStation.ServeCars();

        Assert.AreEqual(2, diningService.GetServedCount());
        Assert.AreEqual(2, gasStation.GetRefueledCount());
        Assert.AreEqual(1, electricStation.GetChargedCount());

        Console.WriteLine("TestServeCars_ProcessesAllCars passed.");
    }

    [TestMethod]
    public void TestServeCars_ServesDinnerIfIsDiningTrue()
    {
        Console.WriteLine("Running TestServeCars_ServesDinnerIfIsDiningTrue...");

        var diningService = new PeopleDinner();
        var electricStation = new ElectricStation();
        var gasStation = new GasStation();
        var carStation = new CarStation(diningService, electricStation, gasStation);

        carStation.AddCar(new Car { Id = 1, Type = "GAS", IsDining = true });
        carStation.AddCar(new Car { Id = 2, Type = "GAS", IsDining = false });

        carStation.ServeCars();

        Assert.AreEqual(1, diningService.GetServedCount());
        Assert.AreEqual(2, gasStation.GetRefueledCount());

        Console.WriteLine("TestServeCars_ServesDinnerIfIsDiningTrue passed.");
    }

    [TestMethod]
    public void TestServeCars_RefuelsBasedOnCarType()
    {
        Console.WriteLine("Running TestServeCars_RefuelsBasedOnCarType...");

        var diningService = new PeopleDinner();
        var electricStation = new ElectricStation();
        var gasStation = new GasStation();
        var carStation = new CarStation(diningService, electricStation, gasStation);

        carStation.AddCar(new Car { Id = 1, Type = "ELECTRIC", IsDining = false });
        carStation.AddCar(new Car { Id = 2, Type = "GAS", IsDining = false });

        carStation.ServeCars();

        Assert.AreEqual(1, electricStation.GetChargedCount());
        Assert.AreEqual(1, gasStation.GetRefueledCount());

        Console.WriteLine("TestServeCars_RefuelsBasedOnCarType passed.");
    }
}
