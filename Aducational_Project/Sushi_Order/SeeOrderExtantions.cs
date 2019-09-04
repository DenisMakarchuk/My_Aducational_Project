using System;
using System.Collections.Generic;
using MenuSushi;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logs;

namespace Sushi_Order
{
    public static class SeeOrderExtantions
    {
        public static void SeeTheSushiInTheOrderExtention(this List<Sushi> sushis)
        {
            float sum = 0;
            foreach (var item in sushis)
            {
                Console.WriteLine("{0}\t{1}\t{2} g.\t{3: 0.00} BYN.\t{4} pieces", item.Id, item.Name, item.Weight, item.Cost, item.Things);
                sum += item.Cost;
            }
            Console.WriteLine($"The total prise is: {sum}");
        }

    }
}
