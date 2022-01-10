using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.DependencyInjection
{
    public class DrinkWithBeer
    {
        /* Esto está mal!! no se deben crear otros objetos en esta clase*/
        //private Beer _beer = new Beer("Poker", "Bavaria");
        private Beer _beer;
        
        public decimal _water;
        public decimal _sugar;

        public DrinkWithBeer(decimal water, decimal sugar, Beer beer)
        {
            _water = water;
            _sugar = sugar;
            _beer = beer;
        }

        public void Build()
        {
            Console.WriteLine($"Preparamos bebida que tiene agua {_water} " + $"azúcar {_sugar} y cerveza {_beer.Name}");
        }
    }
}
