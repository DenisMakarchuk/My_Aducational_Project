using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSushi
{
    public class Sushi : IMenu
    {
        public int Id { get; set; }
        public string Name { get ; set ; }
        public float Weight { get ; set ; }
        public float Cost { get ; set ; }
        public int Things { get ; set ; }
        public bool HalfOrFull { get ; set ; }

        public Sushi(string name, float weight, float cost, int things, bool halfOrFull)
        {
            Name = name;
            Weight = weight;
            Cost = cost;
            Things = things;
            HalfOrFull = halfOrFull;
        }
    }
}
