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
                    Console.WriteLine("Which sushi whoud you like to order?\nEnter the ID number of kind of sushi & press 'enter' to add sushi or 'escape' if you whoudn't add something.");

                    if (Console.ReadKey(true).Key != ConsoleKey.Escape)
                    {
                        try
                        {
                            int idSushiToOrder = Convert.ToInt32(Console.ReadLine());
                        
                        Sushi sushi = sushis.GetSushiById(idSushiToOrder);
                        orderRepository.AddSushiInOrder(sushi);
                        }
                        catch
                        {
                            Console.WriteLine("You must enter the ID number of kind of sushi");
                        }
                    }

                    orderRepository.GetSushisInOrder();
                    Console.WriteLine("The order price is {0: 0.00}", SumCounter(orderRepository));

                    Console.WriteLine("Enything else?\nPress 'escape' if not, 'delete' if you want to delete sushi from your order or something else if yes.");

                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    else if (Console.ReadKey(true).Key == ConsoleKey.Delete)
                    {
                        Console.WriteLine("Enter the ID number of sushi which you whoud like to delete.");
                        int id = Convert.ToInt32(Console.ReadLine());

                        orderRepository.DeleteSushiFromOrder(id);
                        orderRepository.GetSushisInOrder();
                    }
                }
                while (true);

                Console.WriteLine("Whoud you like to finish your order ?\nPress 'enter' if yes or something else if not");

                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
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
