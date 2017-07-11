namespace SolidPrinciples.InterfaceSegregation
{
    // *** ISP - create a new interface rather than updating the current interface

    //PROBLEM: SOME consumers of IDatabase want to have additional method

    interface IDatabase
    {
        void Add();
        // In this case, you will have to add Read method to clients which are realy not interesting in it
        //void Read();
    }

    // SOLUTION: Just describe new interface, which derives from IDatabase

    interface IDatabaseV1 : IDatabase // Gets the Add method
    {
        void Read();
    }

    class OldCustomerWithoutRead : IDatabase
    {
        public void Add()
        {
            // Implements only logic for Add
        }
    }

    class NewCustomerWithRead : IDatabaseV1
    {
        public void Add()
        {
            // Implements logic for Add
        }
        public void Read()
        {
            // Implements logic for Read
        }
    }
}
