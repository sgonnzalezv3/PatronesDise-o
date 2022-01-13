using PatronesDiseno.Repository;
using PatronesDiseñoASP.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatronesDiseñoASP.Strategies
{
    public interface IBeerStrategy
    {
        /*  IStrategy*/
        public void Add(FormBeerViewModel beerVm, IUnitOfWork unitOfWork);
    }
}
