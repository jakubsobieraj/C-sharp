using System;

namespace MathOperationApp
{
    // This is a user-defined class named MathOperations
    class MathOperations
    {
        // This method takes two integers as input parameters
        // It performs a math operation on the first integer
        // and displays the second integer to the screen
        public void PerformOperation(int firstNumber, int secondNumber)
        {
            // Perform a math operation on the first number
            int result = firstNumber * 2;

            // Display the result of the math operation
            Console.WriteLine("Result of math operation on the first number: " + result);

            // Display the second number passed to the method
            Console.WriteLine("Second number is: " + secondNumber);
        }
    }

    class Program
    {
        // The Main method is the entry point of the console application
        static void Main(string[] args)
        {
            // Instantiate the MathOperations class
            MathOperations mathOps = new MathOperations();

            // Call the PerformOperation method by passing two numbers positionally
            mathOps.PerformOperation(5, 10);

            // Call the PerformOperation method by specifying parameter names
            mathOps.PerformOperation(firstNumber: 7, secondNumber: 3);

            // Keep the console window open so we can read the output
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
