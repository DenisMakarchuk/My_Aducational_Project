using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_Order
{
    class SushiRepository : ISushiRepository
    {
        public static List<Sushi> sushis = new List<Sushi>();

        public void CreateSushi(Sushi sushi)
        {
            sushis.Add(sushi);
        }

        public void DeleteSushi(string name)
        {
            var existSushi = sushis.SingleOrDefault(item => item.Name == name);
            if (existSushi == null)
            {
                throw new NullReferenceException();
            }
            sushis.Remove(existSushi);
        }

        public void DeleteSushi(int id)
        {
            throw new NotImplementedException();
        }

        public Sushi GetSushiByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Sushi> GetSushis()
        {
            throw new NotImplementedException();
        }

        public List<Sushi> Sushis()
        {
            throw new NotImplementedException();
        }

        public Sushi UpdateSushi(Sushi moto)
        {
            throw new NotImplementedException();
        }
    }
}
