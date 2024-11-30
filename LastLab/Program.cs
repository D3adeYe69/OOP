using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LastLab
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Starting Main method...");
            var peopleDinner = new PeopleDinner();
            var robotDinner = new RobotDinner();
            var gasStation = new GasStation();
            var electricStation = new ElectricStation();

            var gasCarStation = new CarStation(gasStation, peopleDinner);
            var electricCarStation = new CarStation(electricStation, robotDinner);
            var semaphore = new Semaphore(gasCarStation, electricCarStation, peopleDinner, robotDinner);

            string currentDir = Directory.GetCurrentDirectory();
            string projectDir = Path.GetFullPath(Path.Combine(currentDir, "..", "..", ".."));
            string queuePath = Path.Combine(projectDir, "queue");

            if (Directory.Exists(queuePath))
            {
                Directory.Delete(queuePath, true);
            }
            Directory.CreateDirectory(queuePath);
            Console.WriteLine($"Created queue directory at: {queuePath}");

            // Start generator
            Process? generatorProcess = null;
            try
            {
                string pythonPath = Path.Combine(projectDir, "generator.py");
                Console.WriteLine($"Starting generator at: {pythonPath}");

                var processInfo = new ProcessStartInfo()
                {
                    FileName = "py",
                    Arguments = pythonPath,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    WorkingDirectory = projectDir
                };

                generatorProcess = Process.Start(processInfo);

                if (generatorProcess != null)
                {
                    Console.WriteLine("\nPress Enter to stop the generator and begin processing...");
                    Console.ReadLine();

                    if (!generatorProcess.HasExited)
                    {
                        generatorProcess.Kill();
                        Console.WriteLine("Generator stopped. Starting car processing...\n");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with generator: {ex.Message}");
                return;
            }
            finally
            {
                if (generatorProcess != null)
                {
                    generatorProcess.Dispose();
                }
            }

            // Process all cars
            using (var scheduler = new CarScheduler(semaphore))
            {
                await scheduler.ProcessAllCars();
            }

            Console.WriteLine("Main method complete.");
        }
    }
}