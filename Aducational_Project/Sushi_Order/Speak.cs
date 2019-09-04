using System;
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

        public static void SushiInfo(Sushi sushi)
        {
            if (sushi.HalfOrFull)
            {
                Console.WriteLine("{0}\t{1} g.\t{2: 0.00} BYN.\t{3} pieces\tYou can get a half.", sushi.Name, sushi.Weight, sushi.Cost, sushi.Things);
            }
            else
            {
                Console.WriteLine("{0}\t{1} g.\t{2: 0.00} BYN.\t{3} pieces\tYou can't get a half", sushi.Name, sushi.Weight, sushi.Cost, sushi.Things);
            }
            Console.WriteLine("Write, how many pieces of this sushi whoud you like + press 'Enter' or press 'Space' to make enothe choice.");
        }

        //public static void KindOfSushi()
        //{
        //    Console.WriteLine("What kind of sushi woud you like to order: rolls, nigiri, gunkans?");
        //}

        //public static void HowMuchSushi(string sushi)
        //{
        //    bool isTrue = true;

        //    switch (isTrue)
        //    {
        //        case true when sushi.Equals("notTheRolls"):
        //            Console.WriteLine("How much nigiri/gunkans woud you like?(You can get only whole)");
        //            break;
        //        case true when sushi.Equals("Rolls"):
        //            Console.WriteLine("How much rolls woud you like?(You can get whole and half)");
        //            break;
        //    }
        //}

        public static void AnythingElse()
        {
            Console.WriteLine("Woud you like anything else?(Yes/No)");
        }
    }
}
