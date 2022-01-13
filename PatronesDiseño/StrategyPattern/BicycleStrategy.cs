using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.StrategyPattern
{
    public class BicycleStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Cicla  que se pedalea con 2 llantas");
        }
    }
}
