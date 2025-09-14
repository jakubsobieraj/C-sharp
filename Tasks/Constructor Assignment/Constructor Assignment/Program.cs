using System;

namespace ConsoleAppExample
{
    // This is the main Program class
    class Program
    {
        // Entry point of the application
        static void Main(string[] args)
        {
            // Create a const variable (its value cannot be changed after compilation)
            const double Pi = 3.14159;
            Console.WriteLine($"The value of Pi is: {Pi}");

            // Create a variable using the 'var' keyword.
            // The type is inferred by the compiler based on the value assigned.
            var message = "Hello, C#!";
            Console.WriteLine(message);

            // Create instances of the Person class using constructor chaining
            Person person1 = new Person("Alice");          // Calls first constructor
            Person person2 = new Person("Bob", 30);        // Calls second constructor (which chains to the first)

            // Display info about the persons
            person1.DisplayInfo();
            person2.DisplayInfo();

            Console.ReadLine(); // Keep console window open
        }
    }

    // Define a Person class
    class Person
    {
        // Fields to hold name and age
        private string name;
        private int age;

        // First constructor: takes only the name
        public Person(string name)
        {
            this.name = name;
            this.age = 0; // default age
        }

        // Second constructor: takes name and age
        // This constructor chains to the first constructor to avoid code duplication
        public Person(string name, int age) : this(name)
        {
            this.age = age; // Set age after chaining to first constructor
        }

        // Method to display person info
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}, Age: {age}");
        }
    }
}
