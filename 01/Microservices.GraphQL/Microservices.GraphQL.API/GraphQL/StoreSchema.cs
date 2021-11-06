using GraphQL;
using GraphQL.Conversion;
using GraphQL.Types;
using Microservices.GraphQL.API.GraphQL;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microservices.GraphQL.API.GraphQL
{
    public class StoreSchema: Schema
    {
        public StoreSchema(IServiceProvider provider) : base(provider)
        {            
            NameConverter = PascalCaseNameConverter.Instance;
            Query = provider.GetRequiredService<StoreQuery>();            
        }
    }
}
