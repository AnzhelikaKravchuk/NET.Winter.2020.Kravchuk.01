using StringManipulation;
using static System.Console;

namespace ConsoleUI
{
     class Program
    {
        public static void Main(string[] args)
        {
            Write("Enter user name:");
            string userName = ReadLine();
            Clear();
            WriteLine(Greeting.SayHello(userName));
            ReadKey();
        }
    }
}