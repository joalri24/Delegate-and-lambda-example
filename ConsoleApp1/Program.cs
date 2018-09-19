using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();

            // Pass a regular method as a callback
            myClass.LongRunningMethod(printProgress);

            Console.WriteLine("/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*");

            // Pass a Lambda expression as a callboack
            myClass.LongRunningMethod(progress => 
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
        public void LongRunningMethod(Callback callback)
        {
            for (int i = 0; i < 1001; i++)
            {
                callback(i);
            }
        }

    }
}
