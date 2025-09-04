using System;                 // Provides basic classes like Console for input/output
using System.IO;              // Provides classes for working with files

class Program
{
    static void Main(string[] args)
    {
        // Ask the user to enter a number
        Console.Write("Please enter a number: ");

        // Read the input from the user as a string
        string input = Console.ReadLine();

        // Define the file path where the number will be stored
        string filePath = "log.txt";

        // Write the user's input (number) to the text file
        // This will overwrite the file if it already exists
        File.WriteAllText(filePath, input);

        // Read the contents of the text file back into the program
        string fileContents = File.ReadAllText(filePath);

        // Print the contents of the file to the console
        Console.WriteLine("\nThe contents of the file are:");
        Console.WriteLine(fileContents);

        // Pause so the console window doesn’t close immediately
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
