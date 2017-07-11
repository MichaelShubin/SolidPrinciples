using System;

namespace SolidPrinciples.LiskovSubstitution
{
    // *** LSP - derived classes must be substitutable for their base classes ***

    // PROBLEM: Thanks to polymorphism we might to run into exception which is not expected
    class Customer
    {
        public int CustType { get; set; }

        public virtual double GetDiscount(double totalSales)
        {
            return totalSales;
        }

        public virtual void Add()
        {
            // Database code goes here
        }
    }

    class Enquiry : Customer
    {
        public override double GetDiscount(double totalSales)
        {
            return base.GetDiscount(totalSales) - 5;
        }

        public override void Add()
        {
            throw new Exception("Not allowed"); // We do not want Enquiry to be saved in DB
        }
    }

    // SOLUTION: Enquiry IS NOT A CUSTOMER, it should not have ADD method

    interface IDiscount
    {
        double GetDiscount(double totalSales);
    }

    interface IDatabase
    {
        void Add();
    }

    class Enquiry2 : IDiscount
    {
        public double GetDiscount(double totalSales)
        {
            return totalSales - 5;
        }
    }

    class Customer2 : IDiscount, IDatabase
    {
        public virtual void Add()
        {
            // Database code goes here
        }

        public virtual double GetDiscount(double totalSales)
        {
            return totalSales;
        }
    }
}
