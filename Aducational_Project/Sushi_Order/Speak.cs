﻿using System;
using MenuSushi;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logs;

namespace Sushi_Order
{
    class Speak
    {
        public static void Hello()
        {
            int time = DateTime.Now.Hour;
            bool isTrueTime = true;

            switch (isTrueTime)
            {
                case true when time >= 6 && time < 12:
                    Console.WriteLine("Good morning!");
                    break;
                case true when time >= 12 && time < 18:
                    Console.WriteLine("Good day!");
                    break;
                case true when time >= 18 && time < 24:
                    Console.WriteLine("Good evening!");
                    break;
                default:
                    Console.WriteLine("Good night!");
                    break;
            }
        }

        public static void OllSushi(SushiRepository sushis)
        {
            Console.WriteLine($"Here is our menu:");
            sushis.GetSushis();
        }
    }
}
