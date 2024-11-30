using Microsoft.VisualStudio.TestTools.UnitTesting;
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

    [TestMethod]
    public void TestSemaphoreCarRouting()
    {
        // Setup stations
        var peopleDinner = new PeopleDinner();
        var robotDinner = new RobotDinner();
        var gasStation = new GasStation();
        var electricStation = new ElectricStation();

        var gasCarStation = new CarStation(gasStation, peopleDinner);
        var electricCarStation = new CarStation(electricStation, robotDinner);
        var semaphore = new Semaphore(gasCarStation, electricCarStation, peopleDinner, robotDinner);

        // Create test cars
        var gasCar = new Car { Id = 1, Type = "GAS", Passengers = "PEOPLE", IsDining = true, Consumption = 50 };
        var electricCar = new Car { Id = 2, Type = "ELECTRIC", Passengers = "ROBOTS", IsDining = true, Consumption = 40 };

        // Guide cars to stations
        semaphore.GuideCarToStation(gasCar);
        semaphore.GuideCarToStation(electricCar);

        // Verify queue counts
        Assert.AreEqual(1, semaphore.GetGasQueueCount(), "Gas queue should have 1 car");
        Assert.AreEqual(1, semaphore.GetElectricQueueCount(), "Electric queue should have 1 car");

        // Process cars
        semaphore.ServeCars();

        // Verify final counts
        Assert.AreEqual(1, gasStation.GetRefueledCount(), "One gas car should be refueled");
        Assert.AreEqual(1, electricStation.GetChargedCount(), "One electric car should be charged");
        Assert.AreEqual(1, peopleDinner.GetServedCount(), "People should be served dinner");
        Assert.AreEqual(1, robotDinner.GetServedCount(), "Robots should be served dinner");
    }

    [TestMethod]
    public void TestMultipleCarProcessing()
    {
        // Setup
        var peopleDinner = new PeopleDinner();
        var robotDinner = new RobotDinner();
        var gasStation = new GasStation();
        var electricStation = new ElectricStation();

        var gasCarStation = new CarStation(gasStation, peopleDinner);
        var electricCarStation = new CarStation(electricStation, robotDinner);
        var semaphore = new Semaphore(gasCarStation, electricCarStation, peopleDinner, robotDinner);

        // Create multiple test cars
        var cars = new List<Car>
        {
            new Car { Id = 1, Type = "GAS", Passengers = "PEOPLE", IsDining = true, Consumption = 50 },
            new Car { Id = 2, Type = "ELECTRIC", Passengers = "ROBOTS", IsDining = true, Consumption = 40 },
            new Car { Id = 3, Type = "GAS", Passengers = "PEOPLE", IsDining = false, Consumption = 30 },
            new Car { Id = 4, Type = "ELECTRIC", Passengers = "ROBOTS", IsDining = false, Consumption = 25 }
        };

        // Process all cars
        foreach (var car in cars)
        {
            semaphore.GuideCarToStation(car);
        }

        // Verify queue counts before processing
        Assert.AreEqual(2, semaphore.GetGasQueueCount(), "Gas queue should have 2 cars");
        Assert.AreEqual(2, semaphore.GetElectricQueueCount(), "Electric queue should have 2 cars");

        // Process all cars
        semaphore.ServeCars();

        // Verify final counts
        Assert.AreEqual(2, gasStation.GetRefueledCount(), "Two gas cars should be refueled");
        Assert.AreEqual(2, electricStation.GetChargedCount(), "Two electric cars should be charged");
        Assert.AreEqual(1, peopleDinner.GetServedCount(), "One group of people should be served dinner");
        Assert.AreEqual(1, robotDinner.GetServedCount(), "One group of robots should be served dinner");
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

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestSemaphoreNullCar()
    {
        var peopleDinner = new PeopleDinner();
        var robotDinner = new RobotDinner();
        var gasStation = new GasStation();
        var electricStation = new ElectricStation();

        var gasCarStation = new CarStation(gasStation, peopleDinner);
        var electricCarStation = new CarStation(electricStation, robotDinner);
        var semaphore = new Semaphore(gasCarStation, electricCarStation, peopleDinner, robotDinner);

        semaphore.GuideCarToStation(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestSemaphoreInvalidCarType()
    {
        var peopleDinner = new PeopleDinner();
        var robotDinner = new RobotDinner();
        var gasStation = new GasStation();
        var electricStation = new ElectricStation();

        var gasCarStation = new CarStation(gasStation, peopleDinner);
        var electricCarStation = new CarStation(electricStation, robotDinner);
        var semaphore = new Semaphore(gasCarStation, electricCarStation, peopleDinner, robotDinner);

        var invalidCar = new Car { Id = 1, Type = "DIESEL", Passengers = "PEOPLE", IsDining = true, Consumption = 50 };
        semaphore.GuideCarToStation(invalidCar);
    }
}