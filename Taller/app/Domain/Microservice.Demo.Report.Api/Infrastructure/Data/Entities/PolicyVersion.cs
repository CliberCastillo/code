﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace Microservice.Demo.Report.Api.Infrastructure.Data.Entities
{
    public partial class PolicyVersion
    {
        public int PolicyVersionId { get; set; }
        public int VersionNumber { get; set; }
        public decimal TotalPremiumAmount { get; set; }
        public int PolicyId { get; set; }
        public int PolicyHolderId { get; set; }
        public int CoverPeriodPolicyValidityPeriodId { get; set; }
        public int VersionValidityPeriodPolicyValidityPeriodId { get; set; }
        public virtual Policy Policy { get; set; }
    }
}