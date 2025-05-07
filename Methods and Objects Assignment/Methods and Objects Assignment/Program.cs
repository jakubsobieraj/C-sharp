using System;

namespace InheritanceExample
{
    // This is the base class named Person
    class Person
    {
        // Property to store the person's first name
        public string FirstName { get; set; }

        // Property to store the person's last name
        public string LastName { get; set; }

        // Method that writes the person's full name to the console
        public void SayName()
        {
            // Concatenate first and last name and print it
            Console.WriteLine("Name: " + FirstName + " " + LastName);
        }
    }

    // This class Employee inherits from Person
    class Employee : Person
    {
        // Property to store the employee's ID
        public int Id { get; set; }
    }

    class Program
    {
        // Main method is the entry point of the application
        static void Main(string[] args)
        {
            // Instantiate an Employee object and initialize its properties
            Employee employee = new Employee
            {
                FirstName = "Sample", // Set FirstName
                LastName = "Student", // Set LastName
                Id = 12345            // Set Id (though not used in output)
            };

            // Call the SayName method, inherited from the Person class
            employee.SayName();

            // Wait for a key press before closing the console window
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
