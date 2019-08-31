﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SushiMenu;

namespace Sushi_Order
{
    class OrderRepository : IOrderRepository
    {
        public static List<Sushi> sushiOrder = new List<Sushi>();

        public void AddSushiInOrder(Sushi sushi)
        {
            sushiOrder.Add(sushi);
        }

        public void DeleteSushiFromOrder(string name)
        {
            try
            {
                var sushi = sushiOrder.SingleOrDefault(item => item.Name == name);
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

                var sushi = sushiOrder.FirstOrDefault(item => item.Name == name);
                sushiOrder.Remove(sushi);
            }
        }

        public void GetSushisInOrder()
        {
            Console.WriteLine("Whoud you like to see your order? (Yes/No)");
            string yesNo = Console.ReadLine();

            if (string.Equals(yesNo.ToUpper(), "yes".ToUpper()))
            {

                foreach (var item in sushiOrder)
                {
                    if (item.HalfOrFull)
                    {
                        Console.WriteLine("{0}\t{1} g.\t{2: 0.00} BYN.\t{3} pieces\tYou can get a half.", item.Name, item.Weight, item.Cost, item.Things);
                    }
                    else
                    {
                        Console.WriteLine("{0}\t{1} g.\t{2: 0.00} BYN.\t{3} pieces\tYou can't get a half", item.Name, item.Weight, item.Cost, item.Things);
                    }
                }
            }
            else
            {
                return;
            }
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
