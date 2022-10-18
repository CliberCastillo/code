using Microservice.Demo.Report.Api.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Demo.Report.Api.Infrastructure.Data.Context
{
    public class ReportDbContext: DbContext
    {
        public ReportDbContext()
        {
        }

        public ReportDbContext(DbContextOptions<ReportDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<PolicyStatus> PolicyStatuses { get; set; }
        public virtual DbSet<PolicyVersion> PolicyVersions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }
    }
}
