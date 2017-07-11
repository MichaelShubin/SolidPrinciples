namespace SolidPrinciples.OpenClosed
{
    // *** O - If we need to EXTEND a class, we should not MODIFY it ***

    // PROBLEM: if we add a new customer type we need to go and add one more condition (as a result - we are supposed to test it again and again)

    class Customer
    {
        public int CustType { get; set; }
        
        public double GetDiscount(double totalSales)
        {
            return totalSales - (CustType == 1 ? 100 : 50);
        }
    }

    // SOLUTION: close Customer class for any modification

    class Customer2
    {
        public virtual double GetDiscount(double totalSales)
        {
            return totalSales;
        }
    }

    class SilverCustomer : Customer2
    {
        public override double GetDiscount(double totalSales)
        {
            return base.GetDiscount(totalSales) - 50;
        }
    }

    class GoldCustomer : SilverCustomer
    {
        public override double GetDiscount(double totalSales)
        {
            return base.GetDiscount(totalSales) - 100;
        }
    }
}
