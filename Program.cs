using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        bool running = true;

        Console.WriteLine("Console Stopwatch");
        Console.WriteLine("Commands:");
        Console.WriteLine("  start   - Start or restart the stopwatch");
        Console.WriteLine("  pause   - Pause the stopwatch");
        Console.WriteLine("  resume  - Resume the stopwatch");
        Console.WriteLine("  reset   - Reset the stopwatch to 00:00:00");
        Console.WriteLine("  exit    - Exit the program");

        while (running)
        {
            Console.WriteLine("\nEnter command: ");
            string command = Console.ReadLine()?.Trim().ToLower();

            switch (command)
            {
                case "start":
                    stopwatch.Reset();
                    stopwatch.Start();
                    DisplayTime(stopwatch);
                    break;

                case "pause":
                    stopwatch.Stop();
                    Console.WriteLine("Stopwatch paused.");
                    break;

                case "resume":
                    if (!stopwatch.IsRunning)
                    {
                        stopwatch.Start();
                        DisplayTime(stopwatch);
                    }
                    else
                    {
                        Console.WriteLine("Stopwatch is already running.");
                    }
                    break;

                case "reset":
                    stopwatch.Reset();
                    Console.WriteLine("Stopwatch reset to 00:00:00.");
                    break;

                case "exit":
                    running = false;
                    Console.WriteLine("Exiting program.");
                    break;

                default:
                    Console.WriteLine("Unknown command. Please try again.");
                    break;
            }
        }
    }

    static void DisplayTime(Stopwatch stopwatch)
    {
        Thread timerThread = new Thread(() =>
        {
            while (stopwatch.IsRunning)
            {
                Console.Clear();
                Console.WriteLine($"Elapsed Time: {stopwatch.Elapsed.ToString(@"hh\:mm\:ss")}");
                Thread.Sleep(1000);
            }
        });

        timerThread.IsBackground = true; // Allows thread to exit when the main program exits
        timerThread.Start();
    }
}
