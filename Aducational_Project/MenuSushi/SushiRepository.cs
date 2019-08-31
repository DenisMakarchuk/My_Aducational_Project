using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiMenu
{
    public class SushiRepository : ISushiRepository
    {
        public static List<Sushi> sushis = new List<Sushi>();

        public void CreateSushi(Sushi sushi)
        {
            sushis.Add(sushi);
        }

        public void DeleteSushi(string name)
        {
            try
            {
            var sushi = sushis.SingleOrDefault(item => item.Name == name);
            if (sushi == null)
            {
                throw new NullReferenceException();
            }
            sushis.Remove(sushi);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Sushi GetSushiByName(string name)
        {
            try
            {
                Sushi sushi = sushis.SingleOrDefault(item => item.Name == name);
                if (sushi == null)
                {
                    Console.WriteLine("Sorry, no product information was found. Select another product.");
                }
                return sushi == null ? null : (Sushi)sushi;
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry, something happened. Select another product.");
                return null;
            }
        }

        public List<Sushi> GetSushis()
        {
            return sushis.Select(item => (Sushi)item).ToList();
        }

        public void UpdateSushi(Sushi sushi)
        {
            try
            {
                var exiStsushi = sushis.SingleOrDefault(item => item.Name == sushi.Name);

                if (exiStsushi == null)
                {
                    throw new NullReferenceException();
                }

                exiStsushi.HalfOrFull = sushi.HalfOrFull;
                exiStsushi.Things = sushi.Things;
                exiStsushi.Weight = sushi.Weight;
                exiStsushi.Cost = sushi.Cost;
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
