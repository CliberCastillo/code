using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.Persistence.EFCore.Data.Contexts;
using Microservice.Persistence.EFCore.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microservice.Persistence.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ////////////////////////////////// EF CORE ////////////////////////////////////////////////////
            string conn = Configuration.GetConnectionString("Microservice.Persistence.EFCoreDB");
            //string conn = Configuration.GetConnectionString("Microservice.Persistence.EFCoreDB.azure");
            services.AddDbContext<MicroservicePersistenceEFcoreContext>(opt =>
            {
                opt.UseSqlServer(conn);
            });
            services.AddScoped<IOrderRepository,OrderRepository>();
            ///////////////////////////////////////////////////////////////////////////////////////////////
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
