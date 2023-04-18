using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Test
{
    public interface shape
    {
        void PrintShape();
    }

    public interface IAccount
    {
        void printDeets();
    }
    class CurrAcc : IAccount
    {
        public void printDeets()
        {
            Console.WriteLine("Current Account");
        }

    }
    class SavAcc : IAccount
    {
        public void printDeets()
        {
            Console.WriteLine("Savings Account");
        }
    }
    class Account
    {
        private IAccount account;
        public Account(IAccount account)
        {
            this.account = account;
        }
        public void printDeets()
        {
            account.printDeets();
        }
    }
    class Rectangle : shape
    {
        public void PrintShape()
        {
            Console.WriteLine("i am a Rectangle.");
        }
    }
    class Circle : shape
    {
        public void PrintShape()
        {
            Console.WriteLine("i am a Circle.");
        }
    }

    class ShapeMain
    {
        public shape ShapE { get; set; }

        public void PrintAccounts()
        {
            ShapE.PrintShape();
        }
    }


    class program
    {
        public static void Main(string[] arg)
        {
            IAccount ca = new CurrAcc();
            Account a = new Account(ca);//dependency injection using constructor
            a.printDeets();

            IAccount sa = new SavAcc();
            Account a1 = new Account(sa);//using constructor
            a1.printDeets();

            ShapeMain tr = new ShapeMain();//using properties (getters and setters)
            tr.ShapE = new Rectangle();
            tr.PrintShape();

            ShapeMain rec = new ShapeMain();
            rec.ShapE = new Circle();
            rec.PrintShape();


            Console.ReadKey();
        }

    }

}