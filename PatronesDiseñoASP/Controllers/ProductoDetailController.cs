using Herramientas.Earn;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatronesDiseñoASP.Controllers
{
    public class ProductoDetailController : Controller
    {
        private EarnFactory _localEearnFactory;
        private EarnFactory _foreignEearnFactory;

        /* inyectado */
        public ProductoDetailController(LocalEarnFactory localEarnFactory , ForeignEarnFactory foreignEarnFactory)
        {
            _localEearnFactory = localEarnFactory;
            _foreignEearnFactory = foreignEarnFactory;
        }
        public IActionResult Index(decimal total)
        {
            /* Fabrica */
            /*
             * por inyeccion de dependencias no es conveniente crear objetos aqui
            LocalEarnFactory localEarnFactory = new LocalEarnFactory(0.20m);
            ForeignEarnFactory foreignEarnFactory = new ForeignEarnFactory(0.30m,20);
            */

            /* ahora llamas ese objeto desde el constructor, creando uno privado */


            /* Producto (objeto que genera la fabrica.) */
            var localEarn = _localEearnFactory.GetEarn();
            var foreignEarn = _foreignEearnFactory.GetEarn();

             /*total  */
            ViewBag.totalLocal = total + localEarn.Earn(total);
            ViewBag.totalForeign = total + foreignEarn.Earn(total);

            return View();
        }
    }
}
