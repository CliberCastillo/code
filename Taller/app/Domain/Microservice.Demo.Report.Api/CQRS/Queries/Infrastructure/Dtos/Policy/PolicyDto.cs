using System;

namespace Microservice.Demo.Report.Api.CQRS.Queries.Infrastructure.Dtos.Policy
{
    public class PolicyDto
    {
        public string Number { get; set; }
        public string ProductCode { get; set; }
        public string AgentLogin { get; set; }
        public int PolicyStatusId { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
