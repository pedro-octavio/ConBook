using Autofac;
using CONBook.API.Middlewares;
using CONBook.Data;
using CONBook.IOC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace CONBook.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ApplicationDataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CONBookDB"), migration =>
                {
                    migration.MigrationsAssembly("CONBook.API");
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Configuration["Version"], new OpenApiInfo
                {
                    Title = "CONBook.API",
                    Version = Configuration["Version"],
                    Description = "A application for control a Book collection.",
                    Contact = new OpenApiContact
                    {
                        Name = "Pedro Octávio Cruvinel Almeida",
                        Email = "pedrooctavio.dev@outlook.com",
                        Url = new Uri("https://github.com/pedro-octavio")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://github.com/pedro-octavio/CONBook/blob/main/LICENSE")
                    }
                });
            });
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new ModuleIOC());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/{Configuration["Version"]}/swagger.json", "CONBook.API"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
