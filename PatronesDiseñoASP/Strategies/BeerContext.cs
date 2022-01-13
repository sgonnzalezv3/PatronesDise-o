using PatronesDiseno.Repository;
using PatronesDiseñoASP.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatronesDiseñoASP.Strategies
{
    public class BeerContext
    {
        private IBeerStrategy _strategy;
        public BeerContext(IBeerStrategy strategy)
        {
            _strategy = strategy;
        }

        public IBeerStrategy Strategy
        {
            set
            {
                _strategy = value;
            }
        }

        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork)
        {
            _strategy.Add(beerVM, unitOfWork);
        }
    }
}
