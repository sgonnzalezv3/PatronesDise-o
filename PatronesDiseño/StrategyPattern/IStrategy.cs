using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.StrategyPattern
{
    public interface IStrategy
    {
        /* Strategy de vehiculos de transporte. un transporte tendra una manera de avanzar o caminar o correr */
        public void Run();
    }
}
