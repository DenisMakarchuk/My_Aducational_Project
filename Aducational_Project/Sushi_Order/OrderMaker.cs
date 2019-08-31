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
                string nameSushiToOrder = Console.ReadLine();
                Sushi sushi = sushis.GetSushiByName(nameSushiToOrder);
                orderRepository.AddSushiInOrder(sushi);

                Console.WriteLine("Whoud you like to see your order? (Yes/No)");
                string yesNo = Console.ReadLine();

                if (string.Equals(yesNo.ToUpper(), "yes".ToUpper()))
                {
                    ShowTheOrder();
                }

                Console.WriteLine("Whoud you like to finish your order ? (Yes / No)");
                yesNo = Console.ReadLine();

                if (string.Equals(yesNo.ToUpper(), "yes".ToUpper()))
                {
                    break;
                }

            }
            while (true);

            return orderRepository;
        }

        public void ShowTheOrder()
        {
            orderRepository.GetSushisInOrder();
        }
    }
}
