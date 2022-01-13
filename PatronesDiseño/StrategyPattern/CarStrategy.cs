using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.StrategyPattern
{
    /* ConcreteStrategy */
    public class CarStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Carro que se mueve con 4 llantas");
        }
    }
}
