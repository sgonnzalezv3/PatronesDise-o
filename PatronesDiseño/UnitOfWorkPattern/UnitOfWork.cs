using PatronesDiseño.Models;
using PatronesDiseño.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.UnitOfWorkPattern
{
    /*
     
     Lo que estamos haciendo con Unit Of Work es 
    agrupar nuestros repositorios en una parte o grupo Unit Of Work, este va a trabajar como uno cuando se realicen solicitudes.
     */
    public class UnitOfWork : IUnitOfWork
    {
        /* Esta clase recibe el contexto con el que estamos trabajando, en este caso EF */

        private PatronesDisenoContext _context;

        /* Tenemos que guardar las propiedades creadas, mediante dos propiedades del mismo tipo. */
        public IRepository<Beer> _beers;
        public IRepository<Brand> _brand;


        /* podemos manejarlo de manera al singleton, si ha sido solciitado en un esquema de trabajo, si ya existe devuelvelo, sino crealo */
        /* Esto mejora la performance o rendimiento */
        public IRepository<Beer> Beers
        {
            get
            {
                return _beers == null ?
                    _beers = new Repository<Beer>(_context) : _beers;
            }
        }

        public IRepository<Brand> Brands
        {
            get
            {
                return _brand == null ?
                    _brand = new Repository<Brand>(_context) : _brand;
            }
        }




        public UnitOfWork(PatronesDisenoContext context)
        {
            _context = context;
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
