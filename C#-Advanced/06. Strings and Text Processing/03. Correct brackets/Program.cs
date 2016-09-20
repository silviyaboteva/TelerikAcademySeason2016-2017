using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Correct_brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var brackets = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if(input[0] == ')')
                {
                    Console.WriteLine("Incorrect");
                    return;
                }
                if(input[i] == '(')
                {
                    brackets++;
                }
                else if(input[i] == ')')
                {
                    brackets--;
                }
            }

            if(brackets == 0)
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
            }
        }
    }
}
