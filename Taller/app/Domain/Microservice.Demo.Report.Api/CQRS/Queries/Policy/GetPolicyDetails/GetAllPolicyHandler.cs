using MediatR;
using Microservice.Demo.Report.Api.CQRS.Queries.Infrastructure.Dtos.Policy;
using Microservice.Demo.Report.Api.Infrastructure.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.Demo.Report.Api.CQRS.Queries.Policy.GetPolicyDetails
{

    public class GetAllPolicyHandler : IRequestHandler<GetAllPolicyQuery, IEnumerable<PolicyDto>>
    {
        private readonly IPolicyRepository _repositoryPolicy;

        public GetAllPolicyHandler(IPolicyRepository repositoryPolicy)
        {
            _repositoryPolicy = repositoryPolicy;
        }

        public async Task<IEnumerable<PolicyDto>> Handle(GetAllPolicyQuery request, CancellationToken cancellationToken)
        {
            var result = await _repositoryPolicy.GetAllAsync();

            return result.Select(p => new PolicyDto
            {
                Number = p.Number,
                ProductCode = p.ProductCode,
                AgentLogin = p.AgentLogin,
                PolicyStatusId = p.PolicyStatusId,
                CreationDate = p.CreationDate
            }).ToList();
        }
    }
}
