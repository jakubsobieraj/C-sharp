using System;
using System.Collections.Generic; // Required to use List

class Program
{
    static void Main(string[] args)
    {
        // Create a one-dimensional array of strings
        string[] stringArray = { "Apple", "Banana", "Cherry", "Date", "Elderberry" };

        // Ask the user to select an index from the string array
        Console.WriteLine("Select an index (0-4) to display a fruit from the string array:");
        int stringIndex = Convert.ToInt32(Console.ReadLine());

        // Check if the index is valid before displaying
        if (stringIndex >= 0 && stringIndex < stringArray.Length)
        {
            Console.WriteLine("You selected: " + stringArray[stringIndex]);
        }
        else
        {
            Console.WriteLine("Error: The index you selected does not exist in the string array.");
        }

        // Create a one-dimensional array of integers
        int[] intArray = { 10, 20, 30, 40, 50 };

        // Ask the user to select an index from the integer array
        Console.WriteLine("\nSelect an index (0-4) to display a number from the integer array:");
        int intIndex = Convert.ToInt32(Console.ReadLine());

        // Check if the index is valid before displaying
        if (intIndex >= 0 && intIndex < intArray.Length)
        {
            Console.WriteLine("You selected: " + intArray[intIndex]);
        }
        else
        {
            Console.WriteLine("Error: The index you selected does not exist in the integer array.");
        }

        // Create a list of strings
        List<string> stringList = new List<string>() { "Dog", "Cat", "Bird", "Fish", "Lizard" };

        // Ask the user to select an index from the list
        Console.WriteLine("\nSelect an index (0-4) to display an animal from the list:");
        int listIndex = Convert.ToInt32(Console.ReadLine());

        // Check if the index is valid before displaying
        if (listIndex >= 0 && listIndex < stringList.Count)
        {
            Console.WriteLine("You selected: " + stringList[listIndex]);
        }
        else
        {
            Console.WriteLine("Error: The index you selected does not exist in the list.");
        }

        // Prevent the console window from closing immediately
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
