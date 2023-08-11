using System;

namespace CSharp9Demo
{
    internal sealed class RecordTypes
    {
        /*
         * Records are immutable reference types that provides synthesized methods to provide value semantics for equality.
         */

        public record Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public Person(string firstName, string lastName) => (FirstName, LastName) = (firstName, lastName);
        }

        public record Teacher : Person
        {
            public string Subject { get; set; }

            public Teacher(string firstName, string lastName, string subject)
                : base(firstName, lastName) => Subject = subject;
        }

        public record Pet(string Name)
        {
            public void ShredTheFurniture() =>
                Console.WriteLine($"{nameof(ShredTheFurniture)} got called");
        }

        public record Dog(string Name) : Pet(Name)
        {
            public void WagTail() =>
                Console.WriteLine($"{nameof(WagTail)} got called");
        }

        public static void Run()
        {
            Person person1 = new Person("Stanislav", "Orlov");
            Person person2 = new Person("Stanislav", "Orlov");

            Console.WriteLine(person1 == person2);      //false

            Person brother = person1 with { FirstName = "Vladyslav" };

            Console.WriteLine(person1 == brother);
        }
    }
}
