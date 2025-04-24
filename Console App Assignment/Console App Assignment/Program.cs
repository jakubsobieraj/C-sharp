using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Step 1: Create a list of strings with duplicate entries
        List<string> letters = new List<string>()
        {
            "A", "B", "C", "D", "C" // List with a duplicate "C"
        };

        // Step 2: Create a HashSet to track already seen items (helps identify duplicates)
        HashSet<string> seenItems = new HashSet<string>();

        // Step 3: Loop through each item in the list using foreach
        foreach (var letter in letters)
        {
            // Step 4: Check if the letter has already been seen in the HashSet
            if (seenItems.Contains(letter))
            {
                // Step 5: If it's a duplicate, print that it's a duplicate
                Console.WriteLine($"{letter} - this item is a duplicate");
            }
            else
            {
                // Step 6: If it's unique, print that it's unique
                Console.WriteLine($"{letter} - this item is unique");

                // Add the letter to the HashSet to track that it has been seen
                seenItems.Add(letter);
            }
        }

        // Step 7: Final message to let the user know the program is done
        Console.WriteLine("\nProgram completed. Press any key to exit...");
        Console.ReadKey(); // Keeps the console window open
    }
}
