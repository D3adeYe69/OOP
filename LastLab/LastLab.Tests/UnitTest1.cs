using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class QueueTests
{
    [TestMethod]
    public void TestArrayQueue()
    {
        IQueue<int> queue = new ArrayQueue<int>();
        TestQueueOperations(queue);
    }

    [TestMethod]
    public void TestLinkedQueue()
    {
        IQueue<int> queue = new LinkedQueue<int>();
        TestQueueOperations(queue);
    }

    [TestMethod]
    public void TestCircularQueue()
    {
        IQueue<int> queue = new CircularQueue<int>();
        TestQueueOperations(queue);
    }

    [TestMethod]
    public void TestCarQueue()
    {
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
        Assert.AreEqual(1, queue.Count);
        Assert.AreEqual(1, queue.Peek().Id);
    }

    private void TestQueueOperations(IQueue<int> queue)
    {
        Assert.IsTrue(queue.IsEmpty());
        Assert.AreEqual(0, queue.Count);

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Assert.AreEqual(3, queue.Count);
        Assert.IsFalse(queue.IsEmpty());
        Assert.AreEqual(1, queue.Peek());
        Assert.AreEqual(1, queue.Dequeue());
        Assert.AreEqual(2, queue.Count);
    }
}

[TestClass]
public class DineableRefuelableTests
{
    [TestMethod]
    public void TestPeopleDinner()
    {
        var dinner = new PeopleDinner();
        dinner.ServeDinner("1");
        Assert.AreEqual(1, dinner.GetServedCount());
    }

    [TestMethod]
    public void TestRobotDinner()
    {
        var dinner = new RobotDinner();
        dinner.ServeDinner("1");
        Assert.AreEqual(1, dinner.GetServedCount());
    }

    [TestMethod]
    public void TestElectricStation()
    {
        var station = new ElectricStation();
        station.Refuel("1");
        Assert.AreEqual(1, station.GetChargedCount());
    }

    [TestMethod]
    public void TestGasStation()
    {
        var station = new GasStation();
        station.Refuel("1");
        Assert.AreEqual(1, station.GetRefueledCount());
    }
}