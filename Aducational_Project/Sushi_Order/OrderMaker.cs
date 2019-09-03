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
                    try
                    {
                        AddSushiOrNothing(sushis);
                    }
                    catch
                    {
                        Console.WriteLine("You must enter the ID number of kind of sushi");
                        continue;
                    }


                    orderRepository.GetSushisInOrder();
                    Console.WriteLine("The order price is {0: 0.00}", SumCounter(orderRepository));

                    if (AnythingElse(sushis))
                    {
                        continue;
                    }

                    break;
                }
                while (true);

                Console.WriteLine("Whoud you like to finish your order ?\nPress 'ENTER' if yes or anything else if not");

                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    orderRepository.GetSushisInOrder();
                    Console.WriteLine("The order price is {0: 0.00}", SumCounter(orderRepository));
                    break;
                }
            }
            while (true);

            return orderRepository;
        }

        public Order OrderBuilder(OrderMakeRepository orderRepository)
        {
            string name = string.Empty, address = string.Empty;
            int phone = 0;

            do
            {
                try
                {
                    Console.WriteLine("Enter your firstname.");
                    name = Console.ReadLine();
                }
                catch /*(Exception ex)*/
                {
                    Console.WriteLine("Incorrect data entry \nTry agein.");
                    continue;
                }
                break;
            }
            while (true);

            do
            {
                try
                {
                    Console.WriteLine("Enter your phine number.");
                    phone = Convert.ToInt32(Console.ReadLine());
                }
                catch /*(Exception ex)*/
                {
                    Console.WriteLine("Incorrect data entry \nTry agein.");
                    continue;
                }
                break;
            }
            while (true);

            do
            {
                try
                {
                    Console.WriteLine("Enter your delivery address.");
                    address = Console.ReadLine();
                }
                catch /*(Exception ex)*/
                {
                    Console.WriteLine("Incorrect data entry \nTry agein.");
                    continue;
                }
                break;
            }
            while (true);

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

        public void AddSushiOrNothing(SushiRepository sushis)
        {
            Console.WriteLine("Which sushi whoud you like to order?" +
                "\nEnter the ID number + press 'ENTER' to add sushi \nPress 'ESCAPE' if you whoudn't add anything.");

            if (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                int idSushiToOrder = Convert.ToInt32(Console.ReadLine());

                Sushi sushi = sushis.GetSushiById(idSushiToOrder);
                Sushi tempSushi = new Sushi(sushi.Name, sushi.Weight, sushi.Cost, sushi.Things, sushi.HalfOrFull);
                tempSushi.Id = idSushiToOrder;

                orderRepository.AddSushiInOrder(tempSushi);
            }
        }

        public bool AnythingElse(SushiRepository sushis)
        {
            Console.WriteLine("Enything else?\nPress 'ESCAPE' if not\nPress 'DELETE' if you want to delete sushi from your order" +
                "\nPress 'SPACE' to change amount of sushi in the order\nPress anything else if you whoud like add more sushi to the order.");

            if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
            {
                try
                {
                    Console.WriteLine("Enter the ID number of sushi which you whoud like to change + press 'ENTER'.");
                    int id = Convert.ToInt32(Console.ReadLine());

                    orderRepository.UpdateSushiInOrder(id, sushis);
                    orderRepository.GetSushisInOrder();
                    Console.WriteLine("The order price is {0: 0.00}", SumCounter(orderRepository));

                    return false;
                }
                catch /*(Exception ex)*/
                {
                    Console.WriteLine("Incorrect data entry \nYou must enter the ID number of kind of sushi");
                    return false;
                }
            }
            else if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return false;
            }
            else if (Console.ReadKey(true).Key == ConsoleKey.Delete)
            {
                try
                {
                    Console.WriteLine("Enter the ID number of sushi which you whoud like to delete + press 'ENTER'.");
                    int id = Convert.ToInt32(Console.ReadLine());

                    orderRepository.DeleteSushiFromOrder(id);
                    orderRepository.GetSushisInOrder();
                    Console.WriteLine("The order price is {0: 0.00}", SumCounter(orderRepository));
                }
                catch /*(Exception ex)*/
                {
                    Console.WriteLine("Incorrect data entry \nYou must enter the ID number of kind of sushi");
                    return false;
                }
            }

            return true;
        }
    }
}
