using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PatronesDiseño.BuilderPattern
{
    public class PreparedAcoholicDrinkConcreteBuilder : IBuilder
    {
        /* Vamos a trabajar con un producto. */
        private PreparedDrink _preparedDrink;

        public PreparedAcoholicDrinkConcreteBuilder()
        {
            /* inicializar el objeto */
            Reset();
        }
        public void AddIngredients(string ingredients)
        {
            if (_preparedDrink.Ingredients == null)
                _preparedDrink.Ingredients = new List<string>();
            _preparedDrink.Ingredients.Add(ingredients);
        }

        public void Mix()
        {
            string ingredients = _preparedDrink.Ingredients.Aggregate((i, j) => i +", " + j);
            _preparedDrink.Result = $"Bebida preparada con {_preparedDrink.Alcohol} de alcohol" + 
                $" con los siguientes ignredientes: {ingredients}";

            Console.WriteLine("Se han mezclado ingredientes");

        }

        public void Reset()
        {
            _preparedDrink = new PreparedDrink();
        }

        public void Rest(int time)
        {
            Thread.Sleep(time);
            Console.WriteLine("Breve pa' beber");
        }

        public void SetAlcohol(decimal alcohol)
        {
            _preparedDrink.Alcohol = alcohol;
        }

        public void SetMilk(int milk)
        {
            _preparedDrink.Milk = milk;
        }

        public void SetWater(int water)
        {
            _preparedDrink.Water = water;
        }

        public PreparedDrink GetPreparedDrink() => _preparedDrink;
    }
}
