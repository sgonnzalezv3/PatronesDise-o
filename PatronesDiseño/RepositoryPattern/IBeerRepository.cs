using PatronesDiseño.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.RepositoryPattern
{
    public interface IBeerRepository
    {
        List<Beer> Get();
        Beer Get(int id);
        void Add(Beer beer);
        void Delete(int id);
        void Update(Beer beer);

        /* Metodo que realiza el guardado, no se sabe si va a ser con EF, dapper o por api */
        void Save();
    }
}
