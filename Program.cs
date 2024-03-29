using System;
using System.Runtime.InteropServices;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver();
            Console.WriteLine("Welcome to the Interactive program: ");
            driver.Run();
        }
    }
}