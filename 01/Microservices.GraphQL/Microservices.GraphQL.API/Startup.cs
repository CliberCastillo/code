using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservices.GraphQL.API.GraphQL;
using GraphQL;
using Microservices.GraphQL.API.Data;
using Microservices.GraphQL.API.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Microservices.GraphQL.API
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
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddCors(options => options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            }));

            services.AddDbContext<StoreDbContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:Microservices.GraphQL"]));

            services.AddScoped<ProductRepository>();
            services.AddScoped<ProductReviewRepository>();
            services.AddScoped<ISchema, StoreSchema>();


            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
            })
            .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
            .AddNewtonsoftJson()
            .AddGraphTypes(ServiceLifetime.Scoped)
            .AddUserContextBuilder(context => new GraphQLUserContext { User = context.User })
            .AddDataLoader();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, StoreDbContext dbContext)
        {
            app.UseCors("AllowAll");
            app.UseGraphQL<ISchema>();
            app.UseGraphQLPlayground();
            dbContext.Seed();
        }
    }
}
