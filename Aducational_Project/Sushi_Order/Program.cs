using System;
using MenuSushi;
using Logs;
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
            MyLog.directory.Create();

            MyLog.Logs("Started");

            try
            {
                SushiRepository sushiRepository = new SushiRepository();
                sushiRepository = Menu.MenuMaker(sushiRepository);
                MyLog.Logs("Menu.MenuMaker done!");

                OrdersRepo orders = new OrdersRepo();

                do
                {
                    MyLog.Logs("orders.AddOrder started!");
                    orders.AddOrder(MakeNewOrder(sushiRepository));
                    MyLog.Logs("orders.AddOrder finished!");

                    Console.WriteLine("Press 'ENTER' if you need add one more order or anything else if not");
                }
                while (Console.ReadKey(true).Key == ConsoleKey.Enter);
            }
            catch(Exception ex)
            {
                MyLog.Logs($"Something wrong!\n{ex.Message}\n{ex.StackTrace}");
            }

            MyLog.Logs("Order finished!");

            Console.Read();
        }

        static Order MakeNewOrder(SushiRepository sushiRepository)
        {
            OrderMaker newOrder = new OrderMaker();

            MyLog.Logs("newOrder.MakeOrder started!");

            newOrder.MakeOrder(sushiRepository);
            MyLog.Logs("newOrder.MakeOrder finished, newOrder.OrderBuilder started!");

            Order order = newOrder.OrderBuilder(newOrder.orderRepository);
            MyLog.Logs("newOrder.OrderBuilder finished!");

            newOrder.OrderIsMakedEvent += (string name) => {Console.WriteLine($"{name}, your order is maked!");};

            MyLog.Logs("newOrder.IsMaked started!");
            newOrder.IsMaked(order, 10);

            return order;
        }
    }
}
