using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using CONBook.Application.Core.Interfaces;
using CONBook.Application.Mappers;
using CONBook.Application.Services.Services;
using CONBook.Data.Core.Interfaces;
using CONBook.Data.Services.Services;
using CONBook.Domain.Core.Interfaces;
using CONBook.Domain.Services.Services;

namespace CONBook.IOC.IOC
{
    public static class ConfigurationIOC
    {
        public static void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterAutoMapper(typeof(MappingProfile).Assembly);

            containerBuilder.RegisterType<BookApplicationService>().As<IBookApplicationService>();

            containerBuilder.RegisterType<BookService>().As<IBookService>();

            containerBuilder.RegisterType<BookRepository>().As<IBookRepository>();
        }
    }
}
