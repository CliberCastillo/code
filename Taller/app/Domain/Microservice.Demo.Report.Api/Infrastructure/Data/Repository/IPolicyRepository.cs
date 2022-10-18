namespace Microservice.Demo.Report.Api.Infrastructure.Data.Repository
{
    using Microservice.Demo.Report.Api.Infrastructure.Data.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IPolicyRepository
    {
        Task<List<Policy>> GetAllAsync();
    }
}
