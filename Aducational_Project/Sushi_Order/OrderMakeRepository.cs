using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuSushi;
using Logs;

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
                    Console.WriteLine($"How much of {sushi.Name} whoud you like add to order? You can get a half of them." +
                        $"\nEnter the quantity of them (like #,#) & press 'ENTER'.\nPress 'ESCAPE' if you whoudn't get this kind of sushi.");

                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    try
                    {
                        amountOfSushi = Convert.ToSingle(Console.ReadLine());

                        if (amountOfSushi == 0)
                        {
                            Console.WriteLine("You added no sushi of this kind!");
                            return;
                        }
                        else if (amountOfSushi % 0.5f == 0)
                        {
                            break;
                        }
                        Console.WriteLine("Your can add only multiple of half this kind of sushi! Try agein.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Invalid data entered\nTry agein");

                        MyLog.Logs($"Entered invalid quantity of sushi!\n{ex.Message}\n{ex.StackTrace}");

                        continue;
                    }
                }
                while (true);

            }
            else
            {
                do
                {
                    Console.WriteLine($"How much of {sushi.Name} whoud you like add to order? You can't get a half of them." +
                        $"\nEnter the quantity of them & press 'ENTER'.\nPress 'ESCAPE' if you whoudn't get this kind of sushi.");

                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    try
                    {
                        amountOfSushi = Convert.ToSingle(Console.ReadLine());

                        if (amountOfSushi == 0)
                        {
                            Console.WriteLine("You added no sushi of this kind!");
                            return;
                        }

                        if (amountOfSushi % 1 == 0)
                        {
                            break;
                        }
                        Console.WriteLine("Your can add only whole this kind of sushi! Try agein.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Invalid data entered\nTry agein");

                        MyLog.Logs($"Entered invalid quantity of sushi!\n{ex.Message}\n{ex.StackTrace}");

                        continue;
                    }
                }
                while (true);
            }

            sushi.Things = Convert.ToInt32(sushi.Things * amountOfSushi);
            sushi.Cost = sushi.Cost * amountOfSushi;
            sushi.Weight = sushi.Weight * amountOfSushi;

            sushiOrder.Add(sushi);

            try
            {
                var tempSushi = sushiOrder.SingleOrDefault(item => item.Id == sushi.Id);
            }
            catch (Exception ex)
            {
                DeleteSushiFromOrder(sushi.Id);

                MyLog.Logs($"DeleteSushiFromOrder done!\n{ex.Message}\n{ex.StackTrace}");
            }
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
                Console.WriteLine("You have more than 1 order this kind of sushi in your order.\nWhill be deleted the first of them!");

                var sushi = sushiOrder.FirstOrDefault(item => item.Id == id);
                sushiOrder.Remove(sushi);
            }
        }

        public void GetSushisInOrder()
        {
            Console.WriteLine("Whoud you like to see your order?\nPress 'ENTER' if yes \nPress anything else if not.");
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
        }

        public void UpdateSushiInOrder(int id, SushiRepository sushis)
        {
            try
            {
                var sushi = sushiOrder.SingleOrDefault(item => item.Id == id);

                if (sushi == null)
                {
                    throw new NullReferenceException();
                }

                Sushi baseSushi = sushis.GetSushiById(sushi.Id);
                Sushi tempSushi = new Sushi(baseSushi.Name, baseSushi.Weight, baseSushi.Cost, baseSushi.Things, baseSushi.HalfOrFull);
                tempSushi.Id = sushi.Id;

                AddSushiInOrder(tempSushi);
            }
            catch (Exception ex)
            {
                Console.WriteLine("You don't have eny sushi whith this name in order!");

                MyLog.Logs($"Entered invalid sushi ID! Repiting going!\n{ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}
