using Autofac;
using FurnitureManufacturer.Engine;
using FurnitureManufacturer.Injection;
using FurnitureManufacturer.Interfaces.Engine;

namespace FurnitureManufacturer
{
    public class FurnitureProgram
    {
        /// <summary>
        ///  make use of the components you registered.
        ///  You do this by resolving them from a lifetime scope.
        ///  When you resolve a component, depending on the instance scope you
        ///  define, a new instance of the object gets created. 
        ///  Resolving a component
        ///  is roughly equivalent to calling “new” to instantiate a class.
        /// </summary>
        public static void Main()
        {
            var containerConfig = new AutofacConfig();
            var container = containerConfig.Build();
            var engine = container.Resolve<IFurnitureManufacturerEngine>();
            engine.Start();
        }
    }
}
