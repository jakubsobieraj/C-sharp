// Program.cs
using System;
using MathApp; // Include the namespace to access the MathOperations class

namespace MathConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the MathOperations class to access its methods
            MathOperations operations = new MathOperations();

            // Prompt the user to enter a number
            Console.Write("Enter a number to perform math operations on: ");

            // Read the user's input as a string
            string input = Console.ReadLine();

            // Try to parse the string input to an integer
            if (int.TryParse(input, out int userNumber))
            {
                // Call the AddTen method and display the result
                int resultAdd = operations.AddTen(userNumber);
                Console.WriteLine($"After adding 10: {resultAdd}");

                // Call the MultiplyByTwo method and display the result
                int resultMultiply = operations.MultiplyByTwo(userNumber);
                Console.WriteLine($"After multiplying by 2: {resultMultiply}");

                // Call the SubtractFive method and display the result
                int resultSubtract = operations.SubtractFive(userNumber);
                Console.WriteLine($"After subtracting 5: {resultSubtract}");
            }
            else
            {
                // Display an error if the input is not a valid integer
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

            // Wait for user to press a key before closing the console
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
