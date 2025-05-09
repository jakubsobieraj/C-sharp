using System;

namespace EmployeeComparisonApp
{
    // Define the Employee class
    public class Employee
    {
        // Property to store the employee's unique identifier
        public int Id { get; set; }

        // Property to store the employee's first name
        public string FirstName { get; set; }

        // Property to store the employee's last name
        public string LastName { get; set; }

        // Override the equality operator (==) to compare employees by Id
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            // If both are null, or both are same instance, return true
            if (ReferenceEquals(emp1, emp2))
                return true;

            // If one is null, but not both, return false
            if (emp1 is null || emp2 is null)
                return false;

            // Compare the Ids of the two Employee objects
            return emp1.Id == emp2.Id;
        }

        // Override the inequality operator (!=) as required when overloading ==
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return !(emp1 == emp2);
        }

        // Override Equals to keep consistency with the == operator
        public override bool Equals(object obj)
        {
            // Check if the object is an Employee and compare by Id
            return obj is Employee employee && this.Id == employee.Id;
        }

        // Override GetHashCode to match Equals implementation
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    // Main program class
    class Program
    {
        // Entry point of the application
        static void Main(string[] args)
        {
            // Create first employee object
            Employee emp1 = new Employee { Id = 1, FirstName = "John", LastName = "Doe" };

            // Create second employee object with same Id
            Employee emp2 = new Employee { Id = 1, FirstName = "Jane", LastName = "Smith" };

            // Create third employee object with different Id
            Employee emp3 = new Employee { Id = 2, FirstName = "Alice", LastName = "Brown" };

            // Compare emp1 and emp2 using overloaded ==
            Console.WriteLine("emp1 == emp2: " + (emp1 == emp2)); // True - same Id

            // Compare emp1 and emp3 using overloaded ==
            Console.WriteLine("emp1 == emp3: " + (emp1 == emp3)); // False - different Id

            // Compare emp1 and emp2 using overloaded !=
            Console.WriteLine("emp1 != emp2: " + (emp1 != emp2)); // False - same Id

            // Keep the console window open
            Console.ReadLine();
        }
    }
}
