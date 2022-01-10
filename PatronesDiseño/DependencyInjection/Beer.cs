using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.DependencyInjection
{
    public class Beer
    {
        public string _name;
        public string _brand;
    

        /* propiedad que solo va a regresar el valor */
        public string Name
        {
            get
            {
                return _name;
            }
        }

        public Beer(string name, string brand)
        {
            _name = name;
            _brand = brand;
        }
    }
}
