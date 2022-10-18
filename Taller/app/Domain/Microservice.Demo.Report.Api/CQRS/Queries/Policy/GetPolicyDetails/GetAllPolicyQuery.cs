using MediatR;
using Microservice.Demo.Report.Api.CQRS.Queries.Infrastructure.Dtos.Policy;
using System.Collections.Generic;

namespace Microservice.Demo.Report.Api.CQRS.Queries.Policy.GetPolicyDetails
{
    public class GetAllPolicyQuery : IRequest<IEnumerable<PolicyDto>>
    {
    }
}
