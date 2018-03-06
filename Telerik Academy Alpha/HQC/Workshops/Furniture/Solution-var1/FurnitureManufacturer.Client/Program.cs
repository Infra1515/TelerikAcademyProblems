using Autofac;
using FurnitureManufacturer.Client.InjectionConfig;
using FurnitureManufacturer.Interfaces.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacConfig());
            var container = builder.Build();

            var engine = container.Resolve<IEngine>();
            engine.Start();
        }
    }
}
