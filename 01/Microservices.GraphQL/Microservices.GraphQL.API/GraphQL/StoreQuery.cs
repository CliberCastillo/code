using GraphQL;
using GraphQL.Types;
using Microservices.GraphQL.API.GraphQL.Types;
using Microservices.GraphQL.API.Repositories;

namespace Microservices.GraphQL.API.GraphQL
{
    public class StoreQuery : ObjectGraphType
    {
        public StoreQuery(ProductRepository productRepository)
        {
            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => productRepository.GetAll()
            );

            Field<ProductType>(
                "product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return productRepository.GetOne(id);
                }
            );
        }
    }
}
