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

            OrdersRepo orders = new OrdersRepo();

            do
            {
                orders.AddOrder(MakeNewOrder(sushiRepository));
                Console.WriteLine("Press 'ENTER' if you need add one more order or anything else if not");
            }
            while (Console.ReadKey(true).Key == ConsoleKey.Enter);

            Console.Read();
        }

        static Order MakeNewOrder(SushiRepository sushiRepository)
        {
            OrderMaker newOrder = new OrderMaker();
            newOrder.MakeOrder(sushiRepository);

            Order order = newOrder.OrderBuilder(newOrder.orderRepository);

            newOrder.OrderIsMakedEvent += (string name) => {Console.WriteLine($"{name}, your order is maked!");};
            newOrder.IsMaked(order);

            return order;
        }
    }
}
