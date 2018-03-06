using Autofac;
using Cosmetics.Contracts;
using Cosmetics.Engine;
using Cosmetics.Injection;

namespace Cosmetics
{
    public class CosmeticsProgram
    {
        public static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacConfig());
            var container = builder.Build();

            var engine = container.Resolve<IEngine>();
            engine.Start();

        }
    }
}
