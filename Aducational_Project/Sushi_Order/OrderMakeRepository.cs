using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SushiMenu;

namespace Sushi_Order
{
    class OrderMakeRepository : IOrderMakeRepository
    {
        public  List<Sushi> sushiOrder = new List<Sushi>();

        public void AddSushiInOrder(Sushi sushi)
        {
            float amountOfSushi = 0.0f;

            if (sushi.HalfOrFull)
            {
                do
                {
                    Console.WriteLine($"How much of {sushi.Name} whoud you like add to order? You can get a helf of them.\nEnter the quantity of them & press 'enter'.");
                    amountOfSushi = Convert.ToSingle(Console.ReadLine());

                    if (amountOfSushi == 0)
                    {
                        Console.WriteLine("You added no sushi of this kind!");
                        return;
                    }

                    if (amountOfSushi % 0.5f == 0)
                    {
                        break;
                    }
                    Console.WriteLine("Your can add only multiple of half this kind of sushi! Try agein.");
                }
                while (true);

            }
            else
            {
                do
                {
                    Console.WriteLine($"How much of {sushi.Name} whoud you like add to order? You can't get a helf of them.\nEnter the quantity of them & press 'enter'.");
                    amountOfSushi = Convert.ToSingle(Console.ReadLine());

                    if (amountOfSushi == 0)
                    {
                        Console.WriteLine("You added no sushi of this kind!");
                        return;
                    }

                    if (amountOfSushi%1 == 0)
                    {
                        break;
                    }
                    Console.WriteLine("Your can add only whole this kind of sushi! Try agein.");
                }
                while (true);
            }

            sushi.Things = Convert.ToInt32(sushi.Things * amountOfSushi);
            sushi.Cost = sushi.Cost * amountOfSushi;

            sushiOrder.Add(sushi);
        }

        public void DeleteSushiFromOrder(int id)
        {
            try
            {
                var sushi = sushiOrder.SingleOrDefault(item => item.Id == id);
                if (sushi == null)
                {
                    throw new NullReferenceException();
                }
                sushiOrder.Remove(sushi);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("You don't have eny sushi whith this name in order!");
            }
            catch (Exception)
            {
                Console.WriteLine("You have more than 1 order this kind of sushi in your order.\nWhill delite the first of them!");

                var sushi = sushiOrder.FirstOrDefault(item => item.Id == id);
                sushiOrder.Remove(sushi);
            }
        }

        public void GetSushisInOrder()
        {
            Console.WriteLine("Whoud you like to see your order?\nPress 'enter' if yes or something else if not.");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Enter:
                    foreach (var item in sushiOrder)
                    {
                        Console.WriteLine("{0}\t{1}\t{2} g.\t{3: 0.00} BYN.\t{4} pieces", item.Id, item.Name, item.Weight, item.Cost, item.Things);
                    }
                    break;
                default:
                    return;
            }
            //if (string.Equals(yesNo.ToUpper(), "yes".ToUpper()))
            //{

            //    foreach (var item in sushiOrder)
            //    {
            //        Console.WriteLine("{0}\t{1} g.\t{2: 0.00} BYN.\t{3} pieces.", item.Name, item.Weight, item.Cost, item.Things);
            //    }
            //}
            //else
            //{
            //    return;
            //}
        }

        public void UpdateSushiInOrder(Sushi sushi)
        {
            try
            {
                var exiStsushi = sushiOrder.SingleOrDefault(item => item.Name == sushi.Name);

                if (exiStsushi == null)
                {
                    throw new NullReferenceException();
                }

                exiStsushi.Things = sushi.Things;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("You don't have eny sushi whith this name in order!");
            }
            catch (Exception)
            {
                Console.WriteLine("You have more than 1 order this kind of sushi in your order.\nPlease, delite the one of them!");
            }
        }
    }
}
