using System;

namespace InterfaceExample
{
    // Step 1: Define an interface named IQuittable with a method signature Quit()
    interface IQuittable
    {
        // This method must be implemented by any class that inherits this interface
        void Quit();
    }

    // Step 2: Create an Employee class that implements the IQuittable interface
    class Employee : IQuittable
    {
        // Example properties for the Employee class
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Constructor to initialize an Employee object
        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        // Step 3: Implement the Quit() method from the IQuittable interface
        public void Quit()
        {
            // Example implementation of the Quit method
            Console.WriteLine($"{FirstName} {LastName} has quit the job.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Step 4: Use polymorphism to assign an Employee object to an IQuittable interface variable
            IQuittable quitter = new Employee("John", "Doe");

            // Call the Quit() method through the IQuittable interface
            quitter.Quit();

            // Keep the console window open until a key is pressed
            Console.ReadKey();
        }
    }
}
