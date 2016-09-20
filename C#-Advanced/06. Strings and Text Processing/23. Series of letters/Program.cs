using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23.Series_of_letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(RemoveConsecativeEqualCharacters(input));
        }

        private static string RemoveConsecativeEqualCharacters(string input)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i < input.Length; i++)
            {
                if (i + 1 < input.Length && input[i - 1] == input[i])
                {
                    continue;
                }

                result.Append(input[i - 1]);
                if (i + 1 != input.Length || input[i - 1] == input[i])
                {
                    continue;
                }

                result.Append(input[i]);
                break;
            }

            return result.ToString();
        }
    }
}
