using System;
using SushiMenu;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            SushiRepository sushiRepository = new SushiRepository();

            sushiRepository = Menu.MenuMaker(sushiRepository);

            Speak.SushiInfo(sushiRepository.GetSushiByName("Philadelphia"));

            Console.Read();
        }
    }
}
