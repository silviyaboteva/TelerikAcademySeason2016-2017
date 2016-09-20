using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5to7
{
    public class GenericListMain
    {
        static void Main()
        {
            var test = new GenericList<int>();

            for (int i = 0; i < 11; i++)
            {
                test.Add(i);
            }
            Console.WriteLine(test.ToString());

            test.Insert(4, 56);

            Console.WriteLine(test.ToString());

            Console.WriteLine(test.Max()); 
            Console.WriteLine(test.Min());
        }
    }
}
