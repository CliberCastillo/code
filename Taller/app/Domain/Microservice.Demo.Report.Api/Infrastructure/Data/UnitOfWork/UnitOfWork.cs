using Microservice.Demo.Report.Api.Infrastructure.Data.Context;
using Microservice.Demo.Report.Api.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace Microservice.Demo.Report.Api.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : RepositoryPolicy
    {
        private readonly ReportDbContext _reportDbContext;
        private readonly IDbContextTransaction tx;
        private readonly PolicyRepository _policyRepository;
        public IPolicyRepository Policies => _policyRepository;


        public UnitOfWork(ReportDbContext reportDbContext)
        {
            _reportDbContext = reportDbContext;
            tx = _reportDbContext.Database.BeginTransaction();
            _policyRepository = new PolicyRepository(reportDbContext);
        }

        public async Task CommitChanges()
        {
            try
            {
                _reportDbContext.SaveChanges();
                await tx.CommitAsync();
            }
            catch (Exception ex)
            {
                await tx.RollbackAsync();
                throw ex;
            }
           
        }

        public async Task SaveAsync(object obj)
        {
            _reportDbContext.Add(obj);
            await _reportDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                tx?.Dispose();
            }

        }
    }
}
