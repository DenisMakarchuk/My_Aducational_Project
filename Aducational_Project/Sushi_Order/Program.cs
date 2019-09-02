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

            OrderMaker newOrder = new OrderMaker();
            newOrder.MakeOrder(sushiRepository);
            //newOrder.OrderBuilder(newOrder.orderRepository);



            Console.Read();
        }
    }
}
