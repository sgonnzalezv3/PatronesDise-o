using PatronesDiseno.Modelos.Data;
using PatronesDiseno.Repository;
using PatronesDiseñoASP.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatronesDiseñoASP.Strategies
{
    public class BeerStrategy : IBeerStrategy
    {
        public void Add(FormBeerViewModel beerVm, IUnitOfWork unitOfWork)
        {
            /* Estrategia para cuando la cerveza tenga una marca ya existente */
            var beer = new Beer();
            beer.Name = beerVm.Name;
            beer.Style = beerVm.Style;
            beer.BrandId = (Guid)beerVm.BrandId;

            unitOfWork.Beers.Add(beer);
            unitOfWork.Save();

        }
    }
}
