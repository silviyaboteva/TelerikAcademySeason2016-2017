using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.String_length
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            input = input.Replace(@"\", string.Empty);
            if (input.Length == 20)
            {
                Console.WriteLine(input);
            }
            else
            {
                for (int i = input.Length; i < 20; i++)
                {
                    input += '*';
                }
                Console.WriteLine(input);
            }
        }
    }
}
