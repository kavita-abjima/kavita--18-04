using System;


/*
* Benefits of Records:
* - Simple to write
* - Thread safe
* - Easy and safe to share
* 
* When to use:
* - Capture external data that doesn't change - Weather Service,SWAPI.dev
* - API Calls
* - Processing data
* - Read-Only Data
* 
* When not to use:
*  - when data is needed to be changed (Entity Framework)
*/


namespace RecordDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Record1 r1a = new("Tim", "Corey");
            Record1 r1b = new("Tim", "Corey");
            Record1 r1c = new("Sue", "Storm");

            Class1 c1a = new("Tim", "Corey");
            Class1 c1b = new("Tim", "Corey");
            Class1 c1c = new("Sue", "Storm");

            Console.WriteLine("Record Type:");
            Console.WriteLine($"To String: {r1a}");
            Console.WriteLine($"Are the two objects equal: {Equals(r1a, r1b)}");
            Console.WriteLine($"Are the two objects reference equal: {ReferenceEquals(r1a, r1b)}");
            Console.WriteLine($"Are the two objects ==: {r1a == r1b}");
            Console.WriteLine($"Are the two objects !=: {r1a != r1c}");
            Console.WriteLine($"Hash Code of object A : {r1a.GetHashCode()}");
            Console.WriteLine($"Hash Code of object B : {r1b.GetHashCode()}");
            Console.WriteLine($"Hash Code of object C : {r1c.GetHashCode()}");


            Console.WriteLine();
            Console.WriteLine("**************************************");
            Console.WriteLine();

            Console.WriteLine("Class Type:");
            Console.WriteLine($"To String: {c1a}");
            Console.WriteLine($"Are the two objects equal: {Equals(c1a, c1b)}");
            Console.WriteLine($"Are the two objects reference equal: {ReferenceEquals(c1a, c1b)}");
            Console.WriteLine($"Are the two objects ==: {c1a == c1b}");
            Console.WriteLine($"Are the two objects !=: {c1a != c1c}");
            Console.WriteLine($"Hash Code of object A : {c1a.GetHashCode()}");
            Console.WriteLine($"Hash Code of object B : {c1b.GetHashCode()}");
            Console.WriteLine($"Hash Code of object C : {c1c.GetHashCode()}");

            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
            
            var (fn, ln) = r1a;
            Console.WriteLine($"The value for Fn is : {fn} and the value for Ln is {ln}");

            Record1 r1d = r1a with
            {
                FirstName = "Jon"
            };
            Console.WriteLine($"r1d = {r1d}" );

            Console.WriteLine();
            Record2 r2a = new("Tim", "Corey");
            Console.WriteLine($"R2a value: {r2a}");
            Console.WriteLine($"R2a fn: {r2a.FirstName}  ln: {r2a.LastName}");
            Console.WriteLine(r2a.SayHello());

        }
    }
    //Immutable - Values cannot be changed.
    public record Record1 (string FirstName, string LastName);
    //Inheritance -  User 1 Inheriting the Record 1
    public record User1 (int Id, string FirstName,string LastName) : Record1(FirstName, LastName);

    public class DiscoveryModel
    {
        public User1 LookupUser { get; set; }
        public int InsidentsFound { get; set; }
        public List<string> Insidents { get; set; }
    }
    public record Record2 (string FirstName, string LastName)
    {
        private string _firstName = FirstName;

        public string FirstName
        {
            get { return _firstName.Substring(0, 1); }
            init {}    
        }

        public string FullName { get => $"{FirstName} {LastName}"; }

        public string SayHello()
        {
            return $"Hello {FirstName}";
        }
    }

    //-------------------------------------------------------------------------------//
    public class Class1
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public Class1(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void Deconstruct (out string FirstName, out string LastName)
        {
            FirstName = this.FirstName;
            LastName = this.LastName;
        }
    }



    //***************************//
    //DO NOT DO ANY OF BELOW
    //***************************//
    
    ///This is wrong because it is mutabe this way which is against RECORD being immutable
    public record Record3    
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    ///-------------------------------------------//
}