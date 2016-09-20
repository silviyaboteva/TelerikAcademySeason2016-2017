﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Parse_URL
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = Console.ReadLine();

            int indexOfDualDots = url.IndexOf(":");
            string protocol = url.Substring(0, indexOfDualDots);

            string server = string.Empty;

            int index = protocol.Length + 3;
            for (int i = index; ; i++)
            {
                char curentChar = url[i];
                if (curentChar == '/')
                {
                    index = i;
                    break;
                }
                else
                {
                    server += curentChar;
                }
            }

            string resource = url.Substring(index);
            Console.WriteLine("[protocol] = {0}", protocol);
            Console.WriteLine("[server] = {0}", server);
            Console.WriteLine("[resource] = {0}", resource);
        }
    }
}
