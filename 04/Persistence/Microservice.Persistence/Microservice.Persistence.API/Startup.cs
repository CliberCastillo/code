using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.Persistence.EFCore.Data.Contexts;
using Microservice.Persistence.EFCore.Data.Repositories;
using Microservice.Persistence.NoSQL.Cosmo.EFCore.Data.Contexts;
using Microservice.Persistence.NoSQL.Cosmo.EFCore.Data.Init;
using Microservice.Persistence.NoSQL.Cosmo.EFCore.Data.Repositories;
using Microservice.Persistence.NoSQL.Mongo.Data.Settings;
using Microservice.Persistence.NoSQL.Mongo.Service;
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

            ////////////////////////////////// MONGODB ////////////////////////////////////////////////////
            services.Configure<BookstoreDatabaseSettings>(
                Configuration.GetSection(nameof(BookstoreDatabaseSettings)));

            services.AddSingleton<IBookstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);

            services.AddSingleton<IBookService,BookService>();

            ////////////////////////////////// COSMODB ////////////////////////////////////////////////////
            services.AddDbContext<OrderNoSqlContext>(opt =>
            {
                opt.UseCosmos("https://usrsqlcosmopersistence.documents.azure.com:443/",
                    "PzHoc7PVOr9t6kKnFpTuuHShtDnq8UJOrycpEljfWmPYcfEt9rJzsngWbPIwQxVUBejanbbWVNviSHZ7FKzjgg==",
                    databaseName: "OrdersDB");
            });

            services.AddScoped<IOrderNoSqlRepository, OrderNoSqlRepository>();
            ///////////////////////////////////////////////////////////////////////////////////////////////
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,OrderNoSqlContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            DataSeeder.SeedOrders(context);

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
