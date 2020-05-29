using System;

namespace Chapter2.PartTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How can I help?");
            bool terminate = false;
            do
            {
                var input = Console.ReadLine();
                terminate = string.IsNullOrEmpty(input);
                if (!terminate)
                {
                    Console.WriteLine(RegularExpressions.RunTransformations(input));
                }
            }
            while (!terminate);

        }
    }
}
