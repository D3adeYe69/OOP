using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace LastLab
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Main method...");
            var peopleDinner = new PeopleDinner();
            var robotDinner = new RobotDinner();
            var gasStation = new GasStation();
            var electricStation = new ElectricStation();

            // Create car stations with corresponding refueling and dining services
            var gasCarStation = new CarStation(gasStation, peopleDinner);
            var electricCarStation = new CarStation(electricStation, robotDinner);

            // Initialize the Semaphore
            var semaphore = new Semaphore(gasCarStation, electricCarStation, peopleDinner, robotDinner);

            // Process queue folder
            ProcessQueueFolder(semaphore);

            // Print final statistics
            PrintStatistics(gasStation, electricStation, peopleDinner, robotDinner);
        }

        private static void ProcessQueueFolder(Semaphore semaphore)
        {
            string queueFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "queue");
            if (!Directory.Exists(queueFolderPath))
            {
                Console.WriteLine($"Creating queue folder at: {queueFolderPath}");
                Directory.CreateDirectory(queueFolderPath);
            }

            var jsonFiles = Directory.GetFiles(queueFolderPath, "*.json")
                .OrderBy(f => int.Parse(Path.GetFileNameWithoutExtension(f).Replace("Car", "")))
                .ToArray();

            Console.WriteLine($"Found {jsonFiles.Length} files in queue folder");

            foreach (var jsonFile in jsonFiles)
            {
                ProcessJsonFile(jsonFile, semaphore);
            }

            // Process all queued cars
            semaphore.ServeCars();
        }
        private static void ProcessJsonFile(string jsonFile, Semaphore semaphore)
        {
            Console.WriteLine($"Processing file: {jsonFile}");
            var cars = LoadCarsFromJson(jsonFile);

            foreach (var car in cars)
            {
                semaphore.GuideCarToStation(car);
            }
        }

        public static List<Car> LoadCarsFromJson(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"JSON file not found: {filePath}");

            string jsonContent = File.ReadAllText(filePath);
            if (string.IsNullOrWhiteSpace(jsonContent))
                return new List<Car>();

            try
            {
                // First try to deserialize as a single car
                try
                {
                    var singleCar = JsonConvert.DeserializeObject<Car>(jsonContent);
                    if (singleCar != null)
                        return new List<Car> { singleCar };
                }
                catch (JsonReaderException)
                {
                    // If single car deserialization fails, try as an array
                    var cars = JsonConvert.DeserializeObject<List<Car>>(jsonContent);
                    return cars ?? new List<Car>();
                }
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Error parsing JSON file {filePath}: {ex.Message}");
            }

            return new List<Car>();
        }

        private static void PrintStatistics(
            GasStation gasStation,
            ElectricStation electricStation,
            PeopleDinner peopleDinner,
            RobotDinner robotDinner)
        {
            Console.WriteLine("\nFinal Statistics:");
            Console.WriteLine($"Gas cars served: {gasStation.GetRefueledCount()}");
            Console.WriteLine($"Electric cars charged: {electricStation.GetChargedCount()}");
            Console.WriteLine($"People served dinner: {peopleDinner.GetServedCount()}");
            Console.WriteLine($"Robots served dinner: {robotDinner.GetServedCount()}");
        }
    }
}