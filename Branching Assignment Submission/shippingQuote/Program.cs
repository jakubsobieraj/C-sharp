using System; // Import System namespace for basic console input/output functions

class Program
{
    static void Main()
    {
        // Display welcome message at the start of the program
        Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

        // Prompt the user to enter the package weight
        Console.WriteLine("Please enter the package weight:");
        decimal weight = Convert.ToDecimal(Console.ReadLine());

        // Check if the package weight is greater than 50
        if (weight > 50)
        {
            // If too heavy, display message and exit program immediately
            Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
            return; // End the program
        }

        // Use a loop to allow retrying if dimensions are too large
        bool validDimensions = false; // Flag to check if dimensions are acceptable

        while (!validDimensions)
        {
            // Prompt user to enter package width
            Console.WriteLine("Please enter the package width:");
            decimal width = Convert.ToDecimal(Console.ReadLine());

            // Prompt user to enter package height
            Console.WriteLine("Please enter the package height:");
            decimal height = Convert.ToDecimal(Console.ReadLine());

            // Prompt user to enter package length
            Console.WriteLine("Please enter the package length:");
            decimal length = Convert.ToDecimal(Console.ReadLine());

            // Calculate the sum of dimensions
            decimal dimensionTotal = width + height + length;

            // Check if dimensions are too big
            if (dimensionTotal > 50)
            {
                // Display error and restart dimension input
                Console.WriteLine("Package too big to be shipped via Package Express. Please try again.");
            }
            else
            {
                // Dimensions are valid, proceed to calculate quote
                validDimensions = true; // Exit the loop
                decimal quote = (width * height * length) * weight / 100; // Calculate shipping quote

                // Display the calculated quote formatted to 2 decimal places
                Console.WriteLine($"Your estimated total for shipping this package is: ${quote:F2}");
                Console.WriteLine("Thank you!"); // Thank the user
            }
        }
    }
}
