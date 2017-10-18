using System;

namespace SolidPrinciples
{
    /*
    SOLID - acronym - 5 principles:
    S stands for SRP (Single responsibility principle)
    O stands for OCP (Open closed principle)
    L stands for LSP (Liskov substitution principle)
    I stands for ISP ( Interface segregation principle)
    D stands for DIP ( Dependency inversion principle)
    */

    // The SOLID principles are in SolidPrinciples folder

    // *** THERE IS A BONUS - "NEW" UNDERSTANDING
    class Program
    {
        static void Main(string[] args)
        {
            #region Polymorphism 1

            Console.WriteLine("Example1");
            Console.WriteLine("----------");

            Animal a = new Dog();
            var d = new Dog();

            a.Info();   // Animal
            d.Info();   // Dog
            a.Say();    // Woof
            d.Say();    // Woof

            Console.WriteLine();

            Animal a1 = new Cat();
            var c = new Cat();

            a1.Info();  // Animal
            c.Info();   // Cat
            a1.Say();   // Nothing to say - this is due to 'new' accessor
            c.Say();    // Meow

            #endregion

            Console.WriteLine("----------");
            Console.WriteLine("\nExample2");
            Console.WriteLine("----------");

            #region Polymorphism 2

            Car car1 = new Car();
            car1.DescribeCar();
            Console.WriteLine();

            ConvertibleCar car2 = new ConvertibleCar();
            car2.DescribeCar();                             // there would be 'Standard transportation' even though car2 has a ConvertibleCar type 
            Console.WriteLine();

            Minivan car3 = new Minivan();
            car3.DescribeCar();                             // 'Carries seven people' - as we wanted
            Console.WriteLine();

            #endregion

            Console.WriteLine(Environment.NewLine + "Press any kex for exit");
            Console.ReadKey();
        }

        #region Example1

        class Animal
        {
            public void Info()
            {
                Console.WriteLine("Animal");
            }

            public virtual void Say()
            {
                Console.WriteLine("Nothing to say");
            }
        }

        class Dog : Animal
        {
            public new void Info()
            {
                Console.WriteLine("Dog");
            }

            public override void Say()
            {
                Console.WriteLine("Woof");
            }
        }

        class Cat : Animal
        {
            public new void Info()
            {
                Console.WriteLine("Cat");
            }

            public new void Say()
            {
                Console.WriteLine("Meow");
            }
        }

        #endregion

        #region Example2
        class Car
        {
            public void DescribeCar()
            {
                Console.WriteLine("Four wheels and an engine.");
                ShowDetails();
            }

            public virtual void ShowDetails()
            {
                Console.WriteLine("Standard transportation.");
            }
        }

        // Define the derived classes.  

        // Class ConvertibleCar uses the new modifier to acknowledge that ShowDetails  
        // hides the base class method.  
        class ConvertibleCar : Car
        {
            public new void ShowDetails()
            {
                Console.WriteLine("A roof that opens up.");
            }
        }

        // Class Minivan uses the override modifier to specify that ShowDetails  
        // extends the base class method.  
        class Minivan : Car
        {
            public override void ShowDetails()
            {
                Console.WriteLine("Carries seven people.");
            }
        }

        #endregion
    }
}
