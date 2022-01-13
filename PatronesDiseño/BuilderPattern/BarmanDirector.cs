using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.BuilderPattern
{
    /* Define el orden de los pasos  */
    public class BarmanDirector
    {
        private IBuilder _builder;
        public BarmanDirector(IBuilder builder)
        {
            _builder = builder;
        }

        /* Capacidad de poder cambiar el builder */
        
        public void SetBuilder(IBuilder builder)
        {
            _builder = builder;
        }

        /* Encapsular el proceso de creacion */

        public void PrepareMargarita()
        {
            _builder.Reset();
            _builder.SetAlcohol(9);
            _builder.SetWater(30);
            _builder.AddIngredients("2 Limones");
            _builder.AddIngredients("Pizca sal");
            _builder.AddIngredients("tequila");
            _builder.AddIngredients("Hielo");
            _builder.AddIngredients("Frutiño de mora");

            _builder.Mix();
            _builder.Rest(1000);
        }
    }

}
