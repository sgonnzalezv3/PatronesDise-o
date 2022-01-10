using System;
using System.IO;

namespace Herramientas
{
    /* Sealed hace que una clase no se pueda heredar */
    public  sealed class Log
    {
        private static Log _instance = null;
        private string _path;
        /* Importante, tener en cuenta casos cuando trabajamos con hilos, que puede que 2 procesos llegen a este mismo punto
         * lo que implicaria que se crearian dos instancias, pero se obtendria la ultima creada, evitar esto!
        */
        /* esto protege de procesos asincronos mediante uso de lock() */
        public static object _protect = new object();


        /* A diferencia del otro log, cambiamos la propiedad por un metodo, ya que una propiedad no recibe parametros. */
        /* Basicamente se encarga de analizar si el objeto ya esta creado, de ser asi, devuelve este objeto, sino, lo crea */
        public static Log GetInstance(string path)
        {
            /* mientras un hilo se encuentra trabajando con este hilo, el otro no puede trabajar */
            /* sino hasta que termine, cuando llegue el segundo, ya la instancia _instance va a estar inicializada entonces ya no habria problemas*/
            lock (_protect)
            {
                if (_instance == null)
                {
                    /* Creamos un nuevo objeto y le pasamos el path o la ruta */
                    _instance = new Log(path);
                }
            }

            return _instance;
        }
        /* constructor que recibe como parametro la ruta (solo va a ser llamado por la misma clase) */
        private Log(string path)
        {
            _path = path;
        }
        public void Save(string message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }
    }
}
