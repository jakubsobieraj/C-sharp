using System;

namespace AbstractClassExample
{
    // Define an abstract class called Person
    abstract class Person
    {
        // Property to hold the first name of the person
        public string firstName { get; set; }

        // Property to hold the last name of the person
        public string lastName { get; set; }

        // Abstract method that must be implemented in derived classes
        public abstract void SayName();
    }

    // Employee class inherits from the abstract Person class
    class Employee : Person
    {
        // Override and implement the SayName method from the base class
        public override void SayName()
        {
            // Print the full name in the specified format
            Console.WriteLine("Name: " + firstName + " " + lastName);
        }
    }

    class Program
    {
        // The entry point of the console application
        static void Main(string[] args)
        {
            // Create an instance of Employee and initialize first and last names
            Employee employee = new Employee
            {
                firstName = "Sample",
                lastName = "Student"
            };

            // Call the SayName method to print the full name
            employee.SayName();

            // Keep the console window open until a key is pressed
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
