using BackendTask.Business.Services.BinaryCheck;
using System;

namespace BackendTask.BinaryCheck
{
    class Program
    {
        const string Message = "It {0} a good binary string";
        const string Good = "is";
        const string Bad = "is not";
        static void Main(string[] args)
        {

            while (true) // Loop indefinitely
            {
                Console.WriteLine("Please enter a binary string (press C to stop)");

                var input = Console.ReadLine();

                if (input.ToLower() == "c")
                {
                    break;
                }

                var result = new BinaryCheckService().Check(input);

                Console.WriteLine(Message, result ? Good : Bad);
                Console.WriteLine();
            }
        }
    }
}
