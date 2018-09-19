using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();

            // Pass a regular method as a callback
            myClass.LongRunningMethod1(printProgress);

            Console.WriteLine("/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*");

            // Pass a Lambda expression as a callboack
            myClass.LongRunningMethod1(progress => 
            {
                if (progress % 100 == 0) // Print only multiples of 100
                    Console.WriteLine(progress);
            });

            Console.WriteLine("/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*");
            Console.WriteLine("/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*");

            // Using System Action
            myClass.LongRunningMethod2(printProgress);

            Console.WriteLine("/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*");

            // Lambda expressions are equivalent to a delegate, so this works exactly the same as before.
            myClass.LongRunningMethod2((progress) =>
            {
                if (progress % 100 == 0) // Print only multiples of 100
                    Console.WriteLine(progress);
            });

            Console.ReadLine();
        }

        private static void printProgress (int progress)
        {
            if (progress % 24 == 0) // Print only multiples of 24
                Console.WriteLine(progress);
        }

        
    }

    class MyClass
    {
        public delegate void Callback(int processedLines);
        public void LongRunningMethod1(Callback callback)
        {
            for (int i = 0; i < 1001; i++)
            {
                callback(i);
            }
        }

        // An alternative using the System's Action. 
        // An action is simply a delegate with no return type.
        public void LongRunningMethod2(Action<int> callback)
        {
            for (int i = 0; i < 1001; i++)
            {
                callback(i);
            }
        }

    }
}
