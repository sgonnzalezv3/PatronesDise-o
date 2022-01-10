using Herramientas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PatronesDiseno.Modelos.Data;
using PatronesDiseno.Repository;
using PatronesDiseñoASP.Configuration;
using PatronesDiseñoASP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PatronesDiseñoASP.Controllers
{
    public class HomeController : Controller
    {
        /* MyOptions para Inyectar */
        private readonly IOptions<MyConfig> _config;


        /* Inyectando el repository */
        private readonly IRepository<Beer> _repository;
        public HomeController(IOptions<MyConfig> config, IRepository<Beer> repository)
        {
            _config = config;
            _repository = repository;
        }

        public IActionResult Index()
        {
            Log.GetInstance(_config.Value.PathLog).Save("Entró a Index");

            IEnumerable<Beer> lst = _repository.Get();
            return View("Index" ,lst);
        }

        public IActionResult Privacy()
        {
            Log.GetInstance(_config.Value.PathLog).Save("Entró a Privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
