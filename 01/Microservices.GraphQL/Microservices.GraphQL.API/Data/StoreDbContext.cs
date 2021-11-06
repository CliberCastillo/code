using Microservices.GraphQL.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservices.GraphQL.API.Data
{
    public class StoreDbContext: DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options): base(options)
        {           
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
    }
}
