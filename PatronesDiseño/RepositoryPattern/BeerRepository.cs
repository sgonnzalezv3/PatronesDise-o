using Microsoft.EntityFrameworkCore;
using PatronesDiseño.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.RepositoryPattern
{
    public class BeerRepository : IBeerRepository
    {
        private readonly PatronesDisenoContext _context;
        public BeerRepository(PatronesDisenoContext context)
        {
            _context = context;
        }
        public void Add(Beer beer) => _context.Add(beer);

        public void Delete(int id)
        {
            var beer = _context.Beers.Find(id);
            _context.Remove(beer);
        }

        public List<Beer> Get() => _context.Beers.ToList();

        public Beer Get(int id) =>  _context.Beers.Find(id);

        public void Update(Beer beer)
        {
            _context.Entry(beer).State = EntityState.Modified;
        }

        public void Save() => _context.SaveChanges();
    }
}
