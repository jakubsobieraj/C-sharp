using System;

namespace DivisionApp
{
    // This is a regular (non-static) class that will perform various operations
    class Divider
    {
        // This method divides the input number by 2 and displays the result
        public void DivideAndDisplay(int number)
        {
            int result = number / 2; // Perform division
            Console.WriteLine("Result of dividing by 2: " + result); // Output result
        }

        // This is a method with an 'out' parameter, which outputs the result to the caller
        public void DivideWithOutput(int number, out int result)
        {
            result = number / 2; // Perform division and assign it to the out parameter
        }

        // Method Overload: same method name, different parameters (double instead of int)
        public void DivideWithOutput(double number, out double result)
        {
            result = number / 2.0; // Divide the double value and return via out parameter
        }
    }

    // This is a static class, meaning you cannot instantiate it. It only contains static methods.
    static class StaticHelper
    {
        // A static utility method to show that static classes can only have static members
        public static void ShowInfo()
        {
            Console.WriteLine("This is a static helper method from a static class.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the Divider class to access non-static methods
            Divider divider = new Divider();

            // Ask the user to enter a number
            Console.Write("Enter an integer number: ");
            string userInput = Console.ReadLine(); // Read user input from the console
            int number;

            // Try parsing the input to an integer
            if (int.TryParse(userInput, out number))
            {
                // Call the method that divides and displays directly
                divider.DivideAndDisplay(number);

                // Call the method with an out parameter (int version)
                int outputResult;
                divider.DivideWithOutput(number, out outputResult);
                Console.WriteLine("Output from method with 'out' parameter: " + outputResult);

                // Call the overloaded method (double version)
                double doubleOutput;
                divider.DivideWithOutput((double)number, out doubleOutput);
                Console.WriteLine("Output from overloaded method with double: " + doubleOutput);
            }
            else
            {
                // Inform the user if the input was invalid
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

            // Call the static method from the static class
            StaticHelper.ShowInfo();

            // Wait for user to press a key before closing
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
