using System;

namespace SolidPrinciples.SingleResponsibility
{
    // *** SRP says that a class should have only one responsibility and not multiple ***
    
    // PROBLEM: The customer class IS NOT SUPPOSED TO log anything

    class Customer
    {
        public void Add()
        {
            try
            {
                // Database code goes here
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText(@"c:\Error.txt", ex.ToString());
            }
        }

        
    }


    //SOLUTION:

    class FileLogger
    {
        public void Handle(Exception ex)
        {
            System.IO.File.WriteAllText(@"c:\Error.txt", ex.ToString());
        }
    }

    class Customer2
    {
        private readonly FileLogger _obj = new FileLogger();  // do not pay your attention on "new" yet :)
        public virtual void Add()
        {
            try  // do not pay your attention on "try-catch" presence yet:)
            {
                // Database code goes here
            }
            catch (Exception ex)
            {
                _obj.Handle(ex);
            }
        }
    }
}
