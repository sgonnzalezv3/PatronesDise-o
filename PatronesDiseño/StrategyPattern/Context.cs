using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.StrategyPattern
{
    /* Es la que va a tener la estrategia */
    public class Context
    {
        private IStrategy _strategy;

        /* asignarlo en el ctor */

        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        /* proiedad para cambiar el comportamiento */
        /* esto nos va a dar el poder de que podamos cambiar el comportamiento de run en tiempo de ejecucion
         * 
         * quiero que te comportes como carro- o como moto etc...
         * */
        public IStrategy Strategy
        {
            set
            {
                _strategy = value;
            }
        }



        /* Metodo de arrancar */
        public void Run()
        {
            _strategy.Run();
        }
    }
}
