using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using FurnitureManufacturer.Engine;
using FurnitureManufacturer.Interfaces.Engine;

namespace FurnitureManufacturer.Injection
{
    internal sealed class AutofacConfig
    {
        private IContainer container;

        /// <summary>
        /// This method creates the IoC container. It creates a ContainerBuilder 
        /// which is passed to the RegisterMethod belows and returns the IoC;
        /// </summary>
        /// <returns></returns>
        public IContainer Build()
        {
            var builder = new ContainerBuilder();
            this.RegisterConvention(builder);
            this.RegisterCoreComponents(builder);

            this.container = builder.Build();

            return container;
        }

        /// <summary>
        /// Assembly scanning:
        /// This method uses Reflection to automatically register all
        /// classes in the assembly to the builder. This way you do not have to
        /// register each and everyone of them
        /// AsImplementedInterfaces() : Register the type as providing
        /// all of its public interfaces as services (excluding IDisposable).
        /// </summary>
        /// <param name="builder"></param>
        private void RegisterConvention(ContainerBuilder builder)
        {

            var currentAssemlby = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(currentAssemlby)
                .AsImplementedInterfaces();

        }

        /// <summary>
        /// This method registers components(A body of code that 
        /// declares the Services it provides and the Dependencies it consumes 
        /// of the program) with the IoC
        /// </summary>
        /// <param name="builder"></param>
        private void RegisterCoreComponents(ContainerBuilder builder)
        {

            builder.RegisterType<FurnitureManufacturerEngine>()
                .As<IFurnitureManufacturerEngine>()
                .SingleInstance();
            builder.RegisterType<EngineConstants>()
                .AsSelf()
                .SingleInstance();


        }


        

    }
}
