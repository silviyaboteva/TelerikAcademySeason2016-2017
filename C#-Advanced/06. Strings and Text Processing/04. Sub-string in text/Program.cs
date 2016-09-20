using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Sub_string_in_text
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine().ToLower();
            string text = Console.ReadLine().ToLower();
            int counter = 0;

            for (int i = 0; i < text.Length - pattern.Length + 1; i++)
            {
                string currentSubString = text.Substring(i, pattern.Length);
                if (currentSubString.Equals(pattern))
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);

        }
    }
}
