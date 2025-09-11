using System;   // Provides basic classes like Console and DateTime

class Program
{
    static void Main(string[] args)
    {
        // Step 1: Print the current date and time to the console
        DateTime now = DateTime.Now;  // Get the current system date and time
        Console.WriteLine("The current date and time is: " + now);

        // Step 2: Ask the user for a number (representing hours to add)
        Console.Write("\nEnter a number of hours to add: ");
        string input = Console.ReadLine();  // Read input from the user as a string

        // Convert the input string into an integer (number of hours)
        // This assumes the user enters a valid integer, otherwise an exception could occur
        int hoursToAdd = int.Parse(input);

        // Step 3: Calculate the future time by adding the user-specified hours
        DateTime futureTime = now.AddHours(hoursToAdd);

        // Step 4: Print the result to the console
        Console.WriteLine("\nIn " + hoursToAdd + " hour(s), the time will be: " + futureTime);

        // Step 5: Pause the program so the console doesn't close immediately
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}