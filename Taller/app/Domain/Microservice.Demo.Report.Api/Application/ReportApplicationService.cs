using MediatR;
using Microservice.Demo.Report.Api.CQRS.Queries.Infrastructure.Dtos.Policy;
using Microservice.Demo.Report.Api.CQRS.Queries.Policy.GetPolicyDetails;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservice.Demo.Report.Api.Application
{
    public class ReportApplicationService
    {
        private readonly IMediator _mediator;
        public ReportApplicationService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IEnumerable<PolicyDto>> GetAllAsync()
        {
            var result = await _mediator.Send(new GetAllPolicyQuery());
            return result;
        }
    }
}
