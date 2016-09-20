using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            TryGetSquareRoot(number);
        }

        private static void TryGetSquareRoot(string n)
        {
            try
            {
                double number = double.Parse(n);
                if (number < 0)
                {
                    throw new FormatException("Integer must be positive");
                }
                double squareNumber = Math.Sqrt(number);
                Console.WriteLine("{0:F3}", Math.Round(squareNumber,3));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
