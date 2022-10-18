namespace Microservice.Demo.Report.Api.Infrastructure.Data.Repository
{
    using Microservice.Demo.Report.Api.Infrastructure.Data.Context;
    using Microservice.Demo.Report.Api.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class PolicyRepository: IPolicyRepository
    {
        private readonly ReportDbContext _reportDbContext;
        public PolicyRepository(ReportDbContext reportDbContext)
        {
            _reportDbContext = reportDbContext;
        }

        public async Task<List<Policy>> GetAllAsync()
        {
            return await _reportDbContext.Policies.ToListAsync();
        }
    }
}
    