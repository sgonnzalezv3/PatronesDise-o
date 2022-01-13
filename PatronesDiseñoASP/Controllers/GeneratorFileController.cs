using Herramientas.Generator;
using Microsoft.AspNetCore.Mvc;
using PatronesDiseno.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatronesDiseñoASP.Controllers
{
    public class GeneratorFileController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private GeneratorConcreteBuilder _generatorConcreteBuilder;

        public GeneratorFileController(IUnitOfWork unitOfWork, GeneratorConcreteBuilder generatorConcreteBuilder)
        {
            _unitOfWork = unitOfWork;
            _generatorConcreteBuilder = generatorConcreteBuilder;
        }
        public IActionResult Index()
        {
            return View();
        }

        /* metodo para invocar funcinalidad builder */

        public IActionResult CreateFile(int optionFile)
        {
            try
            {
                var beers = _unitOfWork.Beers.Get();
                List<string> content = beers.Select(x => x.Name).ToList();
                string pth = "file" + DateTime.Now.Ticks + new Random().Next(1000) + ".txt";
                var generatorDirector = new GeneratorDirector(_generatorConcreteBuilder);
                if (optionFile == 1)
                    generatorDirector.CreateSimpleJsonGenerator(content, pth);
                else
                    generatorDirector.CreateSimplePipeGenerator(content, pth);
                var generator = _generatorConcreteBuilder.GetGenerator();
                generator.Save();
                return Json("Archivo generado");
            }
            catch (Exception e)
            {

                return BadRequest();
            }
        }

    }
}
