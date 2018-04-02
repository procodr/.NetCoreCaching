using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NCC.Domain.Contract;
using NCC.Infrustructure.Cache.Contract;
using NCC.Infrustructure.Cache.Implemention;
using NCC.Infrustructure.Cache.Repository;
using NCC.Infrustructure.Data.Context;
using NCC.Infrustructure.Data.Repository;
using NCC.Services.Application;
using NCC.Services.Contract;
using System;

namespace NCC.UI.Public
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMemoryCache();
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = "localhost";
            });
            services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
                    );
            //services.AddTransient<ICacheAdapter, InMemoryCacheAdapter>();
            services.AddTransient<ICacheAdapter, DistributedCacheAdapter>();
            //services.AddTransient<ICacheAdapter>(service =>
            //{
            //    switch (_configuration["CacheMode"])
            //    {
            //        case "redis":
            //        //case "sql-dist": TODO: To be implemented
            //            return service.GetService<DistributedCacheAdapter>();
            //        case "in-memory":
            //            return service.GetService<InMemoryCacheAdapter>();
            //        default:
            //            throw new Exception();
            //    }
            //});
            services.AddScoped<CachedPersonRepository, CachedPersonRepository>();
            services.AddScoped<PersonRepository, PersonRepository>();
            services.AddScoped<IPersonRepository>(service =>
            {
                switch (_configuration["CacheMode"])
                {
                    case "redis":
                    //case "sql-dist": TODO: To be implemented
                    case "in-memory":
                        return service.GetService<CachedPersonRepository>();
                    default:
                        return service.GetService<PersonRepository>();
                }
            });
            services.AddTransient<IPersonService, PersonService>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
        }
    }
}
