using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.Singleton
{
    public class Singleton
    {
        // este sera el unico objeto que vamos a crear de esta clase
        private readonly static Singleton _instance = new Singleton();
        
        //ahora vamos a crear el acceso a la propiedad de arriba, _instance
        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }
        // para hacer que no se pueda crear otro objeto de esta clase, constructor privado
        private Singleton()
        {

        }
    }
}
