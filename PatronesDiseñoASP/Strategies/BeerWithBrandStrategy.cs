using PatronesDiseno.Modelos.Data;
using PatronesDiseno.Repository;
using PatronesDiseñoASP.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatronesDiseñoASP.Strategies
{
    public class BeerWithBrandStrategy : IBeerStrategy
    {
        /* Proceso para la creacion de una cerveza cuando la marca no existe  */
        public void Add(FormBeerViewModel beerVm, IUnitOfWork unitOfWork)
        {
            var beer = new Beer();
            beer.Style = beerVm.Style;
            beer.Name = beerVm.Name;
            /* Aahora se crea una marca  */
            var brand = new Brand();
            brand.Name = beerVm.OtherBrand;
            brand.BrandId = Guid.NewGuid();
            beer.BrandId = brand.BrandId;

            unitOfWork.Brands.Add(brand);
            unitOfWork.Beers.Add(beer);

            unitOfWork.Save();
        }
    }
}
