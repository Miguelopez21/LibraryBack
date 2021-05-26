using Autofac;
using DataAccess;
using DataAccess.EntityFramework;
using Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace IoC
{
    public static class Container
    {
        public static ContainerBuilder Register(ContainerBuilder builder)
        {
            builder.Register(c =>
                {
                    var options = new DbContextOptionsBuilder<LibraryContext>()
                           .UseInMemoryDatabase(databaseName: "Test")
                           .Options;

                    return new LibraryContext(options);
                })
                .As<IContext>()
                .InstancePerLifetimeScope();

            builder
                .RegisterGeneric(typeof(ReadRepository<>))
                .As(typeof(IReadRepository<>));

            builder
                .RegisterGeneric(typeof(WriteRepository<>))
                .As(typeof(IWriteRepository<>));

            builder
                .RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>));

            return builder;
        }
    }
}
