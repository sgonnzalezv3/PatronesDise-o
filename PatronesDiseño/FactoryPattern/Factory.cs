using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* Tanto StoreSale es diferente A InternetSale, existe una relacion y es que ambos son una venta, por
 * lo cual tiene algo que los relaciona, como la implementacion de ISale*/
namespace PatronesDiseño.FactoryPattern
{
    /* 
     *   CREATOR
     *   
     *   
     *   Fabrica de ventas:
     *   se puede tener una venta en internet, pero tambien las puedes tener en tu zona local
     *   u otra quiza telefonica, y podrian tener cierta relacion, o cierto funcionamiento parecido.
     *   
     *   Para esto se crea una fabrica de ventas, representada en una clase abstracta
     */
    public abstract class SaleFactory
    {
        /* hacemos uso de una interface */
        public abstract ISale GetSale();
    }

    // CONCRETE CREATOR
    public class StoreSaleFactory : SaleFactory
    {
        /* La fabrica es la encargada de gestionar los atributos, manejo de esas responsabiliades  */

        /* Creamos la fabrica */
        /* las fabricas se encargan de los atributos */
        private decimal _extra;

        public StoreSaleFactory(decimal extra)
        {
            _extra = extra;
        }


        /* creacion del objeto */
        public override ISale GetSale()
        {
            return new StoreSale(_extra);
        }
    }


    // CONCRETE CREATOR
    public class InternetSaleFactory : SaleFactory
    {
        /* La fabrica es la encargada de gestionar los atributos, manejo de esas responsabiliades  */

        /* Creamos la fabrica */
        /* las fabricas se encargan de los atributos */
        private decimal _discount;

        public InternetSaleFactory(decimal discount)
        {
            _discount = discount;
        }


        /* creacion del objeto */
        public override ISale GetSale()
        {
            return new InternetSale(_discount);
        }
    }

    //Concrete Product
    public class StoreSale : ISale
    {
        private decimal _extra;
        public StoreSale(decimal extra)
        {
            _extra = extra;
        }

        public void Sell(decimal total)
        {
            Console.WriteLine($"realizando venta en tienda, total de {total + _extra}");
        }
    }

    /* Si queremos un nuevo tipo de ventas (internet) creamos otra clase que implemente de ISale */

    public class InternetSale : ISale
    {
        private decimal _discount;
        public InternetSale(decimal discount)
        {
            _discount = discount;
        }
        public void Sell(decimal total)
        {
            Console.WriteLine($"venta en internet tiene total de : { total - _discount}");
        }
    }

    /* NECESITAMOS UNA INTERFACE QUE SERA LA REPRESENTACION DE NUESTRO PRODUCTO. */
    // PRODUCTO
    public interface ISale
    {
        /* Todas las ventas tienen que vender. */
        public void Sell(decimal total);
    }

}
