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
        public OrderMakeRepository orderRepository = new OrderMakeRepository();

        public OrderMakeRepository MakeOrder(SushiRepository sushis)
        {
            Speak.Hello();
            Speak.OllSushi(sushis);

            do
            {
                do
                {
                    Console.WriteLine("Which sushi whoud you like to order?");

                    string nameSushiToOrder = Console.ReadLine();
                    Sushi sushi = sushis.GetSushiByName(nameSushiToOrder);
                    orderRepository.AddSushiInOrder(sushi);

                    orderRepository.GetSushisInOrder();
                    Console.WriteLine("The order price is {0: 0.00}", SumCounter(orderRepository));

                    Console.WriteLine("Enything else? (Yes / No)");
                    string no = Console.ReadLine();

                    if (string.Equals(no.ToUpper(), "no".ToUpper()))
                    {
                        break;
                    }
                }
                while (true);

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

        public Order OrderBuilder(OrderMakeRepository orderRepository)
        {
            Console.WriteLine("Enter your firstname.");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your phine number.");
            int phone = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your delivery address.");
            string address = Console.ReadLine();

            float sum = SumCounter(orderRepository);

            Order order = new Order(name, phone, address, orderRepository.sushiOrder, sum);

            return order;
        }

        public float SumCounter(OrderMakeRepository orderRepository)
        {
            float sum = 0.0f;

            
            foreach (var item in orderRepository.sushiOrder)
            {
                sum += item.Cost;
            }

            return sum;
        }
    }
}
