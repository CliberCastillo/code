using GraphQL.Types;
using Microservices.GraphQL.API.Data;

namespace Microservices.GraphQL.API.GraphQL.Types
{
    public class ProductTypeEnumType: EnumerationGraphType<ProductTypeEnum>
    {
        public ProductTypeEnumType()
        {
            Name = "Type";
            Description = "The type of product";
        }
    }
}
