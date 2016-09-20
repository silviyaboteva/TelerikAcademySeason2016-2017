using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _10.Unicode_characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(GetUnicodeRepresentation(input));
        }

        private static string GetUnicodeRepresentation(string input)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in input)
            {
                result.Append("\\u" + ((int)c).ToString("X").PadLeft(4, '0'));
            }

            return result.ToString();
        }
    }
}
