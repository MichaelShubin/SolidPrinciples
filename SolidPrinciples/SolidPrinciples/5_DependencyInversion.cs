using System;

namespace SolidPrinciples.DependencyInversion
{
    // *** D - Depend on abstractions, not on concretions

    // PROBLEM: Having multiple loggers will affect the Customer class

    class Customer
    {
        private readonly FileLogger _obj = new FileLogger();
        public virtual void Add()
        {
            try
            {
                // Database code goes here
            }
            catch (Exception ex)
            {
                _obj.Handle(ex);
            }
        }
    }

    interface ILogger
    {
        void Handle(Exception error);
    }

    class FileLogger : ILogger
    {
        public void Handle(Exception error)
        {
            System.IO.File.WriteAllText(@"c:\Error.txt", error.ToString());
        }
    }

    class EmailLogger : ILogger
    {
        public void Handle(Exception error)
        {
            // send errors in email
        }
    }

    // SOLUTION: we expect someone else to pass the object rather than the Customer class doing it

    class Customer2
    {
        private ILogger _obj;
        public Customer2(ILogger i)
        {
            _obj = i;
        }
    }
}
