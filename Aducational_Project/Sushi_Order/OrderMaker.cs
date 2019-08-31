using System;
using SushiMenu;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_Order
{
    class OrderMaker
    {
        OrderRepository orderRepository = new OrderRepository();

        public OrderRepository MakeOrder(SushiRepository sushis)
        {
            Speak.Hello();
            Speak.OllSushi(sushis);

            do
            {
                Console.WriteLine("Which sushi whoud you like to order?");

                string nameSushiToOrder = Console.ReadLine();
                Sushi sushi = sushis.GetSushiByName(nameSushiToOrder);
                orderRepository.AddSushiInOrder(sushi);

                orderRepository.GetSushisInOrder();

                Console.WriteLine("Whoud you like to finish your order ? (Yes / No)");
                string yesNo = Console.ReadLine();

                if (string.Equals(yesNo.ToUpper(), "yes".ToUpper()))
                {
                    break;
                }
            }
            while (true);

            return orderRepository;
        }
    }
}
