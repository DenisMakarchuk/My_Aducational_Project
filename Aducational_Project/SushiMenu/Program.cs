using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            SushiRepository sushiRepository = new SushiRepository();

            sushiRepository = MenuMaker(sushiRepository);
        }

        static SushiRepository MenuMaker(SushiRepository sushiRepository)
        {
            Sushi phila = new Sushi("Philadelphia", 250.0f, 12.50f, 8, true);
            sushiRepository.CreateSushi(phila);

            Sushi califa = new Sushi("California", 210.0f, 9.80f, 8, true);
            sushiRepository.CreateSushi(califa);

            Sushi nigiriSiakie = new Sushi("Nigiri siakie", 80.0f, 5.0f, 2, false);
            sushiRepository.CreateSushi(nigiriSiakie);

            Sushi gunkanTekka = new Sushi("Gunkans tekka", 80.0f, 6.50f, 2, false);
            sushiRepository.CreateSushi(gunkanTekka);


            return sushiRepository;
        }
    }
}
