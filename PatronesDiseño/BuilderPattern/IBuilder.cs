using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.BuilderPattern
{
    public interface IBuilder
    {
        // reiniciar o volver a dejar la creacion del objeto en blanco
        public void Reset();

        public void SetAlcohol(decimal alcohol);
        public void SetWater(int water);
        public void SetMilk(int milk);
        public void AddIngredients(string ingredients);

        public void Mix();

        public void Rest(int time);
    }
}
