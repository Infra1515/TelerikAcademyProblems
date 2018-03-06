using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Engine;
using Cosmetics.Engine.Commands;
using Cosmetics.Engine.Commands.Category;
using Cosmetics.Engine.Commands.Create;
using Cosmetics.Engine.Commands.ShoppingCart;
using Cosmetics.Engine.Factories;

namespace Cosmetics.Injection
{
    public sealed class AutofacConfig : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var currentAssembly = Assembly.Load("Cosmetics");

            builder.RegisterAssemblyTypes(currentAssembly)
                .AsImplementedInterfaces();


            // Register core components
            builder.RegisterType<CosmeticsEngine>()
                .As<IEngine>()
                .SingleInstance();

            builder.RegisterType<DataStore>()
                .As<IDataStore>()
                .SingleInstance(); 

            builder.RegisterType<Constants>()
                .AsSelf()
                .SingleInstance();


            // Register commands
            // Category
            builder.RegisterType<AddToCategory>()
                .Named<ICommand>("addtocategory");
            builder.RegisterType<RemoveFromCategory>()
                .Named<ICommand>("removefromcategory");
            builder.RegisterType<ShowCategory>()
                .Named<ICommand>("showcategory");
            // Create
            builder.RegisterType<CreateCategory>()
                .Named<ICommand>("createcategory");
            builder.RegisterType<CreateShampoo>()
                .Named<ICommand>("createshampoo");
            builder.RegisterType<CreateToothpaste>()
                .Named<ICommand>("createtoothpaste");
            // Shopping cart
            builder.RegisterType<AddToShoppingCart>()
                .Named<ICommand>("addtoshoppingcart");
            builder.RegisterType<RemoveFromShoppingCart>()
                .Named<ICommand>("removefromshoppingcart");
            builder.RegisterType<TotalPrice>()
                .Named<ICommand>("totalprice");

            builder.RegisterType<CommandFactory>()
             .As<ICommandsFactory>()
             .SingleInstance();
        }
    }
}
