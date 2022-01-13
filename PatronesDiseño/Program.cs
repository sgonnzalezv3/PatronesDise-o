using PatronesDiseño.BuilderPattern;
using PatronesDiseño.DependencyInjection;
using PatronesDiseño.FactoryPattern;
using PatronesDiseño.Models;
using PatronesDiseño.RepositoryPattern;
using PatronesDiseño.StrategyPattern;
using PatronesDiseño.UnitOfWorkPattern;
using System;
using System.Linq;

namespace PatronesDiseño
{
    class Program
    {
        static void Main(string[] args)
        {

            //Singleton
            var singleton = Singleton.Singleton.Instance;
            var log = Singleton.Log.Instance;
            log.Save("a");
            log.Save("b");
            ///// factory method
            SaleFactory storeSaleFactory = new StoreSaleFactory(10);
            SaleFactory internetSaleFactory = new InternetSaleFactory(10);

            /* Creacion de objetos, haciendo uso de las fabricas */
            ISale sale1 = storeSaleFactory.GetSale();
            sale1.Sell(50);

            ISale sale2 = internetSaleFactory.GetSale();
            sale2.Sell(2);


            /* Inyeccion de dependencias */
            var beer = new DependencyInjection.Beer("Poker", "Bavaria");
            var drinkWithBeer = new DrinkWithBeer(5,5,beer);
            drinkWithBeer.Build();

            /* EF */
            using (var context = new PatronesDisenoContext())
            {
                var beerRepository = new BeerRepository(context);
                var cerveza = new Models.Beer();
                cerveza.Name = "Corona";
                cerveza.Style = "Millos";
                cerveza.BrandId = new Guid("ce9d4cdf-ff67-4e71-a3e6-1602faac5dff");

                beerRepository.Add(cerveza);
                beerRepository.Save();
                
                foreach(var cerv in beerRepository.Get())
                {
                    Console.WriteLine(cerv.Name);
                }
            }


            /* Repository Generic */
            using (var context = new PatronesDisenoContext())
            {
                /* Llamamos el repository y le pasamos el tipo de dato en concreto. */
                var beerRepository = new Repository<Models.Beer>(context);
                var cerveza = new Models.Beer() {Name ="Poker" ,  Style ="Rica" , BrandId = new Guid("ce9d4cdf-ff67-4e71-a3e6-1602faac5dff") };
                beerRepository.Add(cerveza);
                beerRepository.Save();

                foreach (var cerv in beerRepository.Get())
                {
                    Console.WriteLine(cerv.Name);
                }


                /* Llamamos el repository y le pasamos el tipo de dato en concreto. */
                var brandRepository = new Repository<Models.Brand>(context);
                var brand = new Models.Brand() { Name = "Bavaria"};
                brandRepository.Add(brand);
                brandRepository.Save();

                foreach (var brandi in brandRepository.Get())
                {
                    Console.WriteLine(brandi.Name);
                }
            }


            /* Repository con Unit Of WORK */

            using (var context = new PatronesDisenoContext())
            {
                var unitOfWork = new UnitOfWork(context);

                var beers = unitOfWork.Beers;
                var cervecita = new Models.Beer()
                {
                    Name = "Costeña",
                    Style = "Rica",
                    BrandId = new Guid("ce9d4cdf-ff67-4e71-a3e6-1602faac5dff")
                };

                beers.Add(cervecita);


                var brands = unitOfWork.Brands;
                var brandisita = new Models.Brand()
                {
                    Name = "Bavaria2",
                };

                brands.Add(brandisita);
                /* Aun no se ha guardado nada */


                /* Es hasta aqui que se guarda todo lo realizado en el proceso. */
                unitOfWork.Save();
            }

            /* Strategy */

            /* Aqui vemos dos practicas del principio SOLID 
             * RESPONSABILIDAD UNICA (Run)
               Abierto Cerrado : Clase abierta a extension, pero cerrada a modificacion
             */
            var strategyContext = new Context(new CarStrategy());
            strategyContext.Run();

            /* Cambio de comportamiento */
            strategyContext.Strategy = new MotoStrategy();
            strategyContext.Run();

            strategyContext.Strategy = new BicycleStrategy();
            strategyContext.Run();



            /* -------------      Builder   - ---------- */

            var builder = new PreparedAcoholicDrinkConcreteBuilder();

            /* director */
            var barmanDirector = new BarmanDirector(builder);

            barmanDirector.PrepareMargarita();
            var preparedDrink = builder.GetPreparedDrink();
            Console.WriteLine(preparedDrink.Result);


        }
    }
}
