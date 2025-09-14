using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a list of integers to be divided
        List<int> numbers = new List<int>() { 10, 20, 30, 40, 50 };

        // Ask the user for a number to divide each list element by
        Console.Write("Please enter a number to divide each number in the list by: ");
        string userInput = Console.ReadLine(); // Read user input as a string

        try
        {
            // Try to convert the user input to an integer
            int divisor = Convert.ToInt32(userInput);

            // Loop through each number in the list
            foreach (int number in numbers)
            {
                // Perform the division and display the result
                int result = number / divisor;
                Console.WriteLine($"{number} divided by {divisor} is {result}");
            }
        }
        catch (DivideByZeroException ex)
        {
            // Catch if user attempts to divide by zero
            Console.WriteLine("Error: Cannot divide by zero.");
            Console.WriteLine("Exception message: " + ex.Message);
        }
        catch (FormatException ex)
        {
            // Catch if the input is not a valid integer (e.g., a string)
            Console.WriteLine("Error: Invalid input. Please enter a valid integer.");
            Console.WriteLine("Exception message: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Catch any other unforeseen exceptions
            Console.WriteLine("An unexpected error occurred.");
            Console.WriteLine("Exception message: " + ex.Message);
        }

        // This message will always be displayed after the try/catch block
        Console.WriteLine("Program has emerged from the try/catch block and continues running.");

        // Keep the console window open until the user presses a key
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
