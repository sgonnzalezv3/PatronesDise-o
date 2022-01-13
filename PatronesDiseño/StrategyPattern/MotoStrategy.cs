using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.StrategyPattern
{
    /* ConcreteStrategyA1 */
    public class MotoStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Soy una moto que anda a 2 ruedas");
        }
    }
}
