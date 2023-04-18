//#nullable disable
using System;
using System.Security.Cryptography;

namespace CSNullBasics
{
    class Program
    {   static void Main(string[] args) 
        {

            Message message = new()
            {
                Text = "Hello there",
                From = null
            };

            MessagePopulator.Populate(message);

            Console.WriteLine(message.Text);
            Console.WriteLine(message.From ?? "No from");
            Console.WriteLine(message.From!.Length);
            Console.WriteLine(message.ToUpperFrom());

            Console.WriteLine("Press Enter to end");
            Console.ReadLine();
        }

    }
}
