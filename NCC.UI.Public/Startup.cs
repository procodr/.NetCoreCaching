using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NCC.Domain.Contract;
using NCC.Infrustructure.Cache.Repository;
using NCC.Infrustructure.Data.Context;
using NCC.Infrustructure.Data.Repositories;
using NCC.Services.Application;
using NCC.Services.Contract;

namespace NCC.UI.Public
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            if (bool.Parse(Configuration["UseCache"]))
                services.AddScoped<IPersonRepository, CachedPersonRepository>();
            else
                services.AddScoped<IPersonRepository, PersonRepository>();
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
