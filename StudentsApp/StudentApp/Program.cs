using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentContext())
            {
                Console.Write("Enter first name: ");
                var firstName = Console.ReadLine();

                Console.Write("Enter last name: ");
                var lastName = Console.ReadLine();

                Console.Write("Enter email: ");
                var email = Console.ReadLine();

                var student = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email
                };

                db.Students.Add(student);
                db.SaveChanges();

                Console.WriteLine("\nAll students in the database:");
                foreach (var s in db.Students)
                {
                    Console.WriteLine($"{s.StudentId}: {s.FirstName} {s.LastName} - {s.Email}");
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
    public class Student
    {
        public int StudentId { get; set; }  //PK
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
