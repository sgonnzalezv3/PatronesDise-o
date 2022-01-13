using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PatronesDiseno.Modelos.Data;
using PatronesDiseno.Repository;
using PatronesDiseñoASP.Models.ViewModels;
using PatronesDiseñoASP.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatronesDiseñoASP.Controllers
{
    public class BeerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BeerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<BeerViewModel> beers = from d in _unitOfWork.Beers.Get()
                                               select new BeerViewModel
                                               {
                                                   Id = d.BeerId,
                                                   Name = d.Name,
                                                   Style = d.Style
                                               };
            return View("Index",beers);
        }


        [HttpGet]
        public IActionResult Add()
        {
            GetBrandsData();
            
            return View();
        }


        [HttpPost]

        public IActionResult Add(FormBeerViewModel beerVM)
        {
            /* Validar Data Anottations */
            if (!ModelState.IsValid)
            {
                /* Esto es para que no se limpie el form sino que se mantenga la data que se ingresó */
                GetBrandsData();
                return View("Add", beerVM);
            }
            /*
             * Comentado por refactoring con lo de abajo
             * 
            var beer = new Beer();

            beer.Name = beerVM.Name;
            beer.Style = beerVM.Style;
            
            // identificar si viene seleccionado una marca o no, en caso de que no, vamos a tomar el campo otra marca, y crearemos ese dato en la
            //  bd 
             
            if(beerVM.BrandId == null)
            {
                var brand = new Brand();
                brand.Name = beerVM.OtherBrand;
                brand.BrandId = Guid.NewGuid();
                beer.BrandId = brand.BrandId;
                _unitOfWork.Brands.Add(brand);
            }
            else
            {
                beer.BrandId = (Guid)beerVM.BrandId;
            }
            _unitOfWork.Beers.Add(beer);
            _unitOfWork.Save();
            */

            /* Validamos si el BrandId es nulo, queriendo decir que se no se selecciono marca existente, es decir que tambien se crea brand (new BeerWithBrandStrategy)
             *  de lo contrario, brand se seleccionó y se toma el camino de BeerStrategy
             */
            var context = beerVM.BrandId == null ? new BeerContext(new BeerWithBrandStrategy()) : new BeerContext(new BeerStrategy());
            
            /* agregamos mandandole el context y el unitOfWork */
            context.Add(beerVM, _unitOfWork);

            /* si todo es exitoso, valla al index. */
            return RedirectToAction("Index");
        }

        #region HELPERS
        private void GetBrandsData()
        {
            var brands = _unitOfWork.Brands.Get();
            ViewBag.Brands = new SelectList(brands, "BrandId", "Name");
        }
        #endregion
    }
}
