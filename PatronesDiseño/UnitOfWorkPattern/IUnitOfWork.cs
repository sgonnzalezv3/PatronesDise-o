using PatronesDiseño.Models;
using PatronesDiseño.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.UnitOfWorkPattern
{
    /* por cada tabla que va a manejar tu sistema, por cada interaccion de tu sistema o dominio, tendremos que hacer una propiedad de tipo repository. */
    /*  */
    public interface IUnitOfWork
    {
        public IRepository<Beer> Beers { get; }
        public IRepository<Brand> Brands { get; }

        /* Mandar todo lo que se ha realizado a trabajar! */
        public void Save();

    }
}
