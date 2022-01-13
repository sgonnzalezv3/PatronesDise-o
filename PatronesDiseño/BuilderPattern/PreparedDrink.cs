using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.BuilderPattern
{
    public class PreparedDrink
    {
        public List<string> Ingredients = new List<string>();
        public int Milk;
        public int Water;
        public decimal Alcohol;


        /* Contexto: tenemos un constructor complejo
         * 
         y quiero contemplar todas las distintas configuraciones:
         puede que esta clase valla adquiriendo mas parametros y por ende el 
        constructor se valla haciendo mas grande.

        tonces builder nos colabora, tenemos que borrar el constructor  de aqui:
         */
                /*
                public PreparedDrink(List<string> ingredients,
                    int milk,
                    int water,
                    decimal alcohol
                    )
                {
                    Ingredients = ingredients;
                    Milk = milk;
                    Water = water;
                    Alcohol = alcohol;
                }
                */

        public string Result;


    }
}
