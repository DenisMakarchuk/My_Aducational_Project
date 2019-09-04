using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logs;

namespace MenuSushi
{
    public class SushiRepository : ISushiRepository
    {
        public static List<Sushi> sushis = new List<Sushi>();
        private static int _idCounter = 1;

        public void CreateSushi(Sushi sushi)
        {
            sushi.Id = _idCounter;
            _idCounter++;

            sushis.Add(sushi);
        }

        public void DeleteSushi(int id)
        {
            try
            {
                var sushi = sushis.SingleOrDefault(item => item.Id == id);
                if (sushi == null)
                {
                    throw new NullReferenceException();
                }
                sushis.Remove(sushi);
            }
            catch (NullReferenceException ex)
            {
                MyLog.Logs($"Something wrong!\n{ex.Message}\n{ex.StackTrace}");
            }
            catch (Exception ex)
            {
                MyLog.Logs($"Something wrong!\n{ex.Message}\n{ex.StackTrace}");
            }
        }

        public Sushi GetSushiById(int id)
        {
            try
            {
                Sushi sushi = sushis.SingleOrDefault(item => item.Id == id);
                if (sushi == null)
                {
                    Console.WriteLine("Sorry, no product information was found. Select another product.");
                }
                return sushi == null ? null : (Sushi)sushi;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, something happened. Select another product.");

                MyLog.Logs($"Something wrong!\n{ex.Message}\n{ex.StackTrace}");

                return null;
            }
        }

        public void GetSushis()
        {
            foreach (var item in sushis)
            {
                if (item.HalfOrFull)
                {
                    Console.WriteLine("{0}\t{1}\t{2} g.\t{3: 0.00} BYN.\t{4} pieces\tYou can get a half.", item.Id, item.Name, item.Weight, item.Cost, item.Things);
                }
                else
                {
                    Console.WriteLine("{0}\t{1}\t{2} g.\t{3: 0.00} BYN.\t{4} pieces\tYou can't get a half", item.Id, item.Name, item.Weight, item.Cost, item.Things);
                }
            }
        }

        public void UpdateSushi(Sushi sushi)
        {
            try
            {
                var exiStsushi = sushis.SingleOrDefault(item => item.Id == sushi.Id);

                if (exiStsushi == null)
                {
                    throw new NullReferenceException();
                }

                exiStsushi.Name = sushi.Name;
                exiStsushi.HalfOrFull = sushi.HalfOrFull;
                exiStsushi.Things = sushi.Things;
                exiStsushi.Weight = sushi.Weight;
                exiStsushi.Cost = sushi.Cost;
            }
            catch (NullReferenceException ex)
            {
                MyLog.Logs($"Something wrong!\n{ex.Message}\n{ex.StackTrace}");
            }
            catch (Exception ex)
            {
                MyLog.Logs($"Something wrong!\n{ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}
