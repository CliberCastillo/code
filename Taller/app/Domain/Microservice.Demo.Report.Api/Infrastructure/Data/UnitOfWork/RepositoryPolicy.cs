using Microservice.Demo.Report.Api.Infrastructure.Data.Repository;
using System;
using System.Threading.Tasks;

namespace Microservice.Demo.Report.Api.Infrastructure.Data.UnitOfWork
{
    public interface RepositoryPolicy : IDisposable
    {
        IPolicyRepository Policies { get; }

        Task CommitChanges();
        Task SaveAsync(object obj);
    }
}
