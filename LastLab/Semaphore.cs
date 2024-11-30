using System;
using System.Collections.Generic;

public class Semaphore
{
    private readonly CarStation gasStation;
    private readonly CarStation electricStation;
    private readonly PeopleDinner peopleDinner;
    private readonly RobotDinner robotDinner;
    private readonly IQueue<Car> gasQueue;
    private readonly IQueue<Car> electricQueue;

    public Semaphore(CarStation gasStation, CarStation electricStation,
                    PeopleDinner peopleDinner, RobotDinner robotDinner)
    {
        this.gasStation = gasStation;
        this.electricStation = electricStation;
        this.peopleDinner = peopleDinner;
        this.robotDinner = robotDinner;
        this.gasQueue = new ArrayQueue<Car>();
        this.electricQueue = new ArrayQueue<Car>();
    }

    public void GuideCarToStation(Car? car)
    {
        if (car == null)
            throw new ArgumentNullException(nameof(car));

        switch (car.Type?.ToUpper())
        {
            case "GAS":
                gasQueue.Enqueue(car);
                Console.WriteLine($"Gas car {car.Id} added to gas queue");
                break;
            case "ELECTRIC":
                electricQueue.Enqueue(car);
                Console.WriteLine($"Electric car {car.Id} added to electric queue");
                break;
            default:
                throw new ArgumentException($"Unknown car type: {car.Type}");
        }
    }

    public void ServeCars()
    {
        // Process gas cars queue
        while (!gasQueue.IsEmpty())
        {
            var car = gasQueue.Dequeue();
            gasStation.AddCar(car);
        }

        // Process electric cars queue
        while (!electricQueue.IsEmpty())
        {
            var car = electricQueue.Dequeue();
            electricStation.AddCar(car);
        }

        // Service all cars at their respective stations
        gasStation.ServeCars();
        electricStation.ServeCars();
    }

    public int GetGasQueueCount() => gasQueue.Count;
    public int GetElectricQueueCount() => electricQueue.Count;
}